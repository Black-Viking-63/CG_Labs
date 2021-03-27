using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsLW1Task7
    {
        public static cls2D_Picture drawPolygonsFromObjectFile(List<clsPolygon> polygons)
        {
            cls2D_Picture polygonsImage = new cls2D_Picture(1800, 1500);            // фон
            for (int i = 0; i < polygons.Count - 1; i++)                            // рисуем полигон по алгоритму Брезенхема
            {
                clsPolygon poligonchik = polygons[i];
                clsAlgorithmDrawLine.line4(poligonchik[0].X, poligonchik[0].Y, poligonchik[1].X, poligonchik[1].Y, polygonsImage, new clsRGB(0, 0, 255));
                clsAlgorithmDrawLine.line4(poligonchik[0].X, poligonchik[0].Y, poligonchik[2].X, poligonchik[2].Y, polygonsImage, new clsRGB(0, 0, 255));
                clsAlgorithmDrawLine.line4(poligonchik[1].X, poligonchik[1].Y, poligonchik[2].X, poligonchik[2].Y, polygonsImage, new clsRGB(0, 0, 255));
            }
            return polygonsImage;
        }

    }
}
