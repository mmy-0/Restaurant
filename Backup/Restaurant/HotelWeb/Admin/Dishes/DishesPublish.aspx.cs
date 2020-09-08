using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models;

namespace HotelWeb.Admin
{
    public partial class DishesPublish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if(!IsPostBack)
            {
                //初始化菜品下拉框
                this.ddlCategory.DataValueField = "CategoryId";//内部对应的具体值
                this.ddlCategory.DataTextField = "CategoryName";
                this.ddlCategory.DataSource = new DAL.DishService().GetALLCategory();
                this.ddlCategory.DataBind();

                //判断是修改还是新增
                if (Request.QueryString["Operation"] == "0")//新增
                {
                    this.btnEdit.Visible = false;
                }
                else if (Request.QueryString["Operation"] == "1")//不能直接else,要防止地址栏的数据修改
                {   //******************菜品修改************************
                    this.btnPublish.Visible = false;//隐藏添加按钮
                    string dishId = Request.QueryString["DishId"];
                    if (dishId == null || dishId == "")//如果没有提供该参数（防止地址栏的数据修改）
                    {
                        Response.Redirect("~/HotelWeb/Admin/default.aspx");
                        return;
                    }
                    //根据菜品编号获取菜品对象
                    Dish objDish = new DAL.DishService().GetDishById(dishId);//***
                    if (objDish == null)
                    {
                        Response.Redirect("~/HotelWeb/Admin/default.aspx");
                        return;
                    }
                    //前面都没问题，保存要修改的菜品编号DishId
                    ViewState["DishId"] = dishId;//类似成员变量作用，当页有效
                    this.txtDishName.Text = objDish.DishName;
                    this.txtUnitPrice.Text = objDish.UnitPrice.ToString();
                    this.ddlCategory.SelectedValue = objDish.CategoryId.ToString();
                    this.dishImage.ImageUrl = "~/Images/dish/" + dishId + ".png";
                }
                else
                {
                    Response.Redirect("~/HotelWeb/Admin/default.aspx");
                }
                this.ItaMsg.Text = "";
            }
        }


        //添加或者修改
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            //数据验证
            if (this.txtDishName.Text.Trim().Length == 0)
            {
                this.ItaMsg.Text = "<script>alert('请输入菜品名称')</script>";
                return;
            }
            if (this.txtUnitPrice.Text.Trim().Length == 0)
            {
                this.ItaMsg.Text = "<script>alert('请输入菜品价格')</script>";
                return;
            }
            if (this.ddlCategory.SelectedIndex== -1)
            {
                this.ItaMsg.Text = "<script>alert('请选择菜品分类')</script>";
                return;
            }
            //后台验证：正则表达式
            if(!Common.DataValidate.IsInteger(this.txtUnitPrice.Text.Trim()))
            {
                this.ItaMsg.Text = "<script>alert('菜品价格必须是整数')</script>";
                return;            
            }

            //封装对象
            Models.Dish objDish = new Dish() { 
                 DishName = this.txtDishName.Text.Trim(),
                 UnitPrice=Convert.ToInt32(this.txtUnitPrice.Text.Trim()),
                 CategoryId=Convert.ToInt32(this.ddlCategory.SelectedValue)
            };
            //***如果是修改，需要封装dishId
            if (ViewState["DishId"] != null)
            {
                objDish.DishId = Convert.ToInt32(ViewState["DishId"]);
            }

            //提交数据
            try
            {
                if (this.btnPublish.Visible) //多思路方法判断是添加或修改状态
                {
                    //图片上传判断（如果是新增菜品，必须选择图片）
                    if (!this.fulImage.HasFile)//【添加】数据判断图片的存在性***
                    {
                        this.ItaMsg.Text = "<script>alert('请选择菜品照片')</script>";
                        return;
                    }
                    //提交菜品信息，并返回菜品编号
                    int dishId = new DAL.DishService().AddDish(objDish);
                    //上传图片（调用独立方法）
                    this.UploadImage(dishId);
                    this.ItaMsg.Text = "<script>alert('添加成功')</script>";
                    //前端界面数据清空
                    this.txtDishName.Text = "";
                    this.txtUnitPrice.Text = "";
                    this.ddlCategory.SelectedIndex = -1;
                }
                else
                { 
                    //****修改数据
                    new DAL.DishService().ModifyDish(objDish);
                    //上传图片（调用独立方法）
                    this.UploadImage(objDish.DishId);
                    this.ItaMsg.Text = "<script>alert('修改成功');location.href='/HotelWeb/Admin/Dishes/DishesManager.aspx'</script>";
                    //Response.Redirect("/HotelWeb/Admin/Dishes/DishesManager.aspx");
                    //如果在这里写response,前面的alert不会弹出
                }
            }
            catch (Exception ex)
            {

                this.ItaMsg.Text = "<script>alert('添加失败" + ex.Message + "')</script>";
            }
           
        }

        private void UploadImage(int dishId)
        { 
            //是否有文件
            if(!this.fulImage.HasFile)//用意：【修改】数据是判断图片的存在性***
            {
                return;
            }
            //获取文件大小，判断是否符合要求
            double fileLength=this.fulImage.FileContent.Length/(1024*1024);
            if (fileLength>2.0)
            {
                this.ItaMsg.Text = "<script>alert('图片大小不能超过2M')</script>";
                return;
            }
            //获取图片文件名，并修改成规范的文件名
            string fileName = this.fulImage.FileName;
            if(fileName.Substring(fileName.LastIndexOf(".")).ToLower()!=".png")
            {
                this.ItaMsg.Text = "<script>alert('图片格式必须是PNG')</script>";
                return;
            }
            fileName = dishId + ".png";

            //上传图片
            try
            {
                string path = Server.MapPath("~/Images/dish");
                this.fulImage.SaveAs(path+"/"+fileName);
                this.ItaMsg.Text = "<script>alert('图片上传成功')</script>"; 
            }
            catch (Exception ex)
            {
                this.ItaMsg.Text = "<script>alert('图片上传失败"+ex.Message+"')</script>";                
            }

        }

      
    }
}