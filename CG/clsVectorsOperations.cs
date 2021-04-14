using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsVectorsOperations                                       // класс описывающий векторные и скалярные операции
    {
        public static clsVector vectorLight = new clsVector(0, 0, 1);
        
        // вычисление нормали
        public static clsVector getVectorNormal(clsPolygon polygon)
        {
            double x0 = polygon[0].X;
            double y0 = polygon[0].Y;
            double z0 = polygon[0].Z;
            double x1 = polygon[1].X;
            double y1 = polygon[1].Y;
            double z1 = polygon[1].Z;
            double x2 = polygon[2].X;
            double y2 = polygon[2].Y;
            double z2 = polygon[2].Z;
            // нахождение координат нормали через определитель
            double x = (y1 - y0) * (z1 - z2) - (z1 - z0) * (y1 - y2);
            double y = (x1 - x0) * (z1 - z2) - (z1 - z0) * (x1 - x2);
            double z = (x1 - x0) * (y1 - y2) - (y1 - y0) * (x1 - x2);
            return new clsVector(x, y, z);
        }


        // подсчет косинуса угла между нормалью и скалярным произведением
        public static double cosDirectionEarthNormal(clsPolygon polygon)
        {
            clsVector normaliseVector = getVectorNormal(polygon);
            // скалярное произведение
            double scalarMulty = normaliseVector.X * vectorLight.X + normaliseVector.Y * vectorLight.Y + normaliseVector.Z * vectorLight.Z;
            // норма вектора
            double normalVectorLength = Math.Sqrt(normaliseVector.X * normaliseVector.X + normaliseVector.Y * normaliseVector.Y + normaliseVector.Z * normaliseVector.Z);
            return scalarMulty / normalVectorLength;
        }

        public static clsVector getVectorNormal2(clsPolygon polygon)
        {
            double x0 = polygon[0].X0;
            double y0 = polygon[0].Y0;
            double z0 = polygon[0].Z0;
            double x1 = polygon[1].X0;
            double y1 = polygon[1].Y0;
            double z1 = polygon[1].Z0;
            double x2 = polygon[2].X0;
            double y2 = polygon[2].Y0;
            double z2 = polygon[2].Z0;
            // нахождение координат нормали через определитель
            double x = (y1 - y0) * (z1 - z2) - (z1 - z0) * (y1 - y2);
            double y = (x1 - x0) * (z1 - z2) - (z1 - z0) * (x1 - x2);
            double z = (x1 - x0) * (y1 - y2) - (y1 - y0) * (x1 - x2);
            return new clsVector(x, y, z);
        }


        // подсчет косинуса угла между нормалью и скалярным произведением
        public static double cosDirectionEarthNormal2(clsPolygon polygon)
        {
            clsVector normaliseVector = getVectorNormal2(polygon);
            // скалярное произведение
            double scalarMulty = normaliseVector.X * vectorLight.X + normaliseVector.Y * vectorLight.Y + normaliseVector.Z * vectorLight.Z;
            // норма вектора
            double normalVectorLength = Math.Sqrt(normaliseVector.X * normaliseVector.X + normaliseVector.Y * normaliseVector.Y + normaliseVector.Z * normaliseVector.Z);
            return scalarMulty / normalVectorLength;
        }
    }
}
