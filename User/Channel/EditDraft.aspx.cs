using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Channel_EditDraft : System.Web.UI.Page
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
        ViewState["chid"] = Request.QueryString["chid"];
        artid = Convert.ToInt32(Request.QueryString["artid"]);
        if (cookie == null)
        {
            Response.Redirect("../../RegisterLogin/Login.aspx");
        }
        if (!this.IsPostBack)
        {
            this.loadData();
        }
    }

    private void loadData()
    {
        cmd = new SqlCommand("SELECT [artid] ,[cid] ,[chid] ,[heading] ,[thumbnail] ,[articlebody] ,[createdon] FROM [dbo].[draftarticle] where artid=@artid", c.conn);
        cmd.Parameters.AddWithValue("@artid", Request.QueryString["artid"]);
        c.Retrieve(cmd);
        while (c.dr.Read())
        {
            CKEditor1.Text = Convert.ToString(c.dr["articlebody"]);
            txtHeading.Text = Convert.ToString(c.dr["heading"]);
            DropDownCategory.SelectedValue = Convert.ToString(c.dr["cid"]);
            if (Convert.ToString(c.dr["thumbnail"]) != "")
            {
                Image1.ImageUrl = Convert.ToString("~/images/articles/articleImage/" + c.dr["thumbnail"]);
            }
            ViewState["thumbnail"] = c.dr["thumbnail"];
        }
        c.dr.Close();
    }

    protected void btnUpdateDraft_Click(object sender, EventArgs e)
    {
        if (fuThumbnail.HasFile)
        {

            UpdateOnlyData();
            saveImage();
            //UpdateImageData();
        }
        else
        {
            UpdateOnlyData();
        }
        Response.Redirect("DraftArticles.aspx?ChId=" + Request.QueryString["chid"]);
    }

    private void UpdateOnlyData()
    {
        cmd = new SqlCommand("UPDATE[dbo].[draftarticle] SET cid = @cid,heading = @heading ,thumbnail = @thumbnail,articlebody = @articlebody WHERE artid=@artid", c.conn);
        cmd.Parameters.AddWithValue("@heading", txtHeading.Text.Trim());
        cmd.Parameters.AddWithValue("@articlebody", CKEditor1.Text);
        cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(DropDownCategory.SelectedValue));
        cmd.Parameters.AddWithValue("@thumbnail", ViewState["thumbnail"]);
        cmd.Parameters.AddWithValue("@artid", Request.QueryString["artid"]);
        c.Update(cmd);
        
    }

    protected void btnPublish_Click(object sender, EventArgs e)
    {
        if (fuThumbnail.HasFile)
        {
            insertData();
            saveImage();
            insertImageData();
        }
        else
        {
            insertOnlyData();
        }
        DeleteFmDraft();
        Response.Redirect("AllArticles.aspx?ChId=" + ViewState["chid"]);
    }

    private void DeleteFmDraft()
    {
        try
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            string query = "DELETE FROM  [dbo].[draftarticle] WHERE artid=@artid";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@artid", Request.QueryString["artid"]);
            cmd.ExecuteNonQuery();
            if (c.conn.State == ConnectionState.Open)
            {
                c.conn.Close();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void insertOnlyData()
    {
        try
        {
            if (c.conn.State != ConnectionState.Open)
            {
                c.conn.Open();
            }
            cmd = new SqlCommand("INSERT INTO [dbo].[article] ([chid] ,[cid] , [heading] ,[articlebody] ,[postedon] ,[likes] ,[dislikes] ,[views],[thumbnail]) VALUES (@chid,@cid,@heading,@articlebody,@postedon,@likes,@dislikes,@views,@thumbnail)", c.conn);
            cmd.Parameters.AddWithValue("@heading", txtHeading.Text.Trim());
            cmd.Parameters.AddWithValue("@articlebody", CKEditor1.Text);
            cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(DropDownCategory.SelectedValue));
            cmd.Parameters.AddWithValue("@chid", Convert.ToInt32(ViewState["chid"]));
            cmd.Parameters.AddWithValue("@thumbnail", ViewState["thumbnail"]);
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
            cmd.Parameters.AddWithValue("@chid", Convert.ToInt32(ViewState["chid"]));
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
                    fuArImageName = Convert.ToString("d"+artid);
                    fuArImageNameExtension = Path.GetExtension(fuThumbnail.PostedFile.FileName);
                    fuThumbnail.SaveAs(Server.MapPath(" ../../images/articles/articleImage/") + fuArImageName + fuArImageNameExtension);
                    //fuThumbnail.SaveAs(Server.MapPath(" ../../images/articles/articleImage/") + fuArImageName + ".jpg");
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
    }


    protected void btnPreview_Click(object sender, EventArgs e)
    {

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            string query = "DELETE FROM  [dbo].[draftarticle] WHERE artid=@artid";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@artid", Request.QueryString["artid"]);
            cmd.ExecuteNonQuery();
            if (c.conn.State == ConnectionState.Open)
            {
                c.conn.Close();
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
}
}
