<%@ Page Title="" Language="C#" MasterPageFile="~/HotelWeb/MP_News.Master" AutoEventWireup="true"
    CodeBehind="NewsList.aspx.cs" Inherits="HotelWeb.CompanyNews.NewsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/News.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div id="nlistdiv">
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <div class="newsItem">
                    <div class="newtitle">
                        <a href='NewsDetail.aspx?newsId=<%#Eval("NewsId") %>'><%#Eval("NewsTitle") %></a></div>
                    <div class="newsdate">
                      <%#Eval("PublishTime","{0:yyyy-MM-dd}") %></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
