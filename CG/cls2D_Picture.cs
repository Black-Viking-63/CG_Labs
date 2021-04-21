using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG
{
    public class cls2D_Picture
    {
        // размерность картинки
        public int width;
        public int height;

        // лист цветов
        List<clsRGB> colorsList = new List<clsRGB>();

        //конструктор двумерной картинки
        public cls2D_Picture(int width, int height)
        {
            this.width = width;
            this.height = height;
            for (int i = 0; i < width * height; i++)
            {
                colorsList.Add(new clsRGB(0, 0, 0));
            }
        }

        // методы доступа
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        // метод доступа к пикселям
        // постановка по координантам цветового пикселя
        public void setPixel(int x, int y, clsRGB rgbColour)
        {
            colorsList[x + Width * y] = rgbColour;
        }

        //получение цвета пикселя по координатам
        public clsRGB getColor(int x, int y)
        {
            return colorsList[x + Width * y];
        }


        // преобразование цвета
        public static Color ColorRGBtoColor(clsRGB value)
        {
            Color color = Color.FromArgb(value.Red, value.Green, value.Blue);
            return color;
        }

        // преобразование картинки в формат Bitmap
        public static Bitmap picture2DtoBitmap(cls2D_Picture image2D)
        {
            Bitmap result = new Bitmap(image2D.Width, image2D.Height);
            for (int x = 0; x < image2D.Width; x++)
            {
                for (int y = 0; y < image2D.Height; y++)
                {
                    result.SetPixel(x, y, ColorRGBtoColor(image2D.getColor(x, y)));
                }
            }
            return result;
        }


        // сохранение картинок
        public static void savePicture(Bitmap picture, int flag)
        {
            Image image = picture;
            switch (flag)
            {
                case 1: image.Save("Black_Picture.png"); break;
                case 2: image.Save("White_Picture.png"); break;
                case 3: image.Save("Red_Picture.png"); break;
                case 4: image.Save("Grad_Picture.png"); break;
                case 5: image.Save("First_Algoritm.png"); break;
                case 6: image.Save("Second_Algoritm.png"); break;
                case 7: image.Save("Third_Algoritm.png"); break;
                case 8: image.Save("Fourth_Algoritm.png"); break;
            }
        }

    }
}
