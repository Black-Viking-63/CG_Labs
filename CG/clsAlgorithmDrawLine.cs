using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsAlgorithmDrawLine
    {
        // простейший алгоритм отрисовки линии
        public static void line1(int x0, int y0, int x1, int y1, cls2D_Picture image, clsRGB color)
        {
            for (float t = 0.0F; t < 1.0F; t += 0.01F)
            {
                int x = Convert.ToInt32(x0 * (1 - t) + x1 * t);
                int y = Convert.ToInt32(y0 * (1 - t) + y1 * t);
                image.setPixel(x, y, color);
            }
        }

        // модифицированный вариант
        public static void line2(int x0, int y0, int x1, int y1, cls2D_Picture image, clsRGB color)
        {
            for (int x = x0; x <= x1; x++)
            {
                float t = (x - x0) / (float)(x1 - x0);
                int y = Convert.ToInt32(y0 * (1 - t) + y1 * t);
                image.setPixel(x, y, color);
            }
        }

        public static void swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        
        // улучшенный первый алгоритм
        public static void line3(int x0, int y0, int x1, int y1, cls2D_Picture image, clsRGB color)
        {
            bool steep = false;
            if (Math.Abs(x0 - x1) < Math.Abs(y0 - y1))
            {
                swap(ref x0, ref y0);
                swap(ref x1, ref y1);
                steep = true;
            }
            if (x0 > x1)
            {
                swap(ref x0, ref x1);
                swap(ref y0, ref y1);
            }
            for (int x = x0; x <= x1; x++)
            {
                float t = (x - x0) / (float)(x1 - x0);
                int y = Convert.ToInt32(y0 * (1 - t) + y1 * t);
                if (steep)
                {
                    image.setPixel(y, x, color);
                }
                else
                {
                    image.setPixel(x, y, color);
                }
            }
        }
        
        // алгоритм Брезенхема
        public static void line4(int x0, int y0, int x1, int y1, cls2D_Picture image, clsRGB color)
        {
            bool steep = false;
            if (Math.Abs(x0 - x1) < Math.Abs(y0 - y1))
            {
                swap(ref x0, ref y0);
                swap(ref x1, ref y1);
                steep = true;
            }
            if (x0 > x1)
            {
                swap(ref x0, ref x1);
                swap(ref y0, ref y1);
            }
            int dx = x1 - x0;
            int dy = y1 - y0;
            float derror = Math.Abs(dy / (float)dx);
            float error = 0;
            int y = y0;

            for (int x = x0; x <= x1; x++)
            {
                if (steep)
                {
                    image.setPixel(y, x, color);
                }
                else
                {
                    image.setPixel(x, y, color);
                }
                error += derror;
                if (error > 0.5)
                {
                    y += (y1 > y0 ? 1 : -1);
                    error -= 1.0F;
                }
            }
        }
    }
}
