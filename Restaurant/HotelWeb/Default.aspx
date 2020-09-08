<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HotelWeb.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>好运来酒店</title>
    <link href="../Styles/MainPage.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/Default.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript" type="text/javascript">
        var NowFrame = 1;
        var MaxFrame = 2;
        function scroll1(d1) {
            if (Number(d1)) {
                NowFrame = d1;                //设当前显示图片
            }
            for (var i = 1; i < (MaxFrame + 1); i++) {
                if (NowFrame == i) {
                    document.getElementById(NowFrame).style.display = 'block';   //当前显示图片
                }
                else {
                    document.getElementById(i).style.display = 'none';
                }
            }
            {
                if (NowFrame == MaxFrame)   //设置下一个显示的图片
                    NowFrame = 1;
                else
                    NowFrame++;
            }
            theTimer = setTimeout('scroll1()', 3000);   //设置定时器，显示下一张图片
        }			
    </script>
</head>
<body onload="scroll1(1)">
    <form id="form1" runat="server">
    <div id="container">
        <div id="top">
        </div>
        <div id="nav">
            <div id="navlink">
                <ul>
                    <li><a href="Default.aspx">网站首页</a></li>
                    <li><a href="CompanyInfo/CompanyDesc.aspx">公司介绍</a></li>
                    <li><a href="CompanyNews/NewsList.aspx">新闻动态</a></li>
                    <li><a href="CompanyDishes/DishesShow.aspx">美食展示</a></li>
                    <li><a href="CompanyDishes/Environment.aspx">餐厅环境</a></li>
                    <li><a href="CompanyDishes/DishesBook.aspx">在线预订</a></li>
                    <li><a href="CompanyInfo/JoinUs.aspx">加盟连锁</a></li>
                    <li><a href="CompanyInfo/Suggestion.aspx">投诉建议</a></li>
                    <li><a href="CompanyInfo/RecruitmentList.aspx">招聘信息</a></li>
                    <li><a class="navLast" href="CompanyInfo/AboutUs.aspx">关于我们</a></li>
                </ul>
            </div>
        </div>
        <div id="topflashDiv">
            <div id="topflashbg">
                <img src="../Images/topflash1.jpg" id="1" alt="" style="display: none;" />
                <img src="../Images/topflash2.jpg" id="2" alt="" style="display: none;" />
            </div>
        </div>
        <div id="content">
            <div id="leftDiv">
                <div class="lefttitle">
                    餐厅简介
                </div>
                <div id="leftImage1">
                    <img src="../Images/leftimage1.jpg" />
                </div>
                <div id="leftText1">
                    杭州市某某餐饮连锁公司，融合现代快餐理念，开创了更符合国人膳食结构与饮食习惯的快速餐饮体系。以外卖+快速餐饮的新颖模式，引爆各地巨大市场，相继开发了活力早餐、拉面米线、馄饨水饺、商务简餐。
                </div>
                <div class="lefttitle">
                    最新新闻
                </div>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <div class="newslist">
                            <div class="newstitle">
                                <a href='CompanyNews/NewsDetail.aspx?newsId=<%#Eval("NewsId") %>'><%#Eval("NewsTitle") %> </a>
                            </div>
                            <div class="newsdate">
                                <%#Eval("PublishTime","{0:yyyy-MM-dd}")%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div id="rightDiv">
                <div id="righttitle1">
                </div>
                <div id="righttitle2">
                </div>
                <div id="rightrec">
                    <div class="recimage">
                        <img src="../Images/rec1.jpg" height="86px" width="111px" />
                    </div>
                    <div class="rectext">
                        柔嫩皮脆，味碟解腻。此菜关键在于味碟的调制，以往的味碟多是蒜泥味的，而本碟则是加了辣椒、葱末等，味道真的很怀旧又开胃。所以，一道常见的菜，只要在小细
                    </div>
                    <div class="recimage">
                        <img src="../Images/rec2.jpg" height="86px" width="111px" />
                    </div>
                    <div class="rectext">
                        特点：柔嫩皮脆，味碟解腻。此菜关键在于味碟的调制，以往的味碟多是蒜泥味的，而本碟则是加了辣椒、葱末等，味道真的很怀旧又开胃。所以，一道常见的菜，只要
                    </div>
                </div>
                <div id="resinver">
                    <img src="../Images/huanjing1.jpg" style="display: none;" id="div1" border="0">
                    <img src="../Images/huanjing2.jpg" style="display: none;" id="div2" border="0">
                    <img src="../Images/huanjing3.jpg" style="display: none;" id="div3" border="0">
                    <img src="../Images/huanjing4.jpg" style="display: none;" id="div4" border="0">
                </div>
                <%--   <div id="btnaDiv">
            <a class="buta" href="javascript:show(4)">4</a><a class="buta" href="javascript:show(3)">3</a><a
                class="buta" href="javascript:show(2)">2</a><a class="buta" href="javascript:show(1)">1</a>
        </div>--%>
                <div id="rightScorll">
                    <div class="zhaopaidiv">
                        <div class="zhaopai">
                            <img src="../Images/zhaopai1.jpg" height="90px" width="118px" />
                        </div>
                        <div class="zhaopainame">
                            招牌菜一</div>
                    </div>
                    <div class="zhaopaidiv">
                        <div class="zhaopai">
                            <img src="../Images/zhaopai2.jpg" height="90px" width="118px" />
                        </div>
                        <div class="zhaopainame">
                            招牌菜二</div>
                    </div>
                    <div class="zhaopaidiv">
                        <div class="zhaopai">
                            <img src="../Images/zhaopai3.jpg" height="90px" width="118px" />
                        </div>
                        <div class="zhaopainame">
                            招牌菜三</div>
                    </div>
                    <div class="zhaopaidiv">
                        <div class="zhaopai">
                            <img src="../Images/zhaopai4.jpg" height="90px" width="118px" />
                        </div>
                        <div class="zhaopainame">
                            招牌菜四</div>
                    </div>
                </div>
            </div>
        </div>
        <div id="footer">
            <div id="footercontent">
                <ul>
                    <li><a href="#">关于我们</a></li>
                    <li><a href="#">联系方式</a></li>
                    <li><a href="#">加盟连锁</a></li>
                    <li><a href="#">投诉建议</a></li>
                    <li><a href="#">友情链接</a></li>
                </ul>
            </div>
            <div id="bq">
                版权所有 Copyright(C)2010-2020好运来酒店
            </div>
        </div>
        <div id="footerbottom">
        </div>
    </div>
    </form>
</body>
<script language="JavaScript" type="text/javascript">
    show();
    var NowFrame = 1;
    var MaxFrame = 4;
    function show(d1) {
        if (Number(d1)) {
            clearTimeout(theTimer);  //当触动按扭时，清除计时器
            NowFrame = d1;                //设当前显示图片
        }
        for (var i = 1; i < (MaxFrame + 1); i++) {
            if (i == NowFrame)
                document.getElementById('div' + NowFrame).style.display = '';   //当前图片示
            else
                document.getElementById('div' + i).style.display = 'none';    //隐藏其他图片层
        }
        {
            if (NowFrame == MaxFrame)   //设置下一个显示的图片
                NowFrame = 1;
            else
                NowFrame++;
        }
        theTimer = setTimeout('show()', 3000);   //设置定时器，显示下一张图片
    }
				
</script>
</html>
