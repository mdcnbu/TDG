namespace FrmReducerDesignerApplication
{
    partial class FrmCutTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCut = new System.Windows.Forms.DataGridView();
            this.ScaleValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GearNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Da0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ha0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolStyle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnY = new System.Windows.Forms.Button();
            this.btnN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCut)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCut
            // 
            this.dgvCut.AllowUserToAddRows = false;
            this.dgvCut.AllowUserToDeleteRows = false;
            this.dgvCut.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCut.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScaleValue,
            this.GearNum,
            this.D0,
            this.Da0,
            this.Ha0,
            this.ToolStyle});
            this.dgvCut.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCut.Location = new System.Drawing.Point(0, 0);
            this.dgvCut.MultiSelect = false;
            this.dgvCut.Name = "dgvCut";
            this.dgvCut.ReadOnly = true;
            this.dgvCut.RowTemplate.Height = 23;
            this.dgvCut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCut.Size = new System.Drawing.Size(578, 203);
            this.dgvCut.TabIndex = 0;
            // 
            // ScaleValue
            // 
            this.ScaleValue.DataPropertyName = "ScaleValue";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ScaleValue.DefaultCellStyle = dataGridViewCellStyle9;
            this.ScaleValue.HeaderText = "模数m";
            this.ScaleValue.Name = "ScaleValue";
            this.ScaleValue.ReadOnly = true;
            this.ScaleValue.Width = 60;
            // 
            // GearNum
            // 
            this.GearNum.DataPropertyName = "GearNum";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GearNum.DefaultCellStyle = dataGridViewCellStyle10;
            this.GearNum.HeaderText = "齿数Z0";
            this.GearNum.Name = "GearNum";
            this.GearNum.ReadOnly = true;
            this.GearNum.Width = 65;
            // 
            // D0
            // 
            this.D0.DataPropertyName = "D0";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.D0.DefaultCellStyle = dataGridViewCellStyle11;
            this.D0.HeaderText = "分度圆直径d0";
            this.D0.Name = "D0";
            this.D0.ReadOnly = true;
            this.D0.Width = 80;
            // 
            // Da0
            // 
            this.Da0.DataPropertyName = "Da0";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Da0.DefaultCellStyle = dataGridViewCellStyle12;
            this.Da0.HeaderText = "齿顶圆直径da0";
            this.Da0.Name = "Da0";
            this.Da0.ReadOnly = true;
            this.Da0.Width = 80;
            // 
            // Ha0
            // 
            this.Ha0.DataPropertyName = "Ha0";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Ha0.DefaultCellStyle = dataGridViewCellStyle13;
            this.Ha0.HeaderText = "齿顶高系数ha0*";
            this.Ha0.Name = "Ha0";
            this.Ha0.ReadOnly = true;
            this.Ha0.Width = 80;
            // 
            // ToolStyle
            // 
            this.ToolStyle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ToolStyle.DataPropertyName = "ToolStyle";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ToolStyle.DefaultCellStyle = dataGridViewCellStyle14;
            this.ToolStyle.HeaderText = "插刀型式";
            this.ToolStyle.Name = "ToolStyle";
            this.ToolStyle.ReadOnly = true;
            // 
            // btnY
            // 
            this.btnY.Location = new System.Drawing.Point(452, 209);
            this.btnY.Name = "btnY";
            this.btnY.Size = new System.Drawing.Size(56, 23);
            this.btnY.TabIndex = 1;
            this.btnY.Text = "确 定";
            this.btnY.UseVisualStyleBackColor = true;
            this.btnY.Click += new System.EventHandler(this.btnY_Click);
            // 
            // btnN
            // 
            this.btnN.Location = new System.Drawing.Point(514, 209);
            this.btnN.Name = "btnN";
            this.btnN.Size = new System.Drawing.Size(56, 23);
            this.btnN.TabIndex = 1;
            this.btnN.Text = "取 消";
            this.btnN.UseVisualStyleBackColor = true;
            this.btnN.Click += new System.EventHandler(this.btnN_Click);
            // 
            // FrmCutTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 235);
            this.Controls.Add(this.btnN);
            this.Controls.Add(this.btnY);
            this.Controls.Add(this.dgvCut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCutTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "插齿刀基本参数";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCut;
        private System.Windows.Forms.Button btnY;
        private System.Windows.Forms.Button btnN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScaleValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn GearNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn D0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Da0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ha0;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToolStyle;
    }
}