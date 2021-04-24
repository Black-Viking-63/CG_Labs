using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class cls3D_pointModified
    {
        public double originalX;
        public double originalY;
        public double originalZ;

        public double rotationX;
        public double rotationY;
        public double rotationZ;

        public double movementX;
        public double movementY;
        public double movementZ;

        public double projectiveX;
        public double projectiveY;
        public double projectiveZ;

        public cls3D_pointModified(double originalX, double originalY, double originalZ)
        {
            this.originalX = originalX;
            this.originalY = originalY;
            this.originalZ = originalZ;
            double[,] rotationCoordinates = calculateRotationCoordinates(originalX, originalY, originalZ);
            rotationX = rotationCoordinates[0, 0];
            rotationY = rotationCoordinates[1, 0];
            rotationZ = rotationCoordinates[2, 0];
            double[,] movementCoordinates = calculateMovementCoordinates(rotationX, rotationY, rotationZ);
            movementX = movementCoordinates[0, 0];
            movementY = movementCoordinates[1, 0];
            movementZ = movementCoordinates[2, 0];
            double[,] projectiveCoordinates = calculateProjectiveCoordinates(movementX, movementY, movementZ);
            projectiveX = projectiveCoordinates[0, 0];
            projectiveY = projectiveCoordinates[1, 0];
            projectiveZ = projectiveCoordinates[2, 0];
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

        public double[,] calculateRotationCoordinates(double x, double y, double z)
        {
            double[,] originalCoordinates =  { { x }, { y }, { z } };
            double[,] matrixR = calculateMatrixR(180, -45, 0);
            double[,] rotationCoordinates = clsVectorsOperations.multiplyMatrix(matrixR, originalCoordinates);
            return rotationCoordinates;
        }
        
        public double[,] calculateMovementCoordinates(double x, double y, double z)
        {
            double[,] rotationCoordinates = { { x }, { y }, { z } };
            double[,] vectorT = { { 0.005 }, { -0.045 }, { 1.5 } };
            double[,] movementCoordinates =
                {
                { rotationCoordinates[0, 0] + 0 },
                { rotationCoordinates[1, 0] + 0 },
                { rotationCoordinates[2, 0] + vectorT[2, 0]} };
            return movementCoordinates;
        }

        public double[,] calculateProjectiveCoordinates(double x, double y, double z)
        {
            double[,] movementCoordinates = { { x }, { y }, { z } };
            double[,] matrixK = 
            {
                { 20000, 0, 2500 },
                { 0, 20000, 2500 },
                { 0, 0, 1 }
            };
            double[,] projectiveCoordinates = clsVectorsOperations.multiplyMatrix(matrixK, movementCoordinates);
            projectiveCoordinates[0, 0] = projectiveCoordinates[0, 0] / projectiveCoordinates[2, 0];
            projectiveCoordinates[1, 0] = projectiveCoordinates[1, 0] / projectiveCoordinates[2, 0];
            projectiveCoordinates[2, 0] = projectiveCoordinates[2, 0] / projectiveCoordinates[2, 0];
            return projectiveCoordinates;
        }
    }
}
