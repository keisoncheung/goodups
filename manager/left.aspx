<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="manager_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title><LINK href="Admin_STYLE.CSS" type="text/css" rel="stylesheet" />
    <style type="text/css">
    body
    {
    	
    	background-color:#507CD1;
    	text-align:center;
	}

    .menu
    {
    	width:158px;    	
    	text-align:left;
	}
	.menu .menuContent
	{
		margin-bottom:12px;	
		background-color:#d4ecf5;	
	}

	.menu_title  { }
	.menu_title span  { position:relative; top:2px; left:8px; color:#0F42A6; font-weight:bold; }
	.menu_title2  { }
	.menu_title2 span  { position:relative; top:2px; left:8px; color:#cc0000; font-weight:bold; }
	a:link
{
	font-weight : bold ;
	text-decoration : none ;
	color : #000000;
}
a:visited 
{
	font-weight : bold ;
	text-decoration : none ;
	color : #000000;
}
a:hover 
{
	font-weight : bold ;
	color : #f60 ;
	text-decoration : none ;

}
a:active 
{
	font-weight : bold ;
	text-decoration : none ;
	color : #F90 ;
} 
	li 
	{ 
		list-style:disc outside url(bgpic/open.gif);	
		font-weight:700;		
		height:19px;
		padding-left:4px;
		vertical-align:bottom;
		overflow:hidden;
		padding-top:12px;
		
	}
	ul
	{
		margin:0px 0px 0px 30px;
	}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="menu">
            <img src="bgpic/title.gif" alt="" />
            <div class="menu_title"onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';"
                style="background-image: url(bgpic/title_bg_quit.gif); line-height: 25px;">
                <span><b>&nbsp;&nbsp;</b><b><a href="main.aspx?lanauage=1&ac=管理首页" target="main" >网站首页</a></b> | <a href="out.aspx" target="_top"><b>退出</b></a></span>
            </div>
        </div>
        <div class="menu">
        
        
        	<div lang="MainMenu"  style="background-image: url(bgpic/Admin_left_02.gif); line-height: 25px;" class="menu_title" onmouseover="this.className='menu_title1';" onmouseout="this.className='menu_title';">
        		<span style="CURSOR:hand">&nbsp;网站资料管理<span lang="zh-cn"></span> <span style="color:#ff0000">√</span></span>
        	</div>
        	<div class="menuContent">
        		<ul>
        			<li><a href="information.aspx?lan=1" target="main">公司资料</a></li>       
        			<li><a href="Article2.aspx?lan=1" target="main">栏目关键字</a></li>        			
        		</ul>
        	</div>
        	

<div lang="MainMenu"  style="background-image: url(bgpic/Admin_left_02.gif); line-height: 25px;" class="menu_title" onmouseover="this.className='menu_title1';" onmouseout="this.className='menu_title';">
        		<span style="CURSOR:hand">&nbsp;公司公告<span lang="zh-cn"></span> <span style="color:#ff0000">√</span></span>
        	</div>
        	<div class="menuContent">
        		<ul>
        			<li><a href="Article.aspx?id=24&lan=1" target="main">首页公司公告</a></li>
        			<li><a href="Article.aspx?id=33&lan=1" target="main">公司公告</a></li>        			
        		</ul>
        	</div>
        	
        	<div lang="MainMenu"  style="background-image: url(bgpic/Admin_left_02.gif); line-height: 25px;" class="menu_title" onmouseover="this.className='menu_title1';" onmouseout="this.className='menu_title';">
        		<span style="CURSOR:hand">&nbsp;头部图片管理<span lang="zh-cn"></span> <span style="color:#ff0000">√</span></span>
        	</div>
        	<div class="menuContent">
        		<ul>
        			<li><a href="toppicsshow.aspx" target="main">头部图片管理</a></li>        			
        		</ul>
        	</div>
        	
        	<div lang="MainMenu"  style="background-image: url(bgpic/Admin_left_02.gif); line-height: 25px;" class="menu_title" onmouseover="this.className='menu_title1';" onmouseout="this.className='menu_title';">
        		<span style="CURSOR:hand">&nbsp;关于我们<span lang="zh-cn"></span> <span style="color:#ff0000">√</span></span>
        	</div>
        	<div class="menuContent">
        		<ul>
        			<li><a href="Article.aspx?id=1&lan=1" target="main">公司简介 </a></li>   
        			<li><a href="Article.aspx?id=2&lan=1" target="main">企业文化 </a></li>   
        			<li><a href="Article.aspx?id=3&lan=1" target="main">公司资质</a></li>        			
        		</ul>
        	</div>
        	
        	<div lang="MainMenu"  style="background-image: url(bgpic/Admin_left_02.gif); line-height: 25px;" class="menu_title" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';">
        		<span style="CURSOR:hand">&nbsp;产品展示<span lang="zh-cn"></span> <span style="color:#ff0000">√</span></span>
        	</div>
        	<div class="menuContent">
        		<ul>
        			<li><a href="proshow.aspx" target="main">产品列表</a></li>
        			<li><a href="protype.aspx" target="main">系列管理</a></li>
        		</ul>
        	</div>
        	
        	<div lang="MainMenu"  style="background-image: url(bgpic/Admin_left_02.gif); line-height: 25px;" class="menu_title" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';">
        		<span style="CURSOR:hand">&nbsp;新闻动态<span lang="zh-cn"></span> <span style="color:#ff0000">√</span></span>
        	</div>
        	<div class="menuContent">
        		<ul>
        			<li><a href="newsshow.aspx?type=42&lan=1" target="main">公司动态 </a></li>
        			<li><a href="newsshow.aspx?type=54&lan=1" target="main">行业新闻  </a></li>
        		</ul>
        	</div>
        	
        	
        	
        	<div lang="MainMenu"  style="background-image: url(bgpic/Admin_left_02.gif); line-height: 25px;" class="menu_title" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';">
        		<span style="CURSOR:hand">&nbsp;方案与案例 <span lang="zh-cn"></span> <span style="color:#ff0000">√</span></span>
        	</div>
        	<div class="menuContent">
        		<ul>
        			<li><a href="newsshow.aspx?type=56&lan=1" target="main">方案解决</a></li>
        			<li><a href="yingyongshow.aspx" target="main">经典案例</a></li>
        			<li><a href="newsshow.aspx?type=55&lan=1" target="main">技术支持</a></li>
        		</ul>
        	</div>
        	
        	<div lang="MainMenu"  style="background-image: url(bgpic/Admin_left_02.gif); line-height: 25px;" class="menu_title" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';">
        		<span style="CURSOR:hand">&nbsp;联系我们 <span lang="zh-cn"></span> <span style="color:#ff0000">√</span></span>
        	</div>
        	<div class="menuContent">
        		<ul>
        			<li><a href="Article.aspx?id=4&lan=1" target="main">联系方式 </a></li>
        			<li><a href="guessbookshow.aspx" target="main">在线留言</a></li>
        			<li><a href="Article.aspx?id=32&lan=1" target="main">人才招聘 </a></li>
        		</ul>
        	</div>

        	<div lang="MainMenu"  style="background-image: url(bgpic/Admin_left_02.gif); line-height: 25px;" class="menu_title" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';">
        		<span style="CURSOR:hand">&nbsp;友情链接<span lang="zh-cn"></span> <span style="color:#ff0000">√</span></span>
        	</div>
        	<div class="menuContent">
        		<ul>
        			<li><a href="friendsshow.aspx" target="main">友情链接</a></li>
        		</ul>
        	</div>
        	
        		<div lang="MainMenu"  style="background-image: url(bgpic/Admin_left_02.gif); line-height: 25px;" class="menu_title" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';">
        		<span style="CURSOR:hand">&nbsp;产品快览<span lang="zh-cn"></span> <span style="color:#ff0000">√</span></span>
        	</div>
        	<div class="menuContent">
        		<ul>
        			<li><a href="tuiguangshow.aspx" target="main">产品快览</a></li>
        		</ul>
        	</div>
        	
        	<div lang="MainMenu"  style="background-image: url(bgpic/Admin_left_02.gif); line-height: 25px;" class="menu_title" onmouseover="this.className='menu_title5';" onmouseout="this.className='menu_title';">
        		<span style="CURSOR:hand">&nbsp;密码管理<span lang="zh-cn"></span> <span style="color:#ff0000">√</span></span>
        	</div>
        	<div class="menuContent">
        		<ul>
        			<li><a href="changepwd.aspx" target="main">修改密码</a></li>
        		</ul>
        	</div>
       </div>
    </form>
    <script type="text/javascript">
    	
    		var onclick=function()
    		{ 			
    			var div=this.nextSibling;//this.nextSibling;
    			if(div.style.display=="none")    			
    			{
    				div.style.display="";
    			}
    			else
    			{
    				div.style.display="none";
    			}
    		}
    		var divs=document.getElementsByTagName("div");
    		for(var i=0;i<divs.length;i++)
    		{
    			if(divs[i].lang=="MainMenu")
    			{
    				divs[i].setAttribute('onclick',document.all ? eval(onclick) : 'javascript:onclick()');	
    			}
    		}    	
    </script>
</body>
</html>
