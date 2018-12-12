namespace FrmReducerDesignerApplication
{
    partial class FrmDrawings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDrawings));
            this.btnCloseReducer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.添加文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前SW中的文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolViewStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.默认样式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.消除隐藏线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏线可见ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线框架ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.带边线上色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvFileList = new System.Windows.Forms.ListBox();
            this.btnSavePaths = new System.Windows.Forms.Button();
            this.btnBomTempl = new System.Windows.Forms.Button();
            this.btnCompTemplat = new System.Windows.Forms.Button();
            this.btnPrtTemplat = new System.Windows.Forms.Button();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.txtBomPath = new System.Windows.Forms.TextBox();
            this.txtCompTemplate = new System.Windows.Forms.TextBox();
            this.txtPrtTemplate = new System.Windows.Forms.TextBox();
            this.chkBom = new System.Windows.Forms.CheckBox();
            this.chkIsometric = new System.Windows.Forms.CheckBox();
            this.chkStardView = new System.Windows.Forms.CheckBox();
            this.rdoShadowThree = new System.Windows.Forms.RadioButton();
            this.chkStardardScale = new System.Windows.Forms.CheckBox();
            this.btnStartDrawing = new System.Windows.Forms.Button();
            this.rdoAddDimenAuto = new System.Windows.Forms.RadioButton();
            this.rdoAddDimenNo = new System.Windows.Forms.RadioButton();
            this.pbAssem = new System.Windows.Forms.ProgressBar();
            this.lblBar = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblViewStyle = new System.Windows.Forms.Label();
            this.chkDwg = new System.Windows.Forms.CheckBox();
            this.rdoShadowFirst = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCloseReducer
            // 
            this.btnCloseReducer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnCloseReducer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(163)))), ((int)(((byte)(220)))));
            this.btnCloseReducer.FlatAppearance.BorderSize = 0;
            this.btnCloseReducer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseReducer.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseReducer.ForeColor = System.Drawing.Color.White;
            this.btnCloseReducer.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseReducer.Image")));
            this.btnCloseReducer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseReducer.Location = new System.Drawing.Point(672, 1);
            this.btnCloseReducer.Name = "btnCloseReducer";
            this.btnCloseReducer.Size = new System.Drawing.Size(74, 27);
            this.btnCloseReducer.TabIndex = 1;
            this.btnCloseReducer.Text = "   返 回";
            this.btnCloseReducer.UseVisualStyleBackColor = false;
            this.btnCloseReducer.Click += new System.EventHandler(this.btnCloseReducer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "当前位置：[批量出工程图]";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnCloseReducer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 30);
            this.panel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(0, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(821, 2);
            this.label1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加文件ToolStripMenuItem,
            this.删除文件ToolStripMenuItem,
            this.清空文件ToolStripMenuItem,
            this.toolViewStyle});
            this.menuStrip1.Location = new System.Drawing.Point(-3, 33);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(344, 25);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 添加文件ToolStripMenuItem
            // 
            this.添加文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开文件ToolStripMenuItem,
            this.打开目录ToolStripMenuItem,
            this.当前SW中的文件ToolStripMenuItem});
            this.添加文件ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("添加文件ToolStripMenuItem.Image")));
            this.添加文件ToolStripMenuItem.Name = "添加文件ToolStripMenuItem";
            this.添加文件ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.添加文件ToolStripMenuItem.Text = "添加文件";
            // 
            // 打开文件ToolStripMenuItem
            // 
            this.打开文件ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打开文件ToolStripMenuItem.Image")));
            this.打开文件ToolStripMenuItem.Name = "打开文件ToolStripMenuItem";
            this.打开文件ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.打开文件ToolStripMenuItem.Text = "打开文件";
            this.打开文件ToolStripMenuItem.Click += new System.EventHandler(this.打开文件ToolStripMenuItem_Click);
            // 
            // 打开目录ToolStripMenuItem
            // 
            this.打开目录ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打开目录ToolStripMenuItem.Image")));
            this.打开目录ToolStripMenuItem.Name = "打开目录ToolStripMenuItem";
            this.打开目录ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.打开目录ToolStripMenuItem.Text = "打开目录";
            this.打开目录ToolStripMenuItem.Click += new System.EventHandler(this.打开目录ToolStripMenuItem_Click);
            // 
            // 当前SW中的文件ToolStripMenuItem
            // 
            this.当前SW中的文件ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("当前SW中的文件ToolStripMenuItem.Image")));
            this.当前SW中的文件ToolStripMenuItem.Name = "当前SW中的文件ToolStripMenuItem";
            this.当前SW中的文件ToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.当前SW中的文件ToolStripMenuItem.Text = "当前SW中的文件";
            this.当前SW中的文件ToolStripMenuItem.Click += new System.EventHandler(this.当前SW中的文件ToolStripMenuItem_Click);
            // 
            // 删除文件ToolStripMenuItem
            // 
            this.删除文件ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("删除文件ToolStripMenuItem.Image")));
            this.删除文件ToolStripMenuItem.Name = "删除文件ToolStripMenuItem";
            this.删除文件ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.删除文件ToolStripMenuItem.Text = "删除文件";
            this.删除文件ToolStripMenuItem.Click += new System.EventHandler(this.删除文件ToolStripMenuItem_Click);
            // 
            // 清空文件ToolStripMenuItem
            // 
            this.清空文件ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("清空文件ToolStripMenuItem.Image")));
            this.清空文件ToolStripMenuItem.Name = "清空文件ToolStripMenuItem";
            this.清空文件ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.清空文件ToolStripMenuItem.Text = "清空文件";
            this.清空文件ToolStripMenuItem.Click += new System.EventHandler(this.清空文件ToolStripMenuItem_Click);
            // 
            // toolViewStyle
            // 
            this.toolViewStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.默认样式ToolStripMenuItem,
            this.消除隐藏线ToolStripMenuItem,
            this.隐藏线可见ToolStripMenuItem,
            this.线框架ToolStripMenuItem,
            this.带边线上色ToolStripMenuItem,
            this.上色ToolStripMenuItem});
            this.toolViewStyle.Image = ((System.Drawing.Image)(resources.GetObject("toolViewStyle.Image")));
            this.toolViewStyle.Name = "toolViewStyle";
            this.toolViewStyle.Size = new System.Drawing.Size(84, 21);
            this.toolViewStyle.Text = "视图样式";
            // 
            // 默认样式ToolStripMenuItem
            // 
            this.默认样式ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("默认样式ToolStripMenuItem.Image")));
            this.默认样式ToolStripMenuItem.Name = "默认样式ToolStripMenuItem";
            this.默认样式ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.默认样式ToolStripMenuItem.Tag = "1";
            this.默认样式ToolStripMenuItem.Text = "默认样式";
            this.默认样式ToolStripMenuItem.Click += new System.EventHandler(this.消除隐藏线ToolStripMenuItem_Click);
            // 
            // 消除隐藏线ToolStripMenuItem
            // 
            this.消除隐藏线ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("消除隐藏线ToolStripMenuItem.Image")));
            this.消除隐藏线ToolStripMenuItem.Name = "消除隐藏线ToolStripMenuItem";
            this.消除隐藏线ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.消除隐藏线ToolStripMenuItem.Tag = "2";
            this.消除隐藏线ToolStripMenuItem.Text = "消除隐藏线";
            this.消除隐藏线ToolStripMenuItem.Click += new System.EventHandler(this.消除隐藏线ToolStripMenuItem_Click);
            // 
            // 隐藏线可见ToolStripMenuItem
            // 
            this.隐藏线可见ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("隐藏线可见ToolStripMenuItem.Image")));
            this.隐藏线可见ToolStripMenuItem.Name = "隐藏线可见ToolStripMenuItem";
            this.隐藏线可见ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.隐藏线可见ToolStripMenuItem.Tag = "3";
            this.隐藏线可见ToolStripMenuItem.Text = "隐藏线可见";
            this.隐藏线可见ToolStripMenuItem.Click += new System.EventHandler(this.消除隐藏线ToolStripMenuItem_Click);
            // 
            // 线框架ToolStripMenuItem
            // 
            this.线框架ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("线框架ToolStripMenuItem.Image")));
            this.线框架ToolStripMenuItem.Name = "线框架ToolStripMenuItem";
            this.线框架ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.线框架ToolStripMenuItem.Tag = "4";
            this.线框架ToolStripMenuItem.Text = "线框架";
            this.线框架ToolStripMenuItem.Click += new System.EventHandler(this.消除隐藏线ToolStripMenuItem_Click);
            // 
            // 带边线上色ToolStripMenuItem
            // 
            this.带边线上色ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("带边线上色ToolStripMenuItem.Image")));
            this.带边线上色ToolStripMenuItem.Name = "带边线上色ToolStripMenuItem";
            this.带边线上色ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.带边线上色ToolStripMenuItem.Tag = "5";
            this.带边线上色ToolStripMenuItem.Text = "带边线上色";
            this.带边线上色ToolStripMenuItem.Click += new System.EventHandler(this.消除隐藏线ToolStripMenuItem_Click);
            // 
            // 上色ToolStripMenuItem
            // 
            this.上色ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("上色ToolStripMenuItem.Image")));
            this.上色ToolStripMenuItem.Name = "上色ToolStripMenuItem";
            this.上色ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.上色ToolStripMenuItem.Tag = "6";
            this.上色ToolStripMenuItem.Text = "上色";
            this.上色ToolStripMenuItem.Click += new System.EventHandler(this.消除隐藏线ToolStripMenuItem_Click);
            // 
            // dgvFileList
            // 
            this.dgvFileList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvFileList.FormattingEnabled = true;
            this.dgvFileList.ItemHeight = 12;
            this.dgvFileList.Location = new System.Drawing.Point(3, 61);
            this.dgvFileList.Name = "dgvFileList";
            this.dgvFileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.dgvFileList.Size = new System.Drawing.Size(740, 266);
            this.dgvFileList.TabIndex = 17;
            // 
            // btnSavePaths
            // 
            this.btnSavePaths.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSavePaths.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSavePaths.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePaths.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePaths.Location = new System.Drawing.Point(3, 432);
            this.btnSavePaths.Name = "btnSavePaths";
            this.btnSavePaths.Size = new System.Drawing.Size(80, 27);
            this.btnSavePaths.TabIndex = 23;
            this.btnSavePaths.Text = "保存路径";
            this.btnSavePaths.UseVisualStyleBackColor = false;
            this.btnSavePaths.Click += new System.EventHandler(this.btnSavePaths_Click);
            // 
            // btnBomTempl
            // 
            this.btnBomTempl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBomTempl.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBomTempl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBomTempl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBomTempl.Location = new System.Drawing.Point(3, 400);
            this.btnBomTempl.Name = "btnBomTempl";
            this.btnBomTempl.Size = new System.Drawing.Size(80, 27);
            this.btnBomTempl.TabIndex = 25;
            this.btnBomTempl.Text = "明细表模板";
            this.btnBomTempl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBomTempl.UseVisualStyleBackColor = false;
            // 
            // btnCompTemplat
            // 
            this.btnCompTemplat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCompTemplat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCompTemplat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompTemplat.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompTemplat.Location = new System.Drawing.Point(3, 366);
            this.btnCompTemplat.Name = "btnCompTemplat";
            this.btnCompTemplat.Size = new System.Drawing.Size(80, 27);
            this.btnCompTemplat.TabIndex = 26;
            this.btnCompTemplat.Text = "部件图模板";
            this.btnCompTemplat.UseVisualStyleBackColor = false;
            // 
            // btnPrtTemplat
            // 
            this.btnPrtTemplat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPrtTemplat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPrtTemplat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrtTemplat.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrtTemplat.Location = new System.Drawing.Point(3, 332);
            this.btnPrtTemplat.Name = "btnPrtTemplat";
            this.btnPrtTemplat.Size = new System.Drawing.Size(80, 27);
            this.btnPrtTemplat.TabIndex = 27;
            this.btnPrtTemplat.Text = "零件图模板";
            this.btnPrtTemplat.UseVisualStyleBackColor = false;
            // 
            // txtSavePath
            // 
            this.txtSavePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSavePath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSavePath.Location = new System.Drawing.Point(86, 433);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(438, 26);
            this.txtSavePath.TabIndex = 18;
            // 
            // txtBomPath
            // 
            this.txtBomPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBomPath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBomPath.Location = new System.Drawing.Point(86, 401);
            this.txtBomPath.Name = "txtBomPath";
            this.txtBomPath.Size = new System.Drawing.Size(438, 26);
            this.txtBomPath.TabIndex = 20;
            // 
            // txtCompTemplate
            // 
            this.txtCompTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompTemplate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCompTemplate.Location = new System.Drawing.Point(86, 367);
            this.txtCompTemplate.Name = "txtCompTemplate";
            this.txtCompTemplate.Size = new System.Drawing.Size(438, 26);
            this.txtCompTemplate.TabIndex = 21;
            // 
            // txtPrtTemplate
            // 
            this.txtPrtTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrtTemplate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPrtTemplate.Location = new System.Drawing.Point(86, 333);
            this.txtPrtTemplate.Name = "txtPrtTemplate";
            this.txtPrtTemplate.Size = new System.Drawing.Size(438, 26);
            this.txtPrtTemplate.TabIndex = 22;
            // 
            // chkBom
            // 
            this.chkBom.AutoSize = true;
            this.chkBom.BackColor = System.Drawing.SystemColors.Control;
            this.chkBom.Location = new System.Drawing.Point(536, 409);
            this.chkBom.Name = "chkBom";
            this.chkBom.Size = new System.Drawing.Size(84, 16);
            this.chkBom.TabIndex = 28;
            this.chkBom.Text = "材料明细表";
            this.chkBom.UseVisualStyleBackColor = false;
            // 
            // chkIsometric
            // 
            this.chkIsometric.AutoSize = true;
            this.chkIsometric.BackColor = System.Drawing.SystemColors.Control;
            this.chkIsometric.Location = new System.Drawing.Point(536, 363);
            this.chkIsometric.Name = "chkIsometric";
            this.chkIsometric.Size = new System.Drawing.Size(84, 16);
            this.chkIsometric.TabIndex = 29;
            this.chkIsometric.Text = "等轴测视图";
            this.chkIsometric.UseVisualStyleBackColor = false;
            // 
            // chkStardView
            // 
            this.chkStardView.AutoSize = true;
            this.chkStardView.BackColor = System.Drawing.SystemColors.Control;
            this.chkStardView.Checked = true;
            this.chkStardView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStardView.Location = new System.Drawing.Point(536, 340);
            this.chkStardView.Name = "chkStardView";
            this.chkStardView.Size = new System.Drawing.Size(84, 16);
            this.chkStardView.TabIndex = 30;
            this.chkStardView.Text = "标准三视图";
            this.chkStardView.UseVisualStyleBackColor = false;
            // 
            // rdoShadowThree
            // 
            this.rdoShadowThree.AutoSize = true;
            this.rdoShadowThree.Location = new System.Drawing.Point(647, 433);
            this.rdoShadowThree.Name = "rdoShadowThree";
            this.rdoShadowThree.Size = new System.Drawing.Size(95, 16);
            this.rdoShadowThree.TabIndex = 31;
            this.rdoShadowThree.Text = "第三视角投影";
            this.rdoShadowThree.UseVisualStyleBackColor = true;
            // 
            // chkStardardScale
            // 
            this.chkStardardScale.AutoSize = true;
            this.chkStardardScale.Location = new System.Drawing.Point(536, 386);
            this.chkStardardScale.Name = "chkStardardScale";
            this.chkStardardScale.Size = new System.Drawing.Size(96, 16);
            this.chkStardardScale.TabIndex = 32;
            this.chkStardardScale.Text = "使用国标比例";
            this.chkStardardScale.UseVisualStyleBackColor = true;
            // 
            // btnStartDrawing
            // 
            this.btnStartDrawing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnStartDrawing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartDrawing.Location = new System.Drawing.Point(657, 465);
            this.btnStartDrawing.Name = "btnStartDrawing";
            this.btnStartDrawing.Size = new System.Drawing.Size(77, 29);
            this.btnStartDrawing.TabIndex = 33;
            this.btnStartDrawing.Text = "开 始";
            this.btnStartDrawing.UseVisualStyleBackColor = false;
            this.btnStartDrawing.Click += new System.EventHandler(this.btnStartDrawing_Click);
            // 
            // rdoAddDimenAuto
            // 
            this.rdoAddDimenAuto.AutoSize = true;
            this.rdoAddDimenAuto.Location = new System.Drawing.Point(10, 44);
            this.rdoAddDimenAuto.Name = "rdoAddDimenAuto";
            this.rdoAddDimenAuto.Size = new System.Drawing.Size(83, 16);
            this.rdoAddDimenAuto.TabIndex = 31;
            this.rdoAddDimenAuto.Text = "推荐的尺寸";
            this.rdoAddDimenAuto.UseVisualStyleBackColor = true;
            // 
            // rdoAddDimenNo
            // 
            this.rdoAddDimenNo.AutoSize = true;
            this.rdoAddDimenNo.Checked = true;
            this.rdoAddDimenNo.Location = new System.Drawing.Point(10, 22);
            this.rdoAddDimenNo.Name = "rdoAddDimenNo";
            this.rdoAddDimenNo.Size = new System.Drawing.Size(83, 16);
            this.rdoAddDimenNo.TabIndex = 31;
            this.rdoAddDimenNo.TabStop = true;
            this.rdoAddDimenNo.Text = "手动标尺寸";
            this.rdoAddDimenNo.UseVisualStyleBackColor = true;
            // 
            // pbAssem
            // 
            this.pbAssem.Location = new System.Drawing.Point(3, 499);
            this.pbAssem.Name = "pbAssem";
            this.pbAssem.Size = new System.Drawing.Size(711, 20);
            this.pbAssem.TabIndex = 35;
            // 
            // lblBar
            // 
            this.lblBar.Location = new System.Drawing.Point(717, 499);
            this.lblBar.Name = "lblBar";
            this.lblBar.Size = new System.Drawing.Size(31, 20);
            this.lblBar.TabIndex = 36;
            this.lblBar.Text = "0%";
            this.lblBar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoAddDimenAuto);
            this.groupBox1.Controls.Add(this.rdoAddDimenNo);
            this.groupBox1.Location = new System.Drawing.Point(640, 340);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(102, 62);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "尺寸标注";
            // 
            // lblViewStyle
            // 
            this.lblViewStyle.AutoSize = true;
            this.lblViewStyle.Location = new System.Drawing.Point(335, 71);
            this.lblViewStyle.Name = "lblViewStyle";
            this.lblViewStyle.Size = new System.Drawing.Size(11, 12);
            this.lblViewStyle.TabIndex = 38;
            this.lblViewStyle.Text = "1";
            this.lblViewStyle.Visible = false;
            // 
            // chkDwg
            // 
            this.chkDwg.AutoSize = true;
            this.chkDwg.BackColor = System.Drawing.SystemColors.Control;
            this.chkDwg.Location = new System.Drawing.Point(536, 432);
            this.chkDwg.Name = "chkDwg";
            this.chkDwg.Size = new System.Drawing.Size(108, 16);
            this.chkDwg.TabIndex = 28;
            this.chkDwg.Text = "另存为.dwg格式";
            this.chkDwg.UseVisualStyleBackColor = false;
            // 
            // rdoShadowFirst
            // 
            this.rdoShadowFirst.AutoSize = true;
            this.rdoShadowFirst.Checked = true;
            this.rdoShadowFirst.Location = new System.Drawing.Point(647, 411);
            this.rdoShadowFirst.Name = "rdoShadowFirst";
            this.rdoShadowFirst.Size = new System.Drawing.Size(95, 16);
            this.rdoShadowFirst.TabIndex = 31;
            this.rdoShadowFirst.TabStop = true;
            this.rdoShadowFirst.Text = "第一视角投影";
            this.rdoShadowFirst.UseVisualStyleBackColor = true;
            // 
            // FrmDrawings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 520);
            this.Controls.Add(this.lblViewStyle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblBar);
            this.Controls.Add(this.pbAssem);
            this.Controls.Add(this.btnStartDrawing);
            this.Controls.Add(this.chkStardardScale);
            this.Controls.Add(this.rdoShadowThree);
            this.Controls.Add(this.rdoShadowFirst);
            this.Controls.Add(this.chkDwg);
            this.Controls.Add(this.chkBom);
            this.Controls.Add(this.chkIsometric);
            this.Controls.Add(this.chkStardView);
            this.Controls.Add(this.btnSavePaths);
            this.Controls.Add(this.btnBomTempl);
            this.Controls.Add(this.btnCompTemplat);
            this.Controls.Add(this.btnPrtTemplat);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.txtBomPath);
            this.Controls.Add(this.txtCompTemplate);
            this.Controls.Add(this.txtPrtTemplate);
            this.Controls.Add(this.dgvFileList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmDrawings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDrawings_FormClosing);
            this.Load += new System.EventHandler(this.FrmDrawings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCloseReducer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 当前SW中的文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空文件ToolStripMenuItem;
        private System.Windows.Forms.ListBox dgvFileList;
        private System.Windows.Forms.Button btnSavePaths;
        private System.Windows.Forms.Button btnBomTempl;
        private System.Windows.Forms.Button btnCompTemplat;
        private System.Windows.Forms.Button btnPrtTemplat;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.TextBox txtBomPath;
        private System.Windows.Forms.TextBox txtCompTemplate;
        private System.Windows.Forms.TextBox txtPrtTemplate;
        private System.Windows.Forms.ToolStripMenuItem toolViewStyle;
        private System.Windows.Forms.CheckBox chkBom;
        private System.Windows.Forms.CheckBox chkIsometric;
        private System.Windows.Forms.CheckBox chkStardView;
        private System.Windows.Forms.RadioButton rdoShadowThree;
        private System.Windows.Forms.CheckBox chkStardardScale;
        private System.Windows.Forms.Button btnStartDrawing;
        private System.Windows.Forms.RadioButton rdoAddDimenAuto;
        private System.Windows.Forms.RadioButton rdoAddDimenNo;
        private System.Windows.Forms.ToolStripMenuItem 默认样式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 消除隐藏线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 隐藏线可见ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线框架ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 带边线上色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上色ToolStripMenuItem;
        private System.Windows.Forms.ProgressBar pbAssem;
        private System.Windows.Forms.Label lblBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblViewStyle;
        private System.Windows.Forms.CheckBox chkDwg;
        private System.Windows.Forms.RadioButton rdoShadowFirst;
    }
}