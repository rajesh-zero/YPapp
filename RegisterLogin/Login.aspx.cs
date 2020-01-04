using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register_Login_Login : System.Web.UI.Page
{
    Crud c = new Crud();
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnFacebook_Click(object sender, EventArgs e)
    {
        Response.Redirect("FacebookLogin.aspx");
        //Response.Redirect("Error.aspx");
    }

    protected void btnGoogle_Click(object sender, EventArgs e)
    {
        Response.Redirect("GoogleLogin.aspx");
    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        FindUser();
    }

    private void LoginUser()
    {
        cmd = new SqlCommand("select uid,uemail,uname,upassword,ustatus from [dbo].[userprofile] where uemail=@uemail and upassword=@upassword", c.conn);
        cmd.Parameters.AddWithValue("@uemail", txtLEmail.Text.ToString());
        cmd.Parameters.AddWithValue("@upassword", txtLPwd.Text.ToString());
        c.Retrieve(cmd);
        while (c.dr.Read())
        {
            if (Convert.ToString(c.dr["ustatus"]) != "V     ")
            {
                PendingVerification.Visible = true;
                loginfailed.Visible = false;
            }
            else
            {
                if (ChkBxRemember.Checked)
                {
                    HttpCookie cookie = new HttpCookie("userinfo");
                    cookie["email"] = Convert.ToString(c.dr["uemail"]);
                    cookie["uid"] = Convert.ToString(c.dr["uid"]);
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                    Response.Redirect("../Default.aspx?auth=true");
                }
                else
                {
                    HttpCookie cookie = new HttpCookie("userinfo");
                    cookie["email"] = Convert.ToString(c.dr["uemail"]);
                    cookie["uid"] = Convert.ToString(c.dr["uid"]);
                    Response.Cookies.Add(cookie);
                    Response.Redirect("../Default.aspx");
                }
            }
            
        }
    }

    private void FindUser()
    {
        cmd = new SqlCommand("select count(*) from [dbo].[userprofile] where uemail=@uemail and upassword=@upassword", c.conn);
        cmd.Parameters.AddWithValue("@uemail", txtLEmail.Text.ToString());
        cmd.Parameters.AddWithValue("@upassword", txtLPwd.Text.ToString());

        int i = c.getCount(cmd);
        if (i == 1)
        {
            LoginUser();
        }
        else
        {
            loginfailed.Visible = true;
            PendingVerification.Visible = false;
        }
    }
}