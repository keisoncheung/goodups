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
using System.IO;
using System.Drawing;

public partial class manager_form_fy_main : System.Web.UI.Page
{
    public float ss;
    public int tt;
    protected void Page_Load(object sender, EventArgs e)
    {  
        string username = "";
        //try
        //{
        //    username = Session["admin"].ToString();
        //}
        //catch
        //{
        //    Response.Redirect("login.aspx");
        //    return;
        //}
        //string path = Server.MapPath("~");
        //float cc = GetDirectoryLength(path);
        //cc = cc / 1024;
        //Label2.Text = cc.ToString() + "KB";
        //string size = ConfigurationSettings.AppSettings["roomsize"];
        //lblsize.Text = size.ToString() + "M";
        //int dd = Convert.ToInt32(size);
        //img2.ImageUrl = "bgpic/loadingmid.gif";
        //ss = (cc / (dd * 1024));
        //tt = Convert.ToInt32(ss * 425);
        //img2.Width = tt;
        //lblbai.Text = Convert.ToInt32(ss * 100) + "%";

    }

    //public long GetDirectoryLength(string dirPath)
    //{
        //if (!Directory.Exists(dirPath))
        //    return 0;
        //long len = 0;
        //DirectoryInfo di = new DirectoryInfo(dirPath);
        //foreach (FileInfo fi in di.GetFiles())
        //{
        //    len += fi.Length;
        //}
        //DirectoryInfo[] dis = di.GetDirectories();
        //if (dis.Length > 0)
        //{
        //    for (int i = 0; i < dis.Length; i++)
        //    {
        //        len += GetDirectoryLength(dis[i].FullName);
        //    }
        //}
        //return len;
    //}
}
