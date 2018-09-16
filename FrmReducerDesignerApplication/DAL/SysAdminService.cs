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
    /// <summary>
    /// 数据访问类
    /// </summary>
   public class SysAdminService
    {
       public SysAdmin AdminLogin(SysAdmin objAdmin)
       {
           //组合sql语句
           string sql = "select AdminName from Admins where LoginId={0} and LoginPwd='{1}'";
           sql = string.Format(sql, objAdmin.LoginId, objAdmin.LoginPwd);//解析对象
           //从数据库中查询
           SqlDataReader objReader = SQLHelper.GetReader(sql);
           if (objReader.Read())
           {
               objAdmin.AdminName = objReader["AdminName"].ToString();

           }
           else
           {
               objAdmin = null;//登录不成功，清空当前对象
           }
           objReader.Close();
           return objAdmin;//返回结果
       }
       /// <summary>
       /// 修改管理员登录密码
       /// </summary>
       /// <param name="objAdmin"></param>
       /// <returns></returns>
       public int ModifyPwd(SysAdmin objAdmin)
       {
           string sql = "update Admins set LoginPwd='{0}' where LoginId={1}";
           sql = string.Format(sql, objAdmin.LoginPwd, objAdmin.LoginId);
           try
           {
               return SQLHelper.Update(sql);
           }
           catch (Exception ex)
           {
               throw new Exception("修改密码出现数据访问错误：" + ex.Message);
           }
       }
    }
}
