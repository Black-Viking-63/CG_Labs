using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsPolygon
    {
        // массив трехкоординатных точек
        public cls3D_Point[] points = new cls3D_Point[3];
        // конструктор
        public clsPolygon()
        {

        }
        // конструктор
        internal clsPolygon(cls3D_Point p1, cls3D_Point p2, cls3D_Point p3)
        {
            this.points[0] = p1;
            this.points[1] = p2;
            this.points[2] = p3;
        }

        // методы доступа
        public cls3D_Point this[int index]
        {
            get
            {
                return points[index];
            }
            set
            {
                points[index] = value;
            }
        }
    }
}
