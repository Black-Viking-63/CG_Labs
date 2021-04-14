using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG
{
    public partial class fLW1Task5_7 : Form
    {
        public fLW1Task5_7()
        {
            InitializeComponent();
        }

        // методы открытия закрытия доступа и вилимости кнопок в зависимости от лабораторной работы
        public void openButton()
        {
            btnLoadData.Enabled = false;                  // закрытие кнопки загрузки точек и полигонов
            btnDrawTops.Enabled = true;
            btnDrawPolygons.Enabled = true;                                     // открытие кнопок отрисовки вершин и полигонов
        }
        public void closeButton()
        {
            btnDrawTops.Enabled = false;
            btnDrawPolygons.Enabled = false;                                     // открытие кнопок отрисовки вершин и полигонов
        }

        public void closeButton2()
        {
            btnDrawTriangle.Enabled = false;
            btnVolHare.Enabled = false;
            btnZbuffer.Enabled = false;
        }

        public void openButton2()
        {
            btnDrawTriangle.Enabled = true;
            btnVolHare.Enabled = true;
            btnZbuffer.Enabled = true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fLW1Task5_7_Load(object sender, EventArgs e)
        {
            if (clsLoadData.flagNumberLW == 1)
            {
                btnDrawTriangle.Visible = false;
                btnVolHare.Visible = false;
                btnZbuffer.Visible = false;
                closeButton();
            }
            if (clsLoadData.flagNumberLW == 2)
            {
                closeButton();
                closeButton2();
                btnDrawTriangle.Visible = true;
                btnVolHare.Visible = true;
                btnZbuffer.Visible = true;
            }
        }

        // загрузка данных
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            clsLoadData.loadTopsFromObjectFileForLineTrans();
            
            if (clsLoadData.flagNumberLW == 1)
            {
                clsLoadData.loadPolygonsFromObjectFileWithOutCheck();
                openButton();                
            }
            if (clsLoadData.flagNumberLW == 2)
            {
                clsLoadData.loadPolygonsFromObjectFileWithCheck();
                openButton();
                openButton2();
            }
        }

        // отрисовка вершин
        private void btnDrawTops_Click(object sender, EventArgs e)
        {
            Bitmap image = cls2D_Picture.picture2DtoBitmap(clsLW1Task5.drawTopsFromObjectFile(clsLoadData.pointsForLineTrans));
            pictureBox1.Image = image;
            Image img = image;
            img.Save("Tops.png");
        }

        // отрисовка полигонов
        private void btnDrawPolygons_Click(object sender, EventArgs e)
        {
            Bitmap image = cls2D_Picture.picture2DtoBitmap(clsLW1Task7.drawPolygonsFromObjectFile(clsLoadData.polygonsForLineTrans));
            pictureBox1.Image = image;
            Image img = image;
            img.Save("Polygons.png");                                  
        }

        // отрисовка треугольниками
        private void btnDrawTriangle_Click(object sender, EventArgs e)
        {
            Bitmap image = cls2D_Picture.picture2DtoBitmap(clsTriangle.drawTriangle());
            pictureBox1.Image = image;
            Image img = image;
            img.Save("Triangles.png");
        }

        // отрисовка объемной модели
        private void btnVolHare_Click(object sender, EventArgs e)
        {
            Bitmap image = cls2D_Picture.picture2DtoBitmap(clsTriangle.drawVolTriangle());
            pictureBox1.Image = image;
            Image img = image;
            img.Save("VolumeHare.png");
        }
       


        // отрисовка объемной модели через z буфер
        private void btnZbuffer_Click(object sender, EventArgs e)
        {
            clsLoadData.pointsForDraw = clsLoadData.loadTopsFromObjectFileForDraw();
            clsLoadData.pointsForLight = clsLoadData.loadTopsFromObjectFileForLight();
            clsLoadData.polygonsForDraw = clsLoadData.loadPolygonsFromObjectFileForDraw();
            clsLoadData.polygonsForLight = clsLoadData.loadPolygonsFromObjectFileForLight();
            Bitmap image = cls2D_Picture.picture2DtoBitmap(clsTriangle.drawTriangleWithZBufferForTurn());
            pictureBox1.Image = image;
            Image img = image;
            img.Save("ZbufferHare.png");
            
        }
    }
}
