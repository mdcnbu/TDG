using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using DAL;

namespace FrmReducerDesignerApplication
{    
    public partial class FrmAddmin : Form
    {
        private SysAdminService objAdminService = new SysAdminService();
        public FrmAddmin()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region 验证数据
            if (this.txtLoginId.Text.Trim().Length == 0)
            {
                MessageBox.Show("登录名不能为空！");
                this.txtLoginId.Focus();
                return;
            }
            string id = this.txtLoginId.Text.Trim();
            string Sid = id.Substring(0, 2);
            if (!Sid.Equals("ZH"))
            {
                MessageBox.Show("请输入以'ZH'开头的六位登录名，如：ZH0000");
                this.txtLoginId.Focus();
                return;
            }
            if(objAdminService.LoginIdIsExited(this.txtLoginId.Text.Trim()))
            {
                MessageBox.Show("登录名已经存在，请重新输入！");
                this.txtLoginId.Focus();
                return;
            }
            if (this.txtLoginPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("登录密码不能为空！");
                this.txtLoginId.Focus();
                return;
            }
            #endregion
            #region 封装管理员用户对象
            SysAdmin objAdmins = new SysAdmin()
            {
                LoginId = this.txtLoginId.Text.Trim(),
                LoginPwd = this.txtLoginPwd.Text.Trim(),
                AdminName = this.txtAdminName.Text.Trim()
            };
            #endregion
            #region 调用后台方法添加对象
            try
            {
                if (1 == objAdminService.AddAdmins(objAdmins)) {
                    MessageBox.Show("管理员用户添加成功！");
                    this.txtLoginId.Text ="";
                    this.txtLoginPwd.Text = "";
                    this.txtAdminName.Text = "";
                };
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            #endregion
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLoginId_MouseEnter(object sender, EventArgs e)
        {
            ToolTip objTip = new ToolTip();
            objTip.Show("格式如：ZH0000", this.txtLoginId);
        }
    }
}
