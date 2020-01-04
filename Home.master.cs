using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.MasterPage
{
    string email;
    Crud c = new Crud();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpCookie cookie = Request.Cookies["userinfo"];
            if (cookie != null)
            {
                email = cookie["email"];
            }
            if (email != null)
            {
                LoggedIn.Visible = true;
                NotLogged.Visible = false;
                loadProfilepic();
                loadSubscription();
            }
            else
            {
                LoggedIn.Visible = false;
                NotLogged.Visible = true;
            }
        }
    }

    private void loadSubscription()
    {
        try
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            SqlCommand cmd = new SqlCommand("select subscribers.chid,channel.chname from subscribers inner join channel on channel.chid = subscribers.chid where subscribers.uid = @uid", c.conn);
            HttpCookie cookie = Request.Cookies["userinfo"];
            cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            rptSubscription.DataSource = ds;
            rptSubscription.DataBind();

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

    private void loadProfilepic()
    {
        SqlCommand cmd = new SqlCommand("SELECT [uid] ,[uemail] ,[upassword] ,[umobile] ,[uname] ,[ugender] ,[uprofilepic] ,[udob] ,[uregisteredon] ,[udescription] ,[ucountry] FROM [YouPaper].[dbo].[userprofile] WHERE uemail=@uemail", c.conn);
        HttpCookie cookie = Request.Cookies["userinfo"];
        cmd.Parameters.AddWithValue("@uemail", cookie["email"]);
        c.Retrieve(cmd);
        while (c.dr.Read())
        {
            if (Convert.ToString(c.dr["uprofilepic"]) != "")
            {
                Image1.ImageUrl = "~/images/profileimage/" + Convert.ToString(c.dr["uprofilepic"]);
            }
            Label1.Text = Convert.ToString(c.dr["uname"]);
        }
        c.conn.Close();
    }

    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        string a = Request.Form["search"];
        Response.Redirect("SearchResults.aspx?SearchTerm=" + a);
    }
}
