<%@ Page Language="C#" AutoEventWireup="true" CodeFile="guessbook.aspx.cs" Inherits="manager_guessbook" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <LINK href="style.css" type="text/css" rel="stylesheet">
</head>
<body>
<!--#include file="daohang.aspx" -->
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<div style="width: 704px; height: 532px;
        padding: 16px 32px 0px 35px; line-height:18px;">
        <table class="tab" cellSpacing="1" cellPadding="2" width="100%" border="0" align=center>
		<tr>
		<td colspan=4 bgColor="#507CD1">
            <font style="color:White">:::::::::留言内容::::::::::::::::::::::::::::::::::::::::::::::::::</font>
		</td>
	</tr>
		<tr>
		<td>
            公司名称</td>
		<td >
		<input size="30" name="txtName" id="txtName" runat="server" /></td>
		<td >
            Email:</td>
		<td  ><input size="30" name="txtsex" id="txtsex" runat="server"/></td>
	</tr>
	<tr>
		<td>
		联系电话</td>
		<td >
		<input size="30" name="txtTel" id="txtTel" runat="server"/></td>
		<td >
            手机</td>
		<td  ><input size="30" name="txtEmail" id="txtEmail" runat="server"/></td>
	</tr>
	<tr>
		<td  >地　　址</td>
		<td colspan="3" >
		<input size="30" name="txtAddress" id="txtAddress" style="width: 537px; height: 22px;" runat="server"/></td>
	</tr>
	<tr>
		<td  >标题</td>
		<td colspan="3" >
		<input id="txtTitle" size="60" name="txtTitle" runat="server"/><span style="color:red;">* </span></td>
	</tr>
	<tr>
		<td style="vertical-align:top; height: 90px;">内容</td>
		<td colspan="3" style="height: 90px" >
		<textarea id="txtContent" name="txtContent" rows="5" style="width: 537px" runat="server"></textarea><span style="color:red;">*</span></td>
	</tr>
</table>

                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="返回" 
                        Width="70px" />

    </div>
			</FONT>
		</form>
	</body>
</HTML>