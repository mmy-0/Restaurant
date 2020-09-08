using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.HotelWeb.Handlers
{
    /// <summary>
    /// DishBook 的摘要说明
    /// </summary>
    public class DishBook : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //如果用户直接请求该Handler则拒绝
            if (context.Request.UrlReferrer == null)
            {
                context.Response.Write("请求错误！拒绝访问！");
                return;
            }
            //获取请求来路的完整URL
            string url = context.Request.UrlReferrer.AbsoluteUri;
            if (!url.Contains("/CompanyDishes/DishesBook.aspx"))
            {
                context.Response.Write("请求错误！拒绝访问！");
                return;
            }

            System.Threading.Thread.Sleep(2000);//该行代码，仅仅是为了看到提示效果

            //封装对象
            Models.DishBook objDishBook = new Models.DishBook()
            {
                CustomerName = context.Request.Params["txtCustomerName"],
                HotelName = context.Request.Params["ddlHotelName"],
                ConsumeTime = Convert.ToDateTime(context.Request.Params["txtConsumeTime"]),
                CustomerPhone = context.Request.Params["txtPhoneNumber"],
                CustomerEmail = context.Request.Params["txtEmail"],
                ConsumePersons = Convert.ToInt32(context.Request.Params["txtPersons"]),
                RoomType = context.Request.Params["ddlRoomType"],
                Comments = context.Request.Params["txtComment"] == "" ? "无" : context.Request.Params["txtComment"],
            };
            //提交数据
            try
            {
                new DAL.DishBookService().Book(objDishBook);
                context.Response.Write("success");
            }
            catch (Exception ex)
            {
                context.Response.Write("提交失败！" + ex.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}