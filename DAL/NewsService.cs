using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 新闻管理数据访问类
    /// </summary>
    public class NewsService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="objNews"></param>
        /// <returns></returns>
        public int PublishNews(News objNews)
        {
            //NewsId是自增列，PublishTime是系统时间，无需处理
            string sql = "insert into News(NewsTitle,NewsContents,CategoryId) values(@NewsTitle,@NewsContents,@CategoryId)";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter ("@NewsTitle",objNews.NewsTitle),
                new SqlParameter ("@NewsContents",objNews.NewsContents),
                new SqlParameter ("@CategoryId",objNews.CategoryId)            
            };
            return SQLHelp.Update(sql, param);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int ModifyNews(News objNews)
        {
            string sql = "update News set NewsTitle=@NewsTitle,NewsContents=@NewsContents,CategoryId=@CategoryId";
            sql += " where NewsId=@NewsId";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter ("@NewsTitle",objNews.NewsTitle),
                new SqlParameter ("@NewsContents",objNews.NewsContents),
                new SqlParameter ("@CategoryId",objNews.CategoryId),
                new SqlParameter("@NewsId",objNews.NewsId)
            };
            return SQLHelp.Update(sql,param);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public int DeleteNews(string newsId)
        {
            string sql = "delete from News where NewsId=@NewsId";
            SqlParameter[] param = new SqlParameter[]{               
                new SqlParameter("@NewsId",newsId)
            };
            return SQLHelp.Update(sql,param);
        }
        /// <summary>
        /// 查询指定条数的新闻
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<News> GetNews(int count)
        {
            string sql = "select top " + count + " NewsId,NewsTitle,PublishTime,NewsCategory.CategoryId,CategoryName from News";
            sql += " inner join NewsCategory on NewsCategory.CategoryId=News.CategoryId Order by PublishTime DESC";
            List<News> list = new List<News>();
            SqlDataReader objReader = SQLHelp.GetReader(sql);
            while(objReader.Read())
            {
                list.Add(new News() { 
                    NewsId=Convert.ToInt32(objReader["NewsId"]),
                    NewsTitle=objReader["NewsTitle"].ToString(),
                    CategoryName=objReader["CategoryName"].ToString(),
                    PublishTime=Convert.ToDateTime(objReader["PublishTime"]),
                    CategoryId=Convert.ToInt32(objReader["CategoryId"])
                });
                //CategoryId=Convert.ToInt32(objReader["CategoryId"])可以不要
            }
            objReader.Close();
            return list;
        }

        /// <summary>
        /// 根据新闻编号查询新闻对象
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public News GetNewsById(string newsId)
        {
            string sql = "select NewsId,NewsTitle,NewsContents,PublishTime,CategoryId from News where NewsId=@NewsId";
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@NewsId",newsId)
            };
            News objNews = null;
            SqlDataReader objReader = SQLHelp.GetReader(sql,param);
            if(objReader.Read())
            {
                objNews = new News()
                {
                    NewsId = Convert.ToInt32(objReader["NewsId"]),
                    NewsTitle=objReader["NewsTitle"].ToString(),
                    NewsContents=objReader["NewsContents"].ToString(),
                    PublishTime=Convert.ToDateTime(objReader["PublishTime"]),
                    CategoryId=Convert.ToInt32(objReader["CategoryId"])
                };         
            }
           
            objReader.Close();
            return objNews;
        }
    }
}
