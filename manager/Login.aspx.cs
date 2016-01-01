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

public partial class manager_form_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //检查登陆信息
    public string Check(string code, string pwd, string ip)
    {
        string ss = null;
        string sql = null;
        string time = DateTime.Now.ToString();
        try
        {
            //判断是否存在用户, ss=1用户不存在
            sql = "select password from admin where name='" + code + "'";
            ss = osdData.Executescalar(sql).ToString();
            if (!ss.Equals(pwd))
            {
                ss = "2";
                sql = "insert into login (admmin,ip,addtime,type)values('" + code + "','" + ip + "','" + time + "',2)";
                osdData.ExecuteNonQuery(sql);
            }
            else
            {
                //成功登陆
                sql = "insert into login (admin,ip,addtime,type)values('" + code + "','" + ip + "','" + time + "',1)";
                osdData.ExecuteNonQuery(sql);
                ss = "3";
            }
        }
        catch (Exception ee)
        {
            ee.ToString();
            ss = "1";
        }
        return ss;
    }

    protected void Image1_ServerClick1(object sender, ImageClickEventArgs e)
    {
        //获得用户ip地址
        string ip = Request.UserHostAddress.ToString();
        string pwd = this.txtpwd.Value;
        //检索用户信息，并返回值
        string msg = Check(this.txtname.Value.ToString(), pwd, ip);
        //检索验证码
        if (this.txtcode.Value.Equals(Session["CheckCode"] + ""))
        {
            if (msg.Equals("1"))
            {
                this.Label1.Text = "系统提示：您输入的用户名错误，请重新输入！";
            }
            if (msg.Equals("2"))
            {
                this.Label1.Text = "系统提示：您输入的密码错误，请重新输入！";
            }
            if (msg.Equals("3"))
            {
                Session["admin"] = this.txtname.Value.ToString();
                //赋值IP
                Session["userip"] = ip;
                string sql = "select kuai from admin where name ='" + Session["admin"].ToString() + "'";
                Session["kuai"] = osdData.Executescalar(sql).ToString();
                Response.Redirect("form.aspx");
            }
        }
        else
        {
            this.Label1.Text = "系统提示：您输入的验证码错误，请重新输入！";
        }
    }
}

