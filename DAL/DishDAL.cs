using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Models;
namespace DAL
{
    public class DishDAL
    {
        ///<summary>
        ///增加菜品
        ///</summary>
        /// <returns></returns>
        public static int AddDish(Dish dishes)
        {
            SqlParameter[] p = {
                  new SqlParameter("@DishName",dishes.DishName),
                  new SqlParameter("@UnitPrice",dishes.UnitPrice),
                  new SqlParameter("@CategoryId",dishes.CategoryId)
            };
            string sqltext = "insert into Dishes(DishName,UnitPrice,CategoryId) values (@DishName, @UnitPrice, @CategoryId);select @@identity";

            int i = Convert.ToInt32(SQL.SQLHelp.ExecuteScalar(sqltext, CommandType.Text, p));

            return i;
        }

        /// <summary>
        /// 获取菜单类列表
        /// </summary>
        /// <returns></returns>
        /// 
        public static List<DishCategory> GetAllDishCategory()
        {
            string sql = "select CategoryId,CategoryName from DishCategory";
            SqlDataReader dr = SQL.SQLHelp.ExecuteReader(sql, CommandType.Text, null);
            List<DishCategory> list = new List<DishCategory>();///
            while (dr.Read())
            {
                DishCategory n = new DishCategory();
                n.CategoryName = Convert.ToString(dr["CategoryName"]);
                n.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                list.Add(n);
            }
            return list;
        }

        /// <summary>
        /// 获取单个菜品
        /// </summary>
        /// <returns></returns>
        /// 
        public static Dish GetAllDish(int DishId)
        {
            SqlParameter[] p = {
                  new SqlParameter("@DishId",DishId)
            };
            string sql = "select * from Dishes where DishId=@DishId";
            SqlDataReader dr = SQL.SQLHelp.ExecuteReader(sql, CommandType.Text, p);
            Dish n = new Dish();
            while (dr.Read())
            {
                n.DishName = Convert.ToString(dr["DishName"]);
                n.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                n.UnitPrice = Convert.ToInt32(dr["UnitPrice"]);
                n.DishId = Convert.ToInt32(dr["DishId"]);

            }
            return n;
        }

        /// <summary>
        /// 获取菜单类列表
        /// </summary>
        /// <returns></returns>
        /// 
        public static List<Dish> GetAllDish(string CategoryId)
        {
            string sql = "select * from Dishes,DishCategory where Dishes.CategoryId=DishCategory.CategoryId";
            
            List<Dish> list = new List<Dish>();///
            if (CategoryId == null||CategoryId==string.Empty)
            {
                SqlDataReader dr = SQL.SQLHelp.ExecuteReader(sql, CommandType.Text, null);
                while (dr.Read())
                {
                    Dish n = new Dish();
                    n.DishName = Convert.ToString(dr["DishName"]);
                    n.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    n.UnitPrice = Convert.ToInt32(dr["UnitPrice"]);
                    n.DishId = Convert.ToInt32(dr["DishId"]);
                    n.CategoryName = Convert.ToString(dr["CategoryName"]);
                    list.Add(n);
                }
            }
            else
            {
                sql += " and Dishes.CategoryId=@CategoryId";
                SqlParameter[] p = {
                  new SqlParameter("@CategoryId",CategoryId)
                };
                SqlDataReader dr = SQL.SQLHelp.ExecuteReader(sql, CommandType.Text, p);
                while (dr.Read())
                {
                    Dish n = new Dish();
                    n.DishName = Convert.ToString(dr["DishName"]);
                    n.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    n.UnitPrice = Convert.ToInt32(dr["UnitPrice"]);
                    n.DishId = Convert.ToInt32(dr["DishId"]);
                    n.CategoryName = Convert.ToString(dr["CategoryName"]);
                    list.Add(n);
                }
            }    
            return list;
        }

        /// <summary>
        /// 修改菜品
        /// </summary>
        /// <returns></returns>
        /// 
        public static bool Change_Dish(Dish dishes)
        {
            SqlParameter[] p = {
                  new SqlParameter("@DishName",dishes.DishName),
                  new SqlParameter("@UnitPrice",dishes.UnitPrice),
                  new SqlParameter("@DishId",dishes.DishId)
            };
            string sqltext = " update Dishes set DishName=@DishName,UnitPrice=@UnitPrice where DishId=@DishId ";

            int i = Convert.ToInt32(SQL.SQLHelp.ExecuteNonQuery(sqltext, CommandType.Text, p));
            return i > 0;
        }

        /// <summary>
        /// 删除菜品
        /// </summary>
        /// <returns></returns>
        /// 
        public static bool DeleteDish(int DishId)
        {
            SqlParameter[] p = {
                  new SqlParameter("@DishId",DishId)
            };
            string sql = "delete from Dishes where DishId=@DishId";
            int i = Convert.ToInt32(SQL.SQLHelp.ExecuteNonQuery(sql, CommandType.Text, p));
            return i > 0;
        }

    }
}
