<%@ Page Title="" Language="C#" MasterPageFile="~/HotelWeb/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="DishesManager.aspx.cs" Inherits="HotelWeb.Admin.DishesManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Styles/Dishes.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div id="dishcategory">
        菜品分类：<asp:DropDownList ID="ddlCategory" runat="server" CssClass="btncss">
        </asp:DropDownList>
        &nbsp;<asp:Button ID="btnQuery" CssClass="btncss" runat="server" Text="提交查询" 
            onclick="btnQuery_Click"  />
    </div>
    <div id="dishlistdiv">
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                 <div class="dishlist-item">
                    <div class="dishlist-img">
                        <img src='<%#Eval("DishId","/Images/dish/{0}.png")%>' alt="" />
                    </div>
                    <div class="dishlist-txt">
                        菜品名称：<%#Eval("DishName")%></div>
                    <div class="dishlist-txt">
                        菜品分类：<%#Eval("CategoryName")%></div>
                    <div class="dishlist-txt">
                        菜品价格：￥<%#Eval("UnitPrice")%></div>
                    <div class="dishlist-txt">
                        <a href='/HotelWeb/Admin/Dishes/DishesPublish.aspx?Operation=1&dishId=<%#Eval("DishId")%>'>修改</a>&nbsp;&nbsp;
                        <%--<a href="#">删除</a>--%>
                        <asp:LinkButton ID="lbtnDel" runat="server" CommandArgument='<%#Eval("DishId")%>' OnClientClick='return confirm("确认删除?")' OnClick="lbtnDel_Click">删除</asp:LinkButton>
                    </div>
                </div>                
            </ItemTemplate>
        </asp:Repeater>        
    </div>
    <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
</asp:Content>
