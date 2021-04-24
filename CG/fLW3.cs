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
    public partial class fLW3 : Form
    {
        public fLW3()
        {
            InitializeComponent();
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTurn_Click(object sender, EventArgs e)
        {            
            Bitmap image = cls2D_Picture.picture2DtoBitmap(clsTriangle.drawTriangleWithZBufferForTransformation());
            pictureBox1.Image = image;
            Image img = image;
            img.Save("RotationHare.png");
        }

        private void btnZbuffer_Click(object sender, EventArgs e)
        {
            Bitmap image = cls2D_Picture.picture2DtoBitmap(clsTriangle.drawTriangleWithZBuffer());
            pictureBox1.Image = image;
            Image img = image;
            img.Save("ZbufferHare.png");
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            clsLoadData.polygonsForLineTrans = clsLoadData.loadPolygonsFromObjectFileWithCheck();
            clsLoadData.polygonsForTransformation = clsLoadData.loadPolygonsFromObjectFileWithCheckForTransformation();
            clsLoadData.normPolygons = clsLoadData.loadNormsPolygonsFromObjectFile();
            btnZbuffer.Enabled = true;
            btnTurn.Enabled = true;
            btnLight.Enabled = true;

        }

        private void fLW3_Load(object sender, EventArgs e)
        {
            btnZbuffer.Enabled = false;
            btnTurn.Enabled = false;
            btnLight.Enabled = false;
        }

        private void btnLight_Click(object sender, EventArgs e)
        {
            Bitmap image = cls2D_Picture.picture2DtoBitmap(clsTriangle.drawTriangleWithZBufferForTransformationWithModifiedLight());
            pictureBox1.Image = image;
            Image img = image;
            img.Save("HareWithModifiedLight.png");
        }
    }
}
