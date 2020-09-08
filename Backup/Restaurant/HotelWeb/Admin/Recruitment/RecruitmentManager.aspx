<%@ Page Title="" Language="C#" MasterPageFile="~/HotelWeb/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="RecruitmentManager.aspx.cs" Inherits="HotelWeb.Admin.RecruitmentManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AdminCss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="itemdiv">
        <div class="bitem-title">
            职位名称</div>
        <div class="bitem-title">
            职位类型</div>
        <div class="bitem-title">
            工作经验</div>
        <div class="bitem-title">
            学历要求</div>
        <div class="bitem-title">
            招聘人数</div>
        <div class="bitem-title">
            工作地点</div>
        <div class="bitem-title" style="width: 120px;">
            操作</div>
        <asp:Repeater ID="rplList" runat="server">
            <ItemTemplate>
                <div class="bitem">
                    <%#Eval("PostName")%></div>
                <div class="bitem">
                    <%#Eval("PostType")%></div>
                <div class="bitem">
                    <%#Eval("Experience")%></div>
                <div class="bitem">
                    <%#Eval("EduBackground")%></div>
                <div class="bitem">
                    <%#Eval("RequireCount")%></div>
                <div class="bitem">
                    <%#Eval("PostPlace")%></div>
                <div class="bitem" style="width: 120px;">
                    <a href='RecruitmentModify.aspx?PostId=<%#Eval("PostId")%>' target="_blank">修改</a>                    
                    <asp:LinkButton ID="lbtn" runat="server" OnClientClick="return confirm('确认删除?')" CommandArgument='<%#Eval("PostId")%>' OnClick="lbtn_Click">删除</asp:LinkButton>
                </div>
            </ItemTemplate>
        </asp:Repeater>      
    </div>
    <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
</asp:Content>
