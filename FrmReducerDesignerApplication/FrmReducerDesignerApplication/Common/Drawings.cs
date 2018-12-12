using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using MD_SW_ConnectSW;

namespace FrmReducerDesignerApplication.Common
{
   public class Drawings
    {
        #region 定义全局变量
        private SldWorks _swApp;
        private ModelDoc2 _swModelDoc;
        private DrawingDoc __swDrawDoc;
        private ModelDocExtension _swModelEx;
        private Sheet _currentSheet;//图表
        private IBody2 _swBody;//实体
        private AssemblyDoc _swAssembly;
        private Component2 _swComp;//sw组件
        private IView _swView;//工程视图      
        private int _numSucess;
        List<string> sucessFile = new List<string>();//转换成功的文件       
        private BomTableAnnotation swBomTableAnno = default(BomTableAnnotation);
        #endregion
        #region 属性
        /// <summary>
        /// 国标比例
        /// </summary>
        public bool stardardScale { get; set; }
       /// <summary>
       /// 第一视角投影
       /// </summary>
        public bool firstProject { get; set; }
        /// <summary>
        /// 第三视角投影
        /// </summary>
        public bool thirProject { get; set; }
        /// <summary>
        /// 标准三视图
        /// </summary>
        public bool standarView { get; set; }
        /// <summary>
        /// 等轴测视图
        /// </summary>
        public bool isometric { get; set; }
        /// <summary>
        /// 材料明细表
        /// </summary>
        public bool matrialBom { get; set; }
        /// <summary>
        /// 图纸左边框宽度
        /// </summary>
        public double widthLeft { get; set; }
        /// <summary>
        /// 图纸右下边框宽度
        /// </summary>
        public double widthRight { get; set; }
        /// <summary>
        /// 标题栏单元格高度
        /// </summary>
        public double higthSheet { get; set; }
       /// <summary>
       /// 手动标注尺寸
       /// </summary>
        public bool addDimensionNo { get; set; }
       /// <summary>
       /// 推荐的尺寸
       /// </summary>
        public bool addDimensionAuto { get; set; }
       /// <summary>
       /// 保存为.Dwg格式
       /// </summary>
        public bool IfDwg { get; set; }
           /// <summary>
          /// 视图样式
          /// </summary>
       public int tag { get; set; }
        #endregion
        #region  委托公共属性
        /// <summary>
        /// 文件个数
        /// </summary>
        public int MaxCount { get; private set; }

        /// <summary>
        /// 单步
        /// </summary>
        public int Step { get; private set; }
        #endregion
        #region 委托
        /// <summary>
        /// 进度条委托
        /// </summary>
        /// <param name="imaxCnt"></param>
        /// <param name="iStep"></param>
        public delegate void cdAssemBar(int imaxCnt, int iStep);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public cdAssemBar AssemBar;
        #endregion
        /// <summary>
        /// 出工程图方法
        /// </summary>
        /// <param name="dicValue">字典集合保存datagridview中的值</param>
        /// <param name="drawPath">图纸路径集合</param>
        /// <param name="bomPath">bom表模板路径</param>
        /// <param name="bendPath">折弯表模板路径</param>
        /// <param name="savePath">图纸保存路径</param>
        public List<string> ExportDrawing(List<string> dicValue, List<string> drawPath,string prtTemp,string compTemp, string bomPath, string savePath)
        {
            sucessFile.Clear();
            _numSucess = 0;
            List<string> GapPath = new List<string>();//跳过的文件
            List<string> picNames = new List<string>();//临时存放图纸名称
            //遍历dictionary并取出值
            if (dicValue != null)
            {
                foreach (string picPath in drawPath)
                {
                    string picName = picPath.Substring(picPath.LastIndexOf("\\") + 1, picPath.LastIndexOf(".") - picPath.LastIndexOf("\\") - 1);
                    picNames.Add(picName);
                }
                MaxCount = dicValue.Count;
                Step = 0;
                foreach (string item in dicValue)
                {
                    Step += 1;                   
                    string filePath = item;
                    string compName = filePath.Substring(filePath.LastIndexOf("\\") + 1, filePath.LastIndexOf(".") - filePath.LastIndexOf("\\") - 1);//获得文件名
                    if (picNames.IndexOf(compName) != -1)  //判断是否存在同名图纸
                    {
                        DialogResult result = MessageBox.Show("程序检测到保存路径下存在同名图纸：[" + compName + ".SLDDRW]" + "，是否覆盖？\n" + "若覆盖请单击确定，取消则选择另存路径。", "SolidWorks信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK) //覆盖
                        {
                            Drawing(dicValue,prtTemp,compTemp, bomPath, savePath, null);
                            if (AssemBar != null)
                                AssemBar(MaxCount, Step);
                        }
                        else //取消按钮
                        {
                            //另存为 对话框
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                            saveFileDialog1.FileName = compName;
                            saveFileDialog1.Filter = "SolidWorks工程图(*.slddrw) | *.slddrw";
                            saveFileDialog1.FilterIndex = 2;
                            saveFileDialog1.RestoreDirectory = true;
                            string tempPath = null;
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                tempPath = saveFileDialog1.FileName;
                                string[] newPathArry = { tempPath };
                                string aa = tempPath.Substring(0, tempPath.LastIndexOf('\\') + 1);
                                Drawing(dicValue, prtTemp, compTemp, bomPath, aa, tempPath);
                                if (AssemBar != null) AssemBar(MaxCount, Step);
                            }
                        }
                    }
                    else
                    {
                        Drawing(dicValue, prtTemp,compTemp,bomPath, savePath, null);
                        if (AssemBar != null)
                            AssemBar(MaxCount, Step);
                    }
                }
            }
            //FrmResultShow objFrm = new FrmResultShow(GapPath, _numSucess);
            //objFrm.Show();       //结果展示
            return sucessFile;
        }
        /// <summary>
        /// 出工程图
        /// </summary>
        /// <param name="dicValues"></param>
        /// <param name="prtTemp"></param>
        /// <param name="compTemp"></param>
        /// <param name="bomPaths"></param>
        /// <param name="savePaths">保存路径</param>
        /// <param name="newPath">新路径</param>
        private void Drawing(List<string> dicValues, string prtTemp, string compTemp, string bomPaths, string savePaths, string newPath)
        {
                
            string viewType = string.Empty;
            bool isometric = false;
            bool bom = false;
            string dimesion = string.Empty;
            double spaceX = 0.06;//x方向留白区域        
            double scale = 1;//定义比例初始值
            List<double[]> viewBox = new List<double[]>();//集合存放视图box
            List<double[]> viewOrigin = new List<double[]>();//集合存放视图原点值
            double[] outLine = new double[4];//视图box值
            double[] postion = new double[2];//视图原点值
            _swApp = (SldWorks)ConnectSW.iSwApp;//连接sw
            if (_swApp == null) return;
            foreach (string item in dicValues)
            {
                int errors = 0;
                int warnings = 0;
                double view1X = 0;
                double view1Y = 0;               
                string filePath = item;//文件路径              
                string fileEx = filePath.Substring(filePath.LastIndexOf("."), 7);//获得后缀名
                string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1, filePath.LastIndexOf(".") - filePath.LastIndexOf("\\") - 1);
                if (fileEx == ".SLDPRT")
                {
                    _swModelDoc = (ModelDoc2)_swApp.OpenDoc6(filePath, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
                    __swDrawDoc = (DrawingDoc)_swApp.NewDrawing2((int)swDwgTemplates_e.swDwgTemplateCustom, prtTemp, (int)swDwgPaperSizes_e.swDwgPapersUserDefined, 0, 0);
                }
                if (fileEx == ".SLDASM")
                {
                    _swModelDoc = (ModelDoc2)_swApp.OpenDoc6(filePath, (int)swDocumentTypes_e.swDocASSEMBLY, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
                    __swDrawDoc = (DrawingDoc)_swApp.NewDrawing2((int)swDwgTemplates_e.swDwgTemplateCustom, compTemp, (int)swDwgPaperSizes_e.swDwgPapersUserDefined, 0, 0);
                }
                _swModelEx = (ModelDocExtension)_swModelDoc.Extension;
                if (newPath != null)
                {
                    savePaths = newPath.Substring(0, newPath.LastIndexOf("\\"));
                }              
                //新建工程图             
                _swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swAutomaticScaling3ViewDrawings, true);//自动缩放新工程图比例
                if (standarView == false && isometric)//如果只生成等轴测视图
                {
                    CreatIsometric(__swDrawDoc, filePath);                         
                    _currentSheet = (Sheet)__swDrawDoc.GetCurrentSheet();
                    __swDrawDoc.ActivateSheet(_currentSheet.GetName());
                    _swView = __swDrawDoc.GetFirstView();
                    _swView = _swView.GetNextView();
                    ChangeViewShow(tag, _swView);
                    _swApp.CloseDoc(_swModelDoc.GetTitle());//
                    ModelDoc2 tempDoc = (ModelDoc2)__swDrawDoc;
                    bool ss0 = false;
                    if (newPath != null && IfDwg)
                    {
                        ss0 = tempDoc.Extension.SaveAs(newPath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);
                    }
                    else if (newPath != null&&IfDwg==false)
                    {
                        ss0 = tempDoc.Extension.SaveAs(savePaths + "\\" + (_swModelDoc.GetTitle()).Substring(0, (_swModelDoc.GetTitle()).LastIndexOf(".")) + ".DWG", (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);
                    }
                    else if (newPath == null&&IfDwg)
                    {
                        ss0 = tempDoc.Extension.SaveAs(savePaths + "\\" + (_swModelDoc.GetTitle()).Substring(0, (_swModelDoc.GetTitle()).LastIndexOf(".")) + ".DWG", (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);
                    }
                    else
                    {
                        ss0 = tempDoc.Extension.SaveAs(savePaths + "\\" + (_swModelDoc.GetTitle()).Substring(0, (_swModelDoc.GetTitle()).LastIndexOf(".")) + ".slddrw", (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);
                    }

                    bool isHidden = tempDoc.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swViewDisplayHideAllTypes, true); //隐藏所有类型
                    _swApp.CloseDoc(tempDoc.GetTitle());
                    _numSucess += 1;//转换成功的数量
                    sucessFile.Add(filePath);
                    return;
                }             
                bool isCreate = false;
                #region 第三视角投影
                if (thirProject)
                {
                    isCreate = __swDrawDoc.Create3rdAngleViews2(filePath);//创建第三视角投影视图(视图位置有差别)
                    //调整视图位置
                    _swView = __swDrawDoc.GetFirstView();
                    while (_swView != null)
                    {
                        double[] vBox = new double[] { };
                        double[] vPoint = new double[] { };
                        vBox = (double[])_swView.GetOutline();
                        vPoint = (double[])_swView.Position;
                        viewBox.Add(vBox);
                        viewOrigin.Add(vPoint);
                        _swView = _swView.GetNextView();
                    }
                    //调整视图1、2位置
                    if (viewBox[0][3] > viewBox[0][2])//纵向
                    {
                        double[] posView1 = new double[] { viewBox[0][2] / 3.0, viewOrigin[1][1] };
                        _swView = __swDrawDoc.GetFirstView();
                        _swView = _swView.GetNextView();
                        _swView.Position = posView1;
                        double[] posView2 = new double[] { viewOrigin[2][0], viewOrigin[2][1] - (viewBox[2][1] - viewBox[1][3]) / 1.9 };//调整视图2位置
                        _swView = _swView.GetNextView();
                        _swView.Position = posView2;
                    }
                    else
                    {
                        double[] posView1 = new double[] { viewBox[0][2] / 4.0, viewOrigin[1][1] };
                        _swView = __swDrawDoc.GetFirstView();
                        _swView = _swView.GetNextView();
                        _swView.Position = posView1;
                        double[] posView2 = new double[] { viewOrigin[2][0], viewOrigin[2][1] - (viewBox[2][1] - viewBox[1][3]) / 2.0 };//调整视图2位置
                        _swView = _swView.GetNextView();
                        _swView.Position = posView2;
                    }
                    viewOrigin.Clear();
                    viewBox.Clear();
                    _swView = __swDrawDoc.GetFirstView();
                    while (_swView != null)
                    {
                        double[] vBox = new double[] { };
                        double[] vPoint = new double[] { };
                        vBox = (double[])_swView.GetOutline();
                        vPoint = (double[])_swView.Position;
                        viewBox.Add(vBox);
                        viewOrigin.Add(vPoint);
                        _swView = _swView.GetNextView();
                    }
                    if (isometric)//等轴测
                    {
                        _swView = (IView)__swDrawDoc.CreateDrawViewFromModelView3(filePath, "*等轴测", viewOrigin[3][0], viewOrigin[2][1], 0);
                        _swView = __swDrawDoc.GetFirstView();
                        double[] sca = new double[2];
                        sca = _swView.ScaleRatio;//获取比例
                        _swView = _swView.GetNextView();
                        _swView = _swView.GetNextView();
                        _swView = _swView.GetNextView();
                        _swView = _swView.GetNextView();
                        _swView.ScaleRatio = sca;
                        double[] rePos = new double[] { viewOrigin[3][0] + 0.015, viewOrigin[2][1] };
                        _swView.Position = rePos;
                        ChangeViewShow(tag, _swView);//视图样式
                        AddDimension(dimesion, __swDrawDoc, _swModelDoc);//尺寸标注
                    }
                }
                #endregion
                #region 第一视角投影
                else
                {
                    isCreate = __swDrawDoc.Create1stAngleViews(filePath);//创建第一视角投影视图
                    //获取视图boundingbox             
                    _swView = __swDrawDoc.GetFirstView();
                    while ((_swView != null))
                    {
                        outLine = (double[])_swView.GetOutline();//(x,y坐标最值)
                        postion = (double[])_swView.Position;//视图位置值                   
                        viewBox.Add(outLine);
                        viewOrigin.Add(postion);
                        _swView = _swView.GetNextView();
                    }

                    double newScale = CalcuScale(viewBox, __swDrawDoc, scale, spaceX, 3);
                    //调整视图位置（position）
                    if (viewBox[0][3] > viewBox[0][2])
                    {
                        view1X = viewBox[0][2] / 2.8;//视图1的X坐标放在图纸坐标的三分之一处
                        view1Y = viewBox[0][3] - viewBox[0][3] / 4.85;//视图1的Y坐标放在图纸坐标的五分之一处
                    }
                    else
                    {
                        view1X = viewBox[0][2] / 3.5;//视图1的X坐标放在图纸坐标的三分之一处
                        view1Y = viewBox[0][3] - viewBox[0][3] / 4.0;//视图1的Y坐标放在图纸坐标的四分之一处
                    }
                    double[] view1Pos = new double[] { view1X, view1Y };
                    _swView = __swDrawDoc.GetFirstView();//获取图纸
                    _swView = _swView.GetNextView();//获取第一个视图              
                    _swView.Position = view1Pos;
                    bool isRebuild = _swModelDoc.EditRebuild3();
                    //viewBox.Clear();
                    List<double[]> tempBox = new List<double[]>();
                    viewOrigin.Clear();
                    while ((_swView != null))
                    {
                        ChangeViewShow(tag, _swView);//改变视图显示样式
                        AddDimension(dimesion, __swDrawDoc, _swModelDoc);//添加尺寸
                        outLine = (double[])_swView.GetOutline();//(x,y坐标最值)
                        postion = (double[])_swView.Position;//视图位置值                   
                        tempBox.Add(outLine);
                        viewOrigin.Add(postion);
                        _swView = _swView.GetNextView();
                    }
                    if (isometric)  //是否创建等轴测视图（非钣金）
                    {
                        double[] scalArry = new double[2];
                        _swView = (IView)__swDrawDoc.CreateDrawViewFromModelView3(filePath, "*等轴测", viewOrigin[2][0], viewOrigin[1][1], 0);
                        _swView = __swDrawDoc.GetFirstView();//获取图纸
                        _swView = _swView.GetNextView();//获取第一个视图
                        double sca = _swView.get_IScaleRatio();
                        if (sca == 1)//缩小比例
                        {
                            scalArry[0] = 1;
                            scalArry[1] = newScale;
                        }
                        else
                        {
                            scalArry[0] = sca;
                            scalArry[1] = 1;
                        }
                        _swView = _swView.GetNextView();
                        _swView = _swView.GetNextView();
                        _swView = _swView.GetNextView();
                        _swView.ScaleRatio = scalArry;//调整轴测图比例              
                        ChangeViewShow(tag, _swView);
                        _swModelDoc.EditRebuild3();
                    }
                    ////关掉文件（不保存）
                    //_swApp.CloseDoc(_swModelDoc.GetTitle());
                    if (fileEx == ".SLDASM" && bom)        //是否创建明细表
                    {
                        //viewBox.Clear();
                        //viewOrigin.Clear();
                        double[] outArry = new double[4];
                        double[] posArry = new double[2];
                        double[] posArry1 = null;
                        double[] posArry2 = null;
                        double[] posArry3 = null;
                        _currentSheet = (Sheet)__swDrawDoc.GetCurrentSheet();
                        __swDrawDoc.ActivateSheet(_currentSheet.GetName());
                        _swView = __swDrawDoc.GetFirstView();//获取图纸       
                        _swView = _swView.GetNextView();//获取第一个视图
                        swBomTableAnno = (BomTableAnnotation)_swView.InsertBomTable4(true, 0.4, 0.1, (int)swBOMConfigurationAnchorType_e.swBOMConfigurationAnchor_BottomRight, (int)swBomType_e.swBomType_TopLevelOnly, "", bomPaths, false, 0, false);
                        TableAnnotation tableAnnotation = (TableAnnotation)swBomTableAnno;
                        tableAnnotation.GetAnnotation();
                        BomFeature bomFeature = swBomTableAnno.BomFeature;
                        bool[] array = new bool[bomFeature.GetConfigurationCount(false)];
                        object Visible = array;
                        object configurations = bomFeature.GetConfigurations(false, ref Visible);
                        array[0] = true;
                        bomFeature.SetConfigurations(true, array, configurations);
                        FeatureManager featureManager = _swModelDoc.FeatureManager;
                        featureManager.UpdateFeatureTree();
                        double num = 0.007;
                        tableAnnotation.SetRowHeight(-2, num, 0);
                        double totleHeight = num * tableAnnotation.RowCount;//计算总的tableBom高度
                        double heightSum = totleHeight + 0.070;//加上标题栏总高度
                        int columCount = tableAnnotation.ColumnCount;//获取总的列数
                        double columWidth = 0;
                        for (int i = 0; i < columCount; i++)
                        {
                            double wid = tableAnnotation.GetColumnWidth(i);
                            columWidth += wid;
                        }
                        _swView = _swView.GetNextView();
                        _swView = _swView.GetNextView();
                        outArry = (double[])_swView.GetOutline();
                        if (outArry[1] < heightSum)//有可能被遮挡
                        {
                            //__swView = _swDrawDoc.GetFirstView();
                            //double[] tempArry = new double[] { };
                            //tempArry=(double[])__swView.GetOutline();
                            //viewBox.Insert(0, tempArry);
                            scale = ((viewBox[1][2] - viewBox[1][0]) + (viewBox[3][2] - viewBox[3][0])) / (viewBox[0][2] - columWidth - 0.025);//计算X方向的比例        
                            if (scale > 11)
                            {
                                double scaleCeil = System.Math.Ceiling(scale);
                                if (scaleCeil > 11 && scaleCeil < 16) { scale = 20; }
                                if (scaleCeil > 15 && scaleCeil < 21) { scale = 25; }
                                if (scaleCeil > 20 && scaleCeil < 26) { scale = 30; }
                                if (scaleCeil > 25 && scaleCeil < 34) { scale = 40; }
                                if (scaleCeil > 33 && scaleCeil < 45) { scale = 50; }
                                if (scaleCeil > 44 && scaleCeil < 55) { scale = 60; }
                            }
                            else if (scale > 5.8 && scale < 10.5)
                            {
                                double scaleCeil = System.Math.Ceiling(scale);
                                //scale = scaleCeil + 4.0;          //比例为10、11、12、13、14、15         
                                if (scaleCeil > 5 && scaleCeil < 8) { scale = 10; }
                                if (scaleCeil > 7 && scaleCeil < 12) { scale = 15; }
                            }
                            _currentSheet = (Sheet)__swDrawDoc.GetCurrentSheet();
                            __swDrawDoc.ActivateSheet(_currentSheet.GetName());
                            bool isScale = _currentSheet.SetScale(1, scale, false, false);//设置视图和图纸比例  
                            _swView = __swDrawDoc.GetFirstView();
                            _swView = _swView.GetNextView();//获取视图1
                            double[] pos1 = new double[2];
                            pos1 = _swView.Position;
                            posArry1 = new double[] { pos1[0] - columWidth / 3.45, pos1[1] };
                            _swView.Position = posArry1;//重置视图1的位置
                            _swView = _swView.GetNextView();//获取视图2
                            double[] pos2 = new double[2];
                            pos2 = _swView.Position;
                            posArry2 = new double[] { pos2[0] - columWidth / 3.45, pos2[1] + 0.0015 };
                            _swView.Position = posArry2;//设置视图2位置
                            _swView = _swView.GetNextView();//获取视图三           
                            posArry = (double[])_swView.Position;
                            posArry3 = new double[] { posArry[0] - columWidth / 3.5, posArry[1] };
                            _swView.Position = posArry3;//视图3坐标
                        }
                    }
                }//第一视角投影
                #endregion
                if (isCreate)
                {
                    _numSucess += 1;//转换成功的数量
                    sucessFile.Add(filePath);
                }
                ModelDoc2 tempModelDoc = (ModelDoc2)__swDrawDoc;//获取到swDraw的父级（ModelDoc）   
                _swApp.CloseDoc(_swModelDoc.GetTitle());
                bool isHiden = tempModelDoc.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swViewDisplayHideAllTypes, true); //隐藏所有类型               
              
                _swModelDoc.ForceRebuild3(false);
                string saveName = (_swModelDoc.GetTitle()).Substring(0, (_swModelDoc.GetTitle()).LastIndexOf("."));
                bool ss;
                if (newPath != null&&IfDwg)
                {
                    ss = tempModelDoc.Extension.SaveAs(savePaths + "\\" + (_swModelDoc.GetTitle()) + ".DWG", (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);
                }
                else if (newPath != null && IfDwg==false)
                {
                    ss = tempModelDoc.Extension.SaveAs(savePaths + "\\" + (_swModelDoc.GetTitle()) + ".slddrw", (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);

                }
                else if (newPath == null && IfDwg)
                {
                    ss = tempModelDoc.Extension.SaveAs(savePaths + "\\" + (_swModelDoc.GetTitle()) + ".DWG", (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);
                }
                else
                {
                    ss = tempModelDoc.Extension.SaveAs(savePaths + "\\" + (_swModelDoc.GetTitle()) + ".slddrw", (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);
                }             
                _swApp.CloseDoc(tempModelDoc.GetTitle());//关闭转换完成的文件
            }
        }

        /// <summary>
        /// 只生成等轴测视图
        /// </summary>
        /// <param name="swDraw"></param>
        /// <param name="fileName"></param>
        private void CreatIsometric(DrawingDoc swDraw, string fileName)
        {
            double[] outLine = new double[4];
            Sheet currentSheets = (Sheet)__swDrawDoc.GetCurrentSheet();
            __swDrawDoc.ActivateSheet(currentSheets.GetName());
            _swView = (IView)swDraw.GetFirstView();
            outLine = (double[])_swView.GetOutline();//获取图纸边界
            _swView = (IView)swDraw.CreateDrawViewFromModelView3(fileName, "*等轴测", (outLine[2] - outLine[0]) / 2.0, (outLine[3] - outLine[1]) / 1.5, 0);
        }
        #region 自动添加尺寸
        /// <summary>
        /// 添加尺寸
        /// </summary>
        /// <param name="dimensionType">添加尺寸类型</param>
        /// <param name="swDrawDoc"></param>
        /// <param name="swModel"></param>
        private void AddDimension(string dimensionType, DrawingDoc swDrawDoc, ModelDoc2 swModel)
        {
         
            ModelDocExtension swModelDocExt = (ModelDocExtension)swModel.Extension;
            //swDrawDoc.AutoDimension((int)swAutodimEntities_e.swAutodimEntitiesBasedOnPreselect, (int)swAutodimScheme_e.swAutodimSchemeBaseline, (int)swAutodimHorizontalPlacement_e.swAutodimHorizontalPlacementAbove, (int)swAutodimScheme_e.swAutodimSchemeBaseline, (int)swAutodimVerticalPlacement_e.swAutodimVerticalPlacementRight);
            if (addDimensionNo)
            {
                return;
            }
            else if (addDimensionAuto)
            {
                _currentSheet = (Sheet)swDrawDoc.GetCurrentSheet();
                swDrawDoc.ActivateSheet(_currentSheet.GetName());        
                //swDrawDoc.AutoDimension((int)swAutodimEntities_e.swAutodimEntitiesBasedOnPreselect, (int)swAutodimScheme_e.swAutodimSchemeBaseline, (int)swAutodimHorizontalPlacement_e.swAutodimHorizontalPlacementAbove, (int)swAutodimScheme_e.swAutodimSchemeBaseline, (int)swAutodimVerticalPlacement_e.swAutodimVerticalPlacementRight);
                object[] array3 = (object[])swDrawDoc.InsertModelAnnotations3((int)swImportModelItemsSource_e.swImportModelItemsFromEntireModel, (int)swInsertAnnotation_e.swInsertDimensionsMarkedForDrawing, true, true, false, false);

            }
        }
        #endregion
        #region 改变视图样式
        /// <summary>
        /// 改变视图的显示样式
        /// </summary>
        /// <param name="viewType">视图样式</param>
        /// <param name="swView"></param>
        private void ChangeViewShow(int Tag, IView swView)
        {
            if (Tag == 1)
            {
                swView.SetDisplayMode3(false, (int)swDisplayMode_e.swDisplayModeDEFAULT, false, false);
            }
            if (Tag == 4)
            {
                swView.SetDisplayMode3(false, (int)swDisplayMode_e.swWIREFRAME, false, false);
            }
            if (Tag == 3)
            {
                swView.SetDisplayMode3(false, (int)swDisplayMode_e.swHIDDEN_GREYED, false, false);
            }
            if (Tag == 2)
            {
                swView.SetDisplayMode3(false, (int)swDisplayMode_e.swHIDDEN, false, false);
            }
            if (Tag == 5)
            {
                swView.SetDisplayMode3(false, (int)swDisplayMode_e.swDisplayModeDEFAULT, false, false);
                swView.SetDisplayMode3(false, (int)swDisplayMode_e.swSHADED, false, true);
            }
            if (Tag == 6)
            {
                swView.SetDisplayMode3(false, (int)swDisplayMode_e.swSHADED, false, false);
            }
        }
        #endregion
        #region 比例计算
        /// <summary>
        /// 计算修改比列
        /// </summary>
        /// <param name="box"></param>
        /// <param name="swDraw"></param>
        /// <param name="scale"></param>
        /// <param name="space"></param>
        private double CalcuScale(List<double[]> box, DrawingDoc swDraw, double scale, double space, int viewNum)
        {
            if (box[0][3] > box[0][2] && viewNum == 3)//（纵向）三个视图
            {
                scale = ((box[1][2] - box[1][0]) + (box[3][2] - box[3][0])) / (box[0][2] - space - 0.01);//计算X方向的比例                   
            }
            else if (box[0][3] < box[0][2] && viewNum == 3)//（横向）
            {
                scale = ((box[1][3] - box[1][1]) + (box[2][3] - box[2][1])) / (box[0][3] - space - 0.01);//计算Y方向的比例                   
            }
            else if (box[0][3] > box[0][2] && viewNum == 2)//两个视图（钣金展开用：等轴测+展开图）
            {
                scale = (box[2][2] - box[2][0]) / (box[0][2] - space - 0.01);//计算X方向的比例                 
            }
            else if (box[0][3] < box[0][2] && viewNum == 2)//两个视图（钣金展开用）
            {
                scale = (box[2][3] - box[2][1]) / (box[0][3] - space - 0.01);//计算Y方向的比例                   
            }
            else if (box[0][3] > box[0][2] && viewNum == 1)//（只有等轴测）
            {
                scale = (box[1][2] - box[1][0]) / (box[0][2] - space - 0.01);//计算X方向的比例                 
            }
            else if (box[0][3] < box[0][2] && viewNum == 1)//（只有等轴测）
            {
                scale = (box[1][3] - box[1][1]) / (box[0][3] - space - 0.01);//计算Y方向的比例                   
            }

            if (!stardardScale)
            {
                if (scale > 1.0)
                {
                    if (scale > 11)
                    {
                        double scaleCeil = System.Math.Ceiling(scale);
                        scale = scaleCeil + 6.0;//比例为18+
                    }
                    else if (scale > 5.8 && scale < 10.5)
                    {
                        double scaleCeil = System.Math.Ceiling(scale);
                        scale = scaleCeil + 5;          //比例为10、11、12、13、14、15                  
                    }
                    else
                    {
                        if (scale > 3.84 && scale < 5.85)
                        {
                            double scaleCeil = System.Math.Ceiling(scale);
                            scale = scaleCeil + 3.0;//比例为7、8、9
                        }
                        if (scale > 2.84 && scale < 3.85)
                        {
                            double scaleCeil = System.Math.Ceiling(scale);
                            scale = scaleCeil + 2.0;//比例为5或6
                        }
                        if (scale > 1.35 && scale < 2.85)
                        {
                            double scaleCeil = System.Math.Ceiling(scale);
                            scale = scaleCeil + 1.0;//比例为3或4
                        }
                        if (scale > 1 && scale < 1.36)
                        {
                            double scaleCeil = System.Math.Ceiling(scale);
                            scale = scaleCeil;//比例为2
                        }
                    }
                    _currentSheet = (Sheet)swDraw.GetCurrentSheet();
                    swDraw.ActivateSheet(_currentSheet.GetName());
                    bool isScale = _currentSheet.SetScale(1, scale, false, false);//设置视图和图纸比例
                }
                else if (scale > 0.7 && scale < 1.0)
                {
                    double scaleCeil2 = System.Math.Ceiling(scale);
                    scale = scaleCeil2 + 1.0;
                    _currentSheet = (Sheet)swDraw.GetCurrentSheet();
                    swDraw.ActivateSheet(_currentSheet.GetName());
                    bool isScale = _currentSheet.SetScale(1, scale, false, false);//设置视图和图纸比例
                }
                else//scale<1.0
                {
                    double scaleRound = System.Math.Round(scale, 3);//小数的四舍五入                       
                    if (scaleRound > 0.12 && scaleRound < 0.130)
                    {
                        scale = 50;
                    }
                    if (scaleRound > 0.130 && scaleRound < 0.138)
                    {
                        scale = 40;
                    }
                    if (scaleRound > 0.138 && scaleRound < 0.151)
                    {
                        scale = 20;
                    }
                    if (scaleRound > 0.151 && scaleRound < 0.178)
                    {
                        scale = 10;
                    }
                    if (scaleRound > 0.178 && scaleRound < 0.195)
                    {
                        scale = 6;
                    }
                    if (scaleRound > 0.195 && scaleRound < 0.230)
                    {
                        scale = 5;
                    }
                    if (scaleRound > 0.229 && scaleRound < 0.280)
                    {
                        scale = 4;
                    }
                    if (scaleRound > 0.279 && scaleRound < 0.305)
                    {
                        scale = 3;
                    }
                    if (scaleRound > 0.304 && scaleRound < 0.350)
                    {
                        scale = 2.5;
                    }
                    if (scaleRound > 0.349 && scaleRound < 0.405)
                    {
                        scale = 2;
                    }
                    if (scaleRound > 0.405 && scaleRound < 0.71)
                    {
                        scale = 1;
                    }
                    _currentSheet = (Sheet)swDraw.GetCurrentSheet();
                    swDraw.ActivateSheet(_currentSheet.GetName());
                    bool isScales = _currentSheet.SetScale(scale, 1, false, false);//设置视图和图纸比例
                }
            }
            if (stardardScale)//国标比例
            {
                if (scale > 1.0)
                {
                    if (scale > 11)
                    {
                        double scaleCeil = System.Math.Ceiling(scale);
                        if (scaleCeil > 11 && scaleCeil < 16) { scale = 20; }
                        if (scaleCeil > 15 && scaleCeil < 21) { scale = 25; }
                        if (scaleCeil > 20 && scaleCeil < 26) { scale = 30; }
                        if (scaleCeil > 25 && scaleCeil < 34) { scale = 40; }
                        if (scaleCeil > 33 && scaleCeil < 45) { scale = 50; }
                        if (scaleCeil > 44 && scaleCeil < 55) { scale = 60; }
                    }
                    else if (scale > 5.8 && scale < 10.5)
                    {
                        double scaleCeil = System.Math.Ceiling(scale);
                        //scale = scaleCeil + 4.0;          //比例为10、11、12、13、14、15         
                        if (scaleCeil > 5 && scaleCeil < 8) { scale = 10; }
                        if (scaleCeil > 7 && scaleCeil < 12) { scale = 15; }
                    }
                    else
                    {
                        if (scale > 3.84 && scale < 5.85)
                        {
                            double scaleCeil = System.Math.Ceiling(scale);
                            //scale = scaleCeil + 3.0;//比例为7、8、9
                            if (scaleCeil == 4) { scale = 6; }
                            if (scaleCeil > 4 && scaleCeil < 7) { scale = 10; }
                        }
                        if (scale > 2.84 && scale < 3.85)
                        {
                            double scaleCeil = System.Math.Ceiling(scale);
                            scale = scaleCeil + 2.0;//比例为5或6
                        }
                        if (scale > 1.35 && scale < 2.85)
                        {
                            double scaleCeil = System.Math.Ceiling(scale);
                            scale = scaleCeil + 1.0;//比例为3或4
                        }
                        if (scale > 1 && scale < 1.36)
                        {
                            double scaleCeil = System.Math.Ceiling(scale);
                            scale = scaleCeil;//比例为2
                        }
                    }
                    _currentSheet = (Sheet)swDraw.GetCurrentSheet();
                    swDraw.ActivateSheet(_currentSheet.GetName());
                    bool isScale = _currentSheet.SetScale(1, scale, false, false);//设置视图和图纸比例
                }
                else if (scale > 0.7 && scale < 1.0)
                {
                    double scaleCeil2 = System.Math.Ceiling(scale);
                    scale = scaleCeil2 + 1.0;//比例为2
                    _currentSheet = (Sheet)swDraw.GetCurrentSheet();
                    swDraw.ActivateSheet(_currentSheet.GetName());
                    bool isScale = _currentSheet.SetScale(1, scale, false, false);
                }
                else//scale<1.0
                {
                    double scaleRound = System.Math.Round(scale, 3);//小数的四舍五入                       
                    if (scaleRound > 0.12 && scaleRound < 0.130)
                    {
                        scale = 50;
                    }
                    if (scaleRound > 0.130 && scaleRound < 0.138)
                    {
                        scale = 40;
                    }
                    if (scaleRound > 0.138 && scaleRound < 0.151)
                    {
                        scale = 20;
                    }
                    if (scaleRound > 0.151 && scaleRound < 0.178)
                    {
                        scale = 10;
                    }
                    if (scaleRound > 0.178 && scaleRound < 0.195)
                    {
                        scale = 6;
                    }
                    if (scaleRound > 0.195 && scaleRound < 0.255)
                    {
                        scale = 5;
                    }
                    if (scaleRound > 0.255 && scaleRound < 0.285)
                    {
                        scale = 4;
                    }
                    if (scaleRound > 0.285 && scaleRound < 0.308)
                    {
                        scale = 3;
                    }
                    if (scaleRound > 0.307 && scaleRound < 0.340)
                    {
                        scale = 2.5;
                    }
                    if (scaleRound > 0.339 && scaleRound < 0.405)
                    {
                        scale = 2;
                    }
                    if (scaleRound > 0.405 && scaleRound < 0.71)
                    {
                        scale = 1;
                    }
                    _currentSheet = (Sheet)swDraw.GetCurrentSheet();
                    swDraw.ActivateSheet(_currentSheet.GetName());
                    bool isScales = _currentSheet.SetScale(scale, 1, false, false);//设置视图和图纸比例
                }
            }
            return scale;
        }
        #endregion
    }
}
