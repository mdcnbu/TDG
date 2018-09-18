using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SolidWorks.Interop.sldworks;
using MD_SW_ConnectSW;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;

namespace BatchExportDrawings
{
    public partial class FrmMain : Form
    {

        #region   全局变量
        private static string openfolderpath = string.Empty;
        #endregion

        /// <summary>
        /// 构造函数（初始化）
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();

            this.loadTempToolStripMenuItem.Enabled = false;
            this.chkBom.Enabled = false;
            this.chkIsometric.Enabled = false;
            for (int i = 0; i < dgvFileList.ColumnCount; i++)
            {
                dgvFileList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;//禁用列表头排序
            }
            _exePath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//获取程序当前的启动目录
            objDraw = new Drawings.Drawings();
            objDraw.AssemBar = AssemBarStep;
        }
        #region 全局变量
        Drawings.Drawings objDraw;
        private SldWorks swApp;
        private ModelDoc2 swModel;
        Dictionary<string, string[]> dicFile = new Dictionary<string, string[]>();//获取界面数据的集合(string 放文件，string[]放后面几列的值)
        Dictionary<string, string> dicCompare = new Dictionary<string, string>();//临时存放选中的文件并进行排序
        private string temp1 = string.Empty;//零件模板路径
        private string temp2 = string.Empty;//部件模板路径
        private string bomTemp = string.Empty;//明细表模板路径
        private string path = string.Empty;//图纸保存路径
        private string bendTemp = string.Empty;//折弯表模板
        List<string> pathName = new List<string>();//sw当前打开的零件路径
        List<string> drawPaths = new List<string>();//零件路径下所有图纸路径
        private string _exePath = string.Empty;//程序启动目录
        private string prtPath = string.Empty;
        private string compPath = string.Empty;
        private string bomPath = string.Empty;
        private string bendPath = string.Empty;
        List<string> fileNames = new List<string>();//临时存放选取文件的文件名
        #endregion        
        #region 获取文件方法
        /// <summary>
        ///截取到最后一位字符
        /// </summary>
        /// <param name="sSubStr">原字符串路径</param>
        /// <param name="sSplitStr">分隔的字符</param>
        /// <returns></returns>
        public string SubLastString(string sSubStr, string sSplitStr)
        {
            int ipos = sSubStr.LastIndexOf(sSplitStr);
            return sSubStr.Substring(0, ipos + 1);
        }
        /// <summary>
        /// 获取用户所选文件（prt,asm）
        /// </summary>
        /// <returns></returns>
        private string[] GetFiles(string title, string filter, string key)//参数key为配置文件中的key值
        {
            string[] file = null;
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Multiselect = true;//该值确定是否可以选择多个文件
            openDialog.Title = title;
            openDialog.Filter = filter;
            System.Configuration.Configuration conf = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (File.Exists(conf.AppSettings.Settings[key].Value))//判断配置的路径是否存在
            {
                string dir = SubLastString(conf.AppSettings.Settings[key].Value, "\\");
                openDialog.InitialDirectory = dir;//设置初始路径为当前路径
            }
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                file = openDialog.FileNames;
                conf.AppSettings.Settings[key].Value = file[0];//把用户选取的文件赋给配置文件的value值
                conf.Save(ConfigurationSaveMode.Modified);//保存配置
            }
            else
            {
                return null;
            }
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");//刷新配置文件
            return file;
        }
        /// <summary>
        /// 获取文件夹下所有图纸路径
        /// </summary>
        /// <param name="direct"></param>
        /// <returns></returns>
        private void GetDrawPathByDir(string direct)
        {
            if (direct.Equals("")) return;
            DirectoryInfo dir = new DirectoryInfo(direct);
            FileInfo[] file = dir.GetFiles();//获取到文件夹中所有文件            
            foreach (FileInfo fi in file)
            {
                string fullPath = fi.FullName;
                if (fi.Extension.ToLower() == ".slddrw")
                {
                    drawPaths.Add(fullPath);
                }
            }
            /*不再获取子目录下文件
            DirectoryInfo[] diInfo = dir.GetDirectories();//获取到子目录文件夹名
            if (diInfo != null)
            {
                foreach (DirectoryInfo a in diInfo)
                {
                    string path = a.FullName;//子目录路径
                    GetDrawPathByDir(path);
                }
            }*/
        }
        /// <summary>
        /// 获取用户所选择文件夹下的所有文件（prt,asm）
        /// </summary>
        /// <returns></returns>
        private List<string> GetAllFiles(string description)
        {
            List<string> fileLists = new List<string>();
            string sPath = null;
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = description;
            if ( !openfolderpath.Equals(string.Empty))
            {
                folderDialog.SelectedPath = openfolderpath;
            }
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                sPath = folderDialog.SelectedPath;
                openfolderpath = sPath;
                //递归找到所有相关文件//找同级
                fileLists = GetFileByDir(sPath);
            }
            else
            {
                return null;
            }
            return fileLists;
        }
        /// <summary>
        /// 获取文件夹下包含指定字符串的所有文件
        /// </summary>
        /// <param name="directory">文件夹路径</param>       
        /// <returns></returns>
        public List<string> GetFileByDir(string directory)
        {
            List<string> fileList = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(directory);
            FileInfo[] file = dir.GetFiles();//获取到文件夹中所有文件            
            foreach (FileInfo fi in file)
            {
                string fullPath = fi.FullName;
                if ((fi.Extension == ".SLDASM" || fi.Extension == ".SLDPRT") && fi.Extension != ".drwdot")
                {
                    fileList.Add(fullPath);
                }
                if ((fi.Extension != ".SLDASM" || fi.Extension != ".SLDPRT") && fi.Extension == ".drwdot")
                {
                    fileList.Add(fullPath);
                }
            }
            DirectoryInfo[] diInfo = dir.GetDirectories();//获取到子目录文件夹名
            if (diInfo != null)
            {
                foreach (DirectoryInfo a in diInfo)
                {
                    string path = a.FullName;//子目录路径
                    GetFileByDir(path);
                }
            }
            return fileList;
        }
        /// <summary>
        /// 获取工程图模板文件
        /// </summary>
        /// <returns></returns>        
        public void GetTemp(ref string file, string title, string filter, string keys)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Multiselect = false;//该值确定是否可以选择多个文件
            openDialog.Title = title;
            openDialog.Filter = filter;
            System.Configuration.Configuration conf = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (File.Exists(conf.AppSettings.Settings[keys].Value))//判断配置的路径是否存在
            {
                string iniDir = SubLastString(conf.AppSettings.Settings[keys].Value, "\\");//分割文件字符串得到路径
                openDialog.InitialDirectory = iniDir;//设置初始路径为当前路径
            }
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                file = openDialog.FileName;//获取文件路径
                conf.AppSettings.Settings[keys].Value = file;//把用户选取的文件赋给配置文件的value值
                conf.Save(ConfigurationSaveMode.Modified);//保存配置
            }
            else
            {
                return;
            }
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");//刷新配置文件
        }
        #endregion
        /// <summary>
        /// 字典排序方法
        /// </summary>
        /// <param name="dic">排序对象</param>
        private void pairArry(Dictionary<string, string> dic, int num)
        {
            pbAssem.Maximum = dic.Count;
            pbAssem.Value = 0;
            if (dic.Count == 0)
            {
                pbAssem.Maximum = 1;
                pbAssem.Value = 1;
                lblBar.Text = (pbAssem.Value * 100 / pbAssem.Maximum).ToString() + "%";
            }
            this.TempColum.Items.Clear();//清除combox中的模板
            //按后缀字母排序
            List<KeyValuePair<string, string>> listPair = new List<KeyValuePair<string, string>>(dic);
            listPair.Sort(delegate (KeyValuePair<string, string> s1, KeyValuePair<string, string> s2)
            {
                return s1.Value.CompareTo(s2.Value);
            });
            dic.Clear();
            foreach (KeyValuePair<string, string> pair in listPair)
            {
                dic.Add(pair.Key, pair.Value);
            }
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, string> pairs in dic)
            {
                list.Add(pairs.Key);
            }
            for (int j = 0; j < dic.Count; j++)
            {
                this.dgvFileList.Rows.Add(list[j]);//第一列文件列表数据绑定
                                                   //进度条显示
                pbAssem.Value += 1;
                lblBar.Text = (pbAssem.Value * 100 / pbAssem.Maximum).ToString() + "%";
            }
            string tempPath1 = this.txtPrtTemplate.Text.Trim();//获取界面零件模板路径
            string tempPath2 = this.txtCompTemplate.Text.Trim();//获取界面零件模板路径
            string[] str = new string[] { tempPath1, tempPath2 };
            this.TempColum.Items.AddRange(str);
            for (int i = 0; i < list.Count; i++)
            {
                string extension = list[i].Substring(list[i].LastIndexOf(".") + 1).ToLower();
                //string ex = list[i].Substring(list[i].LastIndexOf("d") + 1);
                if (extension == "sldprt")
                {
                    //绑定默认模板文件到模板选择第一栏   
                    dgvFileList.Rows[num + i].Cells["TempColum"].Value = tempPath1;
                    DataGridViewComboBoxCell cell = dgvFileList.Rows[num + i].Cells["TempColum"] as DataGridViewComboBoxCell;
                    cell.Value = dgvFileList.Rows[num + i].Cells["TempColum"].Value.ToString();
                    dgvFileList.UpdateCellValue(cell.ColumnIndex, cell.RowIndex);
                }
                else
                {
                    dgvFileList.Rows[num + i].Cells["TempColum"].Value = tempPath2;//                     
                    DataGridViewComboBoxCell cell = dgvFileList.Rows[num + i].Cells["TempColum"] as DataGridViewComboBoxCell;
                    cell.Value = dgvFileList.Rows[num + i].Cells["TempColum"].Value.ToString();
                    dgvFileList.UpdateCellValue(cell.ColumnIndex, cell.RowIndex);
                }
            }
        }
        /// <summary>
        /// 判断添加的文件是否有重复文件（注意string为null）
        /// </summary>      
        /// <param name="newFile">新添加的文件</param>
        Dictionary<string, string[]> tempDic = new Dictionary<string, string[]>();//临时接收界面中的元素数===
        private Dictionary<string, string> isRepeat(Dictionary<string, string> newFile)//传过来的旧名称是集合或数组
        {
            //[1]获取界面展示的文件          
            tempDic.Clear();
            tempDic = FilesLists();
            Dictionary<string, string> newName = new Dictionary<string, string>();
            if (tempDic.Count == 0) return null;//若界面文件为空则返回
            //遍历集合并判断元素是否相同
            List<string> oldNames = new List<string>();//临时集合存放界面中的文件名
            foreach (var item in tempDic)
            {
                //把item.key进行字符串分割得到文件名称
                string oldName = item.Key.Substring(item.Key.LastIndexOf("\\") + 1);
                oldNames.Add(oldName);
            }
            var list = oldNames.Intersect(newFile.Values).ToArray();//新旧文件名称集合的交集(数组)
            foreach (string item in list)
            {
                ArrayList arryL = new ArrayList(newFile.Keys);
                for (int i = arryL.Count - 1; i >= 0; i--)
                {
                    string file = arryL[i].ToString();
                    string fileEx = file.Substring(file.LastIndexOf("\\") + 1);
                    if (fileEx == item) newFile.Remove(arryL[i].ToString());
                    continue;
                }
            }
            foreach (string key in newFile.Keys)
            {
                string extension = key.Substring(key.LastIndexOf("D") + 1, 3);
                newName.Add(key, extension);
            }
            return newName;
        }

        /// <summary>
        /// 打开文件夹选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] fileList = GetFiles("请选择要出图的零件或装配体文件", "零部件 (*.SLDASM;*.SLDPRT)|*.SLDASM;*.SLDPRT", "files");
            AddFileInfo(fileList);
        }
        /// <summary>
        /// 添加文件信息
        /// </summary>
        private void AddFileInfo(string[] fileList, params string[] originalFiles)
        {
            this.PicShiJiaoColum.Items.Clear();
            this.DimesionColum.Items.Clear();
            this.ViewType.Items.Clear();
            dicCompare.Clear();//清理掉字典里的文件
            drawPaths.Clear();//清理掉图纸集合中的数据
            fileNames.Clear();//清理掉临时文件名集合
            Dictionary<string, string> dicIsSame = new Dictionary<string, string>();
            int filenums = this.dgvFileList.Rows.Count;

            this.dgvFileList.AutoGenerateColumns = false;
            if (this.dgvFileList.Rows.Count > 0) this.dgvFileList.ClearSelection();//取消单元格的选择
            if (fileList != null)
            {
                if (this.txtSavePath.Text.Trim() == string.Empty)
                {
                    string drawPath = SubLastString(fileList[0], "\\");//【1】获取文件夹路径
                    this.txtSavePath.Text = drawPath;//把图纸保存路径显示出来
                    GetDrawPathByDir(drawPath);//【2】获取该路径下所有图纸文件
                }
                for (int i = 0; i < fileList.Length; i++)
                {
                    //先分割字符串再放到dictionary<k,v>中
                    string splitEx = fileList[i].Substring(fileList[i].LastIndexOf("D") + 1, 3);//截取到后缀的三个字母
                    string newName = fileList[i].Substring(fileList[i].LastIndexOf("\\") + 1);//获取到文件名
                    if ((originalFiles.Count() > 0 && !originalFiles.Contains(fileList[i]))|| originalFiles.Count() == 0)
                    {
                        dicCompare.Add(fileList[i], splitEx);
                        dicIsSame.Add(fileList[i], newName);//把用户选取的文件名加到集合里
                    }
                }
                //调用元素是否重复方法
                Dictionary<string, string> newFil = isRepeat(dicIsSame);
                if (newFil == null)
                {
                    pairArry(dicCompare, filenums);
                }
                else
                {
                    pairArry(newFil, filenums); //
                }
                addCombox();
            }
        }
        /// <summary>
        /// 向combox中添加元素
        /// </summary>
        private void addCombox()
        {
            string[] viewStr = new string[] { "第一视角", "第三视角" };
            this.PicShiJiaoColum.Items.AddRange(viewStr);
            string[] dimensionStr = new string[] { "手动标注尺寸", "推荐的尺寸" };
            this.DimesionColum.Items.AddRange(dimensionStr);
            string[] pictureType = new string[] { "默认", "线架图", "隐藏线可见", "消除隐藏线", "带边线上色", "上色" };
            this.ViewType.Items.AddRange(pictureType);
            for (int i = 0; i < this.dgvFileList.Rows.Count; i++)
            {
                this.DimesionColum.DefaultCellStyle.NullValue = dimensionStr[0];
                this.PicShiJiaoColum.DefaultCellStyle.NullValue = viewStr[0];
                this.ViewType.DefaultCellStyle.NullValue = pictureType[0];
            }
            this.dgvFileList.ClearSelection();
            this.loadTempToolStripMenuItem.Enabled = true;
            this.chkBom.Enabled = true;
            this.chkIsometric.Enabled = true;
        }

        /// <summary>
        /// 选择文件夹里所有文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openDirecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PicShiJiaoColum.Items.Clear();
            this.DimesionColum.Items.Clear();
            this.ViewType.Items.Clear();
            drawPaths.Clear();//清理掉图纸集合里的数据
            dicCompare.Clear();//清理掉字典里的文件
            int files = this.dgvFileList.Rows.Count;
            Dictionary<string, string> dicIsSame = new Dictionary<string, string>();
            List<string> fileList = GetAllFiles("请选择一个包含零件或装配体的文件夹");
            this.dgvFileList.AutoGenerateColumns = false;
            if (this.dgvFileList.Rows.Count > 0) this.dgvFileList.ClearSelection();//取消单元格的选择
            if (fileList != null&&fileList.Count()>0)
            {

                if (this.txtSavePath.Text.Trim() == string.Empty)
                {
                    string drawPath = SubLastString(fileList[0], "\\"); //【1】获取文件夹路径
                    this.txtSavePath.Text = drawPath;
                    //【2】获取该路径下所有图纸文件
                    GetDrawPathByDir(drawPath);
                }
                for (int i = 0; i < fileList.Count; i++)
                {//先分割字符串再放到dictionary<k,v>中
                    string splitEx = fileList[i].Substring(fileList[i].LastIndexOf("D") + 1, 3);//截取到后缀的三个字母
                    dicCompare.Add(fileList[i], splitEx);
                    string newName = fileList[i].Substring(fileList[i].LastIndexOf("\\") + 1);//获取到文件名
                    dicIsSame.Add(fileList[i], newName);//把用户选取的文件名加到集合里
                }
                //调用元素是否重复方法
                Dictionary<string, string> newFil = isRepeat(dicIsSame);
                if (newFil == null)
                { pairArry(dicCompare, files); }
                else
                {
                    pairArry(newFil, files);
                }
                addCombox();
            }
        }
        /// <summary>
        /// 打开当前sw中的文件
        /// </summary>      
        private void openCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (swApp == null)
                    swApp = (SldWorks)ConnectSW.iSwApp;
            object[] modelFile;
            pathName.Clear();
            drawPaths.Clear();
            this.PicShiJiaoColum.Items.Clear();
            this.DimesionColum.Items.Clear();
            this.ViewType.Items.Clear();
            dicCompare.Clear();//清理掉字典里的文件
            int files = this.dgvFileList.Rows.Count;
            Dictionary<string, string> dicIsSame = new Dictionary<string, string>();
            if (this.dgvFileList.Rows.Count > 0) this.dgvFileList.ClearSelection();
            int fileCount = swApp.GetDocumentCount();
            modelFile = (object[])swApp.GetDocuments();
            for (int i = 0; i < fileCount; i++)
            {
                swModel = modelFile[i] as ModelDoc2;
                    int type = swModel.GetType();
                    bool isVisible = swModel.Visible;
                    if ((type != 3 && isVisible))//当非图纸文件且界面可见时
                    {
                        string path = swModel.GetPathName();
                        pathName.Add(path);
                    }
                   
            }
            if (pathName.Count != 0)
            {
                if (this.txtSavePath.Text.Trim() == string.Empty)
                {
                    string drawPath = SubLastString(pathName[0], "\\");  //【1】获取文件夹路径
                    this.txtSavePath.Text = drawPath;
                    //【2】获取该路径下所有图纸文件
                    GetDrawPathByDir(drawPath);
                }
                for (int j = 0; j < pathName.Count; j++)
                {
                    //先分割字符串再放到dictionary<k,v>中
                    string splitEx = pathName[j].Substring(pathName[j].LastIndexOf("D") + 1, 3);//截取到后缀的三个字母
                    dicCompare.Add(pathName[j], splitEx);
                    string newName = pathName[j].Substring(pathName[j].LastIndexOf("\\") + 1);//获取到文件名
                    dicIsSame.Add(pathName[j], newName);//把用户选取的文件名加到集合里
                }
                //调用元素是否重复方法
                Dictionary<string, string> newFil = isRepeat(dicIsSame);
                if (newFil == null)
                { pairArry(dicCompare, files); }
                else
                {
                    pairArry(newFil, files);
                }
                addCombox();
            }
            else { return; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 点击单元格立即选择下拉框事件
        /// </summary>     
        private void dgvFileList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && dgvFileList[e.ColumnIndex, e.RowIndex] != null && !dgvFileList[e.ColumnIndex, e.RowIndex].ReadOnly)
            {
                DataGridViewComboBoxColumn comboBoxColumn = dgvFileList.Columns[e.ColumnIndex] as DataGridViewComboBoxColumn;
                if (comboBoxColumn != null)
                {
                    dgvFileList.BeginEdit(true);
                    DataGridViewComboBoxEditingControl comboBoxEditingControl = dgvFileList.EditingControl as DataGridViewComboBoxEditingControl;
                    if (comboBoxEditingControl != null)
                    {
                        comboBoxEditingControl.DroppedDown = true;
                    }
                }
            }
        }
        /// <summary>
        /// 删除选中行
        /// </summary>   
        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowCount = dgvFileList.SelectedRows.Count;//选中的行数
            if (this.dgvFileList.Rows.Count == 0)
            {
                MessageBox.Show("列表中无可操作文件！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rowCount < 1)
            {
                MessageBox.Show("请选中删除行！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                for (int i = rowCount; i > 0; i--)
                {
                    this.dgvFileList.Rows.RemoveAt(dgvFileList.SelectedRows[i - 1].Index);
                }
                if (this.dgvFileList.Rows.Count == 0)
                {
                    this.chkIsometric.Checked = false;
                    this.chkBom.Checked = false;
                    this.loadTempToolStripMenuItem.Enabled = false;//禁用加载模板按钮
                    this.chkIsometric.Enabled = false;
                    this.chkBom.Enabled = false;
                    this.txtSavePath.Text = string.Empty;//清空保存路径
                    //清空模板集合
                    this.TempColum.Items.Clear();
                }
            }
        }
        /// <summary>
        /// 清空列表所有文件
        /// </summary>     
        private void clearFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvFileList.Rows.Count == 0)
            {
                MessageBox.Show("列表中无可操作文件！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.dgvFileList.Rows.Clear();
                this.chkIsometric.Checked = false;
                this.chkBom.Checked = false;
                this.loadTempToolStripMenuItem.Enabled = false;
                this.chkBom.Enabled = false;
                this.chkIsometric.Enabled = false;
                this.TempColum.Items.Clear();
                this.txtSavePath.Text = string.Empty;
            }
        }
        /// <summary>
        /// 获取界面展示全部或选中的文件
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string[]> FilesLists()
        {
            dicFile.Clear();
            //存放dgv后面6列的值
            int selectedRows = this.dgvFileList.SelectedRows.Count;//选定行的数量
            if (selectedRows == 0)//选中的文件等于0
            {
                for (int i = 0; i < this.dgvFileList.Rows.Count; i++)
                {
                    if (this.dgvFileList.Rows[i].Cells[0].Value.ToString().Trim() != string.Empty)
                    {
                        string key = this.dgvFileList.Rows[i].Cells[0].Value.ToString();
                        //[1]先找到相关列
                        DataGridViewComboBoxCell dgvCmbCel1 = dgvFileList.Rows[i].Cells["TempColum"] as DataGridViewComboBoxCell;
                        DataGridViewComboBoxCell dgvCmbCel2 = dgvFileList.Rows[i].Cells["PicShiJiaoColum"] as DataGridViewComboBoxCell;
                        DataGridViewComboBoxCell dgvCmbCel3 = dgvFileList.Rows[i].Cells["ViewType"] as DataGridViewComboBoxCell;
                        DataGridViewComboBoxCell dgvCmbCel4 = dgvFileList.Rows[i].Cells["DimesionColum"] as DataGridViewComboBoxCell;
                        DataGridViewCheckBoxCell dgvChkCell1 = dgvFileList.Rows[i].Cells["PicFangXColum"] as DataGridViewCheckBoxCell;
                        DataGridViewCheckBoxCell dgvChkCell2 = dgvFileList.Rows[i].Cells["bomColum"] as DataGridViewCheckBoxCell;
                        //[2]再找到相关列的value值                       
                        string v1 = dgvCmbCel1.EditedFormattedValue.ToString();//把每列选中的元素加到数组里         
                        string v2 = dgvCmbCel2.EditedFormattedValue.ToString();
                        string v3 = dgvCmbCel3.EditedFormattedValue.ToString();
                        string v4 = dgvChkCell1.EditedFormattedValue.ToString();//获取等轴测的选中状态
                        string v5 = dgvChkCell2.EditedFormattedValue.ToString();//获取Bom的选中状态
                        string v6 = dgvCmbCel4.EditedFormattedValue.ToString();
                        string[] columValue = new string[] { v1, v2, v3, v4, v5, v6 };
                        dicFile.Add(key, columValue);//把所有行单元格中的值加到集合里
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.dgvFileList.Rows.Count; i++)
                {
                    if (this.dgvFileList.Rows[i].Selected)
                    {
                        string key = this.dgvFileList.Rows[i].Cells[0].Value.ToString();
                        DataGridViewComboBoxCell dgvCmbCel1 = dgvFileList.Rows[i].Cells["TempColum"] as DataGridViewComboBoxCell;
                        DataGridViewComboBoxCell dgvCmbCel2 = dgvFileList.Rows[i].Cells["PicShiJiaoColum"] as DataGridViewComboBoxCell;
                        DataGridViewComboBoxCell dgvCmbCel3 = dgvFileList.Rows[i].Cells["ViewType"] as DataGridViewComboBoxCell;
                        DataGridViewComboBoxCell dgvCmbCel4 = dgvFileList.Rows[i].Cells["DimesionColum"] as DataGridViewComboBoxCell;
                        DataGridViewCheckBoxCell dgvChkCell1 = dgvFileList.Rows[i].Cells["PicFangXColum"] as DataGridViewCheckBoxCell;
                        DataGridViewCheckBoxCell dgvChkCell2 = dgvFileList.Rows[i].Cells["bomColum"] as DataGridViewCheckBoxCell;
                        //[2]再找到相关列的value值
                        string v1 = dgvCmbCel1.EditedFormattedValue.ToString();//把每列选中的元素加到数组里         
                        string v2 = dgvCmbCel2.EditedFormattedValue.ToString();
                        string v3 = dgvCmbCel3.EditedFormattedValue.ToString();
                        string v4 = dgvChkCell1.EditedFormattedValue.ToString();//获取等轴测的选中状态
                        string v5 = dgvChkCell2.EditedFormattedValue.ToString();//获取Bom的选中状态
                        string v6 = dgvCmbCel4.EditedFormattedValue.ToString();
                        string[] columValue = new string[] { v1, v2, v3, v4, v5, v6 };
                        dicFile.Add(key, columValue);//把所有行单元格中的值加到集合里
                    }
                }
            }
            return dicFile;
        }

        /// <summary>
        /// 用户单击单元格时取消选中行
        /// </summary>   
        private void dgvFileList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            //if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            //{
            //    if (this.dgvFileList.CurrentRow.Selected)
            //    {
            //        Color selectc = this.dgvFileList.DefaultCellStyle.BackColor;
            //        if (this.dgvFileList.DefaultCellStyle.SelectionBackColor == Color.DodgerBlue)
            //        {
            //            this.dgvFileList.DefaultCellStyle.SelectionBackColor = selectc;
            //            this.dgvFileList.DefaultCellStyle.SelectionForeColor = Color.Black;
            //        }
            //        else
            //        {
            //            this.dgvFileList.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;

            //        }
            //    }
            //    else
            //    {
            //        //this.dgvFileList.CurrentRow.Selected = false;
            //        this.dgvFileList.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            //    }

            //}
            //else
            //{
            //    this.dgvFileList.CurrentRow.Selected = true;
            //}

        }
        private void dgvFileList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #region 模板选择单击事件
        private void tempFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] tempFileList = GetFiles("请选择图纸模板文件", "工程图模板 (*.drwdot)|*.drwdot", "tempfile");
            if (tempFileList != null)
            {
                List<string> tempList = tempIsSame(tempFileList.ToList());
                for (int i = 0; i < tempList.Count; i++)
                {
                    this.TempColum.Items.Add(tempList[i]);
                }
            }
        }
        private void tempFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> tempList = GetAllFiles("请选择一个图纸模板文件夹");
            if (tempList != null)
            {
                List<string> tempLists = tempIsSame(tempList);
                for (int i = 0; i < tempList.Count; i++)
                {
                    this.TempColum.Items.Add(tempList[i]);
                }
            }
        }
        private void btnPrtTemplat_Click(object sender, EventArgs e)
        {
            List<string> firstFile = new List<string>();
            GetTemp(ref temp1, "请选择图纸模板文件", "工程图模板 (*.drwdot)|*.drwdot", "prtfile");
            if (temp1 == string.Empty)
            {
                this.txtPrtTemplate.Text = prtPath;
            }
            else
            {
                this.txtPrtTemplate.Text = temp1;
            }
            if ((dgvFileList.Rows.Count != 0) && (temp1 != string.Empty))
            {
                firstFile = FirstColum();
                if (firstFile == null) return;
                else
                {
                    this.TempColum.Items.Insert(0, temp1);
                    for (int j = 0; j < firstFile.Count; j++)
                    {
                        //分割字符串
                        string ex = firstFile[j].Substring(firstFile[j].LastIndexOf("D") + 1);
                        if (ex == "PRT")
                            dgvFileList.Rows[j].Cells["TempColum"].Value = temp1;
                        DataGridViewComboBoxCell cell = dgvFileList.Rows[j].Cells["TempColum"] as DataGridViewComboBoxCell;
                        cell.Value = dgvFileList.Rows[j].Cells["TempColum"].Value.ToString();
                        dgvFileList.UpdateCellValue(cell.ColumnIndex, cell.RowIndex);
                    }
                }
            }
        }
        /// <summary>
        /// 获取第一列文件名
        /// </summary>
        /// <returns></returns>
        private List<string> FirstColum()
        {
            List<string> file = new List<string>();
            if (this.dgvFileList.Rows.Count == 0)
                return null;
            for (int i = 0; i < dgvFileList.Rows.Count; i++)
            {
                string key = this.dgvFileList.Rows[i].Cells[0].Value.ToString();
                file.Add(key);
            }
            return file;
        }
        private void btnCompTemplat_Click(object sender, EventArgs e)
        {
            List<string> firstFile = new List<string>();
            GetTemp(ref temp2, "请选择图纸模板文件", "工程图模板 (*.drwdot)|*.drwdot", "compfile");
            if (temp2 == string.Empty)
            {
                this.txtCompTemplate.Text = compPath;
            }
            else
            {
                this.txtCompTemplate.Text = temp2;
            }
            if ((dgvFileList.Rows.Count != 0) && (temp2 != string.Empty))
            {
                firstFile = FirstColum();
                if (firstFile == null) return;
                else
                {
                    this.TempColum.Items.Insert(0, temp2);
                    for (int j = 0; j < firstFile.Count; j++)
                    {
                        //分割字符串
                        string ex = firstFile[j].Substring(firstFile[j].LastIndexOf("D") + 1);
                        if (ex == "ASM")
                            dgvFileList.Rows[j].Cells["TempColum"].Value = temp2;
                        DataGridViewComboBoxCell cell = dgvFileList.Rows[j].Cells["TempColum"] as DataGridViewComboBoxCell;
                        cell.Value = dgvFileList.Rows[j].Cells["TempColum"].Value.ToString();
                        dgvFileList.UpdateCellValue(cell.ColumnIndex, cell.RowIndex);
                    }
                }
            }
        }
        private void btnBomTempl_Click(object sender, EventArgs e)
        {
            GetTemp(ref bomTemp, "请选择明细表模板文件", "明细表模板 (*.sldbomtbt)|*.sldbomtbt", "bomfile");
            if (bomTemp == string.Empty)
            {
                this.txtBomPath.Text = bomPath;
            }
            else
            {
                this.txtBomPath.Text = bomTemp;
            }
        }
        private void btnBendBomT_Click(object sender, EventArgs e)
        {
            GetTemp(ref bendTemp, "请选择折弯表模板文件", "折弯表模板 (*.sldbndtbt)|*.sldbndtbt", "bendfile");
            if (bendTemp == string.Empty)
            {
                this.txtBendBom.Text = bendPath;
            }
            else
            {
                this.txtBendBom.Text = bendTemp;
            }
        }
        #endregion
        /// <summary>
        /// 过滤重复的模板文件
        /// </summary>
        /// <param name="newTemp">新加载的模板文件</param>
        /// <returns></returns>
        private List<string> tempIsSame(List<string> newTemp)
        {
            List<string> files = new List<string>();
            //【1】获取界面里的所有模板文件
            DataGridViewComboBoxCell dgvCmBCell = dgvFileList.Rows[0].Cells["TempColum"] as DataGridViewComboBoxCell;
            for (int i = 0; i < dgvCmBCell.Items.Count; i++)
            {
                string cellTemp = dgvCmBCell.Items[i].ToString();
                files.Add(cellTemp);
            }
            var list = files.Intersect(newTemp);
            foreach (string item in list)
            {
                for (int i = newTemp.Count - 1; i >= 0; i--)
                {
                    if (newTemp[i] == item) newTemp.RemoveAt(i);
                }
            }
            return newTemp;
        }

        /// <summary>
        /// 点击checkbox全选\取消按钮（待修改）
        /// </summary>       
        private void chkIsometric_Click(object sender, EventArgs e)
        {
            if (this.chkIsometric.Checked == true && this.dgvFileList.Rows.Count != 0)
            {
                for (int i = 0; i < this.dgvFileList.Rows.Count; i++)
                {
                    this.dgvFileList.Rows[i].Cells["PicFangXColum"].Value = 1;
                }
            }
            else if (this.chkIsometric.Checked == false && this.dgvFileList.Rows.Count != 0)
            {
                for (int i = 0; i < this.dgvFileList.Rows.Count; i++)
                {
                    if (Convert.ToInt32(this.dgvFileList.Rows[i].Cells["PicFangXColum"].Value) == 1)
                    {
                        this.dgvFileList.Rows[i].Cells["PicFangXColum"].Value = 0;
                    }
                }
            }
            else { return; }
        }
        private void dgvFileList_MouseUp(object sender, MouseEventArgs e)
        {
            int count = 0;
            string ck = string.Empty;
            for (int i = 0; i < dgvFileList.Rows.Count; i++)
            {
                ck = this.dgvFileList.Rows[i].Cells["PicFangXColum"].EditedFormattedValue.ToString();
                if (ck == "True") { count++; }
            }
            if (count == this.dgvFileList.Rows.Count)
            {
                this.chkIsometric.Checked = true;
            }
            if (count != dgvFileList.Rows.Count)
            {
                chkIsometric.Click -= new EventHandler(chkIsometric_Click);
                this.chkIsometric.Checked = false;
                chkIsometric.Click += new EventHandler(chkIsometric_Click);
            }
        }
        private void btnSavePaths_Click(object sender, EventArgs e)
        {
            drawPaths.Clear();
            FolderBrowserDialog savePath = new FolderBrowserDialog();
            savePath.Description = "请选择保存路径";
            if (savePath.ShowDialog() == DialogResult.OK)
            {
                path = savePath.SelectedPath;
            }
            else
            {
            }
            this.txtSavePath.Text = path;
            //获取该路径下存在的图纸
            GetDrawPathByDir(path);
        }

        /// <summary>
        /// 实现明细表的全选\取消全选
        /// </summary>      
        private void chkBom_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkBom.Checked == true && this.dgvFileList.Rows.Count != 0)
            {
                for (int i = 0; i < this.dgvFileList.Rows.Count; i++)
                {
                    this.dgvFileList.Rows[i].Cells["bomColum"].Value = 1;
                }
            }
            else if (this.chkBom.Checked == false && this.dgvFileList.Rows.Count != 0)
            {
                for (int i = 0; i < this.dgvFileList.Rows.Count; i++)
                {
                    if (Convert.ToInt32(this.dgvFileList.Rows[i].Cells["bomColum"].Value) == 1)
                    {
                        this.dgvFileList.Rows[i].Cells["bomColum"].Value = 0;
                    }
                }
            }
            else { return; }
        }
        /// <summary>
        /// 实现明细表某一checkbox为false时，全选按钮也为false
        /// </summary>     
        private void dgvFileList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int count = 0;
            string ck = string.Empty;
            for (int i = 0; i < dgvFileList.Rows.Count; i++)
            {
                ck = this.dgvFileList.Rows[i].Cells["bomColum"].EditedFormattedValue.ToString();
                if (ck == "True") { count++; }
            }
            if (count == this.dgvFileList.Rows.Count)
            {
                this.chkBom.Checked = true;
            }
            if (count != dgvFileList.Rows.Count)
            {
                chkBom.CheckedChanged -= new EventHandler(chkBom_CheckedChanged);
                this.chkBom.Checked = false;
                chkBom.CheckedChanged += new EventHandler(chkBom_CheckedChanged);
            }
        }
        /// <summary>
        /// 开始按钮事件
        /// </summary>
        private void btnStartDrawing_Click(object sender, EventArgs e)
        {
           
            drawPaths.Clear();
            GetDrawPathByDir(txtSavePath.Text);
            Dictionary<string, string[]> tempFiles = new Dictionary<string, string[]>();
            List<string> sucFles = new List<string>();
            try
            {
                dicFile.Clear();
                if (this.dgvFileList.Rows.Count == 0)
                {
                    MessageBox.Show("请选择出图文件！");
                    return;
                }
                tempFiles = FilesLists();
                string prtTemp = this.txtPrtTemplate.Text.Trim().ToString();//零件模板
                string compTemp = this.txtCompTemplate.Text.Trim().ToString();//部件模板
                string bomTemp = this.txtBomPath.Text.Trim().ToString();//bom模板
                string bendTemp = this.txtBendBom.Text.Trim().ToString();//折弯表模板
                string savePath = this.txtSavePath.Text.Trim().ToString();//保存路径            
                objDraw.drawScale = this.rdoDrawScales.Checked;//优化比例
                objDraw.stardardScale = this.rdoStardardScale.Checked;//国标比例
                objDraw.standarView = this.chkStardView.Checked;//是否标准三视图
                objDraw.sheetMetal = this.chkBanJin.Checked;//是否钣金展开
                objDraw.sheetFlap = this.chkFlap.Checked;//钣金展开是否翻转
                objDraw.bendSheet = this.chkBendBom.Checked;//是否添加折弯表
                sucFles = objDraw.ExportDrawing(tempFiles, drawPaths, bomTemp, bendTemp, savePath);//零件和部件模板路径不要了
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序出现异常：" + ex.Message);
            }
            foreach (string items in sucFles)//删除转换成功的文件
            {
                for (int i = 0; i < dgvFileList.Rows.Count; i++)
                {
                    if (dgvFileList.Rows[i].Cells["FileListColum"].FormattedValue.ToString() == items)
                    {
                        dgvFileList.Rows.RemoveAt(i);
                    }
                }
            }
            if (this.dgvFileList.Rows.Count == 0)//如果界面为空
            {
                this.chkIsometric.Checked = false;
                this.chkBom.Checked = false;
                this.chkIsometric.Enabled = false;
                this.chkBom.Enabled = false;
            }         
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>     
        private void FrmMain_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] processArr = null;
            processArr = System.Diagnostics.Process.GetProcessesByName("mdb");
            if (processArr.Length == 0) //设计宝未运行
            {
                DialogResult d_result = MessageBox.Show("请在设计宝中运行该插件工具，谢谢配合！", "非设计宝环境的启动错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (d_result == DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }
            //窗体打开之前判断SoildWorks是否打开    
            try
            {
                if (swApp == null)
                    swApp = (SldWorks)ConnectSW.iSwApp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
                return;
            }
        
            prtPath = _exePath + "迈迪模板\\GB-A4.drwdot";
                compPath = _exePath + "迈迪模板\\GB-A3.drwdot";
                bomPath = _exePath + "迈迪模板\\gb-bom-material.sldbomtbt";
                bendPath = _exePath + "迈迪模板\\bendtable-standard.sldbndtbt";
                this.txtPrtTemplate.Text = prtPath;
                this.txtCompTemplate.Text = compPath;
                this.txtBomPath.Text = bomPath;
                this.txtBendBom.Text = bendPath;

        }

        private void AssemBarStep(int imaxCnt, int iStep)
        {
            AssemProgress apb = new AssemProgress(pbBarStep);
            this.Invoke(apb, new object[] { imaxCnt, iStep });
        }
        /// <summary>
        /// 进度条格式
        /// </summary>
        /// <param name="imaxValue">总数</param>
        /// <param name="istep">总步数</param>
        private void pbBarStep(int imaxValue, int istep)
        {
            pbAssem.Maximum = imaxValue;
            pbAssem.Value = istep;
            lblBar.Text = (pbAssem.Value * 100 / pbAssem.Maximum).ToString() + "%";
        }
        private delegate void AssemProgress(int imaxValue, int istep);

        private void 操作演示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            DirectoryInfo info = new DirectoryInfo(temp);
            string sWmvPath = _exePath + "Video\\操作视频.wmv";
            string sTmpPath = info.FullName + "\\操作视频.wmv";
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            Application.EnableVisualStyles();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            try
            {
                if (!File.Exists(sTmpPath))
                    File.Copy(sWmvPath, sTmpPath);
                if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "wmplayer.exe";
                    startInfo.Arguments = sTmpPath;
                    startInfo.UseShellExecute = true;
                    startInfo.Verb = "runas";
                    Process.Start(startInfo);
                }
                else
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "wmplayer.exe";
                    startInfo.Arguments = sTmpPath;
                    startInfo.UseShellExecute = true;
                    startInfo.Verb = "runas";
                    Process.Start(startInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("视频打开出错：" + ex.Message);
                Process.Start("explorer.exe", sWmvPath);
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout objFrm = new BatchExportDrawings.FrmAbout();
            try
            {
                objFrm.ShowDialog();
            }
            finally
            {
                objFrm.Dispose();
            }
        }

        private void dgvFileList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)//反键取消
            {
                if (dgvFileList.Rows[e.RowIndex].Selected)
                {
                    dgvFileList.Rows[e.RowIndex].Selected = false;
                }
                else
                {
                    dgvFileList.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void dgvFileList_DragDrop(object sender, DragEventArgs e)
        {

            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            //获取列表中原有数据
            //List<string> originalFiles = new List<string>();
            int fileNumber = dgvFileList.RowCount;
            string[] originalFiles = new string[dgvFileList.Rows.Count];
            if (fileNumber > 0)
            {
                for (int i = 0; i < fileNumber; i++)
                {
                    originalFiles[i] = dgvFileList.Rows[i].Cells[0].Value.ToString();
                }
            }

            string[] path_list = e.Data.GetData(DataFormats.FileDrop) as string[];
            ArrayList array = new ArrayList();
            //定义过滤格式
            var filter = new Regex(@"$(?<=\.(sldasm|sldprt))", RegexOptions.IgnoreCase);
            foreach (string path in path_list)
            {
                if (File.Exists(path) && filter.IsMatch(path))//文件,且格式符合
                {
                    array.Add(path);
                }
            }
            string[] addfiles = new string[array.Count];
            for (  int i=0; i<array.Count; i++)
            {
                addfiles[i] = array[i].ToString();
            }

            AddFileInfo(addfiles, originalFiles);

        }

        private void dgvFileList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

    }
}
