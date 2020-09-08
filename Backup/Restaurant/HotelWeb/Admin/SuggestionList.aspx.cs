using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HotelWeb.Admin
{
    public partial class SuggestionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.rplList.DataSource = new DAL.SuggestionService().GetSuggestion();
                this.rplList.DataBind();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string  suggestionId = ((LinkButton)sender).CommandArgument;
            new DAL.SuggestionService().ModifySuggestion(suggestionId);
            //刷新
            this.rplList.DataSource = new DAL.SuggestionService().GetSuggestion();
            this.rplList.DataBind();
        }   
       
    }
}