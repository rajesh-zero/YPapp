using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Channel_ChannelPage : System.Web.UI.Page
{
    SqlCommand cmd = null;
    string chid, chname = null;
    Crud c = new Crud();
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        if (cookie == null)
        {
            Response.Redirect("../../RegisterLogin/Login.aspx");
        }
        if (Request.QueryString["chid"] == null)
        {
            Response.Redirect("../../PleaseRegister.aspx");
        }
        else
        {
            searchExist();
            loadChannelData();
            this.LoadPopularArticle();
            this.LoadAllArticle();
        }
    }

    private void searchExist()
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        string checkuser = "select count(*) from [dbo].[channel] where uid='" + cookie["uid"] + "' and chid='" + Request.QueryString["chid"] + "'";
        int i = c.getCount(checkuser);
        if (i != 1)
        {
            Response.Redirect("Error.aspx");
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
            if (c.conn.State == ConnectionState.Open)
            {
                c.conn.Close();
            }
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
    private void loadChannelData()
    {
        try
        {
            if (c.conn.State != ConnectionState.Open)
            {
                c.conn.Open();
            }

            cmd = new SqlCommand("SELECT [chid] ,[uid] ,[chname] ,[chdescription] ,[chart] ,[chimage] ,[chcreatedon] ,[status] FROM[dbo].[channel] WHERE chid=@chid", c.conn);
            //HttpCookie cookie = Request.Cookies["userinfo"];
            //cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
            cmd.Parameters.AddWithValue("@chid",(Request.QueryString["chid"]));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (Convert.ToString(dr["chart"]) != "")
                {
                    chArt.ImageUrl = "~/images/channel/art/" + Convert.ToString(dr["chart"]);
                }

                if (Convert.ToString(dr["chart"]) != "")
                {
                    chImage.ImageUrl = "~/images/channel/images/" + Convert.ToString(dr["chart"]);
                }
               
                
                lblChName.Text = Convert.ToString(dr["chname"]);
                lblchdescription.Text= Convert.ToString(dr["chdescription"]);
               lblCreatedon.Text= "Created on :" + (Convert.ToDateTime(dr["chcreatedon"]).ToString("MM/dd/yyyy"));
                chid = Convert.ToString(dr["chid"]);
                chname = Convert.ToString(dr["chname"]);
            }
            c.conn.Close();
            string query = "select count(*) from [dbo].[subscribers] where chid ='" + Request.QueryString["chid"] + "'";
            int i = c.getCount(query);
            lblSubscriber.Text = Convert.ToString(i);
        }
        catch (Exception ex)
        {
            //Response.Redirect("Error.aspx");
            //string ab = Convert.ToString(ex);
            throw ex;
        }

    }

    protected void btnWriteArticle_Click(object sender, EventArgs e)
    {
        Response.Redirect("WriteArticles.aspx?ChId=" + chid + "&ChName=" + chname);
    }

    protected void btnAllArticles_Click(object sender, EventArgs e)
    {
        Response.Redirect("AllArticles.aspx?ChId=" + chid);
    }

    protected void btnDraftArticles_Click(object sender, EventArgs e)
    {
        Response.Redirect("DraftArticles.aspx?ChId=" + chid);
    }

    protected void btnManageArticles_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageArticles.aspx?ChId=" + chid);
    }

    protected void btnDashboard_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx?ChId=" + chid + "&ChName=" + chname);
        //Session["ChId"] = chid;
        //Session["ChName"] = chname;
    }

    protected void btnDeleteChannel_Click(object sender, EventArgs e)
    {
        string query;
        query = "DELETE FROM [dbo].[channel] WHERE chid =" + chid;
        c.delete(query);
        Response.Redirect("../Profile/ProfilePage.aspx");
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
        Response.Redirect("../Profile/ProfilePage.aspx");
    }

    protected void ImgBtnThumbnail_Click(object sender, EventArgs e)
    {
        string[] arguments = (((ImageButton)sender).CommandArgument).ToString().Split(',');
        string artid = Convert.ToString(arguments[0]);
        Response.Redirect("../../ViewArticle.aspx?artID=" + artid);
    }

    protected void lbtnHeading_Click(object sender, EventArgs e)
    {
        string[] arguments = (((LinkButton)sender).CommandArgument).ToString().Split(',');
        string artid = Convert.ToString(arguments[0]);
        Response.Redirect("../../ViewArticle.aspx?artID=" + artid);
    }

    protected void btnSubscribe_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditChannel.aspx?chid="+ Request.QueryString["chid"]);
    }
}