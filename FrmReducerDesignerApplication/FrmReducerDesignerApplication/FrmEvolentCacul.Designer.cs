namespace FrmReducerDesignerApplication
{
    partial class FrmEvolentCacul
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResultInv = new System.Windows.Forms.TextBox();
            this.txtVal3 = new System.Windows.Forms.TextBox();
            this.txtVal2 = new System.Windows.Forms.TextBox();
            this.txtVal1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInvVal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtα = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtrad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtResultInv);
            this.groupBox1.Controls.Add(this.txtVal3);
            this.groupBox1.Controls.Add(this.txtVal2);
            this.groupBox1.Controls.Add(this.txtVal1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已知α求Invα";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(233, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "\'\'";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(164, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "\'";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "°";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(256, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "则Invα=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "α=";
            // 
            // txtResultInv
            // 
            this.txtResultInv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResultInv.Location = new System.Drawing.Point(310, 45);
            this.txtResultInv.Name = "txtResultInv";
            this.txtResultInv.ReadOnly = true;
            this.txtResultInv.Size = new System.Drawing.Size(104, 21);
            this.txtResultInv.TabIndex = 0;
            this.txtResultInv.Text = "0.0149043839";
            this.txtResultInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtVal3
            // 
            this.txtVal3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVal3.Location = new System.Drawing.Point(182, 45);
            this.txtVal3.Name = "txtVal3";
            this.txtVal3.Size = new System.Drawing.Size(49, 21);
            this.txtVal3.TabIndex = 2;
            this.txtVal3.Text = "0";
            this.txtVal3.TextChanged += new System.EventHandler(this.txtVal3_TextChanged);
            // 
            // txtVal2
            // 
            this.txtVal2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVal2.Location = new System.Drawing.Point(114, 44);
            this.txtVal2.Name = "txtVal2";
            this.txtVal2.Size = new System.Drawing.Size(49, 21);
            this.txtVal2.TabIndex = 1;
            this.txtVal2.Text = "0";
            this.txtVal2.TextChanged += new System.EventHandler(this.txtVal2_TextChanged);
            // 
            // txtVal1
            // 
            this.txtVal1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVal1.Location = new System.Drawing.Point(48, 44);
            this.txtVal1.Name = "txtVal1";
            this.txtVal1.Size = new System.Drawing.Size(49, 21);
            this.txtVal1.TabIndex = 0;
            this.txtVal1.Text = "20";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInvVal);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtα);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtrad);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 93);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "已知Invα反求α";
            // 
            // txtInvVal
            // 
            this.txtInvVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvVal.Location = new System.Drawing.Point(66, 45);
            this.txtInvVal.Name = "txtInvVal";
            this.txtInvVal.Size = new System.Drawing.Size(104, 21);
            this.txtInvVal.TabIndex = 0;
            this.txtInvVal.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(25, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Invα=";
            // 
            // txtα
            // 
            this.txtα.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtα.Location = new System.Drawing.Point(355, 45);
            this.txtα.Name = "txtα";
            this.txtα.ReadOnly = true;
            this.txtα.Size = new System.Drawing.Size(59, 21);
            this.txtα.TabIndex = 0;
            this.txtα.Text = "0";
            this.txtα.Click += new System.EventHandler(this.txtα_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(330, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "α=";
            // 
            // txtrad
            // 
            this.txtrad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtrad.Location = new System.Drawing.Point(253, 45);
            this.txtrad.Name = "txtrad";
            this.txtrad.ReadOnly = true;
            this.txtrad.Size = new System.Drawing.Size(71, 21);
            this.txtrad.TabIndex = 0;
            this.txtrad.Text = "0";
            this.txtrad.Click += new System.EventHandler(this.txtrad_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(207, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "则rad=";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(367, 212);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关 闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmEvolentCacul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 239);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEvolentCacul";
            this.Text = "渐开线函数计算";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtVal1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResultInv;
        private System.Windows.Forms.TextBox txtVal3;
        private System.Windows.Forms.TextBox txtVal2;
        private System.Windows.Forms.TextBox txtInvVal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtα;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtrad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
    }
}