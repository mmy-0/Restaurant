using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelWeb.Admin
{
    public partial class DishesManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
           {
               DAL.DishService objService=new DAL.DishService();
            //下拉框初始化
               this.ddlCategory.DataValueField = "CategoryId";
               this.ddlCategory.DataTextField = "CategoryName";
               this.ddlCategory.DataSource = objService.GetALLCategory();
               this.ddlCategory.DataBind();

            //显示所有菜品
               this.rptList.DataSource = objService.GetDishes(null);
               this.rptList.DataBind();
           }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            this.rptList.DataSource = new DAL.DishService().GetDishes(this.ddlCategory.SelectedValue.ToString());
            this.rptList.DataBind();
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            string dishId = ((LinkButton)sender).CommandArgument;
            try
            {
                DAL.DishService objDishService=new DAL.DishService();
                objDishService.DeleteDish(dishId);
                //刷新（【数据量小：反查询方式】；数据量大：Jquery操作）
                this.rptList.DataSource = objDishService.GetDishes("");
                this.rptList.DataBind();
            }
            catch (Exception)
            {

                this.ltaMsg.Text = "<script>alert('删除失败')</script>";
            }
        }
    }
}