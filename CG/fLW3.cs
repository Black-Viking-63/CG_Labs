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

        private void btnSourceImage_Click(object sender, EventArgs e)
        {
            clsLoadData.polygons = clsLoadData.loadPolygonsFromObjectFileWithCheck();
            Bitmap image = cls2D_Picture.picture2DtoBitmap(clsTriangle.drawTriangleWithZBuffer());
            pictureBox1.Image = image;
            Image img = image;
            img.Save("ZbufferHare1.png");
        }

        private void btnPerspectiveImage_Click(object sender, EventArgs e)
        {
            clsLoadData.polygonsForPerspective = clsLoadData.loadPolygonsFromObjectFileWithCheckForPerspective();
            clsLoadData.polygonsForPerspective2 = clsLoadData.loadPolygonsFromObjectFileWithCheckForPerspective2();
            Bitmap image = cls2D_Picture.picture2DtoBitmap(clsTriangle.drawTriangleWithPerspective());
            pictureBox2.Image = image;
            Image img = image;
            img.Save("HareForPerspective.png");
        }

        private void btnTurnImage_Click(object sender, EventArgs e)
        {
            clsLoadData.polygonsForPerspective = clsLoadData.loadPolygonsFromObjectFileWithCheckForPerspective();
            clsLoadData.polygonsForPerspective2 = clsLoadData.loadPolygonsFromObjectFileWithCheckForPerspective2();
            Bitmap image = cls2D_Picture.picture2DtoBitmap(clsTriangle.drawTriangleWithPerspective());
            pictureBox2.Image = image;
            Image img = image;
            img.Save("HareForPerspective.png");
        }
    }
}
