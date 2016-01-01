using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class manager_pictures : System.Web.UI.Page
{
    System.Drawing.Image.GetThumbnailImageAbort callb = null;
    System.Drawing.Image image, newimage;
    public string imagename1, newName, newNamed;
    public string pic2;
    private string id;
    public int xswz;
    public string lan = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Request["id"] != null)
            {
                id = Request["id"].ToString();
                cstype();
                csh();

            }
            else
            {
                pic2 = "<img src=../upfile/nopic.gif width='130px'>";
                cstype();
            }
        }
    }

    //初始化类别
    private void cstype()
    {
        string sql = null;
        sql = "select * from Article";
        drtype.DataSource = osdData.DataSet(sql);
        drtype.DataTextField = "title";
        drtype.DataValueField = "id";
        drtype.DataBind();
        drtype.Items.Insert(0, "--请选择--");
        drtype.Items[0].Value = "0";
    }

    //上传图片
    private int shang()
    {
        Random rn = new Random();
        int n = 0;
        n = rn.Next(1000, 9999);
        return n;
    }

    private string upfile(HtmlInputFile file)
    {
        string mPath;
        if ("" != file.PostedFile.FileName)
        {
            string imagePath = file.PostedFile.FileName;
            string imageType = imagePath.Substring(imagePath.LastIndexOf(".") + 1);
            string imageName = imagePath.Substring(imagePath.LastIndexOf("\\") + 1);
            imagename1 = DateTime.Now.ToString("yyyyMMddhhmmss") + shang() + "." + imageType;
            if ("jpg" != imageType && "gif" != imageType && "JPG" != imageType && "GIF" != imageType)
            {
                Response.Write("<script language='javascript'> alert('对不起！请您选择jpg或者gif格式的图片！');</script>");
                return "";
            }
            else
            {
                try
                {
                    mPath = Server.MapPath("~") + "\\upfile\\";
                    file.PostedFile.SaveAs(mPath + "\\" + imagename1);
                    //image = System.Drawing.Image.FromFile(mPath + "\\" + imagename1);
                    //int width = image.Width;
                    //int swidth = 230;
                    //int height = image.Height;
                    //int sheight = 157;
                    //newimage = image.GetThumbnailImage(swidth, sheight, callb, new System.IntPtr());
                    //newimage.Save(mPath + "\\s" + imagename1, image.RawFormat);//图片名字－－s+name.jpg
                    //image.Dispose();
                    //newimage.Dispose();
                    //newNamed = imagename1;
                    return imagename1;
                }
                catch (Exception ee)
                {
                    ee.ToString();
                    return "";

                }
            }
        }
        else
        {
            return "";
        }
    }

    private string simage(string file)
    {

        try
        {
            string mPath = Server.MapPath("~") + "\\upfile\\";
            //image = System.Drawing.Image.FromFile(mPath + "\\" + file);
            //int width = image.Width;
            //int swidth = 230;
            //int height = image.Height;
            //int sheight = 157;
            //newimage = image.GetThumbnailImage(swidth, sheight, callb, new System.IntPtr());
            ImageThumbnail.MakeThumbnail(mPath + "\\" + file, mPath + "\\s" + file, 275, 296, "W", System.Drawing.Imaging.ImageFormat.Jpeg);
            //newimage.Save(mPath + "\\s" + file, image.RawFormat);//图片名字－－s+name.jpg
            //image.Dispose();
            //newimage.Dispose();
            //newNamed = file;
            newName = "s" + file;
            return newName;
        }
        catch (Exception ee)
        {
            ee.ToString();
            return "";

        }
    }

    //修改页面
    public void csh()
    {
        string str = null;
        string sql = "select id,spic,parid from Article_pic where id=" + id;
        try
        {

            DataTable dt = new DataTable();
            dt = osdData.DataSet(sql).Tables[0];
            foreach (DataRow or in dt.Select())
            {
                pic2 = "<img src='../upfile/" + or["spic"].ToString() + "' border=0 width=100 height=100>";
                drtype.SelectedValue = Convert.ToString(or["parid"]);
            }
            dt.Dispose();
        }
        catch (Exception rr)
        {
            this.Response.Write(rr.ToString());
        }
    }


    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        string sql = null;
        int scp1;
        string type = null;
        string bpic = upfile(File1);
        string spic = "";
        if (drtype.SelectedValue != "0")
        {
            if (bpic.Length > 1)
            {
                spic = simage(bpic);

                if (Request["id"] != null)
                {
                    sql = "update Article_pic set pic='" +
                        bpic + "',spic='" + spic + "',parid='" + drtype.SelectedValue + "' where id=" + Request["id"] + "";
                    if (Public.Igs(sql))
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"资料修改成功！\");location.href=\"./picturelist.aspx?type=" + drtype.SelectedValue + "&ac=产品管理\";</script>");
                    }
                    else
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"资料修改失败！\");</script>");
                    }
                }
                else
                {
                    sql = "insert into Article_pic (pic,spic,parid) values('" + bpic + "','" + spic + "','" + drtype.SelectedValue + "')";

                    if (Public.Igs(sql))
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"资料添加成功！\");location.href=\"./picturelist.aspx?type=" + drtype.SelectedValue + "&ac=产品管理\";</script>");
                    }
                    else
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"资料修改失败！\");</script>");
                    }
                }
            }
            else
            {
                if (Request["id"] != null)
                {
                    sql = "update Article_pic set parid='" + drtype.SelectedValue + "' where id=" + Request["id"] + "";
                    if (Public.Igs(sql))
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"资料修改成功！\");location.href=\"./picturelist.aspx?type=" + drtype.SelectedValue + "&ac=产品管理\";</script>");
                    }
                    else
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"资料修改失败！\");</script>");
                    }
                }
                else
                {
                    sql = "insert into Article_pic(pic,spic,parid) values('nopic.gif ','nopic.gif ','" + drtype.SelectedValue + "')";

                    if (Public.Igs(sql))
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"资料添加成功！\");location.href=\"./picturelist.aspx?type="+drtype.SelectedValue+"&ac=产品管理\";</script>");
                    }
                    else
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"资料修改失败！\");</script>");
                    }
                }

            }
        }
        else
        {
            Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"请选择类别！\");</script>");
        }

    }
}
