using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register_Login_Register : System.Web.UI.Page
{
    Crud c = new Crud();
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGoogle_Click(object sender, EventArgs e)
    {
        Response.Redirect("GoogleLogin.aspx");
    }

    protected void btnFacebook_Click(object sender, EventArgs e)
    {
        Response.Redirect("Error.aspx");
    }

    protected void BtnSignup_Click(object sender, EventArgs e)
    {
        if (Label1.Text == "")
        {
            cmd = new SqlCommand("INSERT INTO [dbo].[userprofile] (uname,uemail,upassword,uregisteredon,ugender,ustatus) VALUES (@uname,@uemail,@upassword,@uregisteredon,@ugender,@ustatus)", c.conn);
            cmd.Parameters.AddWithValue("@uname", txtRName.Text.Trim());
            cmd.Parameters.AddWithValue("@uemail", txtREmail.Text.Trim());
            cmd.Parameters.AddWithValue("@upassword", txtRPwd.Text.Trim());
            cmd.Parameters.AddWithValue("@uregisteredon", System.DateTime.Today);
            if (RadioMale.Checked)
            {
                cmd.Parameters.AddWithValue("@ugender", "M");
            }
            else if (RadioFemale.Checked)
            {
                cmd.Parameters.AddWithValue("@ugender", "F");
            }
            Random generator = new Random();
            String r = generator.Next(0, 999999).ToString("D6");
            cmd.Parameters.AddWithValue("@ustatus", r);
            c.Insert(cmd);
            sendVerificationMail(txtREmail.Text,txtRName.Text,r);
            txtRName.Text = "";
            txtREmail.Text = "";
            registersuccess.Visible = true;
        }
        else
        {
            string display = "Please check errors on the page and try Again";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
        }
    }

    private void sendVerificationMail(string email,string name,string r)
    {
        EmailSending es = new EmailSending();
        StringBuilder sbEmailBody = new StringBuilder();
        sbEmailBody.Append("Dear " + name + ",<br/><br/>");
        sbEmailBody.Append("Please click on the following link to verify your account");
        sbEmailBody.Append("<br/>"); sbEmailBody.Append("http://localhost:22460/RegisterLogin/UserVerification.aspx?token=" + r+"&uemail="+email);
        sbEmailBody.Append("<br/><br/>");
        sbEmailBody.Append("<b>Official Youpaper</b>");
        string subject = "YouPaper Registration Verification";
        es.sendEMail(email, sbEmailBody.ToString(), subject);
    }

    protected void txtREmail_TextChanged(object sender, EventArgs e)
    {
        string checkuser = "select count(*) from [dbo].[userprofile] where uemail='" + txtREmail.Text.Trim() + "'";
        int i = c.getCount(checkuser);
        if (i == 1)
        {
            Label1.Text = "email is already registered try ";
            // HyperLink1.Visible = true;
            txtREmail.Focus();
        }
        else
        {
            Label1.Text = "";
        }
    }
}