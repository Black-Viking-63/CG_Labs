using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class cls3D_Point
    {
        // координаты
        int x;
        int y;
        int z;
        int k;
        int b;

        double x0;
        double y0;
        double z0;

        // методы доступа
        public int X
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
        public int Y
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
        public int Z
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

        public double X0
        {
            get
            {
                return x0;
            }
            set
            {
                x0 = value;
            }
        }
        public double Y0
        {
            get
            {
                return y0;
            }
            set
            {
                y0 = value;
            }
        }
        public double Z0
        {
            get
            {
                return z0;
            }
            set
            {
                z0 = value;
            }
        }

        // метод преобразования коорданит в экранные координаты 
        private int objectConvertToPoint(double n)
        {
            return Convert.ToInt32(Math.Round(k * n + b));
        }

        // конструктор 
        public cls3D_Point(double x, double y, double z, int k, int b)
        {
            this.k = k;
            this.b = b;
            this.x = objectConvertToPoint(x);
            this.y = objectConvertToPoint(-y);
            this.z = objectConvertToPoint(z);
        }

        // конструктор
        public cls3D_Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public cls3D_Point(double x, double y, double z)
        {
            this.x0 = x;
            this.y0 = y;
            this.z0 = z;
        }

        public static double[,] multyMatrix(double[,] matrixA, double[,] matrixB)
        {
            double[,] matrixC = new double[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }
            return matrixC;
        }

        public static double[] multyVectorsMatrix(double[,] matrixA, double[] vectorB)
        {
            double[] vectorResult = new double[3] { 0, 0, 0 };
            vectorResult[0] = matrixA[0, 0] * vectorB[0] + matrixA[0, 1] * vectorB[1] + matrixA[0, 2] * vectorB[2];
            vectorResult[1] = matrixA[1, 0] * vectorB[0] + matrixA[1, 1] * vectorB[1] + matrixA[1, 2] * vectorB[2];
            vectorResult[2] = matrixA[2, 0] * vectorB[0] + matrixA[2, 1] * vectorB[1] + matrixA[2, 2] * vectorB[2];
            return vectorResult;
        }

        public static double[] summVectors(double[] vectorA, double[] vectorB)
        {
            double[] vectorC = new double[3];
            vectorC[0] = vectorA[0] + vectorB[0];
            vectorC[1] = vectorA[1] + vectorB[1];
            vectorC[2] = vectorA[2] + vectorB[2];
            return vectorC;
        }

        static double alpha = Math.PI;
        static double beta = -Math.PI/3;
        static double gamma = 0;

        static double[,] matrixR_1 = new double[3, 3] { { 1, 0, 0 }, { 0, Math.Cos(alpha), Math.Sin(alpha) }, { 0, -Math.Sin(alpha), Math.Cos(alpha) } };
        static double[,] matrixR_2 = new double[3, 3] { { Math.Cos(beta), 0, Math.Sin(beta) }, { 0, 1, 0 }, { -Math.Sin(beta), 0, Math.Cos(beta) } };
        static double[,] matrixR_3 = new double[3, 3] { { Math.Cos(gamma), Math.Sin(gamma), 0 }, { -Math.Sin(gamma), Math.Cos(gamma), 0 }, { 0, 0, 1 } };
        static double[,] currentMatrixR = new double[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        static double[,] resultMatrixR = new double[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        static double[] initVectorTurnCoordinates = new double[3] { 0, 0, 0 };
        static double[] vectorTurnCoordinates = new double[3] { 0, 0, 0 };

        static double[] vectorT = new double[3] { 0.005, -0.045, 1.5 };

        static double[] initVectorMoveCoordinates = new double[3] { 0, 0, 0 };
        static double[] vectorMoveCoordinates = new double[3] { 0, 0, 0 };

        static double[] initVectorProjCoordinates = new double[3] { 0, 0, 0 };
        static double[] vectorProjCoordinates = new double[3] { 0, 0, 0 };

        static double aX = 20000;
        static double aY = 20000;
        static double u0 = 2500;
        static double v0 = 2500;
        static double[,] matrixK = new double[3, 3] { { aX, 0, u0 }, { 0, aY, v0 }, { 0, 0, 1 } };

        public static double[] initTurnCoordinates(double x, double y, double z)
        {
            initVectorTurnCoordinates[0] = x;
            initVectorTurnCoordinates[1] = y;
            initVectorTurnCoordinates[2] = z;
            return initVectorTurnCoordinates;
        }

        public static double[] calculateTurnCoordinates(double x, double y, double z)
        {
            initVectorTurnCoordinates = initTurnCoordinates(x, y, z);
            currentMatrixR = multyMatrix(matrixR_1, matrixR_2);
            resultMatrixR = multyMatrix(currentMatrixR, matrixR_3);
            vectorTurnCoordinates = multyVectorsMatrix(resultMatrixR, initVectorTurnCoordinates);
            return vectorTurnCoordinates;
        }
        public static double[] initMoveCoordinates(double x, double y, double z)
        {
            vectorTurnCoordinates = calculateTurnCoordinates(x, y, z);
            initVectorMoveCoordinates[0] = vectorTurnCoordinates[0];
            initVectorMoveCoordinates[1] = vectorTurnCoordinates[1];
            initVectorMoveCoordinates[2] = vectorTurnCoordinates[2];
            return initVectorMoveCoordinates;
        }
        public static double[] initProjCoordinates(double x, double y, double z)
        {
            initVectorMoveCoordinates = calculateMoveCoordinates(x, y, z);
            initVectorProjCoordinates[0] = initVectorMoveCoordinates[0];
            initVectorProjCoordinates[1] = initVectorMoveCoordinates[1];
            initVectorProjCoordinates[2] = initVectorMoveCoordinates[2];
            return initVectorProjCoordinates;
        }

        public static double[] calculateMoveCoordinates(double x, double y, double z)
        {
            initVectorMoveCoordinates = initMoveCoordinates(x, y, z);
            vectorMoveCoordinates = summVectors(initVectorMoveCoordinates, vectorT);
            return vectorMoveCoordinates;
        }

        public static double[] calculateProjCoordinates(double x, double y, double z)
        {
            initVectorProjCoordinates = initProjCoordinates(x, y, z);
            vectorProjCoordinates = multyVectorsMatrix(matrixK, initVectorProjCoordinates);
            vectorProjCoordinates[0] = vectorProjCoordinates[0] / vectorProjCoordinates[2];
            vectorProjCoordinates[1] = vectorProjCoordinates[1] / vectorProjCoordinates[2];
            vectorProjCoordinates[2] = 1.0;
            return vectorProjCoordinates;
        }
    
    }
}
