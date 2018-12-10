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
    /// 【1】创建委托对象
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
    /// <param name="p7"></param>
    /// <param name="p8"></param>
    /// <param name="p9"></param>

    public delegate void GetValue(double p1,double p2,double p3,double p4,double p5,double p6,double p7,double p8,double p9);
    /// <summary>
    /// []创建委托对象（第二步）
    /// </summary>
    /// <param name="a1"></param>
    /// <param name="a2"></param>
    /// <param name="a3"></param>
    /// <param name="a4"></param>
    /// <param name="a5"></param>
    /// <param name="a6"></param>
    /// <param name="a7"></param>
    /// <param name="a8"></param>
    public delegate void GetValue2(int a1, double a2, double a3, double a4, double a5, string a6, double a7, double a8);

    /// <summary>
    /// 委托对象（接收窗体3的值）
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <param name="v3"></param>
    public delegate void GetValue3(string v1,string v2,string v3);
    /// <summary>
    /// 定义窗体4的委托
    /// </summary>
    /// <param name="faiD">齿宽系数</param>
    /// <param name="ContaValue">许用接触应力</param>
    /// <param name="Tac">a-c传动扭矩</param>
    /// <param name="a">中心距</param>
    /// <param name="Kc">均载系数</param>
    /// <param name="Kf">综合系数</param>
    /// <param name="u">齿数比</param>
    /// <param name="m">模数选择</param>
    public delegate void GetValue4(double faiD,double ContaValue,double Tac,double a,double Kc,double Kf,double u,double m);
    /// <summary>
    /// 窗体5的委托
    /// </summary>
    /// <param name="β"></param>
    /// <param name="a"></param>
    /// <param name="aReal"></param>
    /// <param name="Xa"></param>
    /// <param name="Xb"></param>
    /// <param name="Xc"></param>
    /// <param name="Da"></param>
    /// <param name="Db"></param>
    /// <param name="Dc"></param>
    /// <param name="da1"></param>
    /// <param name="da2"></param>
    /// <param name="da3"></param>
    public delegate void GetValue5(double β,double a,double aReal,double Xa,double Xb,double Xc,double Da,double Db,double Dc,double da1,double da2,double da3);
    public delegate void GetValue6(double contactVal, double XYContVal, double aBendVal, double cBendVal, double XYbendA, double XYbendC);
    public partial class FrmDesign : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmDesign()
        {
            InitializeComponent();
            //禁用相关按钮
            this.btnCaculGearNum.Enabled = false;//齿数配比
            this.btnCaculGeometry.Enabled = false;//几何计算
            this.btnMaterialSelect.Enabled = false;//材料选择
            this.btnStrengthCheck.Enabled = false;//强度计算
            this.btnCaculDistance.Enabled = false;//计算中心距
        }
        //定义事件响应方法
        private void ShowMsg_SendMsgEvent1(double p1, double p2, double p3, double p4, double p5, double p6, double p7, double p8, double p9)
        {
            this.txtInPower.Text = p1.ToString();
            this.txtInRPm.Text = p2.ToString();
            this.txtRatio.Text = p3.ToString();
            this.txtEffici.Text = p4.ToString();
            this.txtInTor.Text = p5.ToString();
            this.txtOutRPm.Text = p6.ToString();
            this.txtOutTor.Text = p7.ToString();
            this.txtKa.Text = p8.ToString();
            this.txtJunZai.Text = p9.ToString();//均载系数
            this.btnCaculGearNum.Enabled = true;
        }
        private void ShowMsg_SendMsgEvent(int a1, double a2, double a3, double a4, double a5, string a6, double a7, double a8)
        {
            if (a1 == 0 && a2 == 0 && a3 == 0 && a4 == 0 && a5 == 0)
            {
                return;
            }
            this.txtPlantNum.Text = a1.ToString();
            this.txtZa.Text = a2.ToString();
            this.txtZb.Text = a3.ToString();
            this.txtZc.Text = a4.ToString();
            this.txtrealRatin.Text = a5.ToString();
            this.txtRationGap.Text = a6.ToString();
            this.txtOutTort.Text = a7.ToString();
            this.txtOutRevol.Text = a8.ToString();
            this.btnMaterialSelect.Enabled = true;
        }
        private void ShowMsg_SendMsgEvent4(double faiD, double ContaValue, double Tac, double a, double Kc, double Kf, double u, double m)
        {
            if (faiD == 0 && ContaValue == 0 && Tac == 0 && a == 0)
            {
                return;
            }
            this.txtφd.Text = faiD.ToString();
            this.txtcontaValXY.Text = ContaValue.ToString();
            this.txtTac.Text = Tac.ToString();
            this.txta.Text = a.ToString();
            this.txtkc.Text = Kc.ToString();
            this.txtKf.Text = Kf.ToString();
            this.txtU.Text = u.ToString();
            this.txtM.Text = m.ToString();
            this.btnCaculGeometry.Enabled = true;//参数计算按钮启用
        }
        private void ShowMsg_SendMsgEvent5(double β, double a, double aReal, double Xa, double Xb, double Xc, double Da, double Db, double Dc, double da1, double da2, double da3)
        {
            if (β == 0 && a == 0 && aReal == 0 && Xa == 0 && Xb == 0 && Xc == 0)
            {
                return;
            }
            this.txtSpiral.Text = β.ToString();
            this.txtaNone.Text = a.ToString();
            this.txtaReal.Text = aReal.ToString();
            this.txtxa.Text = Xa.ToString();
            this.txtxb.Text = Xb.ToString();
            this.txtxc.Text = Xc.ToString();
            this.txtd1.Text = Da.ToString();
            this.txtd2.Text = Db.ToString();
            this.txtd3.Text = Dc.ToString();
            this.txtda1.Text = da1.ToString();
            this.txtda2.Text = da2.ToString();
            this.txtda3.Text = da3.ToString();
            this.btnStrengthCheck.Enabled = true;
        }
        private void ShowMsg_SendMsgEvent6(double contactVal, double XYContVal, double aBendVal, double cBendVal, double XYbendA, double XYbendC)
        {
            this.txtContact.Text = contactVal.ToString();
            this.txtXYContact.Text = XYContVal.ToString();
            this.txtSunBendV.Text = aBendVal.ToString();
            this.txtPlantBendV.Text = cBendVal.ToString();
            this.txtXYSun.Text = XYbendA.ToString();
            this.txtXYPlant.Text = XYbendC.ToString();
            this.txtInPower.Focus();
        }
        /// <summary>
        /// 传递材料热处理方式的值
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        private void PassMsg_SendMsgEvent(string s1, string s2, string s3)
        {
            if (s1 == null && s2 == null && s3 == null)
            {
                return;
            }
            this.txtSunMatrial.Text = s1;
            this.txtPlantMatrial.Text = s2;
            this.txtInnMatrial.Text = s3;
            this.btnCaculDistance.Enabled = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        public void OperateShow3(string v1, string v2, string v3)
        {
            this.txtSunMatrial.Text = v1;
            this.txtPlantMatrial.Text = v2;
            this.txtInnMatrial.Text = v3;
            this.btnCaculDistance.Enabled = true;
        }
       
        public static FrmOne objOne = null;//定义静态窗体对
        public void btnModifyPara_Click(object sender, EventArgs e)
        {
            if (objOne == null)
            {
                objOne = new FrmOne();
                objOne.OperateGetValue += new GetValue(this.OperateShow);//委托与事件关联
                objOne.PassData1 += new GetValue(this.ShowMsg_SendMsgEvent1);
                objOne.PassData += new GetValue2(this.ShowMsg_SendMsgEvent);//绑定事件传递窗体2的值(通过窗体1传递)
                objOne.PassDatas += new GetValue3(this.PassMsg_SendMsgEvent); //绑定事件传递窗体3的值
                objOne.passData4 += new GetValue4(this.ShowMsg_SendMsgEvent4);//绑定事件传递窗体4的值
                objOne.passData5 += new GetValue5(this.ShowMsg_SendMsgEvent5);//绑定事件传递窗体5的值
                objOne.passData6 += new GetValue6(this.ShowMsg_SendMsgEvent6);//绑定事件传递窗体6的值
                objOne.ShowDialog();
            }
            else
            {
                objOne.Activate();
                objOne.Show();
                objOne.WindowState = FormWindowState.Normal;
            }           
        }
       
        /// <summary>
        ///  //显示数据在textbox中 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p5"></param>
        /// <param name="p6"></param>
        /// <param name="p7"></param>
        /// <param name="p8"></param>
        /// <param name="p9"></param>
        public void OperateShow(double p1, double p2, double p3, double p4, double p5, double p6, double p7, double p8,double p9)
        {
            this.txtInPower.Text = p1.ToString();
            this.txtInRPm.Text = p2.ToString();
            this.txtRatio.Text = p3.ToString();
            this.txtEffici.Text = p4.ToString();
            this.txtInTor.Text = p5.ToString();
            this.txtOutRPm.Text = p6.ToString();
            this.txtOutTor.Text = p7.ToString();
            this.txtKa.Text = p8.ToString();
            this.txtJunZai.Text = p9.ToString();//均载系数
            this.btnCaculGearNum.Enabled = true;
        }


        /// <summary>
        /// 方法;z显示在界面上
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p5"></param>
        /// <param name="p6"></param>
        /// <param name="p7"></param>
        /// <param name="p8"></param>
        public void OperateShow2(int p1, double p2, double p3, double p4, double p5, string p6, double p7, double p8)
        {
            this.txtPlantNum.Text = Common.PassValues.plantaryNum.ToString();
            this.txtZa.Text = Common.PassValues.za.ToString();
            this.txtZb.Text = Common.PassValues.zb.ToString();
            this.txtZc.Text = Common.PassValues.zc.ToString();
            this.txtrealRatin.Text = Common.PassValues.reRation.ToString();
            this.txtRationGap.Text = Common.PassValues.rationGap;
            this.txtOutTort.Text = Common.PassValues.outTorReal.ToString();
            this.txtOutRevol.Text = Common.PassValues.outRevoReal.ToString();

            this.btnMaterialSelect.Enabled = true;
        }
        /// <summary>
        /// 把窗体4的值显示在主界面上
        /// </summary>
        /// <param name="faiD"></param>
        /// <param name="ContaValue"></param>
        /// <param name="Tac"></param>
        /// <param name="a"></param>
        /// <param name="Kc"></param>
        /// <param name="Kf"></param>
        /// <param name="u"></param>
        /// <param name="m"></param>
        public void OperateShow4(double faiD, double ContaValue, double Tac, double a, double Kc, double Kf, double u, double m)
        {
            this.txtφd.Text = faiD.ToString();
            this.txtcontaValXY.Text = ContaValue.ToString();
            this.txtTac.Text = Tac.ToString();
            this.txta.Text = a.ToString();
            this.txtkc.Text = Kc.ToString();
            this.txtKf.Text = Kf.ToString();
            this.txtU.Text = u.ToString();
            this.txtM.Text = m.ToString();
            this.btnCaculGeometry.Enabled = true;//步骤5按钮激活
        }
        /// <summary>
        /// 窗体5显示值
        /// </summary>
        /// <param name="β"></param>
        /// <param name="a"></param>
        /// <param name="aReal"></param>
        /// <param name="Xa"></param>
        /// <param name="Xb"></param>
        /// <param name="Xc"></param>
        /// <param name="Da"></param>
        /// <param name="Db"></param>
        /// <param name="Dc"></param>
        /// <param name="da1"></param>
        /// <param name="da2"></param>
        /// <param name="da3"></param>
        private void OperateShow5(double β, double a, double aReal, double Xa, double Xb, double Xc, double Da, double Db, double Dc, double da1, double da2, double da3)
        {
            this.txtSpiral.Text = "0.00";
            this.txtaNone.Text = a.ToString();
            this.txtaReal.Text = aReal.ToString();
            this.txtxa.Text = Xa.ToString();
            this.txtxb.Text = Xb.ToString();
            this.txtxc.Text = Xc.ToString();
            this.txtd1.Text = Da.ToString();
            this.txtd2.Text = Db.ToString();
            this.txtd3.Text = Dc.ToString();
            this.txtda1.Text = da1.ToString();
            this.txtda2.Text = da2.ToString();
            this.txtda3.Text = da3.ToString();
            this.btnStrengthCheck.Enabled = true;//步骤6按钮激活
        }
        private void OperateShow6(double contactVal, double XYContVal, double aBendVal, double cBendVal, double XYbendA, double XYbendC)
        {
            this.txtContact.Text = contactVal.ToString();
            this.txtcontaValXY.Text = XYContVal.ToString();
            this.txtSunBendV.Text = aBendVal.ToString();
            this.txtPlantBendV.Text = cBendVal.ToString();
            this.txtXYSun.Text = XYbendA.ToString();
            this.txtXYPlant.Text = XYbendC.ToString();           
        }
        private void btnCloseReducer_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach (Control item in FrmMain.pMainWin.splitContainer1.Panel2.Controls)
            {
                if (item is PictureBox)
                {
                    PictureBox objPictu = (PictureBox)item;
                    objPictu.Show();
                }
            }
        }
        public static FrmTwo objTwo = null;//定义静态窗体对
        public void btnCaculGearNum_Click(object sender, EventArgs e)
        {
            //获取窗体1的值(使用公共属性）
            double inputPower=Common.PassValues.inputPower;
            double speedRatio=Common.PassValues.speedRatio;
            double inputRevolo=Common.PassValues.inputRevolo;
            double drivenEfficient=Common.PassValues.drivenEfficient;
            double outputTorque=Common.PassValues.outputTorque;
            double outRevolo=Common.PassValues.outRevolo;
            double inputTorque=Common.PassValues.inputTorque;
            double loadXishu=Common.PassValues.loadXishu;
            double KA = Common.PassValues.KA;
            if (objTwo == null)
            {
                objTwo = new FrmTwo(inputPower, speedRatio, inputRevolo, drivenEfficient, outputTorque, outRevolo, inputTorque, KA, loadXishu);
                objTwo.OperateGetValue2 += new GetValue2(this.OperateShow2);//委托与事件关联///另外一种情况下使用               
                objTwo.ShowDialog();
            }
            else
            {
                objTwo.Activate();
                objTwo.Show();
                objTwo.WindowState = FormWindowState.Normal;
            }           
        }
        public static FrmThree objThree = null;//定义静态窗体对
        public void btnMaterialSelect_Click(object sender, EventArgs e)
        {
            if (objThree == null)
            {
                objThree = new FrmThree();
                objThree.OperateGetValue3 += new GetValue3(this.OperateShow3);//委托与事件关联
                objThree.ShowDialog();
            }
            else
            {
                objThree.Activate();
                objThree.Show();
                objThree.WindowState = FormWindowState.Normal;
            }           
        }
        public static FrmFour objFour = null;//定义静态窗体对
        public void btnCaculDistance_Click(object sender, EventArgs e)
        {
            //获取主窗体值传给窗体4
            double ka = Common.PassValues.KA;//载荷特性值
            double inputTor = Common.PassValues.inputTorque;//输入扭矩
            double Kp = Common.PassValues.loadXishu;
            int za = Convert.ToInt32(Common.PassValues.za);
            int zc = Convert.ToInt32(Common.PassValues.zc);
            int zb = Convert.ToInt32(Common.PassValues.zb);
            if (objFour == null)
            {
                objFour = new FrmFour(ka,inputTor,Kp,za,zc,zb);
                objFour.OperateGetValue4 += new GetValue4(this.OperateShow4);//委托与事件关联
                objFour.ShowDialog();
            }
            else
            {
                objFour.Activate();
                objFour.Show();
                objFour.WindowState = FormWindowState.Normal;
            }           
        }
        public static FrmFive objFive = null;
        public void btnCaculGeometry_Click(object sender, EventArgs e)
        {
            if (objFive == null)
            {
                objFive = new FrmFive(  );
                objFive.OperateGetValue5 += new GetValue5(this.OperateShow5);//委托与事件关联
                objFive.ShowDialog();
            }
            else
            {
                objFive.Activate();
                objFive.Show();
                objFive.WindowState = FormWindowState.Normal;
            }           
        }
        public static FrmSix objSix = null;
        public void btnStrengthCheck_Click(object sender, EventArgs e)
        {
            double M = Common.PassValues.m;
            double d1 = Common.PassValues.d1;
            double d2 = Common.PassValues.d2;
            double d3 = Common.PassValues.d3;
            if (objSix == null)
            {
                objSix = new FrmSix(M,d1,d2,d3);
                objSix.OperateGetValue6 += new GetValue6(this.OperateShow6);//委托与事件关联
                objSix.ShowDialog();
            }
            else
            {
                objSix.Activate();
                objSix.Show();
                objSix.WindowState = FormWindowState.Normal;
            }
        }

   
    }
}
