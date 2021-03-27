using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsLW1Task5
    {
        public static cls2D_Picture drawTopsFromObjectFile(List<cls3D_Point> points)
        {
            cls2D_Picture pointsImage = new cls2D_Picture(1800, 1500);                  // создаем фон изображения
            for (int i = 0; i < points.Count - 1; i++)
            {
                cls3D_Point temp = points[i];
                pointsImage.setPixel(temp.X, temp.Y, new clsRGB(255, 0, 0));     // рисуем ранее записанные точки
            }
            return pointsImage;
        }
    }
}
