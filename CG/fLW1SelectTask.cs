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
    public partial class fLW1SelectTask : Form
    {
        public fLW1SelectTask()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTask1_Click(object sender, EventArgs e)
        {
            fLW1Task1 fLW1Task1 = new fLW1Task1();
            fLW1Task1.ShowDialog();
        }
    }
}
