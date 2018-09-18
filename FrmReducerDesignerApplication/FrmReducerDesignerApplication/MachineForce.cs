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
    public partial class MachineForce : Form
    {
        //[2]定义一个事件
        public event delegateMeasure OperateRadioEvent;
        public MachineForce()
        {
            InitializeComponent();
        }
        private WorkFeatureService objWorkService = new WorkFeatureService();
        private void MachineForce_Load(object sender, EventArgs e)
        {
            this.dgvWorkFactor.AutoGenerateColumns = false;
            this.dgvWorkFactor.DataSource = objWorkService.GetWorkFeature();
            this.dgvPanel2.AutoGenerateColumns = false;
            this.dgvPanel2.DataSource = objWorkService.GetWorkFeature2();
        }

        int rdoNum1, rdoNum2;
        private void btnMachineForce_Click(object sender, EventArgs e)
        {
            //获取选中行的value值
            if (this.dgvWorkFactor.CurrentRow.Index == 0)
            {
                rdoNum1 = 1;
            }
            if (this.dgvWorkFactor.CurrentRow.Index == 1)
            {
                rdoNum1 = 2;
            }
            if (this.dgvWorkFactor.CurrentRow.Index == 2)
            {
                rdoNum1 = 3;
            }
            if (this.dgvWorkFactor.CurrentRow.Index == 3)
            {
                rdoNum1 = 4;
            }
            if (this.dgvPanel2.CurrentRow.Index == 0)
            {
                rdoNum2 = 1;
            }
            if (this.dgvPanel2.CurrentRow.Index == 1)
            {
                rdoNum2 = 2;
            }
            if (this.dgvPanel2.CurrentRow.Index == 2)
            {
                rdoNum2 = 3;
            }
            if (this.dgvPanel2.CurrentRow.Index == 3)
            {
                rdoNum2 = 4;
            }
            //[3]激发事件
            OperateRadioEvent(rdoNum1, rdoNum2);
            this.Close();
        }

        private void MachineForce_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmOne.objFrm = null;
        }
    }
}
