using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class product : System.Web.UI.Page
{
    int pagemax = 12; //没页个数;
    string pagelist = "";
    string cp = "1";
    int num;
    public string vipuser = "";
    public string pics, links;
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
        toppics();
        pageTitle();
    }



    public void pageTitle()
    {
        StringBuilder sbr = new StringBuilder();
        sbr.Append(osdData.Executescalar("select canshu from article2 where id=2") + "");
        if (!string.IsNullOrEmpty(Request["btype"] + ""))
            sbr.Append(" " + osdData.Executescalar("select clsname from producttype where id="+Request["btype"]+"") + "");
        if (Request["id"] != null)
            sbr.Append(" " + osdData.Executescalar("select clsname from producttype where id in(select parid from producttype where id=" + Request["id"] + ")") + " " + osdData.Executescalar("select clsname from producttype where id=" + Request["id"] + "") + "");
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

    public string sintro()
    {
        return osdData.Executescalar("select content1 from article where id=27") + "";
    }

    public string titleintro()
    {
        StringBuilder sbr = new StringBuilder();
        if (Request["id"] != null)
        {
            DataTable dt = osdData.DataSet("select id,clsname,parid from producttype where id=" + Request["id"] + "").Tables[0];
            foreach (DataRow dr in dt.Select())
            {
                sbr.Append(osdData.Executescalar("select clsname from producttype where id="+dr["parid"]+"")+ "> "+Convert.ToString(dr["clsname"]));
            }
        }
        return sbr.ToString();
    }


    public void returnStitle()
    {
 
    }


    public string stype2()
    {



        string sql = "";
        int i = 0;
        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select id, ClsName,SortId from productType where parid=0 order by sortid desc").Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            sbr.Append("<li class='btype" + i + "'><a href='javascript:protype_func(\""+i+"\")' >" + dr["clsname"] + "</a><ul id='ChildMenu" + i + "' class='collapsed'>");
            dt = osdData.DataSet("select id, ClsName,SortId from productType where parid=" + dr["id"] + " and parid<>0  order by sortid desc").Tables[0];
            foreach(DataRow dr2 in dt.Select())
            {
                sbr.Append("<li class='stype"+i+"'><a href='product.aspx?id=" + dr2["id"] + "'>" + dr2["clsname"] + "</a></li>");
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
        string where = " where languageId=1 and sortid=0";
        StringBuilder Html = new StringBuilder();
        cp = Request["cp"] + "";
        int pagenum = 1;
        if (cp.Length < 1)
        {
            cp = "1";
        }

        if (ViewState["CurrentPg"] + "" == "")
        {
            ViewState["CurrentPg"] = 1;
        }
        if (Request["id"] != null)
        {
            where += "and parid=" + Request["id"];
        }
        if (Request["btype"] != null)
        {
            where += "and parid in(select id from producttype where parid=" + Request["btype"] + ")";
        }
        else if (Request["bid"] != null)
        {
            where += " and parid in(select id from productType where parid=" + Request["bid"] + ")";
        }
        else if (Request["keyw"] != null)
        {
            where += " and proname like '%" + Server.UrlDecode(Request["keyw"]) + "%'";
        }

        //StringBuilder html = new StringBuilder();
        //ViewState["max_c"] = osdData.Executescalar("select count(Id) from Product " + where);
        //ViewState["MaxPg"] = Convert.ToString(System.Math.Ceiling(Convert.ToDouble(Convert.ToInt32(Convert.ToString(ViewState["max_c"])) / Convert.ToDouble(this.RecordPerPage))));



        //if (Request["pg"] != null)
        //{
        //    ViewState["CurrentPg"] = Request["pg"] + "";
        //}
        //else
        //{
        //    ViewState["CurrentPg"] = 1;
        //}
        //tpate();

        //int StartNum = Convert.ToInt32(ViewState["CurrentPg"]) * RecordPerPage;
        //int intTemNum = StartNum - RecordPerPage;
        //string sql = "select * from (select top " + StartNum.ToString() + " id,ProName,PictureS,PictureB,ParId,canshu, content,txtsortid from Product " + where + " order by  txtsortid desc) a where a.id not in (Select top " + intTemNum.ToString() + " id from Product " + where + " order by txtsortid desc)";
        //if (intTemNum == 0)
        //{
        //    sql = "select top " + RecordPerPage + " id,ProName,PictureS,PictureB,ParId,canshu,content,txtsortid from Product " + where + " order by  txtsortid desc";

        //}
        //DataTable dt = osdData.DataSet(sql).Tables[0];
        //if (dt.Rows.Count == 0)
        //{
        //    html.Append("暂没这类型产品！");
        //    return html.ToString();
        //}
        //int i =1;
        //string dti = "";
        //if (Request["dti"] != null)
        //{
        //    dti = "&dti=" + Request["dti"];
        //}
        //string title;
        //html.Append("<div class='product_content'>");
        //foreach (DataRow dr in dt.Select())
        //{
        //    title = Convert.ToString(dr["proname"]);
        //    if (title.Length > 8)
        //    {
        //        title = title.Substring(0, 8) + "..";
        //    }

        //    html.Append("<ul><li><a href='productlist.aspx?pid=" + dr["id"] + "' class='jiage'><img src='pic/" + dr["pictures"] + "'alt='" + dr["proname"] + "' /></a></li><li><a href='productlist.aspx?pid=" + dr["id"] + "' class='tit'>" + dr["proname"] + "</a></li></ul>");
            
        //    if (i % 3 == 0)
        //    {
        //        html.Append("</div><div class='product_content'>");
        //    }
        //    i++;

        //}
        //html.Append("</div>");


        int StartNum = Convert.ToInt32(cp) * pagemax;
        int intTemNum = StartNum - pagemax;
        string sql = "select * from (select top " + StartNum + " id,ProName,Procolor,Prodanwei,Promode,ProPrice,ProSize,PictureS,isnew,ishot,txtsortid from product " + where + "  order by txtsortid desc,id desc) a where a.id not in (Select top " + intTemNum + "  id from product " + where + "  order by txtsortid desc,id desc)";
        if (intTemNum <= 0)
        {
            sql = "select top " + pagemax + " id,ProName,Procolor,Prodanwei,Promode,ProPrice,ProSize,PictureS,isnew,ishot,txtsortid  from product " + where + " order by txtsortid desc,id desc";
        }
        pagenum = Convert.ToInt32(osdData.Executescalar("select count(Id) from product " + where));
        DataTable dt = osdData.DataSet(sql).Tables[0];
        
        string title;
        Html.Append("<div class='product_content'>");
        if (dt.Rows.Count > 0)
        {
            int i = 1;
            foreach (DataRow dr in dt.Select())
            {
                title = Convert.ToString(dr["proname"]);
                if (title.Length > 8)
                {
                    title = title.Substring(0, 8) + "..";
                }

                Html.Append("<ul><li><a href='productlist.aspx?pid=" + dr["id"] + "' class='jiage'><img src='pic/" + dr["pictures"] + "'alt='" + dr["proname"] + "' /></a></li><li><a href='productlist.aspx?pid=" + dr["id"] + "' class='tit'>" + dr["proname"] + "</a></li></ul>");

                if (i % 3 == 0)
                {
                    Html.Append("</div><div class='product_content'>");
                }
                i++;
            }
            Html.Append("</div>");
            dt.Dispose();
            page(pagenum, i + pagemax * (Convert.ToInt32(cp) - 1));

        }
        else
        {
            Html.Append("暂时无相关资料！");
        }
        return Html.ToString();
    }
    #endregion
    //分页显示
    private void page(int max, int num)
    {
        int maxtitle = 13;//显示多少页;
        int maxindex = Convert.ToInt32(System.Math.Ceiling((max * 1.0) / pagemax));//最大页数;
        int title_index = Convert.ToInt32(System.Math.Ceiling((maxindex * 1.0) / maxtitle));//显示多少个页数;
        int[,] arry = new int[title_index + 1, maxtitle];
        string url = this.Request.Url.Query;
        if (url.IndexOf("&cp") > 0)
        {
            url = url.Substring(0, url.IndexOf("&cp"));
        }
        if (url.IndexOf("?cp") >= 0)
        {
            url = url.Substring(0, url.IndexOf("?cp"));
        }
        if (url.IndexOf("?") >= 0)
        {
            url += "&cp=";
        }
        else
        {
            url = "?cp=";
        }
        for (int i = 1; i <= title_index; i++)
        {
            for (int t = 0; t < maxtitle; t++)
            {
                arry[i, t] = t + 1 + (maxtitle * (i - 1));
            }
        }
        pagelist += " <div style='text-align:center'></div><a href='" + url + "1' class='firstBtn'>|<<</a>";
        if (Convert.ToInt32(cp) == 1)
        { pagelist += " <a href='" + url + "1' class='firstBtn'><<</a>"; }
        else { pagelist += " <a href='" + url + "" + (Convert.ToInt32(cp) - 1) + "' class='firstBtn'><<</a>"; }

        int arry_index = Convert.ToInt32(System.Math.Ceiling(Convert.ToInt32(cp) / ((maxtitle) * 1.0)));

        string className = "pageBtn";
        for (int i = 0; i < maxtitle; i++)
        {
            if (arry[arry_index, i] > maxindex) continue;
            className = (arry[arry_index, i] == Convert.ToInt32(cp)) ? "currBtn" : "pageBtn";
            pagelist += " <a href='" + url + "" + arry[arry_index, i] + "' class='" + className + "'>" + arry[arry_index, i] + "</a>";
        }
        if (Convert.ToInt32(cp) == maxindex)
        {
            pagelist += " <a href='" + url + "" + maxindex + "' class='lastBtn' >>></a>";
        }
        else { pagelist += " <a href='" + url + "" + (Convert.ToInt32(cp) + 1) + "' class='lastBtn' >>></a>"; }
        pagelist += " <a href='" + url + "" + maxindex + "' class='firstBtn'>>>|</a>";
        pagelist += "<SPAN  style='color:black;'>&nbsp;&nbsp;&nbsp;当前<SPAN style='color:black;'>" + cp + "</SPAN>/<SPAN style='color:black;'>" + maxindex + "</SPAN>页&nbsp;&nbsp;&nbsp; 共<SPAN style='color:black;'>" + max + "</span>记录</span>";
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
    //获取当前页面绝对网址
    private string turnUrl()
    {
        string url = Request.Url.AbsolutePath;
        url = url.Substring(url.LastIndexOf('/') + 1);
        return url;
    }

    public string getpage
    {
        get
        {

            return pagelist;

        }
    }
}