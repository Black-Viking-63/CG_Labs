using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsBarycentricCoordinates                                  // класс описывающий барицентрические координаты
    {
        // поля
        public static clsPolygon polygon;
        public static clsPolygonModified polygonModified;
        public double lambda0;
        public double lambda1;
        public double lambda2;

        // методы доступа
        public double Lambda0
        {
            get
            {
                return lambda0;
            }
            set
            {
                lambda0 = value;
            }
        }
        public double Lambda1
        {
            get
            {
                return lambda1;
            }
            set
            {
                lambda1 = value;
            }
        }
        public double Lambda2
        {
            get
            {
                return lambda2;
            }
            set
            {
                lambda2 = value;
            }
        }
        
        public clsBarycentricCoordinates(clsPolygon polyg)
        {
            polygon = polyg;
        }
        public clsBarycentricCoordinates(clsPolygonModified polyg)
        {
            polygonModified = polyg;
        }

        // подсчет барицентрических координат
        public void Calculating_lambda_coefficients(cls3D_Point screenPoint)
        {
            double x0 = polygon[0].X;
            double x1 = polygon[1].X;
            double x2 = polygon[2].X;
            double y0 = polygon[0].Y;
            double y1 = polygon[1].Y;
            double y2 = polygon[2].Y;
            double y = screenPoint.Y;
            double x = screenPoint.X;
            Lambda0 = ((x1 - x2) * (y - y2) - (y1 - y2) * (x - x2)) /
                      ((x1 - x2) * (y0 - y2) - (y1 - y2) * (x0 - x2));
            lambda1 = ((x2 - x0) * (y - y0) - (y2 - y0) * (x - x0)) /
                      ((x2 - x0) * (y1 - y0) - (y2 - y0) * (x1 - x0));
            lambda2 = ((x0 - x1) * (y - y1) - (y0 - y1) * (x - x1)) /
                      ((x0 - x1) * (y2 - y1) - (y0 - y1) * (x2 - x1));
        }

        public void calc_lambda_for_Original(cls3D_pointModified screenPoint)
        {
            double x0 = polygonModified[0].originalX;
            double x1 = polygonModified[1].originalX;
            double x2 = polygonModified[2].originalX;
            double y0 = polygonModified[0].originalY;
            double y1 = polygonModified[1].originalY;
            double y2 = polygonModified[2].originalY;
            double y = screenPoint.originalX;
            double x = screenPoint.originalY;
            lambda0 = ((x1 - x2) * (y - y2) - (y1 - y2) * (x - x2)) /
                      ((x1 - x2) * (y0 - y2) - (y1 - y2) * (x0 - x2));
            lambda1 = ((x2 - x0) * (y - y0) - (y2 - y0) * (x - x0)) /
                      ((x2 - x0) * (y1 - y0) - (y2 - y0) * (x1 - x0));
            lambda2 = ((x0 - x1) * (y - y1) - (y0 - y1) * (x - x1)) /
                      ((x0 - x1) * (y2 - y1) - (y0 - y1) * (x2 - x1));
        }

        public void calc_lambda_for_Transformation(int x, int y)
        {
            double x0 = polygonModified[0].projectiveX;
            double x1 = polygonModified[1].projectiveX;
            double x2 = polygonModified[2].projectiveX;
            double y0 = polygonModified[0].projectiveY;
            double y1 = polygonModified[1].projectiveY;
            double y2 = polygonModified[2].projectiveY;
            lambda0 = ((x1 - x2) * (y - y2) - (y1 - y2) * (x - x2)) /
                      ((x1 - x2) * (y0 - y2) - (y1 - y2) * (x0 - x2));
            lambda1 = ((x2 - x0) * (y - y0) - (y2 - y0) * (x - x0)) /
                      ((x2 - x0) * (y1 - y0) - (y2 - y0) * (x1 - x0));
            lambda2 = ((x0 - x1) * (y - y1) - (y0 - y1) * (x - x1)) /
                      ((x0 - x1) * (y2 - y1) - (y0 - y1) * (x2 - x1));
        }

    }
}
