using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportArticle : System.Web.UI.Page
{
    Crud c = new Crud();
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpCookie cookie = Request.Cookies["userinfo"];
            if (cookie == null)
            {
                Response.Redirect("PleaseRegister.aspx");
            }
            else
            {
                Label1.Text = Request.QueryString["title"];
            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        string countreport = "select count(*) from [dbo].[reports] where artid='" + Request.QueryString["artID"] + "' and uid = '"+ cookie["uid"] + "'";
        int i = c.getCount(countreport);
        if (i>0)
        {
            cmd = new SqlCommand("UPDATE reports SET description = @description where artid=@artid and uid = @uid", c.conn);
            cmd.Parameters.AddWithValue("@artid", Request.QueryString["artID"]);
            cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
            cmd.Parameters.AddWithValue("@description", Report.SelectedValue);
            c.Update(cmd);
        }
        else
        {
            cmd = new SqlCommand("INSERT INTO [dbo].[reports] ([uid] ,[artid] ,[description]) VALUES (@uid,@artid,@description)", c.conn);
            cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
            cmd.Parameters.AddWithValue("@artid", Request.QueryString["artID"]);
            cmd.Parameters.AddWithValue("@description", Report.SelectedValue);
            c.Insert(cmd);
        }
        Response.Redirect("Default.aspx");
    }
}