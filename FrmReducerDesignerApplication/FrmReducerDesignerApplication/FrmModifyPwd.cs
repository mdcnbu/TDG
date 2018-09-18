using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Models;

namespace FrmReducerDesignerApplication
{
    public partial class FrmModifyPwd : Form
    {
        public FrmModifyPwd()
        {
            InitializeComponent();
        }

        private void btnModifyPwd_Click(object sender, EventArgs e)
        {
            //验证
            if (this.txtPrimPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入原密码！", "提示信息");
                this.txtPrimPwd.Focus();
                return;
            }
            //判断密码是否一致
            if (this.txtPrimPwd.Text.Trim() != Program.objCurrentAdmin.LoginPwd)
            {
                MessageBox.Show("请输入正确的原密码", "提示信息");
                this.txtPrimPwd.Focus();
                this.txtPrimPwd.SelectAll();
                return;
            }
            //判断新密码的长度
            if (this.txtNewPwd.Text.Trim().Length < 6)
            {
                MessageBox.Show("新密码长度不能少于6位", "提示信息");
                this.txtNewPwd.Focus();
                this.txtNewPwd.SelectAll();
                return;
            }
            //判断两次输入是否一致
            if (this.txtRefirmPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请再次输入新密码", "提示信息");
                this.txtRefirmPwd.Focus();
                return;
            }
            if (this.txtRefirmPwd.Text.Trim() != this.txtNewPwd.Text.Trim())
            {
                MessageBox.Show("两次输入密码不一致", "提示信息");
                this.txtRefirmPwd.Focus();
                this.txtRefirmPwd.SelectAll();
                return;
            }
            try
            {
                SysAdmin objAdmin = new SysAdmin()
                {
                    LoginId = Program.objCurrentAdmin.LoginId,
                    LoginPwd = this.txtNewPwd.Text.Trim()
                };
                if (new SysAdminService().ModifyPwd(objAdmin) == 1)
                {
                    MessageBox.Show("密码修改成功！", "提示信息");
                    Program.objCurrentAdmin.LoginPwd = this.txtNewPwd.Text.Trim();
                    this.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnCancelModify_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
