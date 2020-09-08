using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models;
using DAL;


namespace HotelWeb.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            //数据验证
            if (this.txtLoginId.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入登录账号')</script>";
                return;
            }
            if (this.txtLoginPwd.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入登录密码')</script>";
                return;
            }

            //调用后台数据访问实现用户登录
            SysAdmin objAdmin = new SysAdminService().AdminLogin(this.txtLoginId.Text.Trim(), this.txtLoginPwd.Text.Trim());
            if (objAdmin == null)
            {
                this.ltaMsg.Text = "<script>alert('用户名或密码错误！')</script>";
            }
            else
            {
                Session["SysAdmin"] = objAdmin;
                Response.Redirect("Default.aspx");
            }
        }

     
    }
}