using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG
{
    public class clsLoadData
    {
        // массивы для чтения координат и полигонов
        public static string[] lines;
        public static string[] words;
        public static string[] numbers;

        // вершины полигонов
        public static double x;
        public static double y;
        public static double z;
        public static List<cls3D_Point> pointsForLineTrans = new List<cls3D_Point>();

        // сами полигоны
        public static int polygon1;
        public static int polygon2;
        public static int polygon3;
        public static List<clsPolygon> polygonsForLineTrans = new List<clsPolygon>();

        public static int flagNumberLW = 0;

        // считываем и записываем вершины
        public static List<cls3D_Point> loadTopsFromObjectFileForLineTrans()
        {
            lines = File.ReadAllLines("Test.obj");                                  // считывание информации из файла
            for (int i = 0; i < lines.Length; i++)
            {
                words = lines[i].Split(' ');
                if (words[0] == "v")                                                // ищем вершины
                {
                    // CultureInfo.InvariantCulture позволяет читать десятичные числа как 0.хххх, а не 0,ххх
                    x = double.Parse(words[1], CultureInfo.InvariantCulture);       // считываем врешины
                    y = double.Parse(words[2], CultureInfo.InvariantCulture);
                    z = double.Parse(words[3], CultureInfo.InvariantCulture);
                    cls3D_Point point = new cls3D_Point(x, y, z, 5000, 600);       // инициализируем точку по координатам
                    pointsForLineTrans.Add(point);                                             // записываем в лист точку
                }
            }
            return pointsForLineTrans; // возвращаем массив точек
        }
        // считываем и записываем полигоны
        public static List<clsPolygon> loadPolygonsFromObjectFileWithOutCheck()
        {
            pointsForLineTrans = loadTopsFromObjectFileForLineTrans();                            // считываем информацию
            for (int i = 0; i < lines.Length; i++)
            {
                words = lines[i].Split(' ');
                if (words[0] == "f")
                {
                    words = lines[i].Split(' ', '/');                               // считываем координаты полигонов          
                    polygon1 = int.Parse(words[1]);
                    polygon2 = int.Parse(words[4]);
                    polygon3 = int.Parse(words[7]);
                    clsPolygon polygon = new clsPolygon();                      //  записываем полигон
                    polygon[0] = pointsForLineTrans[polygon1 - 1];
                    polygon[1] = pointsForLineTrans[polygon2 - 1];
                    polygon[2] = pointsForLineTrans[polygon3 - 1];
                    polygonsForLineTrans.Add(polygon);                                          // сохраняем в лист
                }

            }
            return polygonsForLineTrans;
        }

        public static List<clsPolygon> loadPolygonsFromObjectFileWithCheck()
        {
            pointsForLineTrans = loadTopsFromObjectFileForLineTrans();                     // считываем информацию
            for (int i = 0; i < lines.Length; i++)
            {
                words = lines[i].Split(' ');
                if (words[0] == "f")
                {
                    words = lines[i].Split(' ', '/');                               // считываем координаты полигонов          
                    polygon1 = int.Parse(words[1]);
                    polygon2 = int.Parse(words[4]);
                    polygon3 = int.Parse(words[7]);
                    clsPolygon polygon = new clsPolygon();                      //  записываем полигон
                    polygon[0] = pointsForLineTrans[polygon1 - 1];
                    polygon[1] = pointsForLineTrans[polygon2 - 1];
                    polygon[2] = pointsForLineTrans[polygon3 - 1];
                    clsBarycentricCoordinates barycentricCoordinates = new clsBarycentricCoordinates(polygon);
                    clsBarycentricCoordinates.Calculating_lambda_coefficients(polygon[0]);
                    if (Math.Abs(1 - clsBarycentricCoordinates.Lambda0 - clsBarycentricCoordinates.Lambda1 -
                                 clsBarycentricCoordinates.Lambda2) > 0.001)
                    {
                        MessageBox.Show("Сумма барицентрических координат не равна 1!", "Ошибка",
                            MessageBoxButtons.OK);
                    }
                    polygonsForLineTrans.Add(polygon);                                          // сохраняем в лист
                }
            }
            return polygonsForLineTrans;

        }
    }
}
