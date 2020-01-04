using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        if (cookie != null)
        {
            Label1.Text = Convert.ToString(cookie["email"]);
            Label2.Text = Convert.ToString(cookie["uid"]);
        }
    }
}