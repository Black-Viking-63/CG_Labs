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

        public static clsVector getNormal(clsPolygonModified polygon)
        {
            double x0 = polygon[0].movementX;
            double y0 = polygon[0].movementY;
            double z0 = polygon[0].originalZ;
            double x1 = polygon[1].movementX;
            double y1 = polygon[1].movementY;
            double z1 = polygon[1].originalZ;
            double x2 = polygon[2].movementX;
            double y2 = polygon[2].movementY;
            double z2 = polygon[2].originalZ;
            // нахождение координат нормали через определитель
            double x = (y1 - y0) * (z1 - z2) - (z1 - z0) * (y1 - y2);
            double y = (x1 - x2) * (z1 - z0) - (z1 - z2) * (x1 - x0);
            double z = (x1 - x0) * (y1 - y2) - (y1 - y0) * (x1 - x2);
            return new clsVector(x, y, z);
        }

        public static double getCosNormal(clsPolygonModified polygon)
        {
            clsVector normaliseVector = getNormal(polygon);
            // скалярное произведение
            double scalarMulty = normaliseVector.X * vectorLight.X + normaliseVector.Y * vectorLight.Y + normaliseVector.Z * vectorLight.Z;
            // норма вектора
            double normalVectorLength = Math.Sqrt(normaliseVector.X * normaliseVector.X + normaliseVector.Y * normaliseVector.Y + normaliseVector.Z * normaliseVector.Z);
            return scalarMulty / normalVectorLength;
        }


        public static double[,] multiplyMatrix(double[,] matrixA, double[,] matrixB)
        {
            double[,] matrixC = new double[matrixA.GetLength(0), matrixB.GetLength(1)];

            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    matrixC[i, j] = 0;

                    for (int k = 0; k < matrixA.GetLength(1); k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixC;
        }
        public static double[,] summaryMatrix(double[,] matrixA, double[,] matrixB)
        {
            double[,] matrixC = new double[matrixA.GetLength(0), matrixB.GetLength(1)];

            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }
            return matrixC;
        }
    }
}
