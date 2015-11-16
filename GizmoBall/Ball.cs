using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GizmoBall
{
    public class Ball : Gizmo
    {
        public Ball()
        {
            SetType(TypeGizmo.BALL);
        }

        public Ball(Position p)
        {
            SetType(TypeGizmo.BALL);
            SetPos(p);
        }

        public Ball(int cX, int cY)
        {
            SetType(TypeGizmo.BALL);
            SetPos(cX, cY);
        }
    }
}
