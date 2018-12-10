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
    public partial class FrmFour : Form
    {
        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="ka"></param>
        /// <param name="inputTor"></param>
        /// <param name="kp"></param>
        /// <param name="za"></param>
        /// <param name="zc"></param>
        /// <param name="zb"></param>
        public FrmFour(double ka, double inputTor, double kp, int za, int zc, int zb)
        {
            InitializeComponent();//？？？？？？？完成窗体初始化
            this.cboRealM.DataSource = scale;
            EstimateValue(ka, inputTor, kp, za, zc, zb);
            //绑定模数下拉框

        }
        /// <summary>
        /// 【2】定义事件传值
        /// </summary>
        public event GetValue4 OperateGetValue4;

        #region 全局变量
        double faid = 0.6;//齿宽系数
        double T1;
        double M = 0.0;//模数大小
        double Xa;//中心论a的变位系数
        double Xc;//齿轮C的变位系数
        double Xb;
        #endregion
        double[] scale = new double[]
        {
         0.5,0.6,0.7,0.8,0.9, 1.0,1.125,1.25,1.375,1.5,1.75,2,2.25,2.5,2.75,3,3.5,4,4.5,5,5.5,6,6.5,7,9,10,11,12,14,16,18,20
          ,22,25,28,32,35,40,45,50
        };//模数数组


        private void btnFourNext_Click(object sender, EventArgs e)
        {
            FrmDesign objDesign = new FrmDesign();
            this.Visible = false;//隐藏当前窗体
            this.btnCalculateFour_Click(null, e);//调用确定按钮
            objDesign.btnCaculGeometry_Click(null, new EventArgs());//调用主窗体打开窗体4

        }
        /// <summary>
        /// 初算参数
        /// </summary>
        /// <param name="ka"></param>
        /// <param name="inputTor"></param>
        /// <param name="kp"></param>
        /// <param name="za"></param>
        /// <param name="zc"></param>
        /// <param name="zb"></param>
        private void EstimateValue(double ka, double inputTor, double kp, int za, int zc, int zb)
        {
            double mless = CalculataScale(ka, inputTor, kp, za);//模数计算
            if (Common.PassValues.shift == 1)
            {
                StandardTransmi(ka, inputTor, kp, za, zc, zb, mless);//标准齿轮传动
                return;
            }
            if (Common.PassValues.shift == 2)
            {
                HightShiftTransmi(ka, inputTor, kp, za, zc, mless);//高度变位传动
                return;
            }
            if (Common.PassValues.shift == 3)
            {
                return;
            }
            if (Common.PassValues.shift == 4)
            {
                return;
            }
            if (Common.PassValues.shift == 5)
            {
                InOutShift(ka, inputTor, kp, za, zc, zb, mless);//外啮合角度变位，内啮合高度变位
                return;
            }
            //啮合参数计算

        }
        /// <summary>
        /// 标准传动参数计算
        /// </summary>
        /// <param name="ka">使用系数</param>
        /// <param name="inputTor">输入扭矩</param>
        /// <param name="kp">载荷系数</param>
        /// <param name="za">太阳轮数</param>
        /// <param name="zc">行星轮数</param>
        /// <param name="zb">内齿轮数</param>
        /// <param name="mLess">最小模数</param>
        private void StandardTransmi(double ka, double inputTor, double kp, int za, int zc, int zb, double mLess)
        {
            double mless = CalculataScale(ka, inputTor, kp, za);//模数计算
            //参数计算太阳轮
            double a = 0.5 * M * (za + zc);//标准传动实际中心距
            double D = M * za;//太阳轮分度圆直径

            double Ba = faid * M * za;//小齿轮齿宽
            //参数计算行星轮
            double D2 = M * zc;//行星轮分度圆直径

            //内齿轮参数计算
            double D3 = M * (za + zc + zc);

            //计算许用接触应力值
            double ContactFLim = Common.PassValues.ContactValue2;
            double XYContactF = Math.Round(0.09081 * ContactFLim);//许用接触应力值
            double chishubi = Convert.ToDouble(zc) / Convert.ToDouble(za);//齿数比
            double aLess = 0.5 * mLess * (za + zc);//中心距不少于此值

            //显示到界面
            this.txtKc.Text = kp.ToString();//载荷不均匀系数
            this.txtInputTor.Text = inputTor.ToString();//总体输入扭矩
            this.txtPlantaryNum.Text = Common.PassValues.plantaryNum.ToString();
            this.txtTorAC.Text = Math.Round(T1, 3).ToString();//单对传动扭矩
            this.txtK.Text = ka.ToString();//综合载荷系数
            this.txtContactVal.Text = Common.PassValues.ContactValue2.ToString();//接触疲劳极限
            this.txtφc.Text = faid.ToString();//齿宽系数
            this.txtContactXY.Text = XYContactF.ToString();//许用接触应力
            this.txtU.Text = chishubi.ToString();//齿数比
            this.txtDisLess.Text = aLess.ToString();//中心距不小于
            this.txtMLess.Text = mless.ToString();//最小模数

            this.cboRealM.Text = M.ToString();//实际模数????
            this.txtDisReal.Text = a.ToString();//实际中心距
            this.txtDistNone.Text = a.ToString();//未变位中心距
            this.txtRealβ.Text = "0.00";//实际螺旋角
            this.txtAngleAc.Text = "20.00";//a-c端面啮合角
            this.txtAngleBc.Text = "20.00";//b-c端面啮合角.
            Common.PassValues.Xa = 0.00;
            Common.PassValues.Xb = 0.00;
            Common.PassValues.Xc = 0.00;
            Common.PassValues.αac = 20.00;
            Common.PassValues.αcb = 20.00;
            Common.PassValues.anone = a;
            this.txtK.Focus();//设置控件焦点
        }
        //高度变位传动
        private void HightShiftTransmi(double ka, double inputTor, double kp, int za, int zc, double mLess)
        {
            double mless = CalculataScale(ka, inputTor, kp, za);//模数计算
            //参数计算太阳轮
            double a = 0.5 * M * (za + zc);//标准传动实际中心距
            double D = M * za;//太阳轮分度圆直径
            double Ba = faid * M * za;//小齿轮齿宽
            //参数计算行星轮
            double D2 = M * zc;//行星轮分度圆直径
            //内齿轮参数计算
            double D3 = M * (za + zc + zc);
            //计算许用接触应力值
            double ContactFLim = Common.PassValues.ContactValue2;
            double XYContactF = Math.Round(0.09081 * ContactFLim);//许用接触应力值
            double chishubi = Convert.ToDouble(zc) / Convert.ToDouble(za);//齿数比
            double aLess = 0.5 * mLess * (za + zc);//中心距不少于此值

            //显示到界面
            this.txtKc.Text = kp.ToString();//载荷不均匀系数
            this.txtInputTor.Text = inputTor.ToString();//总体输入扭矩
            this.txtPlantaryNum.Text = Common.PassValues.plantaryNum.ToString();
            this.txtTorAC.Text = Math.Round(T1, 3).ToString();//单对传动扭矩
            this.txtK.Text = ka.ToString();//综合载荷系数
            this.txtContactVal.Text = Common.PassValues.ContactValue2.ToString();//接触疲劳极限
            this.txtφc.Text = faid.ToString();//齿宽系数
            this.txtContactXY.Text = XYContactF.ToString();//许用接触应力
            this.txtU.Text = chishubi.ToString();//齿数比
            this.txtDisLess.Text = aLess.ToString();//中心距不小于
            this.txtMLess.Text = mless.ToString();//最小模数

            this.cboRealM.Text = M.ToString();//实际模数????
            this.txtDisReal.Text = a.ToString();//实际中心距
            this.txtDistNone.Text = a.ToString();//未变位中心距
            this.txtRealβ.Text = "0.00";//实际螺旋角
            this.txtAngleAc.Text = "20.00";//a-c端面啮合角
            this.txtAngleBc.Text = "20.00";//b-c端面啮合角
            Common.PassValues.αac = 20.00;
            Common.PassValues.αcb = 20.00;
            Common.PassValues.anone = a;
            this.txtK.Focus();//设置控件焦点
        }
        //不等角变位传动
        private void NoEqualShift()
        {


        }
        //等角变位
        private void EqualShift()
        {

        }
        /// <summary>
        /// 外啮合角变位，内啮合高度变位
        /// </summary>
        /// <param name="ka"></param>
        /// <param name="inputTor">输入扭矩</param>
        /// <param name="kp">均载系数</param>
        /// <param name="za">太阳轮齿数</param>
        /// <param name="zc">行星轮齿数</param>
        /// <param name="zb">内齿轮齿数</param>
        /// <param name="mLess"></param>
        private void InOutShift(double ka, double inputTor, double kp, int za, int zc, int zb, double mLess)
        {
            double mless = CalculataScale(ka, inputTor, kp, za);//模数计算

            //参数计算太阳轮
            double a = 0.5 * M * (za + zc);//a-c间中心距
            double Acb = 0.5 * M * (zb - zc);//b-c间中心距
            double y = (Acb - a) / M;//中心距变动系数  

            double alp = Math.Acos(a / Acb * Math.Cos(Math.PI / 9.0));//啮合角α'
            double v1 = Math.Tan(alp) - alp;//invα'
            double v2 = Math.Tan(Math.PI / 9.0) - Math.PI / 9.0;//invα
            double Xac = (za + zc) * (v1 - v2) / 2 / Math.Tan(Math.PI / 9.0);//变位系数和Xac
            double yy = Xac - y;//齿顶高变动系数△y
            Xa =Math.Round( 0.5 * (Xac - (zc - za) / (zc + za) * (Xac - yy)) + 0.08,3);//中心论a的变位系数
            Xc = Math.Round(Xac - Xa, 3);//齿轮C的变位系数
            Xb = Xc;//齿轮B的变位系数为0

            //double D = M * za;//太阳轮分度圆直径

            //double Ba = faid * M * za;//小齿轮齿宽
            ////参数计算行星轮
            //double D2 = M * zc;//行星轮分度圆直径
            //double Da2 = D2 + 2 * M * (1 + Xc - yy);//行星轮齿顶圆直径
            //double Df2 = D2 - 2 * (1 + 0.25 - Xc) * M;
            ////内齿轮参数计算
            //double D3 = M * zb;
            //double Da3 = D3 - 2 * M * (1.0 - Xb);
            //double Df3 = D3 + 2 * (1.25 - Xb);

            //计算许用接触应力值
            double ContactFLim = Common.PassValues.ContactValue2;
            double XYContactF = Math.Round(0.09081 * ContactFLim);//许用接触应力值
            double chishubi = Convert.ToDouble(zc) / Convert.ToDouble(za);//齿数比
            double aLess = 0.5 * mLess * (za + zc);//中心距不少于此值
            //显示到界面
            this.txtKc.Text = kp.ToString();//载荷不均匀系数
            this.txtInputTor.Text = inputTor.ToString();//总体输入扭矩
            this.txtPlantaryNum.Text = Common.PassValues.plantaryNum.ToString();
            this.txtTorAC.Text = Math.Round(T1, 3).ToString();//单对传动扭矩
            this.txtK.Text = ka.ToString();//综合载荷系数
            this.txtContactVal.Text = Common.PassValues.ContactValue2.ToString();//接触疲劳极限
            this.txtφc.Text = faid.ToString();//齿宽系数
            this.txtContactXY.Text = XYContactF.ToString();//许用接触应力
            this.txtU.Text = chishubi.ToString();//齿数比
            this.txtDisLess.Text = aLess.ToString();//中心距不小于
            this.txtMLess.Text = mless.ToString();//最小模数

            this.cboRealM.Text = M.ToString();//实际模数????
            this.txtDisReal.Text = Acb.ToString();//实际中心距
            this.txtDistNone.Text = a.ToString();//未变位中心距
            this.txtRealβ.Text = "0.00";//实际螺旋角
            this.txtAngleAc.Text = Math.Round((alp * 180 / Math.PI), 2).ToString();//a-c端面啮合角α'
            this.txtAngleBc.Text = "20.00";//b-c端面啮合角
            Common.PassValues.yy1 = yy;
            Common.PassValues.yy2 = 0.0;
            Common.PassValues.αac = Math.Round((alp * 180 / Math.PI), 2);
            Common.PassValues.αcb = 20.00;
            Common.PassValues.anone = a;
            this.txtK.Focus();//设置控件焦点
        }
        /// <summary>
        /// 初算模数的方法
        /// </summary>
        /// <param name="ka"></param>
        /// <param name="inputTor"></param>
        /// <param name="kp"></param>
        /// <param name="za"></param>
        private double CalculataScale(double ka, double inputTor, double kp, int za)
        {
            T1 = inputTor * kp / Common.PassValues.plantaryNum;//太阳轮传递的扭矩
            double KFZHXS = 1.8;//综合系数KF(p281)
            double KFP = 1.15;
            double v1 = T1 * ka * KFP * KFZHXS;
            double v2 = faid * za * za * Common.PassValues.BendValue1 * 0.85;
            double m = 17.5 * System.Math.Pow(v1 / v2, 1.0 / 3.0);
            double mLess = Math.Round(m, 3);//模数不小于此值=====
            //选取实际模数
            for (int i = 0; i < scale.Length; i++)
            {
                if (System.Math.Round(m, 3) - scale[i] < 0)
                {
                    M = scale[i];
                    break;//跳出循环====
                }
            }
            return mLess;//返回最小模数
        }
        //模数变化时引起的事件
        private void cboRealM_SelectedIndexChanged(object sender, EventArgs e)
        {
            double Mselect = Convert.ToDouble(this.cboRealM.Text);
            if (Common.PassValues.shift == 1)//标准传动
            {
                double a = (Common.PassValues.za + Common.PassValues.zc) * 0.5 * Mselect;
                this.txtDisReal.Text = a.ToString();//实际中心距
                this.txtDistNone.Text = a.ToString();//未变位中心距
                return;
            }
            if (Common.PassValues.shift == 2)//高度变位传动
            {
                double a = (Common.PassValues.za + Common.PassValues.zc) * 0.5 * Mselect;
                this.txtDisReal.Text = a.ToString();//实际中心距
                this.txtDistNone.Text = a.ToString();//未变位中心距
                return;
            }
            if (Common.PassValues.shift == 3)//等角度变位传动
            {
                return;
            }
            if (Common.PassValues.shift == 4)//不等角度变位传动
            {
                return;
            }
            if (Common.PassValues.shift == 5)//内啮合角度变位，外啮合高度变位
            {
                double a = (Common.PassValues.za + Common.PassValues.zc) * 0.5 * Mselect;
                this.txtDisReal.Text = a.ToString();//实际中心距            
                return;
            }
        }
        //确定按钮完成数据加载，事件激发
        private void btnCalculateFour_Click(object sender, EventArgs e)
        {
            //获取界面值传递
            double faiD = Convert.ToDouble(this.txtφc.Text);//齿宽系数
            double contactXY = Convert.ToDouble(this.txtContactXY.Text);//许用接触应力
            double Tac = Convert.ToDouble(this.txtTorAC.Text);
            double a = Convert.ToDouble(this.txtDisReal.Text);//实际中心距大小
            double kc = Convert.ToDouble(this.txtKc.Text);//载荷不均匀系数
            double k = Convert.ToDouble(this.txtK.Text);//综合载荷系数
            double u = Convert.ToDouble(this.txtU.Text);//齿数比
            double m = Convert.ToDouble(this.cboRealM.Text);//模数值
            OperateGetValue4(faiD, contactXY, Tac, a, kc, k, u, m);//激发事件

            //把数值存入公共类中
            Common.PassValues.Xa = Xa;
            Common.PassValues.Xb = Xc;
            Common.PassValues.Xc = Xc;
            Common.PassValues.faiD = faiD;
            Common.PassValues.contactXY = contactXY;
            Common.PassValues.Tac = Tac;
            Common.PassValues.a = a;
            Common.PassValues.kc = kc;
            Common.PassValues.k = k;
            Common.PassValues.u = u;
            Common.PassValues.m = m;
            this.Hide();
        }

        private void btnFourBefore_Click(object sender, EventArgs e)
        {
            FrmDesign objDesign = new FrmDesign();
            this.Visible = false;//隐藏当前窗体
            objDesign.btnMaterialSelect_Click(null, new EventArgs());
        }


    }
}
