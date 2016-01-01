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
using System.Text;

public partial class manager_Article : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Request["lan"] != null && Request["id"] != null)
            {
                csh(Convert.ToInt32(Request["id"]), Request["lan"]);
            }
        }
    }

    public string stypename()
    {
        StringBuilder sbr = new StringBuilder();
        string sql = "";
        DataTable dt = new DataTable();

        if (Request["lan"] != null && Request["id"]!=null)
        {
            sql = "select id,Title,content1,content2,content3,content4 from Article";
            dt = osdData.DataSet(sql).Tables[0];
            foreach (DataRow dr in dt.Select())
            {
                sbr.Append(" <a href='Article.aspx?id=" + dr["id"] + "&lan=" + Request["lan"] + "' style='display:block; float:left; margin:0px 20px 10px 0px;'>" + dr["Title"] + "</a>");
            }
            
            tabcont.Visible = true;
            ret.Visible = true;
        }


        else if (Request["lan"] != null)
        {
            sql = "select id,Title from Article";
            dt = osdData.DataSet(sql).Tables[0];
            foreach (DataRow dr in dt.Select())
            {
                sbr.Append(" <a href='Article.aspx?id=" + dr["id"] + "&lan=" + Request["lan"] + "' style='display:block; float:left; margin:0px 20px 10px 0px;'>" + dr["Title"] + "</a>");
            }
            tabcont.Visible = false;
            ret.Visible = true;
        }
        else
        {
            sql = "select id,ClsName from languageId";
            dt = osdData.DataSet(sql).Tables[0];
            foreach (DataRow dr in dt.Select())
            {
                sbr.Append(" <a href='Article.aspx?lan=" + dr["id"] + "' style='display:block; float:left; margin:0px 20px 10px 0px;'>" + dr["ClsName"] + "</a>");
                
            }
            ret.Visible = false;
            tabcont.Visible = false;
        }
        return sbr.ToString();
    }

    private void csh(int id,string lan)
    {

        try
        {
            string sql = "select canshu,content"+lan+" from Article where id=" +id + "";
            osdReader or = new osdReader(sql);
            if (or.Read())
            {
                FreeTextBox1.Text = Convert.ToString(or[1]);
                txtcanshu.Value = Convert.ToString(or[0]);
            }
            or.Close();

        }
        catch (Exception e)
        {
            e.ToString();
        }
    }

    protected void Submit2_ServerClick(object sender, EventArgs e)
    {

        string sql = "update Article set content" + Request["lan"] + "='" + FreeTextBox1.Text.Replace("'", "''") + "',canshu='" + txtcanshu.Value + "' where id=" + Request["id"] + "";
        try
        {
            osdData.ExecuteNonQuery(sql);
            Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"修改成功！\")</script>");
        }
        catch (Exception ee)
        {
            ee.ToString();
            Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"修改失败！\")</script>");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request["lan"] != null && Request["id"] != null)
        {
            Response.Redirect("Article.aspx");
        }

    }
}
