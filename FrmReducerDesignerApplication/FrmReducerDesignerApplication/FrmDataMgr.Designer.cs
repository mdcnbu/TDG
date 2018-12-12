namespace FrmReducerDesignerApplication
{
    partial class FrmDataMgr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataMgr));
            this.btnCloseData = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstResultShow = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveAS = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtContactVal = new System.Windows.Forms.TextBox();
            this.txtHeatType = new System.Windows.Forms.TextBox();
            this.txtCardId = new System.Windows.Forms.TextBox();
            this.txtHardVal = new System.Windows.Forms.TextBox();
            this.btnMaterialSql = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaterialType = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBendVal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCloseData
            // 
            this.btnCloseData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnCloseData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnCloseData.FlatAppearance.BorderSize = 0;
            this.btnCloseData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseData.ForeColor = System.Drawing.Color.White;
            this.btnCloseData.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseData.Image")));
            this.btnCloseData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseData.Location = new System.Drawing.Point(674, 2);
            this.btnCloseData.Name = "btnCloseData";
            this.btnCloseData.Size = new System.Drawing.Size(74, 27);
            this.btnCloseData.TabIndex = 3;
            this.btnCloseData.Text = "   返 回";
            this.btnCloseData.UseVisualStyleBackColor = false;
            this.btnCloseData.Click += new System.EventHandler(this.btnCloseData_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnCloseData);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 30);
            this.panel1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "当前位置：[系统数据管理]";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(0, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(821, 2);
            this.label1.TabIndex = 0;
            // 
            // lstResultShow
            // 
            this.lstResultShow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstResultShow.FormattingEnabled = true;
            this.lstResultShow.HorizontalScrollbar = true;
            this.lstResultShow.ItemHeight = 17;
            this.lstResultShow.Location = new System.Drawing.Point(23, 68);
            this.lstResultShow.Name = "lstResultShow";
            this.lstResultShow.Size = new System.Drawing.Size(314, 412);
            this.lstResultShow.TabIndex = 15;
            this.lstResultShow.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstResultShow_DrawItem);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(21, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "设计结果显示：";
            // 
            // btnSaveAS
            // 
            this.btnSaveAS.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveAS.Location = new System.Drawing.Point(229, 486);
            this.btnSaveAS.Name = "btnSaveAS";
            this.btnSaveAS.Size = new System.Drawing.Size(108, 31);
            this.btnSaveAS.TabIndex = 17;
            this.btnSaveAS.Text = "导出数据到Excel";
            this.btnSaveAS.UseVisualStyleBackColor = true;
            this.btnSaveAS.Click += new System.EventHandler(this.btnSaveAS_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtContactVal);
            this.groupBox1.Controls.Add(this.txtHeatType);
            this.groupBox1.Controls.Add(this.txtCardId);
            this.groupBox1.Controls.Add(this.txtHardVal);
            this.groupBox1.Controls.Add(this.btnMaterialSql);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtMaterialType);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBendVal);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(394, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 418);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "静态数据管理";
            // 
            // txtContactVal
            // 
            this.txtContactVal.Location = new System.Drawing.Point(109, 145);
            this.txtContactVal.Name = "txtContactVal";
            this.txtContactVal.Size = new System.Drawing.Size(100, 23);
            this.txtContactVal.TabIndex = 4;
            // 
            // txtHeatType
            // 
            this.txtHeatType.Location = new System.Drawing.Point(109, 91);
            this.txtHeatType.Name = "txtHeatType";
            this.txtHeatType.Size = new System.Drawing.Size(100, 23);
            this.txtHeatType.TabIndex = 2;
            // 
            // txtCardId
            // 
            this.txtCardId.Location = new System.Drawing.Point(109, 35);
            this.txtCardId.Name = "txtCardId";
            this.txtCardId.Size = new System.Drawing.Size(100, 23);
            this.txtCardId.TabIndex = 0;
            this.txtCardId.MouseEnter += new System.EventHandler(this.txtCardId_MouseEnter);
            // 
            // txtHardVal
            // 
            this.txtHardVal.Location = new System.Drawing.Point(109, 118);
            this.txtHardVal.Name = "txtHardVal";
            this.txtHardVal.Size = new System.Drawing.Size(100, 23);
            this.txtHardVal.TabIndex = 3;
            // 
            // btnMaterialSql
            // 
            this.btnMaterialSql.Location = new System.Drawing.Point(11, 214);
            this.btnMaterialSql.Name = "btnMaterialSql";
            this.btnMaterialSql.Size = new System.Drawing.Size(91, 28);
            this.btnMaterialSql.TabIndex = 6;
            this.btnMaterialSql.Text = "添加到数据库";
            this.btnMaterialSql.UseVisualStyleBackColor = true;
            this.btnMaterialSql.Click += new System.EventHandler(this.btnMaterialSql_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(109, 175);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 23);
            this.textBox5.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "材料接触疲劳极限:";
            // 
            // txtMaterialType
            // 
            this.txtMaterialType.Location = new System.Drawing.Point(109, 64);
            this.txtMaterialType.Name = "txtMaterialType";
            this.txtMaterialType.Size = new System.Drawing.Size(100, 23);
            this.txtMaterialType.TabIndex = 1;
            this.txtMaterialType.MouseEnter += new System.EventHandler(this.txtMaterialType_MouseEnter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "材料牌号:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "材料硬度值:";
            // 
            // txtBendVal
            // 
            this.txtBendVal.AutoSize = true;
            this.txtBendVal.Location = new System.Drawing.Point(3, 178);
            this.txtBendVal.Name = "txtBendVal";
            this.txtBendVal.Size = new System.Drawing.Size(107, 17);
            this.txtBendVal.TabIndex = 0;
            this.txtBendVal.Text = "材料弯曲疲劳极限:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "热处理方式:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "材料类型:";
            // 
            // FrmDataMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 520);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveAS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstResultShow);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDataMgr";
            this.Text = "FrmDataMgr";
            this.Load += new System.EventHandler(this.FrmDataMgr_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCloseData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstResultShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveAS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHeatType;
        private System.Windows.Forms.TextBox txtMaterialType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMaterialSql;
        private System.Windows.Forms.TextBox txtContactVal;
        private System.Windows.Forms.TextBox txtHardVal;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtBendVal;
        private System.Windows.Forms.TextBox txtCardId;
        private System.Windows.Forms.Label label12;
    }
}