using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class productlist : System.Web.UI.Page
{
    public string pics, links;
    protected void Page_Load(object sender, EventArgs e)
    {
        toppics();
        pageTitle();
    }


    public void pageTitle()
    {
        StringBuilder sbr = new StringBuilder();

        if (Request["pid"] != null)
        {
            DataTable dt = osdData.DataSet("select id,prokeyword,parid,proname from product where id=" + Request["pid"]).Tables[0];
            foreach (DataRow dr in dt.Select())
            {
                sbr.Append(dr["prokeyword"] + " " + osdData.Executescalar("select clsname from producttype where id in(select parid from producttype where id=" + dr[2] + ")") + " " + osdData.Executescalar("select clsname from producttype where id=" + dr[2] + "") + "-" + dr["proname"]);
            }
        }
        this.Page.Title = sbr.ToString();

    }

    public void toppics()
    {
        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select ClassPath, pictures from product where parid=2 and SortId=2 order by id desc").Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            pics += "pic/" + dr["pictures"] + "|";
            links += "" + dr["ClassPath"] + "|";

        }
        pics = pics.Substring(0, pics.Length - 1);
        links = links.Substring(0, links.Length - 1);
    }

    public string stype2()
    {



        string sql = "";
        int i = 1;
        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select id, ClsName,SortId from productType where parid=0  order by sortid desc").Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            sbr.Append("<li class='btype" + i + "'><a href='javascript:protype_func(\"" + i + "\")' >" + dr["clsname"] + "</a><ul id='ChildMenu" + i + "' class='collapsed'>");
            dt = osdData.DataSet("select id, ClsName,SortId from productType where parid=" + dr["id"] + " and parid<>0  order by sortid desc").Tables[0];
            foreach (DataRow dr2 in dt.Select())
            {
                sbr.Append("<li class='stype" + i + "'><a href='product.aspx?id=" + dr2["id"] + "'>" + dr2["clsname"] + "</a></li>");
            }
            sbr.Append("</ul></li>");
            i++;
        }
        //if (Request["dti"] != null)
        //{
        //    sbr.Append("<script LANGUAGE=\"JavaScript\">displaydl(\"dti" + Request["dti"] + "\")</script>");
        //}
        return sbr.ToString();

    }

    public string sintro()
    {
        string pid = "";
        if ((Request["pid"] + "").Length > 0)
        {
            pid = Request["pid"];
        }
        else
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }
        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select * from Product Where Id=" + pid).Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            string type = osdData.Executescalar("select ClsName from productType where id=" + dr["ParId"] + "").ToString();
            sbr.Append("<div style='margin-left:30px; '><a target='_blank' href='pic/" + dr["PictureB"] + "'><img alt='" + dr["ProName"] + "' style=' border:0px;padding:2px;margin-bottom:5px; float:left; ' src='pic/ss" + dr["PictureS"] + "' alt=''></a>");
            sbr.Append("<div style=' float:left; padding-left:20px;'><br><font style='font-size:14px;font-weight:800;'>" + dr["ProName"] + "</font><p><font style='font-size:12px;font-weight:500;'>名称：" + dr["ProName"] + "<br /><br />类别：" + type + "</div></div>");
            sbr.Append("<div style='width:100%;margin-top:0px; clear:both;'><hr><p style='font-size:13px;font-weight:800;margin-left:30px;'>" + dr["Content"] + "</p></div>");
        }
        dt.Dispose();
        return sbr.ToString();
    }
}
