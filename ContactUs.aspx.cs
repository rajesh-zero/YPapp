using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactUs : System.Web.UI.Page
{
    Crud c = new Crud();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCSubmit_Click(object sender, EventArgs e)
    {
        AddEnquiryInDB();
    }

    private void AddEnquiryInDB()
    {

        try
        {
            if (c.conn.State != ConnectionState.Open)
            {
                c.conn.Open();
            }



            String query = "insert into [dbo].[Enquiry] ([Name],[Email],[MobileNo],[Query]) values (@Name,@Email,@MobileNo,@Query)";
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@Name", txtFname.Text.Trim() + " " + txtLname.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@MobileNo", txtPhone.Text.Trim());
            cmd.Parameters.AddWithValue("@Query", txtQuery.Text.Trim());
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Failed.Visible = true;
            }

            c.conn.Close();
            clearDetails();

        }
        catch (Exception e)
        {
            Response.Redirect("Error.aspx");
        }
    }

    private void clearDetails()
    {
        txtFname.Text = String.Empty;
        txtLname.Text = String.Empty;
        txtPhone.Text = String.Empty;
        txtEmail.Text = String.Empty;
        txtQuery.Text = String.Empty;
    }

    protected void btnCCancel_Click(object sender, EventArgs e)
    {
        clearDetails();
    }
}