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
    //定义委托
    public delegate void GetFrm1Value(double inputPower,double reRation,double inputRevolo,double efficent,double outpTorque,double outpRevolo,double inpuTorque,double Ka);
    public partial class FrmTwo : Form
    {
        public FrmTwo()
        {
            InitializeComponent();
        }
        double inPower, ration, inRevo, effic, outTor, outRevo, inTor, ka;
        //int sty2holeNums;
        private void Receiver2(double inputPower, double reRation, double inputRevolo, double efficent, double outpTorque, double outpRevolo, double inpuTorque, double Ka)
        {
            inPower = inputPower;
            ration = reRation;
            inRevo = inputRevolo;
            effic = efficent;
            outTor = outpTorque;
            outRevo = outpRevolo;
            inTor = inpuTorque;
            //sty2holeNums = holeNum;
            ka = Ka;        
        }
        private void btnPrimStep_Click(object sender, EventArgs e)
        {

        }
        public static FrmThree objThree = null;
        private void btnNextStep_Click(object sender, EventArgs e)
        {
            this.Visible = false;//隐藏当前窗体
            if (objThree == null)
            {
                objThree = new FrmThree();
                objThree.ShowDialog();
            }
            else
            {
                objThree.Activate();
                objThree.Show();
                objThree.WindowState = FormWindowState.Normal;
            }
        }
        #region //验证输入数据方法
        private void VerifyData()
        {
            if (this.txtPlantnearyNum.Text.Trim().Length==0)
            {
                MessageBox.Show("行星轮数目不能为空", "提示信息");
                this.txtPlantnearyNum.Focus();
                return;
            }
            if (!Common.DataValidate.IsInteger(this.txtPlantnearyNum.Text.Trim()))
            {
                MessageBox.Show("行星轮数目不是有效数字，请重新输入", "提示信息");
                this.txtPlantnearyNum.Focus();
                return;
            }
            if (this.txtSunGearNum.Text.Trim().Length==0)
            {
                MessageBox.Show("太阳轮齿数不能为空", "提示信息");
                this.txtSunGearNum.Focus();
                return;
            }
            if (!Common.DataValidate.IsInteger(this.txtSunGearNum.Text.Trim()))
            {
                MessageBox.Show("太阳轮齿数不是有效数字，请重新输入", "提示信息");
                this.txtSunGearNum.Focus();
                return;
            }
            if (this.txtInnerGearNum.Text.Trim().Length==0)
            {
                MessageBox.Show("内齿轮齿数不能为空", "提示信息");
                this.txtInnerGearNum.Focus();
                return;
            }
            if (!Common.DataValidate.IsInteger(this.txtInnerGearNum.Text.Trim()))
            {
                MessageBox.Show("内齿轮齿数不是有效数字，请重新输入", "提示信息");
                this.txtInnerGearNum.Focus();
                return;
            }
            if (this.txtPlantGearNum.Text.Trim().Length==0)
            {
                MessageBox.Show("行星轮齿数不能为空", "提示信息");
                this.txtPlantGearNum.Focus();
                return;
            }
            if (!Common.DataValidate.IsInteger(this.txtPlantGearNum.Text.Trim()))
            {
                MessageBox.Show("行星轮齿数不是有效数字，请重新输入", "提示信息");
                this.txtPlantGearNum.Focus();
                return;
            }
        }
        #endregion
        //配齿计算
        int speedRatio,plantneryNum, sunGearNum, plantGearNum, innerGearNum;
        private void CaculateGearNum()
        {
            VerifyData();
            //获取界面输入值
            plantneryNum = Convert.ToInt32(this.txtPlantnearyNum.Text.Trim());//行星轮数目值
            sunGearNum = Convert.ToInt32(this.txtSunGearNum.Text.Trim());//太阳轮齿数
            plantGearNum = Convert.ToInt32(this.txtPlantGearNum.Text.Trim());//行星轮齿数
            innerGearNum = Convert.ToInt32(this.txtInnerGearNum.Text.Trim());//内齿轮齿数
            //由传动比大小计算特性参数P值
            double P = speedRatio - 1;                   
            //初选太阳轮齿数za
            //sunGearNum = 18;
            //计算内齿轮齿数
            innerGearNum =Convert .ToInt32(P * sunGearNum);
            //计算行星轮数目
            plantGearNum = (innerGearNum - sunGearNum) / 2;
            //计算传动比误差
            //判断传动比条件（传动比误差计算，实际传动比计算）
            ratioReal = 1 + innerGearNum / sunGearNum;//实际传动比
            double rationGap = System.Math.Abs(ratioReal - ration) / ratioReal * 100;
            string gap = rationGap.ToString() + "%";
            this.txtRatioGap.Text = gap;//输出减速比误差
            //计算
        }
        private void MatchGear()//配齿计算
        {

        }
        //判断满足的条件4个
        double ratioReal;
        private void SatisfyConditon()
        {
            //判断传动比条件（传动比误差计算，实际传动比计算）
            ratioReal = 1 + innerGearNum / sunGearNum;//实际传动比
            double rationGap = System.Math.Abs(ratioReal - ration) / ratioReal*100;
            string gap = rationGap.ToString() + "%";
            this.txtRatioGap.Text = gap;//输出减速比误差
            //判断同心条件
            if (innerGearNum + sunGearNum == innerGearNum - plantGearNum)
            {
                this.txtConcidence.Text = "满足条件";
            }
            else
            {
                this.txtConcidence.Text = "不满足条件";
            }
            //判断邻接条件////
            double v00 = sunGearNum * System.Math.Sin(System.Math.PI / plantneryNum) - 2;
            double v01 = 1 - System.Math.Sin(System.Math.PI / plantneryNum);
            double v0 = v00 / v01;
            double v1 = (plantGearNum + 2) / (sunGearNum + plantGearNum);
            double v2 = System.Math.Asin(v1);
            if (plantneryNum < v2||plantGearNum<v0)
            {
                this.txtByMatch.Text = "满足条件";
            }
            else
            {
                this.txtByMatch.Text = "不满足条件";
            }
            //判断装配条件(是否为整数)
            if (!Common.DataValidate.IsInteger(((sunGearNum+innerGearNum)/plantneryNum).ToString()))
            {
                this.txtMatch.Text = "不满足条件";
            }
            else
            {
                this.txtMatch.Text = "满足条件";
            }
        }
    }
}
