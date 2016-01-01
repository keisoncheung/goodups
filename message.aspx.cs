using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class message : System.Web.UI.Page
{
    public string pics, links;
    protected void Page_Load(object sender, EventArgs e)
    {
        toppics();
        this.Page.Title = osdData.Executescalar("select canshu from article2 where id=6") + "";
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
}
