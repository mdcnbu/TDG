using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 插齿刀数据访问类
    /// </summary>
   public class CutToolService
    {
       /// <summary>
        /// 根据给定的模数查询数据
       /// </summary>
       /// <param name="M"></param>
       /// <returns></returns>
       public List<CutTool> GetToolValue(double M)
       {
           //定义连接字符串
           string sql = "select CutTool.ScaleValue, CutTool.GearNum,CutTool.D0,CutTool.Da0,CutTool.Ha0,CutTool.ToolStyle from CutTool";

           sql += string.Format(" where ScaleValue={0}", M);
          
           SqlDataReader objReader = SQLHelper.GetReader(sql);
           List<CutTool> list = new List<CutTool>();
           while (objReader.Read())
           {
               list.Add(new CutTool()
               {
                   ScaleValue = Convert.ToDouble(objReader["ScaleValue"]),
                   GearNum = Convert.ToInt32(objReader["GearNum"]),
                   D0 = Convert.ToDouble(objReader["D0"]),
                   Da0 = Convert.ToDouble(objReader["Da0"]),
                   Ha0 = Convert.ToDouble(objReader["Ha0"]),
                   ToolStyle = objReader["ToolStyle"].ToString()
               });
           }
           objReader.Close();
           return list;
       }

    }
}
