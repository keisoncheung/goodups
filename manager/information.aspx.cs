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

public partial class manager_form_gszl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Request["lan"] != null)
            {
                csh();
            }
        }
    }

    public string stypename()
    {
        StringBuilder sbr = new StringBuilder();
        string sql = "";
        DataTable dt = new DataTable();
       if (Request["lan"] != null)
        {
            sql = "select id,ClsName from languageId";
            dt = osdData.DataSet(sql).Tables[0];
            foreach (DataRow dr in dt.Select())
            {
                sbr.Append(" <a href='information.aspx?lan=" + dr["id"] + "' style='display:block; float:left; margin:0px 20px 10px 0px;'>" + dr["ClsName"] + "</a>");

            }
            tabcont.Visible = true;
        }
        else
        {
            sql = "select id,ClsName from languageId";
            dt = osdData.DataSet(sql).Tables[0];
            foreach (DataRow dr in dt.Select())
            {
                sbr.Append(" <a href='information.aspx?lan=" + dr["id"] + "' style='display:block; float:left; margin:0px 20px 10px 0px;'>" + dr["ClsName"] + "</a>");
                
            }
            tabcont.Visible = false;
        }
        return sbr.ToString();
    }


    public void csh()
    {
        try
        {
            string sql = "select * from Information where LanauageId=" + Request["lan"];
            osdReader or = new osdReader(sql);
            if (or.Read())
            {
                txtname1.Value = Convert.ToString(or["name1"]);
                txtcopyright.Value = Convert.ToString(or["copyright"]);
                txtkeyword.Value = Convert.ToString(or["keyword"]);
                txtname2.Value = Convert.ToString(or["name2"]);
                txtweb.Value = Convert.ToString(or["web"]);
                txtemail.Value = Convert.ToString(or["email"]);
                txtfax.Value = Convert.ToString(or["fax"]);
                txtdes.Value = Convert.ToString(or["Description"]);
                txtlxr.Value = Convert.ToString(or["lxr"]); ;
                txttel.Value = Convert.ToString(or["tel"]);
                txtzip.Value = Convert.ToString(or["zip"]);
                txtaddr.Value = Convert.ToString(or["addr"]);
                txtbeian.Value = Convert.ToString(or["beian"]);
                txtmobilep.Value = Convert.ToString(or["mobilep"]);
                qq.Value = Convert.ToString(or["qq"]);
                addr2.Value = Convert.ToString(or["addr2"]);
                tel2.Value = Convert.ToString(or["tel2"]);
                msn.Value = Convert.ToString(or["msn"]);
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
        string sql = "update Information set name1='" + txtname1.Value + "',name2='" + txtname2.Value + "',web='" + txtweb.Value + "',email='" + txtemail.Value + "',fax='" +
                 txtfax.Value + "',copyright='" + txtcopyright.Value + "',keyword='" + txtkeyword.Value + "',Description='" + txtdes.Value + "',lxr='" + txtlxr.Value + "',tel='" +
                 txttel.Value + "',zip='" + txtzip.Value + "',addr='" + txtaddr.Value + "',beian='" + txtbeian.Value + "',mobilep='" +
                 txtmobilep.Value + "',qq='"+qq.Value+"',msn='"+msn.Value+"',addr2='"+addr2.Value+"',tel2='"+tel2.Value+"' where LanauageId=" + Request["lan"];
        try
        {
            osdData.ExecuteNonQuery(sql);
            Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"修改成功！\");location.href=\"information.aspx?lan="+Request["lan"]+"\";</script>");
        }
        catch (Exception ee)
        {
            ee.ToString();
            
            Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"修改失败！\")</script>");
        }
    }
}



