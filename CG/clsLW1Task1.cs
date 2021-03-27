using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class clsLW1Task1
    {
        // размерность картинки
        public static int widht;
        public static int height;

        // отрисовка черного квадрата
        public static cls2D_Picture createBlackImage()
        {
            cls2D_Picture blackImage = new cls2D_Picture(widht, height);            // задаем размерность картинки
            int[,] black = new int[widht, height];
            for (int i = 0; i < widht; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    black[i, j] = 0;                                                        // задаем массив черных пикселей
                }
            }
            for (int i = 0; i < widht; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    blackImage.setPixel(i, j, new clsRGB(black[i, j], black[i, j], black[i, j]));        // рисуем массив
                }
            }
            return blackImage;  // возврат изображения
        }
        // отрисовка белого квадрата
        public static cls2D_Picture createWhiteImage()
        {
            cls2D_Picture whiteImage = new cls2D_Picture(widht, height);        // задаем размерность картинки 
            int[,] white = new int[widht, height];
            for (int i = 0; i < widht; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    white[i, j] = 255;                                              // залдаем массив белых пискелей
                }
            }
            for (int i = 0; i < widht; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    whiteImage.setPixel(i, j, new clsRGB(white[i, j], white[i, j], white[i, j]));        // рисуем массив
                }
            }
            return whiteImage;                      // возвращаем полученное изображдение
        }
        // отрисовка красного квадрата
        public static cls2D_Picture createRedImage()
        {
            cls2D_Picture redImage = new cls2D_Picture(widht, height);
            for (int i = 0; i < widht; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    redImage.setPixel(i, j, new clsRGB(255, 0, 0));
                }
            }
            return redImage;
        }
        // отрисовка градиентного квадрата
        public static cls2D_Picture createGradImage()
        {
            cls2D_Picture gradImage = new cls2D_Picture(widht, height);                 // задаем размерность картинки
            int[,] grad = new int[widht, height];
            for (int i = 0; i < widht; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    grad[i, j] = (i + j) % 256;                                 // задаем массив цветовых пикселей
                }
            }
            for (int i = 0; i < widht; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    gradImage.setPixel(i, j, new clsRGB(grad[i, j], grad[i, j], grad[i, j]));     // отрисовка полученного массива
                }
            }
            return gradImage;
        }
    }
}
