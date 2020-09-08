using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    public class SuggestionService
    {
        /// <summary>
        /// 查询投诉（获取未处理的即可）
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        public List<Suggestion> GetSuggestion()
        {
            string sql = "select SuggestionId,CustomerName,ConsumeDesc,SuggestionDesc,SuggestTime,PhoneNumber,Email,StatusId";
            sql += " from Suggestion where StatusId=0 order by SuggestTime DESC";           
            List<Suggestion> list = new List<Suggestion>();
            SqlDataReader objReader = SQLHelp.GetReader(sql);
            while(objReader.Read())
            {
                list.Add(new Suggestion() {
                    SuggestionId =Convert.ToInt32(objReader["SuggestionId"]),
                    CustomerName = objReader["CustomerName"].ToString(),
                    ConsumeDesc = objReader["ConsumeDesc"].ToString(),
                    SuggestionDesc = objReader["SuggestionDesc"].ToString(),
                    SuggestTime = Convert.ToDateTime(objReader["SuggestTime"]),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    Email = objReader["Email"].ToString(),
                    StatusId = Convert.ToInt32(objReader["StatusId"])

                });
            }
            objReader.Close();
            return list;
        }

        
        /// <summary>
        /// 受理投诉
        /// </summary>
        /// <param name="objSuggestion"></param>
        /// <returns></returns>
        public int ModifySuggestion(string suggestionId)
        {
            string sql = "update Suggestion set StatusId=1 where SuggestionId=@SuggestionId";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@SuggestionId",suggestionId),
                
            };
            return SQLHelp.Update(sql,param);
            
        }

        /// <summary>
        /// 提交投诉（SuggestTime数据库系统获得，StatusId默认0，SuggestionId自增长标识列）
        /// </summary>
        /// <param name="objSuggestion"></param>
        /// <returns></returns>
        public int AddSuggestion(Suggestion objSuggestion)
        {
            string sql = "insert into Suggestion(CustomerName,ConsumeDesc,SuggestionDesc,PhoneNumber,Email)";
            sql += " values(@CustomerName,@ConsumeDesc,@SuggestionDesc,@PhoneNumber,@Email)";
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@CustomerName",objSuggestion.CustomerName),
                new SqlParameter("@ConsumeDesc",objSuggestion.ConsumeDesc),
                new SqlParameter("@SuggestionDesc",objSuggestion.SuggestionDesc),
                new SqlParameter("@PhoneNumber",objSuggestion.PhoneNumber),                
                new SqlParameter("@Email",objSuggestion.Email)               
            };
            //return Convert.ToInt32(SQLHelper.GetSingleResult(sql, param));
            return SQLHelp.Update(sql, param);
        }
    }
}
