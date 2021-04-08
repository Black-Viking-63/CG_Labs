using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsBarycentricCoordinates
    {
        public static clsPolygon polygon;
        public static double lambda0;
        public static double lambda1;
        public static double lambda2;

        public static double Lambda0
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
        public static double Lambda1
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
        public static double Lambda2
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
        public static void Calculating_lambda_coefficients(cls3D_Point screenPoint)
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
    
    }
}
