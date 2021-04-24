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
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLW1_Click(object sender, EventArgs e)
        {
            clsLoadData.flagNumberLW = 1;
            fLW1SelectTask fLW1SelectTask = new fLW1SelectTask();
            fLW1SelectTask.ShowDialog();
        }

        private void btnLW2_Click(object sender, EventArgs e)
        {
            clsLoadData.flagNumberLW = 2;
            fLW1Task5_7 fLW1Task5_7 = new fLW1Task5_7();
            fLW1Task5_7.ShowDialog();
        }

        private void btnLW3_Click(object sender, EventArgs e)
        {
            fLW3 fLW3 = new fLW3();
            fLW3.ShowDialog();
        }
    }
}
