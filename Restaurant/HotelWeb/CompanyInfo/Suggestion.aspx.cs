using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace HotelWeb.CompanyInfo
{
    public partial class Suggestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //数据验证
            if (this.txtCustomerName.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入您的姓名！')</script>";
                return;
            }
            if (this.txtConsumeDesc.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入您的消费情况！')</script>";
                return;
            }
            if (this.txtPhoneNumber.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入您的联系电话！')</script>";
                return;
            }
            if (this.txtSuggestion.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入您的建议或投诉内容！')</script>";
                return;
            }
            if (this.txtValidateCode.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入验证码！')</script>";
                return;
            }
            if (this.txtValidateCode.Text.Trim() != Session["CheckCode"].ToString())
            {
                this.ltaMsg.Text = "<script>alert('验证码不正确！')</script>";
                return;
            }
            //封装对象
            Models.Suggestion objSuggestion = new Models.Suggestion()
            {
                CustomerName = this.txtCustomerName.Text.Trim(),
                ConsumeDesc = this.txtConsumeDesc.Text.Trim(),
                SuggestionDesc = this.txtSuggestion.Text.Trim(),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                Email = this.txtEmail.Text.Trim()
            };
            //提交数据         
            try
            {
                new SuggestionService().AddSuggestion(objSuggestion);
                this.ltaMsg.Text = "<script>alert('提交成功，我们会尽快处理！');location.href='../Default.aspx'</script>";
            }
            catch (Exception ex)
            {                
                this.ltaMsg.Text = "<script>alert('提交失败！" + ex.Message + "')</script>";
            }
        }

    }
}