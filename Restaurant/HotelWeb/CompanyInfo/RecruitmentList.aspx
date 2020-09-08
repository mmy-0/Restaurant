<%@ Page Title="" Language="C#" MasterPageFile="~/HotelWeb/MP_Info.Master" AutoEventWireup="true"
    CodeBehind="RecruitmentList.aspx.cs" Inherits="HotelWeb.CompanyInfo.RecruitmentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Styles/Rec.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="outdiv">
        <div class="titlediv">
            <div class="position">
                招聘职位</div>
            <div class="place">
                工作地点</div>
            <div class="needcount">
                招聘人数</div>
            <div class="detail">
                详情</div>
        </div>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <div class="itemdiv">
                    <div class="position">
                        <a href='RecruitmentDetail.aspx?PostId=<%#Eval("PostId") %>' target="_blank"><%#Eval("PostName") %></a></div>
                    <div class="place">
                        <%#Eval("PostPlace") %></div>
                    <div class="needcount">
                       <%#Eval("RequireCount") %></div>
                    <div class="detail">
                        <a href='RecruitmentDetail.aspx?PostId=<%#Eval("PostId") %>' target="_blank">详情</a></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
