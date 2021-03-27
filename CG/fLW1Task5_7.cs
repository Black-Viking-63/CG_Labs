using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            btnDrawTriangle.Enabled = false;
            btnDrawTriangle.Visible = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fLW1Task5_7_Load(object sender, EventArgs e)
        {
            if (clsLoadData.flagNumberLW == 1)
            {
                closeButton();
            }
            if (clsLoadData.flagNumberLW == 2)
            {
                closeButton();
                // btnDrawTriangle.Visible = true;
                // btnDrawTriangle.Enabled = false;
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            clsLoadData.loadTopsFromObjectFile();
            clsLoadData.loadPolygonsFromObjectFile();
            if (clsLoadData.flagNumberLW == 1)
            {
                openButton();
            }
            if (clsLoadData.flagNumberLW == 2)
            {
                openButton();
                // btnDrawTriangle.Enabled = true;
            }
        }

        private void btnDrawTops_Click(object sender, EventArgs e)
        {
            Bitmap image = cls2D_Picture.picture2DtoBitmap(clsLW1Task5.drawTopsFromObjectFile(clsLoadData.points));
            pictureBox1.Image = image;
            Image img = image;
            img.Save("Tops.png");
        }

        private void btnDrawPolygons_Click(object sender, EventArgs e)
        {
            Bitmap image = cls2D_Picture.picture2DtoBitmap(clsLW1Task7.drawPolygonsFromObjectFile(clsLoadData.polygons));
            pictureBox1.Image = image;
            Image img = image;
            img.Save("Polygons.png");                                  
        }
    }
}
