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
    public partial class fLW1Task1 : Form
    {
        public fLW1Task1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            Bitmap resultBlackImage = cls2D_Picture.picture2DtoBitmap(clsLW1Task1.createBlackImage());
            pictureBox1.Image = resultBlackImage;
            cls2D_Picture.savePicture(resultBlackImage, 1);
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            Bitmap resultWhiteImage = cls2D_Picture.picture2DtoBitmap(clsLW1Task1.createWhiteImage());
            pictureBox1.Image = resultWhiteImage;
            cls2D_Picture.savePicture(resultWhiteImage, 2);
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            Bitmap resultRedImage = cls2D_Picture.picture2DtoBitmap(clsLW1Task1.createRedImage());
            pictureBox1.Image = resultRedImage;
            cls2D_Picture.savePicture(resultRedImage, 3);
        }

        private void btnGrad_Click(object sender, EventArgs e)
        {
            Bitmap resultGradImage = cls2D_Picture.picture2DtoBitmap(clsLW1Task1.createGradImage());
            pictureBox1.Image = resultGradImage;
            cls2D_Picture.savePicture(resultGradImage, 4);
        }

        private void btnReadSize_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") clsLW1Task1.widht = Convert.ToInt32(textBox1.Text);
            else MessageBox.Show("Вы не ввели ширину изображения", "Предупреждение", MessageBoxButtons.OK);
            if (textBox2.Text != "") clsLW1Task1.height = Convert.ToInt32(textBox2.Text);
            else MessageBox.Show("Вы не ввели ширину изображения", "Предупреждение", MessageBoxButtons.OK);
            if (textBox1.Text != "" && textBox2.Text != "") btnEnableTrue();
        }

        public void btnEnableFalse()
        {
            btnBlack.Enabled = false;
            btnWhite.Enabled = false;
            btnRed.Enabled = false;
            btnGrad.Enabled = false;
        }
        public void btnEnableTrue()
        {
            btnBlack.Enabled = true;
            btnWhite.Enabled = true;
            btnRed.Enabled = true;
            btnGrad.Enabled = true;
        }

        private void fLW1Task1_Load(object sender, EventArgs e)
        {
            btnEnableFalse();
        }
    }
}
