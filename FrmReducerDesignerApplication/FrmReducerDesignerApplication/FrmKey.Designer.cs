namespace FrmReducerDesignerApplication
{
    partial class FrmKey
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvKeyValue = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.minShaftDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxShaftDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyHight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shaftKeyDeep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.circleKeyDeep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyValue)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKeyValue
            // 
            this.dgvKeyValue.AllowUserToAddRows = false;
            this.dgvKeyValue.AllowUserToDeleteRows = false;
            this.dgvKeyValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvKeyValue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvKeyValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeyValue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.minShaftDia,
            this.maxShaftDia,
            this.keyWidth,
            this.keyHight,
            this.shaftKeyDeep,
            this.circleKeyDeep});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKeyValue.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvKeyValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvKeyValue.Location = new System.Drawing.Point(0, 0);
            this.dgvKeyValue.MultiSelect = false;
            this.dgvKeyValue.Name = "dgvKeyValue";
            this.dgvKeyValue.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvKeyValue.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvKeyValue.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvKeyValue.RowTemplate.Height = 23;
            this.dgvKeyValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKeyValue.Size = new System.Drawing.Size(494, 233);
            this.dgvKeyValue.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(440, 236);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(53, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "确 定";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // minShaftDia
            // 
            this.minShaftDia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.minShaftDia.DataPropertyName = "minShaftDia";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.minShaftDia.DefaultCellStyle = dataGridViewCellStyle1;
            this.minShaftDia.HeaderText = "最小轴径";
            this.minShaftDia.Name = "minShaftDia";
            this.minShaftDia.ReadOnly = true;
            this.minShaftDia.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.minShaftDia.Width = 78;
            // 
            // maxShaftDia
            // 
            this.maxShaftDia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.maxShaftDia.DataPropertyName = "maxShaftDia";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.maxShaftDia.DefaultCellStyle = dataGridViewCellStyle2;
            this.maxShaftDia.HeaderText = "最大轴径";
            this.maxShaftDia.Name = "maxShaftDia";
            this.maxShaftDia.ReadOnly = true;
            this.maxShaftDia.Width = 78;
            // 
            // keyWidth
            // 
            this.keyWidth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.keyWidth.DataPropertyName = "keyWidth";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.keyWidth.DefaultCellStyle = dataGridViewCellStyle3;
            this.keyWidth.HeaderText = "键宽B";
            this.keyWidth.Name = "keyWidth";
            this.keyWidth.ReadOnly = true;
            this.keyWidth.Width = 60;
            // 
            // keyHight
            // 
            this.keyHight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.keyHight.DataPropertyName = "keyHight";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.keyHight.DefaultCellStyle = dataGridViewCellStyle4;
            this.keyHight.HeaderText = "键高h";
            this.keyHight.Name = "keyHight";
            this.keyHight.ReadOnly = true;
            this.keyHight.Width = 60;
            // 
            // shaftKeyDeep
            // 
            this.shaftKeyDeep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.shaftKeyDeep.DataPropertyName = "shaftKeyDeep";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shaftKeyDeep.DefaultCellStyle = dataGridViewCellStyle5;
            this.shaftKeyDeep.HeaderText = "轴键槽深";
            this.shaftKeyDeep.Name = "shaftKeyDeep";
            this.shaftKeyDeep.ReadOnly = true;
            this.shaftKeyDeep.Width = 78;
            // 
            // circleKeyDeep
            // 
            this.circleKeyDeep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.circleKeyDeep.DataPropertyName = "circleKeyDeep";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.circleKeyDeep.DefaultCellStyle = dataGridViewCellStyle6;
            this.circleKeyDeep.HeaderText = "毂键槽深";
            this.circleKeyDeep.Name = "circleKeyDeep";
            this.circleKeyDeep.ReadOnly = true;
            this.circleKeyDeep.Width = 78;
            // 
            // FrmKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 260);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvKeyValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "普通平键尺寸查询";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKeyValue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn minShaftDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxShaftDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyHight;
        private System.Windows.Forms.DataGridViewTextBoxColumn shaftKeyDeep;
        private System.Windows.Forms.DataGridViewTextBoxColumn circleKeyDeep;
    }
}