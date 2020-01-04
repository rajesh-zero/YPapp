﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageUser : System.Web.UI.Page
{
    Crud c = new Crud();
    SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-RAJESH\SQLEXPRESS;Initial Catalog=YouPaper;Integrated Security=True");
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.LoadUserData();
        }
    }

    private void LoadUserData()
    {
        try
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT [uid] ,[uemail] ,[upassword] ,[umobile] ,[uname] ,[ugender] ,[uprofilepic] ,convert(varchar, udob, 101) as udob ,convert(varchar, uregisteredon, 101) as uregisteredon ,[udescription] ,[ucountry] ,[ustatus] FROM [dbo].[userprofile]";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Repeater1.DataSource = ds.Tables[0];
            Repeater1.DataBind();

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lbtnViewUser_Click(object sender, EventArgs e)
    {
        string[] arguments = (((LinkButton)sender).CommandArgument).ToString().Split(',');
        int uid = Convert.ToInt32(arguments[0]);
        Response.Write("<script>");
        Response.Write("window.open('../ViewProfile.aspx?uid=" + uid+"', '_blank')");
        Response.Write("</script>");
        //Response.Redirect("../ViewProfile.aspx?uid=" + uid);
    }

    protected void ImgDeleteUser_Click(object sender, ImageClickEventArgs e)
    {
        string[] arguments = (((ImageButton)sender).CommandArgument).ToString().Split(',');
        int uid = Convert.ToInt32(arguments[0]);
        string query = null;
        HttpCookie cookie = Request.Cookies["userinfo"];
        query = "DELETE FROM [dbo].[userprofile] WHERE uid =" + uid;
        c.delete(query);
        LoadUserData();
    }
}