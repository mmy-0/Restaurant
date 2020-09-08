<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="HotelWeb.Admin.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>后台管理系统</title>
    <link href="Styles/AdminCss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <div id="top">
        </div>
        <div id="content">
            <div id="loginimg">
                <img src="Styles/Images/loginimg.jpg" />
            </div>
            <div id="logindiv">
                <div id="ltitle">
                    管理员登录</div>
                <div class="litem">
                    登录账号：<asp:TextBox ID="txtLoginId" runat="server" CssClass="txt"></asp:TextBox></div>
                <div class="litem">
                    登录密码：<asp:TextBox ID="txtLoginPwd" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox></div>
           <div class="litem">
               <asp:Button ID="btnlogin" runat="server" Text="马上登录" 
                   CssClass="btncss" onclick="btnlogin_Click" />
               <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
                </div>
                
           </div>
        </div>
        <div id="footer">
            <div id="bq">
                版权所有 Copyright(C)2010-2020 好运来酒店
            </div>
        </div>
    </div>
    </form>
</body>
</html>
