using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsTriangle
    {

        // размеры изображения
        public static int minimalX;
        public static int maximalX;
        public static int minimalY;
        public static int maximalY;

        // определение размеров
        public static int functionMinimumX(clsPolygon poligon)
        {
            minimalX = Math.Min(Math.Min(poligon[0].X, poligon[1].X), poligon[2].X);
            if (minimalX < 0)
            {
                minimalX = 0;
            }
            return minimalX;
        }
        public static int functionMinimumY(clsPolygon poligon)
        {
            minimalY = Math.Min(Math.Min(poligon[0].Y, poligon[1].Y), poligon[2].Y);
            if (minimalY < 0)
            {
                minimalY = 0;
            }
            return minimalY;
        }
        public static int functionMaximumX(clsPolygon poligon, cls2D_Picture Picture)
        {
            maximalX = Math.Max(Math.Max(poligon[0].X, poligon[1].X), poligon[2].X);
            if (maximalX > Picture.width)
            {
                maximalX = Picture.width;
            }
            return maximalX;
        }
        public static int functionMaximumY(clsPolygon poligon, cls2D_Picture Picture)
        {
            maximalY = Math.Max(Math.Max(poligon[0].Y, poligon[1].Y), poligon[2].Y);
            if (maximalY > Picture.height)
            {
                maximalY = Picture.height;
            }
            return maximalY;
        }

        // создание треугольников
        public static void createTriangle(clsPolygon polygon, cls2D_Picture image, clsRGB colour)
        {
            minimalX = functionMinimumX(polygon);
            maximalX = functionMaximumX(polygon, image);
            minimalY = functionMinimumY(polygon);
            maximalY = functionMaximumY(polygon, image);
            clsBarycentricCoordinates barycentricPoint = new clsBarycentricCoordinates(polygon);
            for (int x = minimalX; x < maximalX; x++)
            {
                for (int y = minimalY; y < maximalY; y++)
                {
                    clsBarycentricCoordinates.Calculating_lambda_coefficients(new cls3D_Point(x, y));
                    if (clsBarycentricCoordinates.Lambda0 >= 0 && clsBarycentricCoordinates.Lambda1 >= 0 && clsBarycentricCoordinates.Lambda2 >= 0)
                    {
                        image.setPixel(x, y, colour);
                    }
                }
            }
        }

        // создание треугольниов с помощью z буфера
        public static void createTriangleWithZBuffer(clsPolygon polygon, cls2D_Picture image, clsRGB colour, clsZbuffer zBuffer)
        {
            minimalX = functionMinimumX(polygon);
            maximalX = functionMaximumX(polygon, image);
            minimalY = functionMinimumY(polygon);
            maximalY = functionMaximumY(polygon, image);
            clsBarycentricCoordinates barycentricPoint = new clsBarycentricCoordinates(polygon);
            for (int x = minimalX; x < maximalX; x++)
            {
                for (int y = minimalY; y < maximalY; y++)
                {
                    clsBarycentricCoordinates.Calculating_lambda_coefficients(new cls3D_Point(x, y));
                    if (clsBarycentricCoordinates.Lambda0 >= 0 && clsBarycentricCoordinates.Lambda1 >= 0 && clsBarycentricCoordinates.Lambda2 >= 0)
                    {
                        double z = clsBarycentricCoordinates.Lambda0 * polygon[0].Z + clsBarycentricCoordinates.Lambda1 * polygon[1].Z + clsBarycentricCoordinates.Lambda2 * polygon[2].Z;
                        if (z < zBuffer.getZBuffer(x, y))
                        {
                            zBuffer.setZBuffer(x, y, z);
                            image.setPixel(x, y, colour);
                        }
                    }
                }
            }
        }

        // отрисовка треугольниками
        public static cls2D_Picture drawTriangle()
        {
            cls2D_Picture polygonsImage = new cls2D_Picture(1700, 1500);
            Random random = new Random();
            for (int i = 0; i < clsLoadData.polygons.Count - 1; i++)
            {
                createTriangle(clsLoadData.polygons[i], polygonsImage, new clsRGB(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
            }
            return polygonsImage;
        }

        // отрисовка треугольниками объемного изображения 
        public static cls2D_Picture drawVolTriangle()
        {
            cls2D_Picture polygonsImage = new cls2D_Picture(1700, 1500);
            Random random = new Random();
            for (int i = 0; i < clsLoadData.polygons.Count - 1; i++)
            {
                if (clsVectorsOperations.cosDirectionEarthNormal(clsLoadData.polygons[i]) < 0)
                    createTriangle(clsLoadData.polygons[i], polygonsImage, 
                        new clsRGB((int)Math.Abs(clsVectorsOperations.cosDirectionEarthNormal(clsLoadData.polygons[i]) * 255), 0,0));
                else continue;
            }
            return polygonsImage;
        }

        // отрисовка треуголниками с помощью z буфера объемного изображения
        public static cls2D_Picture drawTriangleWithZBuffer()
        {
            cls2D_Picture polygonsImage = new cls2D_Picture(1700, 1500);
            clsZbuffer zBuffer = new clsZbuffer(1700, 1500);
            Random random = new Random();
            for (int i = 0; i < clsLoadData.polygons.Count - 1; i++)
            {
                createTriangleWithZBuffer(clsLoadData.polygons[i], polygonsImage, new clsRGB((int)Math.Abs(clsVectorsOperations.cosDirectionEarthNormal(clsLoadData.polygons[i]) * 255), 0, 0), zBuffer);
            }
            return polygonsImage;
        }
    }
}
