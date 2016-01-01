using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = osdData.Executescalar("select canshu from article2 where id=5") + "";
    }


    public string intro()
    {
        string content = "";
        DataTable dt = osdData.DataSet("select title,content1 from article where id=24").Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            content = Convert.ToString(dr["content1"]);
        }
        return content;
    }

    public string news(int parid)
    {
        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select top 22 id,title,EditDate from news where parid=" + parid + " and languageid=1 order by EditDate desc").Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            string stitle = dr[1].ToString();
            if(stitle.Length>22)
            stitle = stitle.Substring(0, 22)+"...";
            sbr.Append("<dd ><span  style='float:right;'>" + DateTime.Parse(Convert.ToString(dr["EditDate"])).ToString("yyyy-MM-dd") + " </span><a href='news.aspx?type=" + parid + "&nid=" + dr["id"] + "' title='" + dr[1]+ "'> " + stitle + "</a></dd>");
        }
        return sbr.ToString();
    }


    public string pro()
    {
        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select top 7 id,PictureS,proname,canshu from product  where languageid=1 and  grade=1 and sortid=0 order by id desc").Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            string intro = Convert.ToString(dr["canshu"]);
            if (intro.Length > 42)
            {
                intro = intro.Substring(0, 42) + "..";
            }
            sbr.Append("<div class='mer_list'><div  class='fl'><a href='productlist.aspx?top=3&pid=" + dr["id"] + "'><img src='pic/s" + dr["PictureS"] + "' /></div><ul><li><a href='productlist.aspx?top=3&pid=" + dr["id"] + "' class='mer_tit'>" + dr["proname"] + "</a></li><li>" + intro + "</li></ul></div>");

        }
        return sbr.ToString();

    }

    public string returnProLinks()
    {
        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select id,title,linkurl from Links where parid=1").Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            sbr.Append("<li>·<a href='"+dr[2]+"' target='_blank'>"+dr[1]+"</a></li>");
        }
        return sbr.ToString();
    }

}
