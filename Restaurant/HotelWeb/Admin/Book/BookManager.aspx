<%@ Page Title="" Language="C#" MasterPageFile="~/HotelWeb/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="BookManager.aspx.cs" Inherits="HotelWeb.Admin.BookManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AdminCss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="itemdiv">
        <div class="book-title">
            酒店名称</div>
        <div class="book-title">
            消费时间</div>
        <div class="book-title">
            消费人数</div>
        <div class="book-title">
            包间类型</div>
        <div class="book-title">
            客户姓名</div>
        <div class="book-title">
            联系电话</div>
        <div class="book-title" style="width: 152px;">
            操作</div>
        
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <div class="book-title">
                    <%#Eval("HotelName")%></div>
                <div class="book-title">
                    <%#Eval("ConsumeTime","{0:yyyy-MM-dd hh:mm}")%></div>
                <div class="book-title">
                    <%#Eval("ConsumePersons")%>人</div>
                <div class="book-title">
                    <%#Eval("RoomType")%></div>
                <div class="book-title">
                    <%#Eval("CustomerName")%></div>
                <div class="book-title">
                    <%#Eval("CustomerPhone")%></div>
                <div class="book-title" style="width: 152px;">
                    <asp:LinkButton ID="lbtnPass" runat="server" CommandArgument='<%#Eval("BookId")%>' CommandName="1" OnClick="lbtnOperation">通过</asp:LinkButton>    
                    <asp:LinkButton ID="lbtnCancel" runat="server" CommandArgument='<%#Eval("BookId")%>' CommandName="-1" OnClick="lbtnOperation">撤销</asp:LinkButton> 
                    <asp:LinkButton ID="lbtnClose" runat="server" CommandArgument='<%#Eval("BookId")%>' CommandName="2" OnClick="lbtnOperation">关闭</asp:LinkButton> 
                </div>
                
                <div class="bookdetail">
                    <div class="book-Time">
                        预定时间： <%#Eval("BookTime", "{0:yyyy-MM-dd hh:mm}")%></div>
                    <div class="book-Time">
                        电子邮件：<%#Eval("CustomerEmail")%></div>
                    <div class="book-Time">
                        预定状态：<%#Eval("OrderStatus")%>&nbsp;（0：未审核&nbsp;1：审核通过）</div>
                    <div class="book-comment">
                        预定其他要求：<%#Eval("Comments")%></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>     
       
        </div>
    <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
   
</asp:Content>
