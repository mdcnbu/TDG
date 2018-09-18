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
    public partial class FrmSpurSty2 : Form
    {
        public FrmSpurSty2()
        {
            InitializeComponent();
        }
        //定义下拉框数据
        double[] holeDiamArry = new double[] { 10, 15, 20, 25, 30, 35, 40, 45, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };
        int[] holeNumArry = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        double[] keyWidth = new double[] { 2, 3, 4, 5, 6, 8, 10, 12, 14, 16, 18, 20, 22, 25, 28, 32, 36, 40, 45, 50, 56, 63, 70, 80, 90, 100 };
        double[] keyDeep = new double[] { 1, 1.4, 1.8, 2.3, 2.8, 3.3, 3.8, 4.3, 4.4, 4.9, 5.4, 6.4, 7.4, 8.4, 9.4, 10.4, 11.4, 12.4, 14.4, 15.4, 17.4, 19.5 };
        #region 验证输入数据方法
        /// <summary>
        /// 验证输入数据
        /// </summary>
        public void VerificationInput()
        {
            string Dia1 = this.txtDia1.Text;
            string Dia2 = this.txtDia2.Text;
            string Dia3 = this.txtDia3.Text;
            string Dia4 = this.txtDia4.Text;
            string banThick = this.txtBanThick.Text;
            string guWidth = this.txtGuWidth.Text;
            string holeDiam = this.cboHoleDia.Text;
            string holeNums = this.cboHoleNum.Text;
            string keyWidths = this.cboKeyWidth.Text;
            string keyDeep = this.cboKeyDeep.Text;
            if (!VerificationIsDigital(Dia1))
            {
                throw new Exception("孔径不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(Dia2))
            {
                throw new Exception("毂外径不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(Dia3))
            {
                throw new Exception("D3不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(Dia4))
            {
                throw new Exception("D4不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(banThick))
            {
                throw new Exception("腹板厚度值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(guWidth))
            {
                throw new Exception("轮毂宽度值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(holeDiam))
            {
                throw new Exception("孔的直径值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(holeNums))
            {
                throw new Exception("孔的个数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(keyWidths))
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

        private void FrmSpurSty2_Load(object sender, EventArgs e)
        {
            foreach (double holeDiam in holeDiamArry)
            {
                cboHoleDia.Items.Add(holeDiam);
            }
            foreach (int holeNum in holeNumArry)
            {
                cboHoleNum.Items.Add(holeNum);
            }
            foreach (double keyWid in keyWidth)
            {
                cboKeyWidth.Items.Add(keyWid);
            }
            foreach (double keyDee in keyDeep)
            {
                cboKeyDeep.Items.Add(keyDee);
            }
        }
        //根据委托创建委托对象
        public GetParaSpur2 msgSender;
        private double dia1 = 0.0;
        private double dia2 = 0.0;
        private double dia3 = 0.0;
        private double dia4 = 0.0;
        private double banThick = 0.0;
        private double guWidth = 0.0;
        private double holeDia = 0.0;
        private int holeNum = 0;
        private double keyW = 0.0;
        private double keyD = 0.0;
        private void FrmSpurSty2_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmUnstandardized.objFrm2 = null;
        }

        private void btnStyle2_Click(object sender, EventArgs e)
        {
            try
            {
                VerificationInput();
                if (msgSender != null)
                {
                    dia1 = Convert.ToDouble(this.txtDia1.Text);
                    dia2 = Convert.ToDouble(this.txtDia2.Text);
                    dia3 = Convert.ToDouble(this.txtDia3.Text);
                    dia4 = Convert.ToDouble(this.txtDia4.Text);
                    banThick = Convert.ToDouble(this.txtBanThick.Text);
                    guWidth = Convert.ToDouble(this.txtGuWidth.Text);
                    holeDia = Convert.ToDouble(this.cboHoleDia.Text);
                    holeNum = Convert.ToInt32(this.cboHoleNum.Text);
                    keyW = Convert.ToDouble(this.cboKeyWidth.Text);
                    keyD = Convert.ToDouble(this.cboKeyDeep.Text);
                    msgSender(dia1, dia2, dia3, dia4, banThick, guWidth, holeDia, holeNum, keyW, keyD);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
