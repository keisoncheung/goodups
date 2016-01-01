<%@ Page Title="" Language="C#" MasterPageFile="~/mar.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" %>
    <%@ Register Src="~/friends.ascx" TagName="leff" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="clear"></div>
   <div class="container" style="margin-top:1px;">
    <SCRIPT type=text/javascript><!--        
        var focus_width=948
        var focus_height=257
        var text_height=0
        var swf_height = focus_height+text_height
        var pics = '<%=pics %>'
        var links = '<%=links %>'
        var texts=''
        document.write('<object ID="focus_flash" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ focus_width +'" height="'+ swf_height +'">');
        document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="swf/headline.swf"><param name="quality" value="high"><param name="bgcolor" value="#FFFFFF">');
        document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
        document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'">');
        document.write('<embed ID="focus_flash" src="swf/headline.swf" wmode="opaque" FlashVars="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'" menu="false" bgcolor="#C5C5C5" quality="high" width="'+ focus_width +'" height="'+ swf_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');document.write('</object>');
 //--></SCRIPT></div>
<div class="container" style="background: url(images/socend.gif) repeat-x; ">
<!--左边-->
 <div  class="mainleft_1">
   <DIV class=left-title ><img src="images/news_p.gif" /></DIV>
	<div id="mainleft" >
		<UL id=leftmenu>
		  <LI class=cur><A href='news2.aspx?type=42'>公司动态</A> </LI>
		  <LI class=cur><A href='news2.aspx?type=54'>行业新闻</A> </LI>s
		</UL>
   <P>&nbsp;</P>
   <div>&nbsp;&nbsp;&nbsp;<img src="images/index_link2.gif" /></div>
   <div><form action="" method="post" name="sform">
			 <select name="" style="width:195px; margin:3px 13px; border:1px solid #CCCCCC; " onchange="selchagegourl(this)">
            	<uc1:leff ID="leff1" runat=server />
          </select>
			   </form></div>
       <div>&nbsp;&nbsp;<a href="contact.aspx?id=4"><img src="images/socend_contart.gif" /></a></div>
	   <div>&nbsp;&nbsp;<a href="message.aspx"><img src="images/socend_messges.gif"  /></a></div>
	   <div>&nbsp;&nbsp;<a href="contact.aspx?id=30"><img src="images/socend_zhaoping.gif"  /></a></div>
    <P>&nbsp;</P>
   </div><div><img src="images/socend_bottom.gif" /></div>
  </div>
   
	<!--右边-->
	<div class="float_r">
		<div class="mainright_1">
	      
		   <div class="float_l " ><img src="images/news_p_2.gif" /></div>
		   <div class="float_r "><img src="images/socend_p_r.gif" /></div>
		   <div class="float_r  mainright_text "><a href="index.aspx">首页</a> > <a href="news2.aspx?type=42">新闻动态</a>  > <%=titles()%></div>
		</div>
	
	  <div class="clear"></div>
      <DIV id=mainright class="float_l">
	     <div class="mainright_text2">
	     <TABLE cellSpacing=0 cellPadding=0 width="100%" border=0 id=ConTxt>
                                <TBODY>
		 <%=New_list%>
		 </TBODY>
		 </TABLE>
        </div>
      </DIV>
	</div>
	
<SCRIPT src="images/autodiv.js" type=text/javascript></SCRIPT>
</div>
</asp:Content>

