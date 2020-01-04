using ASPSnippets.GoogleAPI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register_Login_GoogleLogin : System.Web.UI.Page
{
    Crud c = new Crud();
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        GoogleConnect.ClientId = "164237056287-bjbbnsmtbucn0rslfv4t5h01ircp9rpm.apps.googleusercontent.com";
        GoogleConnect.ClientSecret = "wDxJZzI3s-AsV-FY9tt0w22M";

        GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];

        if (!string.IsNullOrEmpty(Request.QueryString["code"]))
        {
            string code = Request.QueryString["code"];
            string json = GoogleConnect.Fetch("me", code);
            GoogleProfile profile = new JavaScriptSerializer().Deserialize<GoogleProfile>(json);
            //lblId.Text = profile.Id;
            //lblName.Text = profile.DisplayName;
            //lblEmail.Text = profile.Emails.Find(email => email.Type == "account").Value;
            //lblGender.Text = profile.Gender;
            //lblType.Text = profile.ObjectType;
            //ProfileImage.ImageUrl = profile.Image.Url;
            //pnlProfile.Visible = true;
            //btnLogin.Enabled = false;
            string testing = Convert.ToString(profile.Image.Url);
            //////code try Google/////
            string checkuser = "select count(*) from [dbo].[userprofile] where uemail='" + profile.Emails.Find(email => email.Type == "account").Value.ToString() + "'";
            int temp = c.getCount(checkuser);
            if (temp == 1)
            {
                cmd = new SqlCommand("select uid, uemail,uname, upassword from[dbo].[userprofile] where uemail = @uemail", c.conn);
                cmd.Parameters.AddWithValue("@uemail", Convert.ToString(profile.Emails.Find(email => email.Type == "account").Value));
                c.Retrieve(cmd);
                while (c.dr.Read())
                {
                    HttpCookie cookie = new HttpCookie("userinfo");
                    cookie["email"] = Convert.ToString(c.dr["uemail"]);
                    cookie["uid"] = Convert.ToString(c.dr["uid"]);
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                    Response.Redirect("../Default.aspx");
                }
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO [dbo].[userprofile] (uname,uemail,uregisteredon,ustatus) VALUES (@uname,@uemail,@uregisteredon,@ustatus)", c.conn);
                cmd.Parameters.AddWithValue("@uname", profile.DisplayName.ToString());
                cmd.Parameters.AddWithValue("@uemail", profile.Emails.Find(email => email.Type == "account").Value.ToString());
                cmd.Parameters.AddWithValue("@uregisteredon", System.DateTime.Today);
                cmd.Parameters.AddWithValue("@ustatus", "V");
                c.Insert(cmd);

                cmd = new SqlCommand("select uid, uemail, upassword from[dbo].[userprofile] where uemail = @uemail", c.conn);
                cmd.Parameters.AddWithValue("@uemail", profile.Emails.Find(email => email.Type == "account").Value.ToString());
                c.Retrieve(cmd);
                while (c.dr.Read())
                {
                    HttpCookie cookie = new HttpCookie("userinfo");
                    cookie["email"] = Convert.ToString(c.dr["uemail"]);
                    cookie["uid"] = Convert.ToString(c.dr["uid"]);
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                    Response.Redirect("../Default.aspx");
                }
            }
            //////code try Google/////
        }
        if (Request.QueryString["error"] == "access_denied")
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Access denied.')", true);
        }
        GoogleConnect.Authorize("profile", "email");
    }
        /////code try Google//////  
            public class GoogleProfile
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public Image Image { get; set; }
        public List<Email> Emails { get; set; }
        public string Gender { get; set; }
        public string ObjectType { get; set; }
    }

    public class Email
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
    }
}
