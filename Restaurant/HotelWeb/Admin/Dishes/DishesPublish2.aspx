<%@ Page Title="" Language="C#" MasterPageFile="~/HotelWeb/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="DishesPublish2.aspx.cs" Inherits="HotelWebProject.Adminhyl.DishesPublish" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AdminCss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="txtContentdiv">
        <div class="txtItemdiv">
            菜品名称：<asp:TextBox ID="txtDishName" class="txtDish" runat="server"></asp:TextBox>&nbsp;&nbsp;价格：<asp:TextBox
                ID="txtUnitPrice" class="txtDish" runat="server"></asp:TextBox>
            &nbsp;&nbsp; 菜品分类：<asp:DropDownList ID="ddlCategory" runat="server">
            </asp:DropDownList>
        </div>
        <div class="txtItemdiv">
            菜品图片：</div>
        <div class="txtItemdiv">
            <asp:Image ID="dishImage" ImageUrl="~/Adminhyl/Styles/Images/default.png" CssClass="imgDish"
                runat="server" />
        </div>
        <div class="txtItemdiv">
            <asp:FileUpload ID="fulImage" runat="server" />
        </div>
        <div class="txtItemdiv">
            <asp:Button ID="btnPublish" CssClass="btncss" runat="server" Text="新增菜品" OnClick="btnPublish_Click" CommandName="aaa" OnCommand="btnPublish_Command" />
            <asp:Button ID="Button1" CssClass="btncss" runat="server" Text="修改菜品" CommandName="bbb" OnClick="Button1_Click" />
        </div>
        <asp:Label ID="Label1" runat="server" ForeColor="#ff0066"></asp:Label>
    </div>
</asp:Content>
