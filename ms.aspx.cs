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

public partial class ms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request["pars"] != null)
        {
            Response.Clear();
            string[] cc = Request["pars"].Split('-');
            string mz = cc[0].ToString().Trim();
            string sex = cc[1].ToString().Trim();
            string message = null;
            try
            {
                string sql = "insert into GuessBook(Title,Content,Company,Address,email,Tel,Fax,LanguageId,createDate)values('" + cc[0] + "','" +
                    cc[1] + "','" + cc[2] + "','" + cc[3] + "','" + cc[4] + "','" + cc[5] + "','" + cc[6] + "','"+cc[7]+"','"+DateTime.Now.ToString()+"')";
                if (Public.Igs(sql))
                {
                    message = "Congratulations!!";
                }
                else
                {
                    message = "Sorry,you lose!!";
                }
                Response.Write(message.ToString());
            }
            catch (Exception ee)
            {
                Response.Write(ee.ToString());
            }
        }
        else
        {
            Response.Write("empty!!");
        }

    }
}
