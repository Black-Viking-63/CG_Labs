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
            lambda0 = ((x1 - x2) * (y - y2) - (y1 - y2) * (x - x2)) /
                      ((x1 - x2) * (y0 - y2) - (y1 - y2) * (x0 - x2));
            lambda1 = ((x2 - x0) * (y - y0) - (y2 - y0) * (x - x0)) /
                      ((x2 - x0) * (y1 - y0) - (y2 - y0) * (x1 - x0));
            lambda2 = ((x0 - x1) * (y - y1) - (y0 - y1) * (x - x1)) /
                      ((x0 - x1) * (y2 - y1) - (y0 - y1) * (x2 - x1));
        }
        
        public void Calculating_lambda_coefficientsForTurn(cls3D_Point screenPoint, clsPolygon polygonForDraw)
        {
            double x0 = polygonForDraw[0].X0;
            double x1 = polygonForDraw[1].X0;
            double x2 = polygonForDraw[2].X0;
            double y0 = polygonForDraw[0].Y0;
            double y1 = polygonForDraw[1].Y0;
            double y2 = polygonForDraw[2].Y0;
            double y = screenPoint.Y;
            double x = screenPoint.X;
            lambda0 = ((x1 - x2) * (y - y2) - (y1 - y2) * (x - x2)) / ((x1 - x2) * (y0 - y2) - (y1 - y2) * (x0 - x2));
            lambda1 = ((x2 - x0) * (y - y0) - (y2 - y0) * (x - x0)) / ((x2 - x0) * (y1 - y0) - (y2 - y0) * (x1 - x0));
            lambda2 = ((x0 - x1) * (y - y1) - (y0 - y1) * (x - x1)) / ((x0 - x1) * (y2 - y1) - (y0 - y1) * (x2 - x1));
        }

    }
}
