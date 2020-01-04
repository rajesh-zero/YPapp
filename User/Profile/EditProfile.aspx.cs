using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Profile_EditProfile : System.Web.UI.Page
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
                Response.Redirect("../../RegisterLogin/Login.aspx");
            }
            else
            {
                LoadInitialData();
            }
        }
    }

    private void LoadInitialData()
    {
        cmd = new SqlCommand("SELECT [uid] ,[uemail] ,[upassword] ,[umobile] ,[uname] ,[ugender] ,[uprofilepic] ,[udob] ,[uregisteredon] ,[udescription] ,[ucountry] FROM [YouPaper].[dbo].[userprofile] WHERE uemail=@uemail", c.conn);
        HttpCookie cookie = Request.Cookies["userinfo"];
        cmd.Parameters.AddWithValue("@uemail", cookie["email"]);
        c.Retrieve(cmd);
        while (c.dr.Read())
        {
            txtAboutme.Text = Convert.ToString(c.dr["udescription"]);
            txtName.Text = Convert.ToString(c.dr["uname"]);
            txtMobile.Text = Convert.ToString(c.dr["umobile"]);
            string datedob = (c.dr["udob"]).ToString();
            if (datedob != "")
            {
                string modifi = datedob.Length <= 10 ? datedob : datedob.Substring(0, 10);
                txtDob.Text = (Convert.ToDateTime(modifi)).ToString("yyyy-MM-dd");
            }

            if (Convert.ToString(c.dr["ugender"]) == "M")
            {
                rbMale.Checked = true;
            }
            else if (Convert.ToString(c.dr["ugender"]) == "F")
            {
                rbFemale.Checked = true;
            }
            if (Convert.ToString(c.dr["ucountry"]) != "")
            {
                Country.SelectedValue = Convert.ToString(c.dr["ucountry"]);
            }

        }
        c.conn.Close();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        UpdateProfile();
    }

    private void UpdateProfile()
    {
        cmd = new SqlCommand("UPDATE userprofile SET uname = @uname,udob = @udob ,ugender = @ugender,umobile = @umobile,ucountry = @ucountry,udescription=@udescription WHERE uemail=@uemail", c.conn);
        HttpCookie cookie = Request.Cookies["userinfo"];
        cmd.Parameters.AddWithValue("@uemail", cookie["email"]);
        // cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(Request.QueryString["ID"]));
        cmd.Parameters.AddWithValue("@uname", txtName.Text.Trim());
        cmd.Parameters.AddWithValue("@umobile", txtMobile.Text.Trim());
        cmd.Parameters.AddWithValue("@udob", txtDob.Text);
        if (rbMale.Checked)
        {
            cmd.Parameters.AddWithValue("@ugender", "M");
        }
        else if (rbFemale.Checked)
        {
            cmd.Parameters.AddWithValue("@ugender", "F");
        }

        cmd.Parameters.AddWithValue("@ucountry", Country.SelectedValue);
        cmd.Parameters.AddWithValue("@udescription", txtAboutme.Text.Trim());
        c.Update(cmd);
        Response.Redirect("EditSuccessfull.aspx?Check=true");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProfilePage.aspx");
    }
}