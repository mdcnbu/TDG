//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using SolidWorks.Interop.swconst;
//using SolidWorks.Interop.sldworks;
//using MD_SW_ConnectSW;
//using System.Windows.Forms;
//using System.IO;
//using System.Data;


//namespace BatchExportDrawings
//{

//    class BendSheet
//    {
//        #region 定义全局变量
//        private SldWorks swApp;
//        private ModelDoc2 swModelDoc;
//        private DrawingDoc swDrawDoc;
//        private ModelDocExtension swModelEx;
//        private Sheet currentSheet;//图表
//        private IBody2 swBody;//实体
//        private AssemblyDoc swAssembly;
//        private Component2 swComp;//sw组件
//        private IView swView;//工程视图  
//        private int numSucess;
//        List<string> sucessFile = new List<string>();//转换成功的文件       
//        private BomTableAnnotation swBomTableAnno = default(BomTableAnnotation);
//        #endregion
//        object[] featArray;
//        private  bool  Sheet()
//        {
//            FeatureManager featureMgr = swModelDoc.FeatureManager;
//            FlatPatternFolder flatPatternFolder = default(FlatPatternFolder);
//            try
//            {
//                flatPatternFolder = (FlatPatternFolder)featureMgr.GetFlatPatternFolder();
//            }
//            catch (Exception) { }
//            if (flatPatternFolder == null)
//            {
//                swFileList[swFileListCount].SheetMetal = "否";
//                return false;
//            }
//            else
//            {
//                swFileList[swFileListCount].SheetMetal = "是";
//            }

//            feat = flatPatternFolder.GetFeature();
//            if (feat == null)
//            {
//                return false;
//            }
//            featArray = (object[])flatPatternFolder.GetFlatPatterns();
//            if (featArray == null)
//            {
//                return false;
//            }
//            for (int i = featArray.GetLowerBound(0); i <= featArray.GetUpperBound(0); i++)
//            {
//                feat = (Feature)featArray[i];
//                try
//                {
//                    //展开
//                    if (feat.IsSuppressed() == true) { feat.SetSuppression2((int)swFeatureSuppressionAction_e.swUnSuppressFeature, (int)swInConfigurationOpts_e.swThisConfiguration, configurationName); }
//                }
//                catch (Exception ex)
//                {
//                    swFileList[swFileListCount].CauseOfError += "钣金件未被正常展开，" + ex.Message;
//                    return false;
//                }

//                if (AddAnnotationText)
//                {
//                    if (AddAnnotation(modelDoc2, insertAnnotationText, savePath))	//转换到工程图
//                    {
//                        //GC.Collect();
//                    }
//                    else
//                    {
//                        swFileList[swFileListCount].Successful = "失败";
//                        swFileList[swFileListCount].CauseOfError = "缺少模板,若程序文件夹中无无图框模板请勿添加注释";
//                        return false;
//                    }
//                }
//                else
//                {
//                    PartDoc swPart = (PartDoc)modelDoc2;
//                    swPart.ExportToDWG2(savePath, swFileList[swFileListCount].FileName, swExportParameter, exportPublicParameter.exportFile, dataAlignment, exportPublicParameter.reverseX, exportPublicParameter.reverseY, exportSheetMetalOption, annotationViewParameter);
//                }
//                //modelDoc2 = (ModelDoc2)swApp.ActiveDoc;
//                //modelDoc2.ShowConfiguration2(configurationName);
//                //modelDoc2.EditRebuild3();
//                //feat = (Feature)featArray[i];
//                //if (feat.IsSuppressed() == false) { feat.SetSuppression2((int)swFeatureSuppressionAction_e.swSuppressFeature, (int)swInConfigurationOpts_e.swThisConfiguration, configurationName); }


//            }
//            return true;
//        }
//    }
 

//        /// <summary>
//        /// 加入注释
//        /// </summary>
//        /// <param name="modelDoc2"></param>
//        /// <returns></returns>
//        private bool AddAnnotation(ModelDoc2 modelDoc2, string annotationText, string savePath)
//{
//    ModelDoc2 modelDoc = null;
//    SldWorks swApp2 = new SldWorks();
//    //Assembly assembly = GetType().Assembly;
//    //Stream streamSmall = assembly.GetManifestResourceStream("TestSW2.无图框模板.drwdot");
//    if (!File.Exists(System.Environment.CurrentDirectory + @"\模板\无图框模板.drwdot"))
//    {
//        return false;
//    }
//    modelDoc = swApp2.INewDocument2(System.Environment.CurrentDirectory + @"\模板\无图框模板.drwdot", 12, 12.0, 12.0);
//    DrawingDoc drawingDoc = (DrawingDoc)modelDoc;
//    Sheet sheet = (Sheet)drawingDoc.GetCurrentSheet();
//    object properties = sheet.GetProperties();
//    double[] array = (double[])properties;
//    View view_ = drawingDoc.CreateFlatPatternViewFromModelView3(modelDoc2.GetPathName(), "", array[5] / 2.0, array[6] / 2.0, 0.0, !BendLine, false);
//    if (HideBendAnnotation)
//    {
//        drawingDoc.ActivateView(view_.Name);
//        for (Note note = (Note)view_.GetFirstNote(); note != null; note = (Note)note.GetNext())
//        {
//            note.GetText();
//            string propertyLinkedText = note.PropertyLinkedText;
//            if (propertyLinkedText.IndexOf("<bend-direction>") != -1 || propertyLinkedText.IndexOf("<bend-angle>") != -1 || propertyLinkedText.IndexOf("<bend-radius>") != -1)
//            {
//                note.Visible = false;
//                if (modelDoc.Extension.SelectByID2(note.GetName() + "@" + view_.Name, "NOTE", 0.0, 0.0, 0.0, false, 0, null, 0))
//                {
//                    modelDoc.HideDimension();
//                    modelDoc.ClearSelection2(true);
//                }
//            }
//        }
//    }
//    modelDoc.ClearSelection2(true);
//    modelDoc.EditRebuild3();
//    modelDoc.SaveAs(savePath);
//    swApp.CloseDoc(modelDoc.GetTitle());
//    return true;
//}
//}

//}




        