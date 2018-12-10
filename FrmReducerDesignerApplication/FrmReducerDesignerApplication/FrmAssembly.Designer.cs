namespace FrmReducerDesignerApplication
{
    partial class FrmAssembly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAssembly));
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCloseAssemb = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAssembly = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lBoxAssem1 = new System.Windows.Forms.ListBox();
            this.btnAssem1 = new System.Windows.Forms.Button();
            this.btnDelete1 = new System.Windows.Forms.Button();
            this.btnAdd1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lBoxFile3 = new System.Windows.Forms.ListBox();
            this.btnDelete3 = new System.Windows.Forms.Button();
            this.btnAdd3 = new System.Windows.Forms.Button();
            this.cboReduceType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAssSavePath = new System.Windows.Forms.TextBox();
            this.btnOFAssem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "当前位置：[参数化装配设计]";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnCloseAssemb);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 30);
            this.panel1.TabIndex = 13;
            // 
            // btnCloseAssemb
            // 
            this.btnCloseAssemb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnCloseAssemb.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnCloseAssemb.FlatAppearance.BorderSize = 0;
            this.btnCloseAssemb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseAssemb.ForeColor = System.Drawing.Color.White;
            this.btnCloseAssemb.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseAssemb.Image")));
            this.btnCloseAssemb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseAssemb.Location = new System.Drawing.Point(674, 2);
            this.btnCloseAssemb.Name = "btnCloseAssemb";
            this.btnCloseAssemb.Size = new System.Drawing.Size(74, 27);
            this.btnCloseAssemb.TabIndex = 3;
            this.btnCloseAssemb.Text = "   返 回";
            this.btnCloseAssemb.UseVisualStyleBackColor = false;
            this.btnCloseAssemb.Click += new System.EventHandler(this.btnCloseAssemb_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(0, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(821, 2);
            this.label1.TabIndex = 0;
            // 
            // btnAssembly
            // 
            this.btnAssembly.Location = new System.Drawing.Point(14, 256);
            this.btnAssembly.Name = "btnAssembly";
            this.btnAssembly.Size = new System.Drawing.Size(75, 23);
            this.btnAssembly.TabIndex = 14;
            this.btnAssembly.Text = "自动装配";
            this.btnAssembly.UseVisualStyleBackColor = true;
            this.btnAssembly.Click += new System.EventHandler(this.btnAssembly_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lBoxAssem1);
            this.groupBox1.Controls.Add(this.btnAssem1);
            this.groupBox1.Controls.Add(this.btnDelete1);
            this.groupBox1.Controls.Add(this.btnAdd1);
            this.groupBox1.Location = new System.Drawing.Point(11, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 298);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "子装配体1";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.ForestGreen;
            this.label3.Location = new System.Drawing.Point(9, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 71);
            this.label3.TabIndex = 4;
            this.label3.Text = "注：请选择行星架、输出轴部件、销轴、行星轮、行星架垫片";
            // 
            // lBoxAssem1
            // 
            this.lBoxAssem1.FormattingEnabled = true;
            this.lBoxAssem1.ItemHeight = 12;
            this.lBoxAssem1.Location = new System.Drawing.Point(101, 49);
            this.lBoxAssem1.Name = "lBoxAssem1";
            this.lBoxAssem1.Size = new System.Drawing.Size(258, 232);
            this.lBoxAssem1.TabIndex = 3;
            // 
            // btnAssem1
            // 
            this.btnAssem1.Location = new System.Drawing.Point(11, 258);
            this.btnAssem1.Name = "btnAssem1";
            this.btnAssem1.Size = new System.Drawing.Size(75, 23);
            this.btnAssem1.TabIndex = 2;
            this.btnAssem1.Text = "实现装配";
            this.btnAssem1.UseVisualStyleBackColor = true;
            this.btnAssem1.Click += new System.EventHandler(this.btnAssem1_Click);
            // 
            // btnDelete1
            // 
            this.btnDelete1.Location = new System.Drawing.Point(11, 76);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(75, 23);
            this.btnDelete1.TabIndex = 0;
            this.btnDelete1.Text = "删除零部件";
            this.btnDelete1.UseVisualStyleBackColor = true;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // btnAdd1
            // 
            this.btnAdd1.Location = new System.Drawing.Point(11, 47);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(75, 23);
            this.btnAdd1.TabIndex = 0;
            this.btnAdd1.Text = "选择零部件";
            this.btnAdd1.UseVisualStyleBackColor = true;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnAssembly);
            this.groupBox3.Controls.Add(this.lBoxFile3);
            this.groupBox3.Controls.Add(this.btnDelete3);
            this.groupBox3.Controls.Add(this.btnAdd3);
            this.groupBox3.Location = new System.Drawing.Point(376, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(372, 298);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "总装配体";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.ForestGreen;
            this.label5.Location = new System.Drawing.Point(12, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 94);
            this.label5.TabIndex = 4;
            this.label5.Text = "注：请选择机座、内齿轮、电机法兰及子装配体部件";
            // 
            // lBoxFile3
            // 
            this.lBoxFile3.FormattingEnabled = true;
            this.lBoxFile3.ItemHeight = 12;
            this.lBoxFile3.Location = new System.Drawing.Point(98, 47);
            this.lBoxFile3.Name = "lBoxFile3";
            this.lBoxFile3.Size = new System.Drawing.Size(262, 232);
            this.lBoxFile3.TabIndex = 3;
            // 
            // btnDelete3
            // 
            this.btnDelete3.Location = new System.Drawing.Point(14, 76);
            this.btnDelete3.Name = "btnDelete3";
            this.btnDelete3.Size = new System.Drawing.Size(75, 23);
            this.btnDelete3.TabIndex = 0;
            this.btnDelete3.Text = "删除零部件";
            this.btnDelete3.UseVisualStyleBackColor = true;
            this.btnDelete3.Click += new System.EventHandler(this.btnDelete3_Click);
            // 
            // btnAdd3
            // 
            this.btnAdd3.Location = new System.Drawing.Point(14, 47);
            this.btnAdd3.Name = "btnAdd3";
            this.btnAdd3.Size = new System.Drawing.Size(75, 23);
            this.btnAdd3.TabIndex = 0;
            this.btnAdd3.Text = "选择零部件";
            this.btnAdd3.UseVisualStyleBackColor = true;
            this.btnAdd3.Click += new System.EventHandler(this.btnAdd3_Click);
            // 
            // cboReduceType
            // 
            this.cboReduceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReduceType.FormattingEnabled = true;
            this.cboReduceType.Location = new System.Drawing.Point(147, 49);
            this.cboReduceType.Name = "cboReduceType";
            this.cboReduceType.Size = new System.Drawing.Size(229, 20);
            this.cboReduceType.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(9, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "请选择减速机类型：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(18, 415);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "请选择保存路径：";
            // 
            // txtAssSavePath
            // 
            this.txtAssSavePath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssSavePath.Location = new System.Drawing.Point(136, 414);
            this.txtAssSavePath.Name = "txtAssSavePath";
            this.txtAssSavePath.Size = new System.Drawing.Size(414, 26);
            this.txtAssSavePath.TabIndex = 18;
            // 
            // btnOFAssem
            // 
            this.btnOFAssem.BackColor = System.Drawing.Color.GreenYellow;
            this.btnOFAssem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOFAssem.Font = new System.Drawing.Font("Verdana", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOFAssem.Location = new System.Drawing.Point(549, 414);
            this.btnOFAssem.Name = "btnOFAssem";
            this.btnOFAssem.Size = new System.Drawing.Size(47, 25);
            this.btnOFAssem.TabIndex = 106;
            this.btnOFAssem.Text = "打开...";
            this.btnOFAssem.UseVisualStyleBackColor = false;
            // 
            // FrmAssembly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 520);
            this.Controls.Add(this.btnOFAssem);
            this.Controls.Add(this.txtAssSavePath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboReduceType);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAssembly";
            this.Text = "参数化装配";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAssembly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAssem1;
        private System.Windows.Forms.Button btnAdd1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lBoxAssem1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lBoxFile3;
        private System.Windows.Forms.Button btnAdd3;
        private System.Windows.Forms.Button btnDelete1;
        private System.Windows.Forms.Button btnDelete3;
        private System.Windows.Forms.ComboBox cboReduceType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAssSavePath;
        private System.Windows.Forms.Button btnCloseAssemb;
        private System.Windows.Forms.Button btnOFAssem;
    }
}