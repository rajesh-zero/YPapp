using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchResults : System.Web.UI.Page
{
    Crud c = new Crud();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadData();
    }

    private void loadData()
    {
        try
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            string a = Request.QueryString["SearchTerm"];
            string query = "SELECT [article].[artid] ,[article].[chid] ,[article].[cid] ,[article].[heading] ,[article].[articlebody] ,[article].[thumbnail] ,[article].[postedon] ,[article].[likes] ,[article].[dislikes] ,[article].[views],[channel].[chname],[channel].[chimage] from article inner join channel on article.chid=channel.chid where article.heading like '%"+a+"%' or article.heading like '%"+a+"' or article.heading like '"+a+"%'";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Repeater1.DataSource = ds.Tables[0];
            Repeater1.DataBind();
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
    protected string Limit(object desc, int maxLength)
    {
        var description = (string)desc;
        if (string.IsNullOrEmpty(description)) { return description; }
        return description.Length <= maxLength ?
            description : description.Substring(0, maxLength) + "...";
    }
}