namespace FrmReducerDesignerApplication
{
    partial class FrmFour
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
            this.txtTorAC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlantaryNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInputTor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMLess = new System.Windows.Forms.TextBox();
            this.txtDisLess = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.txtU = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContactXY = new System.Windows.Forms.TextBox();
            this.txtφc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContactVal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtK = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboRealM = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDistNone = new System.Windows.Forms.TextBox();
            this.txtAngleBc = new System.Windows.Forms.TextBox();
            this.txtAngleAc = new System.Windows.Forms.TextBox();
            this.txtDisReal = new System.Windows.Forms.TextBox();
            this.txtRealβ = new System.Windows.Forms.TextBox();
            this.btnCalculateFour = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnFourBefore = new System.Windows.Forms.Button();
            this.btnFourNext = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTorAC);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPlantaryNum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtInputTor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtKc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "太阳轮-行星轮传动载荷";
            // 
            // txtTorAC
            // 
            this.txtTorAC.Location = new System.Drawing.Point(352, 68);
            this.txtTorAC.Name = "txtTorAC";
            this.txtTorAC.ReadOnly = true;
            this.txtTorAC.Size = new System.Drawing.Size(59, 23);
            this.txtTorAC.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "单对传动扭矩(N.m)";
            // 
            // txtPlantaryNum
            // 
            this.txtPlantaryNum.Location = new System.Drawing.Point(131, 65);
            this.txtPlantaryNum.Name = "txtPlantaryNum";
            this.txtPlantaryNum.ReadOnly = true;
            this.txtPlantaryNum.Size = new System.Drawing.Size(59, 23);
            this.txtPlantaryNum.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "行星轮数目Cs";
            // 
            // txtInputTor
            // 
            this.txtInputTor.Location = new System.Drawing.Point(352, 27);
            this.txtInputTor.Name = "txtInputTor";
            this.txtInputTor.ReadOnly = true;
            this.txtInputTor.Size = new System.Drawing.Size(59, 23);
            this.txtInputTor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "总体输入扭矩(N.m)";
            // 
            // txtKc
            // 
            this.txtKc.Location = new System.Drawing.Point(131, 27);
            this.txtKc.Name = "txtKc";
            this.txtKc.ReadOnly = true;
            this.txtKc.Size = new System.Drawing.Size(59, 23);
            this.txtKc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "载荷不均匀系数Kc";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMLess);
            this.groupBox2.Controls.Add(this.txtDisLess);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBox11);
            this.groupBox2.Controls.Add(this.txtU);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtContactXY);
            this.groupBox2.Controls.Add(this.txtφc);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtContactVal);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtK);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(23, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 137);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "初算太阳轮-行星轮中心距";
            // 
            // txtMLess
            // 
            this.txtMLess.Location = new System.Drawing.Point(131, 109);
            this.txtMLess.Name = "txtMLess";
            this.txtMLess.ReadOnly = true;
            this.txtMLess.Size = new System.Drawing.Size(59, 23);
            this.txtMLess.TabIndex = 1;
            // 
            // txtDisLess
            // 
            this.txtDisLess.Location = new System.Drawing.Point(352, 109);
            this.txtDisLess.Name = "txtDisLess";
            this.txtDisLess.Size = new System.Drawing.Size(59, 23);
            this.txtDisLess.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "中心距不小于";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "模数m不小于";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(352, 80);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(59, 23);
            this.textBox11.TabIndex = 1;
            // 
            // txtU
            // 
            this.txtU.Location = new System.Drawing.Point(131, 80);
            this.txtU.Name = "txtU";
            this.txtU.ReadOnly = true;
            this.txtU.Size = new System.Drawing.Size(59, 23);
            this.txtU.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(259, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "螺旋角系数Aa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "齿速比u=Zc/Za";
            // 
            // txtContactXY
            // 
            this.txtContactXY.Location = new System.Drawing.Point(352, 53);
            this.txtContactXY.Name = "txtContactXY";
            this.txtContactXY.ReadOnly = true;
            this.txtContactXY.Size = new System.Drawing.Size(59, 23);
            this.txtContactXY.TabIndex = 1;
            // 
            // txtφc
            // 
            this.txtφc.Location = new System.Drawing.Point(131, 53);
            this.txtφc.Name = "txtφc";
            this.txtφc.Size = new System.Drawing.Size(59, 23);
            this.txtφc.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(259, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "许用接触应力";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "齿宽系数φa";
            // 
            // txtContactVal
            // 
            this.txtContactVal.Location = new System.Drawing.Point(352, 26);
            this.txtContactVal.Name = "txtContactVal";
            this.txtContactVal.ReadOnly = true;
            this.txtContactVal.Size = new System.Drawing.Size(59, 23);
            this.txtContactVal.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(238, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "接触疲劳极限σHlim";
            // 
            // txtK
            // 
            this.txtK.Location = new System.Drawing.Point(131, 26);
            this.txtK.Name = "txtK";
            this.txtK.Size = new System.Drawing.Size(59, 23);
            this.txtK.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "综合载荷系数K";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboRealM);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtDistNone);
            this.groupBox3.Controls.Add(this.txtAngleBc);
            this.groupBox3.Controls.Add(this.txtAngleAc);
            this.groupBox3.Controls.Add(this.txtDisReal);
            this.groupBox3.Controls.Add(this.txtRealβ);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(23, 290);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(461, 106);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "初定几何参数";
            // 
            // cboRealM
            // 
            this.cboRealM.FormattingEnabled = true;
            this.cboRealM.Location = new System.Drawing.Point(131, 18);
            this.cboRealM.Name = "cboRealM";
            this.cboRealM.Size = new System.Drawing.Size(59, 25);
            this.cboRealM.TabIndex = 2;
            this.cboRealM.SelectedIndexChanged += new System.EventHandler(this.cboRealM_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(38, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 17);
            this.label15.TabIndex = 0;
            this.label15.Text = "a-c端面啮合角";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(259, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 17);
            this.label18.TabIndex = 0;
            this.label18.Text = "未变位中心距a";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(259, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 17);
            this.label17.TabIndex = 0;
            this.label17.Text = "c-b端面啮合角";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(265, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "实际中心距a\'";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(38, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "实际螺旋角β";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "取实际模数m";
            // 
            // txtDistNone
            // 
            this.txtDistNone.Location = new System.Drawing.Point(352, 47);
            this.txtDistNone.Name = "txtDistNone";
            this.txtDistNone.Size = new System.Drawing.Size(59, 23);
            this.txtDistNone.TabIndex = 1;
            // 
            // txtAngleBc
            // 
            this.txtAngleBc.Location = new System.Drawing.Point(352, 74);
            this.txtAngleBc.Name = "txtAngleBc";
            this.txtAngleBc.Size = new System.Drawing.Size(59, 23);
            this.txtAngleBc.TabIndex = 1;
            // 
            // txtAngleAc
            // 
            this.txtAngleAc.Location = new System.Drawing.Point(131, 74);
            this.txtAngleAc.Name = "txtAngleAc";
            this.txtAngleAc.Size = new System.Drawing.Size(59, 23);
            this.txtAngleAc.TabIndex = 1;
            // 
            // txtDisReal
            // 
            this.txtDisReal.Location = new System.Drawing.Point(352, 20);
            this.txtDisReal.Name = "txtDisReal";
            this.txtDisReal.Size = new System.Drawing.Size(59, 23);
            this.txtDisReal.TabIndex = 1;
            // 
            // txtRealβ
            // 
            this.txtRealβ.Location = new System.Drawing.Point(131, 47);
            this.txtRealβ.Name = "txtRealβ";
            this.txtRealβ.Size = new System.Drawing.Size(59, 23);
            this.txtRealβ.TabIndex = 1;
            // 
            // btnCalculateFour
            // 
            this.btnCalculateFour.Location = new System.Drawing.Point(60, 407);
            this.btnCalculateFour.Name = "btnCalculateFour";
            this.btnCalculateFour.Size = new System.Drawing.Size(75, 23);
            this.btnCalculateFour.TabIndex = 3;
            this.btnCalculateFour.Text = "确 定";
            this.btnCalculateFour.UseVisualStyleBackColor = true;
            this.btnCalculateFour.Click += new System.EventHandler(this.btnCalculateFour_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(164, 407);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "取 消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnFourBefore
            // 
            this.btnFourBefore.Location = new System.Drawing.Point(294, 407);
            this.btnFourBefore.Name = "btnFourBefore";
            this.btnFourBefore.Size = new System.Drawing.Size(75, 23);
            this.btnFourBefore.TabIndex = 3;
            this.btnFourBefore.Text = "上一步";
            this.btnFourBefore.UseVisualStyleBackColor = true;
            this.btnFourBefore.Click += new System.EventHandler(this.btnFourBefore_Click);
            // 
            // btnFourNext
            // 
            this.btnFourNext.Location = new System.Drawing.Point(419, 407);
            this.btnFourNext.Name = "btnFourNext";
            this.btnFourNext.Size = new System.Drawing.Size(75, 23);
            this.btnFourNext.TabIndex = 3;
            this.btnFourNext.Text = "下一步";
            this.btnFourNext.UseVisualStyleBackColor = true;
            this.btnFourNext.Click += new System.EventHandler(this.btnFourNext_Click);
            // 
            // FrmFour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(503, 436);
            this.Controls.Add(this.btnFourNext);
            this.Controls.Add(this.btnFourBefore);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCalculateFour);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "第四步：初算中心距";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTorAC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlantaryNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInputTor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMLess;
        private System.Windows.Forms.TextBox txtDisLess;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox txtU;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContactXY;
        private System.Windows.Forms.TextBox txtφc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtContactVal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDistNone;
        private System.Windows.Forms.TextBox txtAngleBc;
        private System.Windows.Forms.TextBox txtAngleAc;
        private System.Windows.Forms.TextBox txtDisReal;
        private System.Windows.Forms.TextBox txtRealβ;
        private System.Windows.Forms.Button btnCalculateFour;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnFourBefore;
        private System.Windows.Forms.Button btnFourNext;
        private System.Windows.Forms.ComboBox cboRealM;
    }
}