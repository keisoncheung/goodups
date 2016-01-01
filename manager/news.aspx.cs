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

public partial class manager_news : System.Web.UI.Page
{
    System.Drawing.Image.GetThumbnailImageAbort callb = null;
    System.Drawing.Image image, newimage;
    public string imagename1, newName, newNamed, newName2, newName3, newName4;
    public string pic2;
    private string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            id = Request["id"].ToString();
        }
        else
        {
            pic2 = "<img src=../pic/nopic.jpg width='130px'>";
        }        
        if (!IsPostBack)
        {
            if (Request["id"] != null)
            {
                id = Request["id"].ToString();
                cstype();
                csh();
            }
            else
            {
                cstype();
                txtcreatetime.Text = DateTime.Now.ToString();
            }
        }
        
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
                    mPath = Server.MapPath("~") + "\\pic\\";
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
        int x=160;
        int y=111;
       
        try
        {
            string mPath = Server.MapPath("~") + "\\pic\\";

            System.Drawing.Image image = System.Drawing.Image.FromFile(mPath + "\\" + file);
            int width = image.Width;
            int height = image.Height;
            image.Dispose();

            double FrameworkProportion = x / y;
            double ImgeProportion = Convert.ToDouble(width) / Convert.ToDouble(height);
            if (FrameworkProportion >= ImgeProportion)
            {
                ImageThumbnail.MakeThumbnail(mPath + file, mPath + "s" + file, Convert.ToInt32(x), Convert.ToInt32(y), "H", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                ImageThumbnail.MakeThumbnail(mPath + file, mPath + "s" + file, Convert.ToInt32(x), Convert.ToInt32(y), "W", System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            string newName = "s" + file;
            return newName;
        }
        catch (Exception ee)
        {
            ee.ToString();
            return "";

        }
    }

    //初始化类别
    private void cstype()
    {
        string artbtype = null;
        if (Request["id"] != null)
        {
            artbtype = " where id in(select ParId from News where id=" + Request["id"] + ")";
        }

        else if (Request["type"] != null)
        {
            artbtype = " where id=" + Request["type"] + "";

        }
        else
        {
            artbtype = "";
        }
        DataTable dt = new DataTable();
        dt = osdData.DataSet("select id, clsname from languageId").Tables[0];
        rbl.DataSource = dt;
        rbl.DataTextField = "clsname";
        rbl.DataValueField = "id";
        rbl.DataBind();
        rbl.Items[0].Selected = true;


        string sql = "select ID,ClsName1 from NewType" + artbtype;
        artbtype = osdData.Executescalar(sql).ToString();
        ddl1.DataSource = osdData.DataSet(sql);
        ddl1.DataTextField = "ClsName1";
        ddl1.DataValueField = "ID";
        ddl1.DataBind();
        ddl1.Items.Insert(0, "--请选择--");
        ddl1.Items[0].Value = "0";
    }

    //修改页面
    public void csh()
    {
        string str = null;
        string sql = "select Id,Title,Content,ParId,languageId,intro,EditDate,IsHot,newsKW from News where ID=" + id;
        try
        {
            DataTable dt = osdData.DataSet(sql).Tables[0];
            foreach (DataRow or in dt.Select())
            {
                rbl.SelectedValue = Convert.ToString(or["languageId"]);
                txttitle.Value = Convert.ToString(or["Title"]);
                intro.Text = Convert.ToString(or["intro"]);
                txtcreatetime.Text = Convert.ToString(or["EditDate"]);
                FreeTextBox1.Text = Convert.ToString(or["Content"]);
                ddl1.SelectedValue = Convert.ToString(or["ParId"]);
                txtkw.Value = or["newsKW"].ToString();
                if (Convert.ToString(or["IsHot"]) == "1")
                {
                    sfzd.Checked = true;
                }
                else
                {
                    sfzd.Checked = false;
                }

            }
        }
        catch (Exception rr)
        {
            rr.ToString();
        }
    }

    //返回bool类型
    public bool Igs(string sql)
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


    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        string sql = null;
        string bpic = upfile(File1);
        string spic="";
        string ss = FreeTextBox1.Text.Replace("'", "''");
        if (ss.IndexOf("'") > 0)
        {
            ss = ss.Replace("'", "''");
        }
        int sfhot;
        if (sfzd.Checked == true)
        {
            sfhot = 1;
        }
        else
        {
            sfhot = 0;
        }

        if (ddl1.SelectedValue != "0")
        {
            if (bpic.Length > 1)
            {
                spic = simage(bpic);

                if (Request["id"] != null)
                {
                    sql = "update News set Title='" + txttitle.Value + "',Content='" + ss + "', ParId ='" + ddl1.SelectedValue + "',intro='" + intro.Text + "',LanguageId='" + rbl.SelectedValue + "',picture='" + bpic + "',IsHot='" + sfhot + "',linkpic='" + spic + "',EditDate='" + txtcreatetime.Text + "',newsKW='"+txtkw.Value+"' where ID=" + Request["id"].ToString() + "";

                    //string leib = null;
                    //osdReader or = new osdReader("select parId from news where id=" + Request["id"] + "");
                    //while (or.Read())
                    //{
                    //    leib = Convert.ToString(or["ParId"]);
                    //}
                    //or.Close();
                    if (Igs(sql))
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"修改成功！\");location.href=\"./newsshow.aspx?type=" + ddl1.SelectedValue + "&lan=" + rbl.SelectedValue + "&ac=新闻管理咨询\";</script>");
                    }
                    else
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"修改失败！\");</script>");
                    }
                }
                else
                {
                    sql = "insert into News(Title,Content,CreateDate,ParId,IsShow,LanguageId,picture,linkpic,intro,EditDate,ishot,newsKW) values('" + txttitle.Value + "','" + ss + "','" + DateTime.Now.ToString() + "','" + ddl1.SelectedValue + "',1,'" + rbl.SelectedValue + "','" + bpic + "','" + spic + "','" + intro.Text + "','" + txtcreatetime.Text + "','" + sfhot + "','"+txtkw.Value+"')";

                    if (Igs(sql))
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"添加成功！\");location.href=\"./newsshow.aspx?type=" + ddl1.SelectedValue + "&lan=" + rbl.SelectedValue + "&ac=新闻管理咨询\";</script>");
                    }
                    else
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"添加失败！\");</script>");

                    }
                }
            }
            else
            {
                if (Request["id"] != null)
                {
                    sql = "update News set Title='" + txttitle.Value + "',Content='" + ss + "', ParId ='" + ddl1.SelectedValue + "',intro='" + intro.Text + "',LanguageId='" + rbl.SelectedValue + "',IsHot='" + sfhot + "',EditDate='" + txtcreatetime.Text + "',newsKW='"+txtkw.Value+"' where ID=" + Request["id"].ToString() + "";

                    //string leib = null;
                    //osdReader or = new osdReader("select parId from news where id=" + Request["id"] + "");
                    //while (or.Read())
                    //{
                    //    leib = Convert.ToString(or["ParId"]);
                    //}
                    //or.Close();
                    if (Igs(sql))
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"修改成功！\");location.href=\"./newsshow.aspx?type=" + ddl1.SelectedValue + "&lan=" + rbl.SelectedValue + "&ac=新闻管理咨询\";</script>");
                    }
                    else
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"修改失败！\");</script>");
                    }
                }
                else
                {
                    sql = "insert into News(Title,Content,CreateDate,ParId,IsShow,LanguageId,intro,EditDate,ishot,newsKW) values('" + txttitle.Value + "','" + ss + "','" + DateTime.Now.ToString() + "','" + ddl1.SelectedValue + "',1," + rbl.SelectedValue + ",'" + intro.Text + "','" + txtcreatetime.Text + "','" + sfhot + "','"+txtkw.Value+"')";

                    if (Igs(sql))
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"添加成功！\");location.href=\"./newsshow.aspx?type=" + ddl1.SelectedValue + "&lan=" + rbl.SelectedValue + "&ac=新闻管理咨询\";</script>");
                    }
                    else
                    {
                        Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"添加失败！\");</script>");

                    }
                }
 
            }
        }
        else
        {
            Response.Write("<script LANGUAGE=\"JavaScript\">alert(\"请选择类别！\");</script>");

        }
    }
    protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            Response.Redirect("newsshow.aspx?lan=" + rbl.SelectedValue + "&type=" + ddl1.SelectedValue + "");
        }
        else
        {
            Response.Redirect("newsshow.aspx");
        }

    }
}