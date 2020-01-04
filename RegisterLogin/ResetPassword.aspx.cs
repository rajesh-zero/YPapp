using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register_Login_ResetPassword : System.Web.UI.Page
{
    SqlCommand cmd = null;
    string email,name,id;
    int uid;
    Crud c = new Crud();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        email = TextBox1.Text.Trim();
        getUserId();
        insertRequestInTable();
    }

    private void sendMailToUser(string email, string name, string id)
    {
        EmailSending es = new EmailSending();
        StringBuilder sbEmailBody = new StringBuilder();
        sbEmailBody.Append("Dear " + name + ",<br/><br/>");
        sbEmailBody.Append("Please click on the following link to reset your password");
        sbEmailBody.Append("<br/>"); sbEmailBody.Append("http://localhost:22460/RegisterLogin/ChangePassword.aspx?id=" + id);
        sbEmailBody.Append("<br/><br/>");
        sbEmailBody.Append("<b>Official Youpaper</b>");
        string subject = "Reset Your Password";
        es.sendEMail(email, sbEmailBody.ToString(), subject);
    }

    private void GetUniqueID()
    {
        string query = "select id from [dbo].[passwordchangerequest] where uid=@uid";
        cmd = new SqlCommand(query, c.conn);
        cmd.Parameters.AddWithValue("@uid", uid);
        c.Retrieve(cmd);
        while (c.dr.Read())
        {
            id = Convert.ToString(c.dr["id"]);
        }
        c.conn.Close();
    }

    private void insertRequestInTable()
    {
        if (uid != 0)
        {
            cmd = new SqlCommand("insert into passwordchangerequest(uid,requestdatetime) values (@uid,@requestdatetime);", c.conn);
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.Parameters.AddWithValue("@requestdatetime", System.DateTime.Now);
            c.Insert(cmd);
            email = TextBox1.Text;
            GetUniqueID();
            sendMailToUser(email, name, id);
            TextBox1.Text = "";
            lblMessage.Text = "Change password link sent successfully . Please check your email";
        }
        else
        {
            lblMessage.Text = "Your email isn't registered with us try registering first";
        }

    }

    private void getUserId()
    {
        string query = "select uid,uname from [dbo].[userprofile] where uemail=@uemail";
        cmd = new SqlCommand(query, c.conn);
        cmd.Parameters.AddWithValue("@uemail", TextBox1.Text.Trim());
        c.Retrieve(cmd);
        while (c.dr.Read())
        {
            uid = Convert.ToInt32(c.dr["uid"]);
            name = Convert.ToString(c.dr["uname"]);
        }
        c.conn.Close();
    }
}