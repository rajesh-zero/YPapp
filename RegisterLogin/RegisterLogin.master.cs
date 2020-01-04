using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register_Login_RegisterLogin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        if (cookie != null)
        {
            Response.Redirect("../Default.aspx");
        }
    }
    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        string a = Request.Form["search"];
        Response.Redirect("../SearchResults.aspx?SearchTerm=" + a);
    }
}
