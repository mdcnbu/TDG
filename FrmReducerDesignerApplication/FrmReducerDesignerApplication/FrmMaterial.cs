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
    public partial class FrmMaterials : Form
    {
        public FrmMaterials()
        {
            InitializeComponent();
        }
        private MaterialService objMaterial = new MaterialService();
        private void FrmMaterials_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = objMaterial.GetMaterialValue();
        }

        private void btnMaterialNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
