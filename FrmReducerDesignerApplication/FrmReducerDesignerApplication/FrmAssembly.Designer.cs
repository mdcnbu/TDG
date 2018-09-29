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
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAssembly = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lBoxAssem1 = new System.Windows.Forms.ListBox();
            this.btnAssem1 = new System.Windows.Forms.Button();
            this.btnDelete1 = new System.Windows.Forms.Button();
            this.btnAdd1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lBoxAssem2 = new System.Windows.Forms.ListBox();
            this.btnAssem2 = new System.Windows.Forms.Button();
            this.btnDelete2 = new System.Windows.Forms.Button();
            this.btnAdd2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lBoxFile3 = new System.Windows.Forms.ListBox();
            this.btnDelete3 = new System.Windows.Forms.Button();
            this.btnAdd3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 30);
            this.panel1.TabIndex = 13;
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
            this.groupBox1.Location = new System.Drawing.Point(11, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 187);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "子装配体1";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.ForestGreen;
            this.label3.Location = new System.Drawing.Point(9, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "注：请选择行星架和输出轴部件";
            // 
            // lBoxAssem1
            // 
            this.lBoxAssem1.FormattingEnabled = true;
            this.lBoxAssem1.ItemHeight = 12;
            this.lBoxAssem1.Location = new System.Drawing.Point(101, 37);
            this.lBoxAssem1.Name = "lBoxAssem1";
            this.lBoxAssem1.Size = new System.Drawing.Size(258, 124);
            this.lBoxAssem1.TabIndex = 3;
            // 
            // btnAssem1
            // 
            this.btnAssem1.Location = new System.Drawing.Point(11, 138);
            this.btnAssem1.Name = "btnAssem1";
            this.btnAssem1.Size = new System.Drawing.Size(75, 23);
            this.btnAssem1.TabIndex = 2;
            this.btnAssem1.Text = "实现装配";
            this.btnAssem1.UseVisualStyleBackColor = true;
            this.btnAssem1.Click += new System.EventHandler(this.btnAssem1_Click);
            // 
            // btnDelete1
            // 
            this.btnDelete1.Location = new System.Drawing.Point(11, 65);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(75, 23);
            this.btnDelete1.TabIndex = 0;
            this.btnDelete1.Text = "删除零部件";
            this.btnDelete1.UseVisualStyleBackColor = true;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // btnAdd1
            // 
            this.btnAdd1.Location = new System.Drawing.Point(11, 36);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(75, 23);
            this.btnAdd1.TabIndex = 0;
            this.btnAdd1.Text = "选择零部件";
            this.btnAdd1.UseVisualStyleBackColor = true;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lBoxAssem2);
            this.groupBox2.Controls.Add(this.btnAssem2);
            this.groupBox2.Controls.Add(this.btnDelete2);
            this.groupBox2.Controls.Add(this.btnAdd2);
            this.groupBox2.Location = new System.Drawing.Point(11, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 187);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "子装配体2";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.ForestGreen;
            this.label4.Location = new System.Drawing.Point(9, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 40);
            this.label4.TabIndex = 4;
            this.label4.Text = "注：请选择内齿轮、中心轮和行星轮";
            // 
            // lBoxAssem2
            // 
            this.lBoxAssem2.FormattingEnabled = true;
            this.lBoxAssem2.ItemHeight = 12;
            this.lBoxAssem2.Location = new System.Drawing.Point(101, 42);
            this.lBoxAssem2.Name = "lBoxAssem2";
            this.lBoxAssem2.Size = new System.Drawing.Size(258, 124);
            this.lBoxAssem2.TabIndex = 3;
            // 
            // btnAssem2
            // 
            this.btnAssem2.Location = new System.Drawing.Point(11, 143);
            this.btnAssem2.Name = "btnAssem2";
            this.btnAssem2.Size = new System.Drawing.Size(75, 23);
            this.btnAssem2.TabIndex = 2;
            this.btnAssem2.Text = "实现装配";
            this.btnAssem2.UseVisualStyleBackColor = true;
            this.btnAssem2.Click += new System.EventHandler(this.btnAssem2_Click);
            // 
            // btnDelete2
            // 
            this.btnDelete2.Location = new System.Drawing.Point(11, 71);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(75, 23);
            this.btnDelete2.TabIndex = 0;
            this.btnDelete2.Text = "删除零部件";
            this.btnDelete2.UseVisualStyleBackColor = true;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // btnAdd2
            // 
            this.btnAdd2.Location = new System.Drawing.Point(11, 42);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(75, 23);
            this.btnAdd2.TabIndex = 0;
            this.btnAdd2.Text = "选择零部件";
            this.btnAdd2.UseVisualStyleBackColor = true;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnAssembly);
            this.groupBox3.Controls.Add(this.lBoxFile3);
            this.groupBox3.Controls.Add(this.btnDelete3);
            this.groupBox3.Controls.Add(this.btnAdd3);
            this.groupBox3.Location = new System.Drawing.Point(393, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 397);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "总装配体";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.ForestGreen;
            this.label5.Location = new System.Drawing.Point(12, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 40);
            this.label5.TabIndex = 4;
            this.label5.Text = "注：请选择壳体及子装配体部件";
            // 
            // lBoxFile3
            // 
            this.lBoxFile3.FormattingEnabled = true;
            this.lBoxFile3.ItemHeight = 12;
            this.lBoxFile3.Location = new System.Drawing.Point(98, 47);
            this.lBoxFile3.Name = "lBoxFile3";
            this.lBoxFile3.Size = new System.Drawing.Size(245, 232);
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
            // 
            // btnAdd3
            // 
            this.btnAdd3.Location = new System.Drawing.Point(14, 47);
            this.btnAdd3.Name = "btnAdd3";
            this.btnAdd3.Size = new System.Drawing.Size(75, 23);
            this.btnAdd3.TabIndex = 0;
            this.btnAdd3.Text = "选择零部件";
            this.btnAdd3.UseVisualStyleBackColor = true;
            // 
            // FrmAssembly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 520);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAssembly";
            this.Text = "参数化装配";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAssembly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAssem1;
        private System.Windows.Forms.Button btnAdd1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdd2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lBoxAssem1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lBoxAssem2;
        private System.Windows.Forms.Button btnAssem2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lBoxFile3;
        private System.Windows.Forms.Button btnAdd3;
        private System.Windows.Forms.Button btnDelete1;
        private System.Windows.Forms.Button btnDelete2;
        private System.Windows.Forms.Button btnDelete3;
    }
}