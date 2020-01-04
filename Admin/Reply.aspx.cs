using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Reply : System.Web.UI.Page
{
    Crud c = new Crud();
    SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-RAJESH\SQLEXPRESS;Initial Catalog=YouPaper;Integrated Security=True");
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        loadData();
    }

    private void loadData()
    {
        try
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string query = " select * from Enquiry where EnquiryID =" + Request.QueryString["EnquiryID"];
            SqlCommand cmd = new SqlCommand(query, conn);
            c.Retrieve(cmd);
            while (c.dr.Read())
            {
                Label1.Text = Convert.ToString( c.dr["Name"]);
                Label2.Text = Convert.ToString(c.dr["Query"]);
                Label3.Text = Convert.ToString(c.dr["Email"]);
            }
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

    protected void btnSend_Click(object sender, EventArgs e)
    {
        sendMailToUser(Label3.Text,Label1.Text,Label2.Text,TextBox1.Text);
        Label4.Text = "Mail sent successfully";
    }
    private void sendMailToUser(string email, string name, string query,string reply)
    {
        EmailSending es = new EmailSending();
        StringBuilder sbEmailBody = new StringBuilder();
        sbEmailBody.Append("Dear " + name + ",<br/><br/>");
        sbEmailBody.Append("This Mail is response for your query");
        sbEmailBody.Append("<br/>");
        sbEmailBody.Append("<strong> ' "+query+" '</strong>");
        sbEmailBody.Append("<br/>");
        sbEmailBody.Append("Our Reply :");
        sbEmailBody.Append("<br/>");
        sbEmailBody.Append(reply);
        sbEmailBody.Append("<br/><br/>");
        sbEmailBody.Append("<b>Official Youpaper</b>");
        string subject = "YouPaper Enquiry";
        es.sendEMail(email, sbEmailBody.ToString(), subject);
    }
}