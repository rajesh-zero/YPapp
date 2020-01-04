using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageArticle : System.Web.UI.Page
{
    Crud c = new Crud();
    SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-RAJESH\SQLEXPRESS;Initial Catalog=YouPaper;Integrated Security=True");
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.LoadArticleData();
        }
    }

    private void LoadArticleData()
    {
        try
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string query = " select artid,thumbnail,heading,postedon,chname,uname from article inner join channel on article.chid=channel.chid inner join userprofile on channel.uid = userprofile.uid";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Repeater1.DataSource = ds.Tables[0];
            Repeater1.DataBind();

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lbtnViewArticle_Click(object sender, EventArgs e)
    {
        string[] arguments = (((LinkButton)sender).CommandArgument).ToString().Split(',');
        int artid = Convert.ToInt32(arguments[0]);
        Response.Write("<script>");
        Response.Write("window.open('../ViewArticle.aspx?artid=" + artid + "', '_blank')");
        Response.Write("</script>");
    }

    protected void ImgDeleteArticle_Click(object sender, ImageClickEventArgs e)
    {
        string[] arguments = (((ImageButton)sender).CommandArgument).ToString().Split(',');
        int artid = Convert.ToInt32(arguments[0]);
        string query = null;
        HttpCookie cookie = Request.Cookies["userinfo"];
        query = "DELETE FROM [dbo].[article] WHERE artid =" + artid;
        c.delete(query);
        LoadArticleData();
    }
}