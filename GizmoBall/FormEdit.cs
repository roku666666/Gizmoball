using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GizmoBall
{
    public partial class FormEdit : Form
    {
        protected const int LENGTH_UNIT = 20;               // 一格占多少像素
        protected const int LENGTH_BOARD = 401;             // 棋盤的邊長占多少像素(從第0到第400)
        protected const float WIDTH_BOARD = 2.0f;
        protected const float WIDTH_BOX = 0.2f;
        Point corner_L_U;                                   // 格子左上角的像素坐標(plBoard中的坐標)
        Point corner_R_D;

        bool isDrawing = false;
        Gizmo tempGizmo;                                    // 臨時的Gizmo，用來存儲臨時放在棋盤上的gizmo
        Position posPre;
        Position posCur;
        Graphics drawer = Graphics.FromImage(global::GizmoBall.Properties.Resources.ball);
        //Image drawingImg;
        //TypeGizmo curTypeG;
        //TypeBumper curTypeB;
        //OrientTrg curOrientT;
        //OrientFlp curOrientF;
        //Point pointMouse;

        PlayZone playBoard;

        public FormEdit()
        {
            InitializeComponent();
            InitializeBoard();
        }

        protected void InitializeBoard()
        {
            playBoard = new PlayZone();
            corner_L_U = new Point(5, 5);
            corner_R_D = new Point(corner_L_U.X + LENGTH_BOARD - 1, corner_L_U.Y + LENGTH_BOARD - 1);
        }

        protected bool IsInBoard(Point p)
        //  Pre:    這個p是相對於plBoard來說的座標
        //  Post:   返回是否p在plBoard中的棋盤里
        {
         //   Rectangle r = new Rectangle(corner_L_U, new Size(LENGTH_BOARD-1,LENGTH_BOARD-1));
            if (p.X <= corner_R_D.X && p.X >= corner_L_U.X && p.Y >= corner_L_U.Y && p.Y <= corner_R_D.Y)
                return true;
            return false;
        }
        
        protected void PaintUndecided(Position p, ref Graphics g)
        //  Post:   在棋盤內部表示的p位置給映射到棋盤上,畫沒有選定好的狀態的gizmo
        {         
            if (isDrawing)
            {
                Image drawingImg = btnBall.Image;

                // 先把之前的畫過的都釋放掉
                DeleteUndecided(ref g);

                switch (tempGizmo.GetType())
                {
                    case TypeGizmo.BUMPER:
                        Bumper b = (Bumper)tempGizmo;
                        switch (b.GetTypeBumper())
                        {
                            case TypeBumper.SQUARE:
                                drawingImg = btnBpSqr.Image;
                                break;
                            case TypeBumper.TRIANGLE:
                                BumperTrg t = (BumperTrg)b;
                                switch (t.GetOrientation())
                                {
                                    case OrientTrg.L_U:
                                        drawingImg = btnBpTrgL_U.Image;
                                        break;
                                    case OrientTrg.L_D:
                                        drawingImg = btnBpTrgL_D.Image;
                                        break;
                                    case OrientTrg.R_U:
                                        drawingImg = btnBpTrgR_U.Image;
                                        break;
                                    case OrientTrg.R_D:
                                        drawingImg = btnBpTrgR_D.Image;
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case TypeBumper.CIRCLE:
                                drawingImg = btnBpCir.Image;
                                break;
                            default:
                                break;
                        }
                        break;
                    case TypeGizmo.FLIPPER:
                        Flipper f = (Flipper)tempGizmo;
                        switch (f.GetOrientation())
                        {
                            case OrientFlp.LEFT:
                                drawingImg = btnFlpL.Image;
                                break;
                            case OrientFlp.RIGHT:
                                drawingImg = btnFlpR.Image;
                                break;
                            default:
                                break;
                        }
                        break;
                    case TypeGizmo.ABSORBER:
                        drawingImg = btnAsb.Image;
                        break;
                    case TypeGizmo.BALL:
                        drawingImg = btnBall.Image;
                        break;
                    default:
                        break;
                }

                // 畫gizmo
                g.DrawImage(drawingImg, corner_L_U.X + p.GetX() * LENGTH_UNIT, corner_L_U.Y + p.GetY() * LENGTH_UNIT);
            }
        }

        protected void DeleteUndecided(ref Graphics g)
        //  Post:   將整個棋盤內的undecided位置給釋放掉。
        {
            g.Clear(Color.Empty);
        }

        private void plBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            //  畫邊框
            Pen pen = new Pen(Color.Brown, WIDTH_BOARD);
            g.DrawRectangle(pen, corner_L_U.X, corner_L_U.Y, LENGTH_BOARD, LENGTH_BOARD);

            //  畫小格子
            pen.Width = WIDTH_BOX;
            for (int i = 0; i < PlayZone.LENGTH_BOARD; i++)
            {
                //  劃橫線
                g.DrawLine(pen, corner_L_U.X + i * LENGTH_UNIT, corner_L_U.Y, corner_L_U.X + i * LENGTH_UNIT, corner_L_U.Y + LENGTH_BOARD);
 
                //  劃豎線
                g.DrawLine(pen, corner_L_U.X, corner_L_U.Y + i * LENGTH_UNIT, corner_L_U.X + LENGTH_BOARD, corner_L_U.Y + i * LENGTH_UNIT);
            }
        }

        private void btnBpSqr_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isDrawing = true;
                tempGizmo = new BumperSqr();
                //curTypeG = TypeGizmo.BUMPER;
                //curTypeB = TypeBumper.SQUARE; 
                //drawingImg = btnBpSqr.Image;
                //btnBpSqr.DoDragDrop(btnBpSqr.Image, DragDropEffects.Copy);
            }
            else if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                isDrawing = false;
            }
        }

        //private void FormEdit_Paint(object sender, PaintEventArgs e)
        //{
        //    //  如果點擊了按鈕並要拖動，就要在滑鼠處繪製圖案
        //    if (isDrawing)
        //    {
        //        Image drawingImg = btnBall.Image;
        //        switch (curTypeG)
        //        {
        //            case TypeGizmo.BUMPER:
        //                switch (curTypeB)
        //                {
        //                    case TypeBumper.SQUARE:
        //                        drawingImg = btnBpSqr.Image;
        //                        break;
        //                    case TypeBumper.TRIANGLE:
        //                        switch (curOrientT)
        //                        {
        //                            case OrientTrg.L_U:
        //                                drawingImg = btnBpTrgL_U.Image;
        //                                break;
        //                            case OrientTrg.L_D:
        //                                drawingImg = btnBpTrgL_D.Image;
        //                                break;
        //                            case OrientTrg.R_U:
        //                                drawingImg = btnBpTrgR_U.Image;
        //                                break;
        //                            case OrientTrg.R_D:
        //                                drawingImg = btnBpTrgR_D.Image;
        //                                break;
        //                            default:
        //                                break;
        //                        }
        //                        break;
        //                    case TypeBumper.CIRCLE:
        //                        drawingImg = btnBpCir.Image;
        //                        break;
        //                    default:
        //                        break;
        //                }
        //                break;
        //            case TypeGizmo.FLIPPER:
        //                switch (curOrientF)
        //                {
        //                    case OrientFlp.LEFT:
        //                        drawingImg = btnFlpL.Image;
        //                        break;
        //                    case OrientFlp.RIGHT:
        //                        drawingImg = btnFlpR.Image;
        //                        break;
        //                    default:
        //                        break;
        //                }
        //                break;
        //            case TypeGizmo.ABSORBER:
        //                drawingImg = btnAsb.Image;
        //                break;
        //            case TypeGizmo.BALL:
        //                drawingImg = btnBall.Image;
        //                break;
        //            default:
        //                break;
        //        }
        //        e.Graphics.DrawImage(drawingImg, PointToClient(Control.MousePosition));
        //    }
        //}

        //private void plBoard_DragEnter(object sender, DragEventArgs e)
        //{
        //    //Point curPosMouse = PointToClient(Control.MousePosition);
        //    //if (IsInBoard(curPosMouse))
        //    //{
        //    //    isDrawing = false;
        //    //    Position pos = new Position((curPosMouse.X-corner_L_U.X)/LENGTH_UNIT, (curPosMouse.Y - corner_R_D.Y));

        //    //    // 超出邊界的異常處理以防萬一
        //    //    pos.DragIntoBoard();
        //    //}

        //    if ((e.Data.GetDataPresent(typeof(Image))))
        //    {
        //        e.Effect = DragDropEffects.Copy;
        //    }
        //}

        private void plBoard_MouseMove(object sender, MouseEventArgs e)
        {
            Point curPosMouse = PointToClient(Control.MousePosition);
            if (isDrawing && IsInBoard(curPosMouse))
            {
                // 記錄內部棋盤座標並進行超出邊界的異常處理以防萬一
                posPre = posCur;
                posCur.SetCoordinate((curPosMouse.X - corner_L_U.X) / LENGTH_UNIT, (curPosMouse.Y - corner_R_D.Y));                               
                posCur.DragIntoBoard();

                // 根據滑鼠的內部棋盤座標來顯示出來
                if(posPre.GetX() != posCur.GetX() || posPre.GetY() != posCur.GetY())
                {
                    PaintUndecided(posCur, ref drawer);
                }

            }
            
        }

        private void plBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                isDrawing = false;
            }
        }               
    }
}
