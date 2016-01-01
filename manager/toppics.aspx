<%@ Page Language="C#" AutoEventWireup="true" CodeFile="toppics.aspx.cs" Inherits="manager_toppics" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
    <link href="style.css" type="text/css" rel="stylesheet">
    <link href="../css/lightbox.css" rel="stylesheet" type="text/css" />
     <script src="../js/prototype.js" type="text/javascript"></script>
<script src="../js/scriptaculous.js?load=effects,builder" type="text/javascript"></script>
<script src="../js/lightbox.js" type="text/javascript"></script>
</head>
 <!--#include file="daohang.aspx" -->
 <body>
    <form id="form1" method="post" runat="server">
        <div style='width:758px; margin:0 auto;'>
        <fieldset  style="width:660px; font-size:12px; display:none;">
        <legend>类别</legend>
        <div style=" margin:10px 0px 10px 20px;">
       <asp:RadioButtonList ID="rbl" runat="server" RepeatDirection="Horizontal" 
                 AutoPostBack="false">
                            
                            </asp:RadioButtonList>
        </div>
        </fieldset>
        </div>
            <table border=0 cellSpacing="1" cellPadding="1" style="width:758px;" align=center>
                <tr>
                    <td bgcolor="#507CD1" colspan="2">
                        <font face="宋体" color="#ffffff">::头部图片管理::::::::::::::::::::::::::::::</font></td>
                </tr>
                <tr>
                    <td style="width: 113px; height: 30px; display:none;" align="center">相关图片 ：
 </td>
                    <td style=" height: 30px">
                        <asp:DropDownList ID="lanmuxz" runat="server" Width="192px" Visible="false">
                            <asp:ListItem Selected="True" Value="2">关于我们</asp:ListItem>
                            <asp:ListItem Value="3">产品展示</asp:ListItem>
                            <asp:ListItem Value="4">新闻动态</asp:ListItem>
                            <asp:ListItem Value="5">方案与案例</asp:ListItem>
                            <asp:ListItem Value="6">联系我们</asp:ListItem>
                        </asp:DropDownList>
                     <div style=" display:none;">  <asp:TextBox ID="name" runat="server" Width="246px"></asp:TextBox> </div> 
                     
                    <input id="File1" runat="server" style="width: 316px; height: 22px" 
                            name="File1" type="file">
                        </td>
                    
                </tr>
                 
               <tr>
                    <td style="width: 113px; "  colspan="2">
                    链接地址：<input style=" width:300px;" id="linkurl" runat="server" />
                    </td>
                   
                    </tr>
               
                <tr>
                    <td style="width: 464px" align="left" colspan="2">
                        <input class="unnamed5" id="Submit1" type="submit" value=" 确 定 " name="submit" runat="server"
                            onserverclick="Submit1_ServerClick">&nbsp;<input style="width: 72px; height: 24px"
                                onclick="location.href='toppicsshow.aspx'" type="button" value="返回" name="Reg"></td>
                </tr>
            </table>

    </form>
</body>
</html>
