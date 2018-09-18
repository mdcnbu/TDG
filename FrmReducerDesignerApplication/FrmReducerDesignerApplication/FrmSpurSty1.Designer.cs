namespace FrmReducerDesignerApplication
{
    partial class FrmSpurSty1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSpurSty1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboDiameter1 = new System.Windows.Forms.ComboBox();
            this.cboKeyHight1 = new System.Windows.Forms.ComboBox();
            this.cboKeyWidth1 = new System.Windows.Forms.ComboBox();
            this.btnStyle1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(271, 183);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // cboDiameter1
            // 
            this.cboDiameter1.FormattingEnabled = true;
            this.cboDiameter1.Location = new System.Drawing.Point(67, 8);
            this.cboDiameter1.Name = "cboDiameter1";
            this.cboDiameter1.Size = new System.Drawing.Size(74, 20);
            this.cboDiameter1.TabIndex = 24;
            // 
            // cboKeyHight1
            // 
            this.cboKeyHight1.FormattingEnabled = true;
            this.cboKeyHight1.Location = new System.Drawing.Point(67, 40);
            this.cboKeyHight1.Name = "cboKeyHight1";
            this.cboKeyHight1.Size = new System.Drawing.Size(74, 20);
            this.cboKeyHight1.TabIndex = 25;
            // 
            // cboKeyWidth1
            // 
            this.cboKeyWidth1.FormattingEnabled = true;
            this.cboKeyWidth1.Location = new System.Drawing.Point(207, 8);
            this.cboKeyWidth1.Name = "cboKeyWidth1";
            this.cboKeyWidth1.Size = new System.Drawing.Size(74, 20);
            this.cboKeyWidth1.TabIndex = 26;
            // 
            // btnStyle1
            // 
            this.btnStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStyle1.Location = new System.Drawing.Point(175, 34);
            this.btnStyle1.Name = "btnStyle1";
            this.btnStyle1.Size = new System.Drawing.Size(73, 27);
            this.btnStyle1.TabIndex = 23;
            this.btnStyle1.Text = "确 定";
            this.btnStyle1.UseVisualStyleBackColor = true;
            this.btnStyle1.Click += new System.EventHandler(this.btnStyle1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "键槽宽度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "键槽深度：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "轴孔直径：";
            // 
            // FrmSpurSty1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 258);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cboDiameter1);
            this.Controls.Add(this.cboKeyHight1);
            this.Controls.Add(this.cboKeyWidth1);
            this.Controls.Add(this.btnStyle1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSpurSty1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "实心式参数输入";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSpurSty1_FormClosed);
            this.Load += new System.EventHandler(this.FrmSpurSty1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cboDiameter1;
        private System.Windows.Forms.ComboBox cboKeyHight1;
        private System.Windows.Forms.ComboBox cboKeyWidth1;
        private System.Windows.Forms.Button btnStyle1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}