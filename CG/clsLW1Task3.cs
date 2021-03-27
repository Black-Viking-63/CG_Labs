using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsLW1Task3
    {
        public static cls2D_Picture drawLine(int j)                 // отрисовка линий
        {
            cls2D_Picture imageLines = new cls2D_Picture(200, 200);
            switch (j)                                      // выбор алгоритма
            {
                case 1:
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            double alpha = 2 * i * Math.PI / 13;
                            clsAlgorithmDrawLine.line1(100, 100, Convert.ToInt32(100 + 95 * Math.Cos(alpha)), Convert.ToInt32(100 + 95 * Math.Sin(alpha)),
                                imageLines, new clsRGB(255, 0, 0));
                        }
                    };
                    break;
                case 2:
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            double alpha = 2 * i * Math.PI / 13;
                            clsAlgorithmDrawLine.line2(100, 100, Convert.ToInt32(100 + 95 * Math.Cos(alpha)), Convert.ToInt32(100 + 95 * Math.Sin(alpha)),
                                imageLines, new clsRGB(255, 0, 0));
                        }
                    };
                    break;
                case 3:
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            double alpha = 2 * i * Math.PI / 13;
                            clsAlgorithmDrawLine.line3(100, 100, Convert.ToInt32(100 + 95 * Math.Cos(alpha)), Convert.ToInt32(100 + 95 * Math.Sin(alpha)),
                                imageLines, new clsRGB(255, 0, 0));
                        }
                    };
                    break;
                case 4:
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            double alpha = 2 * i * Math.PI / 13;
                            clsAlgorithmDrawLine.line4(100, 100, Convert.ToInt32(100 + 95 * Math.Cos(alpha)), Convert.ToInt32(100 + 95 * Math.Sin(alpha)),
                                imageLines, new clsRGB(255, 0, 0));
                        }
                    };
                    break;

            }
            return imageLines;                                              // возврат изображения
        }

    }
}
