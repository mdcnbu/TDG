namespace FrmReducerDesignerApplication
{
    partial class FrmMaterials
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MaterialCardId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeatingType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HardnessValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactFatigueLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BendingFatigueLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMaterialNo = new System.Windows.Forms.Button();
            this.btnMaterialYes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaterialCardId,
            this.MaterialType,
            this.HeatingType,
            this.HardnessValue,
            this.ContactFatigueLimit,
            this.BendingFatigueLimit});
            this.dataGridView1.GridColor = System.Drawing.Color.Lime;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(702, 440);
            this.dataGridView1.TabIndex = 1;
            // 
            // MaterialCardId
            // 
            this.MaterialCardId.DataPropertyName = "MaterialCardId";
            this.MaterialCardId.HeaderText = "材料牌号";
            this.MaterialCardId.Name = "MaterialCardId";
            this.MaterialCardId.ReadOnly = true;
            // 
            // MaterialType
            // 
            this.MaterialType.DataPropertyName = "MaterialType";
            this.MaterialType.HeaderText = "材料类型";
            this.MaterialType.Name = "MaterialType";
            this.MaterialType.ReadOnly = true;
            // 
            // HeatingType
            // 
            this.HeatingType.DataPropertyName = "HeatingType";
            this.HeatingType.HeaderText = "热处理方式";
            this.HeatingType.Name = "HeatingType";
            this.HeatingType.ReadOnly = true;
            // 
            // HardnessValue
            // 
            this.HardnessValue.DataPropertyName = "HardnessValue";
            this.HardnessValue.HeaderText = "硬度值";
            this.HardnessValue.Name = "HardnessValue";
            this.HardnessValue.ReadOnly = true;
            // 
            // ContactFatigueLimit
            // 
            this.ContactFatigueLimit.DataPropertyName = "ContactFatigueLimit";
            this.ContactFatigueLimit.HeaderText = "接触疲劳强度";
            this.ContactFatigueLimit.Name = "ContactFatigueLimit";
            this.ContactFatigueLimit.ReadOnly = true;
            // 
            // BendingFatigueLimit
            // 
            this.BendingFatigueLimit.DataPropertyName = "BendingFatigueLimit";
            this.BendingFatigueLimit.HeaderText = "弯曲疲劳强度";
            this.BendingFatigueLimit.Name = "BendingFatigueLimit";
            this.BendingFatigueLimit.ReadOnly = true;
            // 
            // btnMaterialNo
            // 
            this.btnMaterialNo.Location = new System.Drawing.Point(648, 444);
            this.btnMaterialNo.Name = "btnMaterialNo";
            this.btnMaterialNo.Size = new System.Drawing.Size(55, 23);
            this.btnMaterialNo.TabIndex = 2;
            this.btnMaterialNo.Text = "取 消";
            this.btnMaterialNo.UseVisualStyleBackColor = true;
            this.btnMaterialNo.Click += new System.EventHandler(this.btnMaterialNo_Click);
            // 
            // btnMaterialYes
            // 
            this.btnMaterialYes.Location = new System.Drawing.Point(562, 444);
            this.btnMaterialYes.Name = "btnMaterialYes";
            this.btnMaterialYes.Size = new System.Drawing.Size(55, 23);
            this.btnMaterialYes.TabIndex = 3;
            this.btnMaterialYes.Text = "确 定";
            this.btnMaterialYes.UseVisualStyleBackColor = true;
            // 
            // FrmMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 467);
            this.Controls.Add(this.btnMaterialNo);
            this.Controls.Add(this.btnMaterialYes);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMaterials";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择材料";
            this.Load += new System.EventHandler(this.FrmMaterials_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCardId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialType;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeatingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn HardnessValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactFatigueLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn BendingFatigueLimit;
        private System.Windows.Forms.Button btnMaterialNo;
        private System.Windows.Forms.Button btnMaterialYes;
    }
}