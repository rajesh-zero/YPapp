using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Profile_UpdatePassword : System.Web.UI.Page
{
    SqlCommand cmd = null;
    Crud c = new Crud();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCancelpwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProfilePage.aspx");
    }

    protected void btnpwdupdate_Click(object sender, EventArgs e)
    {
        UpdateUPwd();
    }

    private void UpdateUPwd()
    {
        cmd = new SqlCommand("UPDATE userprofile SET upassword = @upassword WHERE uid=@uid", c.conn);
        HttpCookie cookie = Request.Cookies["userinfo"];
        cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
        cmd.Parameters.AddWithValue("@upassword", txtPwd.Text.Trim());
        c.Update(cmd);
        Response.Redirect("UpdatePasswordSuccessfull.aspx?authcheck=true");
    }
}