using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using DAL;

namespace FrmReducerDesignerApplication
{
    public partial class FrmCutTool : Form
    {
        private CutToolService objCutTool = new CutToolService();
        public event ToolValue OperateValue;
        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="M"></param>
        public FrmCutTool(double M)
        {
            InitializeComponent();
            //初始化展示窗体数据
            this.dgvCut.AutoGenerateColumns = false;
            this.dgvCut.DataSource = objCutTool.GetToolValue(M);
        }
        //把选中的数据传递回窗体中
        private void btnY_Click(object sender, EventArgs e)
        {
            if (this.dgvCut.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择相关参数！");
                return;
            }
            //选中数据（Z0,Ha0）
            int a = dgvCut.CurrentRow.Index;
            string v1 = dgvCut.Rows[a].Cells["GearNum"].Value.ToString();
            string v2 = dgvCut.Rows[a].Cells["Ha0"].Value.ToString();
            double z0 = Convert.ToDouble(v1);
            double ha0 = Convert.ToDouble(v2);
            OperateValue(z0, ha0);
            this.Close();
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
