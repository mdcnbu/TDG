namespace FrmReducerDesignerApplication
{
    partial class MachineForce
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvWorkFactor = new System.Windows.Forms.DataGridView();
            this.WorkFeature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoverCharacter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPanel2 = new System.Windows.Forms.DataGridView();
            this.WorkingFeature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrivenCharacter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMachineForce = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 1);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvWorkFactor);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(515, 300);
            this.splitContainer1.SplitterDistance = 128;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvWorkFactor
            // 
            this.dgvWorkFactor.AllowUserToAddRows = false;
            this.dgvWorkFactor.AllowUserToDeleteRows = false;
            this.dgvWorkFactor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkFactor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWorkFactor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkFactor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkFeature,
            this.MoverCharacter});
            this.dgvWorkFactor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkFactor.GridColor = System.Drawing.Color.Tomato;
            this.dgvWorkFactor.Location = new System.Drawing.Point(0, 0);
            this.dgvWorkFactor.MultiSelect = false;
            this.dgvWorkFactor.Name = "dgvWorkFactor";
            this.dgvWorkFactor.ReadOnly = true;
            this.dgvWorkFactor.RowTemplate.Height = 23;
            this.dgvWorkFactor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWorkFactor.Size = new System.Drawing.Size(511, 124);
            this.dgvWorkFactor.TabIndex = 0;
            // 
            // WorkFeature
            // 
            this.WorkFeature.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.WorkFeature.DataPropertyName = "WorkFeature";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            this.WorkFeature.DefaultCellStyle = dataGridViewCellStyle2;
            this.WorkFeature.FillWeight = 62.2594F;
            this.WorkFeature.HeaderText = "工作特性";
            this.WorkFeature.Name = "WorkFeature";
            this.WorkFeature.ReadOnly = true;
            // 
            // MoverCharacter
            // 
            this.MoverCharacter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MoverCharacter.DataPropertyName = "MoverCharacter";
            this.MoverCharacter.FillWeight = 60.39162F;
            this.MoverCharacter.HeaderText = "原动机";
            this.MoverCharacter.Name = "MoverCharacter";
            this.MoverCharacter.ReadOnly = true;
            // 
            // dgvPanel2
            // 
            this.dgvPanel2.AllowUserToAddRows = false;
            this.dgvPanel2.AllowUserToDeleteRows = false;
            this.dgvPanel2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPanel2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPanel2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPanel2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPanel2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkingFeature,
            this.DrivenCharacter});
            this.dgvPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPanel2.GridColor = System.Drawing.Color.ForestGreen;
            this.dgvPanel2.Location = new System.Drawing.Point(0, 0);
            this.dgvPanel2.MultiSelect = false;
            this.dgvPanel2.Name = "dgvPanel2";
            this.dgvPanel2.ReadOnly = true;
            this.dgvPanel2.RowTemplate.Height = 23;
            this.dgvPanel2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPanel2.Size = new System.Drawing.Size(511, 164);
            this.dgvPanel2.TabIndex = 0;
            // 
            // WorkingFeature
            // 
            this.WorkingFeature.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.WorkingFeature.DataPropertyName = "WorkingFeature";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WorkingFeature.DefaultCellStyle = dataGridViewCellStyle4;
            this.WorkingFeature.HeaderText = "工作特性";
            this.WorkingFeature.Name = "WorkingFeature";
            this.WorkingFeature.ReadOnly = true;
            // 
            // DrivenCharacter
            // 
            this.DrivenCharacter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DrivenCharacter.DataPropertyName = "DrivenCharacter";
            this.DrivenCharacter.FillWeight = 10F;
            this.DrivenCharacter.HeaderText = "工作机";
            this.DrivenCharacter.Name = "DrivenCharacter";
            this.DrivenCharacter.ReadOnly = true;
            // 
            // btnMachineForce
            // 
            this.btnMachineForce.BackColor = System.Drawing.Color.Red;
            this.btnMachineForce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMachineForce.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMachineForce.ForeColor = System.Drawing.Color.Blue;
            this.btnMachineForce.Location = new System.Drawing.Point(452, 305);
            this.btnMachineForce.Name = "btnMachineForce";
            this.btnMachineForce.Size = new System.Drawing.Size(63, 27);
            this.btnMachineForce.TabIndex = 2;
            this.btnMachineForce.Text = "确 定";
            this.btnMachineForce.UseVisualStyleBackColor = false;
            this.btnMachineForce.Click += new System.EventHandler(this.btnMachineForce_Click);
            // 
            // MachineForce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(514, 332);
            this.Controls.Add(this.btnMachineForce);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MachineForce";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "原动机和工作机载荷示例";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MachineForce_FormClosed);
            this.Load += new System.EventHandler(this.MachineForce_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPanel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvWorkFactor;
        private System.Windows.Forms.DataGridView dgvPanel2;
        private System.Windows.Forms.Button btnMachineForce;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkingFeature;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrivenCharacter;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkFeature;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoverCharacter;
    }
}