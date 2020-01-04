using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Crud c = new Crud();
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        
        if (!this.IsPostBack)
        {
            this.LoadArticleData();
        }
        if (cookie != null)
        {
            
        }
    }
    

    private void LoadArticleData()
    {
        try
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            string query = "select channel.chid,article.artid,article.heading,article.views,article.likes,article.dislikes,article.thumbnail,channel.chname,article.postedon from article inner join channel on article.chid=channel.chid ORDER BY NEWID();";
            SqlCommand cmd = new SqlCommand(query, c.conn);
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

    //to add ... in heading in cards
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
}
