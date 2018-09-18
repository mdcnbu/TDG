using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace FrmReducerDesignerApplication
{
    public partial class FrmSpurSty3 : Form
    {
        public FrmSpurSty3()
        {
            InitializeComponent();
            if (this.lboxLeft.Items.Count == 0)
            {
                this.btnDelet.Enabled = false;
                this.btnAdd3.Enabled = false;
            }
        }
        //定义两个集合数组属性存放轴段尺寸
        public List<string[]> ShaftPara1 = new List<string[]>();
        public List<string[]> ShaftPara2 = new List<string[]>();
        //根据委托创建委托对象
        public GetParaSpur3 msgSender;
        private List<string[]> para1;
        private List<string[]> para2;
        #region 获取显示格式的参数列表方法
        /// <summary>
        /// 获取显示格式的参数列表方法1,2
        /// </summary>
        /// <returns></returns>
        public List<string> ShowPara1()
        {
            List<string> paraList1 = new List<string>();//设为属性，避免每次调用方法都要初始化
            for (int i = 0; i < this.ShaftPara1.Count; i++)
            {
                string showPara = string.Empty;
                if (i < 9)
                {
                    showPara = "0" + (i + 1) + "段:";
                }
                else
                {
                    showPara = (i + 1) + "段:";
                }
                for (int a = 0; a < this.ShaftPara1[i].Length; a++)
                {
                    if (a == 0)
                    {
                        showPara += "直径:" + this.ShaftPara1[i][a] + " ";
                    }
                    else
                    {
                        showPara += "长度:" + this.ShaftPara1[i][a];
                    }

                }

                paraList1.Add(showPara);
            }
            return paraList1;
        }
        public List<string> ShowPara2()
        {
            List<string> paraList2 = new List<string>();
            for (int i = 0; i < this.ShaftPara2.Count; i++)
            {
                string showPara = string.Empty;
                if (i < 9)
                {
                    showPara = "0" + (i + 1) + "段:";
                }
                else
                {
                    showPara = (i + 1) + "段:";
                }
                for (int a = 0; a < this.ShaftPara2[i].Length; a++)
                {
                    if (a == 0)
                    {
                        showPara += "直径:" + this.ShaftPara2[i][a] + " ";
                    }
                    else
                    {
                        showPara += "长度:" + this.ShaftPara2[i][a];
                    }

                }

                paraList2.Add(showPara);
            }
            return paraList2;
        }
        #endregion
        #region 验证输入数据方法
        /// <summary>
        /// 验证输入数据-------------
        /// </summary>
        public void VerificationInput()
        {
            string diaValue = this.txtDiameter3.Text;
            string lengValue = this.txtLength3.Text;

            if (!VerificationIsDigital(diaValue))
            {
                throw new Exception("直径不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(lengValue))
            {
                throw new Exception("长度值不是有效数字，请重新输入！");
            }
        }
        /// <summary>
        /// 验证是否是数字---------
        /// </summary>
        /// <param name="value">验证内容</param>
        /// <returns></returns>
        private bool VerificationIsDigital(string value)
        {
            if (Regex.IsMatch(value, @"^\d+(.\d+)?$"))
            {
                return true;
            }
            return false;
        }
        #endregion
        private void ShowParaNums1()
        {
            this.lboxLeft.Items.Clear();
            this.lboxLeft.Items.AddRange(this.ShowPara1().ToArray());
        }
        private void ShowParaNums2()
        {
            this.lboxRight.Items.Clear();
            this.lboxRight.Items.AddRange(ShowPara2().ToArray());
        }

        private void btnAddL_Click(object sender, EventArgs e)
        {
            try
            {
                VerificationInput();
                if (this.btnDelet.Enabled == false || this.btnAdd3.Enabled == false)
                {
                    this.btnAdd3.Enabled = true;
                    this.btnDelet.Enabled = true;
                }
                string[] ShaftParamete1 ={
                                      this.txtDiameter3.Text,
                                      this.txtLength3.Text,
                                                           };
                ShaftPara1.Add(ShaftParamete1);
                ShowParaNums1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddR_Click(object sender, EventArgs e)
        {
            try
            {
                VerificationInput();
                if (this.btnDelet.Enabled == false || this.btnAdd3.Enabled == false)
                {
                    this.btnAdd3.Enabled = true;
                    this.btnDelet.Enabled = true;
                }
                string[] ShaftParamete2 ={
                                      this.txtDiameter3.Text,
                                      this.txtLength3.Text,
                                                           };
                ShaftPara2.Add(ShaftParamete2);
                ShowParaNums2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            if (this.lboxLeft.SelectedItem != null)
            {
                int indexL = this.lboxLeft.SelectedIndex;//获取左边的索引
                ShaftPara1.RemoveAt(indexL);
                ShowParaNums1();
            }
            else if (this.lboxRight.SelectedItem != null)
            {
                int indexR = this.lboxRight.SelectedIndex;
                ShaftPara2.RemoveAt(indexR);
                ShowParaNums2();
            }
            if (ShaftPara1.Count == 0 && ShaftPara2.Count == 0)
            {
                this.btnDelet.Enabled = false;
                this.btnAdd3.Enabled = false;
            }
        }

        private void btnAdd3_Click(object sender, EventArgs e)
        {
            //委托方法传递输入数据
            if (msgSender != null)
            {
                para1 = ShaftPara1;
                para2 = ShaftPara2;
                msgSender(para1, para2);
            }
            this.Close();
        }

        private void FrmSpurSty3_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmUnstandardized.objFrm3 = null;
        }
    }
}
