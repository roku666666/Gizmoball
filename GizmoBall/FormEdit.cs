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
        Point CORNER_L_U = new Point(5, 5);                 // 格子左上角的像素坐標(plBoard中的坐標)
        //Point CORNER_R_D = new Point(LENGTH_BOARD-1, LENGTH_BOARD-1);

        PlayZone playBoard;

        public FormEdit()
        {
            InitializeComponent();
            InitializeBoard();
        }

        protected void InitializeBoard()
        {
            playBoard = new PlayZone();
        }

        private void plBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            //  畫邊框
            Pen pen = new Pen(Color.Brown, WIDTH_BOARD);
            g.DrawRectangle(pen, CORNER_L_U.X, CORNER_L_U.Y, LENGTH_BOARD, LENGTH_BOARD);

            //  畫小格子
            pen.Width = WIDTH_BOX;
            for (int i = 0; i < PlayZone.LENGTH_BOARD; i++)
            {
                //  劃橫線
                g.DrawLine(pen, CORNER_L_U.X + i * LENGTH_UNIT, CORNER_L_U.Y, CORNER_L_U.X + i * LENGTH_UNIT, CORNER_L_U.Y + LENGTH_BOARD);
 
                //  劃豎線
                g.DrawLine(pen, CORNER_L_U.X, CORNER_L_U.Y + i * LENGTH_UNIT, CORNER_L_U.X + LENGTH_BOARD, CORNER_L_U.Y + i * LENGTH_UNIT);
            }
        }

        private void btnBpSqr_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop()
        }
    }
}
