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

namespace FrmReducerDesignerApplication
{
    public partial class FrmKeyGear : Form
    {
        /// <summary>
        /// 花键齿轮轴
        /// </summary>
        public FrmKeyGear()
        {
            InitializeComponent();
        }
        public GetParaSpur4 msgSender;
        #region 验证输入数据方法
        /// <summary>
        /// 验证输入数据-------------
        /// </summary>
        public void VerificationInput()
        {
            string D1 = this.txtKEYD1.Text;
            string D2 = this.txtKEYD2.Text;
            string D3 = this.txtKEYD3.Text;
            string D4 = this.txtKEYD4.Text;
            string L1 = this.txtKeyL1.Text;
            string L2 = this.txtKeyL2.Text;
            string L3 = this.txtKeyL3.Text;
            string B1 = this.txtKeyB1.Text;
            string L4 = this.txtKeyL4.Text;
            string B = this.txtKeyB.Text;
            string L5 = this.txtKeyL5.Text;
            string Num = this.txtKeyNum.Text;

            if (!VerificationIsDigital(D1))
            {
                throw new Exception("轴段直径(D1)不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(D2))
            {
                throw new Exception("轴段直径D2不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(D3))
            {
                throw new Exception("轴段直径D3不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(D4))
            {
                throw new Exception("轴段直径D4不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(L1))
            {
                throw new Exception("轴段长度L1不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(L2))
            {
                throw new Exception("轴段长度L2不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(L3))
            {
                throw new Exception("轴段长度L3不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(B1))
            {
                throw new Exception("键宽B1不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(B))
            {
                throw new Exception("槽宽B不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(L4))
            {
                throw new Exception("轴段长度L4不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(L5))
            {
                throw new Exception("轴段长度L5不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(Num))
            {
                throw new Exception("花键个数N不是有效数字，请重新输入！");
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
        private void BtnKeyY_Click(object sender, EventArgs e)
        {
            try
            {
                VerificationInput();                
                //委托方法传递输入数据
                if (msgSender != null)
                {
                    double D1 = Convert.ToDouble(this.txtKEYD1.Text);
                    double D2 = Convert.ToDouble(this.txtKEYD2.Text);
                    double D3 = Convert.ToDouble(this.txtKEYD3.Text);
                    double D4 = Convert.ToDouble(this.txtKEYD4.Text);
                    double L1 = Convert.ToDouble(this.txtKeyL1.Text);
                    double L2 = Convert.ToDouble(this.txtKeyL2.Text);
                    double L3 = Convert.ToDouble(this.txtKeyL3.Text);
                    double L4 = Convert.ToDouble(this.txtKeyL4.Text);
                    double L5 = Convert.ToDouble(this.txtKeyL5.Text);
                    double B1 = Convert.ToDouble(this.txtKeyB1.Text);
                    double B = Convert.ToDouble(this.txtKeyB.Text);
                    int num = Convert.ToInt32(this.txtKeyNum.Text);
                    msgSender(D1/1000.0, D2/1000.0, D3/1000.0, D4/1000.0, L1/1000.0, L2/1000.0, L3/1000.0, L4/1000.0, L5/1000.0, B1/1000.0, B/1000.0, num);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }
        private void BtnKeyN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmKeyGear_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmUnstandardized.objFrmKey = null;
        }

    }
}
