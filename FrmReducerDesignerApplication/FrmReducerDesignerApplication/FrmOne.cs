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
    /// <summary>
    /// [1]定义委托方法
    /// </summary>
    /// <param name="c"></param>
    /// <param name="d"></param>
    public delegate void delegateMeasure(int c, int d);
    public partial class FrmOne : Form
    {
        /// <summary>
        /// [2]定义一个事件(传递窗体1、2、3、4、5、6的值)
        /// </summary>
        public event GetValue OperateGetValue;
        public event GetValue PassData1;
        public event GetValue2 PassData;
        public event GetValue3 PassDatas;
        public event GetValue4 passData4;
        public event GetValue5 passData5;
        public event GetValue6 passData6;
        public FrmOne()
        {
            InitializeComponent();
        }
        //public GetFrm1Value msgSender;//创建委托对象（用于传递窗体1中的值） 
        //定义变量
        double KA = 0.0;//工作特性大小
        double inputTorque = 0.0;//输入扭矩大小
        double outRevolo;
        double outputTorque;
        double loadXishu;
        public static MachineForce objFrm = null;
        private void btnListShow_Click(object sender, EventArgs e)
        {
            //创建选择列表窗体            
            if (objFrm == null)
            {
                objFrm = new MachineForce();
                objFrm.OperateRadioEvent += new delegateMeasure(this.OperateRadioBtn);//委托与事件视频

                objFrm.ShowDialog();
            }
            else
            {
                objFrm.Activate();//激活窗体
                objFrm.Show();
                objFrm.WindowState = FormWindowState.Normal;
            }
        }
        //public static FrmTwo objTwo = null;
        private void btnNextStep_Click(object sender, EventArgs e)
        {
            FrmDesign objD = new FrmDesign();
            try
            {
                CaculateVal();//调用确定按钮代码                
                //委托传递参数值(传递给第二步窗体)               
                //    msgSender(inputPower, speedRatio, inputRevolo, drivenEfficient, outputTorque, outRevolo, inputTorque, KA); 
          
                this.Hide();
                objD.btnCaculGearNum_Click(null, new EventArgs());//调用主窗体事件创建子窗体2==
                /*ShowDialog()方法创建的窗体对象是个模式对话框，
                 * 前一个窗体不关闭后一个窗体不能进行任何操作,show（）和showdialog（）方法区别参见百度*/

                //激发事件传递窗体1的值
                PassData1(inputPower, inputRevolo, speedRatio, drivenEfficient, inputTorque, outRevolo, outputTorque, KA, loadXishu);
                //传递窗体3的值
      
                int plantaryNum = Common.PassValues.plantaryNum;
                double za = Common.PassValues.za;
                double zb = Common.PassValues.zb;
                double zc = Common.PassValues.zc;
                double reRation = Common.PassValues.reRation;//实际减速比
                string rationGap = Common.PassValues.rationGap;//减速比误差
                //实际输出转速和实际输出扭矩（计算）
                double outRevoReal = Common.PassValues.outRevoReal;//实际输出转速
                double outTorReal = Common.PassValues.outTorReal;//实际输出扭矩
                PassData(plantaryNum, za, zb, zc, reRation, rationGap, outTorReal, outRevoReal);
                //传递窗体3的值
                string s1 = Common.PassValues.sunMaterial;
                string s2 = Common.PassValues.planMaterial;
                string s3 = Common.PassValues.innMaterial;
                PassDatas(s1, s2, s3);
                double v1 = Common.PassValues.faiD;
                double v2 = Common.PassValues.contactXY;
                double v3 = Common.PassValues.Tac;
                double v4 = Common.PassValues.a;
                double v5 = Common.PassValues.kc;
                double v6 = Common.PassValues.k;
                double v7 = Common.PassValues.u;
                double v8 = Common.PassValues.m;
                passData4(v1, v2, v3, v4, v5, v6, v7, v8);
                double β = 0.00;
                double aN = Common.PassValues.anone;
                double a = Common.PassValues.a;
                double xa = Common.PassValues.Xa;
                double xb = Common.PassValues.Xb;
                double xc = Common.PassValues.Xc;
                double d1 = Common.PassValues.d1;
                double d2 = Common.PassValues.d2;
                double d3 = Common.PassValues.d3;
                double da1 = Common.PassValues.da1;
                double da2 = Common.PassValues.da2;
                double da3 = Common.PassValues.da3;
                passData5(β, aN, a, xa, xb, xc, d1, d3, d2, da1, da3, da2);
                double c1 = Common.PassValues.contactA;
                double c2 = Common.PassValues.contactXY;
                double c3 = Common.PassValues.aBendVal;
                double c4 = Common.PassValues.cBendVal;
                double c5 = Common.PassValues.xyBenda;
                double c6 = Common.PassValues.xyBendc;
                passData6(c1, c2, c3, c4, c5, c6);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
         
        }
        private void GetUiValue()
        {
            double inputPower, inputRevolo, speedRatio, lifeTime, drivenEfficient;
            //获取UI中的值
            if (this.txtInputPower.Text.Length != 0)
            {
                inputPower = Convert.ToDouble(this.txtInputPower.Text.Trim());//输入功率值               
            }
            else
            {
                return;
            }
            if (this.txtInputRpm.Text.Length != 0)
            {
                inputRevolo = Convert.ToDouble(this.txtInputRpm.Text.Trim());//输入转速大小              
            }
            else
            {
                return;
            }
            if (this.txtDrivenRatio.Text.Length != 0)
            {
                speedRatio = Convert.ToDouble(this.txtDrivenRatio.Text.Trim());//传动比大小              
            }
            else
            {
                return;
            }
            if (this.txtDrivenEfficient.Text.Length != 0)
            {
                drivenEfficient = Convert.ToDouble(this.txtDrivenEfficient.Text.Trim());//传动效率值
            }
            else { return; }
            if (this.txtLifeUsing.Text.Length != 0)
            {
                lifeTime = Convert.ToDouble(this.txtLifeUsing.Text.Trim());//使用寿命
            }
            else { return; }
            //计算其他值
            inputTorque = System.Math.Round(9550000 * inputPower / inputRevolo / 1000.0, 2);//额定输入扭矩值(N.m)
            outRevolo = System.Math.Round(inputRevolo / speedRatio, 2);//输出转速大小
            outputTorque = System.Math.Round(inputTorque * inputRevolo * drivenEfficient / outRevolo, 2);//输出转矩大小

        }

        private void btnCancelOne_Click(object sender, EventArgs e)
        {
            //清空用户输入内容
            this.txtInputPower.Text = "22";
            this.txtInputRpm.Text = "1400";
            this.txtDrivenEfficient.Text = "0.98";
            this.txtLifeUsing.Text = "10000";
            this.txtDrivenRatio.Text = "7";
            this.txtJingDU.Text = "7-7-7";
            this.rdoStable.Checked = true;
            this.rdoSlightShock.Checked = false;
            this.rdoMidleShock.Checked = false;
            this.rdoSeverlyShock.Checked = false;
            this.rdoSeverlyShock2.Checked = false;
            this.rdoMidShock2.Checked = false;
            this.rdoSlightShock2.Checked = false;
            this.rdoStable2.Checked = true;
            this.txtInputPower.Focus();
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }
        int rdo1, rdo2;
        #region 定义事件响应方法
        /// <summary>
        /// 【4】定义事件响应方法
        /// </summary>
        /// <param name="c">原动机索引值</param>
        /// <param name="d">原动机索引值</param>
        public void OperateRadioBtn(int c, int d)
        {
            rdo1 = c;
            rdo2 = d;
            if (c == 1 && d == 1)
            {
                this.rdoStable.Checked = true;
                this.rdoStable2.Checked = true;
            }
            if (c == 1 && d == 2)
            {
                this.rdoStable.Checked = true;
                this.rdoSlightShock2.Checked = true;
            }
            if (c == 1 && d == 3)
            {
                this.rdoStable.Checked = true;
                this.rdoMidShock2.Checked = true;
            }
            if (c == 1 && d == 4)
            {
                this.rdoStable.Checked = true;
                this.rdoSeverlyShock2.Checked = true;
            }
            if (c == 2 && d == 1)
            {
                this.rdoSlightShock.Checked = true;
                this.rdoStable2.Checked = true;
            }
            if (c == 2 && d == 2)
            {
                this.rdoSlightShock.Checked = true;
                this.rdoSlightShock2.Checked = true;
            }
            if (c == 2 && d == 3)
            {
                this.rdoSlightShock.Checked = true;
                this.rdoMidShock2.Checked = true;
            }
            if (c == 2 && d == 4)
            {
                this.rdoSlightShock.Checked = true;
                this.rdoSeverlyShock2.Checked = true;
            }
            if (c == 3 && d == 1)
            {
                this.rdoMidleShock.Checked = true;
                this.rdoStable2.Checked = true;
            }
            if (c == 3 && d == 2)
            {
                this.rdoMidleShock.Checked = true;
                this.rdoSlightShock2.Checked = true;
            }
            if (c == 3 && d == 3)
            {
                this.rdoMidleShock.Checked = true;
                this.rdoMidShock2.Checked = true;
            }
            if (c == 3 && d == 4)
            {
                this.rdoMidleShock.Checked = true;
                this.rdoSeverlyShock2.Checked = true;
            }
            if (c == 4 && d == 1)
            {
                this.rdoSeverlyShock.Checked = true;
                this.rdoStable2.Checked = true;
            }
            if (c == 4 && d == 2)
            {
                this.rdoSeverlyShock.Checked = true;
                this.rdoSlightShock2.Checked = true;
            }
            if (c == 4 && d == 3)
            {
                this.rdoSeverlyShock.Checked = true;
                this.rdoMidShock2.Checked = true;
            }
            if (c == 4 && d == 4)
            {
                this.rdoSeverlyShock.Checked = true;
                this.rdoSeverlyShock2.Checked = true;
            }
        }
        #endregion
        double inputPower, inputRevolo, speedRatio, lifeTime, drivenEfficient;
        private void btnCaculOne_Click(object sender, EventArgs e)
        {
            CaculateVal();
            OperateGetValue(inputPower, inputRevolo, speedRatio, drivenEfficient, inputTorque, outRevolo, outputTorque, KA, loadXishu);
            this.Hide();
        }
        private void CaculateVal()
        {
            #region 数据验证
            if (this.rdoStable.Checked == false & rdoSlightShock.Checked == false & rdoMidleShock.Checked == false & rdoSeverlyShock.Checked == false)
            {
                MessageBox.Show("请选择原动机工作特性！", "提示信息");
                return;
            }
            if (this.rdoSeverlyShock2.Checked == false & this.rdoMidShock2.Checked == false & this.rdoSlightShock2.Checked == false & this.rdoStable2.Checked == false)
            {
                MessageBox.Show("请选择工作机工作特性！", "提示信息");
                return;
            }
            if (this.txtInputPower.Text.Trim().Length == 0)
            {
                MessageBox.Show("输入功率不能为空！", "提示信息");
                this.txtDrivenEfficient.Focus();
                return;
            }
            if (!Common.DataValidate.VerificationIsDigital(this.txtInputPower.Text.Trim()))
            {
                MessageBox.Show("输入功率不是有效数字，请重新输入！", "提示信息");
                this.txtInputPower.Focus();
                return;
            }
            if (this.txtDrivenEfficient.Text.Trim().Length == 0)
            {
                MessageBox.Show("传动效率不能为空！", "提示信息");
                this.txtDrivenEfficient.Focus();
                return;
            }
            if (!Common.DataValidate.VerificationIsDigital(this.txtDrivenEfficient.Text.Trim()))
            {
                MessageBox.Show("传动效率不是有效数字，请重新输入！", "提示信息");
                this.txtInputPower.Focus();
                return;
            }
            if (this.txtLifeUsing.Text.Trim().Length == 0)
            {
                MessageBox.Show("使用寿命不能为空！", "提示信息");
                this.txtDrivenEfficient.Focus();
                return;
            }
            if (!Common.DataValidate.IsNumber(this.txtLifeUsing.Text.Trim()))
            {
                MessageBox.Show("使用寿命不是有效数字，请重新输入！", "提示信息");
                this.txtInputPower.Focus();
                return;
            }
            if (this.txtInputRpm.Text.Trim().Length == 0)
            {
                MessageBox.Show("输入转速不能为空！", "提示信息");
                this.txtDrivenEfficient.Focus();
                return;
            }
            if (!Common.DataValidate.IsNumber(this.txtInputRpm.Text.Trim()))
            {
                MessageBox.Show("输入转速不是有效数字，请重新输入！", "提示信息");
                this.txtInputPower.Focus();
                return;
            }
            if (this.txtDrivenRatio.Text.Trim().Length == 0)
            {
                MessageBox.Show("传动比不能为空！", "提示信息");
                this.txtDrivenEfficient.Focus();
                return;
            }
            if (!Common.DataValidate.VerificationIsDigital(this.txtDrivenRatio.Text.Trim()))
            {
                MessageBox.Show("传动比不是有效数字，请重新输入！", "提示信息");
                this.txtInputPower.Focus();
                return;
            }
            if (this.txtJingDU.Text.Trim().Length == 0)
            {
                MessageBox.Show("精度等级不能为空！", "提示信息");
                this.txtDrivenEfficient.Focus();
                return;
            }
            #endregion
            #region [2]计算KA值

            if (rdo1 == 1 && rdo2 == 1 || this.rdoStable.Checked == true && this.rdoStable2.Checked == true)
            {
                KA = 1;

            }
            if (rdo1 == 1 && rdo2 == 2 || this.rdoStable.Checked == true && this.rdoSlightShock2.Checked == true)
            {
                KA = 1.25;

            }
            if (rdo1 == 1 && rdo2 == 3 || this.rdoStable.Checked == true && this.rdoMidShock2.Checked == true)
            {
                KA = 1.5;

            }
            if (rdo1 == 1 && rdo2 == 4 || this.rdoStable.Checked == true && this.rdoSeverlyShock2.Checked == true)
            {
                KA = 1.75;

            }
            if (rdo1 == 2 && rdo2 == 1 || this.rdoSlightShock.Checked == true && this.rdoStable2.Checked == true)
            {
                KA = 1.1;

            }
            if (rdo1 == 3 && rdo2 == 1 || this.rdoMidleShock.Checked == true && this.rdoStable2.Checked == true)
            {
                KA = 1.25;

            }
            if (rdo1 == 4 && rdo2 == 1 || this.rdoSeverlyShock.Checked == true && this.rdoStable2.Checked == true)
            {
                KA = 1.5;

            }
            if (rdo1 == 2 && rdo2 == 2 || this.rdoSlightShock.Checked == true && this.rdoSlightShock2.Checked == true)
            {
                KA = 1.35;

            }
            if (rdo1 == 2 && rdo2 == 3 || this.rdoSlightShock.Checked == true && this.rdoMidShock2.Checked == true)
            {
                KA = 1.6;

            }
            if (rdo1 == 2 && rdo2 == 4 || this.rdoSlightShock.Checked == true && this.rdoSeverlyShock2.Checked == true)
            {
                KA = 1.85;

            }
            if (rdo1 == 3 && rdo2 == 2 || this.rdoMidleShock.Checked == true && this.rdoSlightShock2.Checked == true)
            {
                KA = 1.5;

            }
            if (rdo1 == 3 && rdo2 == 3 || this.rdoMidleShock.Checked == true && this.rdoMidShock2.Checked == true)
            {
                KA = 1.75;

            }
            if (rdo1 == 3 && rdo2 == 4 || this.rdoMidleShock.Checked == true && this.rdoSeverlyShock2.Checked == true)
            {
                KA = 2.0;

            }
            if (rdo1 == 4 && rdo2 == 2 || this.rdoSeverlyShock.Checked == true && this.rdoSlightShock2.Checked == true)
            {
                KA = 1.75;

            }
            if (rdo1 == 4 && rdo2 == 3 || this.rdoSeverlyShock.Checked == true && this.rdoMidShock2.Checked == true)
            {
                KA = 2.0;

            }
            if (rdo1 == 4 && rdo2 == 4 || this.rdoSeverlyShock.Checked == true && this.rdoSeverlyShock2.Checked == true)
            {
                KA = 2.25;

            }
            #endregion
            //获取UI中的值
            if (this.txtInputPower.Text.Length != 0)
            {
                inputPower = Convert.ToDouble(this.txtInputPower.Text.Trim());//输入功率值               
            }
            else
            {
                return;
            }
            if (this.txtInputRpm.Text.Length != 0)
            {
                inputRevolo = Convert.ToDouble(this.txtInputRpm.Text.Trim());//输入转速大小              
            }
            else
            {
                return;
            }
            if (this.txtDrivenRatio.Text.Length != 0)
            {
                speedRatio = Convert.ToDouble(this.txtDrivenRatio.Text.Trim());//传动比大小              
            }
            else
            {
                return;
            }
            if (this.txtDrivenEfficient.Text.Length != 0)
            {
                drivenEfficient = Convert.ToDouble(this.txtDrivenEfficient.Text.Trim());//传动效率值
            }
            else { return; }
            if (this.txtLifeUsing.Text.Length != 0)
            {
                lifeTime = Convert.ToDouble(this.txtLifeUsing.Text.Trim());//使用寿命
            }
            else { return; }
            //计算其他值
            inputTorque = System.Math.Round(9550000 * inputPower / inputRevolo / 1000.0, 2);//额定输入扭矩值(N.m)
            outRevolo = System.Math.Round(inputRevolo / speedRatio, 2);//输出转速大小
            outputTorque = System.Math.Round(inputTorque * inputRevolo * drivenEfficient / outRevolo, 2);//输出转矩大小
            loadXishu = Convert.ToDouble(this.txtJYxishu.Text.Trim());//均载系数
            Common.PassValues.Acurcy = this.txtJingDU.Text.Trim();//精度大小
            Common.PassValues.inputPower = inputPower;
            Common.PassValues.speedRatio = speedRatio;
            Common.PassValues.inputRevolo = inputRevolo;
            Common.PassValues.drivenEfficient = drivenEfficient;
            Common.PassValues.outputTorque = outputTorque;
            Common.PassValues.outRevolo = outRevolo;
            Common.PassValues.inputTorque = inputTorque;
            Common.PassValues.loadXishu = loadXishu;
            Common.PassValues.KA = KA;
        }


        #region textChanged事件方法
        private void txtInputPower_TextChanged(object sender, EventArgs e)
        {
            GetUiValue();//调用方法
            this.txtInputTorque.Text = inputTorque.ToString();
            this.txtOutPutTorque.Text = outputTorque.ToString();
        }

        private void txtDrivenRatio_TextChanged(object sender, EventArgs e)
        {
            GetUiValue();//调用方法
            this.txtOutPutRpm.Text = outRevolo.ToString();
            this.txtOutPutTorque.Text = outputTorque.ToString();
        }

        private void txtInputRpm_TextChanged(object sender, EventArgs e)
        {
            GetUiValue();//调用方法
            this.txtInputTorque.Text = inputTorque.ToString();
            this.txtOutPutRpm.Text = outRevolo.ToString();
            this.txtOutPutTorque.Text = outputTorque.ToString();
        }

        private void txtDrivenEfficient_TextChanged(object sender, EventArgs e)
        {
            GetUiValue();//调用方法
            this.txtOutPutTorque.Text = outputTorque.ToString();
        }
        #endregion



        private void chkSun_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.chkSun.Checked == true) && (this.chkCarrier.Checked == true) && (this.chkInner.Checked == true))
            {
                MessageBox.Show("请选择不高于3个构件！");
                this.chkSun.Checked = false;
            }
            if ((this.chkSun.Checked == true) && (this.chkCarrier.Checked == false) && (this.chkInner.Checked == false))
            {
                this.txtJYxishu.Text = "1.15";
            }
            if ((this.chkSun.Checked == true) && (this.chkCarrier.Checked == true) && (this.chkInner.Checked == false))
            {
                this.txtJYxishu.Text = "1.2";
            }
            if ((this.chkSun.Checked == true) && (this.chkCarrier.Checked == false) && (this.chkInner.Checked == true))
            {
                this.txtJYxishu.Text = "1.15";
            }

        }

        private void chkInner_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.chkSun.Checked == true) && (this.chkCarrier.Checked == true) && (this.chkInner.Checked == true))
            {
                MessageBox.Show("请选择不高于3个构件！");
                this.chkInner.Checked = false;
            }
            if ((this.chkSun.Checked == false) && (this.chkCarrier.Checked == false) && (this.chkInner.Checked == true))
            {
                this.txtJYxishu.Text = "1.15";
            }
            if ((this.chkSun.Checked == true) && (this.chkCarrier.Checked == false) && (this.chkInner.Checked == true))
            {
                this.txtJYxishu.Text = "1.15";
            }
        }

        private void chkCarrier_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.chkSun.Checked == true) && (this.chkCarrier.Checked == true) && (this.chkInner.Checked == true))
            {
                MessageBox.Show("请选择不高于3个构件！");
                this.chkCarrier.Checked = false;
            }
            if ((this.chkSun.Checked == false) && (this.chkCarrier.Checked == true) && (this.chkInner.Checked == false))
            {
                this.txtJYxishu.Text = "1.15";
            }
            if ((this.chkSun.Checked == true) && (this.chkCarrier.Checked == true) && (this.chkInner.Checked == false))
            {
                this.txtJYxishu.Text = "1.20";
            }
        }
    }
}
