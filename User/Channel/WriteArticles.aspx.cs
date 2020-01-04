using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Channel_WriteArticles : System.Web.UI.Page
{
    string query2 = "Select @@Identity";
    Crud c = new Crud();
    //SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-RAJESH\SQLEXPRESS;Initial Catalog=YouPaper;Integrated Security=True");
    SqlCommand cmd = null;
    string fuArImageName = null;
    string fuArImageNameExtension = null;
    int artid;
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        if (cookie == null)
        {
            Response.Redirect("../../RegisterLogin/Login.aspx");
        }
        lblName.Text = Request.QueryString["ChName"];
        ViewState["CHID"] = Request.QueryString["ChId"];
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        string abc = CKEditor1.Text;
        Session["data"] = abc;
        Response.Write("<script>");
        Response.Write("window.open('ArticlePreview.aspx','_blank')");
        Response.Write("</script>");
    }

    protected void btnPublish_Click(object sender, EventArgs e)
    {
        insertData();
        saveImage();
        insertImageData();
        Response.Redirect("AllArticles.aspx?ChId=" + ViewState["CHID"]);
    }

    private void insertData()
    {
        try
        {
            if (c.conn.State != ConnectionState.Open)
            {
                c.conn.Open();
            }
            cmd = new SqlCommand("INSERT INTO [dbo].[article] ([chid] ,[cid] , [heading] ,[articlebody] ,[postedon] ,[likes] ,[dislikes] ,[views]) VALUES (@chid,@cid,@heading,@articlebody,@postedon,@likes,@dislikes,@views)", c.conn);
            cmd.Parameters.AddWithValue("@heading", txtHeading.Text.Trim());
            cmd.Parameters.AddWithValue("@articlebody", CKEditor1.Text);
            cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(DropDownCategory.SelectedValue));
            cmd.Parameters.AddWithValue("@chid", Convert.ToInt32(ViewState["CHID"]));
            cmd.Parameters.AddWithValue("@postedon", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@likes", 0);
            cmd.Parameters.AddWithValue("@dislikes", 0);
            cmd.Parameters.AddWithValue("@views", 0);
            int i = cmd.ExecuteNonQuery();
            cmd.CommandText = query2;
            artid = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            c.conn.Close();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    private void saveImage()
    {
        try
        {
            if (fuThumbnail.HasFile)
            {
                try
                {
                    fuArImageName = Convert.ToString(artid);
                    fuArImageNameExtension = Path.GetExtension(fuThumbnail.PostedFile.FileName);
                    fuThumbnail.SaveAs(Server.MapPath(" ../../images/articles/articleImage/") + fuArImageName + fuArImageNameExtension);
                    //uploadImage(fuChImageName, fuChImageNameExtension);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void insertImageData()
    {
        cmd = new SqlCommand("UPDATE article SET thumbnail = @thumbnail WHERE artid=@artid", c.conn);
        cmd.Parameters.AddWithValue("@artid", artid);
        cmd.Parameters.AddWithValue("@thumbnail", fuArImageName + fuArImageNameExtension);
        c.Update(cmd);
        //try
        //{
        //    if (conn.State != ConnectionState.Open)
        //    {
        //        conn.Open();
        //    }
        //    cmd = new SqlCommand("UPDATE article SET thumbnail = @thumbnail WHERE artid=@artid", conn);
        //    cmd.Parameters.AddWithValue("@artid", artid);
        //    cmd.Parameters.AddWithValue("@thumbnail", fuArImageName + fuArImageNameExtension);
        //    int i = cmd.ExecuteNonQuery();
        //    conn.Close();
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/User/Channel/ChannelPage.aspx?chid=" + ViewState["CHID"]);
    }

    protected void btnDraft_Click(object sender, EventArgs e)
    {
        insertDraftData();
        saveDraftImage();
        insertDraftImageData();
        Response.Redirect("DraftArticles.aspx?ChId=" + ViewState["CHID"]);

    }

    private void insertDraftData()
    {
        try
        {
            if (c.conn.State != ConnectionState.Open)
            {
                c.conn.Open();
            }
            cmd = new SqlCommand("INSERT INTO [dbo].[draftarticle] ([chid] ,[cid] , [heading] ,[articlebody] ,[createdon]) VALUES (@chid,@cid,@heading,@articlebody,@createdon)", c.conn);
            cmd.Parameters.AddWithValue("@heading", txtHeading.Text.Trim());
            cmd.Parameters.AddWithValue("@articlebody", CKEditor1.Text);
            cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(DropDownCategory.SelectedValue));
            cmd.Parameters.AddWithValue("@chid", Convert.ToInt32(ViewState["CHID"]));
            cmd.Parameters.AddWithValue("@createdon", System.DateTime.Now);
            int i = cmd.ExecuteNonQuery();
            cmd.CommandText = query2;
            artid = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            c.conn.Close();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    private void saveDraftImage()
    {
        try
        {
            if (fuThumbnail.HasFile)
            {
                try
                {
                    fuArImageName = Convert.ToString("d"+artid);
                    fuArImageNameExtension = Path.GetExtension(fuThumbnail.PostedFile.FileName);
                    fuThumbnail.SaveAs(Server.MapPath(" ../../images/articles/articleImage/") + fuArImageName + fuArImageNameExtension);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void insertDraftImageData()
    {
        cmd = new SqlCommand("UPDATE draftarticle SET thumbnail = @thumbnail WHERE artid=@artid", c.conn);
        cmd.Parameters.AddWithValue("@artid", artid);
        cmd.Parameters.AddWithValue("@thumbnail", fuArImageName + fuArImageNameExtension);
        c.Update(cmd);
        //try
        //{
        //    if (conn.State != ConnectionState.Open)
        //    {
        //        conn.Open();
        //    }
        //    cmd = new SqlCommand("UPDATE draftarticle SET thumbnail = @thumbnail WHERE artid=@artid", conn);
        //    cmd.Parameters.AddWithValue("@artid", artid);
        //    cmd.Parameters.AddWithValue("@thumbnail", fuArImageName + fuArImageNameExtension);
        //    int i = cmd.ExecuteNonQuery();
        //    conn.Close();
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }
}