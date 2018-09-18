namespace FrmReducerDesignerApplication
{
    partial class FrmSpurSty3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSpurSty3));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lboxRight = new System.Windows.Forms.ListBox();
            this.lboxLeft = new System.Windows.Forms.ListBox();
            this.btnAdd3 = new System.Windows.Forms.Button();
            this.btnDelet = new System.Windows.Forms.Button();
            this.btnAddR = new System.Windows.Forms.Button();
            this.btnAddL = new System.Windows.Forms.Button();
            this.txtLength3 = new System.Windows.Forms.TextBox();
            this.txtDiameter3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(318, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 50;
            this.label4.Text = "右端参数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 51;
            this.label3.Text = "左端参数";
            // 
            // lboxRight
            // 
            this.lboxRight.FormattingEnabled = true;
            this.lboxRight.ItemHeight = 12;
            this.lboxRight.Location = new System.Drawing.Point(181, 218);
            this.lboxRight.Name = "lboxRight";
            this.lboxRight.Size = new System.Drawing.Size(156, 112);
            this.lboxRight.TabIndex = 48;
            // 
            // lboxLeft
            // 
            this.lboxLeft.FormattingEnabled = true;
            this.lboxLeft.ItemHeight = 12;
            this.lboxLeft.Location = new System.Drawing.Point(11, 218);
            this.lboxLeft.Name = "lboxLeft";
            this.lboxLeft.Size = new System.Drawing.Size(155, 112);
            this.lboxLeft.TabIndex = 49;
            // 
            // btnAdd3
            // 
            this.btnAdd3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd3.Location = new System.Drawing.Point(262, 339);
            this.btnAdd3.Name = "btnAdd3";
            this.btnAdd3.Size = new System.Drawing.Size(75, 27);
            this.btnAdd3.TabIndex = 47;
            this.btnAdd3.Text = "结束添加";
            this.btnAdd3.UseVisualStyleBackColor = true;
            this.btnAdd3.Click += new System.EventHandler(this.btnAdd3_Click);
            // 
            // btnDelet
            // 
            this.btnDelet.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelet.Location = new System.Drawing.Point(181, 339);
            this.btnDelet.Name = "btnDelet";
            this.btnDelet.Size = new System.Drawing.Size(75, 27);
            this.btnDelet.TabIndex = 45;
            this.btnDelet.Text = "删除参数";
            this.btnDelet.UseVisualStyleBackColor = true;
            this.btnDelet.Click += new System.EventHandler(this.btnDelet_Click);
            // 
            // btnAddR
            // 
            this.btnAddR.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddR.Location = new System.Drawing.Point(91, 339);
            this.btnAddR.Name = "btnAddR";
            this.btnAddR.Size = new System.Drawing.Size(75, 27);
            this.btnAddR.TabIndex = 43;
            this.btnAddR.Text = "右边添加";
            this.btnAddR.UseVisualStyleBackColor = true;
            this.btnAddR.Click += new System.EventHandler(this.btnAddR_Click);
            // 
            // btnAddL
            // 
            this.btnAddL.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddL.Location = new System.Drawing.Point(10, 339);
            this.btnAddL.Name = "btnAddL";
            this.btnAddL.Size = new System.Drawing.Size(75, 27);
            this.btnAddL.TabIndex = 42;
            this.btnAddL.Text = "左边添加";
            this.btnAddL.UseVisualStyleBackColor = true;
            this.btnAddL.Click += new System.EventHandler(this.btnAddL_Click);
            // 
            // txtLength3
            // 
            this.txtLength3.Location = new System.Drawing.Point(262, 4);
            this.txtLength3.Name = "txtLength3";
            this.txtLength3.Size = new System.Drawing.Size(71, 21);
            this.txtLength3.TabIndex = 41;
            // 
            // txtDiameter3
            // 
            this.txtDiameter3.Location = new System.Drawing.Point(91, 5);
            this.txtDiameter3.Name = "txtDiameter3";
            this.txtDiameter3.Size = new System.Drawing.Size(71, 21);
            this.txtDiameter3.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "轴段长度(L)：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 46;
            this.label1.Text = "轴段直径(D)：";
            // 
            // FrmSpurSty3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 370);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lboxRight);
            this.Controls.Add(this.lboxLeft);
            this.Controls.Add(this.btnAdd3);
            this.Controls.Add(this.btnDelet);
            this.Controls.Add(this.btnAddR);
            this.Controls.Add(this.btnAddL);
            this.Controls.Add(this.txtLength3);
            this.Controls.Add(this.txtDiameter3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSpurSty3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "齿轴式参数输入";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSpurSty3_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lboxRight;
        private System.Windows.Forms.ListBox lboxLeft;
        private System.Windows.Forms.Button btnAdd3;
        private System.Windows.Forms.Button btnDelet;
        private System.Windows.Forms.Button btnAddR;
        private System.Windows.Forms.Button btnAddL;
        private System.Windows.Forms.TextBox txtLength3;
        private System.Windows.Forms.TextBox txtDiameter3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}