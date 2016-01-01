<%@ Page Title="" Language="C#" MasterPageFile="~/mar.master" AutoEventWireup="true"
    CodeFile="index.aspx.cs" Inherits="index" %>


<%@ Register Src="~/friends.ascx" TagName="leff" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="swf/swfobject.js" type="text/javascript"></script>

    <script language="JavaScript" src="images/menu.js"></script>

    <div class="clear">
    </div>
    <div class="container">
        <div id="baner" style="background: #ffffff;">
            <div id="flashcontent">
            </div>

            <script type="text/javascript">
                var so = new SWFObject("swf/ht6.swf", "sotester", "948", "302", "0", "#FFFFFF");
                so.addParam("wmode", "transparent");
                so.write("flashcontent");
            </script>

        </div>
        <div class="clear">
        </div>
    </div>
    <div class="container" style="background: url(images/baner_bottom.gif) repeat-x;
        height: 12px;">
    </div>
    <div class="container">
        <div class="float_l">
            <img src="images/index_company.gif" /></div>
        <div class="index_box2_left">
            <div class="more">
                <img src="images/index_company_2.gif" border="0" usemap="#Map2" />
<map name="Map2" id="Map2"><area shape="rect" coords="201,4,247,28" href="aboutus.aspx?id=33" target="_blank" />
</map></div>
            <ul>
                <%=returnProLinks() %>
            </ul>
   <div>&nbsp;&nbsp;&nbsp;<img src="images/index_link2.gif" /></div>
   <div><form action="" method="post" name="sform">
			 <select name="" style="width:195px; margin:3px 13px; border:1px solid #CCCCCC; " onchange="selchagegourl(this)">
            	<uc1:leff ID="leff1" runat=server />
          </select>
			   </form></div>
       <div>&nbsp;&nbsp;<a href="contact.aspx?id=4"><img src="images/socend_contart.gif" /></a></div>
	   <div>&nbsp;&nbsp;<a href="message.aspx"><img src="images/socend_messges.gif"  /></a></div>
	   <div>&nbsp;&nbsp;<a href="contact.aspx?id=30"><img src="images/socend_zhaoping.gif"  /></a></div>
        </div>
        <div class="float_l">
            <img src="images/index_company_r.gif" /></div>
        <div class="index_box2_r" id="tab1">
            <div class="Menubox  menu">
                <ul>
                    <li id="one1" onMouseOver="setTab('one',1);">公司动态</li>
                    <li id="one2" onMouseOver="setTab('one',2);">行业新闻</li>
                    <li id="one3" onMouseOver="setTab('one',3);">技术支持</li>
                </ul>
            </div>
            <div class="menudiv">
                <dl id="con_one_1">
                    <%=news(42)%>
                    <!--<dd ><span class="float_r">2010-05-01</span>·<a href="#">商家或会员注册赢大奖</a></dd>-->
                    <dd style="border-bottom: none;">
                        <span class="float_r"><a href="news2.aspx?type=42">MORE »</a></span></dd>
                </dl>
                <dl id="con_one_2" style="display: none;">
                    <%=news(54)%>
                    <!--<dd ><span class="float_r">2010-05-01</span>·<a href="#">商家或会员注册赢大奖</a></dd>-->
                    <dd style="border-bottom: none;">
                        <span class="float_r"><a href="news2.aspx?type=54">MORE »</a></span></dd>
                </dl>
                <dl id="con_one_3" style="display: none;">
                    <%=news(55)%>
                    <!--<dd ><span class="float_r">2010-05-01</span>·<a href="#">商家或会员注册赢大奖</a></dd>-->
                    <dd style="border-bottom: none;">
                        <span class="float_r"><a href="cases.aspx?type=55">MORE »</a></span></dd>
                </dl>
            </div>

            <script type="text/javascript">

                function setTab(name, cursel) {
                    cursel_0 = cursel;
                    for (var i = 1; i <= links_len; i++) {
                        var menu = document.getElementById(name + i);
                        var menudiv = document.getElementById("con_" + name + "_" + i);
                        if (i == cursel) {
                            menu.className = "hover";
                            menudiv.style.display = "block";
                        }
                        else {
                            menu.className = "";
                            menudiv.style.display = "none";
                        }
                    }
                }
                function Next() {
                    cursel_0++;
                    if (cursel_0 > links_len) cursel_0 = 1
                    setTab(name_0, cursel_0);
                }
                var name_0 = 'one';
                var cursel_0 = 1;
                var ScrollTime = 3000; //循环周期（毫秒）
                var links_len, iIntervalId;
                onload = function() {
                    var links = document.getElementById("tab1").getElementsByTagName('li')
                    links_len = links.length;
                    for (var i = 0; i < links_len; i++) {
                        links[i].onclick = function() {
                            clearInterval(iIntervalId);
                            this.onmouseout = function() {
                                iIntervalId = setInterval(Next, ScrollTime);
                            }
                        }
                    }
                    document.getElementById("con_" + name_0 + "_" + links_len).parentNode.onmouseover = function() {
                        clearInterval(iIntervalId);
                        this.onmouseout = function() {
                            iIntervalId = setInterval(Next, ScrollTime); ;
                        }
                    }
                    setTab(name_0, cursel_0);
                    iIntervalId = setInterval(Next, ScrollTime);
                }
            </script>

            
        </div>
        <!--right-->
        <div class="index_box2_right">
        <div style=" background-image:url(images/index_company1.gif); background-position:bottom left; background-repeat:no-repeat; width:100%; 
             height:auto!important;  height:69px; min-height:69px;">
             <div class="more">
                <img src="images/index_chang3.gif" width="325" height="37" border="0" usemap="#Map3" />
<map name="Map3" id="Map3"><area shape="rect" coords="226,3,275,25" href="product.aspx" target="_blank" />
</map></div>
            <%=pro() %>
            </div>
        </div>
    </div>
</asp:Content>