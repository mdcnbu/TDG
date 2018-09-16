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
    public class MaterialService
    {
        public List<Materials> GetMaterialValue()
        {
            string sql = "select MaterialCardId,MaterialType,HeatingType,HardnessValue,ContactFatigueLimit,BendingFatigueLimit from Material";
            sql = string.Format(sql);
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<Materials> materialList = new List<Materials>();
            while (objReader.Read())
            {
                materialList.Add(new Materials()
                {
                    MaterialCardId = objReader["MaterialCardId"].ToString(),
                    MaterialType = objReader["MaterialType"].ToString(),
                    HeatingType = objReader["HeatingType"].ToString(),
                    HardnessValue = objReader["HardnessValue"].ToString(),
                    ContactFatigueLimit = objReader["ContactFatigueLimit"].ToString(),
                    BendingFatigueLimit = objReader["BendingFatigueLimit"].ToString()
                });
            }
            objReader.Close();
            return materialList;
        }
    }
}
