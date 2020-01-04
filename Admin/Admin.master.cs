using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ausername"] == null)
        {
            Response.Redirect("~/Admin/AdminLogin.aspx");
        }
    }

    protected void Button1_OnClick(object sender, EventArgs e)
    {
        Session["ausername"] = null;
        Response.Redirect("~/Admin/AdminLogin.aspx");
    }

    protected void btnSearch_OnClick(object sender, EventArgs e)
    {

    }

    protected void btnAdCategory_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCategory.aspx");
    }

    protected void btnReports_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageReports.aspx");
    }

    protected void btnManageUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageUser.aspx");
    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AdminPanel.aspx");
    }

    protected void btnManageArticle_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageArticle.aspx");
    }

    protected void btnManageChannel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageChannel.aspx");
    }

    protected void btnDLReports_Click(object sender, EventArgs e)
    {
        Response.Redirect("../UserReport.aspx");
    }

    protected void btnQueries_Click(object sender, EventArgs e)
    {
        Response.Redirect("Queries.aspx");
    }
}
