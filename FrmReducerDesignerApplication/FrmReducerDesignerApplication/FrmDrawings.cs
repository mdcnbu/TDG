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
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using MD_SW_ConnectSW;

namespace FrmReducerDesignerApplication
{
    public partial class FrmDrawings : Form
    {
        /// <summary>
        /// 构造函数初始化
        /// </summary>
        public FrmDrawings()
        {
            InitializeComponent();
            _exePath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//获取程序当前的启动目录
            objDraw = new Common.Drawings();
            objDraw.AssemBar = AssemBarStep;
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
        # region 全局变量
        Common.Drawings objDraw;
        private SldWorks swApp;
        private ModelDoc2 swModel;
        //Dictionary<string, string[]> dicFile = new Dictionary<string, string[]>();//获取界面数据的集合(string 放文件，string[]放后面几列的值)
        List<string> dicFile = new List<string>();//获取界面数据的集合(string 放文件)
        List<string> ListFile = new List<string>();
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
        #endregion
        private void btnStartDrawing_Click(object sender, EventArgs e)
        {
            List<string> tempFiles = new List<string>();
            List<string> sucessFile = new List<string>();
            try
            {
                dicFile.Clear();
                if (this.dgvFileList.Items.Count == 0)
                {
                    MessageBox.Show("请选择出图文件！");
                    return;
                }
                tempFiles = FilesLists();
                string prtTemp = this.txtPrtTemplate.Text.Trim().ToString();//零件模板
                string compTemp = this.txtCompTemplate.Text.Trim().ToString();//部件模板
                string bomTemp = this.txtBomPath.Text.Trim().ToString();//bom模板             
                string savePath = this.txtSavePath.Text.Trim().ToString();//保存路径    
                objDraw.stardardScale = this.chkStardardScale.Checked;//国标比例
                objDraw.standarView = this.chkStardView.Checked;//标准三视图
                objDraw.matrialBom = this.chkBom.Checked;//材料明细表
                objDraw.isometric = this.chkIsometric.Checked;//等轴测视图
                objDraw.firstProject = this.rdoShadowFirst.Checked;//第一视角投影
                objDraw.thirProject = this.rdoShadowThree.Checked;//第三视角投影
                objDraw.addDimensionNo = this.rdoAddDimenNo.Checked;
                objDraw.addDimensionAuto = this.rdoAddDimenAuto.Checked;
                objDraw.tag = int_1;
                sucessFile=objDraw.ExportDrawing(tempFiles, drawPaths, prtTemp, compTemp, bomTemp, savePath);
                 foreach (string item in sucessFile)
                {
                    //删除转换成功的文件
                    for (int i = 0; i < dgvFileList.Items.Count;i++ )
                    {
                        if (dgvFileList.Items[i].ToString() == item)
                        {
                            dgvFileList.Items.Remove(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序出现异常：" + ex);
            }
        }

        private void FrmDrawings_Load(object sender, EventArgs e)
        {
            prtPath = _exePath + "迈迪模板\\GB-A4.drwdot";
            compPath = _exePath + "迈迪模板\\GB-A3.drwdot";
            bomPath = _exePath + "迈迪模板\\gb-bom-material.sldbomtbt";        
            this.txtPrtTemplate.Text = prtPath;
            this.txtCompTemplate.Text = compPath;
            this.txtBomPath.Text = bomPath;
            int_1 = Convert.ToInt32(lblViewStyle.Text);
            foreach (ToolStripItem dropDownItem in toolViewStyle.DropDownItems)
            {
                if (dropDownItem.Tag != null && dropDownItem.Tag.ToString().Length != 0)
                {
                    ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)dropDownItem;
                    if (toolStripMenuItem.Tag.ToString() == int_1.ToString())
                    {
                        toolStripMenuItem.ForeColor = Color.Red;
                        toolStripMenuItem.Checked = true;
                    }
                    else
                    {
                        toolStripMenuItem.Checked = false;
                    }
                }
            }
        }

       List<string> tempDic =new List<string> ();//临时接收界面中的元素数===
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
                //把item进行字符串分割得到文件名称
                string oldName = item.Substring(item.LastIndexOf("\\") + 1);
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
        /// 获取界面展示全部或选中的文件
        /// </summary>
        /// <returns></returns>
        private List<string> FilesLists()
        {
            dicFile.Clear();
            //存放dgv后面6列的值
            int selectedRows = this.dgvFileList.SelectedIndices.Count;//选定行的数量
            if (selectedRows == 0)//选中的文件等于0（获取全部File）
            {               
                foreach (object item in dgvFileList.Items)
                {
                    dicFile.Add(item.ToString());
                }
            }
            else//获取选中的file
            {
                for (int i = 0; i < this.dgvFileList.Items.Count; i++)
                {
                    if (dgvFileList.GetSelected(i))
                    {
                        this.dgvFileList.SelectedIndex = i;          
                        dicFile.Add(dgvFileList.Items[i].ToString());//把所有行单元格中的值加到集合里
                    }
                }
            }
            return dicFile;
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
        /// 获取文件夹下所有图纸路径
        /// </summary>
        /// <param name="direct"></param>
        /// <returns></returns>
        private void GetDrawPathByDir(string direct)
        {
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
            DirectoryInfo[] diInfo = dir.GetDirectories();//获取到子目录文件夹名
            if (diInfo != null)
            {
                foreach (DirectoryInfo a in diInfo)
                {
                    string path = a.FullName;//子目录路径
                    GetDrawPathByDir(path);
                }
            }
        }

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
            //按后缀字母排序
            List<KeyValuePair<string, string>> listPair = new List<KeyValuePair<string, string>>(dic);
            listPair.Sort(delegate(KeyValuePair<string, string> s1, KeyValuePair<string, string> s2)
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
                this.dgvFileList.Items.Add(list[j]);//文件列表数据绑定
                //进度条显示
                pbAssem.Value += 1;
                lblBar.Text = (pbAssem.Value * 100 / pbAssem.Maximum).ToString() + "%";
            }                   
        }

        private void 清空文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvFileList.Items.Count > 0)
            {
                this.dgvFileList.Items.Clear();
            }
            else
            {
                MessageBox.Show("列表中无可操作文件！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void 删除文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvFileList.Items.Count == 0)
            {
                MessageBox.Show("列表中无可操作文件！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           else if (this.dgvFileList.SelectedItems.Count < 1)
            {
                MessageBox.Show("请选中删除行！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                for (int i = this.dgvFileList.SelectedIndices.Count; i > 0; i--)
                {
                    this.dgvFileList.Items.RemoveAt(this.dgvFileList.SelectedIndices[i-1]);//删除选中的项
                }
            }
        }
        /// <summary>
        /// 打开文件夹选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dicCompare.Clear();//清理掉字典里的文件
            drawPaths.Clear();//清理掉图纸集合中的数据
            //fileNames.Clear();//清理掉临时文件名集合
            int filenums = this.dgvFileList.Items.Count;
            Dictionary<string, string> dicIsSame = new Dictionary<string, string>();
            string[] fileList = GetFiles("请选择要出图的零件或装配体文件", "零部件 (*.SLDASM;*.SLDPRT)|*.SLDASM;*.SLDPRT", "files");
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
                    dicCompare.Add(fileList[i], splitEx);
                    string newName = fileList[i].Substring(fileList[i].LastIndexOf("\\") + 1);//获取到文件名
                    dicIsSame.Add(fileList[i], newName);//把用户选取的文件名加到集合里
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
            }
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
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                sPath = folderDialog.SelectedPath;
                //递归找到所有相关文件
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
        private void 打开目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawPaths.Clear();//清理掉图纸集合里的数据
            dicCompare.Clear();//清理掉字典里的文件
            int files = this.dgvFileList.Items.Count;
            Dictionary<string, string> dicIsSame = new Dictionary<string, string>();
            List<string> fileList = GetAllFiles("请选择一个包含零件或装配体的文件夹");                  
            if (fileList != null)
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
            }
        }

        private void 当前SW中的文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (swApp == null)
                swApp = (SldWorks)ConnectSW.iSwApp;
            object[] modelFile;
            pathName.Clear();
            drawPaths.Clear();
      
            dicCompare.Clear();//清理掉字典里的文件
            int files = this.dgvFileList.Items.Count;
            Dictionary<string, string> dicIsSame = new Dictionary<string, string>();           
            if (swApp == null) return;
            int fileCount = swApp.GetDocumentCount();
            modelFile = (object[])swApp.GetDocuments();
            for (int i = 0; i < fileCount; i++)
            {
                swModel = modelFile[i] as ModelDoc2;
                int type = swModel.GetType();
                bool isVisible = swModel.Visible;
                if (type != 3 && isVisible)//非图纸文件且文件可见时
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
            }
            else { return; }
        }
        private int int_1;
        private void 消除隐藏线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem dropDownItem in toolViewStyle.DropDownItems)
            {
                if (dropDownItem.Tag != null && dropDownItem.Tag.ToString().Length != 0)
                {
                    ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)dropDownItem;
                    toolStripMenuItem.Checked = false;
                    toolStripMenuItem.ForeColor = Color.Black;
                }
            }
            ToolStripMenuItem toolStripMenuItem2 = sender as ToolStripMenuItem;
            toolStripMenuItem2.Checked = true;
            toolStripMenuItem2.ForeColor = Color.Red;
            int_1 = Convert.ToInt32(toolStripMenuItem2.Tag);
            toolViewStyle.ShowDropDown();
        }

        private void btnCloseReducer_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach (Control item in FrmMain.pMainWin.splitContainer1.Panel2.Controls)
            {
                if (item is PictureBox)
                {
                    PictureBox objPictu = (PictureBox)item;
                    objPictu.Show();
                }
            }
        }

        private void FrmDrawings_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.lblViewStyle.Text = int_1.ToString();
        }

    }
}
