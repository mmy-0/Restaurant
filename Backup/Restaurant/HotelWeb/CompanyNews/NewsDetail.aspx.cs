using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;


namespace HotelWeb.CompanyNews
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string newsId = Request.Params["NewsId"];
                if (newsId != null && newsId != string.Empty)
                {
                    News objNews = new DAL.NewsService().GetNewsById(newsId);
                    if (objNews == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        this.ltaNewsContents.Text = objNews.NewsContents;
                        this.ltaNewsTitle.Text = objNews.NewsTitle;
                        this.ltaPublishTime.Text = objNews.PublishTime.ToShortDateString();
                    }
                }
            }
        }
    }
}