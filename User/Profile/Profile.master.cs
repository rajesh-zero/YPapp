using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Profile_Profile : System.Web.UI.MasterPage
{
    string email;
    Crud c = new Crud();
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        if (cookie == null)
        {
            Response.Redirect("../../RegisterLogin/Login.aspx");
        }
        else
        {
            loadIdName();
        }

    }

    private void loadIdName()
    {
        SqlCommand cmd = new SqlCommand("SELECT [uid] ,[uemail] ,[upassword] ,[umobile] ,[uname] ,[ugender] ,[uprofilepic] ,[udob] ,[uregisteredon] ,[udescription] ,[ucountry] FROM [YouPaper].[dbo].[userprofile] WHERE uemail=@uemail", c.conn);
        HttpCookie cookie = Request.Cookies["userinfo"];
        cmd.Parameters.AddWithValue("@uemail", cookie["email"]);
        c.Retrieve(cmd);
        while (c.dr.Read())
        {
            lblId.Text = Convert.ToString(c.dr["uid"]);
            lblName.Text = Convert.ToString(c.dr["uname"]);
            //Session["uid"] = Convert.ToInt32(c.dr["uid"]);
            if (Convert.ToString(c.dr["uprofilepic"]) != "")
            {
                ImageButton1.ImageUrl = "~/images/profileimage/" + Convert.ToString(c.dr["uprofilepic"]);
            }
        }
        c.conn.Close();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("UpdateProfilePic.aspx?ID=" + lblId.Text);
    }

    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        string a = Request.Form["search"];
        Response.Redirect("../../SearchResults.aspx?SearchTerm=" + a);
    }
}
