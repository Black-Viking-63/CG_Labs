using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsVector                                  // класс описывающий вектор
    {
        // координаты вектора
        public double x;
        public double y;
        public double z;

        // конструктор
        public clsVector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // методы доступа
        public double X
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
        public double Y
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
        public double Z
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
    
    }
}
