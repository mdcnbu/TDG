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
   public class WorkFeatureService
    {
       /// <summary>
    /// 工作特性数据访问类
    /// </summary>  
        
        public List <WorkFactor1> GetWorkFeature()
        {
            /// <summary>
            /// 封装原动机的方法
            /// </summary>
            /// <returns></returns>
            string sql="select WorkFeature,MoverCharacter from WorkFactor1";
            sql=string .Format (sql);
            SqlDataReader objReader=SQLHelper .GetReader(sql );
            List<WorkFactor1> workList=new List <WorkFactor1>();
            while (objReader.Read())
            {
                workList.Add(new WorkFactor1()
                    {
                        MoverCharacter=objReader["MoverCharacter"].ToString(),
                        WorkFeature=objReader ["WorkFeature"].ToString()                       
                    });
            }
            objReader.Close();
            return workList;
        }

        public List<WorkFactor2> GetWorkFeature2()
        {
            string sql = "select WorkingFeature,DrivenCharacter from WorkFactor2";
            sql=string .Format (sql);
            SqlDataReader objReader=SQLHelper .GetReader(sql );
            List<WorkFactor2> workList=new List <WorkFactor2>();
            while (objReader.Read())
            {
                workList.Add(new WorkFactor2()
                    {
                        DrivenCharacter=objReader["DrivenCharacter"].ToString(),
                        WorkingFeature=objReader ["WorkingFeature"].ToString()                        
                    });
            }
            objReader.Close();
            return workList;
        }
    }
}
