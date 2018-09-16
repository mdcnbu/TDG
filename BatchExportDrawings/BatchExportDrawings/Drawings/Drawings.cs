using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;
using MD_SW_ConnectSW;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace BatchExportDrawings.Drawings
{
    /// <summary>
    /// 出工程图类
    /// </summary>
    public class Drawings
    {
        #region 定义全局变量
        private SldWorks swApp;
        private ModelDoc2 swModelDoc;
        private DrawingDoc swDrawDoc;
        private ModelDocExtension swModelEx;
        private Sheet currentSheet;//图表
        private IBody2 swBody;//实体
        private AssemblyDoc swAssembly;
        private Component2 swComp;//sw组件
        private IView swView;//工程视图
        //private PartDoc swPartDoc;
        //private string stDefaultTemplateDraw;
        //internal object object_0;
        //internal MathTransform mathTransform_0;
        private int numSucess;
        List<string> sucessFile = new List<string>();//转换成功的文件       
        private BomTableAnnotation swBomTableAnno = default(BomTableAnnotation);
        #endregion
        #region  公共属性
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

        #region 属性
        /// <summary>
        /// 图纸比例到最优
        /// </summary>
        public bool drawScale { get; set; }
        /// <summary>
        /// 国标比例
        /// </summary>
        public bool stardardScale { get; set; }
        /// <summary>
        /// 钣金展开
        /// </summary>
        public bool sheetMetal { get; set; }
        /// <summary>
        /// 钣金展开是否翻转
        /// </summary>
        public bool sheetFlap { get; set; }
        /// <summary>
        /// 折弯系数表
        /// </summary>
        public bool bendSheet { get; set; }
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
        #endregion
        /// <summary>
        /// 出工程图方法
        /// </summary>
        /// <param name="dicValue">字典集合保存datagridview中的值</param>
        /// <param name="drawPath">图纸路径集合</param>
        /// <param name="bomPath">bom表模板路径</param>
        /// <param name="bendPath">折弯表模板路径</param>
        /// <param name="savePath">图纸保存路径</param>
        public List<string> ExportDrawing(Dictionary<string, string[]> dicValue, List<string> drawPath, string bomPath, string bendPath, string savePath)
        {
            sucessFile.Clear();
            numSucess = 0;
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
                foreach (KeyValuePair<string, string[]> item in dicValue)
                {
                    Step += 1;
                    Dictionary<string, string[]> dicVal = new Dictionary<string, string[]>();
                    dicVal.Add(item.Key, item.Value);
                    string filePath = item.Key;
                    string compName = filePath.Substring(filePath.LastIndexOf("\\") + 1, filePath.LastIndexOf(".") - filePath.LastIndexOf("\\") - 1);//获得文件名
                    if (picNames.IndexOf(compName) != -1)  //判断是否存在同名图纸
                    {
                        DialogResult result = MessageBox.Show("程序检测到保存路径下存在同名图纸：[" + compName + ".SLDDRW]" + "，是否跳过？\n" + "若跳过请单击确定，否则请取消。", "SolidWorks信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            if (AssemBar != null)
                                AssemBar(MaxCount, Step);
                            GapPath.Add(filePath);//保存跳过的图纸
                            continue;//跳过该图纸，执行下一个循环
                        }
                        else
                        {
                            Drawing(dicVal, bomPath, bendPath, savePath);
                            if (AssemBar != null)
                                AssemBar(MaxCount, Step);
                        }
                    }
                    else
                    {
                        Drawing(dicVal, bomPath, bendPath, savePath);
                        if (AssemBar != null)
                            AssemBar(MaxCount, Step);
                    }
                }
            }
            FrmResultShow objFrm = new FrmResultShow(GapPath, numSucess);
            objFrm.Show();
            return sucessFile;
        }
        /// <summary>
        /// 出工程图
        /// </summary>
        /// <param name="dicValues">字典集合</param>
        /// <param name="bomPaths">Bom表模板</param>
        /// <param name="bendPaths">折弯表模板</param>
        /// <param name="savePaths">保存路径</param>
        private void Drawing(Dictionary<string, string[]> dicValues, string bomPaths, string bendPaths, string savePaths)
        {
            string tempPath = string.Empty;
            string projection = string.Empty;
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
            swApp = (SldWorks)ConnectSW.iSwApp;//连接sw
            if (swApp == null) return;
            foreach (KeyValuePair<string, string[]> item in dicValues)
            {
                int errors = 0;
                int warnings = 0;
                double view1X = 0;
                double view1Y = 0;
                string[] dicValue = new string[6];
                string filePath = item.Key;//文件路径
                dicValue = item.Value;//dictionary中的value（string[]类型）               
                tempPath = dicValue[0];//模板路径
                projection = dicValue[1];//投影类型
                viewType = dicValue[2];//视图样式
                isometric = Convert.ToBoolean(dicValue[3]);//等轴测
                bom = Convert.ToBoolean(dicValue[4]);//明细表
                dimesion = dicValue[5];    //尺寸标注方式
                string fileEx = filePath.Substring(filePath.LastIndexOf("."), 7);//获得后缀名
                string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1, filePath.LastIndexOf(".") - filePath.LastIndexOf("\\") - 1);
                if (fileEx == ".SLDPRT")
                {
                    swModelDoc = (ModelDoc2)swApp.OpenDoc6(filePath, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
                }
                if (fileEx == ".SLDASM")
                {
                    swModelDoc = (ModelDoc2)swApp.OpenDoc6(filePath, (int)swDocumentTypes_e.swDocASSEMBLY, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
                }
                swModelEx = (ModelDocExtension)swModelDoc.Extension;
                //新建工程图
                swDrawDoc = (DrawingDoc)swApp.NewDrawing2((int)swDwgTemplates_e.swDwgTemplateCustom, tempPath, (int)swDwgPaperSizes_e.swDwgPapersUserDefined, 0, 0);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swAutomaticScaling3ViewDrawings, true);//自动缩放新工程图比例
                if (standarView == false && isometric)//如果只生成等轴测视图
                {
                    CreatIsometric(swDrawDoc, filePath);
                    bool isMental = IsMentalSheets(swModelDoc);
                    if (isMental)//如果是钣金
                    {
                        if (sheetMetal)//展开（+等轴测）
                        {
                            double[] box = new double[4];
                            double[] posi = new double[2];
                            List<double[]> outBox = new List<double[]>();
                            List<double[]> pos = new List<double[]>();
                            swView = swDrawDoc.GetFirstView();
                            swView = swView.GetNextView();//获取轴测图
                            box = (double[])swView.GetOutline();
                            posi = (double[])swView.Position;
                            outBox.Add(box);
                            pos.Add(posi);
                            SheetPlante(swModelDoc, swDrawDoc, filePath, pos, outBox, 1);//展开
                            outBox.Clear();
                            //swView = swDrawDoc.GetFirstView();
                            //while (swView != null)
                            //{                              
                            //    outBox.Add((double[])swView.GetOutline());
                            //    swView = swView.GetNextView();
                            //}                          
                            //double scales = CalcuScale(outBox, swDrawDoc, scale, spaceX,2);//计算修改比例
                            //if (bendSheet)//是否添加折弯表
                            //{
                            //    InsertBendTable(swDrawDoc, swView, swModelDoc, bendPaths);
                            //}
                        }
                    }
                    currentSheet = (Sheet)swDrawDoc.GetCurrentSheet();
                    swDrawDoc.ActivateSheet(currentSheet.GetName());
                    swView = swDrawDoc.GetFirstView();
                    swView = swView.GetNextView();
                    ChangeViewShow(viewType, swView);
                    swApp.CloseDoc(swModelDoc.GetTitle());//
                    ModelDoc2 tempDoc = (ModelDoc2)swDrawDoc;
                    bool ss = tempDoc.Extension.SaveAs(savePaths + swModelDoc.GetTitle() + ".slddrw", (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);
                    bool isHidden = tempDoc.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swViewDisplayHideAllTypes, true); //隐藏所有类型
                    swApp.CloseDoc(tempDoc.GetTitle());
                    numSucess += 1;//转换成功的数量
                    sucessFile.Add(filePath);
                    return;
                }
                if (standarView == false && isometric == false && sheetMetal)//只出一张展开图
                {
                    bool isMental = IsMentalSheets(swModelDoc);
                    if (isMental)//如果是钣金
                    {
                        double[] box = new double[4];
                        double[] posi = new double[2];
                        List<double[]> outBox = new List<double[]>();
                        List<double[]> pos = new List<double[]>();
                        currentSheet = (Sheet)swDrawDoc.GetCurrentSheet();
                        swDrawDoc.ActivateSheet(currentSheet.GetName());
                        swView = swDrawDoc.GetFirstView();
                        box = (double[])swView.GetOutline();
                        posi = (double[])swView.Position;
                        outBox.Add(box);
                        pos.Add(posi);
                        SheetPlante(swModelDoc, swDrawDoc, filePath, pos, outBox, 0);
                        swView = swDrawDoc.GetFirstView();
                        swView = swView.GetNextView();//获取展开图
                        outBox.Add((double[])swView.GetOutline());
                        double scales = CalcuScale(outBox, swDrawDoc, scale, spaceX, 1);
                    }
                    if (bendSheet)//是否添加折弯表
                    {
                        InsertBendTable(swDrawDoc, swView, swModelDoc, bendPaths);
                    }
                    swApp.CloseDoc(swModelDoc.GetTitle());
                    ModelDoc2 tempDoc = (ModelDoc2)swDrawDoc;
                    bool ss = tempDoc.Extension.SaveAs(savePaths + swModelDoc.GetTitle() + ".slddrw", (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);
                    bool isHidden = tempDoc.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swViewDisplayHideAllTypes, true); //隐藏所有类型
                    swApp.CloseDoc(tempDoc.GetTitle());
                    numSucess += 1;//转换成功的数量
                    sucessFile.Add(filePath);
                    return;
                }
                bool isCreate = false;
                #region 第三视角投影
                if (projection == "第三视角")
                {
                    isCreate = swDrawDoc.Create3rdAngleViews2(filePath);//创建第三视角投影视图(视图位置有差别)
                    //调整视图位置
                    swView = swDrawDoc.GetFirstView();
                    while (swView != null)
                    {
                        double[] vBox = new double[] { };
                        double[] vPoint = new double[] { };
                        vBox = (double[])swView.GetOutline();
                        vPoint = (double[])swView.Position;
                        viewBox.Add(vBox);
                        viewOrigin.Add(vPoint);
                        swView = swView.GetNextView();
                    }
                    //调整视图1、2位置
                    if (viewBox[0][3] > viewBox[0][2])//纵向
                    {
                        double[] posView1 = new double[] { viewBox[0][2]/3.0, viewOrigin[1][1]};
                        swView = swDrawDoc.GetFirstView();
                        swView = swView.GetNextView();
                        swView.Position = posView1;
                        double[] posView2 = new double[] { viewOrigin[2][0], viewOrigin[2][1] - (viewBox[2][1] - viewBox[1][3]) / 1.9 };//调整视图2位置
                        swView = swView.GetNextView();
                        swView.Position = posView2;
                    }
                    else
                    {
                        double[] posView1 = new double[] { viewBox[0][2] / 4.0, viewOrigin[1][1]};
                        swView = swDrawDoc.GetFirstView();
                        swView = swView.GetNextView();
                        swView.Position = posView1;
                        double[] posView2 = new double[] { viewOrigin[2][0], viewOrigin[2][1] - (viewBox[2][1] - viewBox[1][3]) / 2.0 };//调整视图2位置
                        swView = swView.GetNextView();
                        swView.Position = posView2;
                    }
                    viewOrigin.Clear();
                    viewBox.Clear();
                    swView = swDrawDoc.GetFirstView();
                    while (swView != null)
                    {
                        double[] vBox = new double[] { };
                        double[] vPoint = new double[] { };
                        vBox = (double[])swView.GetOutline();
                        vPoint = (double[])swView.Position;
                        viewBox.Add(vBox);
                        viewOrigin.Add(vPoint);
                        swView = swView.GetNextView();
                    }
                    if (isometric)//等轴测
                    {
                        swView = (IView)swDrawDoc.CreateDrawViewFromModelView3(filePath, "*等轴测", viewOrigin[3][0], viewOrigin[2][1], 0);
                        swView = swDrawDoc.GetFirstView();
                        double[] sca = new double[2] ;                       
                         sca=swView.ScaleRatio;//获取比例
                        swView = swView.GetNextView();
                        swView = swView.GetNextView();
                        swView = swView.GetNextView();
                        swView = swView.GetNextView();
                        swView.ScaleRatio = sca;
                        double[] rePos = new double[] { viewOrigin[3][0]+0.015, viewOrigin[2][1] };
                        swView.Position= rePos;
                        ChangeViewShow(viewType, swView);//视图样式
                        AddDimension(dimesion, swDrawDoc, swModelDoc);//尺寸标注
                    }
                    if (IsMentalSheets(swModelDoc))//如果是钣金
                    {
                        if (sheetMetal)//展开
                        {
                            FeatureManager featureMgr = swModelDoc.FeatureManager;
                            FlatPatternFolder flatPatternFolder = default(FlatPatternFolder);
                            flatPatternFolder = (FlatPatternFolder)featureMgr.GetFlatPatternFolder();
                            object[] featArray = new object[] { };
                            featArray = (object[])flatPatternFolder.GetFlatPatterns();
                            if (featArray != null)
                            {
                                for (int i = featArray.GetLowerBound(0); i <= featArray.GetUpperBound(0); i++)
                                {
                                    Feature feat = (Feature)featArray[i];
                                    try
                                    {
                                        if (feat.IsSuppressed() == true) { feat.SetSuppression2((int)swFeatureSuppressionAction_e.swUnSuppressFeature, (int)swInConfigurationOpts_e.swThisConfiguration, null); }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("钣金件未被正常展开：" + ex.Message, "错误提示");
                                    }
                                }
                                if (sheetFlap )//是否翻转
                                {
                                    swView = swDrawDoc.CreateFlatPatternViewFromModelView3(filePath, "", viewOrigin[1][0] + (viewOrigin[3][0] - viewOrigin[1][0]) / 2.0, viewBox[2][3] + 0.03, 0.0, false, true);//创建展开视图
                                }
                                else if (!sheetFlap )
                                {
                                    swView = swDrawDoc.CreateFlatPatternViewFromModelView3(filePath, "", viewOrigin[1][0] + (viewOrigin[3][0]- viewOrigin[1][0]) / 2.0, viewBox[2][3] + 0.03, 0.0, false, false);
                                }                           
                            }
                            if (bendSheet)//插入折弯表
                            {
                                InsertBendTable(swDrawDoc, swView, swModelDoc, bendPaths);
                            }
                        }
                    }
                }
                #endregion
                #region 第一视角投影
                else
                {
                    isCreate = swDrawDoc.Create1stAngleViews(filePath);//创建第一视角投影视图
                    //获取视图boundingbox             
                    swView = swDrawDoc.GetFirstView();
                    while ((swView != null))
                    {
                        outLine = (double[])swView.GetOutline();//(x,y坐标最值)
                        postion = (double[])swView.Position;//视图位置值                   
                        viewBox.Add(outLine);
                        viewOrigin.Add(postion);
                        swView = swView.GetNextView();
                    }
                   
                    double newScale = CalcuScale(viewBox, swDrawDoc, scale, spaceX, 3);
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
                    swView = swDrawDoc.GetFirstView();//获取图纸
                    swView = swView.GetNextView();//获取第一个视图              
                    swView.Position = view1Pos;
                    bool isRebuild = swModelDoc.EditRebuild3();
                    //viewBox.Clear();
                    List<double[]> tempBox = new List<double[]>();
                    viewOrigin.Clear();
                    while ((swView != null))
                    {
                        ChangeViewShow(viewType, swView);//改变视图显示样式
                        AddDimension(dimesion, swDrawDoc, swModelDoc);//添加尺寸
                        outLine = (double[])swView.GetOutline();//(x,y坐标最值)
                        postion = (double[])swView.Position;//视图位置值                   
                        tempBox.Add(outLine);
                        viewOrigin.Add(postion);
                        swView = swView.GetNextView();
                    }
                    //currentSheet = (Sheet)swDrawDoc.GetCurrentSheet();
                    //swDrawDoc.ActivateSheet(currentSheet.GetName());
                    //swView = swDrawDoc.GetFirstView();
                    //swView = swView.GetNextView();
                    //swView = swView.GetNextView();//获取第二个视图
                    // //视图2垂直对齐视图1 
                    //  // double view2Y = view1Y + (viewBox[0][3] - view1Y) + (viewOrigin[1][1] - viewBox[1][1])-2*(viewBox[0][3]-viewBox[0][1]);
                    //double view2Y = view1Y - 4 * (viewBox[0][1] - viewBox[1][3]);
                    //   double[] view2Pos = new double[] { view1X, view2Y };//视图2位置
                    //swView.Position = view2Pos;
                    //swModelDoc.EditRebuild3();
                    ////视图3水平对齐视图1
                    //swView = swView.GetNextView();//获取第三个视图
                    ////double view3X = view1X + (viewOrigin[2][0] - viewBox[2][0]) + 1.2 * (viewBox[0][2] - viewBox[0][0]);
                    //double view3X = view1X + (viewBox[2][0] - viewBox[0][2])*10;
                    //double[] view3Pos = new double[] { view3X, view1Y };//视图3位置
                    //swView.Position = view3Pos;
                    //swModelDoc.EditRebuild3();
                    if (sheetMetal && IsMentalSheets(swModelDoc))//钣金展开（用户勾选钣金展开）
                    {
                        double[] scaleArry = new double[2];
                        //调整视图位置
                        swView = swDrawDoc.GetFirstView();
                        swView = swView.GetNextView();
                        swView = swView.GetNextView();
                        double[] pos = new double[] { viewOrigin[1][0], viewOrigin[1][1] + (tempBox[1][3] - tempBox[1][1]) / 2.2 };//调整视图2位置
                        swView.Position = pos;
                        if (isometric)//等轴测
                        {
                            double[] scalArry = new double[2];
                            swView = (IView)swDrawDoc.CreateDrawViewFromModelView3(filePath, "*等轴测", viewOrigin[2][0], viewOrigin[1][1] + (tempBox[1][3] - tempBox[1][1]) / 2.2, 0);
                        }
                        SheetPlante(swModelDoc, swDrawDoc, filePath, viewOrigin, tempBox, 3);//展开图      
                        //调整比例
                        swView = swDrawDoc.GetFirstView();//获取图纸
                        swView = swView.GetNextView();//获取第一个视图
                        double sca = swView.get_IScaleRatio();
                        if (sca == 1)//缩小比例
                        {
                            scaleArry[0] = 1;
                            scaleArry[1] = newScale;
                        }
                        else
                        {
                            scaleArry[0] = sca;
                            scaleArry[1] = 1;
                        }
                        if (bendSheet)//是否添加折弯表
                        {
                            swView = swView.GetNextView();
                            swView = swView.GetNextView();
                            swView = swView.GetNextView();
                            swView = swView.GetNextView();
                            InsertBendTable(swDrawDoc, swView, swModelDoc, bendPaths);
                        }
                        viewBox.Clear();
                        viewOrigin.Clear();
                        double[] Vbox = new double[4];
                        double[] Vpos = new double[2];
                        currentSheet = (Sheet)swDrawDoc.GetCurrentSheet();
                        swDrawDoc.ActivateSheet(currentSheet.GetName());
                        swView = swDrawDoc.GetFirstView();
                        int viewNum = 0;
                        while (swView != null)
                        {
                            Vbox = (double[])swView.GetOutline();//(x,y坐标最值)
                            Vpos = (double[])swView.Position;//视图位置值                   
                            viewBox.Add(Vbox);
                            viewOrigin.Add(Vpos);
                            viewNum += 1;
                            swView = swView.GetNextView();
                        }
                        swView = swDrawDoc.GetFirstView();
                        swView = swView.GetNextView();
                        swView = swView.GetNextView();
                        swView = swView.GetNextView();
                        swView = swView.GetNextView();
                        if (viewNum == 5)//包含图纸
                        {
                            swView.ScaleRatio = scaleArry;//调整展开图比例              
                            double[] pos4 = new double[] { (viewOrigin[1][0] + viewOrigin[3][0]) / 2.0, viewOrigin[4][1] + (viewBox[2][1] - viewBox[4][3]) / 1.56 };
                            swView.Position = pos4;
                        }
                        else//包含轴测图
                        {
                            double[] pos4 = new double[] { (viewOrigin[1][0] + viewOrigin[3][0]) / 2.0, viewOrigin[5][1] + (viewBox[2][1] - viewBox[5][3]) / 1.56 };
                            swView = swView.GetNextView();//?????
                            swView.ScaleRatio = scaleArry;//调整展开图比例              
                            swView.Position = pos4;
                        }
                    }
                    if (isometric && !IsMentalSheets(swModelDoc))  //是否创建等轴测视图（非钣金）
                    {
                        double[] scalArry = new double[2];
                        swView = (IView)swDrawDoc.CreateDrawViewFromModelView3(filePath, "*等轴测", viewOrigin[2][0], viewOrigin[1][1], 0);
                        swView = swDrawDoc.GetFirstView();//获取图纸
                        swView = swView.GetNextView();//获取第一个视图
                        double sca = swView.get_IScaleRatio();
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
                        swView = swView.GetNextView();
                        swView = swView.GetNextView();
                        swView = swView.GetNextView();
                        swView.ScaleRatio = scalArry;//调整轴测图比例              
                        ChangeViewShow(viewType, swView);
                        swModelDoc.EditRebuild3();
                    }
                    //关掉文件（不保存）
                    swApp.CloseDoc(swModelDoc.GetTitle());
                    if (fileEx == ".SLDASM" && bom)        //是否创建明细表
                    {
                        //viewBox.Clear();
                        //viewOrigin.Clear();
                        double[] outArry = new double[4];
                        double[] posArry = new double[2];
                        double[] posArry1 = null;
                        double[] posArry2 = null;
                        double[] posArry3 = null;
                        currentSheet = (Sheet)swDrawDoc.GetCurrentSheet();
                        swDrawDoc.ActivateSheet(currentSheet.GetName());
                        swView = swDrawDoc.GetFirstView();//获取图纸       
                        swView = swView.GetNextView();//获取第一个视图
                        swBomTableAnno = (BomTableAnnotation)swView.InsertBomTable4(true, 0.4, 0.1, (int)swBOMConfigurationAnchorType_e.swBOMConfigurationAnchor_BottomRight, (int)swBomType_e.swBomType_TopLevelOnly, "", bomPaths, false, 0, false);
                        TableAnnotation tableAnnotation = (TableAnnotation)swBomTableAnno;
                        tableAnnotation.GetAnnotation();
                        BomFeature bomFeature = swBomTableAnno.BomFeature;
                        bool[] array = new bool[bomFeature.GetConfigurationCount(false)];
                        object Visible = array;
                        object configurations = bomFeature.GetConfigurations(false, ref Visible);
                        array[0] = true;
                        bomFeature.SetConfigurations(true, array, configurations);
                        FeatureManager featureManager = swModelDoc.FeatureManager;
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
                        swView = swView.GetNextView();
                        swView = swView.GetNextView();
                        outArry = (double[])swView.GetOutline();
                        if (outArry[1] < heightSum)//有可能被遮挡
                        {
                            //swView = swDrawDoc.GetFirstView();
                            //double[] tempArry = new double[] { };
                            //tempArry=(double[])swView.GetOutline();
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
                            currentSheet = (Sheet)swDrawDoc.GetCurrentSheet();
                            swDrawDoc.ActivateSheet(currentSheet.GetName());
                            bool isScale = currentSheet.SetScale(1, scale, false, false);//设置视图和图纸比例  
                            swView = swDrawDoc.GetFirstView();
                            swView = swView.GetNextView();//获取视图1
                            double[] pos1 = new double[2];
                            pos1 = swView.Position;
                            posArry1 = new double[] { pos1[0] - columWidth / 3.45, pos1[1] };
                            swView.Position = posArry1;//重置视图1的位置
                            swView = swView.GetNextView();//获取视图2
                            double[] pos2 = new double[2];
                            pos2 = swView.Position;
                            posArry2 = new double[] { pos2[0] - columWidth / 3.45, pos2[1] + 0.0015 };
                            swView.Position = posArry2;//设置视图2位置
                            swView = swView.GetNextView();//获取视图三           
                            posArry = (double[])swView.Position;
                            posArry3 = new double[] { posArry[0] - columWidth / 3.5, posArry[1] };
                            swView.Position = posArry3;//视图3坐标
                        }
                    }
                }//第一视角投影
                #endregion
                if (isCreate)
                {
                    numSucess += 1;//转换成功的数量
                    sucessFile.Add(filePath);
                }
                swApp.CloseDoc(swModelDoc.GetTitle());
                ModelDoc2 tempModelDoc = (ModelDoc2)swDrawDoc;//获取到swDraw的父级（ModelDoc）                       
                bool isHiden = tempModelDoc.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swViewDisplayHideAllTypes, true); //隐藏所有类型               
                int err = 0, warn = 0;
                swModelDoc.ForceRebuild3(false);
                string nameEx = swModelDoc.GetTitle() + ".slddrw";
                bool isSave = tempModelDoc.Extension.SaveAs(savePaths + nameEx, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref err, ref warn);
                swApp.CloseDoc(tempModelDoc.GetTitle());//关闭转换完成的文件
            }
        }

        /// <summary>
        /// 判断是否为钣金
        /// </summary>
        /// <param name="swModel"></param>
        /// <returns></returns>
        private bool IsMentalSheets(ModelDoc2 swModel)
        {
            //判断是否是钣金件
            FeatureManager featureMgr = swModel.FeatureManager;
            FlatPatternFolder flatPatternFolder = default(FlatPatternFolder);
            try
            {
                flatPatternFolder = (FlatPatternFolder)featureMgr.GetFlatPatternFolder();
            }
            catch (Exception) { }
            if (flatPatternFolder == null)//不是钣金件
            {
                return false;
            }
            else
            { return true; }
        }
        /// <summary>
        /// 钣金展开
        /// </summary>
        /// <param name="swModel"></param>
        /// <param name="swDraw"></param>
        /// <param name="path"></param>
        /// <param name="pos"></param>
        /// <param name="outLine"></param>
        /// <param name="viewNum"></param>
        private void SheetPlante(ModelDoc2 swModel, DrawingDoc swDraw, string path, List<double[]> pos, List<double[]> outLine, int viewNum)
        {
            FeatureManager featureMgr = swModel.FeatureManager;
            FlatPatternFolder flatPatternFolder = default(FlatPatternFolder);
            flatPatternFolder = (FlatPatternFolder)featureMgr.GetFlatPatternFolder();
            object[] featArray = new object[] { };
            featArray = (object[])flatPatternFolder.GetFlatPatterns();
            if (featArray != null)
            {
                for (int i = featArray.GetLowerBound(0); i <= featArray.GetUpperBound(0); i++)
                {
                    Feature feat = (Feature)featArray[i];
                    try
                    {
                        if (feat.IsSuppressed() == true) { feat.SetSuppression2((int)swFeatureSuppressionAction_e.swUnSuppressFeature, (int)swInConfigurationOpts_e.swThisConfiguration, null); }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("钣金件未被正常展开：" + ex.Message, "错误提示");
                    }
                }
                if (sheetFlap && viewNum == 3)//是否翻转
                {
                    swView = swDrawDoc.CreateFlatPatternViewFromModelView3(path, "", (pos[0][0] + pos[2][0]) / 2.0, outLine[1][1] - 0.025, 0.0, false, true);//创建展开视图
                }
                else if (!sheetFlap && viewNum == 3)
                {
                    swView = swDrawDoc.CreateFlatPatternViewFromModelView3(path, "", (pos[0][0] + pos[2][0]) / 2.0, outLine[1][1] - 0.025, 0.0, false, false);//创建展开视图
                }                
                if (sheetFlap && viewNum == 1)
                {
                    swView = swDrawDoc.CreateFlatPatternViewFromModelView3(path, "", pos[0][0], outLine[0][1] - 0.025, 0.0, false, true);
                }
                else if (!sheetFlap && viewNum == 1)
                {
                    swView = swDrawDoc.CreateFlatPatternViewFromModelView3(path, "", pos[0][0], outLine[0][1] - 0.025, 0.0, false, false);
                }
                else if (!sheetFlap && viewNum == 0)
                {
                    swView = swDrawDoc.CreateFlatPatternViewFromModelView3(path, "", outLine[0][2] / 2.0, outLine[0][3] / 1.8, 0.0, true, false);
                }
                if (sheetFlap && viewNum == 0)//只有展开图
                {
                    swView = swDrawDoc.CreateFlatPatternViewFromModelView3(path, "", outLine[0][2] / 2.0, outLine[0][3] / 1.8, 0.0, false, true);
                }
            }
        }
        /// <summary>
        /// 插入折弯表
        /// </summary>
        /// <param name="swDraw"></param>
        /// <param name="swView"></param>
        /// <param name="swModel"></param>
        private void InsertBendTable(DrawingDoc swDraw, IView swView, ModelDoc2 swModel, string path)
        {
            if (swView == null)
            {
                SolidWorks.Interop.sldworks.View view = (SolidWorks.Interop.sldworks.View)swDraw.ActiveDrawingView;
                if (view == null)
                {
                    MessageBox.Show("请选中钣金展开视图，然后重试！此功能只针对钣金件的图纸！", "只能针对钣金展开视图添加折弯表");
                    return;
                }
                swView = view;
            }
            if (swModel == null)
            {
                swModel = swView.ReferencedDocument;
            }
            try
            {
                BendTableAnnotation bendTableAnnotation = null;
                bendTableAnnotation = swView.InsertBendTable(false, 0, 0, (int)swBOMConfigurationAnchorType_e.swBOMConfigurationAnchor_BottomLeft, "1", path);
                TableAnnotation tableAnnotation = (TableAnnotation)bendTableAnnotation;
                tableAnnotation.GetAnnotation();
                int columnCount = tableAnnotation.ColumnCount;
                int rowCount = tableAnnotation.RowCount;
                int num = -1;
                int num2 = -1;
            }
            catch (Exception ex)
            {

                throw ex;
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
            Sheet currentSheets = (Sheet)swDrawDoc.GetCurrentSheet();
            swDrawDoc.ActivateSheet(currentSheets.GetName());
            swView = (IView)swDraw.GetFirstView();
            outLine = (double[])swView.GetOutline();//获取图纸边界
            swView = (IView)swDraw.CreateDrawViewFromModelView3(fileName, "*等轴测", (outLine[2] - outLine[0]) / 2.0, (outLine[3] - outLine[1]) / 1.5, 0);
        }

        /// <summary>
        /// 改变视图的显示样式
        /// </summary>
        /// <param name="viewType">视图样式</param>
        /// <param name="swView"></param>
        private void ChangeViewShow(string viewType, IView swView)
        {
            if (viewType == "默认")
            {
                swView.SetDisplayMode3(false, (int)swDisplayMode_e.swDisplayModeDEFAULT, false, false);
            }
            if (viewType == "线架图")
            {
                swView.SetDisplayMode3(false, (int)swDisplayMode_e.swWIREFRAME, false, false);
            }
            if (viewType == "隐藏线可见")
            {
                swView.SetDisplayMode3(false, (int)swDisplayMode_e.swHIDDEN_GREYED, false, false);
            }
            if (viewType == "消除隐藏线")
            {
                swView.SetDisplayMode3(false, (int)swDisplayMode_e.swHIDDEN, false, false);
            }
            if (viewType == "带边线上色")
            {
                swView.SetDisplayMode3(false, (int)swDisplayMode_e.swDisplayModeDEFAULT, false, false);
                swView.SetDisplayMode3(false, (int)swDisplayMode_e.swSHADED, false, true);
            }
            if (viewType == "上色")
            {
                swView.SetDisplayMode3(false, (int)swDisplayMode_e.swSHADED, false, false);
            }
        }

        /// <summary>
        /// 添加尺寸
        /// </summary>
        /// <param name="dimensionType">添加尺寸类型</param>
        /// <param name="swDrawDoc"></param>
        /// <param name="swModel"></param>
        private void AddDimension(string dimensionType, DrawingDoc swDrawDoc, ModelDoc2 swModel)
        {
            //int selmark1 = 0;
            //int selmark2 = 0;
            //int selmark3 = 0;
            ModelDocExtension swModelDocExt = (ModelDocExtension)swModel.Extension;
            //swDrawDoc.AutoDimension((int)swAutodimEntities_e.swAutodimEntitiesBasedOnPreselect, (int)swAutodimScheme_e.swAutodimSchemeBaseline, (int)swAutodimHorizontalPlacement_e.swAutodimHorizontalPlacementAbove, (int)swAutodimScheme_e.swAutodimSchemeBaseline, (int)swAutodimVerticalPlacement_e.swAutodimVerticalPlacementRight);
            if (dimensionType == "手动标注尺寸")
            {
                return;
            }
            else if (dimensionType == "推荐的尺寸")
            {
                currentSheet = (Sheet)swDrawDoc.GetCurrentSheet();
                swDrawDoc.ActivateSheet(currentSheet.GetName());
                //swView = swDrawDoc.GetFirstView();
                //swView = swView.GetNextView();
                //GetSketchLinePos(swView);
                //selmark3 = (int)swAutodimMark_e.swAutodimMarkEntities;
                //selmark1 = (int)swAutodimMark_e.swAutodimMarkHorizontalDatum;
                //bool status = swModelDocExt.SelectByID2("", "VERTEX", list_1[0], list_1[1], 0, true, selmark1, null, 0);
                //bool status1 = swModelDocExt.SelectByID2("", "EDGE", list_1[0], list_1[1], 0, true, selmark1, null, 0);
                //selmark2 = (int)swAutodimMark_e.swAutodimMarkVerticalDatum;
                //bool statusS = swModelDocExt.SelectByID2("", "EDGE", list_2[0], list_2[1], 0, true, selmark2, null, 0);
                //swDrawDoc.AutoDimension((int)swAutodimEntities_e.swAutodimEntitiesBasedOnPreselect, (int)swAutodimScheme_e.swAutodimSchemeBaseline, (int)swAutodimHorizontalPlacement_e.swAutodimHorizontalPlacementAbove, (int)swAutodimScheme_e.swAutodimSchemeBaseline, (int)swAutodimVerticalPlacement_e.swAutodimVerticalPlacementRight);
                object[] array3 = (object[])swDrawDoc.InsertModelAnnotations3((int)swImportModelItemsSource_e.swImportModelItemsFromEntireModel, (int)swInsertAnnotation_e.swInsertDimensionsMarkedForDrawing, true, true, false, false);

            }
        }
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
            if (drawScale)
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
                    currentSheet = (Sheet)swDraw.GetCurrentSheet();
                    swDraw.ActivateSheet(currentSheet.GetName());
                    bool isScale = currentSheet.SetScale(1, scale, false, false);//设置视图和图纸比例
                }
                else if (scale > 0.7 && scale < 1.0)
                {
                    double scaleCeil2 = System.Math.Ceiling(scale);
                    scale = scaleCeil2 + 1.0;
                    currentSheet = (Sheet)swDraw.GetCurrentSheet();
                    swDraw.ActivateSheet(currentSheet.GetName());
                    bool isScale = currentSheet.SetScale(1, scale, false, false);//设置视图和图纸比例
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
                    currentSheet = (Sheet)swDraw.GetCurrentSheet();
                    swDraw.ActivateSheet(currentSheet.GetName());
                    bool isScales = currentSheet.SetScale(scale, 1, false, false);//设置视图和图纸比例
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
                    currentSheet = (Sheet)swDraw.GetCurrentSheet();
                    swDraw.ActivateSheet(currentSheet.GetName());
                    bool isScale = currentSheet.SetScale(1, scale, false, false);//设置视图和图纸比例
                }
                else if (scale > 0.7 && scale < 1.0)
                {
                    double scaleCeil2 = System.Math.Ceiling(scale);
                    scale = scaleCeil2 + 1.0;//比例为2
                    currentSheet = (Sheet)swDraw.GetCurrentSheet();
                    swDraw.ActivateSheet(currentSheet.GetName());
                    bool isScale = currentSheet.SetScale(1, scale, false, false);
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
                    currentSheet = (Sheet)swDraw.GetCurrentSheet();
                    swDraw.ActivateSheet(currentSheet.GetName());
                    bool isScales = currentSheet.SetScale(scale, 1, false, false);//设置视图和图纸比例
                }
            }
            return scale;
        }
    }
}
