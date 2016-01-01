using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

/// <summary>
/// Public 的摘要说明
/// </summary>
public class Public
{
    public Public()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    //文章
    public static string Article(string aid)
    {
        return osdData.Executescalar("select content from Article where id=" + aid) + "";
    }
    //HTML过滤
    public static string WipeScript(string str)
    {
        str = System.Text.RegularExpressions.Regex.Replace(str, "<[^>]*>", "");
        str = str.Replace("&nbsp;", "");
        return str;
    }
    public static string Hearder(int language)
    {

        StringBuilder sbr = new StringBuilder();
        DataTable dt = osdData.DataSet("select name1,copyright,keyword,Description,author from Information where LanauageId=" + language).Tables[0];
        foreach (DataRow or in dt.Select())
        {
            sbr.Append("<title>" + or["name1"].ToString() + "" + or["keyword"].ToString() + "</title>");
            sbr.Append("<meta http-equiv='content-type' content='text/html;charset=gb2312'>\r");
            sbr.Append("<META content=" + or["Description"].ToString() + " name='Description'>\r");
            sbr.Append("<META content=" + or["keyword"].ToString() + " name='keywords'>\r");
            sbr.Append("<META content=" + or["author"].ToString() + " name='author'>\r");
            sbr.Append("<META content=" + or["copyright"].ToString() + " name='Copyright'>\r");
        }
        return sbr.ToString();

    }

    //返回bool类型
    public static bool Igs(string sql)
    {
        bool b = false;
        try
        {
            osdData.ExecuteNonQuery(sql);
            b = true;
        }
        catch (Exception ee)
        {
            ee.ToString();
            b = false;
        }
        return b;
    }


    public static string Title(string stit)//标题
    {
        string strbt = null;
        switch (stit + "")
        {
            case "1":
                strbt = "公司简介";
                break;
            case "2":
                strbt = "技术设备";
                break;
            case "3":
                strbt = "联系我们";
                break;
        }
        return strbt;
    }

    public static string eTitle(string stit)//英文标题
    {
        string strbt = null;
        switch (stit + "")
        {
            case "1":
                strbt = "AboutUs";
                break;
            case "2":
                strbt = "equipment";
                break;
            case "3":
                strbt = "ContactUs";
                break;
        }
        return strbt;
    }

}
