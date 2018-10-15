using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Models;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;
using System.Runtime.InteropServices;


namespace FrmReducerDesignerApplication
{
    #region 声明委托（1,2,3）定义在类的外部
    public delegate void GetParaSpur1(double dia1, double wid1, double deep1);
    public delegate void GetParaSpur2(double dia1, double dia2, double dia3, double dia4, double banThick, double guWidth, double holeDia, int holeNum, double keyW, double keyD);
    public delegate void GetParaSpur3(List<string[]> para1, List<string[]> para2);
    public delegate void GetParaSpur4(double D1, double D2, double D3, double D4, double L1, double L2, double L3, double L4, double L5, double B1, double B, int num);
    #endregion
    public partial class FrmUnstandardized : Form
    {
        private GearValuesService objGearService = new GearValuesService();
        /// <summary>
        /// 初始化 构造方法
        /// </summary>
        public FrmUnstandardized()
        {
            InitializeComponent();
            #region 绑定下拉框内容
            this.cboModule.DataSource = objGearService.GetModul();
            this.cboModule.DisplayMember = "GearModul";
            this.cboModule.SelectedIndex = -1;
            this.cboGearNum.DataSource = objGearService.GetNums();
            this.cboGearNum.DisplayMember = "GearNum";
            this.cboGearNum.SelectedIndex = -1;
            this.cboGearStyle.DataSource = objGearService.GetType();
            this.cboGearStyle.DisplayMember = "GearTypes";
            this.cboScale.DataSource = objGearService.GetModul();
            this.cboScale.DisplayMember = "GearModul";
            this.cboScale.SelectedIndex = -1;
            this.cboHelixNum.DataSource = objGearService.GetNums();
            this.cboHelixNum.DisplayMember = "GearNum";
            this.cboHelixNum.SelectedIndex = -1;
            this.cboHelixType.DataSource = objGearService.GetType();
            this.cboHelixType.DisplayMember = "GearTypes";
            this.cboInnerModule.DataSource = objGearService.GetModul();
            this.cboInnerModule.DisplayMember = "GearModul";
            this.cboInnerModule.SelectedIndex = -1;
            this.cboInnerNum.DataSource = objGearService.GetNums();
            this.cboInnerNum.DisplayMember = "GearNum";
            this.cboInnerNum.SelectedIndex = -1;
            this.cboSmallNum.DataSource = objGearService.GetNums();
            this.cboSmallNum.DisplayMember = "GearNum";
            this.cboSmallNum.SelectedIndex = -1;
            this.cboBigNum.DataSource = objGearService.GetNums();
            this.cboBigNum.DisplayMember = "GearNum";
            this.cboBigNum.SelectedIndex = -1;
            this.cboBevelMoudle.DataSource = objGearService.GetModul();
            this.cboBevelMoudle.DisplayMember = "GearModul";
            this.cboBevelMoudle.SelectedIndex = -1;
            # endregion
        }
        # region 全局变量
        private SldWorks swApp;
        private ModelDoc2 swModel;
        private ModelDocExtension swModelEx;
        private ModelView swModelView;
        private FeatureManager swFeatMgr;
        private SketchManager swSketchMgr;
        private SketchPoint swSketchPt;
        //private Sketch swSketch;//该字段在获取草图中点的坐标
        private string stDefaultTemplatePart;
        public const double PI = 3.14159265;
        //定义数组实现坐标点的存取
        double[] pointData = new double[14];
        //定义样条曲线坐标点
        double[] pointArry1 = new double[24];//<42时
        double[] pointArry2 = new double[21];//>=42时
        //定义旋转之后的坐标点数组
        private dynamic sketchPointArry;
        //窗体1变量值
        double sty1dia, sty1wid, sty1deep;
        //窗体2变量值
        double sty2dia1, sty2dia2, sty2dia3, sty2dia4, sty2banThick, sty2guWidth, sty2holeDia, sty2keyW, sty2keyD;
        int sty2holeNum;
        /// <summary>
        /// 窗体3变量值
        /// </summary>
        public List<string[]> sty3Para1 = new List<string[]>();
        public List<string[]> sty3Para2 = new List<string[]>();
        //窗体4变量值
        double sty4D1, sty4D2, sty4D3, sty4D4, sty4L1, sty4L2, sty4L3, sty4L4, sty4L5, sty4B1, sty4B;
        int sty4Num;
        //保存路径
        string savePathSpur = string.Empty;
        string savePathInner = string.Empty;
        string savePathCarrier = string.Empty;
        string savePathPlanet = string.Empty;
        #endregion

        #region 验证直齿轮输入数据方法
        /// <summary>
        /// 验证输入数据-------------
        /// </summary>
        public void VerificationInput()
        {
            string gearNum = this.cboGearNum.Text;//齿数
            string gearWidth = this.txtGearWidth.Text;//齿宽
            string higthScale = this.txtHighModule.Text;//顶高系数
            string pressureAngl = this.txtAngle.Text;//压力角
            string gearScale = this.cboModule.Text;//模数         
            string xiScale = this.txtXiModule.Text;//顶隙系数    
            string shiftCoeffiicient = this.txtShiftModule.Text;//变位系数
            if (!VerificationIsDigital(gearScale))
            {
                throw new Exception("模数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(gearNum))
            {
                throw new Exception("齿数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(pressureAngl))
            {
                throw new Exception("压力角值不是有效数字，请重新输入！");
            }

            if (!VerificationIsDigital(higthScale))
            {
                throw new Exception("顶高系数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(xiScale))
            {
                throw new Exception("顶隙系数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(shiftCoeffiicient))
            {
                throw new Exception("变位系数不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(gearWidth))
            {
                throw new Exception("齿宽值不是有效数字，请重新输入！");
            }
        }
        /// <summary>
        /// 验证是否是数字---------
        /// </summary>
        /// <param name="value">验证内容</param>
        /// <returns></returns>
        private bool VerificationIsDigital(string value)
        {
            if (Regex.IsMatch(value, @"^\d+(.\d+)?$"))
            {
                return true;
            }
            return false;
        }
        #endregion
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
        #region 文档框最大化
        /// <summary>
        /// 文档框最大化
        /// </summary>
        public void FramMax()
        {
            swModelView = swModel.ActiveView as ModelView;
            swModelView.FrameState = (int)swWindowState_e.swWindowMaximized;
        }
        #endregion
        #region 显示视图视角方法
        /// <summary>
        /// 显示视图视角
        /// </summary>
        /// <param name="viewName">视角名称</param>
        public void ViewShow(string viewName)
        {
            int viewId = 1;
            switch (viewName)
            {
                case "Front":
                case "前视":
                    viewId = (int)swStandardViews_e.swFrontView;
                    break;
                case "Back":
                case "后视":
                    viewId = (int)swStandardViews_e.swBackView;
                    break;
                case "Left":
                case "左视":
                    viewId = (int)swStandardViews_e.swLeftView;
                    break;
                case "Right":
                case "右视":
                    viewId = (int)swStandardViews_e.swRightView;
                    break;
                case "Top":
                case "上视":
                    viewId = (int)swStandardViews_e.swTopView;
                    break;
                case "Bottom":
                case "下视":
                    viewId = (int)swStandardViews_e.swBottomView;
                    break;
                case "Isometric":
                case "等轴测":
                    viewId = (int)swStandardViews_e.swIsometricView;
                    break;
                case "Trimetric":
                case "上下二等轴测":
                    viewId = (int)swStandardViews_e.swTrimetricView;
                    break;
                case "Dimetric":
                case "左右二等轴测":
                    viewId = (int)swStandardViews_e.swDimetricView;
                    break;
                default:
                    break;
            }
            //显示视图
            swModel.ShowNamedView2(string.Empty, viewId);
            //调整视图大小
            swModel.ViewZoomtofit2();
        }
        #endregion
        #region 新建零件方法
        /// <summary>
        /// x新建零件
        /// </summary>
        public void NewPart()
        {   //默认模版
            stDefaultTemplatePart = swApp.GetUserPreferenceStringValue((int)swUserPreferenceStringValue_e.swDefaultTemplatePart);
            if (stDefaultTemplatePart == "" || !File.Exists(stDefaultTemplatePart))
            {
                stDefaultTemplatePart = Application.StartupPath + @"\Q235B(ZOWELL).prtdot";
                if (!File.Exists(stDefaultTemplatePart))
                {
                    throw new Exception("找不到模版文件，新建零件错误");
                }
            }
            //新建>>>零件-----------------------------
            //swModel=(ModelDoc2)swApp.NewDocument(,0)
            swModel = (ModelDoc2)swApp.NewDocument(stDefaultTemplatePart, 0, 0, 0);//注意：括号里面不能加双引号
            if (swModel == null)
            {
                throw new Exception("新建零件发生错误！");
            }
        }
        #endregion
        #region 生成直齿轮的方法\
        /// <summary>
        /// 生成直齿轮
        /// </summary>
        /// <param name="gearModule">模数</param>
        /// <param name="gearNum">齿数</param>
        /// <param name="pressureAngl">压力角</param>
        /// <param name="higthModule">顶高系数</param>
        /// <param name="xiModule">顶隙系数</param>
        /// <param name="shiftModule">变位系数</param>
        /// <param name="gearWidth">齿宽</param>
        private void GenerateGear(double gearModule, int gearNum, double pressureAngl, double higthModule, double xiModule, double shiftModule, double gearWidth)
        {
            //单位转换
            gearModule = gearModule / 1000.0;
            pressureAngl = pressureAngl * (System.Math.PI) / 180;//把角度转换为弧度值
            higthModule /= 1000.0;
            xiModule /= 1000.0;
            shiftModule /= 1000.0;
            gearWidth /= 1000.0;
            //计算分度圆半径
            double radiusFen = (gearModule * gearNum) / 2.0;
            //计算齿顶圆半径
            double radiusTop = radiusFen + (higthModule + shiftModule) * gearModule * 1000.0;
            //计算齿根圆半径
            double radiusBottom = radiusFen - (higthModule + xiModule - shiftModule) * gearModule * 1000.0;
            //计算基圆半径
            double baseRadius = radiusFen * (System.Math.Cos(pressureAngl));
            //插入基准轴
            swModelEx = swModel.Extension;
            swModelEx.SelectByID2("上视基准面", "PLANE", 0, 0, 0, true, 0, null, 0);
            swModelEx.SelectByID2("右视基准面", "PLANE", 0, 0, 0, true, 0, null, 0);
            swModel.InsertAxis2(true);
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            //新建草图
            swSketchMgr = (SketchManager)swModel.SketchManager;
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusTop);
            swSketchMgr.InsertSketch(true);
            ViewShow("等轴测");//视角
            //拉伸齿坯（齿顶圆）
            swModel.Extension.SelectByID2("草图1", "SKETCH", 0, 0, 0, false, 0, null, 0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat = swFeatMgr.FeatureExtrusion2(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, gearWidth, 0,
                                                                                            false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);
            swModel.ClearSelection2(true);
            //绘制渐开线齿廓草图
            ViewShow("前视");
            swModelEx.SelectByID2("", "FACE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr = (SketchManager)swModel.SketchManager;
            swSketchMgr.InsertSketch(true);
            if (gearNum < 42)
            {
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, false);
                //计算齿廓终点时的压力角
                double endAngl2 = System.Math.Sqrt((radiusTop * radiusTop) / (baseRadius * baseRadius) - 1.0);
                //计算压力角的增加量
                double angleIncrea = endAngl2 / 6.0;
                //循环实现坐标点的选取
                for (int i = 0; i <= 6; i++)
                {
                    //double radiusI = baseRadius + i * increase;//计算r(i)的值,//之前用的是齿根圆radiusBottom + i * increase====
                    //double angleI = System.Math.Acos(baseRadius / radiusI);//计算在（i）点的压力角，此时输出的角度为弧度值之前用的是齿根圆radiusBottom / radiusI====
                    //double invAngle = System.Math.Tan(angleI) - angleI;//得到（i）点处的渐开线函数
                    //计算直角坐标系下各点的坐标值
                    double xI = baseRadius * System.Math.Sin(angleIncrea * i * 1.0) - baseRadius * (angleIncrea * i * 1.0) * System.Math.Cos(angleIncrea * i * 1.0);
                    double yI = baseRadius * (System.Math.Cos(angleIncrea * i * 1.0) + (angleIncrea * i * 1.0) * System.Math.Sin(angleIncrea * i * 1.0));
                    if (i == 0)
                    {
                        pointData[i] = xI;//存放X1点的坐标值
                        pointData[i + 1] = yI;//存放Y1点的坐标值
                    }
                    else if (i == 1)
                    {
                        pointData[i + 1] = xI;//存放X2点的坐标值
                        pointData[i + 2] = yI;//存放Y2点的坐标值
                    }
                    else if (i == 2)
                    {
                        pointData[i + 2] = xI;//存放X3点的坐标值
                        pointData[i + 3] = yI;//存放Y3点的坐标值
                    }
                    else if (i == 3)
                    {
                        pointData[i + 3] = xI;//存放X4点的坐标值
                        pointData[i + 4] = yI;//存放Y4点的坐标值
                    }
                    else if (i == 4)
                    {
                        pointData[i + 4] = xI;//存放X5点的坐标值
                        pointData[i + 5] = yI;//存放Y5点的坐标值
                    }
                    else if (i == 5)
                    {
                        pointData[i + 5] = xI;//存放X6点的坐标值
                        pointData[i + 6] = yI;//存放Y6点的坐标值
                    }
                    else if (i == 6)
                    {
                        pointData[i + 6] = xI;//存放X7点的坐标值
                        pointData[i + 7] = yI;//存放Y7点的坐标值
                    }
                    //根据坐标创建草图点
                    swSketchMgr.CreatePoint(xI, yI, 0);
                }
                //求齿根处点的坐标，利用Y1和Y2点计算直线的斜率k和常量b的值
                double k = (pointData[3] - pointData[1]) / (pointData[2] - pointData[0]);
                double b = pointData[3] - k * pointData[2];
                //联立齿根圆方程计算出齿根处点的X,Y坐标值
                double pointxo = -((-2 * k * b) + System.Math.Sqrt(4.0 * k * k * b * b - (4.0 + 4.0 * k * k) * (radiusBottom * radiusBottom - b * b))) / (2.0 + 2.0 * k * k);
                double pointyo = System.Math.Sqrt((radiusBottom * radiusBottom) - (pointxo * pointxo));
                swSketchMgr.CreatePoint(pointxo, pointyo, 0);
                //建立样条曲线坐标点的数组
                pointArry1[0] = pointxo;
                pointArry1[1] = pointyo;
                pointArry1[2] = 0.0;
                pointArry1[3] = pointData[0];
                pointArry1[4] = pointData[1];
                pointArry1[5] = 0.0;
                pointArry1[6] = pointData[2];
                pointArry1[7] = pointData[3];
                pointArry1[8] = 0.0;
                pointArry1[9] = pointData[4];
                pointArry1[10] = pointData[5];
                pointArry1[11] = 0.0;
                pointArry1[12] = pointData[6];
                pointArry1[13] = pointData[7];
                pointArry1[14] = 0.0;
                pointArry1[15] = pointData[8];
                pointArry1[16] = pointData[9];
                pointArry1[17] = 0.0;
                pointArry1[18] = pointData[10];
                pointArry1[19] = pointData[11];
                pointArry1[20] = 0.0;
                pointArry1[21] = pointData[12];
                pointArry1[22] = pointData[13];
                pointArry1[23] = 0.0;
                //创建压力角处的点坐标
                double xF = baseRadius * System.Math.Sin(pressureAngl) - baseRadius * (pressureAngl) * System.Math.Cos(pressureAngl);
                double yF = baseRadius * (System.Math.Cos(pressureAngl) + (pressureAngl) * System.Math.Sin(pressureAngl));
                //勾股定理求出压力角半径大小
                double radiusF = System.Math.Sqrt(xF * xF + yF * yF);
                //求出该点处压力角阿尔法的大小
                double angleF = System.Math.Acos(baseRadius / radiusF);
                //求出该点处的展角大小（渐开线函数）
                double invAngle = System.Math.Tan(angleF) - angleF;
                //计算齿槽角大小
                double angleWidth = (2 * System.Math.PI) / (4 * gearNum);
                //计算旋转角度大小
                double angleRotate = angleWidth - invAngle;
                //绘制样条曲线
                swSketchMgr.CreateSpline(pointArry1);
                swModelEx.SelectByID2("点1", "SKETCHPOINT", pointData[0], pointData[1], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点2", "SKETCHPOINT", pointData[2], pointData[3], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点3", "SKETCHPOINT", pointData[4], pointData[5], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点4", "SKETCHPOINT", pointData[6], pointData[7], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点5", "SKETCHPOINT", pointData[8], pointData[9], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点6", "SKETCHPOINT", pointData[10], pointData[11], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点7", "SKETCHPOINT", pointData[12], pointData[13], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点8", "SKETCHPOINT", pointxo, pointyo, 0, true, 0, null, 0);
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry1[15], pointArry1[16], 0, true, 0, null, 0);
                //旋转样条曲线
                swModel.Extension.RotateOrCopy(false, 0, true, 0, 0, 0, 0, 0, 1, -angleRotate);
                //绘制镜像对称轴
                swSketchMgr.CreateCenterLine(0, 0, 0, 0, radiusTop + 0.0009, 0);
                //镜像渐开线并修剪对称轴
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry1[15], pointArry1[16], 0, true, 0, null, 0);
                swModel.SketchMirror();
                swModelEx.SelectByID2("直线1", "SKETCHSEGMENT", 0, (gearNum * gearModule / 2.0), 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, 0, 0);
                //转换实体引用齿顶圆
                swModelEx.SelectByID2("", "FACE", 0, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchUseEdge2(false);
                //修剪齿顶圆
                swModelEx.SelectByID2("", "SKETCHSEGMENT", radiusTop, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusTop, 0, 0);
                //创建齿根圆并修剪
                swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusBottom);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusBottom, 0, 0);
                //绘制齿根圆角            
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, true);
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swModelEx.SelectByID2("", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearModule, 1);//圆角半径取经验值ρ=0.38m            
                swModel.DeSelectByID("样条曲线1", "SKETCHSEGMENT", 0, 0, 0);
                swModel.DeSelectByID("", "SKETCHSEGMENT", 0, radiusBottom, 0);
                swModelEx.SelectByID2("样条曲线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swModelEx.SelectByID2("", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearModule, 1);
                //拉伸切除齿廓
                swFeatMgr = swModel.FeatureManager as FeatureManager;
                Feature feat1 = swFeatMgr.FeatureCut3(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, gearWidth, 0,
                                                                                                false, false, false, false, 0, 0, false, false, false, false, false, false, false, false, false, false, 0, 0, false);

                //圆周阵列齿廓
                swModelEx.SelectByID2("基准轴1", "AXIS", 0, 0, 0, true, 1, null, 0);
                swModelEx.SelectByID2("切除-拉伸1", "BODYFEATURE", 0, 0, 0, false, 4, null, 0);
                swFeatMgr = swModel.FeatureManager as FeatureManager;
                Feature feat2 = swFeatMgr.FeatureCircularPattern3(gearNum, 6.2831853071796, false, "", false, true);
                swModel.ClearSelection2(true);
                //swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
                //swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusFen);
                //swSketchMgr.CreateConstructionGeometry();
                //swSketchMgr.InsertSketch(true);
            }

            else if (gearNum >= 42)
            {
                //计算齿廓终点时的压力角（tan阿尔法表示整个圆心角的大小）
                double endAngl2 = System.Math.Sqrt((radiusTop * radiusTop) / (baseRadius * baseRadius) - 1.0);
                //计算角度的增加量
                double angleIncrea = endAngl2 / 6.0;
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, false);
                //循环实现坐标点的选取
                for (int i = 0; i <= 6; i++)
                {
                    //计算直角坐标系下各点的坐标值
                    double xI = baseRadius * System.Math.Sin(angleIncrea * i * 1.0) - baseRadius * (angleIncrea * i * 1.0) * System.Math.Cos(angleIncrea * i * 1.0);
                    double yI = baseRadius * (System.Math.Cos(angleIncrea * i * 1.0) + (angleIncrea * i * 1.0) * System.Math.Sin(angleIncrea * i * 1.0));
                    if (i == 0)
                    {
                        pointData[i] = xI;//存放X1点的坐标值
                        pointData[i + 1] = yI;//存放Y1点的坐标值
                    }
                    else if (i == 1)
                    {
                        pointData[i + 1] = xI;//存放X2点的坐标值
                        pointData[i + 2] = yI;//存放Y2点的坐标值
                    }
                    else if (i == 2)
                    {
                        pointData[i + 2] = xI;//存放X3点的坐标值
                        pointData[i + 3] = yI;//存放Y3点的坐标值
                    }
                    else if (i == 3)
                    {
                        pointData[i + 3] = xI;//存放X4点的坐标值
                        pointData[i + 4] = yI;//存放Y4点的坐标值
                    }
                    else if (i == 4)
                    {
                        pointData[i + 4] = xI;//存放X5点的坐标值
                        pointData[i + 5] = yI;//存放Y5点的坐标值
                    }
                    else if (i == 5)
                    {
                        pointData[i + 5] = xI;//存放X6点的坐标值
                        pointData[i + 6] = yI;//存放Y6点的坐标值
                    }
                    else if (i == 6)
                    {
                        pointData[i + 6] = xI;//存放X7点的坐标值
                        pointData[i + 7] = yI;//存放Y7点的坐标值
                    }
                    //根据坐标创建草图点
                    swSketchMgr.CreatePoint(xI, yI, 0);
                }
                //建立样条曲线坐标点的数组             
                pointArry2[0] = pointData[0];
                pointArry2[1] = pointData[1];
                pointArry2[2] = 0.0;
                pointArry2[3] = pointData[2];
                pointArry2[4] = pointData[3];
                pointArry2[5] = 0.0;
                pointArry2[6] = pointData[4];
                pointArry2[7] = pointData[5];
                pointArry2[8] = 0.0;
                pointArry2[9] = pointData[6];
                pointArry2[10] = pointData[7];
                pointArry2[11] = 0.0;
                pointArry2[12] = pointData[8];
                pointArry2[13] = pointData[9];
                pointArry2[14] = 0.0;
                pointArry2[15] = pointData[10];
                pointArry2[16] = pointData[11];
                pointArry2[17] = 0.0;
                pointArry2[18] = pointData[12];
                pointArry2[19] = pointData[13];
                pointArry2[20] = 0.0;
                //创建压力角处的点坐标
                double xF = baseRadius * System.Math.Sin(pressureAngl) - baseRadius * (pressureAngl) * System.Math.Cos(pressureAngl);
                double yF = baseRadius * (System.Math.Cos(pressureAngl) + (pressureAngl) * System.Math.Sin(pressureAngl));
                //勾股定理求出压力角半径大小
                double radiusF = System.Math.Sqrt(xF * xF + yF * yF);
                //求出该点处压力角阿尔法的大小
                double angleF = System.Math.Acos(baseRadius / radiusF);
                //求出该点处的展角大小（渐开线函数）
                double invAngle = System.Math.Tan(angleF) - angleF;
                //计算齿槽角大小
                double angleWidth = (2 * System.Math.PI) / (4 * gearNum);
                //计算旋转角度大小
                double angleRotate = angleWidth - invAngle;
                //绘制样条曲线
                swSketchMgr.CreateSpline(pointArry2);
                swModelEx.SelectByID2("点1", "SKETCHPOINT", pointData[0], pointData[1], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点2", "SKETCHPOINT", pointData[2], pointData[3], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点3", "SKETCHPOINT", pointData[4], pointData[5], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点4", "SKETCHPOINT", pointData[6], pointData[7], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点5", "SKETCHPOINT", pointData[8], pointData[9], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点6", "SKETCHPOINT", pointData[10], pointData[11], 0, true, 0, null, 0);
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry2[15], pointArry2[16], 0, true, 0, null, 0);
                //旋转样条曲线
                swModel.Extension.RotateOrCopy(false, 0, true, 0, 0, 0, 0, 0, 1, -angleRotate);
                //获取旋转后点的坐标值，创建对象实例
                swSketchMgr = (SketchManager)swModel.SketchManager;
                Sketch swSketch = (Sketch)swModel.GetActiveSketch2();
                sketchPointArry = swSketch.GetSketchPoints2();
                double x0 = 0.0, y0 = 0.0, x1 = 0.0, y1 = 0.0;
                for (int i = 0; i <= sketchPointArry.Length - 1; i++)
                {
                    if (i == 0)
                    {
                        swSketchPt = sketchPointArry[i];
                        x0 = swSketchPt.X;//获取第一个点的x坐标
                        y0 = swSketchPt.Y;//获取第一个点的y坐标                        
                    }
                    if (i == 1)
                    {
                        swSketchPt = sketchPointArry[i];
                        x1 = swSketchPt.X;//获取第二个点的x坐标
                        y1 = swSketchPt.Y;//获取第二个点的y坐标                        
                    }
                }
                //绘制镜像对称轴
                swSketchMgr.CreateCenterLine(0, 0, 0, 0, radiusTop + 0.0009, 0);
                //镜像渐开线并修剪对称轴
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry2[15], pointArry2[16], 0, true, 0, null, 0);
                swModel.SketchMirror();
                swModelEx.SelectByID2("直线1", "SKETCHSEGMENT", 0, radiusFen, 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, 0, 0);
                //转换实体引用齿顶圆
                swModelEx.SelectByID2("", "FACE", 0, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchUseEdge2(false);
                //修剪齿顶圆
                swModelEx.SelectByID2("", "SKETCHSEGMENT", radiusTop, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusTop, 0, 0);
                //创建齿根圆并修剪
                swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusBottom);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusBottom, 0, 0);
                //修剪渐开线与齿根圆的交点处多余的线条
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry2[15], pointArry2[16], 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, x0, y0, 0);
                swModelEx.SelectByID2("样条曲线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, -x0, y0, 0);
                //绘制齿根圆角            
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swModelEx.SelectByID2("", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearModule, 1);//圆角半径取经验值ρ=0.38m 
                swModel.DeleteSelection(true);
                swModelEx.SelectByID2("", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swModelEx.SelectByID2("样条曲线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearModule, 1);
                //拉伸切除齿廓
                swFeatMgr = swModel.FeatureManager as FeatureManager;
                Feature feat1 = swFeatMgr.FeatureCut3(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, gearWidth, 0,
                                                                                                false, false, false, false, 0, 0, false, false, false, false, false, false, false, false, false, false, 0, 0, false);

                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, true);
                //圆周阵列齿廓
                swModelEx.SelectByID2("基准轴1", "AXIS", 0, 0, 0, true, 1, null, 0);
                swModelEx.SelectByID2("切除-拉伸1", "BODYFEATURE", 0, 0, 0, false, 4, null, 0);
                swFeatMgr = swModel.FeatureManager as FeatureManager;
                Feature feat2 = swFeatMgr.FeatureCircularPattern3(gearNum, 6.2831853071796, false, "", false, true);
                swModel.ClearSelection2(true);
            }
            //插入配合基准面（一个，另一个为前视基准面）
            //选择一个面
            swModel.ClearSelection2(true);
            swModelEx.SelectByID2("", "", 0, 0, gearWidth, false, 0, null, 0);
            Feature feat3 = swFeatMgr.InsertRefPlane((int)swRefPlaneReferenceConstraints_e.swRefPlaneReferenceConstraint_Coincident, 0, 0, 0, 0, 0);

        }

        #endregion
        #region 拉伸切除轴孔
        private void CutHole1()
        {
            ViewShow("前视");
            double diameterHole1, holeDeep1, holeWidth1, radiusHole1;
            //获取子窗体1传递的值并进行单位转换
            double gearWidth1 = Convert.ToDouble(this.txtGearWidth.Text);
            gearWidth1 /= 1000.0;
            diameterHole1 = sty1dia;
            radiusHole1 = diameterHole1 / 2;
            holeDeep1 = sty1deep;
            holeWidth1 = sty1wid;
            diameterHole1 /= 1000.0;
            holeWidth1 /= 1000.0;
            holeDeep1 /= 1000.0;
            radiusHole1 /= 1000.0;
            double pointStar = holeWidth1 / 2;
            double yyyy = System.Math.Sqrt(radiusHole1 * radiusHole1 * 1000000.0 - pointStar * pointStar * 1000000.0);
            yyyy /= 1000.0;
            swModelEx = swModel.Extension;
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            //新建草图------------            
            swSketchMgr = (SketchManager)swModel.SketchManager;
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCircle(0, 0, 0, radiusHole1, 0, 0);
            swSketchMgr.CreatePoint(holeWidth1 / 2, holeDeep1 + radiusHole1, 0);
            swSketchMgr.CreateLine(holeWidth1 / 2, holeDeep1 + radiusHole1, 0, -holeWidth1 / 2, holeDeep1 + radiusHole1, 0);
            swSketchMgr.CreateLine(-holeWidth1 / 2, holeDeep1 + radiusHole1, 0, -holeWidth1 / 2, yyyy, 0);
            swSketchMgr.CreateLine(holeWidth1 / 2, holeDeep1 + radiusHole1, 0, holeWidth1 / 2, yyyy, 0);
            swModel.ClearSelection2(true);
            swModel.SetPickMode();
            swModelEx.SelectByID2("圆弧1", "SKETCHSEGMENT", 0, radiusHole1, 0, false, 0, null, 0);
            swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, radiusHole1, 0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat = swFeatMgr.FeatureCut3(true, false, true, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, gearWidth1, 0,
                                                                                             false, false, false, false, 0, 0, false, false, false, false, false, false, false, false, false, false, 0, 0, false);
            swModel.ClearSelection2(true);

        }
        #endregion
        #region 生成腹板式齿轮
        /// <summary>
        /// 生成腹板式齿轮的方法
        /// </summary>
        /// <param name="gearModule"></param>
        /// <param name="gearNum"></param>
        /// <param name="pressureAngl"></param>
        /// <param name="higthModule"></param>
        /// <param name="xiModule"></param>
        /// <param name="shiftModule"></param>
        /// <param name="gearWidth"></param>
        private void GenerateBanGear(double gearModule, int gearNum, double pressureAngl, double higthModule, double xiModule, double shiftModule, double gearWidth)
        {
            //单位转换
            gearModule = gearModule / 1000.0;
            pressureAngl = pressureAngl * (System.Math.PI) / 180;//把角度转换为弧度值
            higthModule /= 1000.0;
            xiModule /= 1000.0;
            shiftModule /= 1000.0;
            gearWidth /= 1000.0;
            //获取子窗体传过来的值并进行单位转换
            double dia1, dia2, dia3, dia4, banT, guW, holeDia, keyW, keyD;
            int holeNum;
            dia1 = sty2dia1;
            dia2 = sty2dia2;
            dia3 = sty2dia3;
            dia4 = sty2dia4;
            banT = sty2banThick;
            guW = sty2guWidth;
            holeDia = sty2holeDia;
            holeNum = sty2holeNum;
            keyW = sty2keyW;
            keyD = sty2keyD;
            dia1 /= 1000.0;
            dia2 /= 1000.0;
            dia3 /= 1000.0;
            dia4 /= 1000.0;
            banT /= 1000.0;
            guW /= 1000.0;
            holeDia /= 1000.0;
            keyD /= 1000.0;
            keyW /= 1000.0;
            //计算分度圆半径
            double radiusFen = (gearModule * gearNum) / 2.0;
            //计算齿顶圆半径
            double radiusTop = radiusFen + (higthModule + shiftModule) * gearModule * 1000.0;
            //计算齿根圆半径
            double radiusBottom = radiusFen - (higthModule + xiModule - shiftModule) * gearModule * 1000.0;
            //计算基圆半径
            double baseRadius = radiusFen * (System.Math.Cos(pressureAngl));
            swModelEx = swModel.Extension;
            swModelEx.SelectByID2("右视基准面", "PLANE", 0, 0, 0, true, 0, null, 0);
            //新建草图并创建齿坯
            swSketchMgr = (SketchManager)swModel.SketchManager;
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCenterLine(-guW, 0, 0, guW, 0, 0);
            swSketchMgr.CreateCenterLine(0, 1.5 * radiusTop, 0, 0, -1.5 * radiusTop, 0);
            swSketchMgr.CreateLine(0, dia1 / 2, 0, guW / 2, dia1 / 2, 0);
            swSketchMgr.CreateLine(guW / 2, dia2 / 2, 0, banT / 2, dia2 / 2, 0);
            swSketchMgr.CreateLine(guW / 2, dia2 / 2, 0, guW / 2, dia1 / 2, 0);
            swSketchMgr.CreateLine(banT / 2, dia2 / 2, 0, banT / 2, dia4 / 2, 0);
            swSketchMgr.CreateLine(banT / 2, dia4 / 2, 0, gearWidth / 2, dia4 / 2, 0);
            swSketchMgr.CreateLine(gearWidth / 2, dia4 / 2, 0, gearWidth / 2, radiusTop, 0);
            swSketchMgr.CreateLine(gearWidth / 2, radiusTop, 0, 0, radiusTop, 0);
            swModelEx.SketchBoxSelect(1.2 * guW, dia1 / 4, 0, banT / 4, 1.2 * radiusTop, 0);
            swModelEx.SelectByID2("直线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            swModel.SketchMirror();
            swSketchMgr.InsertSketch(true);
            swModelEx.SelectByID2("草图1", "SKETCH", 0, 0, 0, false, 0, null, 0);
            swModelEx.SelectByID2("直线1@草图1", "EXTSKETCHSEGMENT", -guW, 0, 0, true, 16, null, 0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat = swFeatMgr.FeatureRevolve2(true, true, false, false, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind,
                                                                                          6.28318530718, 0, false, false, 0, 0, 0, 0, 0, true, true, true);

            swModelEx.SelectByID2("上视基准面", "PLANE", 0, 0, 0, true, 0, null, 0);
            swModelEx.SelectByID2("右视基准面", "PLANE", 0, 0, 0, true, 0, null, 0);
            swModel.InsertAxis2(true);
            //创建轮齿特征
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr = (SketchManager)swModel.SketchManager;
            swSketchMgr.InsertSketch(true);
            ViewShow("前视");
            if (gearNum < 42)
            {
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, false);
                //计算齿廓终点时的压力角
                double endAngl2 = System.Math.Sqrt((radiusTop * radiusTop) / (baseRadius * baseRadius) - 1.0);
                //计算压力角的增加量
                double angleIncrea = endAngl2 / 6.0;
                //循环实现坐标点的选取
                for (int i = 0; i <= 6; i++)
                {
                    //计算直角坐标系下各点的坐标值
                    double xI = baseRadius * System.Math.Sin(angleIncrea * i * 1.0) - baseRadius * (angleIncrea * i * 1.0) * System.Math.Cos(angleIncrea * i * 1.0);
                    double yI = baseRadius * (System.Math.Cos(angleIncrea * i * 1.0) + (angleIncrea * i * 1.0) * System.Math.Sin(angleIncrea * i * 1.0));
                    if (i == 0)
                    {
                        pointData[i] = xI;//存放X1点的坐标值
                        pointData[i + 1] = yI;//存放Y1点的坐标值
                    }
                    else if (i == 1)
                    {
                        pointData[i + 1] = xI;//存放X2点的坐标值
                        pointData[i + 2] = yI;//存放Y2点的坐标值
                    }
                    else if (i == 2)
                    {
                        pointData[i + 2] = xI;//存放X3点的坐标值
                        pointData[i + 3] = yI;//存放Y3点的坐标值
                    }
                    else if (i == 3)
                    {
                        pointData[i + 3] = xI;//存放X4点的坐标值
                        pointData[i + 4] = yI;//存放Y4点的坐标值
                    }
                    else if (i == 4)
                    {
                        pointData[i + 4] = xI;//存放X5点的坐标值
                        pointData[i + 5] = yI;//存放Y5点的坐标值
                    }
                    else if (i == 5)
                    {
                        pointData[i + 5] = xI;//存放X6点的坐标值
                        pointData[i + 6] = yI;//存放Y6点的坐标值
                    }
                    else if (i == 6)
                    {
                        pointData[i + 6] = xI;//存放X7点的坐标值
                        pointData[i + 7] = yI;//存放Y7点的坐标值
                    }
                    //根据坐标创建草图点
                    swSketchMgr.CreatePoint(xI, yI, 0);
                }
                //求齿根处点的坐标，利用Y1和Y2点计算直线的斜率k和常量b的值
                double k = (pointData[3] - pointData[1]) / (pointData[2] - pointData[0]);
                double b = pointData[3] - k * pointData[2];
                //联立齿根圆方程计算出齿根处点的X,Y坐标值
                double pointxo = -((-2 * k * b) + System.Math.Sqrt(4.0 * k * k * b * b - (4.0 + 4.0 * k * k) * (radiusBottom * radiusBottom - b * b))) / (2.0 + 2.0 * k * k);
                double pointyo = System.Math.Sqrt((radiusBottom * radiusBottom) - (pointxo * pointxo));
                swSketchMgr.CreatePoint(pointxo, pointyo, 0);
                //建立样条曲线坐标点的数组
                pointArry1[0] = pointxo;
                pointArry1[1] = pointyo;
                pointArry1[2] = 0.0;
                pointArry1[3] = pointData[0];
                pointArry1[4] = pointData[1];
                pointArry1[5] = 0.0;
                pointArry1[6] = pointData[2];
                pointArry1[7] = pointData[3];
                pointArry1[8] = 0.0;
                pointArry1[9] = pointData[4];
                pointArry1[10] = pointData[5];
                pointArry1[11] = 0.0;
                pointArry1[12] = pointData[6];
                pointArry1[13] = pointData[7];
                pointArry1[14] = 0.0;
                pointArry1[15] = pointData[8];
                pointArry1[16] = pointData[9];
                pointArry1[17] = 0.0;
                pointArry1[18] = pointData[10];
                pointArry1[19] = pointData[11];
                pointArry1[20] = 0.0;
                pointArry1[21] = pointData[12];
                pointArry1[22] = pointData[13];
                pointArry1[23] = 0.0;
                //创建压力角处的点坐标
                double xF = baseRadius * System.Math.Sin(pressureAngl) - baseRadius * (pressureAngl) * System.Math.Cos(pressureAngl);
                double yF = baseRadius * (System.Math.Cos(pressureAngl) + (pressureAngl) * System.Math.Sin(pressureAngl));
                //勾股定理求出压力角半径大小
                double radiusF = System.Math.Sqrt(xF * xF + yF * yF);
                //求出该点处压力角阿尔法的大小
                double angleF = System.Math.Acos(baseRadius / radiusF);
                //求出该点处的展角大小（渐开线函数）
                double invAngle = System.Math.Tan(angleF) - angleF;
                //计算齿槽角大小
                double angleWidth = (2 * System.Math.PI) / (4 * gearNum);
                //计算旋转角度大小
                double angleRotate = angleWidth - invAngle;
                //绘制样条曲线
                swSketchMgr.CreateSpline(pointArry1);
                swModelEx.SelectByID2("点1", "SKETCHPOINT", pointData[0], pointData[1], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点2", "SKETCHPOINT", pointData[2], pointData[3], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点3", "SKETCHPOINT", pointData[4], pointData[5], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点4", "SKETCHPOINT", pointData[6], pointData[7], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点5", "SKETCHPOINT", pointData[8], pointData[9], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点6", "SKETCHPOINT", pointData[10], pointData[11], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点7", "SKETCHPOINT", pointData[12], pointData[13], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点8", "SKETCHPOINT", pointxo, pointyo, 0, true, 0, null, 0);
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry1[15], pointArry1[16], 0, true, 0, null, 0);
                //旋转样条曲线
                swModel.Extension.RotateOrCopy(false, 0, true, 0, 0, 0, 0, 0, 1, -angleRotate);
                //绘制镜像对称轴
                swSketchMgr.CreateCenterLine(0, 0, 0, 0, radiusTop + 0.0009, 0);
                //镜像渐开线并修剪对称轴
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry1[15], pointArry1[16], 0, true, 0, null, 0);
                swModel.SketchMirror();
                swModelEx.SelectByID2("直线1", "SKETCHSEGMENT", 0, (gearNum * gearModule / 2.0), 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, 0, 0);
                //转换实体引用齿顶圆
                swModelEx.SelectByID2("", "EDGE", 0, radiusTop, -gearWidth / 2, true, 0, null, 0);
                swSketchMgr.SketchUseEdge2(false);
                //修剪齿顶圆
                swModelEx.SelectByID2("", "SKETCHSEGMENT", radiusTop, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusTop, 0, 0);
                //创建齿根圆并修剪
                swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusBottom);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusBottom, 0, 0);
                //绘制齿根圆角            
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, true);
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swModelEx.SelectByID2("", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearModule, 1);//圆角半径取经验值ρ=0.38m            
                swModel.DeSelectByID("样条曲线1", "SKETCHSEGMENT", 0, 0, 0);
                swModel.DeSelectByID("", "SKETCHSEGMENT", 0, radiusBottom, 0);
                swModelEx.SelectByID2("样条曲线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swModelEx.SelectByID2("", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearModule, 1);
                //拉伸切除齿廓
                swFeatMgr = swModel.FeatureManager as FeatureManager;
                Feature feat1 = swFeatMgr.FeatureCut3(false, false, false, (int)swEndConditions_e.swEndCondThroughAll, (int)swEndConditions_e.swEndCondThroughAll, gearWidth,
                   0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, false, false, false, (int)swStartConditions_e.swStartSketchPlane, 0, false);

                //圆周阵列齿廓
                swModelEx.SelectByID2("基准轴1", "AXIS", 0, 0, 0, true, 1, null, 0);
                swModelEx.SelectByID2("切除-拉伸1", "BODYFEATURE", 0, 0, 0, false, 4, null, 0);
                swFeatMgr = swModel.FeatureManager as FeatureManager;
                Feature feat2 = swFeatMgr.FeatureCircularPattern3(gearNum, 6.2831853071796, false, "", false, true);
            }
            else if (gearNum >= 42)
            {
                //计算齿廓终点时的压力角（tan阿尔法表示整个圆心角的大小）
                double endAngl2 = System.Math.Sqrt((radiusTop * radiusTop) / (baseRadius * baseRadius) - 1.0);
                //计算角度的增加量
                double angleIncrea = endAngl2 / 6.0;
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, false);
                //循环实现坐标点的选取
                for (int i = 0; i <= 6; i++)
                {
                    //计算直角坐标系下各点的坐标值
                    double xI = baseRadius * System.Math.Sin(angleIncrea * i * 1.0) - baseRadius * (angleIncrea * i * 1.0) * System.Math.Cos(angleIncrea * i * 1.0);
                    double yI = baseRadius * (System.Math.Cos(angleIncrea * i * 1.0) + (angleIncrea * i * 1.0) * System.Math.Sin(angleIncrea * i * 1.0));
                    if (i == 0)
                    {
                        pointData[i] = xI;//存放X1点的坐标值
                        pointData[i + 1] = yI;//存放Y1点的坐标值
                    }
                    else if (i == 1)
                    {
                        pointData[i + 1] = xI;//存放X2点的坐标值
                        pointData[i + 2] = yI;//存放Y2点的坐标值
                    }
                    else if (i == 2)
                    {
                        pointData[i + 2] = xI;//存放X3点的坐标值
                        pointData[i + 3] = yI;//存放Y3点的坐标值
                    }
                    else if (i == 3)
                    {
                        pointData[i + 3] = xI;//存放X4点的坐标值
                        pointData[i + 4] = yI;//存放Y4点的坐标值
                    }
                    else if (i == 4)
                    {
                        pointData[i + 4] = xI;//存放X5点的坐标值
                        pointData[i + 5] = yI;//存放Y5点的坐标值
                    }
                    else if (i == 5)
                    {
                        pointData[i + 5] = xI;//存放X6点的坐标值
                        pointData[i + 6] = yI;//存放Y6点的坐标值
                    }
                    else if (i == 6)
                    {
                        pointData[i + 6] = xI;//存放X7点的坐标值
                        pointData[i + 7] = yI;//存放Y7点的坐标值
                    }
                    //根据坐标创建草图点
                    swSketchMgr.CreatePoint(xI, yI, 0);
                }
                //建立样条曲线坐标点的数组             
                pointArry2[0] = pointData[0];
                pointArry2[1] = pointData[1];
                pointArry2[2] = 0.0;
                pointArry2[3] = pointData[2];
                pointArry2[4] = pointData[3];
                pointArry2[5] = 0.0;
                pointArry2[6] = pointData[4];
                pointArry2[7] = pointData[5];
                pointArry2[8] = 0.0;
                pointArry2[9] = pointData[6];
                pointArry2[10] = pointData[7];
                pointArry2[11] = 0.0;
                pointArry2[12] = pointData[8];
                pointArry2[13] = pointData[9];
                pointArry2[14] = 0.0;
                pointArry2[15] = pointData[10];
                pointArry2[16] = pointData[11];
                pointArry2[17] = 0.0;
                pointArry2[18] = pointData[12];
                pointArry2[19] = pointData[13];
                pointArry2[20] = 0.0;
                //创建压力角处的点坐标
                double xF = baseRadius * System.Math.Sin(pressureAngl) - baseRadius * (pressureAngl) * System.Math.Cos(pressureAngl);
                double yF = baseRadius * (System.Math.Cos(pressureAngl) + (pressureAngl) * System.Math.Sin(pressureAngl));
                //勾股定理求出压力角半径大小
                double radiusF = System.Math.Sqrt(xF * xF + yF * yF);
                //求出该点处压力角阿尔法的大小
                double angleF = System.Math.Acos(baseRadius / radiusF);
                //求出该点处的展角大小（渐开线函数）
                double invAngle = System.Math.Tan(angleF) - angleF;
                //计算齿槽角大小
                double angleWidth = (2 * System.Math.PI) / (4 * gearNum);
                //计算旋转角度大小
                double angleRotate = angleWidth - invAngle;
                //绘制样条曲线
                swSketchMgr.CreateSpline(pointArry2);
                swModelEx.SelectByID2("点1", "SKETCHPOINT", pointData[0], pointData[1], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点2", "SKETCHPOINT", pointData[2], pointData[3], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点3", "SKETCHPOINT", pointData[4], pointData[5], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点4", "SKETCHPOINT", pointData[6], pointData[7], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点5", "SKETCHPOINT", pointData[8], pointData[9], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点6", "SKETCHPOINT", pointData[10], pointData[11], 0, true, 0, null, 0);
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry2[15], pointArry2[16], 0, true, 0, null, 0);
                //旋转样条曲线
                swModel.Extension.RotateOrCopy(false, 0, true, 0, 0, 0, 0, 0, 1, -angleRotate);
                //获取旋转后点的坐标值，创建对象实例
                swSketchMgr = (SketchManager)swModel.SketchManager;
                Sketch swSketch = (Sketch)swModel.GetActiveSketch2();
                sketchPointArry = swSketch.GetSketchPoints2();
                double x0 = 0.0, y0 = 0.0, x1 = 0.0, y1 = 0.0;
                for (int i = 0; i <= sketchPointArry.Length - 1; i++)
                {
                    if (i == 0)
                    {
                        swSketchPt = sketchPointArry[i];
                        x0 = swSketchPt.X;//获取第一个点的x坐标
                        y0 = swSketchPt.Y;//获取第一个点的y坐标                        
                    }
                    if (i == 1)
                    {
                        swSketchPt = sketchPointArry[i];
                        x1 = swSketchPt.X;//获取第二个点的x坐标
                        y1 = swSketchPt.Y;//获取第二个点的y坐标                        
                    }
                }
                //绘制镜像对称轴
                swSketchMgr.CreateCenterLine(0, 0, 0, 0, 1.5 * radiusTop, 0);
                //镜像渐开线并修剪对称轴
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry2[15], pointArry2[16], 0, true, 0, null, 0);
                swModel.SketchMirror();
                swModelEx.SelectByID2("直线1", "SKETCHSEGMENT", 0, radiusFen, 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, 0, 0);
                //转换实体引用齿顶圆
                swModelEx.SelectByID2("", "EDGE", 0, radiusTop, -gearWidth / 2, true, 0, null, 0);
                swSketchMgr.SketchUseEdge2(false);
                //修剪齿顶圆
                swModelEx.SelectByID2("", "SKETCHSEGMENT", radiusTop, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusTop, 0, 0);
                //创建齿根圆并修剪
                swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusBottom);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusBottom, 0, 0);
                //修剪渐开线与齿根圆的交点处多余的线条
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry2[15], pointArry2[16], 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, x0, y0, 0);
                swModelEx.SelectByID2("样条曲线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, -x0, y0, 0);
                //绘制齿根圆角            
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swModelEx.SelectByID2("", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearModule, 1);//圆角半径取经验值ρ=0.38m 
                swModel.DeleteSelection(true);
                swModelEx.SelectByID2("", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swModelEx.SelectByID2("样条曲线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearModule, 1);
                //拉伸切除齿廓
                swFeatMgr = swModel.FeatureManager as FeatureManager;
                Feature feat1 = swFeatMgr.FeatureCut3(false, false, false, (int)swEndConditions_e.swEndCondThroughAll, (int)swEndConditions_e.swEndCondThroughAll, gearWidth,
                    0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, false, false, false, (int)swStartConditions_e.swStartSketchPlane, 0, false);

                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, true);
                //圆周阵列齿廓
                swModelEx.SelectByID2("基准轴1", "AXIS", 0, 0, 0, true, 1, null, 0);
                swModelEx.SelectByID2("切除-拉伸1", "BODYFEATURE", 0, 0, 0, false, 4, null, 0);
                swFeatMgr = swModel.FeatureManager as FeatureManager;
                Feature feat2 = swFeatMgr.FeatureCircularPattern3(gearNum, 6.2831853071796, false, "", false, true);
            }
            //切除腹板孔和键槽
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCenterRectangle(0, dia1 / 2, 0, keyW / 2, keyD + dia1 / 2, 0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat3 = swFeatMgr.FeatureCut3(false, false, false, (int)swEndConditions_e.swEndCondThroughAll, (int)swEndConditions_e.swEndCondThroughAll, gearWidth,
               0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, false, false, false, (int)swStartConditions_e.swStartSketchPlane, 0, false);

            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCircleByRadius(0, dia3 / 2, 0, holeDia);
            Feature feat4 = swFeatMgr.FeatureCut3(false, false, false, (int)swEndConditions_e.swEndCondThroughAll, (int)swEndConditions_e.swEndCondThroughAll, gearWidth,
               0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, false, false, false, (int)swStartConditions_e.swStartSketchPlane, 0, false);
            swModelEx.SelectByID2("基准轴1", "AXIS", 0, 0, 0, true, 1, null, 0);
            swModelEx.SelectByID2("切除-拉伸3", "BODYFEATURE", 0, 0, 0, false, 4, null, 0);
            Feature feat5 = swFeatMgr.FeatureCircularPattern3(holeNum, 6.2831853071796, false, "", false, true);
        }
        #endregion
        #region 生成轴段的方法（循环拉伸）
        private double lengthSumL = 0.0;
        private double lengthSumR = 0.0;
        double diameterR3, lengthR3;
        double diameterL3, lengthL3;
        #region 拉伸右端轴段方法
        private void GenerateShaftR()
        {
            double gearWidth3 = Convert.ToDouble(this.txtGearWidth.Text);//齿宽
            gearWidth3 /= 1000.0;
            //遍历子窗体传过来的集合并转换类型和单位
            for (int i = 0; i < sty3Para1.Count; i++)
            {
                diameterR3 = Convert.ToDouble(sty3Para1[i][0]);
                lengthR3 = Convert.ToDouble(sty3Para1[i][1]);
                diameterR3 /= 1000.0;
                lengthR3 /= 1000.0;
                if (i == 0)
                {
                    swModelEx = swModel.Extension;
                    swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
                    swFeatMgr.InsertRefPlane((int)swRefPlaneReferenceConstraints_e.swRefPlaneReferenceConstraint_Distance, gearWidth3, 0, 0, 0, 0);
                    //新建草图------------
                    swModelEx.SelectByID2("基准面1", "PLANE", 0, 0, 0, false, 0, null, 0);
                    swSketchMgr = (SketchManager)swModel.SketchManager;
                    swSketchMgr.InsertSketch(true);
                    swSketchMgr.CreateCircle(0, 0, gearWidth3, diameterR3 / 2, 0, 0);
                    //拉伸-----------
                    swModel.Extension.SelectByID2("", "SKETCH", 0, 0, gearWidth3, false, 0, null, 0);
                    swFeatMgr = swModel.FeatureManager as FeatureManager;
                    Feature feat = swFeatMgr.FeatureExtrusion2(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, lengthR3, 0,
                                                                                                     false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);

                    swModel.ClearSelection2(true);
                    swModelEx.SelectByID2("基准面1", "PLANE", 0, 0, 0, false, 0, null, 0);
                    swModel.BlankRefGeom();
                }
                else
                {  //选择基准面(注意拉伸方向时z轴正方向)
                    for (int j = 1; j < sty3Para1[i].Length; j++)
                    {
                        lengthSumR = lengthSumR * 1000.0 + Convert.ToDouble(sty3Para1[i - 1][1]);
                        lengthSumR /= 1000.0;
                    }
                    swModelEx = swModel.Extension;
                    swModelEx.SelectByID2("", "FACE", 0, 0, gearWidth3 + lengthSumR, false, 0, null, 0);
                    //新建草图
                    swSketchMgr = (SketchManager)swModel.SketchManager;
                    swSketchMgr.InsertSketch(true);
                    swSketchMgr.CreateCircle(0, 0, gearWidth3 + lengthSumR, diameterR3 / 2, 0, 0);
                    //swSketchMgr.InsertSketch(true);          
                    swModel.Extension.SelectByID2("", "SKETCH", 0, 0, gearWidth3 + lengthSumR, false, 0, null, 0);
                    swFeatMgr = swModel.FeatureManager as FeatureManager;
                    Feature feat = swFeatMgr.FeatureExtrusion2(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, lengthR3, 0,
                                                                                                     false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);

                    swModel.ClearSelection2(true);
                }
            }
        }
        #endregion
        #region 拉伸左端轴段方法
        private void GenerateShaftL()
        {
            ViewShow("右视");
            for (int i = 0; i < sty3Para2.Count; i++)
            {
                diameterL3 = Convert.ToDouble(sty3Para2[i][0]);
                lengthL3 = Convert.ToDouble(sty3Para2[i][1]);
                diameterL3 /= 1000.0;
                lengthL3 /= 1000.0;
                if (i == 0)
                {
                    swModelEx = swModel.Extension;
                    swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
                    //新建草图
                    swSketchMgr = (SketchManager)swModel.SketchManager;
                    swSketchMgr.InsertSketch(true);
                    swSketchMgr.CreateCircle(0, 0, 0, diameterL3 / 2, 0, 0);
                    //拉伸实体
                    swModel.Extension.SelectByID2("", "SKETCH", 0, 0, 0, false, 0, null, 0);
                    swFeatMgr = swModel.FeatureManager as FeatureManager;
                    Feature feat = swFeatMgr.FeatureExtrusion2(true, false, true, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, lengthL3, 0,
                                                                                                     false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);

                    swModel.ClearSelection2(true);
                }
                else
                {  //选择基准面(注意拉伸方向时z轴正方向)
                    for (int j = 1; j < sty3Para2[i].Length; j++)
                    {
                        lengthSumL = lengthSumL * 1000.0 + Convert.ToDouble(sty3Para2[i - 1][1]);
                        lengthSumL /= 1000.0;
                    }
                    swModelEx = swModel.Extension;
                    swModelEx.SelectByID2("", "FACE", 0, 0, -lengthSumL, false, 0, null, 0);
                    //新建草图
                    swSketchMgr = (SketchManager)swModel.SketchManager;
                    swSketchMgr.InsertSketch(true);
                    swSketchMgr.CreateCircle(0, 0, -lengthSumL, diameterL3 / 2, 0, 0);
                    //拉伸实体
                    swModel.Extension.SelectByID2("", "SKETCH", 0, 0, -lengthSumL, false, 0, null, 0);
                    swFeatMgr = swModel.FeatureManager as FeatureManager;
                    Feature feat = swFeatMgr.FeatureExtrusion2(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, lengthL3, 0,
                                                                                                     false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);

                    swModel.ClearSelection2(true);
                }
            }
        }
        #endregion
        #endregion
        #region 接受委托传递的信息的方法1，2，3,4

        private void Receiver1(double dia1, double wid1, double deep1)
        {
            sty1dia = dia1;
            sty1wid = wid1;
            sty1deep = deep1;
        }

        private void Receiver2(double dia1, double dia2, double dia3, double dia4, double banThick, double guWidth, double holeDia, int holeNum, double keyW, double keyD)
        {
            sty2dia1 = dia1;
            sty2dia2 = dia2;
            sty2dia3 = dia3;
            sty2dia4 = dia4;
            sty2banThick = banThick;
            sty2guWidth = guWidth;
            sty2holeDia = holeDia;
            sty2holeNum = holeNum;
            sty2keyW = keyW;
            sty2keyD = keyD;
        }

        private void Receiver3(List<string[]> para1, List<string[]> para2)
        {
            sty3Para1 = para1;
            sty3Para2 = para2;
        }

        private void Receiver4(double D1, double D2, double D3, double D4, double L1, double L2, double L3, double L4, double L5, double B1, double B, int num)
        {
            sty4D1 = D1;
            sty4D2 = D2;
            sty4D3 = D3;
            sty4D4 = D4;
            sty4L1 = L1;
            sty4L2 = L2;
            sty4L3 = L3;
            sty4L4 = L4;
            sty4L5 = L5;
            sty4B1 = B1;
            sty4B = B;
            sty4Num = num;
        }
        #endregion
        #region 斜齿轮生成方法
        /// <summary>
        /// 斜齿轮方法
        /// </summary>
        /// <param name="gearScale">模数</param>
        /// <param name="gearNum">齿数</param>
        /// <param name="pressureAngl">压力角</param>
        /// <param name="higthScale">顶高系数</param>
        /// <param name="xiScale">顶隙系数</param>
        /// <param name="gearWidth">齿宽</param>
        /// <param name="helixAngle">螺旋角</param>
        private void CreateHelix(double gearScale, int gearNum, double pressureAngl, double higthScale, double xiScale, double gearWidth, double helixAngle)
        {
            //单位转换
            gearScale = gearScale / 1000.0;
            pressureAngl = pressureAngl * (System.Math.PI) / 180;//把角度转换为弧度值
            higthScale /= 1000.0;
            xiScale /= 1000.0;
            //shiftScale /= 1000.0;
            gearWidth /= 1000.0;
            helixAngle = helixAngle * (System.Math.PI) / 180;//把角度转换为弧度值
            double cosHelix = System.Math.Cos(helixAngle);
            //法面参数与端面参数的换算
            double scalet = gearScale / cosHelix;//端面模数
            double anglet = System.Math.Atan2(System.Math.Tan(pressureAngl), cosHelix);//端面压力角
            //端面齿顶高系数
            double higthScalet = higthScale * cosHelix;
            //端面顶隙系数
            double xiScalet = xiScale * cosHelix;
            //计算分度圆半径
            double radiusFen = gearNum * gearScale / (2 * cosHelix);
            //计算齿顶圆半径
            double radiusTop = radiusFen + higthScale * gearScale * 1000.0;
            //计算齿根圆半径
            double radiusBottom = radiusFen - gearScale * (higthScale + xiScale) * 1000.0;
            //计算基圆半径
            double baseRadius = radiusFen * System.Math.Cos(anglet);
            //计算螺距和圈数
            double pitch = System.Math.PI * radiusFen / System.Math.Tan(helixAngle);
            double revolution = gearWidth / pitch;
            //当齿根圆和基圆重合时的齿数
            int helixZ = Convert.ToInt32(1000 * 2 * cosHelix * (higthScale + xiScale) / (1 - System.Math.Cos(anglet)));
            //插入基准轴
            swModelEx = swModel.Extension;
            swModelEx.SelectByID2("上视基准面", "PLANE", 0, 0, 0, true, 0, null, 0);
            swModelEx.SelectByID2("右视基准面", "PLANE", 0, 0, 0, true, 0, null, 0);
            swModel.InsertAxis2(true);
            //选择基准面
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            //新建草图
            swSketchMgr = (SketchManager)swModel.SketchManager;
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusTop);
            swSketchMgr.InsertSketch(true);
            //视角
            ViewShow("等轴测");
            //拉伸齿坯（齿顶圆）
            swModel.Extension.SelectByID2("草图1", "SKETCH", 0, 0, 0, false, 0, null, 0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat = swFeatMgr.FeatureExtrusion2(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, gearWidth, 0,
                                                                                            false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);
            swModel.ClearSelection2(true);
            //绘制渐开线齿廓草图
            ViewShow("前视");
            swModelEx.SelectByID2("", "FACE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr = (SketchManager)swModel.SketchManager;
            swSketchMgr.InsertSketch(true);
            #region 齿数小于helixZ时
            if (gearNum < helixZ)
            {
                //计算压力角和展角的和
                double endAngl2 = System.Math.Sqrt((radiusTop * radiusTop) / (baseRadius * baseRadius) - 1.0);
                //计算压力角的增加量
                double angleIncrea = endAngl2 / 6.0;
                //循环实现坐标点的选取
                for (int i = 0; i <= 6; i++)
                {
                    double xI = baseRadius * System.Math.Sin(angleIncrea * i * 1.0) - baseRadius * (angleIncrea * i * 1.0) * System.Math.Cos(angleIncrea * i * 1.0);
                    double yI = baseRadius * (System.Math.Cos(angleIncrea * i * 1.0) + (angleIncrea * i * 1.0) * System.Math.Sin(angleIncrea * i * 1.0));
                    if (i == 0)
                    {
                        pointData[i] = xI;//存放X1点的坐标值
                        pointData[i + 1] = yI;//存放Y1点的坐标值
                    }
                    else if (i == 1)
                    {
                        pointData[i + 1] = xI;//存放X2点的坐标值
                        pointData[i + 2] = yI;//存放Y2点的坐标值
                    }
                    else if (i == 2)
                    {
                        pointData[i + 2] = xI;//存放X3点的坐标值
                        pointData[i + 3] = yI;//存放Y3点的坐标值
                    }
                    else if (i == 3)
                    {
                        pointData[i + 3] = xI;//存放X4点的坐标值
                        pointData[i + 4] = yI;//存放Y4点的坐标值
                    }
                    else if (i == 4)
                    {
                        pointData[i + 4] = xI;//存放X5点的坐标值
                        pointData[i + 5] = yI;//存放Y5点的坐标值
                    }
                    else if (i == 5)
                    {
                        pointData[i + 5] = xI;//存放X6点的坐标值
                        pointData[i + 6] = yI;//存放Y6点的坐标值
                    }
                    else if (i == 6)
                    {
                        pointData[i + 6] = xI;//存放X7点的坐标值
                        pointData[i + 7] = yI;//存放Y7点的坐标值
                    }
                    //根据坐标创建草图点
                    swSketchMgr.CreatePoint(xI, yI, 0);
                }
                //求齿根处点的坐标，利用Y1和Y2点计算直线的斜率k和常量b的值
                double k = (pointData[3] - pointData[1]) / (pointData[2] - pointData[0]);
                double b = pointData[3] - k * pointData[2];
                //联立齿根圆方程计算出齿根处点的X,Y坐标值
                double pointxo = -((-2 * k * b) + System.Math.Sqrt(4.0 * k * k * b * b - (4.0 + 4.0 * k * k) * (radiusBottom * radiusBottom - b * b))) / (2.0 + 2.0 * k * k);
                double pointyo = System.Math.Sqrt((radiusBottom * radiusBottom) - (pointxo * pointxo));
                swSketchMgr.CreatePoint(pointxo, pointyo, 0);
                //建立样条曲线坐标点的数组
                pointArry1[0] = pointxo;
                pointArry1[1] = pointyo;
                pointArry1[2] = 0.0;
                pointArry1[3] = pointData[0];
                pointArry1[4] = pointData[1];
                pointArry1[5] = 0.0;
                pointArry1[6] = pointData[2];
                pointArry1[7] = pointData[3];
                pointArry1[8] = 0.0;
                pointArry1[9] = pointData[4];
                pointArry1[10] = pointData[5];
                pointArry1[11] = 0.0;
                pointArry1[12] = pointData[6];
                pointArry1[13] = pointData[7];
                pointArry1[14] = 0.0;
                pointArry1[15] = pointData[8];
                pointArry1[16] = pointData[9];
                pointArry1[17] = 0.0;
                pointArry1[18] = pointData[10];
                pointArry1[19] = pointData[11];
                pointArry1[20] = 0.0;
                pointArry1[21] = pointData[12];
                pointArry1[22] = pointData[13];
                pointArry1[23] = 0.0;
                //创建分度圆处的点坐标
                double xF = baseRadius * System.Math.Sin(anglet) - baseRadius * (anglet) * System.Math.Cos(anglet);
                double yF = baseRadius * (System.Math.Cos(anglet) + (anglet) * System.Math.Sin(anglet));
                //勾股定理求出压力角半径大小
                double radiusF = System.Math.Sqrt(xF * xF + yF * yF);
                //求出该点处压力角阿尔法的大小
                double angleF = System.Math.Acos(baseRadius / radiusF);
                //求出该点处的展角大小（渐开线函数）
                double invAngle = System.Math.Tan(angleF) - angleF;
                //计算齿槽角大小
                double angleWidth = (2 * System.Math.PI) / (4 * gearNum);
                //计算旋转角度大小
                double angleRotate = angleWidth - invAngle;
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, true);
                //绘制样条曲线
                swSketchMgr.CreateSpline(pointArry1);
                //旋转样条曲线
                swModelEx.SelectByID2("点1", "", pointData[0], pointData[1], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点2", "", pointData[2], pointData[3], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点3", "", pointData[4], pointData[5], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点4", "", pointData[6], pointData[7], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点5", "", pointData[8], pointData[9], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点6", "", pointData[10], pointData[11], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点7", "", pointData[12], pointData[13], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点8", "", pointxo, pointyo, 0, true, 0, null, 0);
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry1[15], pointArry1[16], 0, true, 0, null, 0);
                swModel.Extension.RotateOrCopy(false, 0, true, 0, 0, 0, 0, 0, 1, -angleRotate);
                //绘制镜像对称轴
                swSketchMgr.CreateCenterLine(0, 0, 0, 0, radiusTop + 0.0009, 0);
                //镜像渐开线并修剪对称轴
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry1[15], pointArry1[16], 0, true, 0, null, 0);
                swModel.SketchMirror();
                swModelEx.SelectByID2("直线1", "SKETCHSEGMENT", 0, (gearNum * gearScale / 2.0), 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, 0, 0);
                //转换实体引用齿顶圆
                swModelEx.SelectByID2("", "FACE", 0, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchUseEdge2(false);
                //修剪齿顶圆
                swModelEx.SelectByID2("", "SKETCHSEGMENT", radiusTop, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusTop, 0, 0);
                //创建齿根圆并修剪
                swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusBottom);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusBottom, 0, 0);
                //绘制齿根圆角            
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swModelEx.SelectByID2("", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearScale, 1);//圆角半径取经验值ρ=0.38m 
                swSketchMgr.InsertSketch(true);
                swModel.Extension.SelectByID2("草图2", "SKETCH", 0, 0, 0, false, 0, null, 0);
                swSketchMgr.InsertSketch(true);
                swModelEx.SelectByID2("圆弧6", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swModelEx.SelectByID2("样条曲线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearScale, 1);
                swSketchMgr.InsertSketch(true);
                //开启对象捕捉
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, false);
            }
            #endregion
            #region 齿数大于helixZ时
            else if (gearNum >= helixZ)
            {
                //计算齿廓终点时的压力角（tan阿尔法表示整个圆心角的大小）
                double endAngl2 = System.Math.Sqrt((radiusTop * radiusTop) / (baseRadius * baseRadius) - 1.0);
                //计算角度的增加量
                double angleIncrea = endAngl2 / 6.0;
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, false);
                //循环实现坐标点的选取
                for (int i = 0; i <= 6; i++)
                {
                    //计算直角坐标系下各点的坐标值
                    double xI = baseRadius * System.Math.Sin(angleIncrea * i * 1.0) - baseRadius * (angleIncrea * i * 1.0) * System.Math.Cos(angleIncrea * i * 1.0);
                    double yI = baseRadius * (System.Math.Cos(angleIncrea * i * 1.0) + (angleIncrea * i * 1.0) * System.Math.Sin(angleIncrea * i * 1.0));
                    if (i == 0)
                    {
                        pointData[i] = xI;//存放X1点的坐标值
                        pointData[i + 1] = yI;//存放Y1点的坐标值
                    }
                    else if (i == 1)
                    {
                        pointData[i + 1] = xI;//存放X2点的坐标值
                        pointData[i + 2] = yI;//存放Y2点的坐标值
                    }
                    else if (i == 2)
                    {
                        pointData[i + 2] = xI;//存放X3点的坐标值
                        pointData[i + 3] = yI;//存放Y3点的坐标值
                    }
                    else if (i == 3)
                    {
                        pointData[i + 3] = xI;//存放X4点的坐标值
                        pointData[i + 4] = yI;//存放Y4点的坐标值
                    }
                    else if (i == 4)
                    {
                        pointData[i + 4] = xI;//存放X5点的坐标值
                        pointData[i + 5] = yI;//存放Y5点的坐标值
                    }
                    else if (i == 5)
                    {
                        pointData[i + 5] = xI;//存放X6点的坐标值
                        pointData[i + 6] = yI;//存放Y6点的坐标值
                    }
                    else if (i == 6)
                    {
                        pointData[i + 6] = xI;//存放X7点的坐标值
                        pointData[i + 7] = yI;//存放Y7点的坐标值
                    }
                    //根据坐标创建草图点
                    swSketchMgr.CreatePoint(xI, yI, 0);
                }
                //建立样条曲线坐标点的数组             
                pointArry2[0] = pointData[0];
                pointArry2[1] = pointData[1];
                pointArry2[2] = 0.0;
                pointArry2[3] = pointData[2];
                pointArry2[4] = pointData[3];
                pointArry2[5] = 0.0;
                pointArry2[6] = pointData[4];
                pointArry2[7] = pointData[5];
                pointArry2[8] = 0.0;
                pointArry2[9] = pointData[6];
                pointArry2[10] = pointData[7];
                pointArry2[11] = 0.0;
                pointArry2[12] = pointData[8];
                pointArry2[13] = pointData[9];
                pointArry2[14] = 0.0;
                pointArry2[15] = pointData[10];
                pointArry2[16] = pointData[11];
                pointArry2[17] = 0.0;
                pointArry2[18] = pointData[12];
                pointArry2[19] = pointData[13];
                pointArry2[20] = 0.0;
                //创建压力角处的点坐标
                double xF = baseRadius * System.Math.Sin(pressureAngl) - baseRadius * (pressureAngl) * System.Math.Cos(pressureAngl);
                double yF = baseRadius * (System.Math.Cos(pressureAngl) + (pressureAngl) * System.Math.Sin(pressureAngl));
                //勾股定理求出压力角半径大小
                double radiusF = System.Math.Sqrt(xF * xF + yF * yF);
                //求出该点处压力角阿尔法的大小
                double angleF = System.Math.Acos(baseRadius / radiusF);
                //求出该点处的展角大小（渐开线函数）
                double invAngle = System.Math.Tan(angleF) - angleF;
                //计算齿槽角大小
                double angleWidth = (2 * System.Math.PI) / (4 * gearNum);
                //计算旋转角度大小
                double angleRotate = angleWidth - invAngle;
                //绘制样条曲线
                swSketchMgr.CreateSpline(pointArry2);
                swModelEx.SelectByID2("点1", "SKETCHPOINT", pointData[0], pointData[1], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点2", "SKETCHPOINT", pointData[2], pointData[3], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点3", "SKETCHPOINT", pointData[4], pointData[5], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点4", "SKETCHPOINT", pointData[6], pointData[7], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点5", "SKETCHPOINT", pointData[8], pointData[9], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点6", "SKETCHPOINT", pointData[10], pointData[11], 0, true, 0, null, 0);
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry2[15], pointArry2[16], 0, true, 0, null, 0);
                //旋转样条曲线
                swModel.Extension.RotateOrCopy(false, 0, true, 0, 0, 0, 0, 0, 1, -angleRotate);
                //获取旋转后点的坐标值，创建对象实例
                swSketchMgr = (SketchManager)swModel.SketchManager;
                Sketch swSketch = (Sketch)swModel.GetActiveSketch2();
                sketchPointArry = swSketch.GetSketchPoints2();
                double x0 = 0.0, y0 = 0.0, x1 = 0.0, y1 = 0.0;
                for (int i = 0; i <= sketchPointArry.Length - 1; i++)
                {
                    if (i == 0)
                    {
                        swSketchPt = sketchPointArry[i];
                        x0 = swSketchPt.X;//获取第一个点的x坐标
                        y0 = swSketchPt.Y;//获取第一个点的y坐标                        
                    }
                    if (i == 1)
                    {
                        swSketchPt = sketchPointArry[i];
                        x1 = swSketchPt.X;//获取第二个点的x坐标
                        y1 = swSketchPt.Y;//获取第二个点的y坐标                        
                    }
                }
                //绘制镜像对称轴
                swSketchMgr.CreateCenterLine(0, 0, 0, 0, radiusTop + 0.0009, 0);
                //镜像渐开线并修剪对称轴
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry2[15], pointArry2[16], 0, true, 0, null, 0);
                swModel.SketchMirror();
                swModelEx.SelectByID2("直线1", "SKETCHSEGMENT", 0, (gearNum * gearScale / 2.0), 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, 0, 0);
                //转换实体引用齿顶圆
                swModelEx.SelectByID2("", "FACE", 0, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchUseEdge2(false);
                //修剪齿顶圆
                swModelEx.SelectByID2("", "SKETCHSEGMENT", radiusTop, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusTop, 0, 0);
                //开启对象捕捉
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, true);
                //创建齿根圆并修剪
                swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusBottom);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusBottom, 0, 0);
                //修剪渐开线与齿根圆的交点处多余的线条
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry2[15], pointArry2[16], 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, x0, y0, 0);
                swModelEx.SelectByID2("样条曲线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, -x0, y0, 0);
                //绘制齿根圆角            
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swModelEx.SelectByID2("", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearScale, 1);//圆角半径取经验值ρ=0.38m         
                swModelEx.SelectByID2("", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swModelEx.SelectByID2("样条曲线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearScale, 1);
                swSketchMgr.InsertSketch(true);
            }
            //插入螺旋线
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusTop);
            if (rdoBtnL.Checked == true)
            {
                swModel.InsertHelix(false, true, false, false, (int)swHelixDefinedBy_e.swHelixDefinedByHeightAndRevolution, gearWidth, pitch, revolution, 0, System.Math.PI / 2);
            }
            else if (rdoBtnR.Checked == true)
            {
                swModel.InsertHelix(false, false, false, false, (int)swHelixDefinedBy_e.swHelixDefinedByHeightAndRevolution, gearWidth, pitch, revolution, 0, System.Math.PI / 2);
            }
            swSketchMgr.InsertSketch(true);
            //扫描切除齿廓
            swModelEx.SelectByID2("草图2", "SKETCH", 0, 0, 0, false, 1, null, 0);
            swModelEx.SelectByID2("螺旋线/涡状线1", "REFERENCECURVES", 0, 0, 0, true, 4, null, 0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat1 = swFeatMgr.InsertCutSwept4(false, true, (short)swTwistControlType_e.swTwistControlFollowPath, false, false, (short)swTangencyType_e.swTangencyNone, (short)swTangencyType_e.swTangencyNone,
                                                                                           false, 0, 0, 0, 0, true, true, 0, true, true, true, false);
            //圆周阵列齿廓
            swModelEx.SelectByID2("基准轴1", "AXIS", 0, 0, 0, true, 1, null, 0);
            swModelEx.SelectByID2("切除-扫描1", "BODYFEATURE", 0, 0, 0, false, 4, null, 0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat2 = swFeatMgr.FeatureCircularPattern3(gearNum, 6.2831853071796, false, "", false, true);
            ViewShow("等轴测");
            #endregion
        }
        #endregion
        #region 腹板斜齿轮创建方法
        /// <summary>
        /// 腹板斜齿轮创建方法
        /// </summary>
        /// <param name="gearScale">模数</param>
        /// <param name="gearNum">齿数</param>
        /// <param name="pressureAngl">压力角</param>
        /// <param name="higthScale">顶高系数</param>
        /// <param name="xiScale">顶隙系数</param>
        /// <param name="gearWidth">齿宽</param>
        /// <param name="helixAngle">螺旋角</param>
        private void GenerateBanGearH(double gearScale, int gearNum, double pressureAngl, double higthScale, double xiScale, double gearWidth, double helixAngle)
        {
            //单位转换
            gearScale = gearScale / 1000.0;
            pressureAngl = pressureAngl * (System.Math.PI) / 180;//把角度转换为弧度值
            higthScale /= 1000.0;
            xiScale /= 1000.0;
            //shiftScale /= 1000.0;
            gearWidth /= 1000.0;
            helixAngle = helixAngle * (System.Math.PI) / 180;//把角度转换为弧度值
            double cosHelix = System.Math.Cos(helixAngle);
            //获取子窗体传过来的值并进行单位转换
            double dia1, dia2, dia3, dia4, banT, guW, holeDia, keyW, keyD;
            int holeNum;
            dia1 = sty2dia1;
            dia2 = sty2dia2;
            dia3 = sty2dia3;
            dia4 = sty2dia4;
            banT = sty2banThick;
            guW = sty2guWidth;
            holeDia = sty2holeDia;
            holeNum = sty2holeNum;
            keyW = sty2keyW;
            keyD = sty2keyD;
            dia1 /= 1000.0;
            dia2 /= 1000.0;
            dia3 /= 1000.0;
            dia4 /= 1000.0;
            banT /= 1000.0;
            guW /= 1000.0;
            holeDia /= 1000.0;
            keyD /= 1000.0;
            keyW /= 1000.0;
            //法面参数与端面参数的换算
            double scalet = gearScale / cosHelix;//端面模数
            double anglet = System.Math.Atan2(System.Math.Tan(pressureAngl), cosHelix);//端面压力角
            //端面齿顶高系数
            double higthScalet = higthScale * cosHelix;
            //端面顶隙系数
            double xiScalet = xiScale * cosHelix;
            //计算分度圆半径
            double radiusFen = gearNum * gearScale / (2 * cosHelix);
            //计算齿顶圆半径
            double radiusTop = radiusFen + higthScale * gearScale * 1000.0;
            //计算齿根圆半径
            double radiusBottom = radiusFen - gearScale * (higthScale + xiScale) * 1000.0;
            //计算基圆半径
            double baseRadius = radiusFen * System.Math.Cos(anglet);
            //计算螺距和圈数
            double pitch = System.Math.PI * radiusFen / System.Math.Tan(helixAngle);
            double revolution = gearWidth / pitch;
            //当齿根圆和基圆重合时的齿数
            int helixZ = Convert.ToInt32(1000 * 2 * cosHelix * (higthScale + xiScale) / (1 - System.Math.Cos(anglet)));
            //新建草图并创建齿坯
            swModelEx = swModel.Extension;
            swModelEx.SelectByID2("右视基准面", "PLANE", 0, 0, 0, true, 0, null, 0);
            swSketchMgr = (SketchManager)swModel.SketchManager;
            swSketchMgr.InsertSketch(true);
            swModel.ViewZoomtofit2();
            swSketchMgr.CreateCenterLine(-1.5 * guW, 0, 0, 1.5 * guW, 0, 0);
            swSketchMgr.CreateCenterLine(0, 1.5 * radiusTop, 0, 0, -1.5 * radiusTop, 0);
            swSketchMgr.CreateLine(0, dia1 / 2, 0, guW / 2, dia1 / 2, 0);
            swSketchMgr.CreateLine(guW / 2, dia2 / 2, 0, banT / 2, dia2 / 2, 0);
            swSketchMgr.CreateLine(guW / 2, dia2 / 2, 0, guW / 2, dia1 / 2, 0);
            swSketchMgr.CreateLine(banT / 2, dia2 / 2, 0, banT / 2, dia4 / 2, 0);
            swSketchMgr.CreateLine(banT / 2, dia4 / 2, 0, gearWidth / 2, dia4 / 2, 0);
            swSketchMgr.CreateLine(gearWidth / 2, dia4 / 2, 0, gearWidth / 2, radiusTop, 0);
            swSketchMgr.CreateLine(gearWidth / 2, radiusTop, 0, 0, radiusTop, 0);
            swModelEx.SketchBoxSelect(1.2 * guW, dia1 / 4, 0, banT / 4, 1.2 * radiusTop, 0);
            swModelEx.SelectByID2("直线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            swModel.SketchMirror();
            swModelEx.SelectByID2("直线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, dia3 / 2, 0);
            swModel.ViewZoomtofit2();
            swSketchMgr.InsertSketch(true);
            swModelEx.SelectByID2("草图1", "SKETCH", 0, 0, 0, false, 0, null, 0);
            swModelEx.SelectByID2("直线1@草图1", "EXTSKETCHSEGMENT", -1.5 * guW, 0, 0, true, 16, null, 0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat = swFeatMgr.FeatureRevolve2(true, true, false, false, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind,
                                                                                          6.28318530718, 0, false, false, 0, 0, 0, 0, 0, true, true, true);

            swModelEx.SelectByID2("上视基准面", "PLANE", 0, 0, 0, true, 0, null, 0);
            swModelEx.SelectByID2("右视基准面", "PLANE", 0, 0, 0, true, 0, null, 0);
            swModel.InsertAxis2(true);
            ViewShow("前视");
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            swFeatMgr = (FeatureManager)swModel.FeatureManager;
            swFeatMgr.InsertRefPlane((int)swRefPlaneReferenceConstraints_e.swRefPlaneReferenceConstraint_Distance, gearWidth / 2, 0, 0, 0, 0);
            swSketchMgr.InsertSketch(true);
            swModelEx.SelectByID2("基准面1", "PLANE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr.InsertSketch(true);
            #region 齿数小于helixZ时
            if (gearNum < helixZ)
            {
                //计算压力角和展角的和
                double endAngl2 = System.Math.Sqrt((radiusTop * radiusTop) / (baseRadius * baseRadius) - 1.0);
                //计算压力角的增加量
                double angleIncrea = endAngl2 / 6.0;
                //循环实现坐标点的选取
                for (int i = 0; i <= 6; i++)
                {
                    double xI = baseRadius * System.Math.Sin(angleIncrea * i * 1.0) - baseRadius * (angleIncrea * i * 1.0) * System.Math.Cos(angleIncrea * i * 1.0);
                    double yI = baseRadius * (System.Math.Cos(angleIncrea * i * 1.0) + (angleIncrea * i * 1.0) * System.Math.Sin(angleIncrea * i * 1.0));
                    if (i == 0)
                    {
                        pointData[i] = xI;//存放X1点的坐标值
                        pointData[i + 1] = yI;//存放Y1点的坐标值
                    }
                    else if (i == 1)
                    {
                        pointData[i + 1] = xI;//存放X2点的坐标值
                        pointData[i + 2] = yI;//存放Y2点的坐标值
                    }
                    else if (i == 2)
                    {
                        pointData[i + 2] = xI;//存放X3点的坐标值
                        pointData[i + 3] = yI;//存放Y3点的坐标值
                    }
                    else if (i == 3)
                    {
                        pointData[i + 3] = xI;//存放X4点的坐标值
                        pointData[i + 4] = yI;//存放Y4点的坐标值
                    }
                    else if (i == 4)
                    {
                        pointData[i + 4] = xI;//存放X5点的坐标值
                        pointData[i + 5] = yI;//存放Y5点的坐标值
                    }
                    else if (i == 5)
                    {
                        pointData[i + 5] = xI;//存放X6点的坐标值
                        pointData[i + 6] = yI;//存放Y6点的坐标值
                    }
                    else if (i == 6)
                    {
                        pointData[i + 6] = xI;//存放X7点的坐标值
                        pointData[i + 7] = yI;//存放Y7点的坐标值
                    }
                    //根据坐标创建草图点
                    swSketchMgr.CreatePoint(xI, yI, 0);
                }
                //求齿根处点的坐标，利用Y1和Y2点计算直线的斜率k和常量b的值
                double k = (pointData[3] - pointData[1]) / (pointData[2] - pointData[0]);
                double b = pointData[3] - k * pointData[2];
                //联立齿根圆方程计算出齿根处点的X,Y坐标值
                double pointxo = -((-2 * k * b) + System.Math.Sqrt(4.0 * k * k * b * b - (4.0 + 4.0 * k * k) * (radiusBottom * radiusBottom - b * b))) / (2.0 + 2.0 * k * k);
                double pointyo = System.Math.Sqrt((radiusBottom * radiusBottom) - (pointxo * pointxo));
                swSketchMgr.CreatePoint(pointxo, pointyo, 0);
                //建立样条曲线坐标点的数组
                pointArry1[0] = pointxo;
                pointArry1[1] = pointyo;
                pointArry1[2] = 0.0;
                pointArry1[3] = pointData[0];
                pointArry1[4] = pointData[1];
                pointArry1[5] = 0.0;
                pointArry1[6] = pointData[2];
                pointArry1[7] = pointData[3];
                pointArry1[8] = 0.0;
                pointArry1[9] = pointData[4];
                pointArry1[10] = pointData[5];
                pointArry1[11] = 0.0;
                pointArry1[12] = pointData[6];
                pointArry1[13] = pointData[7];
                pointArry1[14] = 0.0;
                pointArry1[15] = pointData[8];
                pointArry1[16] = pointData[9];
                pointArry1[17] = 0.0;
                pointArry1[18] = pointData[10];
                pointArry1[19] = pointData[11];
                pointArry1[20] = 0.0;
                pointArry1[21] = pointData[12];
                pointArry1[22] = pointData[13];
                pointArry1[23] = 0.0;
                //创建分度圆处的点坐标
                double xF = baseRadius * System.Math.Sin(anglet) - baseRadius * (anglet) * System.Math.Cos(anglet);
                double yF = baseRadius * (System.Math.Cos(anglet) + (anglet) * System.Math.Sin(anglet));
                //勾股定理求出压力角半径大小
                double radiusF = System.Math.Sqrt(xF * xF + yF * yF);
                //求出该点处压力角阿尔法的大小
                double angleF = System.Math.Acos(baseRadius / radiusF);
                //求出该点处的展角大小（渐开线函数）
                double invAngle = System.Math.Tan(angleF) - angleF;
                //计算齿槽角大小
                double angleWidth = (2 * System.Math.PI) / (4 * gearNum);
                //计算旋转角度大小
                double angleRotate = angleWidth - invAngle;
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, true);
                //绘制样条曲线
                swSketchMgr.CreateSpline(pointArry1);
                //旋转样条曲线
                swModelEx.SelectByID2("点1", "", pointData[0], pointData[1], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点2", "", pointData[2], pointData[3], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点3", "", pointData[4], pointData[5], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点4", "", pointData[6], pointData[7], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点5", "", pointData[8], pointData[9], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点6", "", pointData[10], pointData[11], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点7", "", pointData[12], pointData[13], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点8", "", pointxo, pointyo, 0, true, 0, null, 0);
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry1[15], pointArry1[16], 0, true, 0, null, 0);
                swModel.Extension.RotateOrCopy(false, 0, true, 0, 0, 0, 0, 0, 1, -angleRotate);
                //绘制镜像对称轴
                swSketchMgr.CreateCenterLine(0, 0, 0, 0, radiusTop + 0.0009, 0);
                //镜像渐开线并修剪对称轴
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry1[15], pointArry1[16], 0, true, 0, null, 0);
                swModel.SketchMirror();
                swModelEx.SelectByID2("直线1", "SKETCHSEGMENT", 0, (gearNum * gearScale / 2.0), 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, 0, 0);
                //转换实体引用齿顶圆
                swModelEx.SelectByID2("", "EDGE", 0, radiusTop, -gearWidth / 2, true, 0, null, 0);
                swSketchMgr.SketchUseEdge2(false);
                //修剪齿顶圆
                swModelEx.SelectByID2("", "SKETCHSEGMENT", radiusTop, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusTop, 0, 0);
                //创建齿根圆并修剪
                swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusBottom);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusBottom, 0, 0);
                //绘制齿根圆角            
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swModelEx.SelectByID2("圆弧6", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearScale, 1);//圆角半径取经验值ρ=0.38m 
                swSketchMgr.InsertSketch(true);
                swModel.Extension.SelectByID2("草图2", "SKETCH", 0, 0, 0, false, 0, null, 0);
                swSketchMgr.InsertSketch(true);
                swModelEx.SelectByID2("圆弧6", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swModelEx.SelectByID2("样条曲线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearScale, 1);
                swSketchMgr.InsertSketch(true);
                //开启对象捕捉
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, false);
            }
            #endregion
            #region 齿数大于helixZ时
            else if (gearNum >= helixZ)
            {
                //计算齿廓终点时的压力角（tan阿尔法表示整个圆心角的大小）
                double endAngl2 = System.Math.Sqrt((radiusTop * radiusTop) / (baseRadius * baseRadius) - 1.0);
                //计算角度的增加量
                double angleIncrea = endAngl2 / 6.0;
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, false);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, false);
                //循环实现坐标点的选取
                for (int i = 0; i <= 6; i++)
                {
                    //计算直角坐标系下各点的坐标值
                    double xI = baseRadius * System.Math.Sin(angleIncrea * i * 1.0) - baseRadius * (angleIncrea * i * 1.0) * System.Math.Cos(angleIncrea * i * 1.0);
                    double yI = baseRadius * (System.Math.Cos(angleIncrea * i * 1.0) + (angleIncrea * i * 1.0) * System.Math.Sin(angleIncrea * i * 1.0));
                    if (i == 0)
                    {
                        pointData[i] = xI;//存放X1点的坐标值
                        pointData[i + 1] = yI;//存放Y1点的坐标值
                    }
                    else if (i == 1)
                    {
                        pointData[i + 1] = xI;//存放X2点的坐标值
                        pointData[i + 2] = yI;//存放Y2点的坐标值
                    }
                    else if (i == 2)
                    {
                        pointData[i + 2] = xI;//存放X3点的坐标值
                        pointData[i + 3] = yI;//存放Y3点的坐标值
                    }
                    else if (i == 3)
                    {
                        pointData[i + 3] = xI;//存放X4点的坐标值
                        pointData[i + 4] = yI;//存放Y4点的坐标值
                    }
                    else if (i == 4)
                    {
                        pointData[i + 4] = xI;//存放X5点的坐标值
                        pointData[i + 5] = yI;//存放Y5点的坐标值
                    }
                    else if (i == 5)
                    {
                        pointData[i + 5] = xI;//存放X6点的坐标值
                        pointData[i + 6] = yI;//存放Y6点的坐标值
                    }
                    else if (i == 6)
                    {
                        pointData[i + 6] = xI;//存放X7点的坐标值
                        pointData[i + 7] = yI;//存放Y7点的坐标值
                    }
                    //根据坐标创建草图点
                    swSketchMgr.CreatePoint(xI, yI, 0);
                }
                //建立样条曲线坐标点的数组             
                pointArry2[0] = pointData[0];
                pointArry2[1] = pointData[1];
                pointArry2[2] = 0.0;
                pointArry2[3] = pointData[2];
                pointArry2[4] = pointData[3];
                pointArry2[5] = 0.0;
                pointArry2[6] = pointData[4];
                pointArry2[7] = pointData[5];
                pointArry2[8] = 0.0;
                pointArry2[9] = pointData[6];
                pointArry2[10] = pointData[7];
                pointArry2[11] = 0.0;
                pointArry2[12] = pointData[8];
                pointArry2[13] = pointData[9];
                pointArry2[14] = 0.0;
                pointArry2[15] = pointData[10];
                pointArry2[16] = pointData[11];
                pointArry2[17] = 0.0;
                pointArry2[18] = pointData[12];
                pointArry2[19] = pointData[13];
                pointArry2[20] = 0.0;
                //创建压力角处的点坐标
                double xF = baseRadius * System.Math.Sin(pressureAngl) - baseRadius * (pressureAngl) * System.Math.Cos(pressureAngl);
                double yF = baseRadius * (System.Math.Cos(pressureAngl) + (pressureAngl) * System.Math.Sin(pressureAngl));
                //勾股定理求出压力角半径大小
                double radiusF = System.Math.Sqrt(xF * xF + yF * yF);
                //求出该点处压力角阿尔法的大小
                double angleF = System.Math.Acos(baseRadius / radiusF);
                //求出该点处的展角大小（渐开线函数）
                double invAngle = System.Math.Tan(angleF) - angleF;
                //计算齿槽角大小
                double angleWidth = (2 * System.Math.PI) / (4 * gearNum);
                //计算旋转角度大小
                double angleRotate = angleWidth - invAngle;
                //绘制样条曲线
                swSketchMgr.CreateSpline(pointArry2);
                swModelEx.SelectByID2("点1", "SKETCHPOINT", pointData[0], pointData[1], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点2", "SKETCHPOINT", pointData[2], pointData[3], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点3", "SKETCHPOINT", pointData[4], pointData[5], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点4", "SKETCHPOINT", pointData[6], pointData[7], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点5", "SKETCHPOINT", pointData[8], pointData[9], 0, true, 0, null, 0);
                swModelEx.SelectByID2("点6", "SKETCHPOINT", pointData[10], pointData[11], 0, true, 0, null, 0);
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry2[15], pointArry2[16], 0, true, 0, null, 0);
                //旋转样条曲线
                swModel.Extension.RotateOrCopy(false, 0, true, 0, 0, 0, 0, 0, 1, -angleRotate);
                //获取旋转后点的坐标值，创建对象实例
                swSketchMgr = (SketchManager)swModel.SketchManager;
                Sketch swSketch = (Sketch)swModel.GetActiveSketch2();
                sketchPointArry = swSketch.GetSketchPoints2();
                double x0 = 0.0, y0 = 0.0, x1 = 0.0, y1 = 0.0;
                for (int i = 0; i <= sketchPointArry.Length - 1; i++)
                {
                    if (i == 0)
                    {
                        swSketchPt = sketchPointArry[i];
                        x0 = swSketchPt.X;//获取第一个点的x坐标
                        y0 = swSketchPt.Y;//获取第一个点的y坐标                        
                    }
                    if (i == 1)
                    {
                        swSketchPt = sketchPointArry[i];
                        x1 = swSketchPt.X;//获取第二个点的x坐标
                        y1 = swSketchPt.Y;//获取第二个点的y坐标                        
                    }
                }
                //绘制镜像对称轴
                swSketchMgr.CreateCenterLine(0, 0, 0, 0, radiusTop + 0.0009, 0);
                //镜像渐开线并修剪对称轴
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry2[15], pointArry2[16], 0, true, 0, null, 0);
                swModel.SketchMirror();
                swModelEx.SelectByID2("直线1", "SKETCHSEGMENT", 0, (gearNum * gearScale / 2.0), 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, 0, 0);
                //转换实体引用齿顶圆
                swModelEx.SelectByID2("", "EDGE", 0, radiusTop, -gearWidth / 2, true, 0, null, 0);
                swSketchMgr.SketchUseEdge2(false);
                //修剪齿顶圆
                swModelEx.SelectByID2("", "SKETCHSEGMENT", radiusTop, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusTop, 0, 0);
                //开启对象捕捉
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, true);
                swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, true);
                //创建齿根圆并修剪
                swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusBottom);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusBottom, 0, 0);
                //修剪渐开线与齿根圆的交点处多余的线条
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry2[15], pointArry2[16], 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, x0, y0, 0);
                swModelEx.SelectByID2("样条曲线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, -x0, y0, 0);
                //绘制齿根圆角            
                swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swModelEx.SelectByID2("", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearScale, 1);//圆角半径取经验值ρ=0.38m         
                swModelEx.SelectByID2("", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
                swModelEx.SelectByID2("样条曲线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
                swSketchMgr.CreateFillet(0.38 * gearScale, 1);
                swSketchMgr.InsertSketch(true);
            }
            #endregion
            //插入螺旋线
            swModelEx.SelectByID2("基准面1", "PLANE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusTop);
            if (rdoBtnL.Checked == true)
            {
                swModel.InsertHelix(true, true, false, false, (int)swHelixDefinedBy_e.swHelixDefinedByHeightAndRevolution, gearWidth, pitch, revolution, 0, System.Math.PI / 2);
            }
            else if (rdoBtnR.Checked == true)
            {
                swModel.InsertHelix(true, false, false, false, (int)swHelixDefinedBy_e.swHelixDefinedByHeightAndRevolution, gearWidth, pitch, revolution, 0, System.Math.PI / 2);
            }
            swSketchMgr.InsertSketch(true);
            //扫描切除齿廓
            swModelEx.SelectByID2("草图2", "SKETCH", 0, 0, 0, false, 1, null, 0);
            swModelEx.SelectByID2("螺旋线/涡状线1", "REFERENCECURVES", 0, 0, 0, true, 4, null, 0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat1 = swFeatMgr.InsertCutSwept4(false, true, (short)swTwistControlType_e.swTwistControlFollowPath, false, false, (short)swTangencyType_e.swTangencyNone, (short)swTangencyType_e.swTangencyNone,
                                                                                           false, 0, 0, 0, 0, true, true, 0, true, true, true, false);
            //圆周阵列齿廓
            swModelEx.SelectByID2("基准轴1", "AXIS", 0, 0, 0, true, 1, null, 0);
            swModelEx.SelectByID2("切除-扫描1", "BODYFEATURE", 0, 0, 0, false, 4, null, 0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat2 = swFeatMgr.FeatureCircularPattern3(gearNum, 6.2831853071796, false, "", false, true);
            //创建腹板孔及键槽特征
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr.InsertSketch(true);
            ViewShow("前视");
            swSketchMgr.CreateCenterRectangle(0, dia1 / 2, 0, keyW / 2, keyD + dia1 / 2, 0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat3 = swFeatMgr.FeatureCut3(false, false, false, (int)swEndConditions_e.swEndCondThroughAll, (int)swEndConditions_e.swEndCondThroughAll, gearWidth,
               0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, false, false, false, (int)swStartConditions_e.swStartSketchPlane, 0, false);

            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCircleByRadius(0, dia3 / 2, 0, holeDia);
            Feature feat4 = swFeatMgr.FeatureCut3(false, false, false, (int)swEndConditions_e.swEndCondThroughAll, (int)swEndConditions_e.swEndCondThroughAll, gearWidth,
               0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, false, false, false, (int)swStartConditions_e.swStartSketchPlane, 0, false);
            swModelEx.SelectByID2("基准轴1", "AXIS", 0, 0, 0, true, 1, null, 0);
            swModelEx.SelectByID2("切除-拉伸2", "BODYFEATURE", 0, 0, 0, false, 4, null, 0);
            Feature feat5 = swFeatMgr.FeatureCircularPattern3(holeNum, 6.2831853071796, false, "", false, true);
            swModel.ClearSelection2(true);
            swModelEx.SelectByID2("基准面1", "PLANE", 0, 0, 0, false, 0, null, 0);
            swModel.BlankRefGeom();
        }
        #endregion
        #region 拉伸切除轴孔斜齿轮
        private void CutHoleHelix()
        {
            ViewShow("前视");
            double diameterHole1, holeDeep1, holeWidth1, radiusHole1;
            //获取子窗体1传递的值并进行单位转换
            double gearWidth1 = Convert.ToDouble(this.txtHelixWidth.Text);
            gearWidth1 /= 1000.0;
            diameterHole1 = sty1dia;
            radiusHole1 = diameterHole1 / 2;
            holeDeep1 = sty1deep;
            holeWidth1 = sty1wid;
            diameterHole1 /= 1000.0;
            holeWidth1 /= 1000.0;
            holeDeep1 /= 1000.0;
            radiusHole1 /= 1000.0;
            double pointStar = holeWidth1 / 2;
            double yyyy = System.Math.Sqrt(radiusHole1 * radiusHole1 * 1000000.0 - pointStar * pointStar * 1000000.0);
            yyyy /= 1000.0;
            swModelEx = swModel.Extension;
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            //新建草图------------            
            swSketchMgr = (SketchManager)swModel.SketchManager;
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCircle(0, 0, 0, radiusHole1, 0, 0);
            swSketchMgr.CreatePoint(holeWidth1 / 2, holeDeep1 + radiusHole1, 0);
            swSketchMgr.CreateLine(holeWidth1 / 2, holeDeep1 + radiusHole1, 0, -holeWidth1 / 2, holeDeep1 + radiusHole1, 0);
            swSketchMgr.CreateLine(-holeWidth1 / 2, holeDeep1 + radiusHole1, 0, -holeWidth1 / 2, yyyy, 0);
            swSketchMgr.CreateLine(holeWidth1 / 2, holeDeep1 + radiusHole1, 0, holeWidth1 / 2, yyyy, 0);
            swModel.ClearSelection2(true);
            swModel.SetPickMode();
            swModelEx.SelectByID2("圆弧1", "SKETCHSEGMENT", 0, radiusHole1, 0, false, 0, null, 0);
            swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, radiusHole1, 0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat = swFeatMgr.FeatureCut3(true, false, true, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, gearWidth1, 0,
                                                                                             false, false, false, false, 0, 0, false, false, false, false, false, false, false, false, false, false, 0, 0, false);
            swModel.ClearSelection2(true);
        }
        #endregion
        #region 生成轴段的方法斜齿轮
        private double lengthSumHL = 0.0;
        private double lengthSumHR = 0.0;
        double diameterHR3, lengthHR3;
        double diameterHL3, lengthHL3;
        #region 拉伸右端轴段方法
        /// <summary>
        /// 拉伸右端轴段
        /// </summary>
        private void GenerateShaftHR()
        {
            double gearWidth3 = Convert.ToDouble(this.txtHelixWidth.Text);//齿宽
            gearWidth3 /= 1000.0;
            //遍历子窗体传过来的集合并转换类型和单位
            for (int i = 0; i < sty3Para1.Count; i++)
            {
                diameterHR3 = Convert.ToDouble(sty3Para1[i][0]);
                lengthHR3 = Convert.ToDouble(sty3Para1[i][1]);
                diameterHR3 /= 1000.0;
                lengthHR3 /= 1000.0;
                if (i == 0)
                {
                    swModelEx = swModel.Extension;
                    swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
                    swFeatMgr.InsertRefPlane((int)swRefPlaneReferenceConstraints_e.swRefPlaneReferenceConstraint_Distance, gearWidth3, 0, 0, 0, 0);
                    //新建草图------------
                    swModelEx.SelectByID2("基准面1", "PLANE", 0, 0, 0, false, 0, null, 0);
                    swSketchMgr = (SketchManager)swModel.SketchManager;
                    swSketchMgr.InsertSketch(true);
                    swSketchMgr.CreateCircle(0, 0, gearWidth3, diameterHR3 / 2, 0, 0);
                    //拉伸-----------
                    swModel.Extension.SelectByID2("", "SKETCH", 0, 0, gearWidth3, false, 0, null, 0);
                    swFeatMgr = swModel.FeatureManager as FeatureManager;
                    Feature feat = swFeatMgr.FeatureExtrusion2(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, lengthHR3, 0,
                                                                                                     false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);

                    swModel.ClearSelection2(true);
                    swModelEx.SelectByID2("基准面1", "PLANE", 0, 0, 0, false, 0, null, 0);
                    swModel.BlankRefGeom();
                }
                else
                {  //选择基准面(注意拉伸方向时z轴正方向)
                    for (int j = 1; j < sty3Para1[i].Length; j++)
                    {
                        lengthSumHR = lengthSumHR * 1000.0 + Convert.ToDouble(sty3Para1[i - 1][1]);
                        lengthSumHR /= 1000.0;
                    }
                    swModelEx = swModel.Extension;
                    swModelEx.SelectByID2("", "FACE", 0, 0, gearWidth3 + lengthSumHR, false, 0, null, 0);
                    //新建草图
                    swSketchMgr = (SketchManager)swModel.SketchManager;
                    swSketchMgr.InsertSketch(true);
                    swSketchMgr.CreateCircle(0, 0, gearWidth3 + lengthSumHR, diameterHR3 / 2, 0, 0);
                    swSketchMgr.InsertSketch(true);
                    //拉伸-----------
                    swModel.Extension.SelectByID2("", "SKETCH", 0, 0, gearWidth3 + lengthSumHR, false, 0, null, 0);
                    swFeatMgr = swModel.FeatureManager as FeatureManager;
                    Feature feat = swFeatMgr.FeatureExtrusion2(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, lengthHR3, 0,
                                                                                                     false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);

                    swModel.ClearSelection2(true);
                }
            }
        }
        #endregion
        #region 拉伸左端轴段方法
        private void GenerateShaftHL()
        {
            ViewShow("右视");
            for (int i = 0; i < sty3Para2.Count; i++)
            {
                diameterHL3 = Convert.ToDouble(sty3Para2[i][0]);
                lengthHL3 = Convert.ToDouble(sty3Para2[i][1]);
                diameterHL3 /= 1000.0;
                lengthHL3 /= 1000.0;
                if (i == 0)
                {
                    swModelEx = swModel.Extension;
                    swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
                    //新建草图
                    swSketchMgr = (SketchManager)swModel.SketchManager;
                    swSketchMgr.InsertSketch(true);
                    swSketchMgr.CreateCircle(0, 0, 0, diameterHL3 / 2, 0, 0);
                    //拉伸实体
                    swModel.Extension.SelectByID2("", "SKETCH", 0, 0, 0, false, 0, null, 0);
                    swFeatMgr = swModel.FeatureManager as FeatureManager;
                    Feature feat = swFeatMgr.FeatureExtrusion2(true, false, true, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, lengthHL3, 0,
                                                                                                     false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);

                    swModel.ClearSelection2(true);
                }
                else
                {  //选择基准面(注意拉伸方向时z轴正方向)
                    for (int j = 1; j < sty3Para2[i].Length; j++)
                    {
                        lengthSumHL = lengthSumHL * 1000.0 + Convert.ToDouble(sty3Para2[i - 1][1]);
                        lengthSumHL /= 1000.0;
                    }
                    swModelEx = swModel.Extension;
                    swModelEx.SelectByID2("", "FACE", 0, 0, -lengthSumHL, false, 0, null, 0);
                    //新建草图
                    swSketchMgr = (SketchManager)swModel.SketchManager;
                    swSketchMgr.InsertSketch(true);
                    swSketchMgr.CreateCircle(0, 0, -lengthSumHL, diameterHL3 / 2, 0, 0);
                    swSketchMgr.InsertSketch(true);
                    //拉伸实体
                    swModel.Extension.SelectByID2("", "SKETCH", 0, 0, -lengthSumHL, false, 0, null, 0);
                    swFeatMgr = swModel.FeatureManager as FeatureManager;
                    Feature feat = swFeatMgr.FeatureExtrusion2(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, lengthHL3, 0,
                                                                                                     false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);

                    swModel.ClearSelection2(true);
                }
            }
        }
        #endregion
        #endregion
        #region 验证斜齿轮数据
        public void VerificationInputH()
        {
            string gearNum = this.cboHelixNum.Text;//齿数
            string gearWidth = this.txtHelixWidth.Text;//齿宽
            string higthScale = this.txtHelixHigScale.Text;//顶高系数
            string pressureAngl = this.txtHelixAngle.Text;//压力角
            string gearScale = this.cboScale.Text;//模数
            //string shiftScale = this.txtShiftScale.Text;//变位系数
            string xiScale = this.txtHelixXiScale.Text;//顶隙系数
            string helixAngle = this.cboHelixAngle.Text;//螺旋角
            if (!VerificationIsDigital(gearScale))
            {
                throw new Exception("模数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(gearNum))
            {
                throw new Exception("齿数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(pressureAngl))
            {
                throw new Exception("压力角值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(higthScale))
            {
                throw new Exception("顶高系数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(xiScale))
            {
                throw new Exception("顶隙系数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(gearWidth))
            {
                throw new Exception("齿宽值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(helixAngle))
            {
                throw new Exception("螺旋角值不是有效数字，请重新输入！");
            }
        }
        #endregion
        #region 验证输入数据方法内齿轮
        /// <summary>
        /// 验证输入数据内齿轮-------------
        /// </summary>
        public void VerificationInputIn()
        {
            string gearNum = this.cboInnerNum.Text;//齿数
            string gearWidth = this.txtInWidth.Text;//齿宽
            string higthScale = this.txtInHightScale.Text;//顶高系数
            string pressureAngl = this.txtInPressAng.Text;//压力角
            string gearScale = this.cboInnerModule.Text;//模数
            string shiftScale = this.txtInShiftNum.Text;//变位系数
            string xiScale = this.txtInXiScale.Text;//顶隙系数
            string diamMax = this.txtInDiamMax.Text;//齿圈外径    
            string holeCenter = this.txtHoleCenter.Text;//孔中心线直径    
            string holeDiaIn = this.txtHoleDiaInne.Text;//孔直径大小    
            string holeNum = this.txtHoleNumInner.Text;//孔个数    
            if (!VerificationIsDigital(gearScale))
            {
                throw new Exception("模数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(pressureAngl))
            {
                throw new Exception("压力角值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(gearNum))
            {
                throw new Exception("齿数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(higthScale))
            {
                throw new Exception("顶高系数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(xiScale))
            {
                throw new Exception("顶隙系数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(shiftScale))
            {
                throw new Exception("变位系数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(gearWidth))
            {
                throw new Exception("齿宽值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(diamMax))
            {
                throw new Exception("齿圈外径值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(holeCenter))
            {
                throw new Exception("孔中心线直径值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(holeDiaIn))
            {
                throw new Exception("孔直径值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(holeNum))
            {
                throw new Exception("孔个数值不是有效数字，请重新输入！");
            }
        }
        #endregion
        #region 生成内齿轮的方法
        /// <summary>
        /// 生成内齿轮
        /// </summary>
        /// <param name="gearModule">模数</param>
        /// <param name="gearNum">齿数</param>
        /// <param name="diamMax">外圈直径</param>
        /// <param name="pressureAngl">压力角</param>
        /// <param name="higthModule">顶高系数</param>
        /// <param name="xiModule">顶隙系数</param>
        /// <param name="shiftModule">变位系数</param>
        /// <param name="gearWidth">齿宽</param>
        /// <param name="holeCenter">孔中心线直径</param>
        /// <param name="holeDia">孔径</param>
        /// <param name="holeNUM">孔个数</param>
        private void GenerateCircleGear(double gearModule, int gearNum, double diamMax, double pressureAngl, double higthModule, double xiModule, double shiftModule, double gearWidth, double holeCenter, double holeDia, int holeNUM)
        {
            //单位转换
            gearModule = gearModule / 1000.0;
            pressureAngl = pressureAngl * (System.Math.PI) / 180;//把角度转换为弧度值
            higthModule /= 1000.0;
            xiModule /= 1000.0;
            shiftModule /= 1000.0;
            gearWidth /= 1000.0;
            diamMax /= 1000.0;
            holeCenter /= 1000.0;
            holeDia /= 1000.0;
            //计算分度圆半径
            double radiusFen = (gearModule * gearNum) / 2.0;
            //计算齿顶圆半径
            double radiusTop = radiusFen - (higthModule + shiftModule) * gearModule * 1000.0;
            //计算齿根圆半径
            double radiusBottom = radiusFen + (higthModule + xiModule - shiftModule) * gearModule * 1000.0;
            //计算基圆半径
            double baseRadius = radiusFen * (System.Math.Cos(pressureAngl));
            //插入基准轴
            swModelEx = swModel.Extension;
            swModelEx.SelectByID2("上视基准面", "PLANE", 0, 0, 0, true, 0, null, 0);
            swModelEx.SelectByID2("右视基准面", "PLANE", 0, 0, 0, true, 0, null, 0);
            swModel.InsertAxis2(true);
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            //新建草图
            swSketchMgr = (SketchManager)swModel.SketchManager;
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusTop);
            swSketchMgr.CreateCircleByRadius(0, 0, 0, diamMax / 2.0);
            swSketchMgr.InsertSketch(true);
            ViewShow("等轴测");//视角
            swModel.Extension.SelectByID2("草图1", "SKETCH", 0, 0, 0, false, 0, null, 0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat = swFeatMgr.FeatureExtrusion2(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, gearWidth, 0,
                                                                                            false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);
            swModel.ClearSelection2(true);
            ViewShow("前视");
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr.InsertSketch(true);
            swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
            swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, false);
            swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, false);
            //计算齿廓终点时的压力角
            double endAngl2 = System.Math.Sqrt((radiusBottom * radiusBottom) / (baseRadius * baseRadius) - 1.0);
            //计算压力角的增加量
            double angleIncrea = endAngl2 / 6.0;
            //循环实现坐标点的选取
            for (int i = 0; i <= 6; i++)
            {
                //计算直角坐标系下各点的坐标值
                double xI = baseRadius * System.Math.Sin(angleIncrea * i * 1.0) - baseRadius * (angleIncrea * i * 1.0) * System.Math.Cos(angleIncrea * i * 1.0);
                double yI = baseRadius * (System.Math.Cos(angleIncrea * i * 1.0) + (angleIncrea * i * 1.0) * System.Math.Sin(angleIncrea * i * 1.0));
                if (i == 0)
                {
                    pointData[i] = xI;//存放X1点的坐标值
                    pointData[i + 1] = yI;//存放Y1点的坐标值
                }
                else if (i == 1)
                {
                    pointData[i + 1] = xI;//存放X2点的坐标值
                    pointData[i + 2] = yI;//存放Y2点的坐标值
                }
                else if (i == 2)
                {
                    pointData[i + 2] = xI;//存放X3点的坐标值
                    pointData[i + 3] = yI;//存放Y3点的坐标值
                }
                else if (i == 3)
                {
                    pointData[i + 3] = xI;//存放X4点的坐标值
                    pointData[i + 4] = yI;//存放Y4点的坐标值
                }
                else if (i == 4)
                {
                    pointData[i + 4] = xI;//存放X5点的坐标值
                    pointData[i + 5] = yI;//存放Y5点的坐标值
                }
                else if (i == 5)
                {
                    pointData[i + 5] = xI;//存放X6点的坐标值
                    pointData[i + 6] = yI;//存放Y6点的坐标值
                }
                else if (i == 6)
                {
                    pointData[i + 6] = xI;//存放X7点的坐标值
                    pointData[i + 7] = yI;//存放Y7点的坐标值
                }
                //根据坐标创建草图点
                swSketchMgr.CreatePoint(xI, yI, 0);
            }
            pointArry2[0] = pointData[0];
            pointArry2[1] = pointData[1];
            pointArry2[2] = 0.0;
            pointArry2[3] = pointData[2];
            pointArry2[4] = pointData[3];
            pointArry2[5] = 0.0;
            pointArry2[6] = pointData[4];
            pointArry2[7] = pointData[5];
            pointArry2[8] = 0.0;
            pointArry2[9] = pointData[6];
            pointArry2[10] = pointData[7];
            pointArry2[11] = 0.0;
            pointArry2[12] = pointData[8];
            pointArry2[13] = pointData[9];
            pointArry2[14] = 0.0;
            pointArry2[15] = pointData[10];
            pointArry2[16] = pointData[11];
            pointArry2[17] = 0.0;
            pointArry2[18] = pointData[12];
            pointArry2[19] = pointData[13];
            pointArry2[20] = 0.0;
            //创建压力角处的点坐标
            double xF = baseRadius * System.Math.Sin(pressureAngl) - baseRadius * (pressureAngl) * System.Math.Cos(pressureAngl);
            double yF = baseRadius * (System.Math.Cos(pressureAngl) + (pressureAngl) * System.Math.Sin(pressureAngl));
            //勾股定理求出压力角半径大小
            double radiusF = System.Math.Sqrt(xF * xF + yF * yF);
            //求出该点处压力角阿尔法的大小
            double angleF = System.Math.Acos(baseRadius / radiusF);
            //求出该点处的展角大小（渐开线函数）
            double invAngle = System.Math.Tan(angleF) - angleF;
            //计算齿槽角大小
            double angleWidth = (2 * System.Math.PI) / (4 * gearNum);
            //计算旋转角度大小
            double angleRotate = angleWidth - invAngle;
            //绘制样条曲线
            swSketchMgr.CreateSpline(pointArry2);
            swModelEx.SketchBoxSelect(-0.0005, baseRadius * 0.8, 0, 0.01, diamMax, 0);
            //旋转样条曲线
            swModel.Extension.RotateOrCopy(false, 0, true, 0, 0, 0, 0, 0, 1, angleRotate + angleWidth);
            //获取旋转后点的坐标值，创建对象实例
            swSketchMgr = (SketchManager)swModel.SketchManager;
            Sketch swSketch = (Sketch)swModel.GetActiveSketch2();
            sketchPointArry = swSketch.GetSketchPoints2();
            double x0 = 0.0, y0 = 0.0, x1 = 0.0, y1 = 0.0, x6 = 0.0, y6 = 0.0;
            for (int i = 0; i <= sketchPointArry.Length - 1; i++)
            {
                if (i == 0)
                {
                    swSketchPt = sketchPointArry[i];
                    x0 = swSketchPt.X;//获取第一个点的x坐标
                    y0 = swSketchPt.Y;//获取第一个点的y坐标                        
                }
                if (i == 1)
                {
                    swSketchPt = sketchPointArry[i];
                    x1 = swSketchPt.X;//获取第二个点的x坐标
                    y1 = swSketchPt.Y;//获取第二个点的y坐标                        
                }
                if (i == 6)
                {
                    swSketchPt = sketchPointArry[i];
                    x6 = swSketchPt.X;//获取第7个点的x坐标
                    y6 = swSketchPt.Y;//获取第7个点的y坐标             
                }
            }
            //绘制镜像对称轴
            swSketchMgr.CreateCenterLine(0, 0, 0, 0, radiusTop, 0);
            swModelView = (ModelView)swModel.ActiveView;
            swModelView.FrameState = (int)swWindowState_e.swWindowMaximized;
            //镜像渐开线并修剪对称轴
            swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry2[15], pointArry2[16], 0, true, 0, null, 0);
            swModel.SketchMirror();
            swModelEx.SelectByID2("直线1", "SKETCHSEGMENT", 0, radiusFen, 0, true, 0, null, 0);
            swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, 0, 0);
            //修剪齿根圆和齿顶圆
            swModelEx.SelectByID2("", "EDGE", 0, radiusTop, -gearWidth / 2, true, 0, null, 0);
            swSketchMgr.SketchUseEdge2(false);
            swModelEx.SelectByID2("", "SKETCHSEGMENT", radiusTop, 0, 0, true, 0, null, 0);
            swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusTop, 0, 0);
            swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusBottom);
            swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, radiusBottom, 0, 0);
            swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", pointArry2[15], pointArry2[16], 0, true, 0, null, 0);
            swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, x0, y0, 0);
            swModelEx.SelectByID2("样条曲线2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            swSketchMgr.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, -x0, y0, 0);
            //创建齿根圆角
            swModelEx.SketchBoxSelect(-x1, 1.01 * radiusFen, 0, 0, 1.05 * radiusBottom, 0);
            swSketchMgr.CreateFillet(0.28 * gearModule, 1);//圆角半径取经验值ρ=0.3m 
            swModel.DeleteSelection(true);
            swModelEx.SelectByID2("样条曲线1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            swModelEx.SelectByID2("圆弧3", "SKETCHSEGMENT", 0, radiusBottom, 0, true, 0, null, 0);
            swSketchMgr.CreateFillet(0.28 * gearModule, 1);//圆角半径取经验值ρ=0.3m 
            //拉伸切除齿廓
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat1 = swFeatMgr.FeatureCut3(false, false, false, (int)swEndConditions_e.swEndCondThroughAll, (int)swEndConditions_e.swEndCondThroughAll, gearWidth,
                0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, false, false, false, (int)swStartConditions_e.swStartSketchPlane, 0, false);

            swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, true);
            swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAutomaticRelations, true);
            swApp.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchSnapsPoints, true);
            //圆周阵列齿廓
            swModelEx.SelectByID2("基准轴1", "AXIS", 0, 0, 0, true, 1, null, 0);
            swModelEx.SelectByID2("切除-拉伸1", "BODYFEATURE", 0, 0, 0, false, 4, null, 0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat2 = swFeatMgr.FeatureCircularPattern3(gearNum, 6.2831853071796, false, "", false, true);
            //swModel.DeleteSelection(true);
            //绘制连接孔
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCircleByRadius(0, holeCenter / 2, 0, holeDia / 2);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat3 = swFeatMgr.FeatureCut3(false, false, false, (int)swEndConditions_e.swEndCondThroughAll, (int)swEndConditions_e.swEndCondThroughAll, gearWidth,
                0, false, false, false, false, 0, 0, false, false, false, false, false, true, true, false, false, false, (int)swStartConditions_e.swStartSketchPlane, 0, false);
            swModelEx.SelectByID2("基准轴1", "AXIS", 0, 0, 0, true, 1, null, 0);
            swModelEx.SelectByID2("切除-拉伸2", "BODYFEATURE", 0, 0, 0, false, 4, null, 0);
            Feature feat4 = swFeatMgr.FeatureCircularPattern3(holeNUM, 6.2831853071796, false, "", false, true);
            swModel.ClearSelection2(true);
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusFen);
            swSketchMgr.CreateConstructionGeometry();
            swSketchMgr.InsertSketch(true);
        }
        #endregion
        /// <summary>
        /// 生成花键齿轴
        /// </summary>
        /// <param name="gearModule">模数</param>
        /// <param name="gearNum">齿数</param>
        /// <param name="pressureAngl">压力角</param>
        /// <param name="higthModule">顶高系数</param>
        /// <param name="xiModule">顶隙系数</param>
        /// <param name="shiftModule">变位系数</param>
        /// <param name="gearWidth">齿宽</param>
        private void CreateKeyGear(double gearModule, int gearNum, double pressureAngl, double higthModule, double xiModule, double shiftModule, double gearWidth)
        {
            GenerateGear(gearModule, gearNum, pressureAngl, higthModule, xiModule, shiftModule, gearWidth);
            ViewShow("等轴测");
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            RefPlane refPlane = (RefPlane)swFeatMgr.InsertRefPlane(264, sty4L1 - sty4L2 - sty4L5, 0, 0, 0, 0);
            swModel.ClearSelection2(true);
            swModelEx.SelectByID2("基准面1", "PLANE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCircleByRadius(0, 0, -(sty4L1 - sty4L2 - sty4L5), sty4D1 / 2.0);
            Feature feat3 = swFeatMgr.FeatureExtrusion2(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, (sty4L4), 0,
                                                                                         false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);
            swModel.ClearSelection2(true);
            swModelEx = swModel.Extension;
            swModelEx.SelectByID2("", "FACE", 0, 0, -(sty4L1 - sty4L2 - sty4L5 - sty4L4), false, 0, null, 0);
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCircleByRadius(0, 0, -(sty4L1 - sty4L2 - sty4L5 - sty4L4), sty4D3 / 2.0);
            swFeatMgr = swModel.FeatureManager as FeatureManager;
            Feature feat = swFeatMgr.FeatureExtrusion2(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, sty4B, 0,
                                                                                            false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);
            //Feature ff = swFeatMgr.FeatureRevolve(6.2831853071796, false, 0, (int)swRevolveType_e.swRevolveTypeOneDirection, (int)swRevolveOptions_e.swAutoCloseSketch, false, false, true);
            swModel.ClearSelection2(true);
            swModelEx = swModel.Extension;
            swModelEx.SelectByID2("", "FACE", 0, 0, -(sty4L1 - sty4L2 - sty4L5 - sty4L4 - sty4B), false, 0, null, 0);
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCircleByRadius(0, 0, -(sty4L1 - sty4L2 - sty4L5 - sty4L4 - sty4B), sty4D1 / 2.0);
            Feature feat1 = swFeatMgr.FeatureExtrusion2(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, (sty4L3 - sty4L4 - sty4B), 0,
                                                                                           false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);

            swModel.ClearSelection2(true);
            swModelEx.SelectByID2("", "FACE", 0, 0, -(sty4L1 - sty4L2 - sty4L5 - sty4L4 - sty4B), false, 0, null, 0);
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCircleByRadius(0, 0, -(sty4L1 - sty4L2 - sty4L5 - sty4L4 - sty4B), sty4D2 / 2.0);
            Feature feat2 = swFeatMgr.FeatureExtrusion2(true, false, false, (int)swEndConditions_e.swEndCondBlind, (int)swEndConditions_e.swEndCondBlind, (sty4L1 - sty4L2 - sty4L5 - sty4L3), 0,
                                                                                         false, false, false, false, 0, 0, false, false, false, false, true, true, true, 0, 0, false);
            swModel.ClearSelection2(true);
            ViewShow("右视");
            swModelEx.SelectByID2("基准面1", "PLANE", 0, 0, 0, false, 0, null, 0);
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateCenterLine(0, 0, -(sty4L1 - sty4L2 - sty4L5), 0, sty4D1 / 2.0, -(sty4L1 - sty4L2 - sty4L5));

        }
        #region 生成直齿轮按钮
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //验证输入数据
                VerificationInput();
                //获取值
                double gearModule = Convert.ToDouble(this.cboModule.Text);
                int gearNum = Convert.ToInt32(this.cboGearNum.Text);
                double pressureAngl = Convert.ToDouble(this.txtAngle.Text);
                double higthModule = Convert.ToDouble(this.txtHighModule.Text);
                double xiModule = Convert.ToDouble(this.txtXiModule.Text);
                double shiftModule = Convert.ToDouble(this.txtShiftModule.Text);
                double gearWidth = Convert.ToDouble(this.txtGearWidth.Text);
                string savePath = this.txtSPSpur.Text.Trim();
                if (savePath == string.Empty)
                {
                    MessageBox.Show("请选择保存路径！");
                    return;
                }
                ConnectSw();
                //新建零件
                NewPart();
                //文档框最大化
                FramMax();
                //生成齿轮的方法
                if (this.cboGearStyle.SelectedIndex == 0)
                {
                    GenerateGear(gearModule, gearNum, pressureAngl, higthModule, xiModule, shiftModule, gearWidth);
                }
                if (this.cboGearStyle.SelectedIndex == 1)
                {
                    GenerateGear(gearModule, gearNum, pressureAngl, higthModule, xiModule, shiftModule, gearWidth);
                    CutHole1();

                    swModel.ClearSelection2(true);
                }
                if (this.cboGearStyle.SelectedIndex == 2)
                {
                    GenerateBanGear(gearModule, gearNum, pressureAngl, higthModule, xiModule, shiftModule, gearWidth);
                }
                if (this.cboGearStyle.SelectedIndex == 3)
                {
                    GenerateGear(gearModule, gearNum, pressureAngl, higthModule, xiModule, shiftModule, gearWidth);
                    GenerateShaftR();
                    GenerateShaftL();

                    swModel.ClearSelection2(true);
                }
                if (this.cboGearStyle.SelectedIndex == 4)
                {
                    CreateKeyGear(gearModule, gearNum, pressureAngl, higthModule, xiModule, shiftModule, gearWidth);
                }
                ViewShow("等轴测");
                //保存文件
                int errors = 0;
                int warnings = 0;
                string aa = swModel.GetTitle() + ".sldprt";
                bool isTrue = swModelEx.SaveAs(savePath + "\\" + aa, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);

            }
            catch (Exception ex)
            {
                MessageBox.Show("异常：" + ex.Message);
            }
        }
        #endregion
        # region 窗体返回按钮代码
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
        private void btnBackHelix_Click(object sender, EventArgs e)
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

        private void btnBackInner_Click(object sender, EventArgs e)
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

        private void btnBackBevel_Click(object sender, EventArgs e)
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
        # endregion
        #region 验证锥齿轮输入数据
        public void VerificationInputBevel()
        {
            string gearNumS = this.cboSmallNum.Text;//小齿数
            string gearNumB = this.cboBigNum.Text;//大齿数
            string gearWidth = this.txtBevelWidth.Text;//齿宽
            string higthScale = this.txtBevelHigh.Text;//顶高系数
            string pressureAngl = this.txtBevelAngle.Text;//压力角
            string gearScale = this.cboBevelMoudle.Text;//模数
            //string shiftScale = this.txtShiftScale.Text;//变位系数
            string xiScale = this.txtBevelXi.Text;//顶隙系数
            string bevelHoleDia = this.txtBevelHoleD.Text;//轴孔直径
            string bevelKeyWid = this.txtBevelKeyWidth.Text;//键槽宽度
            string bevelKeyDeep = this.txtBevelKeyDeep.Text;//键槽深度
            if (!VerificationIsDigital(gearNumS))
            {
                throw new Exception("小齿轮齿数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(gearNumB))
            {
                throw new Exception("大齿轮齿数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(gearScale))
            {
                throw new Exception("模数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(pressureAngl))
            {
                throw new Exception("压力角值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(higthScale))
            {
                throw new Exception("顶高系数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(xiScale))
            {
                throw new Exception("顶隙系数值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(gearWidth))
            {
                throw new Exception("齿宽值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(bevelHoleDia))
            {
                throw new Exception("轴孔直径值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(bevelKeyWid))
            {
                throw new Exception("键槽宽度值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(bevelKeyDeep))
            {
                throw new Exception("键槽深度值不是有效数字，请重新输入！");
            }
        }
        #endregion
        #region 生成锥齿轮的方法
        private void GenerateBevelGear(int gearNumS, int gearNumB, double gearScale, double pressureAngl, double higthScale, double xiScale, double gearWidth, double bevelHoleDia, double bevelKeyW, double bevelKeyDeep)
        {
            //单位转换
            gearScale = gearScale / 1000.0;
            pressureAngl = pressureAngl * (System.Math.PI) / 180;//把角度转换为弧度值
            higthScale /= 1000.0;
            xiScale /= 1000.0;
            gearWidth /= 1000.0;
            bevelHoleDia /= 1000.0;
            bevelKeyW /= 1000.0;
            bevelKeyDeep /= 1000.0;
            //参数计算
            double smallFenConeAng = System.Math.Atan2(gearNumS, gearNumB);//小齿轮分锥角
            double BigFenConeAng = System.Math.PI / 2 - smallFenConeAng;//大齿轮分锥角
            double topHight = gearScale * higthScale;//齿顶高
            double downHight = (higthScale + xiScale) * gearScale;//齿根高
            double RefenceDiameter = gearScale * gearNumS;//分度圆直径
            double topDiameter = RefenceDiameter + 2 * topHight * System.Math.Cos(smallFenConeAng);//齿顶圆直径
            double downDiameter = RefenceDiameter - 2 * downHight * System.Math.Cos(smallFenConeAng);//齿根圆直径
            double R = gearScale * System.Math.Sqrt(gearNumS * gearNumS + gearNumB * gearNumB) / 2.0;//锥距
            double downAngl = System.Math.Atan2(downHight, R);//齿根角
            double topConeAngl = smallFenConeAng + downAngl;//顶锥角
            double downConeAngl = smallFenConeAng - downAngl;//根锥角
            //插入基准轴
            swModelEx = swModel.Extension;
            swModelEx.SelectByID2("上视基准面", "PLANE", 0, 0, 0, true, 0, null, 0);
            swModelEx.SelectByID2("右视基准面", "PLANE", 0, 0, 0, true, 0, null, 0);
            swModel.InsertAxis2(true);
            //选择基准面
            swModelEx.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0);
            //新建草图
            swSketchMgr = (SketchManager)swModel.SketchManager;
            swSketchMgr.InsertSketch(true);
            swSketchMgr.CreateLine(0, 0, 0, 0, 0, 0);
            //swSketchMgr.CreateCircleByRadius(0, 0, 0, radiusTop);
            swSketchMgr.InsertSketch(true);
            //视角
            ViewShow("等轴测");



        }

        #endregion
        //定义静态窗体变量防止窗体重复创建
        public static FrmSpurSty1 objFrm1 = null;
        public static FrmSpurSty2 objFrm2 = null;
        public static FrmSpurSty3 objFrm3 = null;
        public static FrmKeyGear objFrmKey = null;
        # region 直齿轮下拉框选择变化时触发的事件及关联委托变量
        private void cboGearStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboGearStyle.SelectedIndex)
            {
                case 1:
                    if (objFrm1 == null)
                    {
                        objFrm1 = new FrmSpurSty1();//创建窗体对象
                        objFrm1.msgSender = this.Receiver1;//将子窗体的委托变量和主窗体的对应方法关联
                        objFrm1.ShowDialog(this);
                    }
                    else
                    {
                        objFrm1.Activate();
                        objFrm1.WindowState = FormWindowState.Normal;
                    }
                    break;
                case 2:
                    if (objFrm2 == null)
                    {
                        objFrm2 = new FrmSpurSty2();//创建窗体对象
                        objFrm2.msgSender = this.Receiver2;//关联委托变量
                        objFrm2.ShowDialog();
                    }
                    else
                    {
                        objFrm2.Activate();
                        objFrm2.WindowState = FormWindowState.Normal;
                    }
                    break;
                case 3:
                    if (objFrm3 == null)
                    {
                        objFrm3 = new FrmSpurSty3();//创建窗体对象
                        objFrm3.msgSender = this.Receiver3;//关联委托变量
                        objFrm3.ShowDialog();
                    }
                    else
                    {
                        objFrm3.Activate();
                        objFrm3.WindowState = FormWindowState.Normal;
                    }
                    break;
                case 4:
                    if (objFrmKey == null)
                    {
                        objFrmKey = new FrmKeyGear();//创建窗体对象
                        objFrmKey.msgSender = this.Receiver4;//关联委托变量
                        objFrmKey.ShowDialog();
                    }
                    else
                    {
                        objFrmKey.Activate();
                        objFrmKey.WindowState = FormWindowState.Normal;
                    }
                    break;
            }
        }
        # endregion
        # region 斜齿轮下拉框选择变化时触发的事件及关联委托变量
        private void cboHelixType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboHelixType.SelectedIndex)
            {
                case 1:
                    if (objFrm1 == null)
                    {
                        objFrm1 = new FrmSpurSty1();//创建窗体对象
                        objFrm1.msgSender = this.Receiver1;//将子窗体的委托变量和主窗体的对应方法关联
                        objFrm1.ShowDialog(this);
                    }
                    else
                    {
                        objFrm1.Activate();
                        objFrm1.WindowState = FormWindowState.Normal;
                    }
                    break;
                case 2:
                    if (objFrm2 == null)
                    {
                        objFrm2 = new FrmSpurSty2();//创建窗体对象
                        objFrm2.msgSender = this.Receiver2;//关联委托变量
                        objFrm2.ShowDialog();
                    }
                    else
                    {
                        objFrm2.Activate();
                        objFrm2.WindowState = FormWindowState.Normal;
                    }
                    break;
                case 3:
                    if (objFrm3 == null)
                    {
                        objFrm3 = new FrmSpurSty3();//创建窗体对象
                        objFrm3.msgSender = this.Receiver3;//关联委托变量
                        objFrm3.ShowDialog();
                    }
                    else
                    {
                        objFrm3.Activate();
                        objFrm3.WindowState = FormWindowState.Normal;
                    }
                    break;
            }
        }
        # endregion
        #region 生成斜齿轮按钮
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                VerificationInputH();//验证输入数据            
                //获取值
                double gearScale = Convert.ToDouble(this.cboScale.Text);
                int gearNum = Convert.ToInt32(this.cboHelixNum.Text);
                double pressureAngl = Convert.ToDouble(this.txtHelixAngle.Text);
                double higthScale = Convert.ToDouble(this.txtHelixHigScale.Text);
                double xiScale = Convert.ToDouble(this.txtHelixXiScale.Text);
                double gearWidth = Convert.ToDouble(this.txtHelixWidth.Text);
                double helixAngle = Convert.ToDouble(this.cboHelixAngle.Text);
                ConnectSw(); //连接solidwork
                NewPart();//新建零件
                FramMax();//文档框最大化
                if (this.cboHelixType.SelectedIndex == 0)
                {
                    CreateHelix(gearScale, gearNum, pressureAngl, higthScale, xiScale, gearWidth, helixAngle);
                }
                if (this.cboHelixType.SelectedIndex == 1)
                {
                    CreateHelix(gearScale, gearNum, pressureAngl, higthScale, xiScale, gearWidth, helixAngle);
                    CutHoleHelix();
                    ViewShow("等轴测");
                }
                if (this.cboHelixType.SelectedIndex == 2)
                {
                    GenerateBanGearH(gearScale, gearNum, pressureAngl, higthScale, xiScale, gearWidth, helixAngle);
                    ViewShow("等轴测");
                }
                if (this.cboHelixType.SelectedIndex == 3)
                {
                    CreateHelix(gearScale, gearNum, pressureAngl, higthScale, xiScale, gearWidth, helixAngle);
                    GenerateShaftHR();
                    GenerateShaftHL();
                    ViewShow("等轴测");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region 生成内齿圈按钮
        private void btnCircleCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //验证输入数据
                VerificationInputIn();
                //获取值
                double gearModule = Convert.ToDouble(this.cboInnerModule.Text);//模数
                int gearNum = Convert.ToInt32(this.cboInnerNum.Text);//齿数
                double pressureAngl = Convert.ToDouble(this.txtInPressAng.Text);//压力角
                double higthModule = Convert.ToDouble(this.txtInHightScale.Text);//顶高系数
                double xiModule = Convert.ToDouble(this.txtInXiScale.Text);//顶隙系数
                double shiftModule = Convert.ToDouble(this.txtInShiftNum.Text);//变位系数
                double gearWidth = Convert.ToDouble(this.txtInWidth.Text);//齿宽
                double diamMax = Convert.ToDouble(this.txtInDiamMax.Text);//齿圈外径
                double holeCente = Convert.ToDouble(this.txtHoleCenter.Text);//孔中心线
                double holeDia = Convert.ToDouble(this.txtHoleDiaInne.Text);//孔径大小
                int holeNUMS = Convert.ToInt32(this.txtHoleNumInner.Text);//孔个数
                string savePath = this.txtSPInner.Text.Trim();//保存路径

                if (gearNum < 34 && shiftModule == 0 && higthModule == 1)
                {
                    MessageBox.Show("你输入的齿数少于最小齿数，请重新输入。", "参数提示");
                    this.cboGearNum.Focus();
                    return;
                }
                if (gearNum < 27 && shiftModule == 0 && higthModule == 0.8)
                {
                    MessageBox.Show("你输入的齿数少于最小齿数，请重新输入。", "参数提示");
                    this.cboGearNum.Focus();
                    return;
                }
                if (savePath == string.Empty)
                {
                    MessageBox.Show("请选择保存路径！");
                    return;
                }
                ConnectSw();
                NewPart();
                FramMax();
                GenerateCircleGear(gearModule, gearNum, diamMax, pressureAngl, higthModule, xiModule, shiftModule, gearWidth, holeCente, holeDia, holeNUMS);
                int err = 0;
                int war = 0;
                swModelEx.SaveAs(savePath + swModel.GetTitle() + ".sldprt", (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref err, ref war);
                swModel.ClearSelection2(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        private void btnCreateBevel_Click(object sender, EventArgs e)
        {
            try
            {
                //验证输入数据
                VerificationInputBevel();
                //获取值
                double gearModule = Convert.ToDouble(this.cboBevelMoudle.Text);
                int gearNumS = Convert.ToInt32(this.cboSmallNum.Text);
                int gearNumB = Convert.ToInt32(this.cboBigNum.Text);
                double pressureAngl = Convert.ToDouble(this.txtBevelAngle.Text);
                double higthModule = Convert.ToDouble(this.txtBevelHigh.Text);
                double xiModule = Convert.ToDouble(this.txtBevelXi.Text);
                double holeDiame = Convert.ToDouble(this.txtBevelHoleD.Text);
                double gearWidth = Convert.ToDouble(this.txtBevelWidth.Text);
                double keyWidth = Convert.ToDouble(this.txtBevelKeyWidth.Text);
                double keyDeep = Convert.ToDouble(this.txtBevelKeyDeep.Text);
                ConnectSw();
                //新建零件
                NewPart();
                //文档框最大化
                FramMax();
                //生成齿轮的方法             
                GenerateBevelGear(gearNumS, gearNumB, gearModule, pressureAngl, higthModule, xiModule, gearWidth, holeDiame, keyWidth, keyDeep);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //生成G800系列行星架
        private void btnCreatConject_Click(object sender, EventArgs e)
        {
            try
            {
                //验证输入数据
                VerificationInputCarrier();
                //获取界面值
                double W1 = Convert.ToDouble(this.txtW1.Text);//
                double RA = Convert.ToDouble(this.txtRA.Text);//最大外径
                double fai3 = Convert.ToDouble(this.txtφ3.Text);
                double RCenter = Convert.ToDouble(this.txtRCenter.Text);//孔中心线直径
                double fai4 = Convert.ToDouble(this.txtφ4.Text);//
                double Rhole = Convert.ToDouble(this.txtRhole.Text);//
                double RKey = Convert.ToDouble(this.txtRKey1.Text);// 
                double rKey2 = Convert.ToDouble(this.txtR5.Text);//键槽深度元直径
                double W2 = Convert.ToDouble(this.txtW2.Text);//
                double W3 = Convert.ToDouble(this.txtW3.Text);//
                double W4 = Convert.ToDouble(this.txtW4.Text);//
                double W5 = Convert.ToDouble(this.txtW5.Text);
                double fai5 = Convert.ToDouble(this.txtfai5.Text);//凸台直径
                int keyNum = Convert.ToInt32(this.txtKeyNum.Text);//花键个数
                //int holeNum = Convert.ToInt32(this.txtHoleNum.Text);//孔个数
                string save = this.txtSPCarrier.Text.Trim();
                if (save == string.Empty)
                {
                    MessageBox.Show("请选择保存路径！");
                    return;
                }
              ModelDoc2 swPart=  CreateAPart(RA, fai3, RKey, rKey2, fai4, fai5, RCenter, Rhole, W1, W3, W4, W5, keyNum);
                int errors = 0;
                int warnings = 0;
                //swModelEx为空？？？？
                swModelEx = swPart.Extension;
                //零部件名称相同了？？？？？？？？
                bool ss = swModelEx.SaveAs(save + "\\" + swPart.GetTitle() + ".sldprt", (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 判断正整数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private bool VerificationDigital(string num)
        {
            if (Regex.IsMatch(num, @"^[1-9]\d*$"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 判断其他数
        /// </summary>
        public void VerificationInputCarrier()
        {
            string W1 = this.txtW1.Text;//
            string RA = this.txtRA.Text;//
            string RCenter = this.txtRCenter.Text;//
            string RC = this.txtφ3.Text;//凸台直径
            string R4 = this.txtRKey1.Text;
            string Rhole = this.txtRhole.Text;//
            string RKey = this.txtfai5.Text;// 
            string W2 = this.txtW2.Text;//
            string W3 = this.txtW3.Text;//
            string W4 = this.txtW4.Text;//
            string W5 = this.txtW5.Text;
            string keyNum = this.txtKeyNum.Text;//花键个数
            //string holeNum = this.txtHoleNum.Text;//孔个数           
            if (!VerificationIsDigital(RA))
            {
                throw new Exception("φA不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(RCenter))
            {
                throw new Exception("R2不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(RKey))
            {
                throw new Exception("R3不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(R4))
            {
                throw new Exception("R4不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(RC))
            {
                throw new Exception("φC不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(W1))
            {
                throw new Exception("W1不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(W2))
            {
                throw new Exception("W2不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(W3))
            {
                throw new Exception("花键长度值不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(W4))
            {
                throw new Exception("W4不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(W5))
            {
                throw new Exception("键槽宽度值不是有效数字，请重新输入！");
            }
            if (!VerificationDigital(keyNum))
            {
                throw new Exception("花键个数值不是有效数字，请重新输入！");
            }

            //if (!VerificationDigital(holeNum))
            //{
            //    throw new Exception("孔个数值不是有效数字，请重新输入！");
            //}

        }
        private string FileNameNOConf
        {
            get
            {
                if (tabControl1.SelectedIndex == 5)
                {
                    return "行星架";
                }

                else if (tabControl1.SelectedIndex == 6)
                {
                    return "立机座";
                }
                else
                    return "";
            }
        }
        /// 模版文件名,同时也是参数表名（数据库）
        private string Temp_TB_name
        {
            get
            {
                if (this.tabControl1.SelectedIndex == 5 && this.tabControl5.SelectedIndex == 0)
                {
                    return "PlanetCarrier";
                }
                if (this.tabControl1.SelectedIndex == 6 && this.tabControl6.SelectedIndex == 0)
                {
                    return "VerticalBasePlanet";
                }
                return "";
            }
        }

        /// <summary>
        /// //生成一个零件
        /// </summary>
        /// <param name="ra">总直径</param>
        /// <param name="r2">R2</param>
        /// <param name="r3">R3</param>
        /// <param name="rkeys"></param>
        /// <param name="r4">内圆直径</param>
        /// <param name="rc">中心线直径</param>
        /// <param name="rh">孔径</param>
        /// <param name="B1">总厚度</param>
        /// <param name="B3">花键长度</param>
        /// <param name="B4">B4宽度</param>
        /// <param name="B5">键槽宽度</param>    
        /// <param name="keyNum">花键数量</param>
        private ModelDoc2 CreateAPart(double ra, double r2, double r3, double rkeys, double r4, double r5, double rc, double rh, double B1, double B3, double B4, double B5, int keyNum)
        {
            //新方法,检查看看还能不能用
            //if (Dbtool2.hasconn(true, this.FindForm()) == false) return;

            ModelDoc2 Part = (ModelDoc2)AllData.NewDoc(false, false, AllData.StartUpPath + "\\prtTemplate\\" + this.Temp_TB_name + ".prtdot");
            bool ist = Part.SetTitle2(this.FileNameNOConf);

            //调用下面的方法
            if (this.Temp_TB_name == "PlanetCarrier")
            {
                Part = CreatePartCarrier(Part, ra, r2, r3, rkeys, r4, r5, rc, rh, B1, B3, B4, B5, keyNum);//生成行星架
            }
            //这里不能自动关闭，因为还有大的没有生成
            Part.SetUserPreferenceToggle(198, true);//隐藏尺寸
            CustomPropertyManager cpmMdl = Part.Extension.get_CustomPropertyManager(Part.ConfigurationManager.ActiveConfiguration.Name);//自定义属性
            cpmMdl.Add2("名称", (int)swCustomInfoType_e.swCustomInfoText, this.FileNameNOConf);
            cpmMdl.Add2("类别", (int)swCustomInfoType_e.swCustomInfoText, "专用件");
            return Part;
        }
        private ModelDoc2 CreatePartCarrier(ModelDoc2 Part, double ra, double r2, double r3, double rkeys, double r4, double r5, double rc, double rh, double B1, double B3, double B4, double B5, int keyNum)
        {
            SolidWorks.Interop.sldworks.Dimension Dim = null;
            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("RBig@草图1");
            Dim.SetSystemValue2(ra / 2.0 / 1000.0, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("B1@草图1");
            Dim.SetSystemValue2(B1 / 1000, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("R2@草图1");
            Dim.SetSystemValue2((r2 / 2.0) / 1000, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("R3@草图1");
            Dim.SetSystemValue2((r4 / 2.0) / 1000, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("B3@草图1");
            Dim.SetSystemValue2((B3 / 1000), (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("B4@草图1");
            Dim.SetSystemValue2(B4 / 1000, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("R1@草图1");//花键槽内径
            Dim.SetSystemValue2(rkeys / 2.0 / 1000, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("RKEY@草图3");//花键槽外径
            Dim.SetSystemValue2(r3 / 2.0 / 1000, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("R5@草图1");//凸台直径
            Dim.SetSystemValue2(r5/2.0 / 1000, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("RCenter@草图2");
            Dim.SetSystemValue2(rc / 1000, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("Rhole@草图2");//轴间距
            Dim.SetSystemValue2(rh / 1000, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("D1@阵列(圆周)2");//花键个数
            Dim.SetSystemValue2(keyNum, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Part.ClearSelection2(true);
            Part.EditRebuild3();
            Part.ViewZoomtofit2();
            return Part;
        }

        private void btnSavePathSpur_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog savePath = new FolderBrowserDialog();
            savePath.Description = "请选择保存路径";
            if (savePath.ShowDialog() == DialogResult.OK)
            {
                savePathSpur = savePath.SelectedPath;
            }
            else
            {
            }
            this.txtSPSpur.Text = savePathSpur;
        }

        private void btnOFInner_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog savePath = new FolderBrowserDialog();
            savePath.Description = "请选择保存路径";
            if (savePath.ShowDialog() == DialogResult.OK)
            {
                savePathInner = savePath.SelectedPath;
            }
            else
            {
            }
            this.txtSPInner.Text = savePathInner;
        }

        private void btnOFCarrier_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog savePath = new FolderBrowserDialog();
            savePath.Description = "请选择保存路径";
            if (savePath.ShowDialog() == DialogResult.OK)
            {
                savePathCarrier = savePath.SelectedPath;
            }
            else
            {
            }
            this.txtSPCarrier.Text = savePathCarrier;
        }

        private void btnCreateKeTi_Click(object sender, EventArgs e)
        {
            try
            {
                //验证数据
                Verification();
                //获取界面值
                double r1 = Convert.ToDouble(this.txtketiR1.Text.Trim());
                double r2 = Convert.ToDouble(this.txtketiR2.Text.Trim());
                double fai3 = Convert.ToDouble(this.txtketifai3.Text.Trim());
                double fai4 = Convert.ToDouble(this.txtketifai4.Text.Trim());
                double fai5 = Convert.ToDouble(this.txtketifai5.Text.Trim());
                double fiaHole = Convert.ToDouble(this.txtketifaiHole.Text.Trim());
                double B = Convert.ToDouble(this.txtkeitiB.Text.Trim());
                string savePath = this.txtSaveKeti.Text.Trim();//保存路径
                if (savePath == string.Empty)
                {
                    MessageBox.Show("请选择保存路径！");
                    return;
                }
                //调用方法生成机座
                ModelDoc2 Part = (ModelDoc2)AllData.NewDoc(false, false, AllData.StartUpPath + "\\prtTemplate\\" + this.Temp_TB_name + ".prtdot");
                bool ist = Part.SetTitle2(this.FileNameNOConf);

                //调用下面的方法
                if (this.Temp_TB_name == "PlanetCarrier")
                {
                    Part = CreatePlanet(Part, r1, r2, fai3, fai4, fai5, fiaHole, B);//生成立机座
                }
                Part.SetUserPreferenceToggle(198, true);//隐藏尺寸
                CustomPropertyManager cpmMdl = Part.Extension.get_CustomPropertyManager(Part.ConfigurationManager.ActiveConfiguration.Name);//自定义属性
                cpmMdl.Add2("名称", (int)swCustomInfoType_e.swCustomInfoText, this.FileNameNOConf);
                cpmMdl.Add2("类别", (int)swCustomInfoType_e.swCustomInfoText, "专用件");
                //保存文件
                swModelEx = swModel.Extension;
                int errors = -1;
                int warnings = -1;
                bool isss = swModelEx.SaveAs(savePath +"\\"+ swModel.GetTitle() + ".sldprt", (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, null, ref errors, ref warnings);
            }
            catch (Exception ex)
            {
               MessageBox.Show("出现错误："+ex.Message);
            }
        }
        private void Verification()
        {
            string r1 = this.txtketiR1.Text;//
            string r2 = this.txtketiR2.Text;//
            string fai3 = this.txtketifai3.Text;//
            string fai4 = this.txtketifai4.Text;//
            string fai5 = this.txtketifai5.Text;
            string faiHole = this.txtketifaiHole.Text;
            string B = this.txtkeitiB.Text;
            if (!VerificationIsDigital(r1))
            {
                throw new Exception("R1不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(r2))
            {
                throw new Exception("R2不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(fai3))
            {
                throw new Exception("φ3不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(fai4))
            {
                throw new Exception("φ4不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(fai5))
            {
                throw new Exception("φ5不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(faiHole))
            {
                throw new Exception("孔径φh不是有效数字，请重新输入！");
            }
            if (!VerificationIsDigital(B))
            {
                throw new Exception("筋宽度B不是有效数字，请重新输入！");
            }
        }
        /// <summary>
        /// 生成机座
        /// </summary>
        /// <param name="Part"></param>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <param name="fai3"></param>
        /// <param name="fai4"></param>
        /// <param name="fai5"></param>
        /// <param name="faiHole"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        private ModelDoc2 CreatePlanet(ModelDoc2 Part, double r1, double r2, double fai3, double fai4, double fai5, double faiHole,double B)
        {
            SolidWorks.Interop.sldworks.Dimension Dim = null;
            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("R1@草图1");//最大外径
            Dim.SetSystemValue2(r1 / 2.0 / 1000.0, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("R2@草图1");//孔中心线直径
            Dim.SetSystemValue2(r2 / 1000, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("FAI3@草图1");
            Dim.SetSystemValue2((fai3 / 2.0) / 1000, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("FAI4@草图1");
            Dim.SetSystemValue2((fai4 / 2.0) / 1000, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("FAI5@草图1");//
            Dim.SetSystemValue2((fai5/2.0 / 1000), (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("FAI5@草图1");//孔的直径。。。。。
            Dim.SetSystemValue2((faiHole / 2.0 / 1000), (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);

            Dim = (SolidWorks.Interop.sldworks.Dimension)Part.Parameter("D1@筋3");//筋的宽度
            Dim.SetSystemValue2(B / 1000, (int)swSetValueInConfiguration_e.swSetValue_InThisConfiguration);
            Part.ClearSelection2(true);
            Part.EditRebuild3();
            Part.ViewZoomtofit2();
            return Part;
        }
        //选择机座保存路径
        private void btnKetiOpenSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog savePath = new FolderBrowserDialog();
            savePath.Description = "请选择保存路径";
            if (savePath.ShowDialog() == DialogResult.OK)
            {
                savePathPlanet = savePath.SelectedPath;
            }
            else
            {
            }
            this.txtSaveKeti.Text = savePathPlanet;
        }

    }
}


