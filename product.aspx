<%@ Page Title="" Language="C#" MasterPageFile="~/mar.master" AutoEventWireup="true"
    CodeFile="product.aspx.cs" Inherits="product" %>
    <%@ Register Src="~/friends.ascx" TagName="leff" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="js/jquery.js" type="text/javascript"></script>
    <link href="css/produt.css" rel="stylesheet" type="text/css" />
    <div class="clear">
    </div>
    <div class="container" style="margin-top: 1px;">

        <script type="text/javascript"><!--
            var focus_width = 948
            var focus_height = 257
            var text_height = 0
            var swf_height = focus_height + text_height
            var pics = '<%=pics %>'
            var links = '<%=links %>'
            var texts = ''
            document.write('<object ID="focus_flash" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="' + focus_width + '" height="' + swf_height + '">');
            document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="swf/headline.swf"><param name="quality" value="high"><param name="bgcolor" value="#FFFFFF">');
            document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
            document.write('<param name="FlashVars" value="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '">');
            document.write('<embed ID="focus_flash" src="swf/headline.swf" wmode="opaque" FlashVars="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '" menu="false" bgcolor="#C5C5C5" quality="high" width="' + focus_width + '" height="' + swf_height + '" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />'); document.write('</object>');
 //--></script>

    </div>
    <!--head wall-->
    <div class="container" style="background: url(images/socend.gif) repeat-x;">
        <!--左边-->
        <div class="mainleft_1">
             <DIV class=left-title ><img src="images/socend_p.gif" /></DIV>
            <div id="mainleft">
                <div id="PARENT">
                    <ul id="nav">
                        <%=stype2()%>
                    </ul>
                </div>

<script type="text/javascript">
    function protype_func(liIndex) {
        
        for (var i = 0; i < 20; i++) {
            $(".btype" + i + "").find("ul").css("display", "none");
        }
        $(".btype" + liIndex + "").find("ul").css("display", "block");
    }


</script>

            <%--    <script type="text/javascript"><!--
                    var LastLeftID = "";
                    function menuFix() {
                        var obj = document.getElementById("nav").getElementsByTagName("li");

                        for (var i = 0; i < obj.length; i++) {
                            obj[i].onmouseover = function() {
                                this.className += (this.className.length > 0 ? " " : "") + "sfhover";
                            }
                            obj[i].onMouseDown = function() {
                                this.className += (this.className.length > 0 ? " " : "") + "sfhover";
                            }
                            obj[i].onMouseUp = function() {
                                this.className += (this.className.length > 0 ? " " : "") + "sfhover";
                            }
                            obj[i].onmouseout = function() {
                                this.className = this.className.replace(new RegExp("( ?|^)sfhover\\b"), "");
                            }
                        }
                    }
                    function DoMenu(emid) {
                        var obj = document.getElementById(emid);
                        obj.className = (obj.className.toLowerCase() == "expanded" ? "collapsed" : "expanded");
                        if ((LastLeftID != "") && (emid != LastLeftID)) //关闭上一个Menu
                        {
                            document.getElementById(LastLeftID).className = "collapsed";
                        }
                        LastLeftID = emid;
                    }
                    function GetMenuID() {
                        var MenuID = "";
                        var _paramStr = new String(window.location.href);
                        var _sharpPos = _paramStr.indexOf("#");

                        if (_sharpPos >= 0 && _sharpPos < _paramStr.length - 1) {
                            _paramStr = _paramStr.substring(_sharpPos + 1, _paramStr.length);
                        }
                        else {
                            _paramStr = "";
                        }

                        if (_paramStr.length > 0) {
                            var _paramArr = _paramStr.split("&");
                            if (_paramArr.length > 0) {
                                var _paramKeyVal = _paramArr[0].split("=");
                                if (_paramKeyVal.length > 0) {
                                    MenuID = _paramKeyVal[1];
                                }
                            }
                            /*
                            if (_paramArr.length>0)
                            {
                            var _arr = new Array(_paramArr.length);
                            }
  
  //取所有#后面的，菜单只需用到Menu
  //for (var i = 0; i < _paramArr.length; i++)
                            {
                            var _paramKeyVal = _paramArr[i].split('=');
   
   if (_paramKeyVal.length>0)
                            {
                            _arr[_paramKeyVal[0]] = _paramKeyVal[1];
                            }  
                            }
                            */
                        }

                        if (MenuID != "") {
                            DoMenu(MenuID)
                        }
                    }
                    GetMenuID(); //*这两个function的顺序要注意一下，不然在Firefox里GetMenuID()不起效果
                    menuFix();
--></script>--%>

                <p>&nbsp;
                    </p>
                <div class="clear">
                </div>
                <div>
                    &nbsp;&nbsp;&nbsp;<img src="images/index_link2.gif" /></div>
                <div>
                    <form action="" method="post" name="sform">
                    <select name="" style="width: 195px; margin: 3px 13px; border: 1px solid #CCCCCC;" onchange="selchagegourl(this)">
                       <uc1:leff ID="leff1" runat=server />
                    </select>
                    </form>
                </div>
                 <div>&nbsp;&nbsp;<a href="contact.aspx?id=4"><img src="images/socend_contart.gif" /></a></div>
	   <div>&nbsp;&nbsp;<a href="message.aspx?id=4"><img src="images/socend_messges.gif"  /></a></div>
	   <div>&nbsp;&nbsp;<a href="contact.aspx?id=30"><img src="images/socend_zhaoping.gif"  /></a></div>
                <p>&nbsp;
                    </p>
            </div>
            <div>
                <img src="images/socend_bottom.gif" /></div>
        </div>
        <!--右边-->
        <div class="float_r">
            <div class="mainright_1">
                <div class="float_l "><img src="images/socend_p_2.gif" /></div>
                <div class="float_r ">
                    <img src="images/socend_p_r.gif" /></div>
                <div class="float_r  mainright_text ">
                    <a href="index.aspx">首页</a> > 产品展示<%=titleintro()%></div>
            </div>
            <div class="clear">
            </div>
            <div id="mainright" class="float_l">
                <%=Content%>
                    <div style="text-align:center; clear:left; vertical-align:bottom" class="page_list" ><%=getpage %></div>
            </div>
        </div>

        <script src="images/autodiv.js" type="text/javascript"></script>

    </div>
</asp:Content>
