using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class product2 : System.Web.UI.Page
{
    private int RecordPerPage = 12;//每页显示行数
    private string page_text = "";
    private string dti = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.ViewState["CurrentPg"] = 1;
        }
        string dti = "";
        if (Request["dti"] != null)
        {
            dti = "&dti=" + Request["dti"];
        }
        pageTitle();
    }

    public void pageTitle()
    {
        StringBuilder sbr = new StringBuilder();
        sbr.Append(osdData.Executescalar("select canshu from article2 where id=4") + "");
        if (Request["type"] != null)
            sbr.Append(" " + osdData.Executescalar("select clsname from producttype where id in(select parid from producttype where id=" + Request["type"] + ")") + " " + osdData.Executescalar("select clsname from producttype where id=" + Request["id"] + "") + "");
        this.Page.Title = sbr.ToString();

    }



    public string toppics()
    {
        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select pictures from product where parid=2 and SortId=2 order by id desc").Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            sbr.Append("pic/" + dr["pictures"] + "|");
        }
        string str = sbr.ToString();
        str = str.Substring(0, str.Length - 1);
        return str;
    }
    public string sintro()
    {
        return osdData.Executescalar("select content1 from article where id=27") + "";
    }

    public string stype2()
    {



        string sql = "";
        int i = 1;
        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select id, ClsName,SortId from productType where parid=0").Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            sbr.Append("<li><a href='#Menu=ChildMenu" + i + "' onClick=\"DoMenu('ChildMenu" + i + "')\">" + dr["clsname"] + "</a><ul id='ChildMenu" + i + "' class='collapsed'>");
            dt = osdData.DataSet("select id, ClsName,SortId from productType where parid=" + dr["id"] + " and parid<>0").Tables[0];
            foreach (DataRow dr2 in dt.Select())
            {
                sbr.Append("<li><a href='product.aspx?id=" + dr2["id"] + "'>" + dr2["clsname"] + "</a></li>");
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
    public string Content
    {
        get
        {
            return content();
        }
    }


    private string content()
    {
        return products();
    }


    #region 所有产品
    private string products()
    {
        string where = " where languageId=1 and sortid=1";


        if (ViewState["CurrentPg"] + "" == "")
        {
            ViewState["CurrentPg"] = 1;
        }
        if (Request["id"] != null)
        {
            where += "and parid=" + Request["id"];
        }

        else if (Request["bid"] != null)
        {
            where += " and parid in(select id from productType where parid=" + Request["bid"] + ")";
        }

        StringBuilder html = new StringBuilder();
        ViewState["max_c"] = osdData.Executescalar("select count(Id) from Product " + where);
        ViewState["MaxPg"] = Convert.ToString(System.Math.Ceiling(Convert.ToDouble(Convert.ToInt32(Convert.ToString(ViewState["max_c"])) / Convert.ToDouble(this.RecordPerPage))));



        if (Request["pg"] != null)
        {
            ViewState["CurrentPg"] = Request["pg"] + "";
        }
        else
        {
            ViewState["CurrentPg"] = 1;
        }
        tpate();

        int StartNum = Convert.ToInt32(ViewState["CurrentPg"]) * RecordPerPage;
        int intTemNum = StartNum - RecordPerPage;
        string sql = "select * from (select top " + StartNum.ToString() + " id,ProName,PictureS,PictureB,ParId,canshu, content,classpath,txtsortid from Product " + where + " order by txtsortid desc, Id desc) a where a.Id not in (Select top " + intTemNum.ToString() + " Id from Product " + where + " order by Id desc)";
        if (intTemNum == 0)
        {
            sql = "select top " + RecordPerPage + " id,ProName,PictureS,PictureB,ParId,canshu,content,classpath,txtsortid from Product " + where + " order by txtsortid desc, Id desc";

        }
        DataTable dt = osdData.DataSet(sql).Tables[0];
        if (dt.Rows.Count == 0)
        {
            html.Append("暂没这类型产品！");
            return html.ToString();
        }
        int i = 1;
        string dti = "";
        if (Request["dti"] != null)
        {
            dti = "&dti=" + Request["dti"];
        }
        string title;
        html.Append("<div class='product_content'>");
        foreach (DataRow dr in dt.Select())
        {
            title = Convert.ToString(dr["proname"]);
            if (title.Length > 8)
            {
                title = title.Substring(0, 8) + "..";
            }

            html.Append("<ul><li><a href='" + dr["classpath"] + "' target='_blank' class='jiage'><img  id=picboder src='pic/" + dr["pictures"] + "' alt='" + dr["proname"] + "' name=picboder /></a></li><li><a href='" + dr["classpath"] + "' class='tit' title='" + dr["ProName"] + "'  target='_blank'>" + title + "</a></li></ul>");

            if (i % 3 == 0)
            {
                html.Append("</div><div class='product_content'>");
            }
            i++;

        }
        html.Append("</div>");
        return html.ToString();
    }
    #endregion
    //分页显示
    private void tpate()
    {
        string control = Convert.ToString(this.Request["pg"]);
        int pg, p, n = 0;
        switch (control)
        {
            case "f":
                ViewState["CurrentPg"] = 1;
                break;
            case "n":
                ViewState["CurrentPg"] = Convert.ToInt32(ViewState["CurrentPg"]) + 1;
                break;
            case "p":
                ViewState["CurrentPg"] = Convert.ToInt32(ViewState["CurrentPg"]) - 1;
                break;
            case "l":
                ViewState["CurrentPg"] = ViewState["MaxPg"];
                break;
            default:
                ViewState["CurrentPg"] = 1;
                try
                {
                    if (control != "f" && control != "n" && control != "l" && control != "p" && control != "" && control != "null")
                    {
                        if (Convert.ToInt32(control) > 0)
                        {
                            ViewState["CurrentPg"] = control;
                        }
                    }
                    else
                    {
                        ViewState["CurrentPg"] = 1;
                    }
                }
                catch { }
                break;
        }
        if (Convert.ToInt32(ViewState["CurrentPg"]) < 1)
        {
            ViewState["CurrentPg"] = 1;
        }
        if (Convert.ToInt32(ViewState["CurrentPg"]) > Convert.ToInt32(ViewState["MaxPg"]))
        {
            ViewState["CurrentPg"] = RecordPerPage;
        }
        if (Convert.ToInt32(ViewState["MaxPg"]) <= 1)
        {
            page_text = "";
        }
        else
        {
            string page_q = turnQ();
            pg = Convert.ToInt32(ViewState["CurrentPg"]);
            p = ((pg - 1) >= 1) ? (pg - 1) : 1;
            n = ((pg + 1) <= Convert.ToInt32(ViewState["MaxPg"])) ? (pg + 1) : Convert.ToInt32(ViewState["MaxPg"]);
            page_text = "<div style='clear:both;'><div align='right'><table border='0' cellspacing='0' cellpadding='0'><tr>" +
                "<td><a href='product2.aspx?pg=1&spid=1" + turnQ() + "'><font style='color:blue;'>【首页】</font></a></td> " +
                "<td><a href='product2.aspx?pg=" + p + "&spid=1" + turnQ() + "'><font style='color:blue;'>【上页】</font></a></td> " +
                "<td><a href='product2.aspx?pg=" + n + "&spid=1" + turnQ() + "'><font style='color:blue;'>【下页】</font></a></td> " +
                "<td><a href='product2.aspx?pg=" + ViewState["MaxPg"] + "&spid=1" + turnQ() + "'><font style='color:blue;'>【尾页】</font></a></td> " +
                "<td style=''>页次：" + ViewState["CurrentPg"] + "/" + ViewState["MaxPg"] + "页</span></td> " +
                "<td>&nbsp;总共" + ViewState["max_c"] + "条</td></tr></table></div>";
            //"<td><select id='spage'><option selected value='1'>1</option></select><button type=button value=submit onclick=\"document.location.href='products.aspx?spid=1&pg='+document.getElementById('spage').value+'" + page_q + "" + turnQ() + "'\">跳转</button></td> " + "<td width='10'></td></tr></table></div></div><script>var s=document.getElementById('spage');var pg=" + ViewState["MaxPg"] + ";var cpg=" + ViewState["CurrentPg"] + ";s.options.length=0;for(var i=0;i<pg;i++){var option  = document.createElement('option');option.value =(i+1);option.innerHTML  =('第'+(1+i)+'页');if((i+1)==cpg){option.selected=true;}s.appendChild(option);}</script>";
        }
    }

    private string turnQ()
    {
        string urls = Request.Url.Query;
        string url = "";
        if (urls.IndexOf("?") >= 0)
        {
            urls = urls.Replace("?", "");
            foreach (string u in urls.Split('&'))
            {
                if (u.IndexOf("pg") == -1)
                {
                    url += "&" + u;
                }
            }
        }
        return url;
    }
    public string Page_Text
    {
        get
        {
            return page_text;
        }
    }
}
