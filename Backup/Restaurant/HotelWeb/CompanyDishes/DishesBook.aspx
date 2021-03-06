﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HotelWeb/MP_Dishes.Master" AutoEventWireup="true" CodeBehind="DishesBook.aspx.cs" Inherits="Restaurant.HotelWeb.CompanyDishes.DishesBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/Dishes.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>    
    <script src="../../Scripts/validation-min.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
 <div class="cdiv">
        <form name="mainForm" method="post" action="" id="mainForm" runat="server">
        <div class="item">
            <div class="itemtitle">
                酒店名称：
            </div>
            <div class="itemcontent">
                <select name="ddlHotelName">
                    <option value="天津南开店">天津南开店</option>
                    <option value="天津和平店">天津和平店</option>
                    <option value="北京朝阳店">北京朝阳店</option>
                </select>
                <span>&nbsp;*</span>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                您的消费时间：
            </div>
            <div class="itemcontent">
                <input type="text" name="txtConsumeTime" class="txt" onclick="WdatePicker()" />
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                您的消费人数：
            </div>
            <div class="itemcontent">
                <input type="text" name="txtPersons" class="txt" />
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                选择包间类型：
            </div>
            <div class="itemcontent">
                <select name="ddlRoomType">
                    <option value="包间">包间</option>
                    <option value="散座">散座</option>
                </select>
                <span>&nbsp;*</span>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                预订人姓名：
            </div>
            <div class="itemcontent">
                <input type="text" name="txtCustomerName" class="txt" />
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                手机号码：
            </div>
            <div class="itemcontent">
                <input type="text" name="txtPhoneNumber" class="txt" />
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                电子邮件：
            </div>
            <div class="itemcontent">
                <input type="text" name="txtEmail" class="txt" />
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                备注事项：
            </div>
            <div class="itemcontent">
                <textarea class="txt" cols="3" style="height: 70px;" name="txtComment">
            </textarea>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                验证码：
            </div>
            <div class="itemcontent">
                <input type="text" class="txt" name="txtValidateCode" style="width: 50px;" />
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
            </div>
            <div class="itemcontent">
                <img id="vCodeimg" src="../Handlers/ValidateCode.ashx" />
                
                <a href="#" id="refreshcode">&nbsp;换一张</a>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
            </div>
            <div class="itemcontent">
                <input type="button" class="btncss" id="submitMsg" value="马上预定" />
            </div>
        </div>
        </form>
    </div>
    <div id="popdiv">
        <div id="infodiv">
            <div id="loadingdiv">
                <img src="/Styles/Images/onloading.gif" /></div>
            <div class="loadinfo">
                正在提交数据，请耐心等待......</div>
        </div>
        <div id="errordiv" style="display: none; color: #FCD24B; float: left;">
            服务器超时，请稍后再试！[关闭]</div>
        <div id="regsuccess" style="float: left; display: none;">
            提交成功！&nbsp;<b>在<span id="seconds">3</span></b>&nbsp;秒后自动跳转......</div>
    </div>
    <div id="zzc">
    </div>
    <script type="text/javascript">
        //注册信息验证
        $("#mainForm").valid([
            { name: "txtConsumeTime", isNull: "消费时间不能为空!", onFocus: "请选择您的消费时间！" },
            { name: "txtPersons", type: "number", error: "消费人数必须是整数！", isNull: "请填写消费人数！", onFocus: "请填写正确的消费人数！" },
            { name: "txtCustomerName", isNull: "预订人姓名不能为空！", onFocus: "请填写预定人姓名！" },
            { name: "txtPhoneNumber", type: "mobile", error: "手机号码格式不正确！", isNull: "请填写您的常用手机号！", onFocus: "请填写您的常用手机号！" },
            { name: "txtValidateCode", isNull: "验证码必须填写!", onFocus: "请输入下面的验证码" },
            { name: "txtValidateCode", type: "ajax", error: "验证码不正确！", other: { url: "../Handlers/CheckData.ashx?type=checkcode"} }
            ], true);
        //刷新验证码
        $(function () {
            $("#refreshcode").click(function () {
                $("#txtVCode").val("");
                $("#vCodeimg").attr("src", function () {
                    return "../Handlers/ValidateCode.ashx?a=" + new Date().getMilliseconds();
                });
            });
        });
        //提交按钮
        $(function () {
            $("#submitMsg").click(function () {
                $("#mainForm").submit();
            });
        });
        //提交注册信息
        function ajaxForm() {
            $.ajax({
                type: "POST", //设置请求发送的方式
                timeout: 30000, //设置服务器请求超时时间
                url: "../Handlers/DishBook.ashx", //提交的地址
                data: $("#mainForm").serialize(), //序列化表单元素值
                beforeSend: function () {//表单提交前执行的函数
                    $("#errordiv").text("服务器超时，请稍后再试！[关闭]");
                    $("#errordiv").hide();
                    $("#zzc").show();
                    popupDiv("popdiv");
                },
                error: function () {//提交发生错误的时候执行的函数               
                    $("#infodiv").hide();
                    $("#errordiv").show();
                },
                success: function (data) {//提交成功的时候执行的函数
                    if (data == "success") {
                        $("#infodiv").hide();
                        $("#regsuccess").show();
                        setInterval(MyTimer, 1000)
                    } else {
                        $("#infodiv").hide();
                        $("#errordiv").text(data);
                        $("#errordiv").show();
                    }
                }
            });
        }
        //弹出窗口
        function popupDiv(div_id) {
            var div_obj = $("#" + div_id);
            //窗口宽度,高度
            var winWidth = $(window).width();
            var winHeight = $(window).height();
            //弹出的div的宽度,高度
            var popHeight = div_obj.height();
            var popWidth = div_obj.width();
            div_obj.animate({ opacity: "show", left: (winWidth - popWidth) / 2,
                top: (winHeight - popHeight) / 2 + 300, width: popWidth, height: popHeight
            }, 300);
            $("#infodiv").show();
        }
        $(function () {
            $("#popdiv").click(function () {
                $("#popdiv").animate({ opacity: "hide" }, 300);
                $("#zzc").css("display", "none");
            });
        });
        $(function () {
            $("#errordiv").mouseover(function () {
                $("#popdiv").animate({ opacity: "hide" }, 300);
                $("#zzc").css("display", "none");
            });
        });
        //注册成功后自动跳转定时器
        var sec = 3;
        function MyTimer() {
            if (sec == 0) {
                location = "../Default.aspx";
            } else {
                sec = sec - 1;
                $("#seconds").text(sec);
            }
        }
    </script>
</asp:Content>
