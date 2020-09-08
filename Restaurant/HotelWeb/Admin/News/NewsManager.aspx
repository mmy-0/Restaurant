<%@ Page Title="" Language="C#" MasterPageFile="~/HotelWeb/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="NewsManager.aspx.cs" Inherits="HotelWeb.Admin.NewsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AdminCss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="itemdiv">
        <div class="newsitem-title-1">
            发布时间</div>
        <div class="newsitem-title-2">
            新闻标题</div>
        <div class="newsitem-title-2">
            新闻分类</div>
        <div class="newsitem-title-3" style="width: 110px;">
            操作</div>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <div class="newsitem-title-1">
                    <%#Eval("PublishTime","{0:yyyy-MM-dd}") %>
                </div>
                <div class="newsitem-title-2">
                    <a href='/HotelWeb/CompanyNews/NewsDetail.aspx?newsId=<%#Eval("NewsId") %>' target="_blank"><%#Eval("NewsTitle") %></a>
                </div>
                <div class="newsitem-title-2">
                    <%#Eval("CategoryName") %>
                </div>
                <div class="newsitem-title-3" style="width: 110px;">
                    <a href='NewsPublish.aspx?Operation=1&newsId=<%#Eval("NewsId") %>'>修改</a> 
                    <asp:LinkButton ID="lbtnDel" runat="server" OnClick="lbtn_Click" 
                    OnClientClick="return confirm('确认删除?')" 
                    CommandArgument='<%#Eval("NewsId") %>'>删除</asp:LinkButton>
                </div>       
            </ItemTemplate>
        </asp:Repeater>
        
    </div>
    <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
</asp:Content>
