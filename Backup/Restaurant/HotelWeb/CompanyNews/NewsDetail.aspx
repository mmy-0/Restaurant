<%@ Page Title="" Language="C#" MasterPageFile="~/HotelWeb/MP_News.master" AutoEventWireup="true"
    CodeBehind="NewsDetail.aspx.cs" Inherits="HotelWeb.CompanyNews.NewsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/News.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
  <div class="newstitle">
      <asp:Literal ID="ltaNewsTitle" runat="server"></asp:Literal>
    </div>
    <div class="newsdesc">
        发布时间：<asp:Literal ID="ltaPublishTime" runat="server"></asp:Literal>&nbsp;&nbsp; 文字：【<a href="javascript:fontZoom(16)">大</a>】【<a
            href="javascript:fontZoom(14)">中</a>】【<a href="javascript:fontZoom(12)">小</a>】
    </div>
    <div class="newscontent">
        <asp:Literal ID="ltaNewsContents" runat="server"></asp:Literal>
    </div>
</asp:Content>
