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
    public partial class FrmThree : Form
    {
        private MaterialIdService objMaterialService = new MaterialIdService();
        private HeatTypeService objHeatTypeService = new HeatTypeService();
        public FrmThree()
        {
            InitializeComponent();
            #region 初始化下拉框
            this.cboMaterialCard1.DataSource = objMaterialService.GetMaterialId();
            this.cboMaterialCard1.DisplayMember = "MaterialCardId";
            this.cboMaterialCard1.ValueMember = "CardId";
            this.cboMaterialCard1.SelectedIndex = 10;
            this.cboMaterialCard2.DataSource = objMaterialService.GetMaterialId();
            this.cboMaterialCard2.DisplayMember = "MaterialCardId";
            this.cboMaterialCard2.ValueMember = "CardId";
            this.cboMaterialCard2.SelectedIndex = 10;
            this.cboMaterialCard3.DataSource = objMaterialService.GetMaterialId();
            this.cboMaterialCard3.DisplayMember = "MaterialCardId";
            this.cboMaterialCard3.ValueMember = "CardId";
            this.cboMaterialCard3.SelectedIndex = 12;
            #endregion
        }
        /// <summary>
        /// 定义事件传值
        /// </summary>
        public event GetValue3 OperateGetValue3;
        private void btnSelectOne_Click(object sender, EventArgs e)
        {
            FrmMaterials objMaterial = new FrmMaterials();
            objMaterial.ShowDialog();
        }

        private void btnSelectTwo_Click(object sender, EventArgs e)
        {
            FrmMaterials objMaterial = new FrmMaterials();
            objMaterial.ShowDialog();
        }

        private void btnSelectThree_Click(object sender, EventArgs e)
        {
            FrmMaterials objMaterial = new FrmMaterials();
            objMaterial.ShowDialog();
        }
        # region 太阳轮下拉框变化一起的事件
        private void cboMaterialCard1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboMaterialCard1.SelectedIndex == 0)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 1)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 2)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 3)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 4)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 5)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 6)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 7)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 8)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 9)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 10)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 11)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 12)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 13)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 14)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 15)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 16)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 17)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 18)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 19)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 20)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 21)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 22)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 23)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 24)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 25)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 26)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 27)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 28)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 29)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 30)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 31)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 32)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 33)
            {
                this.cboHeat1.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard1.Text);
                this.cboHeat1.DisplayMember = "HeatingType";
                return;
            }
        }
        # endregion
        #region 行星轮材料下拉框变化时发生的事件
        private void cboMaterialCard2_SelectedIndexChanged(object sender, EventArgs e)
        {            
     
            if (this.cboMaterialCard2.SelectedIndex == 0)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 1)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 2)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 3)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 4)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 5)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 6)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 7)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 8)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 9)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 10)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 11)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 12)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 13)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 14)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 15)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 16)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 17)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 18)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 19)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 20)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 21)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 22)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 23)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 24)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 25)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 26)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 27)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 28)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 29)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 30)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 31)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 32)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 33)
            {
                this.cboHeat2.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard2.Text);
                this.cboHeat2.DisplayMember = "HeatingType";
                return;
            }
        }
        # endregion
        # region 内齿轮材料下拉框变化时发生的事件
        private void cboMaterialCard3_SelectedIndexChanged(object sender, EventArgs e)
        {         
            if (this.cboMaterialCard3.SelectedIndex == 0)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 1)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 2)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 3)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 4)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 5)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 6)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 7)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 8)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 9)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 10)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 11)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 12)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 13)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 14)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 15)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 16)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 17)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 18)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 19)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 20)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 21)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 22)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 23)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 24)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 25)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 26)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 27)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 28)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 29)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 30)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 31)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 32)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 33)
            {
                this.cboHeat3.DataSource = objHeatTypeService.GetHeatType(this.cboMaterialCard3.Text);
                this.cboHeat3.DisplayMember = "HeatingType";
                return;
            }
        
       
        }
         # endregion
        # region 对应的材料属性值
        private void cboHeat1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string value1, value2, value3;
            if (this.cboMaterialCard1.SelectedIndex == 0 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "160～210 HB";
                value2 = "526";
                value3 = "200";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 0 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "200～280 HB";
                value2 = "578";
                value3 = "214";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 0 && this.cboHeat1.SelectedIndex == 2)
            {
                value1 = "40～50 HRC";
                value2 = "1056";
                value3 = "260";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 1 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "200～280 HB";
                value2 = "668";
                value3 = "282";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 1 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "45～55 HRC";
                value2 = "1110";
                value3 = "310";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 2 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "200～280 HB";
                value2 = "625";
                value3 = "270";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 2 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "45～55 HRC";
                value2 = "1110";
                value3 = "310";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 3 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "210～280 HB";
                value2 = "668";
                value3 = "282";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 3 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "45～50 HRC";
                value2 = "1110";
                value3 = "310";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }

            if (this.cboMaterialCard1.SelectedIndex == 4 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "240～280 HB";
                value2 = "686";
                value3 = "287";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 4 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "45～55 HRC";
                value2 = "1110";
                value3 = "310";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 5 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "190～280 HB";
                value2 = "668";
                value3 = "282";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 5 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "45～55 HRC";
                value2 = "1165";
                value3 = "360";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 6 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "240～300 HB";
                value2 = "728";
                value3 = "299";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 6 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "50～55 HRC";
                value2 = "1165";
                value3 = "360";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 7 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "220～280 HB";
                value2 = "686";
                value3 = "287";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 7 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "48～55 HRC";
                value2 = "1143";
                value3 = "340";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 8 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "210～270 HB";
                value2 = "635";
                value3 = "273";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 8 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "40～45 HRC";
                value2 = "1056";
                value3 = "260";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 9 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "56～62 HRC";
                value2 = "1500";
                value3 = "470";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 9 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "561～713 HV";
                value2 = "1000";
                value3 = "375";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 10 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "56～62 HRC";
                value2 = "1500";
                value3 = "470";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 10 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "642～795 HV";
                value2 = "1000";
                value3 = "375";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 11 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "56～62 HRC";
                value2 = "1500";
                value3 = "470";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 12 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "230～250 HB";
                value2 = "668";
                value3 = "282";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 12 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "850～1100 HV";
                value2 = "1250";
                value3 = "425";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 13 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "56～62 HRC";
                value2 = "1500";
                value3 = "470";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 14 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "160～200 HB";
                value2 = "305";
                value3 = "124";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 15 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "180～210 HB";
                value2 = "318";
                value3 = "130";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 16 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "200～240 HB";
                value2 = "530";
                value3 = "234";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 16 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "270～300 HB";
                value2 = "633";
                value3 = "256";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 17 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "160～210 HB";
                value2 = "481";
                value3 = "223";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 17 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "200～250 HB";
                value2 = "530";
                value3 = "234";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 18 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "160～210 HB";
                value2 = "481";
                value3 = "223";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 18 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "200～250 HB";
                value2 = "530";
                value3 = "234";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 19 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "220～250 HB";
                value2 = "559";
                value3 = "240";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 20 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "175～210 HB";
                value2 = "552";
                value3 = "238";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 20 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "230～320 HB";
                value2 = "575";
                value3 = "243";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 21 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "180～240 HB";
                value2 = "504";
                value3 = "228";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 21 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "180～240 HB";
                value2 = "504";
                value3 = "228";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 22 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "160～210 HB";
                value2 = "481";
                value3 = "223";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 22 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "200～270 HB";
                value2 = "530";
                value3 = "234";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 23 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "210～270 HB";
                value2 = "635";
                value3 = "273";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 24 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "210～270 HB";
                value2 = "640";
                value3 = "274";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 25 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "190～240 HB";
                value2 = "516";
                value3 = "230";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 25 && this.cboHeat1.SelectedIndex == 1)
            {
                value1 = "260～300 HB";
                value2 = "707";
                value3 = "293";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 26 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "280～360 HB";
                value2 = "600";
                value3 = "222";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 27 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "245～335 HB";
                value2 = "556";
                value3 = "209";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 28 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "225～305 HB";
                value2 = "531";
                value3 = "201";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 29 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "190～270 HB";
                value2 = "487";
                value3 = "188";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 30 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "170～230 HB";
                value2 = "462";
                value3 = "180";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 31 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "170～290 HB";
                value2 = "331";
                value3 = "58";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 32 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "160～270 HB";
                value2 = "316";
                value3 = "55";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 33 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "150～260 HB";
                value2 = "310";
                value3 = "53";
                this.txtHardValue1.Text = value1;
                this.txtContactValue1.Text = value2;
                this.txtBendValue1.Text = value3;
                return;
            }
        }
        # endregion
        # region 行星轮热处理索引变化事件
        private void cboHeat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value1, value2, value3;
            if (this.cboMaterialCard2.SelectedIndex == 0 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "160～210 HB";
                value2 = "526";
                value3 = "200";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 0 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "200～280 HB";
                value2 = "578";
                value3 = "214";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 0 && this.cboHeat2.SelectedIndex == 2)
            {
                value1 = "40～50 HRC";
                value2 = "1056";
                value3 = "260";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 1 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "200～280 HB";
                value2 = "668";
                value3 = "282";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 1 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "45～55 HRC";
                value2 = "1110";
                value3 = "310";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 2 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "200～280 HB";
                value2 = "625";
                value3 = "270";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 2 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "45～55 HRC";
                value2 = "1110";
                value3 = "310";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 3 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "210～280 HB";
                value2 = "668";
                value3 = "282";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 3 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "45～50 HRC";
                value2 = "1110";
                value3 = "310";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }

            if (this.cboMaterialCard2.SelectedIndex == 4 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "240～280 HB";
                value2 = "686";
                value3 = "287";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 4 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "45～55 HRC";
                value2 = "1110";
                value3 = "310";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 5 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "190～280 HB";
                value2 = "668";
                value3 = "282";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 5 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "45～55 HRC";
                value2 = "1165";
                value3 = "360";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 6 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "240～300 HB";
                value2 = "728";
                value3 = "299";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 6 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "50～55 HRC";
                value2 = "1165";
                value3 = "360";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 7 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "220～280 HB";
                value2 = "686";
                value3 = "287";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 7 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "48～55 HRC";
                value2 = "1143";
                value3 = "340";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 8 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "210～270 HB";
                value2 = "635";
                value3 = "273";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 8 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "40～45 HRC";
                value2 = "1056";
                value3 = "260";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 9 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "56～62 HRC";
                value2 = "1500";
                value3 = "470";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 9 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "561～713 HV";
                value2 = "1000";
                value3 = "375";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 10 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "56～62 HRC";
                value2 = "1500";
                value3 = "470";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 10 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "642～795 HV";
                value2 = "1000";
                value3 = "375";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 11 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "56～62 HRC";
                value2 = "1500";
                value3 = "470";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 12 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "230～250 HB";
                value2 = "668";
                value3 = "282";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 12 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "850～1100 HV";
                value2 = "1250";
                value3 = "425";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 13 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "56～62 HRC";
                value2 = "1500";
                value3 = "470";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 14 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "160～200 HB";
                value2 = "305";
                value3 = "124";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 15 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "180～210 HB";
                value2 = "318";
                value3 = "130";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 16 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "200～240 HB";
                value2 = "530";
                value3 = "234";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 16 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "270～300 HB";
                value2 = "633";
                value3 = "256";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 17 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "160～210 HB";
                value2 = "481";
                value3 = "223";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 17 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "200～250 HB";
                value2 = "530";
                value3 = "234";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 18 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "160～210 HB";
                value2 = "481";
                value3 = "223";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 18 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "200～250 HB";
                value2 = "530";
                value3 = "234";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 19 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "220～250 HB";
                value2 = "559";
                value3 = "240";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 20 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "175～210 HB";
                value2 = "552";
                value3 = "238";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 20 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "230～320 HB";
                value2 = "575";
                value3 = "243";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 21 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "180～240 HB";
                value2 = "504";
                value3 = "228";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 21 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "180～240 HB";
                value2 = "504";
                value3 = "228";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 22 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "160～210 HB";
                value2 = "481";
                value3 = "223";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 22 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "200～270 HB";
                value2 = "530";
                value3 = "234";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 23 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "210～270 HB";
                value2 = "635";
                value3 = "273";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 24 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "210～270 HB";
                value2 = "640";
                value3 = "274";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 25 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "190～240 HB";
                value2 = "516";
                value3 = "230";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 25 && this.cboHeat2.SelectedIndex == 1)
            {
                value1 = "260～300 HB";
                value2 = "707";
                value3 = "293";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 26 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "280～360 HB";
                value2 = "600";
                value3 = "222";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 27 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "245～335 HB";
                value2 = "556";
                value3 = "209";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 28 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "225～305 HB";
                value2 = "531";
                value3 = "201";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 29 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "190～270 HB";
                value2 = "487";
                value3 = "188";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 30 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "170～230 HB";
                value2 = "462";
                value3 = "180";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 31 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "170～290 HB";
                value2 = "331";
                value3 = "58";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 32 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "160～270 HB";
                value2 = "316";
                value3 = "55";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
            if (this.cboMaterialCard2.SelectedIndex == 33 && this.cboHeat2.SelectedIndex == 0)
            {
                value1 = "150～260 HB";
                value2 = "310";
                value3 = "53";
                this.txtHardValue2.Text = value1;
                this.txtContactValue2.Text = value2;
                this.txtBendValue2.Text = value3;
                return;
            }
        }        
            # endregion
        # region 内齿轮热处理索引变化事件
        private void cboHeat3_SelectedIndexChanged(object sender, EventArgs e)
        {       
       
            string value1, value2, value3;
            if (this.cboMaterialCard3.SelectedIndex == 0 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "160～210 HB";
                value2 = "526";
                value3 = "200";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 0 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "200～280 HB";
                value2 = "578";
                value3 = "214";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 0 && this.cboHeat3.SelectedIndex == 2)
            {
                value1 = "40～50 HRC";
                value2 = "1056";
                value3 = "260";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard1.SelectedIndex == 1 && this.cboHeat1.SelectedIndex == 0)
            {
                value1 = "200～280 HB";
                value2 = "668";
                value3 = "282";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 1 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "45～55 HRC";
                value2 = "1110";
                value3 = "310";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 2 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "200～280 HB";
                value2 = "625";
                value3 = "270";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 2 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "45～55 HRC";
                value2 = "1110";
                value3 = "310";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 3 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "210～280 HB";
                value2 = "668";
                value3 = "282";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 3 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "45～50 HRC";
                value2 = "1110";
                value3 = "310";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }

            if (this.cboMaterialCard3.SelectedIndex == 4 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "240～280 HB";
                value2 = "686";
                value3 = "287";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 4 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "45～55 HRC";
                value2 = "1110";
                value3 = "310";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 5 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "190～280 HB";
                value2 = "668";
                value3 = "282";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 5 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "45～55 HRC";
                value2 = "1165";
                value3 = "360";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 6 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "240～300 HB";
                value2 = "728";
                value3 = "299";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 6 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "50～55 HRC";
                value2 = "1165";
                value3 = "360";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 7 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "220～280 HB";
                value2 = "686";
                value3 = "287";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 7 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "48～55 HRC";
                value2 = "1143";
                value3 = "340";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 8 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "210～270 HB";
                value2 = "635";
                value3 = "273";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 8 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "40～45 HRC";
                value2 = "1056";
                value3 = "260";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 9 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "56～62 HRC";
                value2 = "1500";
                value3 = "470";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 9 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "561～713 HV";
                value2 = "1000";
                value3 = "375";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 10 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "56～62 HRC";
                value2 = "1500";
                value3 = "470";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 10 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "642～795 HV";
                value2 = "1000";
                value3 = "375";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 11 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "56～62 HRC";
                value2 = "1500";
                value3 = "470";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 12 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "230～250 HB";
                value2 = "668";
                value3 = "282";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 12 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "850～1100 HV";
                value2 = "1250";
                value3 = "425";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 13 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "56～62 HRC";
                value2 = "1500";
                value3 = "470";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 14 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "160～200 HB";
                value2 = "305";
                value3 = "124";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 15 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "180～210 HB";
                value2 = "318";
                value3 = "130";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 16 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "200～240 HB";
                value2 = "530";
                value3 = "234";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 16 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "270～300 HB";
                value2 = "633";
                value3 = "256";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 17 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "160～210 HB";
                value2 = "481";
                value3 = "223";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 17 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "200～250 HB";
                value2 = "530";
                value3 = "234";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 18 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "160～210 HB";
                value2 = "481";
                value3 = "223";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 18 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "200～250 HB";
                value2 = "530";
                value3 = "234";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 19 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "220～250 HB";
                value2 = "559";
                value3 = "240";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 20 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "175～210 HB";
                value2 = "552";
                value3 = "238";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 20 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "230～320 HB";
                value2 = "575";
                value3 = "243";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 21 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "180～240 HB";
                value2 = "504";
                value3 = "228";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 21 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "180～240 HB";
                value2 = "504";
                value3 = "228";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 22 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "160～210 HB";
                value2 = "481";
                value3 = "223";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 22 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "200～270 HB";
                value2 = "530";
                value3 = "234";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 23 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "210～270 HB";
                value2 = "635";
                value3 = "273";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 24 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "210～270 HB";
                value2 = "640";
                value3 = "274";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 25 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "190～240 HB";
                value2 = "516";
                value3 = "230";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 25 && this.cboHeat3.SelectedIndex == 1)
            {
                value1 = "260～300 HB";
                value2 = "707";
                value3 = "293";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 26 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "280～360 HB";
                value2 = "600";
                value3 = "222";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 27 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "245～335 HB";
                value2 = "556";
                value3 = "209";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 28 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "225～305 HB";
                value2 = "531";
                value3 = "201";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 29 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "190～270 HB";
                value2 = "487";
                value3 = "188";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 30 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "170～230 HB";
                value2 = "462";
                value3 = "180";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 31 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "170～290 HB";
                value2 = "331";
                value3 = "58";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 32 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "160～270 HB";
                value2 = "316";
                value3 = "55";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
            if (this.cboMaterialCard3.SelectedIndex == 33 && this.cboHeat3.SelectedIndex == 0)
            {
                value1 = "150～260 HB";
                value2 = "310";
                value3 = "53";
                this.txtHardValue3.Text = value1;
                this.txtContactValue3.Text = value2;
                this.txtBendValue3.Text = value3;
                return;
            }
        }

            # endregion
        //public static FrmFour objFour = null;
        private void frm3Next_Click(object sender, EventArgs e)
        {
            FrmDesign objDesign = new FrmDesign();
            this.Visible = false;//隐藏当前窗体

            this.btnMaterialOk_Click(null, e);
            objDesign.btnCaculDistance_Click(null, new EventArgs());//通过主窗体打开窗体4

            //if (objFour == null)
            //{
            //    objFour = new FrmFour();
            //    objFour.ShowDialog();
            //}
            //else
            //{
            //    objFour.Activate();
            //    objFour.Show();
            //    objFour.WindowState = FormWindowState.Normal;
            //}
        }

        private void btnMaterialOk_Click(object sender, EventArgs e)
        {
            //获取界面的数值
            double ContactValue1 = Convert.ToDouble(this.txtContactValue1.Text);
            double BendValue1 = Convert.ToDouble(this.txtBendValue1.Text);
            double ContactValue2 = Convert.ToDouble(this.txtContactValue2.Text);
            double BendValue2= Convert.ToDouble(this.txtBendValue2.Text);
            double ContactValue3 = Convert.ToDouble(this.txtContactValue3.Text);
            double BendValue3 = Convert.ToDouble(this.txtBendValue3.Text);
            string sunMatrials = this.cboMaterialCard1.Text + "，" + this.cboHeat1.Text + "处理，硬度值：" + this.txtHardValue1.Text + "，接触疲劳强度：" + ContactValue1 + "MPa，弯曲疲劳强度：" + BendValue1 + "MPa";
            string plaMatrials = this.cboMaterialCard2.Text + "，" + this.cboHeat2.Text + "处理，硬度值：" + this.txtHardValue2.Text + "，接触疲劳强度：" + ContactValue2 + "MPa，弯曲疲劳强度：" + BendValue2 + "MPa";
            string innMatrials = this.cboMaterialCard3.Text + "，" + this.cboHeat3.Text + "处理，硬度值：" + this.txtHardValue3.Text + "，接触疲劳强度：" + ContactValue3 + "MPa，弯曲疲劳强度：" + BendValue3 + "MPa";

            Common.PassValues.MaterialVala = this.cboMaterialCard1.Text;
            Common.PassValues.MaterialValc = this.cboMaterialCard2.Text;
            Common.PassValues.MaterialValb = this.cboMaterialCard3.Text;
            Common.PassValues.sunMaterial = sunMatrials;
            Common.PassValues.planMaterial = plaMatrials;
            Common.PassValues.innMaterial = innMatrials;
            Common.PassValues.ContactValue1 = ContactValue1;
            Common.PassValues.ContactValue2 = ContactValue2;
            Common.PassValues.ContactValue3 = ContactValue3;
            Common.PassValues.BendValue1 = BendValue1;
            Common.PassValues.BendValue2 = BendValue2;
            Common.PassValues.BendValue3 = BendValue3;
            //激发事件
            OperateGetValue3(sunMatrials, plaMatrials, innMatrials);
            this.Hide();
        }

        private void frm3Prim_Click(object sender, EventArgs e)
        {
            FrmDesign objDesign = new FrmDesign();
            this.Visible = false;//隐藏当前窗体
            objDesign.btnCaculGearNum_Click(null, new EventArgs());
        }

    }
}
