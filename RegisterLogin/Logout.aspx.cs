using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register_Login_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("userinfo");
        cookie.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(cookie);
        Response.Redirect("../Default.aspx");
    }
}