using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GizmoBall
{
    public enum Box { ALL_AVAIL, CAPTURED, ONLY_L_D, ONLY_R_D }

    public class PlayZone
    {
        public const int LENGTH_BOARD = 20;    // Side length of arena, 量綱是unit,即長度是按unit算的        

        protected Box[,] boxs;   // 遊戲中的基本單元，共有LENGTH_BOARD*LENGTH_BOARD個unit

        protected List<Gizmo> gizmos;

        public PlayZone()
        {
            boxs = new Box[LENGTH_BOARD, LENGTH_BOARD];
            for (int i = 0; i < LENGTH_BOARD; i++)
                for (int j = 0; j < LENGTH_BOARD; j++)
                {
                    boxs[i, j] = Box.ALL_AVAIL;
                }
            gizmos = new List<Gizmo>();
        }

        public void Clear()
        {
            for (int i = 0; i < LENGTH_BOARD; i++)
                for (int j = 0; j < LENGTH_BOARD; j++)
                {
                    boxs[i, j] = Box.ALL_AVAIL;
                }
            gizmos.Clear();
        }

        //public bool DetectGizmo(Position p, Gizmo g)
        ////  Post:   檢測并返回在指定位置p是否能安放gizmo
        //{
        //    if (g is Bumper) return DetectGizmo(p, (Bumper)g);
        //    else if (g is Flipper) return DetectGizmo(p, (Flipper)g);
        //    else if (g is Absorber) return DetectGizmo(p, (Absorber)g);
        //    else return false;
        //}

        public bool InstallGizmo(Bumper g)
        //  Post:   在棋盤上安裝該部件，如果裝不上，返回false，裝上了返回true
        {
            if (DetectGizmo(g))
            {
                AddGizmo(g); return true;
            }
            return false;
        }

        public bool InstallGizmo(Flipper g)
        //  Post:   在棋盤上安裝該部件，如果裝不上，返回false，裝上了返回true
        {
            if (DetectGizmo(g))
            {
                AddGizmo(g); return true;
            }
            return false;
        }

        public bool InstallGizmo(Absorber g)
        //  Post:   在棋盤上安裝該部件，如果裝不上，返回false，裝上了返回true
        {
            if (DetectGizmo(g))
            {
                AddGizmo(g); return true;
            }
            return false;
        }

        public bool InstallGizmo(Ball g)
        //  Post:   在棋盤上安裝該部件，如果裝不上，返回false，裝上了返回true
        {
            if (DetectGizmo(g))
            {
                AddGizmo(g); return true;
            }
            return false;
        }

        public bool UninstallGizmo(Position p)
        //  Post:   在棋盤上指定位置上刪除部件，如果沒有部件可以刪除，返回false，否則刪掉了返回true
        {
            foreach(Gizmo g in gizmos)
            {
                if(g.GetPos() == p)
                {
                    //  那就是這個gizmo了
                    if (g is Bumper) RemoveGizmo((Bumper)g);
                    else if (g is Flipper)RemoveGizmo((Flipper)g);
                    else if (g is Absorber) RemoveGizmo((Absorber)g);
                    else if (g is Ball) RemoveGizmo((Ball)g);
                    return true;
                }
            }
            return false;
        }      

        public bool UninstallGizmo(int cX, int cY)
        {
            Position p = new Position(cX, cY);
            return UninstallGizmo(p);
        }

        public bool PlaceBall(Ball b)
        //  Post:   在棋盤上放球， 如果放不上，返回false，放好了返回true
        {
            return InstallGizmo(b);
        }

        public bool DetectGizmo(Bumper b)
        //  Post:   檢測并返回在b的位置是否能安放b彈性部件
        {
            if (b.IsInBoard())
            {
                if (IsAvailable(b.GetPos()))  //  空的格子
                {
                    return true;    // 因為b只會占一格~
                }
                else if(b is BumperTrg)
                {
                    BumperTrg t = (BumperTrg)b;
                    if (GetState(b.GetPos()) == Box.ONLY_L_D && t.GetOrientation() == OrientTrg.L_D
                        || GetState(b.GetPos()) == Box.ONLY_R_D && t.GetOrientation() == OrientTrg.R_D)
                        return true;                    
                }
            }
            return false;
        }

        public bool DetectGizmo(Flipper f)
        //  Post:   檢測并返回在f的位置是否能安放flipper部件
        {
            // 檢查這個flipper所影響的f.LENGTH^2個格子
            Position p = f.GetPos();
            int fLen = f.GetLength();
            Position[,] boxAffected = new Position[fLen, fLen];

            if (f.GetOrientation() == OrientFlp.LEFT)
            {
                // f的pos的右、下f.LENGTH行要被佔掉
                for (int i = 0; i < fLen; i++)
                    for (int j = 0; j < fLen; j++)
                    {
                        boxAffected[i, j] = new Position(p.GetX() + i, p.GetY() + j);
                    }
            }
            else
            {
                // f的pos的左、下f.LENGTH行要被佔掉
                for (int i = 0; i < fLen; i++)
                    for (int j = 0; j < fLen; j++)
                    {
                        boxAffected[i, j] = new Position(p.GetX() - i, p.GetY() + j);
                    }
            }

            //  檢查這些格子有沒有超出範圍的，有一個都不行
            foreach (Position pos in boxAffected)
            {
                if (!pos.IsInBoard()) return false;
            }

            //  再檢查這些格子可不可用
            foreach (Position pos in boxAffected)
            {
                if (!IsAvailable(pos)) return false;
            }

            return true;
        }

        public bool DetectGizmo(Absorber a)
        //  Pre:    這裡假設Absorber類嚴格控制其實例的pos的y坐標都是0
        //  Post:   檢測并返回在a的位置是否能安放absorber部件
        {
            if (!a.IsInBoard()) return false;
            for(int j=0;j<LENGTH_BOARD;j++)
            {
                if (!IsAvailable(a.GetRow(), j)) return false;
            }
            return true;
        }

        public bool DetectGizmo(Ball b)
        //  Post:   檢測并返回在b的位置是否能安放小球
        {
            if (b.IsInBoard())
            {
                if (IsAvailable(b.GetPos()))  //  空的格子
                {
                    return true;    // 因為小球只會占一格~
                }
            }
            return false;
        }

        protected void AddGizmo(Bumper b)
        //  Pre:    前提要是DetectGizmo是true的情況下才能add,並且b中已經記錄了要插入的位置
        //  Post:   將該bumper放置在指定位置上，周圍格子的狀態也設置好
        {
            gizmos.Add(b);
            SetState(b.GetPos(), Box.CAPTURED);
        }

        protected void AddGizmo(Flipper f)
        //  Pre:    前提要是DetectGizmo是true的情況下才能add,並且f中已經記錄了要插入的位置
        //  Post:   將該Flipper放置在指定位置上，周圍格子的狀態也設置好
        {
            gizmos.Add(f);
         
            Position p = f.GetPos();
            int fLen = f.GetLength();

            if( f.GetOrientation() == OrientFlp.LEFT)
            {
                // f的pos的右、下f.LENGTH行要被佔掉
                for (int i = 0; i < fLen; i++)
                    for (int j = 0; j < fLen; j++)
                    {
                        SetState(p.GetX() + i, p.GetY() + j, Box.CAPTURED);
                    }
                SetState(p.GetX() + fLen - 1, p.GetY() + fLen - 1, Box.ONLY_R_D);
            }
            else
            {
                // f的pos的左、下f.LENGTH行要被佔掉
                for (int i = 0; i < fLen; i++)
                    for (int j = 0; j < fLen; j++)
                    {
                        SetState(p.GetX() - i, p.GetY() + j, Box.CAPTURED);
                    }
                SetState(p.GetX() - fLen + 1, p.GetY() + fLen - 1, Box.ONLY_L_D);
            }
        }

        protected void AddGizmo(Absorber a)
        //  Pre:    前提要是DetectGizmo是true的情況下才能add,並且a中已經記錄了要插入的位置
        //  Post:   將該Absorber放置在指定行上，該行格子的狀態也設置好
        {
            gizmos.Add(a);
            for (int j = 0; j < LENGTH_BOARD; j++)
            {
                SetState(a.GetRow(), j, Box.CAPTURED);
            }
        }

        protected void AddGizmo(Ball b)
        //  Pre:    前提要是DetectGizmo是true的情況下才能add,並且b中已經記錄了要插入的位置
        //  Post:   將該小球放置在指定位置上，周圍格子的狀態也設置好
        {
            gizmos.Add(b);
            SetState(b.GetPos(), Box.CAPTURED);
        }

        protected void RemoveGizmo(Bumper b)
        //  Pre:    b要之前被成功地加進去過的並且調用時還在棋盤上
        //  Post:   將該bumper從他自己的位置刪去並且設置好周圍格子的狀態
        {
            gizmos.Remove(b);
            SetState(b.GetPos(), Box.ALL_AVAIL);
        }

        protected void RemoveGizmo(Flipper f)
        //  Pre:    f要之前被成功地加進去過的並且調用時還在棋盤上
        //  Post:   將該flipper從他自己的位置刪去並且設置好周圍格子的狀態
        {
            gizmos.Remove(f);

            Position p = f.GetPos();
            int fLen = f.GetLength();

            if (f.GetOrientation() == OrientFlp.LEFT)
            {
                // f的pos的右、下f.LENGTH行要被佔掉
                for (int i = 0; i < fLen; i++)
                    for (int j = 0; j < fLen; j++)
                    {
                        SetState(p.GetX() + i, p.GetY() + j, Box.ALL_AVAIL);
                    }
            }
            else
            {
                // f的pos的左、下f.LENGTH行要被佔掉
                for (int i = 0; i < fLen; i++)
                    for (int j = 0; j < fLen; j++)
                    {
                        SetState(p.GetX() - i, p.GetY() + j, Box.ALL_AVAIL);
                    }
            }
        }

        protected void RemoveGizmo(Absorber a)
        //  Pre:    a要之前被成功地加進去過的並且調用時還在棋盤上
        //  Post:   將該absorber從他自己的位置刪去並且設置好周圍格子的狀態
        {
            gizmos.Remove(a);
            for (int j = 0; j < LENGTH_BOARD; j++)
            {
                SetState(a.GetRow(), j, Box.ALL_AVAIL);
            }
        }

        protected void RemoveGizmo(Ball b)
        //  Pre:    b要之前被成功地加進去過的並且調用時還在棋盤上
        //  Post:   將該小球從他自己的位置刪去並且設置好周圍格子的狀態
        {
            gizmos.Remove(b);
            SetState(b.GetPos(), Box.ALL_AVAIL);
        }

        public Box GetState(Position p)
        //  Post:   返回當前格子的狀態(即是否被佔用等等)，如果該格子越界，那就返回被佔的狀態
        {
            if (p.IsInBoard())
            {
                return boxs[p.GetX(), p.GetY()];
            }
            return Box.CAPTURED;
        }

        public Box GetState(int cX, int cY)
        //  Post:   返回當前格子的狀態(即是否被佔用等等)，如果該格子越界，那就返回被佔的狀態
        {
            Position p = new Position(cX, cY);
            return GetState(p);
        }

        public void SetState(Position p, Box state)
        //  Post:   將state狀態賦予當前格子
        {
            if(p.IsInBoard())
            {
                boxs[p.GetX(), p.GetY()] = state;
            }
        }

        public void SetState(int cX, int cY, Box state)
        //  Post:   將state狀態賦予當前格子
        {
            Position p = new Position(cX, cY);
            SetState(p, state);
        }

        public bool IsAvailable(Position p)
        //  Post:   給定坐標p, 返回是否是ALL_AVAIL狀態，即是不是沒有被Gizmo或Gizmo相關的格子佔用,如果p超出棋盤範圍，也返回false
        {
            if (p.IsInBoard())
            {
                if (boxs[p.GetX(), p.GetY()] == Box.ALL_AVAIL)
                    return true;
            }
            return false;
        }

        public bool IsAvailable(int cX, int cY)
        //  Post:   給定坐標cX, cY, 返回是否是ALL_AVAIL狀態，即是不是沒有被Gizmo或Gizmo相關的格子佔用,如果p超出棋盤範圍，也返回false
        {
            Position p = new Position(cX, cY);
            return IsAvailable(p);
        }
    }

    //*************************************************************************

    public class Position
    //  Pre:    x和y的範圍都需要在0~LENGTH_BOARD-1內
    //  Post:   表示一個Gizmo的坐標
    {
        int x, y;
        
        public Position()
        {
            x = y = 0;
        }

        public Position(int cX, int cY)
        {
            if (!CheckCoordinate(cX, cY))
                x = y = 0;
            else            
                SetCoordinate(cX, cY);
        }

        protected bool CheckCoordinate(int x)
        {
            if (x >= PlayZone.LENGTH_BOARD || x < 0)
                return false;
            return true;
        }

        protected bool CheckCoordinate(int x, int y)
        {
            return CheckCoordinate(x) && CheckCoordinate(y);
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public void SetX(int cX)
        {
            x = cX;
        }

        public void SetY(int cY)
        {
            y = cY;
        }

        public void SetCoordinate(int cX, int cY)
        {
            SetX(cX); SetY(cY);
        }

        public bool IsInBoard()
        {
            if (x > PlayZone.LENGTH_BOARD - 1 || x < 0 || y > PlayZone.LENGTH_BOARD - 1 || y < 0)
                return false;
            return true;
        }

        public void DragIntoBoard()
        //  Post:   檢查這個Position的橫縱坐標, 如果超出Board就拖回Board
        {
            if (x > PlayZone.LENGTH_BOARD - 1)
                x = PlayZone.LENGTH_BOARD - 1;
            else if (x < 0)
                x = 0;

            if (y > PlayZone.LENGTH_BOARD - 1)
                y = PlayZone.LENGTH_BOARD - 1;
            else if (y < 0)
                y = 0;
        }
    }
}
