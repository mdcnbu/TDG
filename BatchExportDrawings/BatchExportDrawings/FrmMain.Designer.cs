namespace BatchExportDrawings
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDirecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTempToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tempFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tempFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvFileList = new System.Windows.Forms.DataGridView();
            this.FileListColum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TempColum = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PicShiJiaoColum = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ViewType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PicFangXColum = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bomColum = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DimesionColum = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtPrtTemplate = new System.Windows.Forms.TextBox();
            this.txtCompTemplate = new System.Windows.Forms.TextBox();
            this.chkStardView = new System.Windows.Forms.CheckBox();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnStartDrawing = new System.Windows.Forms.Button();
            this.txtBomPath = new System.Windows.Forms.TextBox();
            this.chkIsometric = new System.Windows.Forms.CheckBox();
            this.chkBom = new System.Windows.Forms.CheckBox();
            this.txtBendBom = new System.Windows.Forms.TextBox();
            this.chkBendBom = new System.Windows.Forms.CheckBox();
            this.chkBanJin = new System.Windows.Forms.CheckBox();
            this.lblSeprate = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.nUDLeft = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDRightUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nUDTitleHeigth = new System.Windows.Forms.NumericUpDown();
            this.btnPrtTemplat = new System.Windows.Forms.Button();
            this.btnCompTemplat = new System.Windows.Forms.Button();
            this.btnBomTempl = new System.Windows.Forms.Button();
            this.btnBendBomT = new System.Windows.Forms.Button();
            this.btnSavePaths = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rdoDrawScales = new System.Windows.Forms.RadioButton();
            this.rdoStardardScale = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBar = new System.Windows.Forms.Label();
            this.pbAssem = new System.Windows.Forms.ProgressBar();
            this.chkFlap = new System.Windows.Forms.CheckBox();
            this.操作演示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRightUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTitleHeigth)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.deleteFileToolStripMenuItem,
            this.clearFileToolStripMenuItem,
            this.loadTempToolStripMenuItem,
            this.操作演示ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDocToolStripMenuItem,
            this.openDirecToolStripMenuItem,
            this.openCurrentToolStripMenuItem});
            this.文件ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("文件ToolStripMenuItem.Image")));
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.文件ToolStripMenuItem.Text = "添加文件";
            // 
            // openDocToolStripMenuItem
            // 
            this.openDocToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openDocToolStripMenuItem.Image")));
            this.openDocToolStripMenuItem.Name = "openDocToolStripMenuItem";
            this.openDocToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openDocToolStripMenuItem.Text = "打开文件";
            this.openDocToolStripMenuItem.Click += new System.EventHandler(this.openDocToolStripMenuItem_Click);
            // 
            // openDirecToolStripMenuItem
            // 
            this.openDirecToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openDirecToolStripMenuItem.Image")));
            this.openDirecToolStripMenuItem.Name = "openDirecToolStripMenuItem";
            this.openDirecToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openDirecToolStripMenuItem.Text = "打开目录";
            this.openDirecToolStripMenuItem.Click += new System.EventHandler(this.openDirecToolStripMenuItem_Click);
            // 
            // openCurrentToolStripMenuItem
            // 
            this.openCurrentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openCurrentToolStripMenuItem.Image")));
            this.openCurrentToolStripMenuItem.Name = "openCurrentToolStripMenuItem";
            this.openCurrentToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openCurrentToolStripMenuItem.Text = "当前打开的文件";
            this.openCurrentToolStripMenuItem.Click += new System.EventHandler(this.openCurrentToolStripMenuItem_Click);
            // 
            // deleteFileToolStripMenuItem
            // 
            this.deleteFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteFileToolStripMenuItem.Image")));
            this.deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
            this.deleteFileToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.deleteFileToolStripMenuItem.Text = "删除文件";
            this.deleteFileToolStripMenuItem.Click += new System.EventHandler(this.deleteFileToolStripMenuItem_Click);
            // 
            // clearFileToolStripMenuItem
            // 
            this.clearFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clearFileToolStripMenuItem.Image")));
            this.clearFileToolStripMenuItem.Name = "clearFileToolStripMenuItem";
            this.clearFileToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.clearFileToolStripMenuItem.Text = "清空文件";
            this.clearFileToolStripMenuItem.Click += new System.EventHandler(this.clearFileToolStripMenuItem_Click);
            // 
            // loadTempToolStripMenuItem
            // 
            this.loadTempToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tempFilesToolStripMenuItem,
            this.tempFolderToolStripMenuItem});
            this.loadTempToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadTempToolStripMenuItem.Image")));
            this.loadTempToolStripMenuItem.Name = "loadTempToolStripMenuItem";
            this.loadTempToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.loadTempToolStripMenuItem.Text = "加载模板";
            // 
            // tempFilesToolStripMenuItem
            // 
            this.tempFilesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tempFilesToolStripMenuItem.Image")));
            this.tempFilesToolStripMenuItem.Name = "tempFilesToolStripMenuItem";
            this.tempFilesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.tempFilesToolStripMenuItem.Text = "选择模板文件";
            this.tempFilesToolStripMenuItem.Click += new System.EventHandler(this.tempFilesToolStripMenuItem_Click);
            // 
            // tempFolderToolStripMenuItem
            // 
            this.tempFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tempFolderToolStripMenuItem.Image")));
            this.tempFolderToolStripMenuItem.Name = "tempFolderToolStripMenuItem";
            this.tempFolderToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.tempFolderToolStripMenuItem.Text = "选择文件夹";
            this.tempFolderToolStripMenuItem.Click += new System.EventHandler(this.tempFolderToolStripMenuItem_Click);
            // 
            // dgvFileList
            // 
            this.dgvFileList.AllowUserToAddRows = false;
            this.dgvFileList.AllowUserToOrderColumns = true;
            this.dgvFileList.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFileList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileListColum,
            this.TempColum,
            this.PicShiJiaoColum,
            this.ViewType,
            this.PicFangXColum,
            this.bomColum,
            this.DimesionColum});
            this.dgvFileList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvFileList.GridColor = System.Drawing.Color.Black;
            this.dgvFileList.Location = new System.Drawing.Point(0, 27);
            this.dgvFileList.Name = "dgvFileList";
            this.dgvFileList.RowTemplate.Height = 23;
            this.dgvFileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFileList.Size = new System.Drawing.Size(1008, 321);
            this.dgvFileList.TabIndex = 1;
            this.dgvFileList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFileList_CellClick);
            this.dgvFileList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFileList_CellContentClick);
            this.dgvFileList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFileList_CellDoubleClick);
            this.dgvFileList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvFileList_DataError);
            this.dgvFileList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvFileList_MouseUp);
            // 
            // FileListColum
            // 
            this.FileListColum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileListColum.DataPropertyName = "FileListColum";
            this.FileListColum.HeaderText = "文件列表";
            this.FileListColum.Name = "FileListColum";
            this.FileListColum.ReadOnly = true;
            // 
            // TempColum
            // 
            this.TempColum.DataPropertyName = "TempColum";
            this.TempColum.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.TempColum.HeaderText = "模板选择";
            this.TempColum.Name = "TempColum";
            this.TempColum.Width = 310;
            // 
            // PicShiJiaoColum
            // 
            this.PicShiJiaoColum.DataPropertyName = "PicShiJiaoColum";
            this.PicShiJiaoColum.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.PicShiJiaoColum.HeaderText = "投影类型";
            this.PicShiJiaoColum.Name = "PicShiJiaoColum";
            this.PicShiJiaoColum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PicShiJiaoColum.Width = 75;
            // 
            // ViewType
            // 
            this.ViewType.DataPropertyName = "ViewType";
            this.ViewType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ViewType.HeaderText = "视图样式";
            this.ViewType.Name = "ViewType";
            this.ViewType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ViewType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ViewType.Width = 80;
            // 
            // PicFangXColum
            // 
            this.PicFangXColum.DataPropertyName = "PicFangXColum";
            this.PicFangXColum.FalseValue = "0";
            this.PicFangXColum.HeaderText = "等轴测";
            this.PicFangXColum.Name = "PicFangXColum";
            this.PicFangXColum.TrueValue = "1";
            this.PicFangXColum.Width = 52;
            // 
            // bomColum
            // 
            this.bomColum.DataPropertyName = "bomColum";
            this.bomColum.FalseValue = "0";
            this.bomColum.HeaderText = "明细表";
            this.bomColum.Name = "bomColum";
            this.bomColum.TrueValue = "1";
            this.bomColum.Width = 52;
            // 
            // DimesionColum
            // 
            this.DimesionColum.DataPropertyName = "DimesionColum";
            this.DimesionColum.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DimesionColum.HeaderText = "尺寸标注";
            this.DimesionColum.Name = "DimesionColum";
            this.DimesionColum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DimesionColum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DimesionColum.Width = 90;
            // 
            // txtPrtTemplate
            // 
            this.txtPrtTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrtTemplate.Location = new System.Drawing.Point(87, 365);
            this.txtPrtTemplate.Name = "txtPrtTemplate";
            this.txtPrtTemplate.Size = new System.Drawing.Size(599, 21);
            this.txtPrtTemplate.TabIndex = 3;
            // 
            // txtCompTemplate
            // 
            this.txtCompTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompTemplate.Location = new System.Drawing.Point(87, 399);
            this.txtCompTemplate.Name = "txtCompTemplate";
            this.txtCompTemplate.Size = new System.Drawing.Size(599, 21);
            this.txtCompTemplate.TabIndex = 3;
            // 
            // chkStardView
            // 
            this.chkStardView.AutoSize = true;
            this.chkStardView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.chkStardView.Checked = true;
            this.chkStardView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStardView.Location = new System.Drawing.Point(724, 6);
            this.chkStardView.Name = "chkStardView";
            this.chkStardView.Size = new System.Drawing.Size(84, 16);
            this.chkStardView.TabIndex = 6;
            this.chkStardView.Text = "标准三视图";
            this.chkStardView.UseVisualStyleBackColor = false;
            // 
            // txtSavePath
            // 
            this.txtSavePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSavePath.Location = new System.Drawing.Point(87, 501);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(599, 21);
            this.txtSavePath.TabIndex = 3;
            // 
            // btnStartDrawing
            // 
            this.btnStartDrawing.Location = new System.Drawing.Point(920, 503);
            this.btnStartDrawing.Name = "btnStartDrawing";
            this.btnStartDrawing.Size = new System.Drawing.Size(77, 29);
            this.btnStartDrawing.TabIndex = 9;
            this.btnStartDrawing.Text = "开 始";
            this.btnStartDrawing.UseVisualStyleBackColor = true;
            this.btnStartDrawing.Click += new System.EventHandler(this.btnStartDrawing_Click);
            // 
            // txtBomPath
            // 
            this.txtBomPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBomPath.Location = new System.Drawing.Point(87, 433);
            this.txtBomPath.Name = "txtBomPath";
            this.txtBomPath.Size = new System.Drawing.Size(599, 21);
            this.txtBomPath.TabIndex = 3;
            // 
            // chkIsometric
            // 
            this.chkIsometric.AutoSize = true;
            this.chkIsometric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.chkIsometric.Location = new System.Drawing.Point(814, 6);
            this.chkIsometric.Name = "chkIsometric";
            this.chkIsometric.Size = new System.Drawing.Size(84, 16);
            this.chkIsometric.TabIndex = 6;
            this.chkIsometric.Text = "等轴测视图";
            this.chkIsometric.UseVisualStyleBackColor = false;
            this.chkIsometric.Click += new System.EventHandler(this.chkIsometric_Click);
            // 
            // chkBom
            // 
            this.chkBom.AutoSize = true;
            this.chkBom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.chkBom.Location = new System.Drawing.Point(904, 6);
            this.chkBom.Name = "chkBom";
            this.chkBom.Size = new System.Drawing.Size(84, 16);
            this.chkBom.TabIndex = 6;
            this.chkBom.Text = "材料明细表";
            this.chkBom.UseVisualStyleBackColor = false;
            this.chkBom.CheckedChanged += new System.EventHandler(this.chkBom_CheckedChanged);
            // 
            // txtBendBom
            // 
            this.txtBendBom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBendBom.Location = new System.Drawing.Point(87, 467);
            this.txtBendBom.Name = "txtBendBom";
            this.txtBendBom.Size = new System.Drawing.Size(599, 21);
            this.txtBendBom.TabIndex = 3;
            // 
            // chkBendBom
            // 
            this.chkBendBom.AutoSize = true;
            this.chkBendBom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.chkBendBom.Location = new System.Drawing.Point(658, 6);
            this.chkBendBom.Name = "chkBendBom";
            this.chkBendBom.Size = new System.Drawing.Size(60, 16);
            this.chkBendBom.TabIndex = 10;
            this.chkBendBom.Text = "折弯表";
            this.chkBendBom.UseVisualStyleBackColor = false;
            // 
            // chkBanJin
            // 
            this.chkBanJin.AutoSize = true;
            this.chkBanJin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.chkBanJin.Location = new System.Drawing.Point(510, 6);
            this.chkBanJin.Name = "chkBanJin";
            this.chkBanJin.Size = new System.Drawing.Size(84, 16);
            this.chkBanJin.TabIndex = 10;
            this.chkBanJin.Text = "钣金展开图";
            this.chkBanJin.UseVisualStyleBackColor = false;
            // 
            // lblSeprate
            // 
            this.lblSeprate.BackColor = System.Drawing.Color.Black;
            this.lblSeprate.Location = new System.Drawing.Point(492, 6);
            this.lblSeprate.Name = "lblSeprate";
            this.lblSeprate.Size = new System.Drawing.Size(1, 15);
            this.lblSeprate.TabIndex = 11;
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(837, 383);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(89, 12);
            this.lblLeft.TabIndex = 12;
            this.lblLeft.Text = "模板左边框宽度";
            // 
            // nUDLeft
            // 
            this.nUDLeft.Location = new System.Drawing.Point(932, 378);
            this.nUDLeft.Name = "nUDLeft";
            this.nUDLeft.Size = new System.Drawing.Size(65, 21);
            this.nUDLeft.TabIndex = 13;
            this.nUDLeft.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(837, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "右上下边框宽度";
            // 
            // nUDRightUD
            // 
            this.nUDRightUD.Location = new System.Drawing.Point(932, 412);
            this.nUDRightUD.Name = "nUDRightUD";
            this.nUDRightUD.Size = new System.Drawing.Size(65, 21);
            this.nUDRightUD.TabIndex = 13;
            this.nUDRightUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(837, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "模板标题栏高度";
            // 
            // nUDTitleHeigth
            // 
            this.nUDTitleHeigth.Location = new System.Drawing.Point(932, 446);
            this.nUDTitleHeigth.Name = "nUDTitleHeigth";
            this.nUDTitleHeigth.Size = new System.Drawing.Size(65, 21);
            this.nUDTitleHeigth.TabIndex = 13;
            this.nUDTitleHeigth.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // btnPrtTemplat
            // 
            this.btnPrtTemplat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPrtTemplat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrtTemplat.Font = new System.Drawing.Font("Arial Black", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrtTemplat.Location = new System.Drawing.Point(685, 365);
            this.btnPrtTemplat.Name = "btnPrtTemplat";
            this.btnPrtTemplat.Size = new System.Drawing.Size(19, 21);
            this.btnPrtTemplat.TabIndex = 14;
            this.btnPrtTemplat.Text = "…";
            this.btnPrtTemplat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrtTemplat.UseVisualStyleBackColor = true;
            this.btnPrtTemplat.Click += new System.EventHandler(this.btnPrtTemplat_Click);
            // 
            // btnCompTemplat
            // 
            this.btnCompTemplat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCompTemplat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompTemplat.Font = new System.Drawing.Font("Arial Black", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompTemplat.Location = new System.Drawing.Point(685, 399);
            this.btnCompTemplat.Name = "btnCompTemplat";
            this.btnCompTemplat.Size = new System.Drawing.Size(19, 21);
            this.btnCompTemplat.TabIndex = 14;
            this.btnCompTemplat.Text = "…";
            this.btnCompTemplat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCompTemplat.UseVisualStyleBackColor = true;
            this.btnCompTemplat.Click += new System.EventHandler(this.btnCompTemplat_Click);
            // 
            // btnBomTempl
            // 
            this.btnBomTempl.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBomTempl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBomTempl.Font = new System.Drawing.Font("Arial Black", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBomTempl.Location = new System.Drawing.Point(685, 433);
            this.btnBomTempl.Name = "btnBomTempl";
            this.btnBomTempl.Size = new System.Drawing.Size(19, 21);
            this.btnBomTempl.TabIndex = 14;
            this.btnBomTempl.Text = "…";
            this.btnBomTempl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBomTempl.UseVisualStyleBackColor = true;
            this.btnBomTempl.Click += new System.EventHandler(this.btnBomTempl_Click);
            // 
            // btnBendBomT
            // 
            this.btnBendBomT.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBendBomT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBendBomT.Font = new System.Drawing.Font("Arial Black", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBendBomT.Location = new System.Drawing.Point(685, 467);
            this.btnBendBomT.Name = "btnBendBomT";
            this.btnBendBomT.Size = new System.Drawing.Size(19, 21);
            this.btnBendBomT.TabIndex = 14;
            this.btnBendBomT.Text = "…";
            this.btnBendBomT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBendBomT.UseVisualStyleBackColor = true;
            this.btnBendBomT.Click += new System.EventHandler(this.btnBendBomT_Click);
            // 
            // btnSavePaths
            // 
            this.btnSavePaths.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSavePaths.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePaths.Font = new System.Drawing.Font("Arial Black", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePaths.Location = new System.Drawing.Point(685, 501);
            this.btnSavePaths.Name = "btnSavePaths";
            this.btnSavePaths.Size = new System.Drawing.Size(19, 21);
            this.btnSavePaths.TabIndex = 14;
            this.btnSavePaths.Text = "…";
            this.btnSavePaths.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSavePaths.UseVisualStyleBackColor = true;
            this.btnSavePaths.Click += new System.EventHandler(this.btnSavePaths_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "零件图模板：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 403);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "部件图模板：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 437);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "明细表模板：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 471);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "折弯表模板：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 505);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "保存路径：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoDrawScales
            // 
            this.rdoDrawScales.AutoSize = true;
            this.rdoDrawScales.Checked = true;
            this.rdoDrawScales.Location = new System.Drawing.Point(791, 477);
            this.rdoDrawScales.Name = "rdoDrawScales";
            this.rdoDrawScales.Size = new System.Drawing.Size(107, 16);
            this.rdoDrawScales.TabIndex = 16;
            this.rdoDrawScales.TabStop = true;
            this.rdoDrawScales.Text = "调整到最优比例";
            this.rdoDrawScales.UseVisualStyleBackColor = true;
            // 
            // rdoStardardScale
            // 
            this.rdoStardardScale.AutoSize = true;
            this.rdoStardardScale.Location = new System.Drawing.Point(904, 478);
            this.rdoStardardScale.Name = "rdoStardardScale";
            this.rdoStardardScale.Size = new System.Drawing.Size(95, 16);
            this.rdoStardardScale.TabIndex = 16;
            this.rdoStardardScale.Text = "使用国标比例";
            this.rdoStardardScale.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblBar);
            this.panel1.Controls.Add(this.pbAssem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 538);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 19);
            this.panel1.TabIndex = 17;
            // 
            // lblBar
            // 
            this.lblBar.AutoSize = true;
            this.lblBar.Location = new System.Drawing.Point(981, 3);
            this.lblBar.Name = "lblBar";
            this.lblBar.Size = new System.Drawing.Size(17, 12);
            this.lblBar.TabIndex = 1;
            this.lblBar.Text = "0%";
            this.lblBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbAssem
            // 
            this.pbAssem.Location = new System.Drawing.Point(0, 0);
            this.pbAssem.Name = "pbAssem";
            this.pbAssem.Size = new System.Drawing.Size(976, 19);
            this.pbAssem.TabIndex = 0;
            // 
            // chkFlap
            // 
            this.chkFlap.AutoSize = true;
            this.chkFlap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.chkFlap.Location = new System.Drawing.Point(604, 6);
            this.chkFlap.Name = "chkFlap";
            this.chkFlap.Size = new System.Drawing.Size(48, 16);
            this.chkFlap.TabIndex = 10;
            this.chkFlap.Text = "翻转";
            this.chkFlap.UseVisualStyleBackColor = false;
            // 
            // 操作演示ToolStripMenuItem
            // 
            this.操作演示ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("操作演示ToolStripMenuItem.Image")));
            this.操作演示ToolStripMenuItem.Name = "操作演示ToolStripMenuItem";
            this.操作演示ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.操作演示ToolStripMenuItem.Text = "操作演示";
            this.操作演示ToolStripMenuItem.Click += new System.EventHandler(this.操作演示ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("关于ToolStripMenuItem.Image")));
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 557);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rdoStardardScale);
            this.Controls.Add(this.rdoDrawScales);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSavePaths);
            this.Controls.Add(this.btnBendBomT);
            this.Controls.Add(this.btnBomTempl);
            this.Controls.Add(this.btnCompTemplat);
            this.Controls.Add(this.btnPrtTemplat);
            this.Controls.Add(this.nUDTitleHeigth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nUDRightUD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nUDLeft);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.lblSeprate);
            this.Controls.Add(this.chkBanJin);
            this.Controls.Add(this.chkFlap);
            this.Controls.Add(this.chkBendBom);
            this.Controls.Add(this.btnStartDrawing);
            this.Controls.Add(this.chkBom);
            this.Controls.Add(this.chkIsometric);
            this.Controls.Add(this.chkStardView);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.txtBendBom);
            this.Controls.Add(this.txtBomPath);
            this.Controls.Add(this.txtCompTemplate);
            this.Controls.Add(this.txtPrtTemplate);
            this.Controls.Add(this.dgvFileList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "迈迪批量出图工具";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRightUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTitleHeigth)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDirecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearFileToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvFileList;
        private System.Windows.Forms.TextBox txtPrtTemplate;
        private System.Windows.Forms.TextBox txtCompTemplate;
        private System.Windows.Forms.CheckBox chkStardView;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnStartDrawing;
        private System.Windows.Forms.TextBox txtBomPath;
        private System.Windows.Forms.ToolStripMenuItem loadTempToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tempFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tempFolderToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkIsometric;
        private System.Windows.Forms.CheckBox chkBom;
        private System.Windows.Forms.TextBox txtBendBom;
        private System.Windows.Forms.CheckBox chkBendBom;
        private System.Windows.Forms.CheckBox chkBanJin;
        private System.Windows.Forms.Label lblSeprate;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.NumericUpDown nUDLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDRightUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nUDTitleHeigth;
        private System.Windows.Forms.Button btnPrtTemplat;
        private System.Windows.Forms.Button btnCompTemplat;
        private System.Windows.Forms.Button btnBomTempl;
        private System.Windows.Forms.Button btnBendBomT;
        private System.Windows.Forms.Button btnSavePaths;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileListColum;
        private System.Windows.Forms.DataGridViewComboBoxColumn TempColum;
        private System.Windows.Forms.DataGridViewComboBoxColumn PicShiJiaoColum;
        private System.Windows.Forms.DataGridViewComboBoxColumn ViewType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PicFangXColum;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bomColum;
        private System.Windows.Forms.DataGridViewComboBoxColumn DimesionColum;
        private System.Windows.Forms.RadioButton rdoDrawScales;
        private System.Windows.Forms.RadioButton rdoStardardScale;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBar;
        private System.Windows.Forms.ProgressBar pbAssem;
        private System.Windows.Forms.CheckBox chkFlap;
        private System.Windows.Forms.ToolStripMenuItem 操作演示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
    }
}

