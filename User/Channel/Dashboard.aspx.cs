using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Channel_Dashboard : System.Web.UI.Page
{
    Crud c = new Crud();
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        if (cookie == null)
        {
            Response.Redirect("../../RegisterLogin/Login.aspx");
        }
        if (Request.QueryString["ChID"] != null)
        {
            loadDashboardData();
            Loadarticles();
        }
    }

    private void Loadarticles()
    {
        try
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            string query = "SELECT top 10 [artid] ,[heading] ,[thumbnail] ,[postedon] ,[likes] ,[dislikes] ,[views] FROM [dbo].[article] where chid = @chid ORDER BY artid DESC";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@chid", Convert.ToInt32(Request.QueryString["ChID"]));
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            RptAllArticle.DataSource = ds.Tables[0];
            RptAllArticle.DataBind();
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

    private void loadDashboardData()
    {
        cmd = new SqlCommand("select sum(likes) as 'likes',sum(dislikes) as 'dislikes',sum(views) as 'views' from article where chid=@chid", c.conn);
        cmd.Parameters.AddWithValue("chid",Request.QueryString["ChID"]);
        c.Retrieve(cmd);
        while(c.dr.Read())
        {
            lblViews.Text = Convert.ToString(c.dr["views"]);
            lblLikes.Text= Convert.ToString(c.dr["likes"]);
            lblDislikes.Text= Convert.ToString(c.dr["dislikes"]);
        }
        c.conn.Close();
        string query = "select count(*) from [dbo].[subscribers] where chid ='"+ Request.QueryString["ChID"]+ "'";
        int i = c.getCount(query);
        lblSubs.Text = Convert.ToString(i);
        query = "select count(*) from [dbo].[article] where chid ='" + Request.QueryString["ChID"] + "'";
        i = c.getCount(query);
        lblArticles.Text = Convert.ToString(i);
    }

    protected void lbtnHeading_Click(object sender, EventArgs e)
    {
        string[] arguments = (((LinkButton)sender).CommandArgument).ToString().Split(',');
        string artid = Convert.ToString(arguments[0]);
        Response.Redirect("../../ViewArticle.aspx?artID=" + artid);
    }

    protected void ImgEditArticle_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void ImgDeleteArticle_Click(object sender, ImageClickEventArgs e)
    {
        string[] arguments = (((ImageButton)sender).CommandArgument).ToString().Split(',');
        int artid = Convert.ToInt32(arguments[0]);
        string query = "DELETE FROM  [dbo].[article] WHERE artid=@artid";
        SqlCommand cmd = new SqlCommand(query, c.conn);
        cmd.Parameters.AddWithValue("@artid", artid);
        c.delete(cmd);
    }
}