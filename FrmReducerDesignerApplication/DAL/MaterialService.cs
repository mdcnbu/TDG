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
        /// <summary>
        /// 获取材料方法，返回值为对象类型（集合）
        /// </summary>
        /// <returns></returns>
        public List<Materials> GetMaterialValue()
        {
            string sql = "select MaterialCardId,MaterialType,HeatingType,HardnessValue,ContactFatigueLimit,BendingFatigueLimit from Material";
            sql = string.Format(sql);
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<Materials> materialList = new List<Materials>();
            while (objReader.Read())//while循环读取多条注意read（）方法的使用
            {
                materialList.Add(new Materials()
                {
                    MaterialCardId = objReader["MaterialCardId"].ToString(),//转换成string类型
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
        #region 添加材料
        /// <summary>
        /// 判断材料是否已经存在
        /// </summary>
        /// <param name="CardId">牌号</param>
        /// <returns></returns>
        public bool IsCardIdExisted(string CardId)
        {
            string sql = "select count(*) from Material where MaterialCardId='{0}'";
            sql = string.Format(sql, CardId);
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1) return true;
            else return false;
        }
        
        /// <summary>
        /// 封装材料对象
        /// </summary>
        /// <param name="objMaterial"></param>
        /// <returns></returns>
        public int AddMaterial(Materials objMaterial)
        {
            //[1]编写SQL语句
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Material(MaterialCardId,MaterialType,HeatingType,HardnessValue,ContactFatigueLimit,BendingFatigueLimit)");
            sqlBuilder.Append(" values('{0}','{1}','{2}','{3}',{4},{5})");
            //[2]解析对象
            string sql = string.Format(sqlBuilder.ToString(), objMaterial.MaterialCardId, objMaterial.MaterialType, objMaterial.HeatingType,
                objMaterial.HardnessValue, objMaterial.ContactFatigueLimit, objMaterial.BendingFatigueLimit);
            //[3] 提交到数据库
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                
                throw new Exception ("数据库操作出现异常！具体信息："+ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
