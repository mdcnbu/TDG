using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BatchExportDrawings
{
    public partial class FrmResultShow : Form
    {
        List<string> files = new List<string>();
        private int nums;
        /// <summary>
        /// 初始化（构造方法）
        /// </summary>
        /// <param name="data">跳过的文件</param>
        /// <param name="num">成功的文件数</param>
        public FrmResultShow(List<string > data,int num)
        {
            InitializeComponent();
            files = data;//跳过的文件
            nums = num;//成功的文件
        }

        private void FrmResultShow_Load(object sender, EventArgs e)
        {
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
         
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            for(int i = 0; i < files.Count; i++)
            {
                dgvResult.Rows.Add("失败：存在同名文件，已跳过！");
                dgvResult.Rows[i].Cells["fileName"].Value = files[i];
            }
            dgvResult.Rows.Insert(0, "成功");
            dgvResult.Rows[0].Cells["fileName"].Value = "成功转换了" + nums + "个文件!" +"  （成功转换的文件已从列表中清除！）  ";
    
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
