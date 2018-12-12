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
       /// <summary>
       /// 管理员登录
       /// </summary>
       /// <param name="objAdmin"></param>
       /// <returns></returns>
       public SysAdmin AdminLogin(SysAdmin objAdmin)
       {
           //组合sql语句
           string sql = "select AdminName from Admins where LoginId='{0}' and LoginPwd='{1}'";
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

        #region 添加管理员用户
       /// <summary>
       /// 判断管理员是否已经存在
       /// </summary>
       /// <param name="LoginId">登录名</param>
       /// <returns></returns>
       public bool LoginIdIsExited(string LoginId)
       {
           string sql = "select count(*) from Admins where LoginId='{0}'";
           sql = string.Format(sql, LoginId);
          int res=Convert.ToInt32( SQLHelper.GetSingleResult(sql));
          if (1 == res) return true;
          else return false;
       }
       /// <summary>
       /// 添加数据（解析对象）
       /// </summary>
       /// <param name="objAdmin"></param>
       /// <returns></returns>
       public int AddAdmins(SysAdmin objAdmin)
       {
           //[1]编写SQL语句
           StringBuilder objStr = new StringBuilder();
           objStr.Append("insert into Admins(LoginId,LoginPwd,AdminName)");
           objStr.Append(" values('{0}','{1}','{2}')");
           //[2]解析对象
           string sql = string.Format(objStr.ToString(), objAdmin.LoginId, objAdmin.LoginPwd, objAdmin.AdminName);
           //[3]提交到数据库
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
