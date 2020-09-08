<%@ Page Title="" Language="C#" MasterPageFile="~/HotelWeb/MP_Info.Master" AutoEventWireup="true" CodeBehind="RecruitmentDetail.aspx.cs" Inherits="HotelWeb.CompanyInfo.RecruitmentDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Styles/Rec.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="item" style="margin-top: 20px;">
        <div class="itemtitle">
            职位名称：
        </div>
        <div class="itemcontent">
            <asp:Literal ID="ltaPostName" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="item">        
        <div class="itemtitle">
            职位类型：
        </div>
        <div class="itemcontent">
            <asp:Literal ID="ltaPostType" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="item">
        <div class="itemtitle">
            工作经验：
        </div>
        <div class="itemcontent">
            <asp:Literal ID="ltaExp" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="item">
        <div class="itemtitle">
            学历要求：
        </div>
        <div class="itemcontent">
             <asp:Literal ID="ltaEduBac" runat="server"></asp:Literal>
        </div>
    </div> 
    <div class="item">
        <div class="itemtitle">
            招聘人数：
        </div>
        <div class="itemcontent">
              <asp:Literal ID="ltaRecCount" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="item">
        <div class="itemtitle">
            发布时间：
        </div>
        <div class="itemcontent">
             <asp:Literal ID="ltaPublisTime" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="item">
        <div class="itemtitle">
            职位描述：
        </div>
        <div class="itemcontent">
        </div>
    </div>
    <div class="positiondesc">
         <asp:Literal ID="ltaDesc" runat="server"></asp:Literal>
    </div>
    <div class="item">
        <div class="itemtitle">
            招聘要求：
        </div>
        <div class="itemcontent">
        </div>
    </div>
    <div class="positiondesc">
         <asp:Literal ID="ltaRequire" runat="server"></asp:Literal>
    </div>
    <div class="item">
        <div class="itemtitle">
            联 系 人：
        </div>
        <div class="itemcontent">
             <asp:Literal ID="ltamManager" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="item">
        <div class="itemtitle">
            联系电话：
        </div>
        <div class="itemcontent">
       <asp:Literal ID="ltaPhone" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="item">
        <div class="itemtitle">
            电子邮件：
        </div>
        <div class="itemcontent">
             <asp:Literal ID="ltaEmail" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>

