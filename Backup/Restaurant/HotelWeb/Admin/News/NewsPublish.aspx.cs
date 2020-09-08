using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using Models;

namespace HotelWeb.Admin
{
    public partial class NewsPublish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //判断是发布还是修改
                if(Request.QueryString["Operation"]=="0")
                {
                    this.btnModify.Visible = false;
                }
                else if (Request.QueryString["Operation"] == "1")
                {
                    this.btnPublish.Visible = false;
                    string newsId = Request.QueryString["newsId"];//获取新闻编号，并保存
                    ViewState["newsId"] = newsId;
                    //显示新闻内容
                    News objNews = new DAL.NewsService().GetNewsById(newsId);
                    if (objNews == null)
                        Response.Redirect("~/HotelWeb/Admin/Default.aspx");
                    else
                    {
                        this.txtContent.Value = objNews.NewsContents;
                        this.txtNewsTitle.Text = objNews.NewsTitle;
                        this.ddlCategory.SelectedValue = objNews.CategoryId.ToString();//下拉列表框内部对应值是直接编辑输入的，列表项的值是1/2！
                    }                    
                }
                else
                    Response.Redirect("~/HotelWeb/Admin/Default.aspx");             
            }
            this.ltaMsg.Text = "";
           
        }
        //发布和修改新闻
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            //数据验证
            if(this.txtNewsTitle.Text.Trim().Length==0)
            {
                this.ltaMsg.Text = "<script>alert('请输入新闻标题')</script>";
                return;
            }
            if (this.txtContent.Value.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入新闻内容')</script>";
                return;
            }
            if (this.ddlCategory.SelectedIndex==-1)
            {
                this.ltaMsg.Text = "<script>alert('请选择新闻分类')</script>";
                return;
            }
            //封装新闻对象
            News objNews = new News()
            {
                NewsTitle = this.txtNewsTitle.Text.Trim(),
                CategoryId = Convert.ToInt32(this.ddlCategory.SelectedValue),
                NewsContents = this.txtContent.Value
            };
            if (ViewState["newsId"] != null)
            {
                objNews.NewsId = Convert.ToInt32(ViewState["newsId"]);
            }
            //提交数据
            try
            {
                if (this.btnPublish.Visible)//发布新闻
                {
                    new DAL.NewsService().PublishNews(objNews);
                    this.ltaMsg.Text = "<script>alert('发布成功')</script>";
                    //清除已输入的内容
                    this.txtContent.Value = "";
                    this.txtNewsTitle.Text = "";
                    this.ddlCategory.SelectedIndex = -1;
                }
                else
                {
                    new NewsService().ModifyNews(objNews);
                    this.ltaMsg.Text = "<script>alert('修改成功');location.href='/HotelWeb/Admin/News/NewsManager.aspx'</script>";
                }
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('提交失败"+ex.Message+"')</script>";
                
            }
        }       
    }
}