<%@ Page Title="" Language="C#" MasterPageFile="~/HotelWeb/MP_Dishes.Master" AutoEventWireup="true"
    CodeBehind="DishesShow.aspx.cs" Inherits="HotelWeb.CompanyDishes.DishesShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Styles/Dishes.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <div id="dishitem">
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <div class="ditem">
                    <div class="dimgdiv">
                        <img src='<%#Eval("DishId","../../Images/dish/{0}.png") %>' />
                    </div>
                    <div class="dishname">
                       <%#Eval("DishName") %>&nbsp;￥<%#Eval("UnitPrice") %>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
