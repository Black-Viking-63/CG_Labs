using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsZbuffer                                                 // класс описывающий z буфер
    {

        public int height;
        public int width;
        public List<double> zBuffer = new List<double>();

        // конструктор
        public clsZbuffer(int width, int height)
        {
            this.width = width;
            this.height = height;
            for (int i = 0; i < width * height; i++)
            {
                zBuffer.Add(Double.PositiveInfinity);
            }
        }

        // методы доступа
        public void setZBuffer(int x, int y, double z)
        {
            zBuffer[x + width * y] = (int)z;
        }
        public double getZBuffer(int x, int y)
        {
            return zBuffer[x + width * y];
        }
    }
}
