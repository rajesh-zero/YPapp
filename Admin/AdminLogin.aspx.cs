using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminLogin : System.Web.UI.Page
{
    Admin a = new Admin();
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void logSubmit_Click(object sender, EventArgs e)
    {
        VerifyAdmin();
    }
    private void VerifyAdmin()
    {
        try
        {
            if (a.conn.State != ConnectionState.Open)
            {
                a.conn.Open();
            }
            string query = "select ausername,apassword from [dbo].[admin] where ausername=@ausername and apassword=@apassword";
            cmd = new SqlCommand(query, a.conn);
            cmd.Parameters.AddWithValue("@ausername", txtUsername.Text.ToString());
            cmd.Parameters.AddWithValue("@apassword", txtPwd.Text.ToString());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            var user = da.Fill(ds);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (user > 0)
                {
                    while (dr.Read())
                    {
                        Session["ausername"] = Convert.ToString(dr["ausername"]);
                        Response.Redirect("AdminPanel.aspx");
                    }
                }
            }
            else
            {
                Label1.Visible = true;
            }
            a.conn.Close();

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}

