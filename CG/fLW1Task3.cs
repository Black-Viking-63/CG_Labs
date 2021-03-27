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
    public partial class fLW1Task3 : Form
    {
        public fLW1Task3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap resultImageLines = cls2D_Picture.picture2DtoBitmap(clsLW1Task3.drawLine(1));  // отрисовка линий
            pictureBox1.Image = resultImageLines;                                                   // отображние на экране
            cls2D_Picture.savePicture(resultImageLines, 5);                                         // сохранение в файл 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap resultImageLines = cls2D_Picture.picture2DtoBitmap(clsLW1Task3.drawLine(2));  // отрисовка линий
            pictureBox1.Image = resultImageLines;                                                   // отображние на экране
            cls2D_Picture.savePicture(resultImageLines, 6);                                         // сохранение в файл 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap resultImageLines = cls2D_Picture.picture2DtoBitmap(clsLW1Task3.drawLine(3));  // отрисовка линий
            pictureBox1.Image = resultImageLines;                                                   // отображние на экране
            cls2D_Picture.savePicture(resultImageLines, 7);                                         // сохранение в файл 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap resultImageLines = cls2D_Picture.picture2DtoBitmap(clsLW1Task3.drawLine(4));  // отрисовка линий
            pictureBox1.Image = resultImageLines;                                                   // отображние на экране
            cls2D_Picture.savePicture(resultImageLines, 8);                                         // сохранение в файл 

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
