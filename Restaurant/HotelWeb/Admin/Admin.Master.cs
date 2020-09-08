using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models;


namespace HotelWeb.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //保证登录的时候，没有登录就进入不了任何Admin文件夹的页面（用了该母版的页面）
            if (Session["SysAdmin"] == null)
            {
                Response.Redirect("~/HotelWeb/Admin/AdminLogin.aspx");
            }
            else
            {
                this.ltaAdmin.Text = "[当前用户："+((SysAdmin)Session["SysAdmin"]).LoginName+"]";
            }
        }
    }
}