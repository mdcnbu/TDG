using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;



namespace FrmReducerDesignerApplication
{
    public partial class FrmMain : Form
    {
        public static FrmMain pMainWin = null;//定义主窗体全局变量
        public FrmMain()
        {
            InitializeComponent();
            //显示登录用户名
            this.lblUserName.Text = Program.objCurrentAdmin.AdminName + "]";
            pMainWin = this;//初始化全局变量
        }
        #region 移动窗体
        private System.Drawing.Point mouseOff;//鼠标移动位置变量
        private bool leftFlag;//标签是否为左键
        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new System.Drawing.Point(-e.X, -e.Y);//得到变量的值
                leftFlag = true;//点击左键按下时标注为true
            }
        }
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                System.Drawing.Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);//设置移动后的位置
                Location = mouseSet;
            }
        }
        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false---------
            }
        }
        #endregion   
        private void CloseForm()
        {
            //判断容器中是否已经存在窗体
            foreach (Control item in this.splitContainer1.Panel2.Controls)
            {
                if (item is Form)
                {
                    Form objControl = (Form)item;
                    objControl.Close();
                }
                else if (item is PictureBox)
                {
                    PictureBox objPictu = (PictureBox)item;
                    objPictu.Hide();
                }
            }
        }
        private void OpenForm(Form objForm)
        {
            CloseForm();
            objForm.TopLevel = false;
            objForm.WindowState = FormWindowState.Normal;
            //this.splitContainer.Panel2.Controls.Remove(pictureBox);//嵌入子窗体前移除图片框            
            objForm.Parent = this.splitContainer1.Panel2;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }     
        private void btnAllDesign_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmDesign());
        }

        private void btnCloseMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗？", "退出询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result !=DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnModifPwd_Click(object sender, EventArgs e)
        {
            FrmModifyPwd objFrm = new FrmModifyPwd();
            objFrm.ShowDialog();
        }

        private void btnReducer_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmUnstandardized());
        }

        private void btnRejection_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmStandardized());
        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModifyPwd objFrm = new FrmModifyPwd();
            objFrm.ShowDialog();
        }

        private void btnAssembly_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmAssembly());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmDrawings());
        }

       
        private void btnDataMgr_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmDataMgr());
        }

        private void btnMinimal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEvolentCacul objFrm = new FrmEvolentCacul();
            objFrm.ShowDialog();
        }

        private void 添加管理员用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddmin objFrm = new FrmAddmin();
            objFrm.ShowDialog();
        }

        private void 普通平键尺寸查询ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmKey objkey = new FrmKey();
            objkey.ShowDialog();
        }

        private void 使用说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetails objDetails = new FrmDetails();
            objDetails.ShowDialog();
        }
     
    }
}
