using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsRGB
    {
        // инициализируем цветовые поля
        int red;
        int green;
        int blue;

        // конструктор
        public clsRGB(int R, int G, int B)
        {
            Red = R;
            Green = G;
            Blue = B;
        }
        // методы доступа для каждого цвета
        public int Red
        {
            get
            {
                return red;
            }
            set
            {
                red = value;
            }
        }
        public int Green
        {
            get
            {
                return green;
            }
            set
            {
                green = value;
            }
        }
        public int Blue
        {
            get
            {
                return blue;
            }
            set
            {
                blue = value;
            }
        }
    }
}
