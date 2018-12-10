namespace FrmReducerDesignerApplication
{
    partial class FrmTwo
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoHelix = new System.Windows.Forms.RadioButton();
            this.rdoSPur = new System.Windows.Forms.RadioButton();
            this.txtHelixAngle = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRealRatio = new System.Windows.Forms.TextBox();
            this.txtRatioGap = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMYRatio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtj = new System.Windows.Forms.TextBox();
            this.txtcb = new System.Windows.Forms.TextBox();
            this.txtac = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoNoEqualAngle = new System.Windows.Forms.RadioButton();
            this.rdoOutInnMod = new System.Windows.Forms.RadioButton();
            this.rdoAngleMod = new System.Windows.Forms.RadioButton();
            this.rdoHighMod = new System.Windows.Forms.RadioButton();
            this.rdoNoMod = new System.Windows.Forms.RadioButton();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.btnPrimStep = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCaculate = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPlantGearNum = new System.Windows.Forms.TextBox();
            this.txtInnerGearNum = new System.Windows.Forms.TextBox();
            this.txtPlantnearyNum = new System.Windows.Forms.TextBox();
            this.txtSunGearNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMatch = new System.Windows.Forms.TextBox();
            this.txtConcidence = new System.Windows.Forms.TextBox();
            this.txtByMatch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdoHelix);
            this.groupBox4.Controls.Add(this.rdoSPur);
            this.groupBox4.Controls.Add(this.txtHelixAngle);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(249, 165);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(181, 134);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "齿轮类型";
            // 
            // rdoHelix
            // 
            this.rdoHelix.AutoSize = true;
            this.rdoHelix.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoHelix.Location = new System.Drawing.Point(87, 36);
            this.rdoHelix.Name = "rdoHelix";
            this.rdoHelix.Size = new System.Drawing.Size(50, 21);
            this.rdoHelix.TabIndex = 0;
            this.rdoHelix.TabStop = true;
            this.rdoHelix.Text = "斜齿";
            this.rdoHelix.UseVisualStyleBackColor = true;
            // 
            // rdoSPur
            // 
            this.rdoSPur.AutoSize = true;
            this.rdoSPur.Checked = true;
            this.rdoSPur.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoSPur.Location = new System.Drawing.Point(9, 36);
            this.rdoSPur.Name = "rdoSPur";
            this.rdoSPur.Size = new System.Drawing.Size(50, 21);
            this.rdoSPur.TabIndex = 0;
            this.rdoSPur.TabStop = true;
            this.rdoSPur.Text = "直齿";
            this.rdoSPur.UseVisualStyleBackColor = true;
            this.rdoSPur.CheckedChanged += new System.EventHandler(this.rdoSPur_CheckedChanged);
            // 
            // txtHelixAngle
            // 
            this.txtHelixAngle.Location = new System.Drawing.Point(82, 71);
            this.txtHelixAngle.Name = "txtHelixAngle";
            this.txtHelixAngle.Size = new System.Drawing.Size(55, 26);
            this.txtHelixAngle.TabIndex = 1;
            this.txtHelixAngle.Text = "0.00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(20, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "螺旋角(°)：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRealRatio);
            this.groupBox2.Controls.Add(this.txtRatioGap);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtMYRatio);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(19, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 134);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "减速比";
            // 
            // txtRealRatio
            // 
            this.txtRealRatio.Location = new System.Drawing.Point(92, 29);
            this.txtRealRatio.Name = "txtRealRatio";
            this.txtRealRatio.ReadOnly = true;
            this.txtRealRatio.Size = new System.Drawing.Size(65, 26);
            this.txtRealRatio.TabIndex = 1;
            // 
            // txtRatioGap
            // 
            this.txtRatioGap.Location = new System.Drawing.Point(92, 91);
            this.txtRatioGap.Name = "txtRatioGap";
            this.txtRatioGap.ReadOnly = true;
            this.txtRatioGap.Size = new System.Drawing.Size(65, 26);
            this.txtRatioGap.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(10, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "实际减速比i\'：";
            // 
            // txtMYRatio
            // 
            this.txtMYRatio.Location = new System.Drawing.Point(92, 60);
            this.txtMYRatio.Name = "txtMYRatio";
            this.txtMYRatio.ReadOnly = true;
            this.txtMYRatio.Size = new System.Drawing.Size(65, 26);
            this.txtMYRatio.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "名义减速比i：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(4, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "减速比偏差Δi：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtj);
            this.groupBox5.Controls.Add(this.txtcb);
            this.groupBox5.Controls.Add(this.txtac);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(437, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(185, 147);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "啮合角计算";
            // 
            // txtj
            // 
            this.txtj.Location = new System.Drawing.Point(124, 28);
            this.txtj.Name = "txtj";
            this.txtj.Size = new System.Drawing.Size(55, 26);
            this.txtj.TabIndex = 1;
            // 
            // txtcb
            // 
            this.txtcb.Location = new System.Drawing.Point(124, 98);
            this.txtcb.Name = "txtcb";
            this.txtcb.Size = new System.Drawing.Size(55, 26);
            this.txtcb.TabIndex = 1;
            // 
            // txtac
            // 
            this.txtac.Location = new System.Drawing.Point(124, 62);
            this.txtac.Name = "txtac";
            this.txtac.Size = new System.Drawing.Size(55, 26);
            this.txtac.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(6, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "初定c-b端面啮合角：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(6, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "初定a-c端面啮合角：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(6, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "j=(Zb-Zc)/(Za+Zc)：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoNoEqualAngle);
            this.groupBox1.Controls.Add(this.rdoOutInnMod);
            this.groupBox1.Controls.Add(this.rdoAngleMod);
            this.groupBox1.Controls.Add(this.rdoHighMod);
            this.groupBox1.Controls.Add(this.rdoNoMod);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(243, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 147);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "变位方式";
            // 
            // rdoNoEqualAngle
            // 
            this.rdoNoEqualAngle.AutoSize = true;
            this.rdoNoEqualAngle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoNoEqualAngle.Location = new System.Drawing.Point(5, 97);
            this.rdoNoEqualAngle.Name = "rdoNoEqualAngle";
            this.rdoNoEqualAngle.Size = new System.Drawing.Size(110, 21);
            this.rdoNoEqualAngle.TabIndex = 0;
            this.rdoNoEqualAngle.Text = "不等啮合角变位";
            this.rdoNoEqualAngle.UseVisualStyleBackColor = true;
            this.rdoNoEqualAngle.CheckedChanged += new System.EventHandler(this.rdoNoEqualAngle_CheckedChanged);
            // 
            // rdoOutInnMod
            // 
            this.rdoOutInnMod.AutoSize = true;
            this.rdoOutInnMod.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoOutInnMod.Location = new System.Drawing.Point(5, 119);
            this.rdoOutInnMod.Name = "rdoOutInnMod";
            this.rdoOutInnMod.Size = new System.Drawing.Size(182, 21);
            this.rdoOutInnMod.TabIndex = 0;
            this.rdoOutInnMod.Text = "外啮合角变位，内啮合高变位";
            this.rdoOutInnMod.UseVisualStyleBackColor = true;
            this.rdoOutInnMod.CheckedChanged += new System.EventHandler(this.rdoOutInnMod_CheckedChanged);
            // 
            // rdoAngleMod
            // 
            this.rdoAngleMod.AutoSize = true;
            this.rdoAngleMod.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoAngleMod.Location = new System.Drawing.Point(5, 75);
            this.rdoAngleMod.Name = "rdoAngleMod";
            this.rdoAngleMod.Size = new System.Drawing.Size(86, 21);
            this.rdoAngleMod.TabIndex = 0;
            this.rdoAngleMod.Text = "等角度变位";
            this.rdoAngleMod.UseVisualStyleBackColor = true;
            this.rdoAngleMod.CheckedChanged += new System.EventHandler(this.rdoAngleMod_CheckedChanged);
            // 
            // rdoHighMod
            // 
            this.rdoHighMod.AutoSize = true;
            this.rdoHighMod.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoHighMod.Location = new System.Drawing.Point(5, 53);
            this.rdoHighMod.Name = "rdoHighMod";
            this.rdoHighMod.Size = new System.Drawing.Size(74, 21);
            this.rdoHighMod.TabIndex = 0;
            this.rdoHighMod.Text = "高度变位";
            this.rdoHighMod.UseVisualStyleBackColor = true;
            this.rdoHighMod.CheckedChanged += new System.EventHandler(this.rdoHighMod_CheckedChanged);
            // 
            // rdoNoMod
            // 
            this.rdoNoMod.AutoSize = true;
            this.rdoNoMod.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoNoMod.Location = new System.Drawing.Point(5, 31);
            this.rdoNoMod.Name = "rdoNoMod";
            this.rdoNoMod.Size = new System.Drawing.Size(62, 21);
            this.rdoNoMod.TabIndex = 0;
            this.rdoNoMod.Text = "不变位";
            this.rdoNoMod.UseVisualStyleBackColor = true;
            this.rdoNoMod.CheckedChanged += new System.EventHandler(this.rdoNoMod_CheckedChanged);
            // 
            // btnNextStep
            // 
            this.btnNextStep.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNextStep.Location = new System.Drawing.Point(454, 343);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(55, 23);
            this.btnNextStep.TabIndex = 11;
            this.btnNextStep.Text = "下一步";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // btnPrimStep
            // 
            this.btnPrimStep.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrimStep.Location = new System.Drawing.Point(372, 343);
            this.btnPrimStep.Name = "btnPrimStep";
            this.btnPrimStep.Size = new System.Drawing.Size(55, 23);
            this.btnPrimStep.TabIndex = 12;
            this.btnPrimStep.Text = "上一步";
            this.btnPrimStep.UseVisualStyleBackColor = true;
            this.btnPrimStep.Click += new System.EventHandler(this.btnPrimStep_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(218, 343);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnCaculate
            // 
            this.btnCaculate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCaculate.Location = new System.Drawing.Point(127, 343);
            this.btnCaculate.Name = "btnCaculate";
            this.btnCaculate.Size = new System.Drawing.Size(55, 23);
            this.btnCaculate.TabIndex = 14;
            this.btnCaculate.Text = "确 定";
            this.btnCaculate.UseVisualStyleBackColor = true;
            this.btnCaculate.Click += new System.EventHandler(this.btnCaculate_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPlantGearNum);
            this.groupBox3.Controls.Add(this.txtInnerGearNum);
            this.groupBox3.Controls.Add(this.txtPlantnearyNum);
            this.groupBox3.Controls.Add(this.txtSunGearNum);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(19, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(214, 147);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "配齿计算";
            // 
            // txtPlantGearNum
            // 
            this.txtPlantGearNum.Location = new System.Drawing.Point(97, 116);
            this.txtPlantGearNum.Name = "txtPlantGearNum";
            this.txtPlantGearNum.Size = new System.Drawing.Size(55, 26);
            this.txtPlantGearNum.TabIndex = 1;
            // 
            // txtInnerGearNum
            // 
            this.txtInnerGearNum.Location = new System.Drawing.Point(97, 84);
            this.txtInnerGearNum.Name = "txtInnerGearNum";
            this.txtInnerGearNum.Size = new System.Drawing.Size(55, 26);
            this.txtInnerGearNum.TabIndex = 1;
            // 
            // txtPlantnearyNum
            // 
            this.txtPlantnearyNum.Location = new System.Drawing.Point(97, 20);
            this.txtPlantnearyNum.Name = "txtPlantnearyNum";
            this.txtPlantnearyNum.Size = new System.Drawing.Size(55, 26);
            this.txtPlantnearyNum.TabIndex = 1;
            this.txtPlantnearyNum.Text = "3";
            // 
            // txtSunGearNum
            // 
            this.txtSunGearNum.Location = new System.Drawing.Point(97, 52);
            this.txtSunGearNum.Name = "txtSunGearNum";
            this.txtSunGearNum.Size = new System.Drawing.Size(55, 26);
            this.txtSunGearNum.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(6, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "行星轮齿数Zc：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(6, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "内齿轮齿数Zb：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(6, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "太阳轮齿数Za：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(6, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 17);
            this.label15.TabIndex = 0;
            this.label15.Text = "行星轮数目Cs：";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(168, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 56);
            this.button1.TabIndex = 13;
            this.button1.Text = "查表法配齿";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.txtMatch);
            this.groupBox6.Controls.Add(this.txtConcidence);
            this.groupBox6.Controls.Add(this.txtByMatch);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox6.Location = new System.Drawing.Point(437, 165);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(185, 134);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "条件校验";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(10, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "装配条件：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(10, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "邻接条件：";
            // 
            // txtMatch
            // 
            this.txtMatch.BackColor = System.Drawing.Color.White;
            this.txtMatch.Location = new System.Drawing.Point(84, 33);
            this.txtMatch.Name = "txtMatch";
            this.txtMatch.ReadOnly = true;
            this.txtMatch.Size = new System.Drawing.Size(78, 26);
            this.txtMatch.TabIndex = 1;
            // 
            // txtConcidence
            // 
            this.txtConcidence.BackColor = System.Drawing.Color.White;
            this.txtConcidence.Location = new System.Drawing.Point(84, 65);
            this.txtConcidence.Name = "txtConcidence";
            this.txtConcidence.ReadOnly = true;
            this.txtConcidence.Size = new System.Drawing.Size(78, 26);
            this.txtConcidence.TabIndex = 1;
            // 
            // txtByMatch
            // 
            this.txtByMatch.BackColor = System.Drawing.Color.White;
            this.txtByMatch.Location = new System.Drawing.Point(84, 96);
            this.txtByMatch.Name = "txtByMatch";
            this.txtByMatch.ReadOnly = true;
            this.txtByMatch.Size = new System.Drawing.Size(78, 26);
            this.txtByMatch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "同心条件：";
            // 
            // FrmTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(634, 378);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNextStep);
            this.Controls.Add(this.btnPrimStep);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCaculate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmTwo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "第二步:齿数配比";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdoHelix;
        private System.Windows.Forms.RadioButton rdoSPur;
        private System.Windows.Forms.TextBox txtHelixAngle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRealRatio;
        private System.Windows.Forms.TextBox txtRatioGap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMYRatio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtcb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoAngleMod;
        private System.Windows.Forms.RadioButton rdoHighMod;
        private System.Windows.Forms.RadioButton rdoNoMod;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Button btnPrimStep;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCaculate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPlantGearNum;
        private System.Windows.Forms.TextBox txtInnerGearNum;
        private System.Windows.Forms.TextBox txtSunGearNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtByMatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlantnearyNum;
        private System.Windows.Forms.TextBox txtMatch;
        private System.Windows.Forms.TextBox txtConcidence;
        private System.Windows.Forms.TextBox txtj;
        private System.Windows.Forms.RadioButton rdoOutInnMod;
        private System.Windows.Forms.TextBox txtac;
        private System.Windows.Forms.RadioButton rdoNoEqualAngle;
    }
}