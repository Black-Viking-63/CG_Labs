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
        public static List<cls3D_Point> points = new List<cls3D_Point>();
        public static List<cls3D_Point> pointsForPerspective = new List<cls3D_Point>();
        public static List<cls3D_Point> pointsForPerspective2 = new List<cls3D_Point>();

        // сами полигоны
        public static int polygon1;
        public static int polygon2;
        public static int polygon3;
        public static List<clsPolygon> polygons = new List<clsPolygon>();
        public static List<clsPolygon> polygonsForPerspective = new List<clsPolygon>();
        public static List<clsPolygon> polygonsForPerspective2 = new List<clsPolygon>();

        public static int flagNumberLW = 0;

        // считываем и записываем вершины
        public static List<cls3D_Point> loadTopsFromObjectFile()
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
                    cls3D_Point point = new cls3D_Point(x, y, z, 4000, 500);       // инициализируем точку по координатам
                    points.Add(point);                                             // записываем в лист точку
                }
            }
            return points; // возвращаем массив точек
        }

        public static List<cls3D_Point> loadTopsFromObjectFileForPerspective()
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
                    cls3D_Point point = new cls3D_Point(x, -y, z);       // инициализируем точку по координатам
                    pointsForPerspective.Add(point);                                             // записываем в лист точку
                }
            }
            return pointsForPerspective; // возвращаем массив точек
        }
        // считываем и записываем полигоны
        public static List<cls3D_Point> loadTopsFromObjectFileForPerspective2()
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
                    cls3D_Point point = new cls3D_Point(x, -y, z);       // инициализируем точку по координатам
                    pointsForPerspective2.Add(point);                                             // записываем в лист точку
                }
            }
            return pointsForPerspective2; // возвращаем массив точек
        }
        public static List<clsPolygon> loadPolygonsFromObjectFileWithOutCheck()
        {

            points = loadTopsFromObjectFile();                            // считываем информацию
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
                    polygon[0] = points[polygon1 - 1];
                    polygon[1] = points[polygon2 - 1];
                    polygon[2] = points[polygon3 - 1];
                    polygons.Add(polygon);                                          // сохраняем в лист
                }

            }
            return polygons;

        }
        public static List<clsPolygon> loadPolygonsFromObjectFileWithCheck()
        {
            points = loadTopsFromObjectFile();                     // считываем информацию
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
                    polygon[0] = points[polygon1 - 1];
                    polygon[1] = points[polygon2 - 1];
                    polygon[2] = points[polygon3 - 1];
                    clsBarycentricCoordinates barycentricCoordinates = new clsBarycentricCoordinates(polygon);
                    clsBarycentricCoordinates.Calculating_lambda_coefficients(polygon[0]);
                    if (Math.Abs(1 - clsBarycentricCoordinates.Lambda0 - clsBarycentricCoordinates.Lambda1 -
                                 clsBarycentricCoordinates.Lambda2) > 0.001)
                    {
                        MessageBox.Show("Сумма барицентрических координат не равна 1!", "Ошибка",
                            MessageBoxButtons.OK);
                    }
                    polygons.Add(polygon);                                          // сохраняем в лист
                }
            }
            return polygons;
        }
        public static List<clsPolygon> loadPolygonsFromObjectFileWithCheckForPerspective()
        {
            pointsForPerspective = loadTopsFromObjectFileForPerspective();                     // считываем информацию
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
                    polygon[0] = pointsForPerspective[polygon1 - 1];
                    polygon[1] = pointsForPerspective[polygon2 - 1];
                    polygon[2] = pointsForPerspective[polygon3 - 1];
                    clsBarycentricCoordinates barycentricCoordinates = new clsBarycentricCoordinates(polygon);
                    clsBarycentricCoordinates.Calculating_lambda_coefficients(polygon[0]);
                    if (Math.Abs(1 - clsBarycentricCoordinates.Lambda0 - clsBarycentricCoordinates.Lambda1 -
                                 clsBarycentricCoordinates.Lambda2) > 0.001)
                    {
                        MessageBox.Show("Сумма барицентрических координат не равна 1!", "Ошибка",
                            MessageBoxButtons.OK);
                    }
                    polygonsForPerspective.Add(polygon);                                          // сохраняем в лист
                }
            }
            return polygonsForPerspective;
        }

        public static List<clsPolygon> loadPolygonsFromObjectFileWithCheckForPerspective2()
        {
            pointsForPerspective2 = loadTopsFromObjectFileForPerspective2();                     // считываем информацию
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
                    polygon[0] = pointsForPerspective2[polygon1 - 1];
                    polygon[1] = pointsForPerspective2[polygon2 - 1];
                    polygon[2] = pointsForPerspective2[polygon3 - 1];
                    clsBarycentricCoordinates barycentricCoordinates = new clsBarycentricCoordinates(polygon);
                    clsBarycentricCoordinates.Calculating_lambda_coefficients(polygon[0]);
                    if (Math.Abs(1 - clsBarycentricCoordinates.Lambda0 - clsBarycentricCoordinates.Lambda1 -
                                 clsBarycentricCoordinates.Lambda2) > 0.001)
                    {
                        MessageBox.Show("Сумма барицентрических координат не равна 1!", "Ошибка",
                            MessageBoxButtons.OK);
                    }
                    polygonsForPerspective2.Add(polygon);                                          // сохраняем в лист
                }
            }
            return polygonsForPerspective2;
        }
    }
}
