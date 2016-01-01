using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;

public partial class mar : System.Web.UI.MasterPage
{
    public string tel, fax, email, qq, msn, skype, lxr, addr, mobilep,addr2,tel2,beian,name2;
    protected void Page_Load(object sender, EventArgs e)
    {
        ContactUs();
    }

    public string headKeyWord()
    {
        return osdData.Executescalar("select canshu from article2 where id=7") + "";
    }


    public void ContactUs()//联系我们
    {
        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select * from Information where LanauageId=1").Tables[0];
        foreach (DataRow dr in dt.Select())
        {
            tel = "公司电话："+Convert.ToString(dr["tel"]);
            tel2 = "工厂电话：" + Convert.ToString(dr["tel2"]);
            addr = "公司地址：" + Convert.ToString(dr["addr"]);
            addr2 = "工厂地址：" + Convert.ToString(dr["addr2"]);
            qq = "" + Convert.ToString(dr["qq"]);
            lxr = Convert.ToString(dr["email"]);
            mobilep = "" + Convert.ToString(dr["mobilep"]);
            email = "公司邮箱：" + Convert.ToString(dr["email"]);
            beian = Convert.ToString(dr["beian"]);
            name2 =  Convert.ToString(dr["name2"]);
        }

    }


    public string protype() 
    {
        StringBuilder sbr = new StringBuilder();
        string sql = "select id,clsname from languageId";
        DataTable dt = new DataTable();
        dt = osdData.DataSet(sql).Tables[0];

        dt = osdData.DataSet("select id,clsname,languageId,Parid,sortid from productType where parid=0 and languageId=1  order by sortid desc").Tables[0];
        foreach (DataRow dr2 in dt.Select())
        {
            sbr.Append("<A href='product.aspx?btype="+dr2["id"]+"'>"+dr2["clsname"]+"</A><IMG src='images/line_y_top_menu.gif'> "); 

        }
        return sbr.ToString();
    }

}
