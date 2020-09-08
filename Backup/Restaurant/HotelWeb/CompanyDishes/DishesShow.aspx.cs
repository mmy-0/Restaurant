using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelWeb.CompanyDishes
{
    public partial class DishesShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.rptList.DataSource = new DAL.DishService().GetDishes("");
                this.rptList.DataBind();
            }
        }
    }
}