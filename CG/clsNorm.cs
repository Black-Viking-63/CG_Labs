using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsNorm
    {
        public double x;
        public double y;
        public double z;

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }

        public double calculateAngle(int angle)
        {
            return angle * Math.PI / 180;
        }


        public double[,] calculateMatrixR(int rotX, int rotY, int rotZ)
        {
            double[,] matrixR1 =
            {
                {1, 0, 0},
                {0, Math.Cos(calculateAngle(rotX)), Math.Sin(calculateAngle(rotX))},
                {0, -Math.Sin(calculateAngle(rotX)), Math.Cos(calculateAngle(rotX))}
            };
            double[,] matrixR2 =
            {
                {Math.Cos(calculateAngle(rotY)), 0, Math.Sin(calculateAngle(rotY))},
                {0, 1, 0},
                {-Math.Sin(calculateAngle(rotY)), 0, Math.Cos(calculateAngle(rotY))}
            };
            double[,] matrixR3 =
            {
                {Math.Cos(calculateAngle(rotZ)), Math.Sin(calculateAngle(rotZ)), 0},
                {-Math.Sin(calculateAngle(rotZ)), Math.Cos(calculateAngle(rotZ)), 0},
                {0, 0, 1}
            };
            double[,] matrixR = clsVectorsOperations.multiplyMatrix(clsVectorsOperations.multiplyMatrix(matrixR1, matrixR2), matrixR3);
            return matrixR;
        }

        public double[,] calculateRotationCoordinatesNorm(double x, double y, double z)
        {
            double[,] originalCoordinates = { { x }, { y }, { z } };
            double[,] matrixR = calculateMatrixR(180, 140, 0);
            double[,] rotationCoordinates = clsVectorsOperations.multiplyMatrix(matrixR, originalCoordinates);
            return rotationCoordinates;
        }

        public clsNorm(double x, double y, double z)
        {
            double[,] rotationNorm = calculateRotationCoordinatesNorm(x, y, z);
            this.x = rotationNorm[0, 0];
            this.y = rotationNorm[1, 0];
            this.z = rotationNorm[2, 0];
        }
    }
}
