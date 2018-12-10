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
    public partial class FrmSix : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="m">模数</param>
        /// <param name="da">a的分度圆</param>
        /// <param name="dc">c的分度圆</param>
        /// <param name="db">b的分度圆</param>
        public FrmSix(double m, double da, double dc, double db)
        {
            InitializeComponent();
            M = m;
            d1 = da;
            d2 = dc;
            d3 = db;
            ka = Common.PassValues.KA;
            P = Common.PassValues.inputPower;//
            n = Common.PassValues.inputRevolo;
            za = Convert.ToInt32(Common.PassValues.za);
            zb = Convert.ToInt32(Common.PassValues.zb);
            zc = Convert.ToInt32(Common.PassValues.zc);
            alpac = Common.PassValues.αac;
            alpcb = Common.PassValues.αcb;
            materialA = Common.PassValues.MaterialVala;
            materialC = Common.PassValues.MaterialValc;
            materialB = Common.PassValues.MaterialValb;
            CaculateContactVal();
            CaculateBendVal();
        }
        public event GetValue6 OperateGetValue6;//定义事件
        #region 定义全局变量
        private double ka;
        private double d1;
        private double d2;
        private double d3;
        private double P;
        private double n;
        private double M;
        private int za;
        private int zb;
        private int zc;
        private double alpac;
        private double alpcb;
        private string materialA;
        private string materialC;
        private string materialB;
        private double Ft;
        double Kfβ ;
        double Kfα ;
        double Kv;
        #endregion
        /// <summary>
        /// 校核接触应力
        /// </summary>
        private void CaculateContactVal()
        {
            Regex regNum = new Regex("^[0-9]");
            //计算接触应力的基本值
            //1.计算节点区域系数(直齿轮传动)
            double Zh = Math.Round(Math.Sqrt(2 * Math.Cos(alpac / 180 * Math.PI) / (Math.Cos(Math.PI / 9.0) * Math.Cos(Math.PI / 9.0) * Math.Sin(alpac / 180 * Math.PI))), 3);
            //2.计算弹性系数Ze
            double ZE = 0.0;
            double Khβ = 0.0;
            double Khβcb = 0.0;
            double Khα = 0.0;
            if (regNum.IsMatch(materialA) && regNum.IsMatch(materialC))
            {
                ZE = 189.8;
            }
            else if (regNum.IsMatch(materialA) && materialC.Contains("ZG"))
            {
                ZE = 188.9;
            }
            else if (regNum.IsMatch(materialA) && materialC.Contains("QT"))
            {
                ZE = 181.4;
            }
            else if (materialA.Contains("ZG") && materialC.Contains("ZG"))
            {
                ZE = 188.0;
            }
            else if (materialA.Contains("ZG") && materialC.Contains("QT"))
            {
                ZE = 180.5;
            }
            else
            {
                ZE = 173.9;
            }
            //计算重合度系数Zε
            double Zε = Math.Round(Math.Sqrt((4 - Common.PassValues.chdAC) / 3.0), 2);
            double Zεcb = Math.Round(Math.Sqrt((4 - Common.PassValues.chdCB) / 3.0), 2);
            //计算螺旋角系数Zβ
            double Zβ = 1.0;//直齿轮传动
            //计算Ft
            double T = 9549 * P / n;
            Ft =Math.Round( 2000 * T / d1);//单位为牛顿（N）
            double u = zc / za;
            double Ucb=zb/zc;
            //计算接触应力的基本值
            double Fh0 =Math.Round( Zh * Zε * Zβ * ZE * Math.Sqrt(Ft * (u + 1) / (d1 * u * 0.7 * M * za)));

            double Fhcb = Math.Round(Zh * Zεcb * Zβ * ZE * Math.Sqrt(Ft * (Ucb - 1) / (d1 * Ucb * 0.7 * M * za)));
            //计算Kv值
            string jd = Common.PassValues.Acurcy;//精度等级7-7-7
            double jda = Convert.ToDouble(jd.Substring(0, 1));//太阳轮的精度等级
            double jdc = Convert.ToDouble(jd.Substring(2, 1));
            double jdb = Convert.ToDouble(jd.Substring(4, 1));
            double B = 0.25 * Math.Pow((jda - 5.0), 0.667);
            double A = 50 + 56 * (1.0 - B);
            double nx = n / (1 + zb / za);
            double vx = d1 * (n - nx) / 19100;
            Kv =Math.Round( Math.Pow(A / (A + Math.Sqrt(200 * vx)), -B),2);
            //计算齿向载荷分布系数Khβ Kfβ和计算Khα Kfα
            double N =Math.Round( (0.7 * d1 / 2.25 / M) * (0.7 * d1 / 2.25 / M) / (1 + (0.7 * d1 / 2.25 / M) + (0.7 * d1 / 2.25 / M) * (0.7 * d1 / 2.25 / M)));
            if (jda == 6)
            {
                Khβ =Math.Round( 1.11 + 0.18 * 0.7 * 0.7 + 0.00015 * 0.7 * d1,3);
                Khβcb = Math.Round(1.11 + 0.18 * 0.7 * 0.7 + 0.00015 * 0.7 * d2, 3);
                Khα = 1.0;
                Kfβ =Math.Round(Math.Pow(Khβ,N),3);
                Kfα = Khα;
            }
            else if (jda == 7)
            {
                Khβ = Math.Round( 1.12 + 0.18 * 0.7 * 0.7 + 0.00023 * 0.7 * d1,3);
                Khβcb = Math.Round(1.12 + 0.18 * 0.7 * 0.7 + 0.00023 * 0.7 * d2, 3);
                Khα = 1.1;
                Kfβ = Math.Round(Math.Pow(Khβ, N), 3);
                Kfα = Khα;
            }
            else if (jda == 8)
            {
                Khβ = Math.Round( 1.15 + 0.18 * 0.7 * 0.7 + 0.00031 * 0.7 * d1,3);
                Khβcb = Math.Round(1.15 + 0.18 * 0.7 * 0.7 + 0.00031 * 0.7 * d1, 3);
                Khα = 1.2;
                Kfβ = Math.Round(Math.Pow(Khβ, N), 3);
                Kfα = Khα;
            }
            else
            {
                Khβ = Math.Round( 1.10 + 0.18 * 0.7 * 0.7 + 0.0002 * 0.7 * d1,3);
                Khβcb = Math.Round(1.10 + 0.18 * 0.7 * 0.7 + 0.0002 * 0.7 * d1, 3);
                Khα = 1.2;
                Kfβ = Math.Round(Math.Pow(Khβ, N), 3);
                Kfα = Khα;
            }
            double Khp = Common.PassValues.loadXishu;//载荷分配不均匀系数
            double Fh1 = Math.Round(Fh0 * Math.Sqrt(ka * Kv * Khβ * Khα * Khp), 3);//a-c接触疲劳强度
            double Fh2 = Math.Round(Fhcb * Math.Sqrt(ka * Kv * Khβcb * Khα * Khp), 3);//c-b接触疲劳强度

            //分别计算两轮的许用接触应力大小
            double Fhalim = Common.PassValues.ContactValue1;//太阳轮接触疲劳极限
            double Fhclim = Common.PassValues.ContactValue2;//
            double Fhblim = Common.PassValues.ContactValue3;//
            double Smin = 1.1;
            double xya = Math.Round(Fhalim / Smin * 1.335);//a轮许用接触应力
            double xyc = Math.Round(Fhclim / Smin * 1.353);//c轮许用接触应力
            double xyb = Math.Round(Fhblim / Smin * 1.331);//c轮许用接触应力
            if (Fh1 < xya && Fh1 < xyc)
            {
                this.txtAnswer1.Text = "满足接触疲劳强度条件！";
            }
            else
            {
                this.txtAnswer1.Text = "不满足接触疲劳强度条件！";
            }
            //把值显示到界面上
            this.txtFt.Text = Ft.ToString();
            this.txtu.Text = u.ToString();
            this.txtkv.Text = Kv.ToString();
            this.txtka.Text = ka.ToString();
            this.txtkhα.Text = Khα.ToString();
            this.txtkhβ.Text = Khβ.ToString();
            this.txtZe.Text = ZE.ToString();
            this.txtZh.Text = Zh.ToString();
            this.txtZβ.Text = Zβ.ToString();
            this.txtZε.Text = Zε.ToString();
            this.txtFac.Text = Fh1.ToString();
            this.txtSmin.Text = Smin.ToString();
            this.txtXYa.Text = xya.ToString();
            this.txtXYc.Text = xyc.ToString();
            this.txtaLim.Text = Fhalim.ToString();
            this.txtcLim.Text = Fhclim.ToString();
           
            if (Fh2 < xyb && Fh2 < xyc)
            {
                this.txtAnswer3.Text = "满足接触疲劳强度条件！";
            }
            else
            {
                this.txtAnswer3.Text = "不满足接触疲劳强度条件！";
            }

            this.txtFtcb.Text = Ft.ToString();
        
            this.txtUcb.Text = Ucb.ToString();
            this.txtKvcb.Text = Kv.ToString();
            this.txtkacb.Text = ka.ToString();
            this.txtKhαcb.Text = Khα.ToString();
            this.txtKhβcb.Text = Khβcb.ToString();

            this.txtZecb.Text = ZE.ToString();
            this.txtZhcb.Text = Zh.ToString();
            this.txtZβcb.Text = Zβ.ToString();
            this.txtZεcb.Text = Zεcb.ToString();

            this.txtFcb.Text = Fh2.ToString();
            this.txtSmincb.Text = Smin.ToString();
            this.txtXYccb.Text = xyc.ToString();
            this.txtXYbcb.Text = xyb.ToString();
            this.txtBlimcb.Text = Fhblim.ToString();
            this.txtClimcb.Text = Fhclim.ToString();
        }
        /// <summary>
        /// 校核弯曲应力
        /// </summary>
        private void CaculateBendVal()
        {
            Regex regNum = new Regex("^[0-9]");
            //计算基本值
            //计算Yfa1,Yfa2
            double Yfa1 = 0;
            double Yfa2 = 0;
            double Ysa1 = 0;
            double Ysa2 = 0;
            double xa=Common.PassValues.Xa;
            if (xa > 0 && xa < 0.2 && za < 20)
            {
                Yfa1 = 2.655;
                Yfa2 = 2.624;
            }
            else if (xa > 0.19 && xa < 0.41 && za < 20)
            {
                Yfa1 = 2.453;
                Yfa2 = 2.525;
            }
            else if (xa > 0.4 && xa < 0.61 && za < 20)
            {
                Yfa1 = 2.263;
                Yfa2 = 2.235;
            }
            else if (xa > 0.6 && xa < 0.9 && za < 20)
            {
                Yfa1 = 2.055;
                Yfa2 = 2.105;
            }
            else if (xa > 0.5 && xa < 0.8 && za > 20 && za < 30)
            {
                Yfa1 = 2.153;
                Yfa2 = 2.128;
            }
            else
            {
                Yfa1 = 2.053;
                Yfa2 = 1.828;
            }
            //计算Ysa1,Ysa2
            if (xa > 0 && xa < 0.2 && za < 20)
            {
                Ysa1 = 1.615;
                Ysa2 = 1.624;
            }
            else if (xa > 0.19 && xa < 0.51 && za < 20)
            {
                Ysa1 = 1.723;
                Ysa2 = 1.725;
            }
            else if (xa > 0.5 && xa < 0.81 && za < 20)
            {
                Ysa1 = 1.813;
                Ysa2 = 1.785;
            }
            else if (xa > 0.8 && xa < 1.2 && za < 20)
            {
                Ysa1 = 1.865;
                Ysa2 = 1.835;
            }
            else if (xa > 0.5 && xa < 0.8 && za > 20 && za < 30)
            {
                Ysa1 = 1.853;
                Ysa2 = 1.828;
            }
            else
            {
                Ysa1 = 1.653;
                Ysa2 = 1.528;
            }
            //计算Yε
            double Yε1 =Math.Round( 0.25 + (0.75 / Common.PassValues.chdAC),2);
            double Yε2 =Math.Round( 0.25 + (0.75 / Common.PassValues.chdCB),2);
            //计算Yβ1，Yβ2
            double Yβ1 = 1.0;
            double Yβ2 = 1.0;
            //计算基本值
            double F01 = Ft / 0.7 / d1 / M * Ysa1 * Yfa1 * Yε1 * Yβ1;
            double F02 = Ft / 0.7 / d1 / M * Ysa2 * Yfa2 * Yε2 * Yβ2;
            //计算弯曲应力
            double Kfp=Common.PassValues.loadXishu;
            double Fa = F01 * ka * Kv * Kfα * Kfβ * Kfp;//太阳轮弯曲应力
            double Fc = F02 * ka * Kv * Kfα * Kfβ * Kfp;//行星轮弯曲应力
            //计算许用弯曲应力
            double Yst = 2.0;
            double Ynt = 1.0;
            double Yrelt = 1.0;
            double Yrelr = 1.065;
            double Yx = 0.0;
            if (regNum.IsMatch(materialA) && regNum.IsMatch(materialC))
            {
                Yx =Math.Round(1.03-0.006*M,2);
            }
            else if (regNum.IsMatch(materialA) && materialC.Contains("ZG"))
            {
                Yx = Math.Round(1.05 - 0.01 * M, 2);
            }
            else if (regNum.IsMatch(materialA) && materialC.Contains("QT"))
            {
                Yx = Math.Round(1.05 - 0.01 * M, 2);
            }
            else if (materialA.Contains("ZG") && materialC.Contains("ZG"))
            {
                Yx = Math.Round(1.075 - 0.015 * M, 2);
            }
            else if (materialA.Contains("ZG") && materialC.Contains("QT"))
            {
                Yx = Math.Round(1.075 - 0.015 * M, 2);
            }
            else
            {
                Yx = Math.Round(1.03 - 0.006 * M, 2);
            }
            double Flima = Common.PassValues.BendValue1;
            double Flimc = Common.PassValues.BendValue2;
            double Flim1 =Math.Round( Flima * Yst * Ynt * Yrelr * Yrelt * Yx / 1.5);//太阳轮许用弯曲应力
            double Flim2 =Math.Round( Flimc * Yst * Ynt * Yrelr * Yrelt * Yx / 1.5);
            if (Fa < Flim1 && Fc < Flim2)
            {
                this.txtAnswer2.Text = "满足弯曲疲劳强度条件！";
            }
            else
            {
                this.txtAnswer2.Text = "不满足弯曲疲劳强度条件！";
            }
            //把数值显示到界面上
            this.txtkfp.Text = Kfp.ToString();
            this.txtKfα.Text = Kfα.ToString();
            this.txtkfβ.Text = Kfβ.ToString();
            this.txtSfmin.Text = "1.5";
            this.txtYε.Text = Yε1.ToString();
            this.txtYβ.Text = Yβ1.ToString();
            this.txtYst.Text = Yst.ToString();
            this.txtYsα.Text = Ysa1.ToString();
            this.txtYx.Text = Yx.ToString();//尺寸系数
            this.txtFbendA.Text =Math.Round( Fa,2).ToString();
            this.txtFbendC.Text = Math.Round( Fc,2).ToString();
            this.txtYfα.Text = Yfa1.ToString();
            this.txtxyBengA.Text = Flim1.ToString();//太阳轮许用弯曲应力
            this.txtxyBengC.Text = Flim2.ToString();
            this.txtBendLima.Text = Flima.ToString();
            this.txtBendLimc.Text = Flimc.ToString();
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            double v1 = Convert.ToDouble(this.txtFac.Text);
            double v2 = Convert.ToDouble(this.txtXYa.Text);
            double v3 = Convert.ToDouble(this.txtFbendA.Text);
            double v4 = Convert.ToDouble(this.txtFbendC.Text);
            double v5 = Convert.ToDouble(txtxyBengA.Text);
            double v6 = Convert.ToDouble(txtxyBengC.Text);
            Common.PassValues.contactA = v1;
            Common.PassValues.contactXY = v2;
            Common.PassValues.aBendVal = v3;
            Common.PassValues.cBendVal = v4;
            Common.PassValues.xyBenda = v5;
            Common.PassValues.xyBendc = v6;
            //引发事件
            OperateGetValue6(v1, v2, v3, v4, v5, v6);
            this.Hide();
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrim6_Click(object sender, EventArgs e)
        {
            FrmDesign objDesign = new FrmDesign();
            this.Close();
            objDesign.btnCaculGeometry_Click(null, new EventArgs());
        }


    }
}
