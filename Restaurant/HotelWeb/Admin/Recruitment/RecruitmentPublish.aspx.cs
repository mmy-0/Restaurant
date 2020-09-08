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
    public partial class RecruitmentPublish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            //数据验证（界面输入）
            if (this.txtPostName.Text.Trim().Length == 0)
            {
                ltaMsg.Text = "<script>alert('请输入招聘职位')</script>";
                return;
            
            }
            if(this.ddlPostType.SelectedIndex == -1)
            {
                ltaMsg.Text = "<script>alert('请选择职位类型')</script>";
                return;
            }
            if (this.ddlwork.SelectedIndex == -1)
            {
                ltaMsg.Text = "<script>alert('请选择工作经验')</script>";
                return;
            }
            if (this.ddlEducation.SelectedIndex == -1)
            {
                ltaMsg.Text = "<script>alert('请选择学历')</script>";
                return;
            }
            if (this.txtCount.Text.Trim().Length == 0)
            {
                ltaMsg.Text = "<script>alert('请输入招聘数量')</script>";
                return;

            }
            if (this.txtPlace.Text.Trim().Length == 0)
            {
                ltaMsg.Text = "<script>alert('请输入招聘地点')</script>";
                return;

            }
            if (this.txtDesc.Value.Length == 0)
            {
                ltaMsg.Text = "<script>alert('请输入职位描述')</script>";
                return;

            }
            if (this.txtRequire.Value.Length == 0)
            {
                ltaMsg.Text = "<script>alert('请输入职位要求')</script>";
                return;

            }
            if (this.txtManager.Text.Trim().Length == 0)
            {
                ltaMsg.Text = "<script>alert('请输入联系人')</script>";
                return;

            }
            if (this.txtPhone.Text.Trim().Length == 0)
            {
                ltaMsg.Text = "<script>alert('请输入联系人电话')</script>";
                return;

            }
            if (this.txtEmail.Text.Trim().Length == 0)
            {
                ltaMsg.Text = "<script>alert('请输入联系人邮箱')</script>";
                return;

            }
            //封装数据SelectedValue*
            Models.Recruitment objRecruitment = new Models.Recruitment() {
                PostName = this.txtPostName.Text.Trim(),
                PostType=this.ddlPostType.SelectedValue,
                Experience = this.ddlwork.SelectedValue,
                EduBackground = this.ddlEducation.SelectedValue,
                RequireCount =Convert.ToInt32(this.txtCount.Text.Trim()),
                PostPlace = this.txtPlace.Text.Trim(),
                PostDesc = this.txtDesc.Value,
                PostRequire = this.txtRequire.Value,
                Manager = this.txtManager.Text.Trim(),
                PhoneNumber = this.txtPhone.Text.Trim(),
                Email = this.txtEmail.Text.Trim()
            };
           
            //提交数据
            try
            {
                new DAL.RecruitmentService().AddRecruitment(objRecruitment);
                ltaMsg.Text = "<script>alert('发布成功')</script>";
                this.txtPostName.Text = "";
                this.txtCount.Text = "";
                this.txtPlace.Text = "";
                this.txtDesc.Value = "";
                this.txtRequire.Value = "";
                this.txtManager.Text = "";
                this.txtPhone.Text="";
                this.txtEmail.Text = "";
            }
            catch (Exception ex)
            {

                ltaMsg.Text = "<script>alert('发布失败"+ex.Message+"')</script>";
            }
        }
     
    }
}