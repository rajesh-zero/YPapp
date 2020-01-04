using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ausername"] == null)
        {
            Response.Redirect("~/Admin/AdminLogin.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserReport.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChannelReport.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("ArticleReport.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AdminPanel.aspx");
    }
}
