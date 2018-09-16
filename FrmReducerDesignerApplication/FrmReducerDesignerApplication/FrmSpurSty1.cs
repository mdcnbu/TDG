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
    public partial class FrmSpurSty1 : Form
    {
        public FrmSpurSty1()
        {
            InitializeComponent();
        }
        //根据委托创建委托对象(定义委托变量)
        public GetParaSpur1 msgSender;
        private double dia = 0.0;
        private double wid = 0.0;
        private double deep = 0.0;
        double[] diameterArry1 = new double[]{
        5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,35,40,45,50,55,60
        };
        double[] widthArry1 = new double[]{
            2,3,4,5,6,8,10,12,14,16,18,20,22,25,28,32,36,40,45,50,56,63,70,80,90,100
        };
        double[] deepArry1 = new double[]{
            1,1.4,1.8,2.3,2.8,3.3,3.8,4.3,4.4,4.9,5.4,6.4,7.4,8.4,9.4,10.4,11.4,12.4,14.4,15.4,17.4,19.5
        };
        #region 验证输入数据方法
        /// <summary>
        /// 验证输入数据-------------
        /// </summary>
        public void VerificationInput()
        {
            string holeDia = this.cboDiameter1.Text;//齿数
            string keyWidth = this.cboKeyWidth1.Text;//齿宽
            string keyDeep = this.cboKeyHight1.Text;//顶高系数

            if (!VerificationIsDigital(holeDia))
            {
                throw new Exception("孔径不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(keyWidth))
            {
                throw new Exception("键槽宽度值不是有效数字，请重新输入！");
            }

            if (!VerificationIsDigital(keyDeep))
            {
                throw new Exception("键槽深度值不是有效数字，请重新输入！");
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
        private void FrmSpurSty1_Load(object sender, EventArgs e)
        {
            foreach (double diameter in diameterArry1)
            {
                cboDiameter1.Items.Add(diameter);
            }
            foreach (double width in widthArry1)
            {
                cboKeyWidth1.Items.Add(width);
            }
            foreach (double deep in deepArry1)
            {
                cboKeyHight1.Items.Add(deep);
            }
        }

        private void btnStyle1_Click(object sender, EventArgs e)
        {
            try
            {
                VerificationInput();
                //委托方法传递输入数据
                if (msgSender != null)
                {
                    dia = Convert.ToDouble(this.cboDiameter1.Text);
                    wid = Convert.ToDouble(this.cboKeyWidth1.Text);
                    deep = Convert.ToDouble(this.cboKeyHight1.Text);
                    msgSender(dia, wid, deep);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmSpurSty1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmUnstandardized.objFrm1 = null;
        }
    }
}
