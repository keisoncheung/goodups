using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class news2 : System.Web.UI.Page
{
    private string page_text = "";
    private string title_new = null;
    private int RecordPerPage = 10;//每页显示行数
    protected System.Web.UI.HtmlControls.HtmlTableRow ttr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.ViewState["CurrentPg"] = 1;
        }
        if (Request.QueryString["nid"] != null)
        {

        }
        pageTitle();
    }



    public void pageTitle()
    {
        StringBuilder sbr = new StringBuilder();
        sbr.Append(osdData.Executescalar("select canshu from article2 where id=3") + "");
        if (Request["type"] != null)
        {
            sbr.Append(" " + osdData.Executescalar("select clsname1 from NewType where id=" + Request["type"] + ""));
        }
        if (Request["nid"] != null)
        {
            sbr.Length = 0;
            sbr.Append(" " + osdData.Executescalar("select newsKW from news where id=" + Request["nid"] + ""));
        }
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

    public string titles()
    {
        string str = "公司动态";
        if (Request["type"] != null)
        {
            switch (Request["type"])
            {
                case "42":
                    str = "公司动态";
                    break;
                case "54":
                    str = "行业新闻";
                    break;
                case "55":
                    str = "技术支持";
                    break;
            }
           
        }
        return str;
    }


    public string zhidingpic(string partype)
    {

        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select * from news where ishot=1 and parid=" + partype+"").Tables[0];
        int i = 0;
        foreach (DataRow dr in dt.Select())
        {
            string parid = osdData.Executescalar("select clsname1 from newtype where id=" + dr["parid"]) + "";
            string title = Convert.ToString(dr["Title"]);
            string content = Convert.ToString(dr["intro"]);
            if (content.Length > 150)
            {
                content = content.Substring(0, 150) + "...";
            }
            sbr.Append("<div class='mer_list  mer_list_width'><div style='float:left;width:160px;'><a href='news2.aspx?type=" + dr["parid"] + "&nid=" + dr["id"] + "'><img src='pic/" + dr["LinkPic"] + "' class='mer_img_1'/></a></div><ul ><li><a href='news2.aspx?type=" + dr["parid"] + "&nid=" + dr["id"] + "' class='mer_tit'>" + title + "</a></li><li>" + content + "<span class='float_r '><a href='news2.aspx?type=" + dr["parid"] + "&nid=" + dr["id"] + "' class='font_yellow'>查看详情>></a></span> </li></ul></div><dl>");
            i++;
            if (i != 0)
                break;
        }
        return sbr.ToString();
    }


    public string Ini()
    {
        string webstr = null;
        webstr += zhidingpic(Request["type"].ToString());
        string nid = Request["nid"] + "";
        string ntype = Request["type"] + "";
        if (nid.Length <= 0) //新闻列表
        {
            string where = " where parid=54 and languageId=1 and isshow=1 or parid=55 and isshow=1 and ishot=0 and languageId=1";
            if (ntype.Length > 1)
            {
                where = " where languageId=1 and ishot=0 and  parid=" + ntype + "";
            }
            ViewState["max_c"] = osdData.Executescalar("select count(Id) from news" + where);
            ViewState["MaxPg"] = Convert.ToString(System.Math.Ceiling(Convert.ToDouble(Convert.ToInt32(Convert.ToString(ViewState["max_c"])) / Convert.ToDouble(this.RecordPerPage))));
            tpate();
            int StartNum = Convert.ToInt32(ViewState["CurrentPg"]) * RecordPerPage;
            int intTemNum = StartNum - RecordPerPage;
            string sql = "select * from (select top " + StartNum + " Id, EditDate,Title,CreateDate,parid,Content,LinkPic,intro,ishot from news " + where + " order by  EditDate desc, id desc) a where a.Id not in (Select top " + intTemNum + " Id from news " + where + " order by  EditDate desc)";
            if (intTemNum <= 0)
            {
                sql = "select top " + RecordPerPage + " EditDate, Id,Title,CreateDate,parid,Content,LinkPic,intro,ishot from news " + where + " order by EditDate desc ,id desc";
            }
            DataTable dt = osdData.DataSet(sql).Tables[0];
            string parid;
            int fori = 0;
            string content = "";
            foreach (DataRow dr in dt.Select())
            {
                parid = osdData.Executescalar("select clsname1 from newtype where id=" + dr["parid"]) + "";
                string title = Convert.ToString(dr["Title"]);
                content = Convert.ToString(dr["intro"]);
                if (content.Length > 150)
                {
                    content = content.Substring(0, 150) + "...";
                }
                  
                webstr += "<dd ><span >" + DateTime.Parse(Convert.ToString(dr["EditDate"])).ToString("yyyy-MM-dd") + " </span> | <a href='news.aspx?type=" + dr["parid"] + "&nid=" + dr["id"] + "' title='" + dr["title"] + "' target='_blank'> " + title + "</a> </dd>";
                fori++;
            }
            webstr += "</dl>";
            dt.Dispose();
        }
        else//新闻详细信息
        {
            string sql = "select Id,Title,Author,Content,CreateDate from news where id=" + nid;
            DataTable dt = osdData.DataSet(sql).Tables[0];
            if (dt.Rows.Count >= 1)
            {
                webstr = "<tr><td style='font-size:18px; height:20px; ' valign=top align=center><STRONG><Font>" + dt.Rows[0]["Title"] + "</font></STRONG><br><hr width=100% size=1 color=#c0c0c0 noshade></td></tr><tr><td style='padding:0px 0px 0px 0px;'><div id='page' style=''>" + dt.Rows[0]["Content"] + "</div> </td></tr>";
            }
            else
            {
                webstr = "暂无信息!";
            }
        }
        return webstr;
    }
    private string roadNewType(string tid)
    {
        return osdData.Executescalar("select ClsName from NewType where id=" + tid) + "";
    }
    #region //分页显示
    private void tpate()
    {
        string control = Convert.ToString(this.Request["pg"]);
        ViewState["CurrentPg"] = control;
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
        }
        if (Convert.ToInt32(ViewState["CurrentPg"]) < 1)
        {
            ViewState["CurrentPg"] = 1;
        }
        string urlq = turnQ();
        if (Convert.ToInt32(ViewState["MaxPg"]) > 1)
        {
            pg = Convert.ToInt32(ViewState["CurrentPg"]);
            p = ((pg - 1) >= 1) ? (pg - 1) : 1;
            n = ((pg + 1) <= Convert.ToInt32(ViewState["MaxPg"])) ? (pg + 1) : Convert.ToInt32(ViewState["MaxPg"]);
            page_text = "<div  style='text-align:right;'><table border='0' cellspacing='0' cellpadding='0'><tr>" +
                "<td><a style='' href='" + urlq + "&pg=1'><font style='color:blue;'>首页</font></a></td> " +
                "<td><a style='' href='" + urlq + "&pg=" + p + "'><font style='color:blue;'>上一页</font></a></td> " +
                "<td><a style='' href='" + urlq + "&pg=" + n + "'><font style='color:blue;'>下一页</font></a></td> " +
                "<td><a style='' href='" + urlq + "&pg=" + ViewState["MaxPg"] + "'><font style='color:blue;'>尾页</font></a></td> " +
                "<td>页次：<span style='font-weight:bold;'>" + ViewState["CurrentPg"] + "/" + ViewState["MaxPg"] + "</span>页</td> " +
                "<td>总共" + ViewState["max_c"] + "条</td>" +
                "</tr></table></div>";
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
        return Request.Url.AbsolutePath + "?" + url.Substring(1);
    }
    public string Page_Text
    {
        get
        {
            return (page_text != null) ? page_text : "";
        }
    }
    public string New_list
    {
        get
        {
            return Ini();
        }
    }
    #endregion
}

