using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelWebProject.Adminhyl
{
    public partial class DishesPublish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //List<DishCategory> list = new List<DishCategory>();
                //list = DAL.DishDAL.GetAllDishCategory();
                //for (int i = 0; i < list.Count(); i++)
                //{
                //    ddlCategory.Items.Add(list[i].CategoryName);
                //}

                this.ddlCategory.DataValueField = "CategoryId";//内部对应值
                this.ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataSource = DAL.DishDAL.GetAllDishCategory();
                ddlCategory.DataBind();

                if (Request.QueryString["Operation"] == "0")
                {
                    Button1.Visible = false;
                }
                else
                {
                    btnPublish.Visible = false;
                    Dish n = new Dish();
                    n = DAL.DishDAL.GetAllDish(Convert.ToInt32(Request.QueryString["DishId"]));
                    txtDishName.Text = n.DishName;
                    txtUnitPrice.Text = n.UnitPrice.ToString();
                    dishImage.ImageUrl = "~/Images/dish/" + n.DishId + ".png";
                }
            }           
        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            if(txtDishName.Text.Trim().Length==0)
            {
                Label1.Text = "请输入菜品名";
                return;
            }
            if (txtUnitPrice.Text.Trim().Length == 0|| txtUnitPrice.Text.IndexOf(".") > 0)
            {
                Label1.Text = "请输入菜品价格(整数)";
                return;
            }
            if (ddlCategory.SelectedIndex == -1)
            {
                Label1.Text = "请选择菜品分类";
                return;
            }
            try
            {
                Convert.ToInt32(txtUnitPrice.Text);
            }
            catch (Exception)
            {
                Utility.JavaScript.Alert("输入数字非法!", this);
                return;
                //throw;
            }
            Dish dishes = new Dish();
            dishes.DishName = txtDishName.Text;
            dishes.UnitPrice = Convert.ToInt32(txtUnitPrice.Text);
            dishes.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);

            if(!fulImage.HasFile)
            {
                Label1.Text = "请选择图片文件";
                return;
            }
            if (judge())
            {
                int dishId = DAL.DishDAL.AddDish(dishes);
                UploadImage(dishId);
                //Response.Write("<Script>alert('添加成功!')</Script>");
                Utility.JavaScript.Alert("添加成功!", this);
                txtDishName.Text = "";
                txtUnitPrice.Text = "";
                Label1.Text = "";
            }
            else
            {
                Label1.Text = "图片格式不正确";
                return;
            }
        }

        private void UploadImage(int dishId)
        {
            //double filelenght = fulImage.FileContent.Length / (1024 * 1024);
            //if(filelenght>2.0)
            //{
            //    Label1.Text = "文件不能超过2MB";
            //    return;
            //}
            string fileName = fulImage.FileName;
            //if(fileName.Substring(fileName.LastIndexOf(".")).ToLower()!=".png")
            //{
            //    Label1.Text = "图片格式必须是.png";
            //    return;
            //}
            fileName = dishId + ".png";
            try
            {
                string path = Server.MapPath("~/Images/dish/")+ fileName;
                fulImage.SaveAs(path);
                Label1.Text = "图片上传成功";
            }
            catch (Exception e)
            {
                Label1.Text = "图片上传失败"+e.Message;
                //throw;
            }          
        }
        private bool judge()
        {
            double filelenght = fulImage.FileContent.Length / (1024 * 1024);
            if (filelenght > 2.0)
            {
                Label1.Text = "文件不能超过2MB";
                return false;
            }
            string fileName = fulImage.FileName;
            if (fileName.Substring(fileName.LastIndexOf(".")).ToLower() != ".png")
            {
                Label1.Text = "图片格式必须是.png";
                return false;
            }
            return true;
        }

        protected void btnPublish_Command(object sender, CommandEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtDishName.Text.Trim().Length == 0)
            {
                Label1.Text = "请输入菜品名";
                return;
            }
            if (txtUnitPrice.Text.Trim().Length == 0)
            {
                Label1.Text = "请输入菜品价格";
                return;
            }
            if (ddlCategory.SelectedIndex == -1)
            {
                Label1.Text = "请选择菜品分类";
                return;
            }
            Dish dishes = new Dish();
            dishes.DishName = txtDishName.Text;
            dishes.UnitPrice = Convert.ToInt32(txtUnitPrice.Text);
            dishes.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            dishes.DishId = Convert.ToInt32(Request.QueryString["DishId"]);
            if (!fulImage.HasFile)
            {
                //Label1.Text = "请选择图片文件";

                DAL.DishDAL.Change_Dish(dishes);
                Utility.JavaScript.Alert("修改成功!", this);
                return;
            }
            if (judge())
            {               
                    int dishId = DAL.DishDAL.AddDish(dishes);
                    UploadImage(dishId);
                    Utility.JavaScript.Alert("修改成功!", this);
                    txtDishName.Text = "";
                    txtUnitPrice.Text = "";
                    Label1.Text = "";
                    DAL.DishDAL.DeleteDish(dishes.DishId);                            
            }
            else
            {
                Label1.Text = "图片格式不正确";
                return;
            }
        }
    }
}