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
    //【1】创建委托对象
    public delegate void GetValue(double p1,double p2,double p3,double p4,double p5,double p6,double p7,double p8);
    public partial class FrmDesign : Form
    {
        public FrmDesign()
        {
            InitializeComponent();
            //禁用相关按钮
            this.btnCaculGearNum.Enabled = false;
            this.btnCaculGeometry.Enabled = false;
            this.btnMaterialSelect.Enabled = false;
            this.btnStrengthCheck.Enabled = false;
            this.btnCaculDistance.Enabled = false;
        }
        public static FrmOne objOne = null;//定义静态窗体对
        private void btnModifyPara_Click(object sender, EventArgs e)
        {
            if (objOne == null)
            {
                objOne = new FrmOne();
                objOne.OperateGetValue += new GetValue(this.OperateShow);//委托与事件关联
                objOne.ShowDialog();
            }
            else
            {
                objOne.Activate();
                objOne.ShowDialog();
                objOne.WindowState = FormWindowState.Normal;
            }           
        }
        //显示数据在textbox中
        double txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8;       
        public void OperateShow(double p1, double p2, double p3, double p4, double p5, double p6, double p7, double p8)
        {
            txt1 = p1;
            txt2 = p2;
            txt3 = p3;
            txt4 = p4;
            txt5 = p5;
            txt6 = p6;
            txt7 = p7;
            txt8 = p8;
            this.txtInPower.Text = txt1.ToString();
            this.txtInRPm.Text = txt2.ToString();
            this.txtRatio.Text = txt3.ToString();
            this.txtEffici.Text = txt4.ToString();
            this.txtInTor.Text = txt5.ToString();
            this.txtOutRPm.Text = txt6.ToString();
            this.txtOutTor.Text = txt7.ToString();
            this.txtKa.Text = txt8.ToString();
            this.btnCaculGearNum.Enabled = true;
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
    }
}
