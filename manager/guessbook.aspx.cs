using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class manager_guessbook : System.Web.UI.Page
{
    private string gid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Request["id"] != null)
            {
                gid = Request["id"].ToString();
                BindInfo();
            }
        }

    }
    private void BindInfo()
    {
        string sql = null;

        try
        {
            sql = "select email,fax,Tel,Company,Address,Title,Content from GuessBook where id=" + gid + "";
            osdReader or = new osdReader(sql);
            or.Read();
            txtName.Value = Convert.ToString(or["Company"]);
            txtsex.Value = Convert.ToString(or["email"]);
            txtTel.Value = Convert.ToString(or["Tel"]);
            txtEmail.Value = Convert.ToString(or["fax"]);
            txtAddress.Value = Convert.ToString(or["Address"]);
            txtTitle.Value = Convert.ToString(or["Title"]);
            txtContent.Value = Convert.ToString(or["Content"]);
            or.Close();
        }
        catch (Exception ee)
        {
            ee.ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            Response.Redirect("guessbookshow.aspx?lan=" + osdData.Executescalar("select languageId from GuessBook where id="+Request["id"]));
        }
        else
        {
            Response.Redirect("guessbookshow.aspx");
        }

    }
}
