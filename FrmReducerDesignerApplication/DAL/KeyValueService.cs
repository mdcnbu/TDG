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
    /// 平键尺寸数据访问类
    /// </summary>
   public class KeyValueService
    {
       /// <summary>
       /// 获取所有数据
       /// </summary>
       /// <returns></returns>
       public List<KeyValue> GetAllVaule()
       {
           //[1]编写SQL语句
           string sql = "select minShaftDia,maxShaftDia,keyWidth,keyHight,shaftKeyDeep,circleKeyDeep from KeyValues ";
           sql = string.Format(sql);
           SqlDataReader objReader = SQLHelper.GetReader(sql);
           List<KeyValue> listValue = new List<KeyValue>();
           while (objReader.Read())
           {
               listValue.Add(new KeyValue
               {
                   minShaftDia = Convert.ToInt32(objReader["minShaftDia"]),
                   maxShaftDia = Convert.ToInt32(objReader["maxShaftDia"]),
                   keyWidth = Convert.ToInt32(objReader["keyWidth"]),
                   keyHight = Convert.ToInt32(objReader["keyHight"]),
                   shaftKeyDeep = Convert.ToDouble(objReader["shaftKeyDeep"]),
                   circleKeyDeep = Convert.ToDouble(objReader["circleKeyDeep"])
               });
           }
           objReader.Close();
           return listValue;
       }


    }
}
