using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SysAdminService
    {
        /// <summary>
        /// 用户登录的方法
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="loginPwd"></param>
        /// <returns></returns>
        public SysAdmin AdminLogin(string loginId,string loginPwd)
        {
            string sql = "select LoginName from SysAdmins where LoginId=@LoginId and LoginPwd=@LoginPwd";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@LoginId",loginId),
                new SqlParameter("@LoginPwd",loginPwd)
            };
            SysAdmin objAdmin = null;
            object result = SQLHelp.GetSingleResult(sql,param);
            if (result != null)
            {
                objAdmin = new SysAdmin() 
                {
                    LoginId = Convert.ToInt32(loginId),
                    LoginName = result.ToString(),
                    LoginPwd = loginPwd
                };//内部分量值:给实体属性赋值！LoginName = result.ToString(),因为select语句是返回LoginName
            }
            return objAdmin;
        }
    }
}
