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
    public partial class FrmKey : Form
    {
        public FrmKey()
        {
            InitializeComponent();
            this.dgvKeyValue.AutoGenerateColumns = false;
            this.dgvKeyValue.DataSource = obj.GetAllVaule();
        }
        private KeyValueService obj = new KeyValueService();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
