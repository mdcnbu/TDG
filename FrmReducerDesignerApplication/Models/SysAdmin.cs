using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 管理员实体类
    /// </summary>
  public class SysAdmin
    {
        //自动属性
        public string LoginId { get; set; }
        public string AdminName { get; set; }
        public string LoginPwd { get; set; }
    }
}
