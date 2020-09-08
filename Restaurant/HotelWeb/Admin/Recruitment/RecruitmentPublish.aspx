<%@ Page Title="" Language="C#" MasterPageFile="~/HotelWeb/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="RecruitmentPublish.aspx.cs" Inherits="HotelWeb.Admin.RecruitmentPublish" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AdminCss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="txtContentdiv">
        <div class="txtItemdiv">
            职位名称：
            <asp:TextBox ID="txtPostName" class="txtInput" runat="server"></asp:TextBox>
            职位类型：
            <asp:DropDownList ID="ddlPostType" runat="server">
                <asp:ListItem Value="全职">全职</asp:ListItem>
                <asp:ListItem Value="兼职">兼职</asp:ListItem>
            </asp:DropDownList>
            工作经验：
            <asp:DropDownList ID="ddlwork" runat="server">
                <asp:ListItem Value="1年">1年</asp:ListItem>
                <asp:ListItem Value="2年">2年</asp:ListItem>
                <asp:ListItem Value="3年">3年</asp:ListItem>
                <asp:ListItem Value="4年">4年</asp:ListItem>
                <asp:ListItem Value="5年">5年</asp:ListItem>
            </asp:DropDownList>
            学历要求：
            <asp:DropDownList ID="ddlEducation" runat="server">
                <asp:ListItem Value="本科">本科</asp:ListItem>
                <asp:ListItem Value="硕士">硕士</asp:ListItem>
                <asp:ListItem Value="专科">专科</asp:ListItem>
                <asp:ListItem Value="高中">高中</asp:ListItem>
            </asp:DropDownList>
            招聘人数：
            <asp:TextBox ID="txtCount" Width="50px" class="txtInput" runat="server"></asp:TextBox>
            工作地点：
            <asp:TextBox ID="txtPlace" Width="50px" class="txtInput" runat="server"></asp:TextBox>
        </div>
        <div class="txtItemdiv">
            职位描述：</div>
        <div class="txtItemdiv">
            <textarea id="txtDesc" cols="100" rows="8" class="txtInput" style="width: 768px;
                height: 100px;" runat="server"></textarea>
        </div>
        <div class="txtItemdiv">
            具体要求：</div>
        <div class="txtItemdiv">
            <textarea id="txtRequire" cols="100" class="txtInput" rows="8" style="width: 768px;
                height: 100px;" runat="server"></textarea>
        </div>
        <div class="txtItemdiv">
            联系人：
            <asp:TextBox ID="txtManager" class="txtInput" runat="server"></asp:TextBox>
            电话：<asp:TextBox ID="txtPhone" class="txtInput" runat="server"></asp:TextBox>
            电子邮件：<asp:TextBox ID="txtEmail" class="txtInput" runat="server"></asp:TextBox>
        </div>
        <div class="txtItemdiv">
            <asp:Button ID="btnPublish" CssClass="btncss" runat="server" Text="立即发布" 
                onclick="btnPublish_Click" />
            <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
