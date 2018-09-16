using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAL;
using Models;

namespace FrmReducerDesignerApplication
{   
    public partial class FrmUserLogin : Form
    {
        //创建数据访问类对象
        private SysAdminService objAdminService = new SysAdminService();
        public FrmUserLogin()
        {
            InitializeComponent();
        }
        #region 移动窗体
        private Point mouseOff;//鼠标移动位置变量
        private bool leftFlag;//标签是否为左键
        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);//得到变量的值
                leftFlag = true;//点击左键按下时标注为true
            }
        }
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //【1】数据验证
            if (this.txtLoginId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入登录账号！", "登录提示");
                this.txtLoginId.Focus();
                return;
            }
            if (!Common.DataValidate.IsInteger(this.txtLoginId.Text.Trim()))
            {
                MessageBox.Show("登录账号必须为正整数!", "提示信息");
                this.txtLoginId.Focus();
                return;
            }
            if (this.txtLoginPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入登录密码！", "登录提示");
                this.txtLoginPwd.Focus();
                return;
            }
            //[2]封装对象
            SysAdmin objAdmin = new SysAdmin()
            {
                LoginId = Convert.ToInt32(this.txtLoginId.Text.Trim()),
                LoginPwd = this.txtLoginPwd.Text.Trim()
            };
            //[3]和后台交互，判断登录信息是否正确
            try
            {
                objAdmin = objAdminService.AdminLogin(objAdmin);
                if (objAdmin != null)
                {
                    //保存登录信息
                    Program.objCurrentAdmin = objAdmin;
                    //设置登录窗体的返回值
                    this.DialogResult = DialogResult.OK;
                    //关闭窗体
                    this.Close();
                }
                else
                {
                    MessageBox.Show("登录账号或密码有误！", "登录提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据访问出现异常，登录失败！具体原因：" + ex.Message);
            }  
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
