using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GizmoBall
{
    public enum TypeBumper { SQUARE, TRIANGLE, CIRCLE };
    public enum OrientTrg { L_U, L_D, R_U, R_D };    // 尖尖頭指向左上左下右上右下

    //*************************************************************************

    public abstract class Bumper : Gizmo
    {        
        protected TypeBumper typeBumper;

        public TypeBumper GetTypeBumper()
        {
            return typeBumper;
        }

        public void SetType(TypeBumper tB)
        {
            SetType(TypeGizmo.BUMPER);
            SetTypeBumper(tB);
        }

        protected void SetTypeBumper(TypeBumper tB)
        {
            typeBumper = tB;
        }
    }

    //*************************************************************************

    public class BumperSqr : Bumper
    {
        public BumperSqr()
        {
            SetType(TypeBumper.SQUARE);
        }

        public BumperSqr(Position p)
        {
            SetType(TypeBumper.SQUARE);
            SetPos(p);
        }

        public BumperSqr(int cX, int cY)
        {
            SetType(TypeBumper.SQUARE);
            SetPos(cX, cY);
        }
    }

    //*************************************************************************

    public class BumperTrg : Bumper
    {
        OrientTrg orientation;
        
        public BumperTrg()
        {
            SetType(TypeBumper.TRIANGLE);
            SetOrientation(OrientTrg.L_D);
        }

        public BumperTrg(Position p, OrientTrg o)
        {
            SetType(TypeBumper.TRIANGLE);
            SetOrientation(o); 
            SetPos(p);
        }

        public BumperTrg(int cX, int cY, OrientTrg o)
        {
            SetType(TypeBumper.TRIANGLE);
            SetOrientation(o);
            SetPos(cX, cY);            
        }

        public void SetOrientation(OrientTrg o)
        {
            orientation = o;
        }

        public OrientTrg GetOrientation()
        {
            return orientation;
        }
    }

    //*************************************************************************

    public class BumperCir : Bumper
    {
        public BumperCir()
        {
            SetType(TypeBumper.CIRCLE);
        }

        public BumperCir(Position p)
        {
            SetType(TypeBumper.CIRCLE);
            SetPos(p);
        }

        public BumperCir(int cX, int cY)
        {
            SetType(TypeBumper.CIRCLE);
            SetPos(cX, cY);
        }
    }
}
