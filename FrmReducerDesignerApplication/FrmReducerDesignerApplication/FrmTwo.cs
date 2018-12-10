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
    //定义委托(接收窗体1传过来的数据)
    public delegate void GetFrm1Value(double inputPower, double reRation, double inputRevolo, double efficent, double outpTorque, double outpRevolo, double inpuTorque, double Ka);


    public partial class FrmTwo : Form
    {
        /// <summary>
        /// [2]定义一个事件
        /// </summary>
        public event GetValue2 OperateGetValue2;
        //public event GetValue3 PassDatas;
        /// <summary>
        /// 构造函数（初始化）
        /// </summary>
        public FrmTwo()
        {
            InitializeComponent();

        }


        /// <summary>
        /// 构造函数实现不同窗体间的传参
        /// </summary>
        /// <param name="inputPower"></param>
        /// <param name="reRation"></param>
        /// <param name="inputRevolo"></param>
        /// <param name="efficent"></param>
        /// <param name="outpTorque"></param>
        /// <param name="outpRevolo"></param>
        /// <param name="inpuTorque"></param>
        /// <param name="Ka"></param>
        public FrmTwo(double inputPower, double reRation, double inputRevolo, double efficent, double outpTorque, double outpRevolo, double inpuTorque, double Ka, double loadXishu)
        {
            inPower = inputPower;//输入功率
            ration = reRation;//减速比
            inRevo = inputRevolo;
            effic = efficent;
            outTor = outpTorque;
            outRevo = System.Math.Round(outpRevolo, 2);
            inTor = inpuTorque;
            ka = Ka;
            loadScale = loadXishu;
            InitializeComponent();
            this.txtMYRatio.Text = ration.ToString();//名义速比显示在界面上
            //调用配齿方法初步计算并显示到界面上
            MatchGear();
        }
        double inPower, ration, inRevo, effic, outTor, outRevo, inTor, ka, loadScale;//定义变量接收窗体1传过来的值(输入功率、速比、转速、效率、输出扭矩、输出转速、输入扭矩,ka,不均匀系数)
        
        //public static FrmOne objOne ;
        private void btnPrimStep_Click(object sender, EventArgs e)//上一步
        {
            FrmDesign obj = new FrmDesign();
            this.Close();//隐藏当前窗体
            //this.Dispose();//无法访问已释放的对象
            obj.btnModifyPara_Click(null, new EventArgs());
            //Timer fa = new Timer();
            //fa.Stop();
        
        }

        //public static FrmThree objThree = null;
        private void btnNextStep_Click(object sender, EventArgs e)//下一步
        {
            FrmDesign objD = new FrmDesign();
            this.Visible = false;//隐藏当前窗体
            //调用确定按钮事件===
            this.btnCaculate_Click(null, new EventArgs());//实现传值、

            //调用主窗体按钮事件启动窗体3
            objD.btnMaterialSelect_Click(null, e);

            //string s1 = Common.PassValues.sunMaterial;
            //string s2 = Common.PassValues.planMaterial;
            //string s3 = Common.PassValues.innMaterial;
            //PassDatas(s1, s2, s3);
        }
        #region //验证输入数据方法
        private void VerifyData()
        {
            if (this.txtPlantnearyNum.Text.Trim().Length == 0)
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
            if (this.txtSunGearNum.Text.Trim().Length == 0)
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
            if (this.txtInnerGearNum.Text.Trim().Length == 0)
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
            if (this.txtPlantGearNum.Text.Trim().Length == 0)
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
        int plantneryNum, sunGearNum, plantGearNum, innerGearNum;

        private void CaculateGearNum()
        {
            VerifyData();
            //获取界面输入值
            plantneryNum = Convert.ToInt32(this.txtPlantnearyNum.Text.Trim());//行星轮数目值
            sunGearNum = Convert.ToInt32(this.txtSunGearNum.Text.Trim());//太阳轮齿数
            plantGearNum = Convert.ToInt32(this.txtPlantGearNum.Text.Trim());//行星轮齿数
            innerGearNum = Convert.ToInt32(this.txtInnerGearNum.Text.Trim());//内齿轮齿数
            //由传动比大小计算特性参数P值
            double P = ration - 1;    //ration为名义减速比（窗体1传过来的）               
            //初选太阳轮齿数za------------------------------------------=================================------------------=
            //sunGearNum = 18;
            //计算内齿轮齿数
            innerGearNum = Convert.ToInt32(P * sunGearNum);
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


        double m = 0.0;//模数大小
        double[] scale = new double[]
        {
          1,1.125,1.25,1.375,1.5,1.75,2,2.25,2.5,2.75,3,3.5,4,4.5,5,5.5,6,6.5,7,9,10,11,12,14,16,18,20
          ,22,25,28,32,35,40,45,50
        };//模数数组

        private void MatchGear()//配齿计算方法
        {
            //[1]计算内齿轮直径d
            double x = ka * outTor * 0.99 * (ration - 1) * (ration - 1) / ((ration - 2) * 0.24);
            double d = 5 * System.Math.Pow(x, 1.0 / 3.0);//参考文献，曹艳丽（3-11公式）、伍琼仙

            //[2]计算中心距
            double a = 0.25 * ration * d / (ration - 1);
            //[3]初算模数（遍历标准模数并选择合适值）            
            double mmax = 0.31 * (ration - 1) * a / (ration * ration);
            double mmin = 0.25 * (ration - 1) * a / (ration * ration);

            for (int i = 0; i < scale.Length; i++)
            {
                if (scale[i] > mmin && scale[i] < mmax)
                {
                    m = scale[i];
                    if (scale[i + 1] > mmin && scale[i + 1] < mmax)
                    {
                        m = scale[i + 1];
                        break;//跳出循环====
                    }
                    break;//跳出循环====
                }

            }
            //[4]初算内齿轮齿数
            double inGearNun = System.Math.Round(d / m);
            //[5]计算太阳轮齿数
            double sunGearNum = System.Math.Round(inGearNun / (ration - 1));
            //[6]计算行星轮齿数（满足同心条件）
            double planteNum = System.Math.Round((inGearNun - sunGearNum) / 2.0);
            //[7]计算中心距
            double aa = 0.5 * m * (sunGearNum + planteNum);
            //innerGearNums = inGearNun;
            SatisfyConditon(inGearNun, sunGearNum, planteNum);
            this.rdoOutInnMod.Checked = true;//不变位radiobutton激活

        }
        double innerGearNums;



        //判断满足的条件4个
        double ratioReal;//实际传动比
        private void SatisfyConditon(double zb, double za, double zg)
        {
            //判断同心条件-------------
            if (zg + za == zb - zg)
            {
                this.txtConcidence.Text = "满足";
                this.txtConcidence.ForeColor = Color.Black;
            }
            else
            {
                this.txtConcidence.Text = "变位后满足";
                this.txtConcidence.ForeColor = Color.Red;//设置字体颜色为红色
            }
            //判断邻接条件////
            double v00 = za * System.Math.Sin(System.Math.PI / 3.0) - 2;
            double v01 = 1 - System.Math.Sin(System.Math.PI / 3.0);
            double v0 = v00 / v01;
            if (zg < v0)
            {
                this.txtByMatch.Text = "满足";
            }
            else
            {
                this.txtByMatch.Text = "不满足";
                this.txtByMatch.ForeColor = Color.Red;//设置字体颜色为红色
            }
            //判断装配条件(是否为整数)
            //if (Common.DataValidate.IsInteger(((za + zb) / 3).ToString()))
            //{
            //    this.txtMatch.Text = "不满足";
            //}
            //else
            //{
            //    this.txtMatch.Text = "满足";
            //}
            double Zb = AssemblyMatch(za, zb);
            //判断传动比条件（传动比误差计算，实际传动比计算）
            ratioReal = 1 + (Zb / za);//实际传动比
            double rationGap = (System.Math.Abs(ratioReal - ration) / ratioReal) * 100;
            string gap = System.Math.Round(rationGap, 3).ToString() + "%";
            this.txtRatioGap.Text = gap;//输出减速比误差
            this.txtRealRatio.Text = ratioReal.ToString();//实际传动比
            this.txtInnerGearNum.Text = Zb.ToString();
            this.txtPlantGearNum.Text = zg.ToString();
            this.txtSunGearNum.Text = za.ToString();
        }
        //不变位按钮
        private void rdoNoMod_CheckedChanged(object sender, EventArgs e)
        {
            //调用满足条件方法判断是否满足？
            double za = Convert.ToDouble(this.txtSunGearNum.Text.Trim());
            double zb = Convert.ToDouble(this.txtInnerGearNum.Text.Trim());
            double zc = (zb - za) / 2.0;
            this.txtPlantGearNum.Text = zc.ToString();
            //this.txtInnerGearNum.Text = innerGearNums.ToString();
        
            //double[] gearnum = new double[3];
            //gearnum = traveMatch(za, zb, zc);
            this.txtac.Text = "20.000";
            this.txtcb.Text = "20.000";
            //判断是否符合同心条件
            if((za+zc)==(zb-zc))
            {
                this.txtConcidence.Text = "满足";
                this.txtConcidence.ForeColor = Color.Black;
            }
            if (Common.DataValidate.IsInteger(((za + zb) / 3).ToString()) == true)
            {
                this.txtMatch.Text = "满足";
            }
            //SatisfyConditon(gearnum[1], gearnum[0], gearnum[2]);
            double j = (zb - zc) / (za + zc);
            this.txtj.Text = Math.Round(j, 3).ToString();//显示在界面上
            Common.PassValues.shift = 1;
        }
        /// <summary>
        /// 递归方法判断是否满足同心条件
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        private double[] traveMatch(double a, double b, double c)
        {
            double[] gearNum = new double[] { a, b, c };
            if (a + c > b - c)
            {
                a = a - 1;
            }
            else if (a + c < b - c)
            {
                a = a + 1;
            }
            else return gearNum;
            traveMatch(a, b, c);
            gearNum[0] = a;
            gearNum[1] = b;
            gearNum[2] = c;
            return gearNum;
        }
        /// <summary>
        /// 满足装配条件的方法
        /// </summary>
        /// <param name="za"></param>
        /// <param name="zb"></param>
        /// <returns></returns>
        private double  AssemblyMatch(double za, double zb)
        {
            if (Common.DataValidate.IsInteger(((za + zb) / 3).ToString()) == false)//如果不满足
            {
                //与行星轮齿数无关，只需调整za,zb即可
                for (int i = 5; i < zb; i--)
                {
                    --zb;
                    if (Common.DataValidate.IsInteger(((za + zb) / 3).ToString()) == true)
                    {
                        break;
                    }
                }
            }
            else
            {
                this.txtMatch.Text = "满足";
            }
            this.txtMatch.Text = "满足";
            return zb;
        }

        //高度变位
        private void rdoHighMod_CheckedChanged(object sender, EventArgs e)
        {
            //中心距保持不变、变位防止根切
            //调用满足条件方法判断是否满足？
            double za = Convert.ToDouble(this.txtSunGearNum.Text.Trim());
            double zb = Convert.ToDouble(this.txtInnerGearNum.Text.Trim());
            double zc = (zb - za) / 2.0;
            this.txtPlantGearNum.Text = zc.ToString();
        
            this.txtac.Text = "20.000";
            this.txtcb.Text = "20.000";
            //判断是否符合同心条件
            if ((za + zc) == (zb - zc))
            {
                this.txtConcidence.Text = "满足";
                this.txtConcidence.ForeColor = Color.Black;
            }
            if (Common.DataValidate.IsInteger(((za + zb) / 3).ToString()) == true)
            {
                this.txtMatch.Text = "满足";
            }
            double j = (zb - zc) / (za + zc);
            this.txtj.Text = Math.Round(j, 3).ToString();//显示在界面上
            
            Common.PassValues.shift = 2;

        }
        //等角度变位
        private void rdoAngleMod_CheckedChanged(object sender, EventArgs e)
        {
            //double L = 0.0;
            
            //计算中心距
            double za = Convert.ToDouble(this.txtSunGearNum.Text.Trim());
            double zb = Convert.ToDouble(this.txtInnerGearNum.Text.Trim());
            double zc =Convert.ToDouble( this.txtPlantGearNum.Text);
         
            double Lac = 0.5 * m * (za + zc);//a、c中心距
            double Lbc = 0.5 * m * (zb - zc);//b、c中心距
            if (Lac > Lbc)
            {
                L = System.Math.Round(Lac);
            }
            else
            {
                L = Math.Round(Lbc);
            }
            //计算啮合角并显示在界面上

            double cosac = (0.5 * m * (za + zc) * Math.Cos(Math.PI / 9.0)) / Lac;
            double cosbc = (0.5 * m * (zb - zc) * Math.Cos(Math.PI / 9.0)) / Lbc;

            //计算啮合角大小
            double Aac = Math.Acos(cosac)*180/Math.PI;
            double Abc = Math.Acos(cosbc)*180/Math.PI;
            double lef = (za + zc) / cosac;
            double rig = (zb - zc) / cosbc;
            if (lef == rig)
            {
                this.txtConcidence.Text = "满足";
                 this.txtConcidence.ForeColor = Color.Black;
            }
            else
            {
                this.txtConcidence.Text = "不满足";
                this.txtConcidence.ForeColor = Color.Red;//设置字体颜色为红色
            }
            this.txtac.Text =Math.Round( Aac,3).ToString();
            this.txtcb.Text = Math.Round(Aac, 3).ToString();
            Common.PassValues.shift = 3;
        }

        double L ;//变位齿轮实际中心距
        //内啮合高变位、外啮合角变位
        private void rdoOutInnMod_CheckedChanged(object sender, EventArgs e)
        {

            double zc = 0.0;
            //计算中心距
            double za = Convert.ToDouble(this.txtSunGearNum.Text.Trim());
            double zb = Convert.ToDouble(this.txtInnerGearNum.Text.Trim());
            if ((zb - za) % 2 == 0)
            {
                zc = (zb - za) / 2 - 1;//行星齿轮               
            }
            else
            {
                zc = (zb - za) / 2;
            }
            this.txtPlantGearNum.Text = zc.ToString();
            double Lac = 0.5 * m * (za + zc);//a、c中心距
            double Lbc = 0.5 * m * (zb - zc);//b、c中心距
            if (Lac < Lbc)
            {
                L = System.Math.Round(Lac);//取大者为实际中心距
            }
            else
            {
                this.txtConcidence.Text = "不满足";
                this.txtConcidence.ForeColor = Color.Red;//设置字体颜色为红色
            }
            //计算啮合角并显示在界面上

            double cosac = Lac / L * Math.Cos(Math.PI / 9.0);
            double cosbc =  Math.Cos(Math.PI / 9.0);
            double v1 = cosac / cosbc;
            double v2 = (za + zc) / (zb - zc);


            //计算啮合角大小
            double Aac = Math.Acos(cosac)*180/Math.PI ;
            double Abc = Math.Acos(cosbc) * 180 / Math.PI;

            double lef = (za + zc) / cosac;
            double rig = (zb - zc) / cosbc;
          
            double j = (zb - zc) / (za + zc);
            this.txtj.Text = Math.Round(j, 3).ToString();//显示在界面上
            this.txtac.Text = Math.Round(Aac, 3).ToString();
            this.txtcb.Text = Math.Round(Abc, 3).ToString();
            this.txtConcidence.Text = "满足";
            this.txtConcidence.ForeColor = Color.Black;
            Common.PassValues.shift = 5;
        }

        private void rdoSPur_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoSPur.Checked == true)
            {
                this.txtHelixAngle.Enabled = false;//禁用textbox
            }
            this.txtHelixAngle.Text =" 0";
        }
        //不等啮合角变位
        private void rdoNoEqualAngle_CheckedChanged(object sender, EventArgs e)
        {
            Common.PassValues.shift = 4;
        }

        private void btnCaculate_Click(object sender, EventArgs e)
        {

            //获取界面显示的相关值
            int plantaryNum = Convert.ToInt32(this.txtPlantnearyNum.Text.Trim());//行星轮数
            double za = Convert.ToDouble(this.txtSunGearNum.Text);//太阳轮齿数
            double zb = Convert.ToDouble(this.txtInnerGearNum.Text);
            double zc = Convert.ToDouble(this.txtPlantGearNum.Text);
            double reRation = Convert.ToDouble(this.txtRealRatio.Text);//实际减速比
            string rationGap = this.txtRatioGap.Text.Trim();//减速比误差
            //实际输出转速和实际输出扭矩（计算）
            double outRevoReal = System.Math.Round(inRevo / reRation, 2);//实际输出转速
            double outTorReal = System.Math.Round(9549 * inPower / outRevoReal, 2);//实际输出扭矩
            //[3]激发事件
            Common.PassValues.plantaryNum = plantaryNum;
            Common.PassValues.za = za;
            Common.PassValues.zb = zb;
            Common.PassValues.zc = zc;
            Common.PassValues.reRation = reRation;
            Common.PassValues.rationGap = rationGap;
            Common.PassValues.outRevoReal = outRevoReal;
            Common.PassValues.outTorReal = outTorReal;
            Common.PassValues.LReal = L;//实际中心距
            OperateGetValue2(plantaryNum, za, zb, zc, reRation, rationGap, outTorReal, outRevoReal);

            this.Hide();

        }
      

    }
}
