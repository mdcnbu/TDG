using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmReducerDesignerApplication.Common
{
    /// <summary>
    /// 公共数据存储类
    /// </summary>
  public  class PassValues
    {
      //定义公共属性传值
      public static double p1;
      public static double inputPower;
      public static double speedRatio;
      public static double inputRevolo;
      public static double drivenEfficient;
      public static double outputTorque;
      public static double outRevolo;
      public static double inputTorque;
      public static double loadXishu;//均载系数
      public static double KA;//工作特性系数
      public static string Acurcy;//精度等级
      //【2】窗体2数据
      public static int plantaryNum;//行星轮数
      public static double za ;//太阳轮齿数
      public static double zb ;
      public static double zc ;
      public static double reRation ;//实际减速比
      public static string rationGap ;//减速比误差
      //实际输出转速和实际输出扭矩（计算）
      public static double outRevoReal ;//实际输出转速
      public static double outTorReal ;//实际输出扭矩
      public static double LReal;//实际中心距

      //[3]窗体3数据
      public static string sunMaterial;
      public static string planMaterial;
      public static string innMaterial;
      public static double BendValue1;
      public static double BendValue2;
      public static double BendValue3;
      public static double ContactValue1;//接触极限值
      public static double ContactValue2;
      public static double ContactValue3;
      public static string MaterialVala;
      public static string MaterialValb;
      public static string MaterialValc;

      //变位方式选择标记
      public static int shift;

      public static double yy1;
      public static double yy2;
      //窗体4数据
      public static double faiD;//齿宽系数
      public static double contactXY;//许用接触应力
      public static double Tac;//a-c传动扭矩
      public static double a;//实际中心距
      public static double anone;//未变位中心距
      public static double kc;//载荷系数
      public static double k;//综合系数
      public static double u;//齿数比
      public static double m;//模数
      public static double αac;
      public static double αcb;
      //变位系数===
      public static double Xa;//太阳轮变位系数
      public static double Xb;//内齿轮变位系数
      public static double Xc;//行星轮变位系数
           
      //窗体5数据
      public static double d1;//分度圆
      public static double d2;
      public static double d3;
      public static double da1;//齿顶圆
      public static double da2;
      public static double da3;
      public static double chdAC;
      public static double chdCB;

      //窗体6数据
      public static double contactA;
      public static double xyContactVak;
      public static double aBendVal;
      public static double cBendVal;
      public static double xyBenda;
      public static double xyBendc;
    }
}
