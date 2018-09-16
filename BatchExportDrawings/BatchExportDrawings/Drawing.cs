using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;
using MD_SW_ConnectSW;

namespace BatchExportDrawings
{
    /// <summary>
    /// 出工程图类
    /// </summary>
   public class Drawing
    {
        #region 定义全局变量
        private SldWorks swApp;
        private ModelDoc2 swModel;
        private Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
        #endregion
        #region 属性
        /// <summary>
        /// 图纸比例
        /// </summary>
        public bool drawScale { get; set; }
        /// <summary>
        /// 钣金展开
        /// </summary>
        public bool sheetMetal { get; set; }
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
        public void ExportDrawing(string prtPath,string comPath,string bomPath,string bendPath,string savePath)
        {
            if (ConnectSW.iSwApp == null)
            {
                swApp = (SldWorks)ConnectSW.iSwApp;
            }
            
        }

    }
}
