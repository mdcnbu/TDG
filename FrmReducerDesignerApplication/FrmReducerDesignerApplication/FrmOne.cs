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
    //[1]定义委托方法
    public delegate void delegateMeasure(int c, int d);
    public partial class FrmOne : Form
    {
        //[2]定义一个事件
        public event GetValue OperateGetValue;
        public FrmOne()
        {
            InitializeComponent();
        }
        //定义变量
        double KA = 0.0;//工作特性大小
        double inputTorque = 0.0;//输入扭矩大小
        double outRevolo;
        double outputTorque;
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
        public static FrmTwo objTwo = null;
        private void btnNextStep_Click(object sender, EventArgs e)
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
                this.txtInputPower.Focus();
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
                this.txtDrivenEfficient.Focus();
                return;
            }
            if (this.txtLifeUsing.Text.Trim().Length == 0)
            {
                MessageBox.Show("使用寿命不能为空！", "提示信息");
                this.txtLifeUsing.Focus();
                return;
            }
            if (!Common.DataValidate.IsNumber(this.txtLifeUsing.Text.Trim()))
            {
                MessageBox.Show("使用寿命不是有效数字，请重新输入！", "提示信息");
                this.txtLifeUsing.Focus();
                return;
            }
            if (this.txtInputRpm.Text.Trim().Length == 0)
            {
                MessageBox.Show("输入转速不能为空！", "提示信息");
                this.txtInputRpm.Focus();
                return;
            }
            if (!Common.DataValidate.IsNumber(this.txtInputRpm.Text.Trim()))
            {
                MessageBox.Show("输入转速不是有效数字，请重新输入！", "提示信息");
                this.txtInputRpm.Focus();
                return;
            }
            if (this.txtDrivenRatio.Text.Trim().Length == 0)
            {
                MessageBox.Show("传动比不能为空！", "提示信息");
                this.txtDrivenRatio.Focus();
                return;
            }
            if (!Common.DataValidate.VerificationIsDigital(this.txtDrivenRatio.Text.Trim()))
            {
                MessageBox.Show("传动比不是有效数字，请重新输入！", "提示信息");
                this.txtDrivenRatio.Focus();
                return;
            }
            if (this.txtJingDU.Text.Trim().Length == 0)
            {
                MessageBox.Show("精度等级不能为空！", "提示信息");
                this.txtJingDU.Focus();
                return;
            }
            #endregion
            //委托传递参数值
            if (msgSender != null) { msgSender(inputPower, speedRatio, inputRevolo, drivenEfficient, outputTorque, outRevolo, inputTorque, KA); }
            this.Visible = false; //-------------------还有对数据的处理操作----------------------------
            if (objTwo == null)
            {
                objTwo = new FrmTwo();
                objTwo.ShowDialog();
            }
            else
            {
                objTwo.Activate();//激活窗体
                objTwo.Show();
                objTwo.WindowState = FormWindowState.Normal;
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
            inputTorque = 9550000 * inputPower / inputRevolo;//额定输入扭矩值(N.m)
            outRevolo = inputRevolo / speedRatio;//输出转速大小
            outputTorque = inputTorque * inputRevolo * drivenEfficient / outRevolo;//输出转矩大小

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
            inputTorque = 9550000 * inputPower / inputRevolo;//额定输入扭矩值(N.m)
            outRevolo = inputRevolo / speedRatio;//输出转速大小
            outputTorque = inputTorque * inputRevolo * drivenEfficient / outRevolo;//输出转矩大小
            OperateGetValue(inputPower, inputRevolo, speedRatio, drivenEfficient, inputTorque, outRevolo, outputTorque, KA);
            this.Close();
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

        public GetFrm1Value msgSender;//创建委托对象（用于传递窗体1中的值） 
    }
}
