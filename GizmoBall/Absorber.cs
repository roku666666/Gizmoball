using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GizmoBall
{
    public class Absorber : Gizmo
    {
        protected const int LENGTH = PlayZone.LENGTH_BOARD;

        public Absorber()
        {
            SetType(TypeGizmo.ABSORBER);
        }

        public Absorber(Position p)
        {
            SetType(TypeGizmo.ABSORBER);
            SetPos(p.GetX(), 0);    // Absorber的pos是算在最左邊的
        }

        public Absorber(int row)
        {
            SetType(TypeGizmo.ABSORBER);
            SetPos(row, 0);         // 安排Absorber在第row行
        }

        public int GetLength()
        {
            return LENGTH;
        }

        public int GetRow()
        {
            return pos.GetX();
        }
    }
}
