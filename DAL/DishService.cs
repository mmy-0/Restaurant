using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    /// <summary>
    /// 菜品数据访问类
    /// </summary>
    public class DishService
    {
        //// <summary>
        /// 获取菜品分类
        /// 绑定到下拉列表框
        /// </summary>
        /// <returns></returns>
        public List<DishCategory> GetALLCategory()
        {
            string sql = "select CategoryId,CategoryName from DishCategory";
            List<DishCategory> list = new List<DishCategory>();
            SqlDataReader objReader = SQLHelp.GetReader(sql);
            while(objReader.Read())
            {
                list.Add(new DishCategory() { 
                    CategoryId=Convert.ToInt32(objReader["CategoryId"]),
                    CategoryName=objReader["CategoryName"].ToString()
                });
            }
            objReader.Close();
            return list;
        }

        /// <summary>
        /// 新增菜品（返回新增菜品ID号）
        /// </summary>
        /// <param name="objDish"></param>
        /// <returns></returns>
        public int AddDish(Dish objDish)
        {
            string sql = "insert into Dishes(DishName,UnitPrice,CategoryId) values(@DishName,@UnitPrice,@CategoryId);select @@identity";
            SqlParameter[] param=new SqlParameter[]{
                new SqlParameter("@DishName",objDish.DishName),
                new SqlParameter("@UnitPrice",objDish.UnitPrice),
                new SqlParameter("@CategoryId",objDish.CategoryId)
            };
            return Convert.ToInt32(SQLHelp.GetSingleResult(sql,param)); //sql语句中有2条语句，所以用scaler方法
        }

        /// <summary>
        /// 根据菜品编号查询菜品对象
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Dish> GetDishes(string categoryId)
        {
            string sql = "select DishId,DishName,UnitPrice,Dishes.CategoryId,CategoryName from Dishes inner join DishCategory on DishCategory.CategoryId=Dishes.CategoryId";
            List<Dish> list = new List<Dish>();
            SqlDataReader objReader = null;
            if (categoryId == null || categoryId == string.Empty)
            {
                objReader = SQLHelp.GetReader(sql);
            }
            else
            {
                sql += " where Dishes.CategoryId=@CategoryId"; //****where前面加个空格！！！
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@CategoryId",categoryId)
                };
                objReader = SQLHelp.GetReader(sql,param);
            }
            while(objReader.Read())
            {
                list.Add(new Dish() 
                { 
                    DishId=Convert.ToInt32(objReader["DishId"]),
                    CategoryName = objReader["CategoryName"].ToString(),
                    CategoryId=Convert.ToInt32(objReader["CategoryId"]),                    
                    DishName=objReader["DishName"].ToString(),
                    UnitPrice=Convert.ToInt32(objReader["UnitPrice"])
                
                });

            }
            objReader.Close();
            return list;
        }

        /// <summary>
        /// 根据菜品编号获取菜品对象（有问题的菜品需要修改，单个对象）
        /// </summary>
        /// <param name="dishId"></param>
        /// <returns></returns>
        public Dish GetDishById(string dishId)
        {
            string sql = "select DishId,DishName,UnitPrice,CategoryId from Dishes where DishId=@DishId";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@DishId", dishId) };
            Dish objDish = null;
            SqlDataReader objReader = SQLHelp.GetReader(sql,param);
            if(objReader.Read())
            {
                objDish = new Dish() {
                    DishId = Convert.ToInt32(objReader["DishId"]),
                    CategoryId = Convert.ToInt32(objReader["CategoryId"]),                   
                    DishName = objReader["DishName"].ToString(),
                    UnitPrice = Convert.ToInt32(objReader["UnitPrice"])
                };
            }
            objReader.Close();
            return objDish;
        }

        /// <summary>
        /// 根据菜品编号修改菜品信息
        /// </summary>
        /// <param name="objDish"></param>
        /// <returns></returns>
        public int ModifyDish(Dish objDish)
        {
            string sql = "update Dishes set DishName=@DishName,UnitPrice=@UnitPrice,CategoryId=@CategoryId where DishId=@DishId";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@DishName",objDish.DishName),
                new SqlParameter("@UnitPrice",objDish.UnitPrice),
                new SqlParameter("@CategoryId",objDish.CategoryId),
                new SqlParameter("@DishId",objDish.DishId)
            };
            return SQLHelp.Update(sql,param);
        }

        /// <summary>
        /// 删除菜品
        /// </summary>
        /// <param name="dishId"></param>
        /// <returns></returns>
        public int DeleteDish(string dishId)
        {
            string sql = "delete from Dishes where DishId=@DishId";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@DishId",dishId)               
            };
             return SQLHelp.Update(sql,param);
        }
    }
}
