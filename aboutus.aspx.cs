using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class aboutus : System.Web.UI.Page
{
    public string title, content;
    public string pics, links;
    protected void Page_Load(object sender, EventArgs e)
    {
        intro();
        toppics();
        pageTitle();

    }


    public void pageTitle()
    {
        StringBuilder sbr = new StringBuilder();
        if (Request["id"] != null)
        {

            DataTable dt = osdData.DataSet("select title,content1,canshu from article where id=" + Request["id"]).Tables[0];
            foreach (DataRow dr in dt.Select())
            {
                Page.Header.Title = dr["canshu"] + " " +dr[0] +" " + osdData.Executescalar("select name1 from information where id=1") + "";
            }
        }
    }


    public string articletype()
    {
        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select id,title from article where id between 1 and 3 or id=33").Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            sbr.Append("<LI class=cur><A href='aboutus.aspx?id="+dr["id"]+"'>"+dr["title"]+"</A> </LI>");
        }

        return sbr.ToString();
    }

    public string intro()
    {
        StringBuilder sbr = new StringBuilder();
        string con = "";
        DataTable dt = osdData.DataSet("select title,content1,canshu from article where id=" + Request["id"]).Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            title = Convert.ToString(dr["title"]);
            content = Convert.ToString(dr["content1"]);

            
        }
        return sbr.ToString();
    }

    public void toppics()
    {
        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select ClassPath, pictures from product where parid=2 and SortId=2 order by id desc").Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            pics+="pic/" + dr["pictures"] + "|";
            links += "" + dr["ClassPath"] + "|";

        }
        pics = pics.Substring(0, pics.Length - 1);
        links = links.Substring(0, links.Length - 1);
    }
}
