using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewArticle : System.Web.UI.Page
{
    int incView, incLike, incDislike;
    string flagLD;
    Crud c = new Crud();
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Request.QueryString["artID"] == "")
            {
                Response.Redirect("ArticleNotFound.aspx");
            }

            string checkarticle = "select count(*) from [dbo].[article] where artid='" + Request.QueryString["artID"] + "'";
            int temp = c.getCount(checkarticle);
            if (temp == 0)
            {
                Response.Redirect("ArticleNotFound.aspx");
            }
            else
            {
                this.LoadArticle();
                this.IncView();
            }
            HttpCookie cookie = Request.Cookies["userinfo"];
            if (cookie != null)
            {
                loadReactionData();
                LoadUserSubscribeStatus();
            }
        }
        loadSideArticles();
        loadComments();
    }

    private void LoadUserSubscribeStatus()
    {
        cmd = new SqlCommand("SELECT count(*) FROM [dbo].[subscribers] where uid=@uid and chid=@chid", c.conn);
        HttpCookie cookie = Request.Cookies["userinfo"];
        cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
        cmd.Parameters.AddWithValue("@chid", ViewState["chid"]);
        int i = c.getCount(cmd);
        if (i == 1)
        {
            btnSubscribe.Text = "Subscribed";
        }
        else
        {
            btnSubscribe.Text = "Subscribe";
        }
    }

    private void loadComments()
    {
        try
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            string query = "select comments.comment,comments.postedon,userprofile.uname,userprofile.uid from comments inner join userprofile on comments.uid=userprofile.uid where artid=@artid ORDER BY postedon DESC;";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@artid", Request.QueryString["artID"]);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            rptComments.DataSource = ds.Tables[0];
            rptComments.DataBind();
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

    private void loadSideArticles()
    {
        try
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            string query = "SELECT [article].[artid] ,[article].[chid] ,[article].[cid] ,[article].[heading] ,[article].[articlebody] ,[article].[thumbnail] ,[article].[postedon] ,[article].[likes] ,[article].[dislikes] ,[article].[views],[channel].[chname],[channel].[chimage] from article inner join channel on article.chid=channel.chid";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            rptSideArticle.DataSource = ds.Tables[0];
            rptSideArticle.DataBind();
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

    private void IncView()
    {
        cmd = new SqlCommand("UPDATE article SET views = @views WHERE artid=@artid", c.conn);
        cmd.Parameters.AddWithValue("@views", Convert.ToInt32(incView + 1));
        cmd.Parameters.AddWithValue("@artid", Request.QueryString["artID"]);
        c.Update(cmd);
    }

    private void LoadArticle()
    {
        cmd = new SqlCommand("SELECT [article].[artid] ,[article].[chid] ,[article].[cid] ,[article].[heading] ,[article].[articlebody] ,[article].[thumbnail] ,[article].[postedon] ,[article].[likes] ,[article].[dislikes] ,[article].[views],[channel].[chname],[channel].[chimage] from article inner join channel on article.chid=channel.chid WHERE artid=@artid", c.conn);
        cmd.Parameters.AddWithValue("@artid", Request.QueryString["artID"]);
        c.Retrieve(cmd);
        while (c.dr.Read())
        {
            ViewState["chid"] = Convert.ToString(c.dr["chid"]);
            lblMainBody.Text = Convert.ToString(c.dr["articlebody"]);
            if (Convert.ToString(c.dr["chimage"]) != "")
            {
                ImgChannel.ImageUrl = Convert.ToString("~/images/channel/images/" + c.dr["chimage"]);
            }
            //ImgChannel.ImageUrl = Convert.ToString("~/images/articles/articleImage/"+c.dr["chimage"]);
            lblHeading.Text = Convert.ToString(c.dr["heading"]);
            lblViews.Text = "views : " + Convert.ToString(c.dr["views"]);
            lblLike.Text = " " + Convert.ToString(c.dr["likes"]);
            lbldislike.Text = " " + Convert.ToString(c.dr["dislikes"]);
            lnkChannel.Text = Convert.ToString(c.dr["chname"]);
            incView = Convert.ToInt32(c.dr["views"]);
        }
        c.dr.Close();
    }

    private void loadReactionData()
    {
        cmd = new SqlCommand();
        cmd = new SqlCommand("SELECT [ldid] ,[uid] ,[artid] ,[reaction] FROM [dbo].[likedislike] WHERE uid=@uid and artid=@artid", c.conn);
        HttpCookie cookie = Request.Cookies["userinfo"];
        cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
        cmd.Parameters.AddWithValue("@artid", Request.QueryString["artID"]);
        c.Retrieve(cmd);
        while (c.dr.Read())
        {
            flagLD = Convert.ToString(c.dr["reaction"]);
            ViewState["flagLD"] = Convert.ToString(c.dr["reaction"]);
        }
        c.conn.Close();
        if (flagLD == "L")
        {
            like.Attributes.Add("style", "color:black;font-size: x-large;");
            dislike.Attributes.Add("style", "color:thistle;font-size: x-large;");
        }
        if (flagLD == "D")
        {
            dislike.Attributes.Add("style", "color:black;font-size: x-large;");
            like.Attributes.Add("style", "color:thistle;font-size: x-large;");
        }
    }

    protected void lnkLike_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        if (cookie == null)
        {
            Response.Redirect("PleaseRegister.aspx");
        }
        else
        {
            insertLike();
            like.Attributes.Add("style", "color:black;font-size: x-large;");
            dislike.Attributes.Add("style", "color:thistle;font-size: x-large;");
        }
        
    }

    private void insertLike()
    {
        flagLD = Convert.ToString(ViewState["flagLD"]);
        if (flagLD == "")
        {
            cmd = new SqlCommand("INSERT INTO [dbo].[likedislike] ([uid] ,[artid] ,[reaction]) VALUES (@uid,@artid,@reaction)", c.conn);
            HttpCookie cookie = Request.Cookies["userinfo"];
            cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
            cmd.Parameters.AddWithValue("@artid", Request.QueryString["artID"]);
            cmd.Parameters.AddWithValue("@reaction", "L");
            ViewState["flagLD"] = "L";
            c.Insert(cmd);
            updateArticleTable();
        }
        if (flagLD == "L")
        {

        }
        if (flagLD == "D")
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            cmd = new SqlCommand("UPDATE likedislike SET reaction = @reaction WHERE uid=@uid and artid=@artid", c.conn);
            HttpCookie cookie = Request.Cookies["userinfo"];
            cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
            cmd.Parameters.AddWithValue("@artid", Request.QueryString["artID"]);
            cmd.Parameters.AddWithValue("@reaction", "L");
            ViewState["flagLD"] = "L";
            int i = cmd.ExecuteNonQuery();
            i = 0;
            cmd = new SqlCommand("UPDATE article SET likes = likes + 1 , dislikes = dislikes - 1 where artid=@artid", c.conn);
            cmd.Parameters.AddWithValue("@artid", Request.QueryString["artID"]);
            i = cmd.ExecuteNonQuery();
            c.conn.Close();
            incDislike = Convert.ToInt32(lbldislike.Text);
            incLike = Convert.ToInt32(lblLike.Text);
            lbldislike.Text = Convert.ToString(Convert.ToInt32(incDislike - 1));
            lblLike.Text = Convert.ToString(Convert.ToInt32(incLike + 1));
        }
    }

    private void updateArticleTable()
    {
        cmd = new SqlCommand("UPDATE article SET likes = @likes WHERE artid=@artid", c.conn);
        cmd.Parameters.AddWithValue("@artid", Convert.ToInt32(Request.QueryString["artID"]));
        incLike = Convert.ToInt32(lblLike.Text);
        cmd.Parameters.AddWithValue("@likes", Convert.ToInt32(incLike + 1));
        lblLike.Text = Convert.ToString(Convert.ToInt32(incLike + 1));
        c.Update(cmd);
    }

    protected void lnkDislike_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        if (cookie == null)
        {
            Response.Redirect("PleaseRegister.aspx");
        }
        else
        {
            insertDislike();
            dislike.Attributes.Add("style", "color:black;font-size: x-large;");
            like.Attributes.Add("style", "color:thistle;font-size: x-large;");
        }
        
    }

    private void insertDislike()
    {
        flagLD = Convert.ToString(ViewState["flagLD"]);
        if (flagLD == "")
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            cmd = new SqlCommand("INSERT INTO [dbo].[likedislike] ([uid] ,[artid] ,[reaction]) VALUES (@uid,@artid,@reaction)", c.conn);
            HttpCookie cookie = Request.Cookies["userinfo"];
            cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
            cmd.Parameters.AddWithValue("@artid", Request.QueryString["artID"]);
            cmd.Parameters.AddWithValue("@reaction", "D");
            ViewState["flagLD"] = "D";
            int i = cmd.ExecuteNonQuery();
            c.conn.Close();
            updateArticleTableDislike();
        }
        if (flagLD == "L")
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            cmd = new SqlCommand("UPDATE likedislike SET reaction = @reaction WHERE uid=@uid and artid=@artid", c.conn);
            HttpCookie cookie = Request.Cookies["userinfo"];
            cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
            cmd.Parameters.AddWithValue("@artid", Request.QueryString["artID"]);
            cmd.Parameters.AddWithValue("@reaction", "D");
            ViewState["flagLD"] = "D";
            int i = cmd.ExecuteNonQuery();
            i = 0;
            cmd = new SqlCommand("UPDATE article SET likes = likes - 1 , dislikes = dislikes + 1 where artid=@artid", c.conn);
            cmd.Parameters.AddWithValue("@artid", Request.QueryString["artID"]);
            i = cmd.ExecuteNonQuery();
            c.conn.Close();
            incDislike = Convert.ToInt32(lbldislike.Text);
            incLike = Convert.ToInt32(lblLike.Text);
            lbldislike.Text = Convert.ToString(Convert.ToInt32(incDislike + 1));
            lblLike.Text = Convert.ToString(Convert.ToInt32(incLike - 1));
        }
        if (flagLD == "D")
        {

        }
    }

    private void updateArticleTableDislike()
    {
        cmd = new SqlCommand("UPDATE article SET dislikes = @dislikes WHERE artid=@artid", c.conn);
        cmd.Parameters.AddWithValue("@artid", Convert.ToInt32(Request.QueryString["artID"]));
        incDislike = Convert.ToInt32(lbldislike.Text);
        cmd.Parameters.AddWithValue("@dislikes", Convert.ToInt32(incDislike + 1));
        lbldislike.Text = Convert.ToString(Convert.ToInt32(incDislike + 1));
        c.Update(cmd);
    }

    protected void lnkReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportArticle.aspx?artID="+Request.QueryString["artID"]+"&title="+lblHeading.Text);
    }

    protected void lnkChannel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewChannel.aspx?chid="+ ViewState["chid"]);
    }

    protected void lBtnkChname_Click(object sender, EventArgs e)
    {
        string[] arguments = (((LinkButton)sender).CommandArgument).ToString().Split(',');
        string uid = Convert.ToString(arguments[0]);
        Response.Redirect("ViewProfile.aspx?uid=" + uid);
    }

    protected string Limit(object desc, int maxLength)
    {
        var description = (string)desc;
        if (string.IsNullOrEmpty(description)) { return description; }
        return description.Length <= maxLength ?
            description : description.Substring(0, maxLength) + "...";
    }

    protected void ImgBtnThumbnail_Click(object sender, EventArgs e)
    {
        string[] arguments = (((ImageButton)sender).CommandArgument).ToString().Split(',');
        string artid = Convert.ToString(arguments[0]);
        Response.Redirect("ViewArticle.aspx?artID=" + artid);
    }
    protected void lbtnHeading_Click(object sender, EventArgs e)
    {
        string[] arguments = (((LinkButton)sender).CommandArgument).ToString().Split(',');
        string artid = Convert.ToString(arguments[0]);
        Response.Redirect("ViewArticle.aspx?artID=" + artid);
    }
    protected void lbtnChannelname_Click(object sender, EventArgs e)
    {
        string[] arguments = (((LinkButton)sender).CommandArgument).ToString().Split(',');
        string chid = Convert.ToString(arguments[0]);
        Response.Redirect("ViewChannel.aspx?ChID=" + chid);
    }

    protected void btnComment_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        if (cookie != null)
        {
            cmd = new SqlCommand("INSERT INTO [dbo].[comments] ([uid] ,[artid] ,[comment] ,[postedon]) VALUES (@uid,@artid,@comment,@postedon)", c.conn);
            cmd.Parameters.AddWithValue("@comment", txtComment.Text.Trim());
            cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
            cmd.Parameters.AddWithValue("@artid", Request.QueryString["artID"]);
            cmd.Parameters.AddWithValue("@postedon", System.DateTime.Now);
            c.Insert(cmd);
            txtComment.Text = "";
        }
        else
        {
            Response.Redirect("PleaseRegister.aspx");
        }
        loadComments();
    }

    protected void btnSubscribe_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        if (cookie == null)
        {
            Response.Redirect("PleaseRegister.aspx");
        }
        else
        {
            if (btnSubscribe.Text == "Subscribe")
            {
                cmd = new SqlCommand("INSERT INTO[dbo].[subscribers] ([chid] ,[uid] ,[subscribedon]) VALUES (@chid,@uid,@subscribedon)", c.conn);

                cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
                cmd.Parameters.AddWithValue("@chid", ViewState["chid"]);
                cmd.Parameters.AddWithValue("@subscribedon", System.DateTime.Today);
                c.Insert(cmd);
            }
            if (btnSubscribe.Text == "Subscribed")
            {
                cmd = new SqlCommand("DELETE FROM [dbo].[subscribers] WHERE uid=@uid and chid=@chid", c.conn);

                cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
                cmd.Parameters.AddWithValue("@chid", ViewState["chid"]);
                cmd.Parameters.AddWithValue("@subscribedon", System.DateTime.Today);
                c.delete(cmd);
            }
        }
        LoadUserSubscribeStatus();
        Server.TransferRequest(Request.Url.AbsolutePath, false);
    }
}