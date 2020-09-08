using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Drawing;

namespace Restaurant.HotelWeb.Handlers
{
    /// <summary>
    /// ValidateCode 的摘要说明
    /// </summary>
    public class ValidateCode : IHttpHandler, IRequiresSessionState
    {
        //请求处理
        public void ProcessRequest(HttpContext context)
        {
            //如果用户直接请求该Handler则拒绝
            if (context.Request.UrlReferrer == null)
            {
                context.Response.Write("请求错误！拒绝访问！");
                return;
            }
            //获取请求来路的完整URL
            string url = context.Request.UrlReferrer.AbsoluteUri;
            if (!url.Contains("/CompanyDishes/DishesBook.aspx") &&
                 !url.Contains("/CompanyInfo/Suggestion.aspx"))
            {
                context.Response.Write("请求错误！拒绝访问！");
                return;
            }
            //将验证码保存到Session中
            context.Session["CheckCode"] = CreateCode();
            //创建并输出带验证码的图片
            CreateImages(context.Session["CheckCode"].ToString(), context);
        }

        //生成四位数字验证码
        private string CreateCode()
        {
            Random rand = new Random();
            int vCode = 0;
            while (true)
            {
                vCode = rand.Next(9999);
                if (vCode.ToString().Length == 4) break;
            }
            return vCode.ToString();
        }
        //创建带验证码的图片
        private void CreateImages(string checkCode, HttpContext context)
        {
            //【1】创建一个指定大小的空白图片
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(55, 23); //创建一个空白图片
            Graphics grap = Graphics.FromImage(image); //创建GDI+绘图的核心对象（该对象提供各种绘图的方法和属性）
            grap.Clear(Color.White); //将整个绘图面变成白色

            //【2】随机输出噪点
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(image.Width);
                int y = rand.Next(image.Height);
                grap.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
            }

            //输出不同字体和颜色的验证码字符
            Color[] c = { Color.Black, Color.Red, 
                            Color.DarkBlue, Color.Green,
                            Color.Orange, Color.Brown, Color.DarkCyan, 
                            Color.Purple }; //定义颜色数组          
            string[] font = { "Verdana", "Microsoft Sans Serif", 
                                "Comic Sans MS", "Arial", "宋体" };  //定义字体数组          
            for (int i = 0; i < checkCode.Length; i++)
            {
                int cindex = rand.Next(7);
                int findex = rand.Next(5);
                Font f = new System.Drawing.Font(font[findex], 12, System.Drawing.FontStyle.Bold);
                Brush b = new System.Drawing.SolidBrush(c[cindex]);
                int ii = 4;
                if ((i + 1) % 2 == 0)
                {
                    ii = 2;
                }
                grap.DrawString(checkCode.Substring(i, 1), f, b, 3 + (i * 12), ii);
            }

            //【3】给图片画一个边框
            grap.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);

            //【4】使用内存流输出到浏览器
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            context.Response.ClearContent();
            context.Response.ContentType = "image/gif";
            context.Response.BinaryWrite(ms.ToArray());

            //【5】资源释放
            grap.Dispose();
            image.Dispose();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}