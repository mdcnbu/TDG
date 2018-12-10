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
    public partial class FrmEvolentCacul : Form
    {
        public FrmEvolentCacul()
        {
            InitializeComponent();
        }
        double inv1;
        double R1 = 10.0;//左端点
        double R2 = 60.0;//右端点
        /// <summary>
        /// 迭代求解α'
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        private double CaculateAlp(double Value)
        {
            //先定一个初始值
            double initialValue = (R2 - R1) * 0.6180339887 + R1;
            for (int i = 0; i < 800; i++)
            {
                inv1 = Math.Tan(initialValue * Math.PI / 180) - (initialValue * Math.PI / 180);
                if (inv1 < Value)
                {
                    R2 = initialValue;
                    initialValue = (R2 - R1) * 0.381966011 + R1;
                }
                else
                {
                    R1 = initialValue;
                    initialValue = (R2 - R1) * 0.6180339887 + R1;
                }
            }
            return initialValue;
        }

        private double CaculateInv(double v)
        {
            double v1 = Math.Tan(v / 180 * Math.PI);
            double Inv = v1 - (v / 180 * Math.PI);
            return Inv;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();//销毁回收对象
        }

        private double CaculateAngle()
        {
            string val1 =this.txtVal1.Text.Trim();
            string val2 =this.txtVal2.Text.Trim();
            string val3 =this.txtVal3.Text.Trim();
            if (!Common.DataValidate.VerificationIsDigital(val1))
            {
                throw new Exception("输入的字符格式不正确！");           
            } 
            if (!Common.DataValidate.VerificationIsDigital(val2))
            {
                throw new Exception("输入的字符格式不正确！");
            } if (!Common.DataValidate.VerificationIsDigital(val3))
            {
                throw new Exception("输入的字符格式不正确！");
            }
            double v1 = Convert.ToDouble(val1);
            double v2 = Convert.ToDouble(val2);
            double v3 = Convert.ToDouble(val3);
            double alp = Math.Round(v1 + v2 / 60 + v3 / 600, 2);//角度大小
            return alp;
        }

        private void txtVal1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVal2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double angle = CaculateAngle();
                double inv = CaculateInv(angle);
                this.txtResultInv.Text = inv.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtVal3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double angle = CaculateAngle();
                double inv = CaculateInv(angle);
                this.txtResultInv.Text = inv.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtInvVal_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
        /// <summary>
        /// 原函数
        /// </summary>
        /// <param name="alp"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        private double OldFunction(double alp, double a)
        {
            double res = Math.Tan(alp) - alp - a;         
            return res;
        }
        /// <summary>
        /// 导函数
        /// </summary>
        /// <param name="alp"></param>
        /// <returns></returns>
        private double Dfunction(double alp)
        {
            double res = Math.Tan(alp) * Math.Tan(alp);          
            return res;
        }
        public double CacuAlp(double a)
        { 
            double res=0.0;
            double res1 = 0.0;
            //double alp = Math.PI * 20 / 180;//设置初始值
            double alp = 1.0;
            do
            {
            res1 = OldFunction(alp, a);
            double res2 = Dfunction(alp);
            alp = alp - res1 / res2;
           }
            while (res1 > 0.00001||res1<-0.00001);
            return alp;
        }

        private void txtrad_Click(object sender, EventArgs e)
        {
            string val = this.txtInvVal.Text.Trim();
            double v1;
            double v2;
            if (!Common.DataValidate.VerificationIsDigital(val))
            {
                MessageBox.Show("输入的字符格式不正确！");
                return;
            }
            double initial = Convert.ToDouble(val);
            double v = Math.Pow(initial * 3, 1.0 / 3.0);
            v1 = OldFunction(v, initial);
            v2 = Dfunction(v);       
            do
            {
                v = v - v1 / v2;
                v1 = OldFunction(v, initial);
             } while (v1 > 0.000001 || v1 < -0.000001);
            this.txtrad.Text = Math.Round(v, 7).ToString();//弧度值
            //换算成角度值
            double angle = Math.Round(v * 180 / Math.PI, 3);
            //对角度值求余数
            string vv = angle.ToString();
            if (angle%2==0)
            {
                this.txtα.Text = vv + "°";
            }
            else
            {
                string firstVal = vv.Substring(0, vv.LastIndexOf('.'));//度
                string vvv = vv.Substring(vv.LastIndexOf('.')+1, 3);
                double value = Convert.ToDouble(vvv) / 1000.0;
                double secondVCa = value * 60;
                string secondV = secondVCa.ToString().Substring(0, secondVCa.ToString().LastIndexOf('.') - 0);//分
                string lastV = secondVCa.ToString().Substring(secondVCa.ToString().LastIndexOf('.'));
                double lastvv = Convert.ToDouble(lastV);
                double lastVcacu =Math.Round(lastvv * 60);
                string Alp = firstVal + "°" + secondV + "'" + lastVcacu + "''";//最终度数显示
                this.txtα.Text = Alp;
            }
        }

        private void txtα_Click(object sender, EventArgs e)
        {
            this.txtrad_Click(null, e);
        }
    }
}
