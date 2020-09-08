using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HotelWeb.CompanyInfo
{
    public partial class RecruitmentDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string postId = Request.QueryString["PostId"];
                if (postId != null && postId != "")
                {
                    Models.Recruitment objRec = new DAL.RecruitmentService().GetRecruitmentById(postId);
                    if (objRec != null)
                    {
                        //显示职位详细信息
                        this.ltaDesc.Text = objRec.PostDesc;
                        this.ltaEduBac.Text = objRec.EduBackground;
                        this.ltaEmail.Text = objRec.Email;
                        this.ltaExp.Text = objRec.Experience;
                        this.ltamManager.Text = objRec.Manager;
                        this.ltaPhone.Text = objRec.PhoneNumber;
                        this.ltaPostName.Text = objRec.PostName;
                        this.ltaPostType.Text = objRec.PostType;
                        this.ltaRecCount.Text = objRec.RequireCount.ToString();
                        this.ltaPublisTime.Text = objRec.PublishTime.ToShortDateString();
                        this.ltaRequire.Text = objRec.PostRequire;
                    }
                    else
                    {
                        Response.Redirect("~/HotelWeb/Default.aspx");
                    }
                }
            }
        }
    }
}