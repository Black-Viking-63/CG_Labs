using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsPolygonModified
    {
        // массив трехкоординатных точек
        public cls3D_pointModified[] points = new cls3D_pointModified[3];
        // конструктор
        public clsPolygonModified()
        {

        }
        // конструктор
        internal clsPolygonModified(cls3D_pointModified p1, cls3D_pointModified p2, cls3D_pointModified p3)
        {
            this.points[0] = p1;
            this.points[1] = p2;
            this.points[2] = p3;
        }

        // методы доступа
        public cls3D_pointModified this[int index]
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
