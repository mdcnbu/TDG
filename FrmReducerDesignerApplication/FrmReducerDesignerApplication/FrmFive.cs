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
    public partial class FrmFive : Form
    {
        public FrmFive()
        {
            InitializeComponent();
        }
        public static FrmSix objSix = null;
        private void btnFiveNext_Click(object sender, EventArgs e)
        {
            this.Visible = false;//隐藏当前窗体
            if (objSix == null)
            {
                objSix = new FrmSix();
                objSix.ShowDialog();
            }
            else
            {
                objSix.Activate();
                objSix.Show();
                objSix.WindowState = FormWindowState.Normal;
            }
        }
    }
}
