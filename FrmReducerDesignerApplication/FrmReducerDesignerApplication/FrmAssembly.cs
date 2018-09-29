﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;
using MD_SW_ConnectSW;

namespace FrmReducerDesignerApplication
{
    public partial class FrmAssembly : Form
    {
        public FrmAssembly()
        {
            InitializeComponent();
        }
        private SldWorks swApp;
        private ModelDoc2 swModel;        
        private ModelDocExtension swModelEx;
        private ModelView swModelView;
        private FeatureManager swFeatMgr;
        private SketchManager swSketchMgr;
        private AssemblyDoc swAssembly;
        private string stDefaultTemplateAssembly;
        private IComponent2 swComponent;
        private Feature mateFeature;
        private Mate2 myMate;
        int mateError;
        int errors;
        int warnings;
        string assemblyName;
        bool state;
 
        //#region 新建装配体零件方法
        ///// <summary>
        ///// x新建零件
        ///// </summary>
        //public void NewPart()
        //{   //默认模版
        //    stDefaultTemplateAssembly = swApp.GetUserPreferenceStringValue((int)swUserPreferenceStringValue_e.swDefaultTemplateAssembly);
        //    if (stDefaultTemplateAssembly == "" || !File.Exists(stDefaultTemplateAssembly))
        //    {
        //        stDefaultTemplateAssembly = Application.StartupPath + @"\assemblyDot.asmdot";
        //        if (!File.Exists(stDefaultTemplateAssembly))
        //        {
        //            throw new Exception("找不到模版文件，新建零件错误");
        //        }
        //    }
        //    //新建>>>零件-----------------------------
        //    //swModel=(ModelDoc2)swApp.NewDocument(,0)
        //    swAssembly = (AssemblyDoc)swApp.NewDocument(stDefaultTemplateAssembly, 0, 0, 0);//注意：括号里面不能加双引号
        //    if (swAssembly == null)
        //    {
        //        throw new Exception("新建零件发生错误！");
        //    }
        //}
        //#endregion
        #region 连接solidworks方法
        /// <summary>
        /// 连接Solidworks---------方法
        /// </summary>
        public void ConnectSw()
        {
            if (swApp == null)
            {
                Process[] processArr = null;  //对进程进行检测
                processArr = Process.GetProcessesByName("SLDWORKS");//通过C#语言规则
                if (processArr.Length > 0)
                {
                    //通过SldWorks.Application方式
                    try
                    {
                        swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
                    }
                    catch (Exception)
                    {

                    }
                    //通过SldWorks.Application.18方式，.18=2010版，.19=2011版，.20=2012版，.21=2013版，.22=2014版，.23=2015版----------强烈推荐
                    if (swApp == null)
                    {
                        for (int i = 18; i < 28; i++)
                        {
                            try
                            {
                                swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application." + i.ToString());//获取sw  加上版本号才行
                                if (swApp != null)
                                {
                                    break;
                                }
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                    //通过Guid的方式
                    if (swApp == null)//2010sw
                    {
                        try
                        {
                            Guid myGuid1 = new Guid("6894540C-3171-484F-9E97-6A962559BA30");
                            object processSW = System.Activator.CreateInstance(System.Type.GetTypeFromCLSID(myGuid1));//创建连接sw 不推荐
                            swApp = (SldWorks)processSW;
                        }
                        catch (Exception)
                        {

                        }
                    }
                    if (swApp == null)//2012sw
                    {
                        try
                        {
                            Guid myGuid1 = new Guid("B4875E89-91F6-4124-BB63-2539727E98FA");
                            object processSW = System.Activator.CreateInstance(System.Type.GetTypeFromCLSID(myGuid1));
                            swApp = (SldWorks)processSW;
                        }
                        catch (Exception)
                        {

                        }
                    }
                    //通过SldWorks.ISldWorks方式
                    if (swApp == null)
                    {
                        try
                        {
                            swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.ISldWorks");
                        }
                        catch (Exception)//
                        {

                        }
                    }
                }
            }
            //尝试连接注册表中注册的solidworks，可未打开状态，SldWorksClass() 方式
            if (swApp == null)
            {
                try
                {
                    swApp = new SldWorks();
                }
                catch (Exception)//异常处理
                {

                }
            }
            //SldWorks()方式连接
            if (swApp == null)
            {
                try
                {
                    swApp = new SldWorks();//不建议
                }
                catch (Exception)
                {

                }
            }
            //连接成功，使solidworks可见
            if (swApp != null)
            {
                if (!swApp.Visible)
                {
                    try
                    {
                        swApp.Visible = true;    //使sw显示
                    }
                    catch
                    {
                        swApp = null;
                    }
                }
            }
            //连接失败
            if (swApp == null)
            {
                throw new Exception("无法连接到Solidworks,请先手动打开!");
            }
        }
        #endregion.
        //装配体中插入新零件
        public void InsretComponent()
        {
            string[] strCompName = new string[3];
            string[] firstSelect = new string[15]; 
            string[] secondSelect = new string[15];
            swModel = (ModelDoc2)swApp.OpenDoc6("G:\\CodeTest\\planetAssembly.SLDASM", (int)swDocumentTypes_e.swDocASSEMBLY, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
            swAssembly = (AssemblyDoc)swModel;//////
            string assemblyTitle =swModel.GetTitle();//获取装配体名称
            string[] strings = assemblyTitle.Split(new Char[] { '.' });//使用分隔符分割装配体实例号
            assemblyName = (string)strings[0];//获得装配体名称
            //打开零件并添加零件到装配体
            swModel = (ModelDoc2)swApp.OpenDoc6("G:\\CodeTest\\内齿轮.SLDPRT", (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
            swComponent = (IComponent2)swAssembly.AddComponent5("内齿轮.sldprt", (int)swAddComponentConfigOptions_e.swAddComponentConfigOptions_CurrentSelectedConfig, "", false, "", 0, 0, 0);
            strCompName[0] = swComponent.Name2; //获取内齿轮名称       
            swApp.DocumentVisible(false, (int)swDocumentTypes_e.swDocPART);
            swModel = (ModelDoc2)swApp.OpenDoc6("G:\\CodeTest\\行星轮.SLDPRT", (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
            swComponent = (IComponent2)swAssembly.AddComponent5("行星轮.sldprt", (int)swAddComponentConfigOptions_e.swAddComponentConfigOptions_CurrentSelectedConfig, "", false, "", 0, -0.0456, 0);
            strCompName[1] = swComponent.Name2; //获取行星轮名称
            swApp.DocumentVisible(false, (int)swDocumentTypes_e.swDocPART);
            swModel = (ModelDoc2)swApp.OpenDoc6("G:\\CodeTest\\输入轴.SLDPRT", (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
            swComponent = (IComponent2)swAssembly.AddComponent5("输入轴.sldprt", (int)swAddComponentConfigOptions_e.swAddComponentConfigOptions_CurrentSelectedConfig, "", false, "", 0, 0, 0);
            strCompName[2] = swComponent.Name2; //获取输入轴名称
            swApp.DocumentVisible(false, (int)swDocumentTypes_e.swDocPART);
            
            //添加同心配合关系           
            firstSelect[0] = "前视基准面@" + strCompName[0] + "@" + assemblyName;//第一个选择选项
            secondSelect[0] = "前视基准面@" + strCompName[2] + "@" + assemblyName;//第二个选择选项
            swModel.ClearSelection2(true);
            swModelEx = swModel.Extension;
            swModelEx.SelectByID2(firstSelect[0], "PLANE", 0, 0, 0, false, 1, null, 0);//?????????
            swModelEx.SelectByID2("前视基准面@输入轴-1@planetAssembly", "PLANE", 0, 0, 0, true, 0, null, 0);
          
            swAssembly.AddMate3((int)swMateType_e.swMateCOINCIDENT, (int)swMateAlign_e.swMateAlignALIGNED, false, 0, 0, 0, 0, 0, 0, 0, 0, false, out mateError);
            swModel.ClearSelection2(true);
            //添加距离约束
            swModelEx.SelectByID2("Point1@原点@行星轮-1@装配体5", "EXTSKETCHPOINT", 0, 0, 0, true, 1, null, 0);
            swModelEx.SelectByID2("Point1@原点@输入轴-1@装配体5", "EXTSKETCHPOINT", 0, 0, 0, true, 1, null, 0);
            swAssembly.AddMate3((int)swMateType_e.swMateDISTANCE, (int)swMateAlign_e.swMateAlignALIGNED, false, 0.0455, 0.0455, 0.0455, 0, 0, 0, 0, 0, false, out mateError);
            //添加齿轮配合
            
        }

        private void btnAssembly_Click_1(object sender, EventArgs e)
        {
            if (swApp == null)
                swApp = (SldWorks)ConnectSW.iSwApp;
            ConnectSw();

            InsretComponent();
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            
            string[] fileList = GetFiles("请选择要装配的文件", "零部件 (*.SLDASM;*.SLDPRT)|*.SLDASM;*.SLDPRT", "files");
            //把选择的文件展示在listbox中
            if (fileList != null)
            {
                this.lBoxAssem1.Items.AddRange(fileList);
            }
           
        }
     /// <summary>
        ///  获取用户所选文件（prt,asm）
     /// </summary>
     /// <param name="title">标题</param>
     /// <param name="filter">过滤标题</param>
     /// <param name="key">配置中的键</param>
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

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            string[] fileList = GetFiles("请选择要装配的文件", "零部件 (*.SLDASM;*.SLDPRT)|*.SLDASM;*.SLDPRT", "files");
            //把选择的文件展示在listbox中
            this.lBoxAssem2.Items.AddRange(fileList);
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (this.lBoxAssem1.Items.Count == 0)
            {
                MessageBox.Show("列表中无可操作文件！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (this.lBoxAssem1.SelectedItems.Count < 1)
            {
                MessageBox.Show("请选中删除行！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                for (int i = this.lBoxAssem1.SelectedIndices.Count; i > 0; i--)
                {
                    this.lBoxAssem1.Items.RemoveAt(this.lBoxAssem1.SelectedIndices[i - 1]);//删除选中的项
                }
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (this.lBoxAssem2.Items.Count == 0)
            {
                MessageBox.Show("列表中无可操作文件！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (this.lBoxAssem2.SelectedItems.Count < 1)
            {
                MessageBox.Show("请选中删除行！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                for (int i = this.lBoxAssem2.SelectedIndices.Count; i > 0; i--)
                {
                    this.lBoxAssem2.Items.RemoveAt(this.lBoxAssem2.SelectedIndices[i - 1]);//删除选中的项
                }
            }
        }

        private void btnAssem1_Click(object sender, EventArgs e)
        {
            if (swApp == null)
                swApp = (SldWorks)ConnectSW.iSwApp;
            List<string> fileAssem1 = new List<string>();
            //子装配体1
            //获取界面中的文件并打开
              int selectedRows = this.lBoxAssem1.SelectedIndices.Count;//选定行的数量        
                foreach (object item in lBoxAssem1.Items)
                {
                    fileAssem1.Add(item.ToString());
                }
                foreach (string file in fileAssem1)
                {
                    swModel = (ModelDoc2)swApp.OpenDoc6(file, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
                }
      
            //实现装配

        }

        private void btnAssem2_Click(object sender, EventArgs e)
        {

        }
    }
}
