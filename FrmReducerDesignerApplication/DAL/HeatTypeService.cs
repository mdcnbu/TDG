using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
  public class HeatTypeService
    {
        //根据材料牌号查询热处理方式
        public List<HeatType> GetHeatType(string materialCardId)
        {
            string sql = "select HeatingType,MaterialCardId from HeatType";
            sql += " inner join MaterialId on HeatType.CardId=MaterialId.CardId";
            sql += " where MaterialCardId='{0}'";
            sql = string.Format(sql, materialCardId);
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<HeatType> list = new List<HeatType>();
            while (objReader.Read())
            {
                list.Add(new HeatType()
                {
                    HeatingType = objReader["HeatingType"].ToString(),
                    MaterialCardId = objReader["MaterialCardId"].ToString()
                });
            }
            objReader.Close();
            return list;
        }
    }
}
