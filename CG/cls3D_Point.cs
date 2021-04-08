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
        double x1;
        double y1;
        double z1;

        public static double ax = 10000, ay = 10000, u0 = 75, v0 = 175;

        double[,] matrixK = new double[3, 3] { { ax, 0, u0 }, { 0, ay, v0 }, { 0, 0, 1 } };
        double[,] vectorT = new double[3, 1] { { 0.005 }, { -0.045 }, { 15 } };
        double[,] vectorOriginal = new double[3, 1];
        double[,] vectorSumm = new double[3, 1];
        double[] vectorResult = new double[3];

        public static double alpha = 0, betta = 180, gamma = 0;


        double[,] matrixR1 = new double[3, 3] { { 1, 0, 0 }, { 0, Math.Cos(alpha), Math.Sin(alpha) }, { 0, -Math.Sin(alpha), Math.Cos(alpha) } };
        double[,] matrixR2 = new double[3, 3] { { Math.Cos(betta), 0, Math.Sin(betta) }, { 0, 1, 0 }, { -Math.Sin(betta), 0, Math.Cos(betta) } };
        double[,] matrixR3 = new double[3, 3] { { Math.Cos(gamma), Math.Sin(gamma), 0 }, { -Math.Sin(gamma), Math.Cos(gamma), 0 }, { 0, 0, 1 } };
        double[,] currentMatrixR = new double[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        double[,] matrixR = new double[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        double[,] multyMatrix(double[,] matrixA, double[,] matrixB, double[,] matrixC) {
            
            for (int i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    for (var k = 0; k < 3; k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }
            return matrixC;
        }

        double[,] calculateMatrixR()
        {
            currentMatrixR = multyMatrix(matrixR1, matrixR2, currentMatrixR);
            matrixR = multyMatrix(currentMatrixR, matrixR3, matrixR);
            return matrixR;
        }

        void initVectorForTurn(double x, double y, double z)
        {
            vectorOriginal[0, 0] = x;
            vectorOriginal[1, 0] = y;
            vectorOriginal[2, 0] = z;
        }

        void multiOfVectorsForTurn(double x, double y, double z)
        {
            initVectorForTurn(x, y, z);
            matrixR = calculateMatrixR();
            vectorResult[0] = matrixR[0, 0] * vectorOriginal[0, 0] + matrixR[0, 1] * vectorOriginal[1, 0] + matrixR[0, 2] * vectorOriginal[2, 0];
            vectorResult[1] = matrixR[1, 0] * vectorOriginal[0, 0] + matrixR[1, 1] * vectorOriginal[1, 0] + matrixR[1, 2] * vectorOriginal[2, 0];
            vectorResult[2] = matrixR[2, 0] * vectorOriginal[0, 0] + matrixR[2, 1] * vectorOriginal[1, 0] + matrixR[2, 2] * vectorOriginal[2, 0];
        }

        void initVectorForPerspective(double x, double y, double z)
        {
            multiOfVectorsForTurn(x, y, z);
            vectorOriginal[0, 0] = vectorResult[0];
            vectorOriginal[1, 0] = vectorResult[1];
            vectorOriginal[2, 0] = vectorResult[2];
        }

        void summOfVectorsForPerspective(double x, double y, double z)
        {
            initVectorForPerspective(x, y, z);
            vectorSumm[0, 0] = vectorOriginal[0, 0] + vectorT[0, 0];
            vectorSumm[1, 0] = vectorOriginal[1, 0] + vectorT[1, 0];
            vectorSumm[2, 0] = vectorOriginal[2, 0] + vectorT[2, 0];
        }

        void multiOfVectorsForPerspective(double x, double y, double z)
        {
            summOfVectorsForPerspective(x, y, z);
            vectorResult[0] = matrixK[0, 0] * vectorSumm[0, 0] + matrixK[0, 1] * vectorSumm[1, 0] + matrixK[0, 2] * vectorSumm[2, 0];
            vectorResult[1] = matrixK[1, 0] * vectorSumm[0, 0] + matrixK[1, 1] * vectorSumm[1, 0] + matrixK[1, 2] * vectorSumm[2, 0];
            vectorResult[2] = matrixK[2, 0] * vectorSumm[0, 0] + matrixK[2, 1] * vectorSumm[1, 0] + matrixK[2, 2] * vectorSumm[2, 0];
        }


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

        public double X1
        {
            get
            {
                return x1;
            }
            set
            {
                x1 = value;
            }
        }
        public double Y1
        {
            get
            {
                return y1;
            }
            set
            {
                y1 = value;
            }
        }
        public double Z1
        {
            get
            {
                return z1;
            }
            set
            {
                z1 = value;
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
        
        public cls3D_Point(double x, double y, double z)
        {
            x1 = x;
            y1 = y;
            z1 = z;
            multiOfVectorsForPerspective(x, y, z);
            //multiOfVectorsForTurn(x, y, z);
            this.x = (int)vectorResult[0];
            this.y = (int)vectorResult[1];
            this.z = (int)vectorResult[2];

        }
        public cls3D_Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
