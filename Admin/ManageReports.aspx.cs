using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageReports : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-RAJESH\SQLEXPRESS;Initial Catalog=YouPaper;Integrated Security=True");
    SqlCommand cmd = null;
    Crud c = new Crud();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.loadReports();
        }
        
    }

    private void loadReports()
    {
        try
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT article.heading, userprofile.uname,reports.rid,reports.artid,reports.description FROM reports INNER JOIN article ON article.artid=reports.artid LEFT OUTER JOIN userprofile on userprofile.uid=reports.uid";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            RptReports.DataSource = ds;
            RptReports.DataBind();

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

    protected void ImgDeleteArticle_Click(object sender, ImageClickEventArgs e)
    {
        string[] arguments = (((ImageButton)sender).CommandArgument).ToString().Split(',');
        int artid = Convert.ToInt32(arguments[0]);
        string query = null;
        query = "DELETE FROM [dbo].[article] WHERE artid =" + artid;
        c.delete(query);
        loadReports();
    }

    protected void ImgIgnoreReport_Click(object sender, ImageClickEventArgs e)
    {
        string[] arguments = (((ImageButton)sender).CommandArgument).ToString().Split(',');
        int rid = Convert.ToInt32(arguments[0]);
        string query = null;
        query = "DELETE FROM [dbo].[reports] WHERE rid =" + rid;
        c.delete(query);
        loadReports();
    }

    protected void lBtnView_Click(object sender, EventArgs e)
    {
        string[] arguments = (((LinkButton)sender).CommandArgument).ToString().Split(',');
        int artid = Convert.ToInt32(arguments[0]);
        Response.Write("<script>");
        Response.Write("window.open('../ViewArticle.aspx?artid=" + artid + "', '_blank')");
        Response.Write("</script>");
    }
}