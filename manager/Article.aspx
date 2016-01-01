<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Article.aspx.cs" Inherits="manager_Article"  ValidateRequest="false"%>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        #Submit2
        {
            width: 94px;
        }
    </style>
</head>
<body>
<!--#include file="daohang.aspx" -->
    <form id="form1" runat="server">
    <div style=" width:660px; margin:0 auto;">
    <fieldset  style="width:660px; font-size:12px; display:none;">
        <legend>类别</legend>
        <div style=" margin:10px 0px 10px 20px;">
        <%=stypename()%><a href='Article.aspx' id="ret" style='display:block; float:left; margin-right:20px; color:Red;' runat=server>返回</a>
        </div>
        </fieldset>
    <table id="tabcont" style="width:660px;" border="0" align="center" runat=server>
     <TR>
						<TD align=center style="WIDTH: 294px; height: 21px;color:Black;">关键字：</TD>
						<TD style="height: 21px; width: 551px;"><INPUT id="txtcanshu" type="text" name="txtcanshu" runat="server" style="WIDTH: 520px;">
                        </TD>
                            </TR>
				<tr>
					<td bgColor="#507CD1" colSpan="2"><font face="宋体" color="#ffffff">::::::::::::::::::::::::::::::::</font></td>
				</tr>
				<tr>
					<td style="HEIGHT: 283px" colspan=2>					&nbsp;<FTB:FreeTextBox ID="FreeTextBox1" runat="server" DownlevelMode="BasicEditor"
                            Width="100%" AutoConfigure="Alternate">
                        </FTB:FreeTextBox>
                    </td>
				</tr>
	<tr>
					<td vAlign="bottom" align="center" colSpan="2" style="height: 26px"><input class="unnamed5" id="Submit2" type="submit" value=" 确 定 " name="submit" runat="server" onserverclick="Submit2_ServerClick" />&nbsp;<asp:Button 
                            ID="Button1" runat="server" Text="返回" Width="65px" 
                            onclick="Button1_Click" />
                    </td>
				</tr>
</table>
    </div>
    </form>
</body>
</html>
