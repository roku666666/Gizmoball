using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GizmoBall
{
    public enum TypeGizmo { BUMPER, FLIPPER, ABSORBER, BALL };

    public abstract class Gizmo
    //  Description:    是棋盤上所有控制項的抽象類代表
    {
        protected TypeGizmo type;
        protected Position pos;    // 棋盤中的位置, 指代unit， 範圍是長寬0~LENGTH_BOARD-1

        public Gizmo()
        {
            pos = new Position();
        }

        public TypeGizmo GetType()
        {
            return type;
        }

        public void SetType(TypeGizmo t)
        {
            type = t;
        }

        public Position GetPos()
        {
            return pos;
        }

        public void SetPos(Position p)
        {
            pos = p;
        }

        public void SetPos(int cX, int cY)
        {
            pos.SetCoordinate(cX, cY);
        }

        public bool IsInBoard()
        {
            return pos.IsInBoard();
        }
    }
}
