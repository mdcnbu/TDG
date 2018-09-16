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
   public class MaterialIdService
   {
       public List<MaterialId> GetMaterialId()
       {
           string sql = "select CardId,MaterialCardId from MaterialId";
           SqlDataReader objReader = SQLHelper.GetReader(sql);
           List<MaterialId> list = new List<MaterialId>();
           while (objReader.Read())
           {
               list.Add(new MaterialId()
               {
                   CardId = Convert.ToInt32(objReader["CardId"]),
                   MaterialCardId = objReader["MaterialCardId"].ToString()
               });
           }
           objReader.Close();
           return list;
       }
    }
}
