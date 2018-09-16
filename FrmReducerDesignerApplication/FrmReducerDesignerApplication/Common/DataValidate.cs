using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FrmReducerDesignerApplication.Common
{
    /// <summary>
    /// 基于正则表达式的数据验证
    /// </summary>
  public class DataValidate
    {    
       //正整数验证
        public static bool IsInteger(string txt)
        {
            Regex objReg = new Regex(@"^[1-9]\d*$");
            return objReg.IsMatch(txt);
        }
       //数字验证
        public static bool IsNumber(string txt)
        {
            Regex objReg = new Regex(@"^[0-9]*$");
            return objReg.IsMatch(txt);
        }
        public static bool VerificationIsDigital(string txt)
        {
            Regex objReg = new Regex(@"^\d+(.\d+)?$");
            return objReg.IsMatch(txt);            
        }
    }
}
