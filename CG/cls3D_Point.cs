using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class cls3D_Point
    {
        // координаты
        int x;
        int y;
        int z;
        int k;
        int b;

        // методы доступа
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public int Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }

        // метод преобразования коорданит в экранные координаты 
        private int objectConvertToPoint(double n)
        {
            return Convert.ToInt32(Math.Round(k * n + b));
        }

        // конструктор 
        public cls3D_Point(double x, double y, double z, int k, int b)
        {
            this.k = k;
            this.b = b;
            this.x = objectConvertToPoint(x);
            this.y = objectConvertToPoint(-y);
            this.z = objectConvertToPoint(z);
        }

        // конструктор
        public cls3D_Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
