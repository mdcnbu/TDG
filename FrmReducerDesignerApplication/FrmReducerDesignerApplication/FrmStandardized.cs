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
    public partial class FrmStandardized : Form
    {
        /// <summary>
        /// 构造函数（初始化）
        /// </summary>
        public FrmStandardized()
        {
            InitializeComponent();
        }

        private void btnCloseReducer_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach (Control item in FrmMain.pMainWin.splitContainer1.Panel2.Controls)
            {
                if (item is PictureBox)
                {
                    PictureBox objPictu = (PictureBox)item;
                    objPictu.Show();
                }
            }
        }
    }
}
