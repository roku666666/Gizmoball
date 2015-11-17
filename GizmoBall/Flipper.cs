using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GizmoBall
{
    public enum OrientFlp { LEFT, RIGHT };

    public class Flipper : Gizmo
    //  在flipper中，一個flipper佔有LENGTH_FLP個格子，它的pos指代的是它自己的pivot
    //  flipper目前是初始狀態垂下，激活狀態為水平，有左右之分
    {
        protected OrientFlp orientation;
        protected const int LENGTH = 3;
        //protected Position relatedPosIni;   // 記錄初始狀態時要佔用的格子（通常是pivot下面的一個）
        //protected Position relatedPosAft;   // 記錄彈起狀態後要佔用的格子（根據flipper的左右朝向而定）

        public Flipper()
        {
            SetType(TypeGizmo.FLIPPER);
            SetOrientation(OrientFlp.LEFT);
        }

        public Flipper(Position p, OrientFlp o)
        {
            SetType(TypeGizmo.FLIPPER);
            SetOrientation(o);
            SetPos(p);
        }

        public Flipper(int cX, int cY, OrientFlp o)
        {
            SetType(TypeGizmo.FLIPPER);
            SetOrientation(o);
            SetPos(cX, cY);
        }

        public void SetOrientation(OrientFlp o)
        {
            orientation = o;
        }

        public OrientFlp GetOrientation()
        {
            return orientation;
        }

        public int GetLength()
        {
            return LENGTH;
        }
    }
}
