using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
   public class SQLHelp
    {
       private static string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
       
       /// <summary>
       /// 增删查改
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
       public static int Update(string sql)
       {
        SqlConnection conn=new SqlConnection(connString);
        SqlCommand cmd=new SqlCommand(sql,conn);
        conn.Open();
        int result=cmd.ExecuteNonQuery();
        conn.Close();
        return result;
       }
       
       /// <summary>
       /// 返回单一结果的查询
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
       public static object GetSingleResult(string sql)
       {
           SqlConnection conn = new SqlConnection(connString);
           SqlCommand cmd = new SqlCommand(sql, conn);
           conn.Open();
           object result = cmd.ExecuteScalar();
           conn.Close();
           return result;
       }

       /// <summary>
       /// 返回一个数据集的查询
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
       public static SqlDataReader GetReader(string sql)
       {
           SqlConnection conn = new SqlConnection(connString);
           SqlCommand cmd = new SqlCommand(sql, conn);
           conn.Open();
           return cmd.ExecuteReader(CommandBehavior.CloseConnection);
       }

        #region 执行带参数的SQL语句
           public static int Update(string sql,SqlParameter[] parameters)
           {
               SqlConnection conn = new SqlConnection(connString);
               SqlCommand cmd = new SqlCommand(sql, conn);
               try
               {
                   conn.Open();
                   cmd.Parameters.AddRange(parameters);
                   int result = cmd.ExecuteNonQuery();
                   return result;
               }
               catch (Exception ex)
               {
                   throw ex;
               }
               finally
               {
                   conn.Close();
               }                 
               
           }


           public static object GetSingleResult(string sql, SqlParameter[] parameters)
           {
               SqlConnection conn = new SqlConnection(connString);
               SqlCommand cmd = new SqlCommand(sql, conn);
               try
               {
                   conn.Open();
                   cmd.Parameters.AddRange(parameters);
                   object result = cmd.ExecuteScalar();
                   return result;
               }
               catch (Exception ex)
               {
                   throw ex;
               }
               finally
               {
                   conn.Close();
               }  
           }


           public static SqlDataReader GetReader(string sql, SqlParameter[] parameters)
           {
               SqlConnection conn = new SqlConnection(connString);
               SqlCommand cmd = new SqlCommand(sql, conn);
               try
               {                   
                   conn.Open();
                   cmd.Parameters.AddRange(parameters);
                   return cmd.ExecuteReader(CommandBehavior.CloseConnection);
               }
               catch (Exception ex)
               {
                   conn.Close();//不能写在finally里面
                   throw ex;
               }
             
           }

           //其它说明：web里面不用返回DataSet的方法
        #endregion
    }
}
