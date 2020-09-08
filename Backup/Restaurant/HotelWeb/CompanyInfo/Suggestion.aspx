<%@ Page Title="" Language="C#" MasterPageFile="~/HotelWeb/MP_Info.Master" AutoEventWireup="true"
    CodeBehind="Suggestion.aspx.cs" Inherits="HotelWeb.CompanyInfo.Suggestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/Dishes.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="cdiv">
        <div class="item">
            <div class="itemtitle">
                客户姓名：
            </div>
            <div class="itemcontent">
                <asp:TextBox ID="txtCustomerName" CssClass="txt" runat="server"></asp:TextBox><span>&nbsp;*</span>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                您的消费情况：
            </div>
            <div class="itemcontent">
                <asp:TextBox ID="txtConsumeDesc" CssClass="txt" runat="server"></asp:TextBox><span>&nbsp;*</span>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                联系电话：
            </div>
            <div class="itemcontent">
                <asp:TextBox ID="txtPhoneNumber" CssClass="txt" runat="server"></asp:TextBox><span>&nbsp;*</span>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                电子邮件：
            </div>
            <div class="itemcontent">
                <asp:TextBox ID="txtEmail" CssClass="txt" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                投诉建议：
            </div>
            <div class="itemcontent">
                <asp:TextBox ID="txtSuggestion" CssClass="txt" runat="server" Height="50px" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                验证码：
            </div>
            <div class="itemcontent">
                <asp:TextBox ID="txtValidateCode" CssClass="txt" runat="server" Width="50px"></asp:TextBox><span>&nbsp;*
                    <asp:Image ID="Image1" ImageUrl="~/HotelWeb/Handlers/ValidateCode.ashx" runat="server" /></span>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
            </div>
            <div class="itemcontent">
                <asp:Button ID="btnSubmit" CssClass="btncss" runat="server" Text="提交投诉" OnClick="btnSubmit_Click" />
                <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</asp:Content>
