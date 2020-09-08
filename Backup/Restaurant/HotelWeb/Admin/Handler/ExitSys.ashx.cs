using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.SessionState; //****

namespace Restaurant.HotelWeb.Handler
{
    /// <summary>
    /// 在一般处理程序中使用session必须使用标记接口
    /// </summary>
    public class ExitSys : IHttpHandler,IRequiresSessionState //****标记接口
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Session.Abandon();
            context.Response.Redirect("~/HotelWeb/Admin/Default.aspx");
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