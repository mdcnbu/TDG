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
    /// 齿轮特性数据访问类
    /// </summary>
    public class GearValuesService
    {
        public List <Modules> GetModul()
        {
            string sql = "select GearModul from Modules";
            sql = string.Format(sql);
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<Modules> workList = new List<Modules>();
            while (objReader.Read())
            {
                workList.Add(new Modules()
                {
                    GearModul = Convert.ToDouble(objReader["GearModul"])                   
                });
            }
            objReader.Close();
            return workList;
        }

        public List<GearNums> GetNums()
        {
            string sql = "select GearNum from GearNums";
            sql = string.Format(sql);
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<GearNums> workList = new List<GearNums>();
            while (objReader.Read())
            {
                workList.Add(new GearNums()
                {
                    GearNum = Convert.ToInt32(objReader["GearNum"])
                });
            }
            objReader.Close();
            return workList;
        }

        public List<GearType> GetType()
        {
            string sql = "select GearTypes from GearType";
            sql = string.Format(sql);
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<GearType> workList = new List<GearType>();
            while (objReader.Read())
            {
                workList.Add(new GearType()
                {
                    GearTypes = objReader["GearTypes"].ToString()
                });
            }
            objReader.Close();
            return workList;
        }
    }
}
