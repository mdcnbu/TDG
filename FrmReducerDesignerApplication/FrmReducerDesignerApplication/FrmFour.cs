using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmReducerDesignerApplication
{
    public partial class FrmFour : Form
    {
        public FrmFour()
        {
            InitializeComponent();
        }
        public static FrmFive objFive = null;
        private void btnFourNext_Click(object sender, EventArgs e)
        {
            this.Visible = false;//隐藏当前窗体
            if (objFive == null)
            {
                objFive = new FrmFive();
                objFive.ShowDialog();
            }
            else
            {
                objFive.Activate();
                objFive.Show();
                objFive.WindowState = FormWindowState.Normal;
            }
        }
    }
}
