using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisterLogin_ChangePassword : System.Web.UI.Page
{
    Crud c = new Crud();
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        checkID();
    }

    private void checkID()
    {
        try
        {
            if (c.conn.State != ConnectionState.Open)
            {
                c.conn.Open();
            }
            string query = "select id,uid from [dbo].[passwordchangerequest] where id=@id";
            cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
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
                        ViewState["uid"] = Convert.ToInt32(dr["uid"]);
                        divPassword.Visible = true;
                    }
                }
            }
            else
            {
                lblMessage.Text = "This link is expired";
            }
            c.conn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = "This link is expired";
            //throw ex;
        }
    }

    protected void btnChangePwd_Click(object sender, EventArgs e)
    {
        updatwPwd();
    }

    private void updatwPwd()
    {
        cmd = new SqlCommand("UPDATE userprofile SET upassword = @upassword WHERE uid=@uid", c.conn);
        cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(ViewState["uid"]));
        cmd.Parameters.AddWithValue("@upassword", txtNewPwd.Text.Trim());
        c.Update(cmd);
        divPassword.Visible = false;
        lblMessage.Text = "your password change is successful";
    }
}