using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DAL;
using Models;

namespace FrmReducerDesignerApplication
{
    public partial class FrmDataMgr : Form
    {
        private MaterialService objMaterialService = new MaterialService();
        /// <summary>
        /// 构造函数（初始化）
        /// </summary>
        public FrmDataMgr()
        {
            InitializeComponent();
        }

        private void btnCloseData_Click(object sender, EventArgs e)
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

        //获取设计参数
        private void ShowPara()
        {
            double inputPower = Common.PassValues.inputPower;
            double speedRatio = Common.PassValues.speedRatio;
            double inputRevolo = Common.PassValues.inputRevolo;
            double drivenEfficient = Common.PassValues.drivenEfficient;
            double outputTorque = Common.PassValues.outputTorque;
            double outRevolo = Common.PassValues.outRevolo;
            double inputTorque = Common.PassValues.inputTorque;
            if (inputPower == 0 && speedRatio == 0 && inputRevolo == 0 && outputTorque == 0)
            {
                string messageShow = "未进行参数化设计，找不到设计结果！";

                lstResultShow.Items.Add(messageShow);
                return;
            }
            string Acurcy = Common.PassValues.Acurcy;//精度等级
            string v0 = "设计初始参数";
            string space = "-------------------------------------------------------";
            string v1 = "输入功率：" + inputPower.ToString() + " Kw";
            string v2 = "名义减速比：" + speedRatio.ToString();
            string v3 = "输入转速：" + inputRevolo.ToString() + " r/min";
            string v4 = "传动效率：" + drivenEfficient.ToString();
            string v5 = "输出扭矩：" + outputTorque.ToString() + " N.m";
            string v6 = "输出转速：" + outRevolo.ToString() + " r/min";
            string v7 = "输入扭矩：" + inputTorque.ToString() + " N.m";
            string v8 = "精度等级：" + Acurcy;
            string v9 = "-------------------------------------------------------";
            //string[] ArryFrm1 = new string[] { v0, space,v1, v2, v3, v4, v5, v6, v7, v8, v9 };

            //【2】窗体2数据             
            int plantaryNum = Common.PassValues.plantaryNum;
            double za = Common.PassValues.za;
            double zb = Common.PassValues.zb;
            double zc = Common.PassValues.zc;
            double reRation = Common.PassValues.reRation;//实际减速比
            string rationGap = Common.PassValues.rationGap;//减速比误差
            //实际输出转速和实际输出扭矩（计算）
            double outRevoReal = Common.PassValues.outRevoReal;//实际输出转速
            double outTorReal = Common.PassValues.outTorReal;//实际输出扭矩
            string v20 = "设计结果参数";
            string v21 = "-------------------------------------------------------";
            string v22 = "行星轮个数：" + plantaryNum;
            string v23 = "行星轮齿数：" + zc;
            string v24 = "太阳轮齿数：" + za;
            string v25 = "内齿轮齿数：" + zb;
            string v26 = "实际减速比：" + reRation;
            string v27 = "减速比误差：" + rationGap;
            string v28 = "实际输出转速：" + outRevoReal + " r/min";
            string v29 = "实际输出扭矩：" + outTorReal + " N.m";
            //string[] ArryFrm2 = new string[] { v20, v21,v22, v23, v24, v25, v26, v27, v28, v29 };
            //ParaShow.Add(ArryFrm2);



            //[3]窗体3数据
            string vv1 = Common.PassValues.sunMaterial;
            string vv2 = Common.PassValues.planMaterial;
            string vv3 = Common.PassValues.innMaterial;
            string sunM = vv1.Substring(0, vv1.IndexOf('，'));
            string sunC = vv1.Substring(0, vv1.IndexOf('，'));
            string sunB = vv1.Substring(0, vv1.IndexOf('，'));
            string sunMaterial = "太阳轮材料：" + sunM;
            string planMaterial = "行星轮材料：" + sunC;
            string innMaterial = "内齿轮材料：" + sunB;

            //double BendValue1;
            //double BendValue2;
            //double BendValue3;
            //double ContactValue1;//接触极限值
            //double ContactValue2;
            //double ContactValue3;
            //string MaterialVala;
            //string MaterialValb;
            //string MaterialValc;
            //string[] ArryFrm3 = new string[] { sunMaterial, planMaterial, innMaterial };
            //ParaShow.Add(ArryFrm3);
            //变位方式选择标记
            string shiftS;
            int shift = Common.PassValues.shift;
            if (shift == 1)
            {
                shiftS = "标准传动";
            }
            else if (shift == 2)
            {
                shiftS = "高度变位传动";
            }
            else if (shift == 3)
            {
                shiftS = "等角度变位传动";
            }
            else if (shift == 4)
            {
                shiftS = "不等角度变位传动";
            }
            else
            {
                shiftS = "外啮合角变位、内啮合高变位传动";
            }

            //窗体4数据
            double faiD = Common.PassValues.faiD;//齿宽系数       
            double Tac = Common.PassValues.Tac;//a-c传动扭矩
            double a = Common.PassValues.a;//实际中心距
            double anone = Common.PassValues.anone;//未变位中心距
            double kc = Common.PassValues.kc;//载荷系数
            double k = Common.PassValues.k;//综合系数       
            double m = Common.PassValues.m;//模数
            double αac = Common.PassValues.αac;
            double αcb = Common.PassValues.αcb;
            //变位系数===
            double Xa = Common.PassValues.Xa;//太阳轮变位系数
            double Xb = Common.PassValues.Xb;//内齿轮变位系数
            double Xc = Common.PassValues.Xc;//行星轮变位系数

            string v41 = "变位方式：" + shiftS;
            string v42 = "太阳轮变位系数：" + Xa.ToString();
            string v43 = "内齿轮变位系数：" + Xb.ToString();
            string v44 = "行星轮变位系数：" + Xc.ToString();
            string v45 = "a-c副啮合角：" + αac.ToString() + "°";
            string v46 = "c-b副啮合角：" + αcb.ToString() + "°";
            string v47 = "实际模数：" + m.ToString();
            string v48 = "实际中心距：" + a.ToString() + " mm";
            string v49 = "a-c传动扭矩大小：" + Tac.ToString();
            //string[] ArryFrm4 = new string[] { v41, v42, v43, v44, v45, v46, v47, v48, v49 };
            //ParaShow.Add(ArryFrm4);

            //窗体5数据
            double d1 = Common.PassValues.d1;       //分度圆
            double d2 = Common.PassValues.d2;
            double d3 = Common.PassValues.d3;
            double da1 = Common.PassValues.da1;//齿顶圆
            double da2 = Common.PassValues.da2;
            double da3 = Common.PassValues.da3;
            double chdAC = Common.PassValues.chdAC;
            double chdCB = Common.PassValues.chdCB;
            string v51 = "太阳轮分度圆：" + d1.ToString() + " mm";
            string v52 = "行星轮分度圆：" + d2.ToString() + " mm";
            string v53 = "内齿轮分度圆：" + d3.ToString() + " mm";
            string v54 = "太阳轮齿顶圆直径：" + da1.ToString() + " mm";
            string v55 = "行星轮齿顶圆直径：" + da2.ToString() + " mm";
            string v56 = "内齿轮齿顶圆直径：" + da3.ToString() + " mm";
            string v57 = "a-c副重合度：" + chdAC.ToString();
            string v58 = "c-b副重合度：" + chdCB.ToString();
            //string[] ArryFrm5 = new string[] { v51, v52, v53, v54, v55, v56, v57, v58 };
            //ParaShow.Add(ArryFrm5);

            //窗体6数据
            double contactA = Common.PassValues.contactA;
            double xyContactVak = Common.PassValues.contactXY;
            double aBendVal = Common.PassValues.aBendVal;
            double cBendVal = Common.PassValues.cBendVal;
            double xyBenda = Common.PassValues.xyBenda;
            double xyBendc = Common.PassValues.xyBendc;
            string v61 = "太阳轮接触应力：" + contactA.ToString() + " N/mm²";
            string v62 = "太阳轮许用接触应力：" + xyContactVak.ToString() + " N/mm²";
            string v63 = "太阳轮弯曲应力：" + aBendVal.ToString() + " N/mm²";
            string v64 = "行星轮弯曲应力：" + cBendVal.ToString() + " N/mm²";
            string v65 = "太阳轮许用弯曲应力：" + xyBenda.ToString() + " N/mm²";
            string v66 = "行星轮许用弯曲应力：" + xyBendc.ToString() + " N/mm²";
            string v67 = "-------------------------------------------------------";
            ArryFrm6 = new string[] { v0, space, v1, v2, v3, v4, v5, v6, v7, v8, v9, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, sunMaterial, planMaterial, innMaterial, v41, v42, v43, v44, v45, v46, v47, v48, v49, v51, v52, v53, v54, v55, v56, v57, v58, v61, v62, v63, v64, v65, v66, v67 };
            //创建集合
            //ParaShow.Add(ArryFrm6);
            ArryVal = new string[]{inputPower+" Kw",speedRatio.ToString(),inputRevolo+" r/min",
            drivenEfficient.ToString(),outputTorque+" N.m", outRevolo+ " r/min",
            inputTorque + " N.m",Acurcy,"",plantaryNum.ToString(),zc.ToString(),za.ToString(),zb.ToString(),
            reRation.ToString(),rationGap,outRevoReal.ToString(),outTorReal.ToString(),sunM,sunC,sunB,
            shiftS,Xa.ToString(),Xb.ToString(),Xc.ToString(),αac+"°", αcb+"°", m.ToString(),a+" mm",
             Tac.ToString(),d1 + " mm",d2 + " mm",d3 + " mm",da1 + " mm",da2 + " mm",da3 + " mm",chdAC.ToString(),
              chdCB.ToString(), contactA + " N/mm²",xyContactVak + " N/mm²",aBendVal + " N/mm²",cBendVal + " N/mm²",
               xyBenda+ " N/mm²",xyBendc + " N/mm²" };
            lstResultShow.Items.AddRange(ArryFrm6);

        }
        string[] ArryFrm6;
        string[] ArryVal;
        private List<string[]> ParaShow = new List<string[]>();

        private void FrmDataMgr_Load(object sender, EventArgs e)
        {
            this.lstResultShow.Items.Clear();
            lstResultShow.DrawMode = DrawMode.OwnerDrawVariable;
            ShowPara();
        }

        private void lstResultShow_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush FontBrush = null;
            System.Windows.Forms.ListBox listBox = sender as System.Windows.Forms.ListBox;
            if (e.Index > -1)
            {
                if (listBox.Items[e.Index].ToString().Equals("未进行参数化设计，找不到设计结果！"))
                {
                    FontBrush = Brushes.Red;
                }
                else if (e.Index == 0 || e.Index == 11)
                {
                    FontBrush = Brushes.Tomato;
                }
                else
                {
                    FontBrush = Brushes.Black;
                }
                e.DrawBackground();
                e.Graphics.DrawString(listBox.Items[e.Index].ToString(), e.Font, FontBrush, e.Bounds);
                e.DrawFocusRectangle();
            }

        }

        private void btnSaveAS_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            FolderBrowserDialog savePath = new FolderBrowserDialog();
            savePath.Description = "请选择Excel文件保存路径";
            if (savePath.ShowDialog() == DialogResult.OK)
            {
                path = savePath.SelectedPath;
            }
            else
            {
                MessageBox.Show("未选择保存路径，导出失败！");
                return;
            }
            string[] arrr = new string[]{"输入功率" ,"名义减速比", "输入转速","传动效率","输出扭矩","输出转速","输入扭矩" ,
            "精度等级", "","行星轮个数","行星轮齿数","太阳轮齿数","内齿轮齿数","实际减速比", "减速比误差","实际输出转速",
            "实际输出扭矩","太阳轮材料","行星轮材料","内齿轮材料","变位方式","太阳轮变位系数","内齿轮变位系数","行星轮变位系数","a-c副啮合角","c-b副啮合角",
             "实际模数" ,"实际中心距", "a-c传动扭矩大小","太阳轮分度圆", "行星轮分度圆", "内齿轮分度圆","太阳轮齿顶圆直径",
"行星轮齿顶圆直径" ,"内齿轮齿顶圆直径", "a-c副重合度" ,"c-b副重合度" ,"太阳轮接触应力", "太阳轮许用接触应力","太阳轮弯曲应力",
"行星轮弯曲应力","太阳轮许用弯曲应力" ,"行星轮许用弯曲应力" 
            };//第一列行数据
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //创建datatable
            System.Data.DataTable dt = new System.Data.DataTable("dataShow");
            //创建列
            DataColumn dc1 = new DataColumn("参数名称", typeof(string));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("参数值", typeof(string));
            dt.Columns.Add(dc2);
            //创建行
            for (int i = 0; i < arrr.Length; i++)
            {
                dt.Rows.Add(arrr[i], ArryVal[i]);
            }

            bool isTrue = ExportExcel("设计参数结果导出", dt, path + "\\设计结果导出文件i=" + ArryVal[1]);
            if (isTrue == true)
            {
                MessageBox.Show("Excel文件导出成功，请至所选保存文件夹下查看。\n 默认文件名为：设计结果导出文件+速比i", "导出结果提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("数据导出失败，请重新操作！", "导出结果提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #region 导出数据到Excel
        private int _ReturnStatus;//返回状态
        private string _ReturnMessage;//返回信息
        /// <summary>
        /// 把DataTable导出到EXCEL
        /// </summary>
        /// <param name="reportName">报表名称</param>
        /// <param name="dt">数据源表</param>
        /// <param name="saveFileName">Excel全路径文件名</param>
        /// <returns>导出是否成功</returns>
        public bool ExportExcel(string reportName, System.Data.DataTable dt, string saveFileName)
        {
            if (dt == null)
            {
                _ReturnStatus = -1;
                _ReturnMessage = "数据集为空！";
                return false;
            }

            bool fileSaved = false;
            Microsoft.Office.Interop.Excel.Application ExlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            if (ExlApp == null)
            {
                _ReturnStatus = -1;
                _ReturnMessage = "无法创建Excel对象，可能您的计算机未安装Excel";
                return false;
            }

            Microsoft.Office.Interop.Excel.Workbooks workbooks = ExlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
            worksheet.Cells.Font.Size = 12;
            Microsoft.Office.Interop.Excel.Range range;

            long totalCount = dt.Rows.Count;
            long rowRead = 0;
            float percent = 0;

            worksheet.Cells[1, 1] = reportName;
            ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1]).Font.Size = 12;
            ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1]).Font.Bold = true;

            //写入字段
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                worksheet.Cells[2, i + 1] = dt.Columns[i].ColumnName;
                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[2, i + 1];
                range.Interior.ColorIndex = 15;
                range.Font.Bold = true;

            }
            //写入数值
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[r + 3, i + 1] = dt.Rows[r][i].ToString();
                }
                rowRead++;
                percent = ((float)(100 * rowRead)) / totalCount;
            }

            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[dt.Rows.Count + 2, dt.Columns.Count]);
            range.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
            if (dt.Rows.Count > 0)
            {
                range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].ColorIndex = Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic;
                range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            }
            if (dt.Columns.Count > 1)
            {
                range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].ColorIndex = Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic;
                range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            }

            //保存文件
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                    fileSaved = true;
                }
                catch (Exception ex)
                {
                    fileSaved = false;
                    _ReturnStatus = -1;
                    _ReturnMessage = "导出文件时出错,文件可能正被打开！\n" + ex.Message;
                }
            }
            else
            {
                fileSaved = false;
            }
            //释放Excel对应的对象
            if (range != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
                range = null;
            }
            if (worksheet != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                worksheet = null;
            }
            if (workbook != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
            }
            if (workbooks != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks);
                workbooks = null;
            }
            ExlApp.Application.Workbooks.Close();
            ExlApp.Quit();
            if (ExlApp != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExlApp);
                ExlApp = null;
            }
            GC.Collect();
            return fileSaved;
        }
        #endregion
        private void txtCardId_MouseEnter(object sender, EventArgs e)
        {
            ToolTip objT = new ToolTip();
            objT.Show("如：40Cr", this.txtCardId);
        }

        private void txtMaterialType_MouseEnter(object sender, EventArgs e)
        {
            ToolTip objT = new ToolTip();
            objT.Show("如：中碳合金钢", this.txtMaterialType);
        }

        private void btnMaterialSql_Click(object sender, EventArgs e)
        {
            #region 数据验证
            if (this.txtCardId.Text.Trim().Length == 0)
            {
                MessageBox.Show("材料牌号不能为空！", "提示信息");
                this.txtCardId.Focus();
                return;
            }
            if (this.txtMaterialType.Text.Trim().Length == 0)
            {
                MessageBox.Show("材料类型不能为空！", "提示信息");
                this.txtMaterialType.Focus();
                return;
            }
            if (this.txtHeatType.Text.Trim().Length == 0)
            {
                MessageBox.Show("热处理方式不能为空！", "提示信息");
                this.txtHeatType.Focus();
                return;
            }
            if (this.txtHardVal.Text.Trim().Length == 0)
            {
                MessageBox.Show("材料硬度值不能为空！", "提示信息");
                this.txtHardVal.Focus();
                return;
            }
            if (this.txtContactVal.Text.Trim().Length == 0)
            {
                MessageBox.Show("接触疲劳极限值不能为空！", "提示信息");
                this.txtContactVal.Focus();
                return;
            }
            if (Common.DataValidate.IsNumber(this.txtContactVal.Text.Trim()))
            {
                MessageBox.Show("接触疲劳极限值有误，请重新输入！", "提示信息");
                this.txtContactVal.Focus();
                return;
            }
            if (this.txtBendVal.Text.Trim().Length == 0)
            {
                MessageBox.Show("弯曲疲劳极限值不能为空！", "提示信息");
                this.txtBendVal.Focus();
                return;
            }
            if (Common.DataValidate.IsNumber(this.txtBendVal.Text.Trim()))
            {
                MessageBox.Show("弯曲疲劳极限值有误，请重新输入！", "提示信息");
                this.txtBendVal.Focus();
                return;
            }

            #endregion
            #region 封装材料对象
            Materials objMaterial = new Materials()
            {
                MaterialCardId = this.txtCardId.Text.Trim(),
                MaterialType = this.txtMaterialType.Text.Trim(),
                HeatingType = this.txtHeatType.Text.Trim(),
                HardnessValue = this.txtHardVal.Text.Trim(),
                ContactFatigueLimit = this.txtContactVal.Text.Trim(),
                BendingFatigueLimit = this.txtBendVal.Text.Trim()
            };
            #endregion
            #region 调用后台数据访问方法添加对象
            try
            {
                if (1 == objMaterialService.AddMaterial(objMaterial))
                {
                    MessageBox.Show("添加成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

    }
}
