using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class friends : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    public string intro()
    {
        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select title,linkurl from links where parid=0 order by id desc").Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            sbr.Append("<option value='" + dr["linkurl"] + "'>"+dr["title"]+"</option>");
        }
        return sbr.ToString();
    }
}
