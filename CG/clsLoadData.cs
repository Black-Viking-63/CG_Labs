using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsLoadData
    {
        // массивы для чтения координат и полигонов
        public static string[] lines;
        public static string[] words;
        public static string[] numbers;

        // координаты
        public static double x;
        public static double y;
        public static double z;
        public static List<cls3D_Point> points = new List<cls3D_Point>();

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
                    cls3D_Point point = new cls3D_Point(x, y, z, 5000, 600);       // инициализируем точку по координатам
                    points.Add(point);                                             // записываем в лист точку
                }
            }
            return points; // возвращаем массив точек
        }
    
    }
}
