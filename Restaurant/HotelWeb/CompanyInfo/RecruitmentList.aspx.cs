using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HotelWeb.CompanyInfo
{
    public partial class RecruitmentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.rptList.DataSource = new DAL.RecruitmentService().GetRecruitment();
                this.rptList.DataBind();
            }


        }
    }
}