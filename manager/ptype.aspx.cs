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

public partial class manager_ptype : System.Web.UI.Page
{
    public Public pc = new Public();
    private int readp = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ViewState["currentp"] = 1;
            if (Request["lan"] != null && Request["id"] != null)
            {
 
            }
            else if (Request["id"] != null)
            {
                csh();
            }
        }
    }

    ////初始化类别
    //private void cstype()
    //{
    //    string sql = null;
    //    sql = "select * from productType where id=" + Request["id"];
    //    drtype.DataSource = osdData.DataSet(sql);
    //    drtype.DataTextField = "ClsName";
    //    drtype.DataValueField = "id";
    //    drtype.DataBind();
    //}


    //修改页面
    public void csh()
    {
        string str = null;
        string sql = "select id,clsname,sortid from productType where id=" + Request["id"];
        try
        {

            DataTable dt = new DataTable();
            dt = osdData.DataSet(sql).Tables[0];
            foreach (DataRow or in dt.Select())
            {
                tb1.Text = Convert.ToString(or["clsname"]);
                txtsorid.Text = Convert.ToString(or["sortid"]);
            }
            dt.Dispose();
        }
        catch (Exception rr)
        {
            this.Response.Write(rr.ToString());
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("protype.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        StringBuilder sbr = new StringBuilder();
        string sql = "";
        DataTable dt = new DataTable();
        if (Request["lan"] != null && Request["id"] != null)
        {
            sql = "insert into productType(clsname,languageId,parid,SortId)values('" + tb1.Text + "','" + Request["lan"] + "','" + Request["id"] + "','"+txtsorid.Text.Trim()+"')";
            try
            {
                osdData.ExecuteNonQuery(sql);
                Messages.ConfirmMessageBox("protype.aspx","添加成功");
            }
            catch (Exception ee)
            {
                Messages.Message("添加失败");
            }
        }
        else if (Request["lan"] != null)
        {
            sql = "insert into productType(clsname,languageId,parid,sortid)values('" + tb1.Text + "','" + Request["lan"] + "',0,'"+txtsorid.Text.Trim()+"')";
            try
            {
                osdData.ExecuteNonQuery(sql);
                Messages.ConfirmMessageBox("protype.aspx", "添加成功");
            }
            catch (Exception ee)
            {
                Messages.Message("添加失败");
            }

        }
        else
        {
            sql = "update productType set clsname='" + tb1.Text + "',sortid='"+txtsorid.Text.Trim()+"' where id=" + Request["id"];
            try
            {
                osdData.ExecuteNonQuery(sql);
                Messages.ConfirmMessageBox("protype.aspx", "添加成功");
            }
            catch (Exception ee)
            {
                Messages.Message("修改失败");
            }

        }
    }
}
