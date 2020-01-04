using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Channel_DraftArticles : System.Web.UI.Page
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
        if (!this.IsPostBack)
        {
            this.loadData();
        }
    }

    private void loadData()
    {
        try
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            string query = "SELECT [artid] ,[cid] ,[chid] ,[heading] ,[thumbnail] ,[articlebody] ,[createdon] FROM [dbo].[draftarticle] where chid = @chid ORDER BY artid DESC";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@chid", Convert.ToInt32(Request.QueryString["ChId"]));
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

    protected void ImgEditArticle_Click(object sender, ImageClickEventArgs e)
    {
        string[] arguments = (((ImageButton)sender).CommandArgument).ToString().Split(',');
        int artid = Convert.ToInt32(arguments[0]);
        Response.Redirect("EditDraft.aspx?artid=" + artid+"&chid="+ Convert.ToInt32(Request.QueryString["ChId"]));
    }

    protected void ImgPublishArticle_Click(object sender, ImageClickEventArgs e)
    {
        string[] arguments = (((ImageButton)sender).CommandArgument).ToString().Split(',');
        int artid = Convert.ToInt32(arguments[0]);
        Response.Redirect("EditDraft.aspx?artid=" + artid + "&chid=" + Convert.ToInt32(Request.QueryString["ChId"]));
    }

    protected void ImgDeleteArticle_Click(object sender, ImageClickEventArgs e)
    {
        string[] arguments = (((ImageButton)sender).CommandArgument).ToString().Split(',');
        int artid = Convert.ToInt32(arguments[0]);
        try
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            string query = "DELETE FROM  [dbo].[draftarticle] WHERE artid=@artid";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@artid", artid);
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
        loadData();
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChannelPage.aspx?chid=" + Request.QueryString["ChId"]);
    }
}