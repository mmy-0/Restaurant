using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    public class DishBookService
    {
        /// <summary>
        /// 客户预定
        /// </summary>
        /// <param name="objDishBook"></param>
        /// <returns></returns>
        public int Book(DishBook objDishBook)
        {
            string sql = "insert into DishBook(HotelName,ConsumeTime,ConsumePersons,RoomType,CustomerName,CustomerPhone,CustomerEmail,Comments)";
            sql += " values(@HotelName,@ConsumeTime,@ConsumePersons,@RoomType,@CustomerName,@CustomerPhone,@CustomerEmail,@Comments)";
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@HotelName",objDishBook.HotelName),
                new SqlParameter("@ConsumeTime",objDishBook.ConsumeTime),
                new SqlParameter("@ConsumePersons",objDishBook.ConsumePersons),
                new SqlParameter("@RoomType",objDishBook.RoomType),
                new SqlParameter("@CustomerName",objDishBook.CustomerName),
                new SqlParameter("@CustomerPhone",objDishBook.CustomerPhone),
                new SqlParameter("@CustomerEmail",objDishBook.CustomerEmail),
                new SqlParameter("@Comments",objDishBook.Comments),                
            };
            return SQLHelp.Update(sql,param);
        }

        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public int ModifyBook(string bookId,string orderStatus)
        {
            string sql = "update DishBook set OrderStatus=@OrderStatus where BookId=@BookId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@OrderStatus",orderStatus),
                new SqlParameter("@BookId",bookId)
            };
            return SQLHelp.Update(sql,param);
        }

        /// <summary>
        /// 获取未关闭的订单
        /// </summary>
        /// <returns></returns>
        public List<DishBook> GetAllDishBook()
        {
            string sql = "select BookId,HotelName,ConsumeTime,ConsumePersons,RoomType,CustomerName,CustomerPhone,CustomerEmail,Comments,BookTime,OrderStatus from DishBook";
            sql += " where OrderStatus=0 or OrderStatus=1 order by BookTime DESC";
            List<DishBook> list = new List<DishBook>();
            SqlDataReader objReader = SQLHelp.GetReader(sql);
            while(objReader.Read())
            {
                list.Add(new DishBook() {
                    BookId = Convert.ToInt32(objReader["BookId"]),
                    HotelName = objReader["HotelName"].ToString(),
                    ConsumeTime = Convert.ToDateTime(objReader["ConsumeTime"]),
                    ConsumePersons =Convert.ToInt32(objReader["ConsumePersons"]),
                    RoomType = objReader["RoomType"].ToString(),
                    CustomerName = objReader["CustomerName"].ToString(),
                    CustomerPhone = objReader["CustomerPhone"].ToString(),
                    CustomerEmail = objReader["CustomerEmail"].ToString(),
                    Comments = objReader["Comments"].ToString(),
                    BookTime = Convert.ToDateTime(objReader["BookTime"]),
                    OrderStatus = Convert.ToInt32(objReader["OrderStatus"])                
                });
            }
            objReader.Close();
            return list;
        }
    }
}
