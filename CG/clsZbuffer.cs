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
        //public static List<double> zBuffer = new List<double>();
        public static double[,] zBuffer;

        // конструктор
        public clsZbuffer(int width, int height)
        {
            this.width = width;
            this.height = height;
            zBuffer = new double[width, height];
            for (int i = 0; i < width - 1; i++)
            {
                for (int j = 0; j < height - 1; j++)
                {
                    zBuffer[i, j] = 10000;
                }
            }
            
        }

        // методы доступа
        public void setZBuffer(int x, int y, double z)
        {
            zBuffer[x, y] = z;
        }
        public double getZBuffer(int x, int y)
        {
            return zBuffer[x, y];
        }
    }
}
