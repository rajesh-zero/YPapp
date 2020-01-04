using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewChannel : System.Web.UI.Page
{
    Crud c = new Crud();
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Request.QueryString["chid"] == "")
            {
                Response.Redirect("ChannelNotFound.aspx");
            }

            string checkarticle = "select count(*) from [dbo].[channel] where chid='" + Request.QueryString["chid"] + "'";
            int temp = c.getCount(checkarticle);
            if (temp == 0)
            {
                Response.Redirect("ChannelNotFound.aspx");
            }
            else
            {
                this.LoadChannel();
                this.LoadPopularArticle();
                this.LoadAllArticle();
            }
            HttpCookie cookie = Request.Cookies["userinfo"];
            if (cookie != null)
            {
                LoadUserSubscribeStatus();
            }
        }

    }

    private void LoadAllArticle()
    {
        try
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            string query = "SELECT [artid] ,[chid] ,[cid] ,[heading] ,[articlebody] ,[thumbnail] ,[postedon] ,[likes] ,[dislikes] ,[views] FROM [dbo].[article] where chid = @chid ORDER BY postedon DESC;";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@chid", Request.QueryString["chid"]);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dtlistArticle.DataSource = ds;
            dtlistArticle.DataBind();

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

    private void LoadPopularArticle()
    {
        try
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            string query = "SELECT TOP 5 [artid] ,[chid] ,[cid] ,[heading] ,[articlebody] ,[thumbnail] ,[postedon] ,[likes] ,[dislikes] ,[views] FROM [dbo].[article] where chid = @chid  ORDER BY views DESC;";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@chid", Request.QueryString["chid"]);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dtlistPopularArticle.DataSource = ds;
            dtlistPopularArticle.DataBind();

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

    private void LoadChannel()
    {
        cmd = new SqlCommand("SELECT [channel].[chid],[channel].[uid],[channel].[chname] ,[channel].[chdescription] ,[channel].[chart] ,[channel].[chimage] ,[channel].[chcreatedon] ,[channel].[status],[userprofile].[uname] FROM[dbo].[channel] inner join userprofile on channel.uid=userprofile.uid WHERE chid=@chid", c.conn);
        cmd.Parameters.AddWithValue("@chid", Request.QueryString["chid"]);
        c.Retrieve(cmd);
        while (c.dr.Read())
        {
            ViewState["uid"] = Convert.ToString(c.dr["uid"]);
            chArt.ImageUrl = "~/images/channel/art/" + Convert.ToString(c.dr["chart"]);
            chImage.ImageUrl = "~/images/channel/images/" + Convert.ToString(c.dr["chimage"]);
            lblChName.Text = Convert.ToString(c.dr["chname"]);
            lblCreatedon.Text= "Created on :"+(Convert.ToDateTime(c.dr["chcreatedon"]).ToString("MM/dd/yyyy"));
            lblchdescription.Text= Convert.ToString("Description :"+c.dr["chdescription"]);
            channelOwner.Text = Convert.ToString("Owner :"+c.dr["uname"]);
        }
        c.conn.Close();
        string query = "select count(*) from [dbo].[subscribers] where chid ='" + Request.QueryString["chid"] + "'";
        int i = c.getCount(query);
        lblSubscriber.Text = Convert.ToString(i);
    }

    private void LoadUserSubscribeStatus()
    {
        //string checkstatus = "select count(*) from [dbo].[userprofile] where uemail='" + txtREmail.Text.Trim() + "'";
        //int i = c.getCount(checkstatus);
        cmd = new SqlCommand("SELECT count(*) FROM [dbo].[subscribers] where uid=@uid and chid=@chid", c.conn);
        HttpCookie cookie = Request.Cookies["userinfo"];
        cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
        cmd.Parameters.AddWithValue("@chid", Request.QueryString["ChID"]);
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

    protected string Limit(object desc, int maxLength)
    {
        var description = (string)desc;
        if (string.IsNullOrEmpty(description)) { return description; }
        return description.Length <= maxLength ?
            description : description.Substring(0, maxLength) + "...";
    }

    protected void channelOwner_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewProfile.aspx?uid=" + ViewState["uid"]);
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
            if (btnSubscribe.Text=="Subscribe")
            {
                cmd = new SqlCommand("INSERT INTO[dbo].[subscribers] ([chid] ,[uid] ,[subscribedon]) VALUES (@chid,@uid,@subscribedon)", c.conn);
             
                cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
                cmd.Parameters.AddWithValue("@chid", Request.QueryString["ChID"]);
                cmd.Parameters.AddWithValue("@subscribedon", System.DateTime.Today);
                c.Insert(cmd);
            }
            if (btnSubscribe.Text == "Subscribed")
            {
                cmd = new SqlCommand("DELETE FROM [dbo].[subscribers] WHERE uid=@uid and chid=@chid", c.conn);
              
                cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
                cmd.Parameters.AddWithValue("@chid", Request.QueryString["ChID"]);
                cmd.Parameters.AddWithValue("@subscribedon", System.DateTime.Today);
                c.delete(cmd);
            }
            Response.Redirect("ViewChannel.aspx?ChID="+ Request.QueryString["ChID"]);
        }
    }
}