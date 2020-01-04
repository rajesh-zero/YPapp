using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisterLogin_UserVerification : System.Web.UI.Page
{
    Crud c = new Crud();
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        success.Visible = false;
        failure.Visible = false;
        Verify();
    }

    private void Verify()
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
            string query = "select uid,uemail,ustatus from [dbo].[userprofile] where uemail=@uemail and ustatus=@ustatus";
            cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@uemail", Request.QueryString["uemail"]);
            cmd.Parameters.AddWithValue("@ustatus", Request.QueryString["token"]);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            var user = da.Fill(ds);
            SqlDataReader dr = cmd.ExecuteReader();
            c.conn.Close();
            if (user > 0)
            {
                cmd = new SqlCommand("UPDATE userprofile SET ustatus = @ustatus WHERE uemail=@uemail", c.conn);
                cmd.Parameters.AddWithValue("@uemail", Request.QueryString["uemail"]);
                cmd.Parameters.AddWithValue("@ustatus", "V");
                c.Update(cmd);
                success.Visible = true;
            }
            //}
            //if (dr.HasRows)
            //{
            //    if (user > 0)
            //    {
            //        while (dr.Read())
            //        {

            //        }
            //    }
            //}
            else
            {
                failure.Visible = true;
            }
            

        }
        catch (Exception ex)
        {
            //failure.Visible = true;
            throw ex;
        }
    }
}