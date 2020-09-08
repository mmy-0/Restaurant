using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models;

namespace HotelWeb.Admin
{
    public partial class BookManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          if(!IsPostBack)
          {
              this.rptList.DataSource = new DAL.DishBookService().GetAllDishBook();
              this.rptList.DataBind();
            
          }
        }

        protected void lbtnOperation(object sender, EventArgs e)
        {
            string bookId = ((LinkButton)sender).CommandArgument;
            string status=((LinkButton)sender).CommandName;
            try
            {
                //修改预定状态
                new DAL.DishBookService().ModifyBook(bookId,status);
                this.ltaMsg.Text = "<script>alert('操作成功')</script>";
                //刷新
                this.rptList.DataSource = new DAL.DishBookService().GetAllDishBook();
                this.rptList.DataBind();
            }
            catch (Exception ex)
            {

                this.ltaMsg.Text = "<script>alert('操作失败"+ex.Message+"')</script>";
               
            }
        }

    }
}