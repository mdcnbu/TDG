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
    /// <summary>
    /// 定义委托接收插齿刀参数值
    /// </summary>
    /// <param name="z0"></param>
    /// <param name="ha0"></param>
    public delegate void ToolValue(double z0, double ha0);
    public partial class FrmFive : Form
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public FrmFive(  )
        {
            InitializeComponent();
            za =Convert.ToInt32( Common.PassValues.za);
            zb = Convert.ToInt32(Common.PassValues.zb);
            zc = Convert.ToInt32(Common.PassValues.zc);
            M = Convert.ToDouble(Common.PassValues.m);
            Xa = Common.PassValues.Xa;
            Xb = Common.PassValues.Xb;
            Xc = Common.PassValues.Xc;
            shiftV = Common.PassValues.shift;
            yy1 = Common.PassValues.yy1;
            yy2 = Common.PassValues.yy2;
            a= Common.PassValues.a;
            alfac = Common.PassValues.αac;
            alfcb = Common.PassValues.αcb;
            CaculateValue();
        }
        # region 全局变量
        private int za;
        private int zb;
        private int zc;
        private double M;
        private double Xa;
        private double Xb;
        private double Xc;
        private double shiftV;
        private double yy1;
        private double yy2;
        private double a;
        private double alfac;
        private double alfcb;
        #endregion 
     
        public event GetValue5 OperateGetValue5;
        private void btnFiveNext_Click(object sender, EventArgs e)
        {
            FrmDesign objD = new FrmDesign();
            this.btnGemoCalcu_Click(null, e);
            this.Visible = false;//隐藏当前窗体.
            objD.btnStrengthCheck_Click(null, new EventArgs());//调用主窗体启动窗体6
        }

        private void CaculateValue()
        {
            double ha1 = 0.0;
            double ha2 = 0.0;
            double ha3 = 0.0;
            double hf1 = 0.0;
            double hf2 = 0.0;
            double hf3 = 0.0;
            double d1 = za * M;
            double d2 = zc * M;
            double d3 = zb * M;
            double Da1 = 0.0;//齿顶圆
            double Da2 = 0.0;//行星轮齿顶圆直径？？？？有误
            double Da3 = 0.0;

            //齿根圆直径
            double Df1 = 0.0;//齿根圆直径
            double Df2 = 0.0;
            double Df3 =0.0;
            double h1 = 0.0;
            double h2 = 0.0;
            double h3 = 0.0;
            string shift = "";
            if (this.rdoGun.Checked)
            {              
                //齿顶高计算
                if (shiftV == 1)//标准传动
                {
                    ha1 = (1 + 0) * M;//太阳轮
                    ha2 = ha1;//行星轮
                    ha3 = ha1;//内齿轮
                    hf1 = (1 + 0.25) * M;
                    hf2 = hf1;
                    hf3 = hf1;
                    shift = "不变位";
                }
                if (shiftV == 2)//高度变位
                {
                    ha1 = (1 + Xa) * M;
                    ha2 = (1 + Xc);
                    ha3 = (1 - Xb) * M;
                    hf1 = (1 + 0.25 - Xa) * M;
                    hf2 = (1 + 0.25 - Xc) * M;
                    hf3 = (1 + 0.25 + Xb) * M;
                    shift = "高度变位";
                }
                if (shiftV == 3||shiftV==4||shiftV==5)//等角、不等角、内外不同方式变位，，计算△y
                {
                    if (shiftV == 3)
                    {
                        shift = "等角度变位";
                    }
                    else if (shiftV == 4)
                    {
                        shift = "不等啮合角变位";
                    }
                    else
                    {
                        shift = "外啮合角变位，内啮合高变位";
                    }
                    ha1 = (1 + Xa - yy1) * M;
                    ha2 = (1 + Xc - yy1) * M;
                    ha3 = (1 - Xb + yy2) * M;
                    hf1 = (1 + 0.25 - Xa) * M;
                    hf2 = (1 + 0.25 - Xc) * M;
                    hf3 = (1 + 0.25 + Xb) * M;
                }
                //齿全高计算
                 h1 = ha1 + hf1;
                 h2 = ha2 + hf2;
                 h3 = ha3 + hf3;

                //齿顶圆直径计算,,,变位系数计算
                 Da1 = d1 + 2 * ha1;//齿顶圆
                 Da2 = d2 + 2 * ha2;//行星轮齿顶圆直径？？？？有误
                 Da3 = d3 - 2 * ha3;

                //齿根圆直径
                 Df1 = d1 - 2 * hf1;//齿根圆直径
                 Df2 = d2 - 2 * hf2;
                 Df3 = d3 + 2 * hf3;
            }
            else
            {
                //获取界面插齿刀的参数值
                int z0 = Convert.ToInt32(this.txtCutZ0.Text);//插齿刀齿数
                double Cx0 = Convert.ToDouble(this.txtCutX0.Text);//变位系数
                double Cha0 = Convert.ToDouble(this.txtCutHa0.Text);//插齿刀顶高系数
                if (z0 == 0 && Cx0 == 0 && Cha0 == 0)
                {
                    MessageBox.Show("请先选择插齿刀！");
                    this.rdoCha.Checked = false;
                    this.rdoGun.Checked = true;
                    return;
                }
                double da0 = M * (z0 + 2 * Cha0);//插齿刀参数
                          
                //计算插齿加工时的参数
                double invAlp1 = 2 * (Xa + Cx0) * Math.Tan(Math.PI / 9.0) / (za + z0) - (Math.Tan(Math.PI / 9.0) - Math.PI / 9.0);
                double invAlp2 = 2 * (Xc + Cx0) * Math.Tan(Math.PI / 9.0) / (zc + z0) - (Math.Tan(Math.PI / 9.0) - Math.PI / 9.0);
                double invAlp3 = 2 * (Xb - Cx0) * Math.Tan(Math.PI / 9.0) / (zb - z0) - (Math.Tan(Math.PI / 9.0) - Math.PI / 9.0);
                double alp1 = CaculateAlp(invAlp1);
                double alp2 = CaculateAlp(invAlp2);
                double alp3 = CaculateAlp(invAlp3);
                //计算切齿时中心距变动系数
                double y01 = 0.5 * (za + z0) * (Math.Cos(Math.PI / 9.0) / Math.Cos(alp1) - 1);
                double y02 = 0.5 * (zc + z0) * (Math.Cos(Math.PI / 9.0) / Math.Cos(alp2) - 1);
                double y03 = 0.5 * (zb - z0) * (Math.Cos(Math.PI / 9.0) / Math.Cos(alp3) - 1);
                //计算切齿时中心距a0
                double a1 = M * (0.5 * (za + z0) + y01);
                double a2 = M * (0.5 * (zc + z0) + y02);
                double a3 = M * (0.5 * (zb - z0) + y03);
                //计算齿根圆直径和齿顶圆直径
                 Df1 = 2 * a1 - da0;
                 Df2 = 2 * a2 - da0;
                 Df3 = 2 * a3 + da0;
                 Da1 = 2 * Common.PassValues.a - Df2 - 2 * 0.25 * M;
                 Da2 = 2 * Common.PassValues.a - Df1 - 2 * 0.25 * M;
                 Da3 = 2 * Common.PassValues.a + Df2 - 2 * 0.25 * M;
                ha1 = (Da1 - d1) / 2.0;
                ha2 = (Da2 - d2) / 2.0;
                ha3 = (d3 - Da3) / 2.0;
                hf1 = (d1 - Df1) / 2.0;
                hf2 = (d2 - Df2) / 2.0;
                hf3 = (Df3 - d3) / 2.0;
                h1 = ha1 + hf1;
                h2 = ha2 + hf2;
                h3 = ha3 + hf3;
            }
            //计算重合度
            double db1 = d1 * Math.Cos(Math.PI / 9.0);//基圆
            double db2 = d2 * Math.Cos(Math.PI / 9.0);
            double db3 = d3 * Math.Cos(Math.PI / 9.0);
            //a-g传动端面重合度
            double va1 = Da1 * Da1 / 4.0;
            double va2 = db1 * db1 / 4.0;
            double vc1 = Da2 * Da2 / 4.0;
            double vc2 = db2 * db2 / 4.0;
            double vb1 = Da3 * Da3 / 4.0;
            double vb2 = db3 * db3 / 4.0;
            double rouA = Math.Sqrt(va1 - va2);//太阳轮齿顶曲率半径
            double rouC = Math.Sqrt(vc1 - vc2);//行星轮齿顶曲率半径
            double rouB = Math.Sqrt(vb1 - vb2);//内齿轮齿顶曲率半径
            double ga1 = (rouA + rouC) - (a * Math.Sin(alfac/180*Math.PI));
            double chdAC =Math.Round( ga1 / Math.PI / M / Math.Cos(Math.PI / 9.0),2);//a-c端面重合度大小
            double ga2 = (rouC - rouB) + a * Math.Sin(alfcb / 180 * Math.PI);
            double chdCB =Math.Round( ga2 / Math.PI / M / Math.Cos(Math.PI / 9.0),2);//c-b端面重合度大小
            
            //数据显示到界面
            this.txtza.Text = za.ToString();
            this.txtzb.Text = zb.ToString();
            this.txtzc.Text = zc.ToString();
            this.txtXa.Text = Xa.ToString();
            this.txtXb.Text = Xb.ToString();
            this.txtXc.Text = Xc.ToString();
            this.txtd1.Text = d1.ToString();//分度圆
            this.txtd2.Text = d2.ToString();
            this.txtd3.Text = d3.ToString();
            this.txtda1.Text =Math.Round( Da1,2).ToString();//齿顶圆
            this.txtda2.Text =Math.Round( Da2,2).ToString();
            this.txtda3.Text = Math.Round(Da3,2).ToString();
            this.txtDfa.Text = Df1.ToString();//齿根圆
            this.txtDfc.Text = Df2.ToString();
            this.txtDfb.Text = Df3.ToString();
            this.txtHa.Text =Math.Round(h1,2).ToString();//齿全高
            this.txtHb.Text =Math.Round( h2,2).ToString();
            this.txtHc.Text = Math.Round(h3,2).ToString();
            this.txtHa1.Text =Math.Round( ha1,2).ToString();//齿顶高
            this.txtHa2.Text =Math.Round( ha2,2).ToString();
            this.txtHa3.Text =Math.Round( ha3,2).ToString();
            this.txtHfa.Text =Math.Round(hf1,2).ToString();//齿根高
            this.txtHfb.Text =Math.Round( hf2,2).ToString();
            this.txtHfc.Text =Math.Round( hf3,2).ToString();
            this.txtXac.Text = (Xa + Xc).ToString();//a-c变位系数和
            this.txtXcb.Text = (Xc - Xb).ToString();//c-b变位系数和
            this.txtalp.Text = "20.00";
            this.txtm.Text = M.ToString();
            this.txtShiftStyle.Text = shift;
            this.txtGearStyle.Text = "直齿";
            this.txtAlpac.Text = alfac.ToString();
            this.txtAlpcb.Text = alfcb.ToString();
            this.txtacCHD.Text = chdAC.ToString();//a-c端面重合度
            this.txtcbCHD.Text = chdCB.ToString();//c-b端面重合度
            this.txtβ.Text = "0.00";
            this.txta.Text = a.ToString();//中心距值
        }

        private void rdoGun_CheckedChanged(object sender, EventArgs e)
        {
            CaculateValue();
        }

        private void rdoCha_CheckedChanged(object sender, EventArgs e)
        {
            CaculateValue();
        }
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
        double inv1 ;
        double R1 = 0.0;//左端点
        double R2 = 90.0;//右端点
        private void btnSelectTool_Click(object sender, EventArgs e)
        {
            //要建立一个委托传值给窗体（模数）
            FrmCutTool objFrm = new FrmCutTool(M);//构造函数把模数传递过去
            objFrm.OperateValue += new ToolValue(ShowValues);//事件与方法的关联
            objFrm.ShowDialog();//打开子窗体
        }
        private void ShowValues(double z0, double ha0)
        {
            this.txtCutZ0.Text = z0.ToString();
            this.txtCutHa0.Text = ha0.ToString();
        }

        //传值到主窗体
        private void btnGemoCalcu_Click(object sender, EventArgs e)
        {
            //获取界面值
            double d1 =Convert.ToDouble( this.txtd1.Text);
            double d2 = Convert.ToDouble(this.txtd2.Text);
            double d3 = Convert.ToDouble(this.txtd3.Text);
            double da1 = Convert.ToDouble(this.txtda1.Text);
            double da2 = Convert.ToDouble(this.txtda2.Text);
            double da3 = Convert.ToDouble(this.txtda3.Text);
            double A=Common.PassValues.a;//实际中心距
            double Anone=Common.PassValues.anone;
            Common.PassValues.d1 = d1;
            Common.PassValues.d2 = d2;
            Common.PassValues.d3 = d3;
            Common.PassValues.da1 = da1;
            Common.PassValues.da2 = da2;
            Common.PassValues.da3 = da3;
            Common.PassValues.chdAC = Convert.ToDouble(this.txtacCHD.Text);
            Common.PassValues.chdCB = Convert.ToDouble(this.txtcbCHD.Text);
            //激发事件传值
            OperateGetValue5(0.00, Anone, A, Xa, Xb, Xc, d1, d3, d2, da1, da3, da2);
            this.Hide();
        }

        private void btnPrim5_Click(object sender, EventArgs e)
        {
            FrmDesign objDesign = new FrmDesign();
            this.Close();
            objDesign.btnCaculDistance_Click(null, new EventArgs());
        }
               
    }
}
