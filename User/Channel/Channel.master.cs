using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Channel_Channel : System.Web.UI.MasterPage
{
    string email = null;
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
            }
            else
            {
                LoggedIn.Visible = false;
                NotLogged.Visible = true;
            }
        }
    }

    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        string a = Request.Form["search"];
        Response.Redirect("../../SearchResults.aspx?SearchTerm=" + a);
    }
}
