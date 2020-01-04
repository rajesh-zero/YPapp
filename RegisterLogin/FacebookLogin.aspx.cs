using ASPSnippets.FaceBookAPI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register_Login_FacebookLogin : System.Web.UI.Page
{
    Crud c = new Crud();
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        FaceBookConnect.API_Key = "1831876080438597";
        FaceBookConnect.API_Secret = "30413411bcbe10ca03e2be58cb0bc1eb";

        if (Request.QueryString["error"] == "access_denied")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User has denied access.')", true);
            return;
        }

        string code = Request.QueryString["code"];
        if (!string.IsNullOrEmpty(code))
        {
            string data = FaceBookConnect.Fetch(code, "me?fields=id,name,email");
            FaceBookUser faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
            faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
            //pnlFaceBookUser.Visible = true;
            //lblId.Text = faceBookUser.Id;
            //lblUserName.Text = faceBookUser.UserName;
            //lblName.Text = faceBookUser.Name;
            //Session["uemail"] = faceBookUser.Email;
            //ProfileImage.ImageUrl = faceBookUser.PictureUrl;
            //btnLogin.Enabled = false;

            //////code try Facebook/////
            if (faceBookUser.Email == null)
            {
                Response.Redirect("Error.aspx");
            }
            string checkuser = "select count(*) from [dbo].[userprofile] where uemail='" + faceBookUser.Email + "'";
            int temp = c.getCount(checkuser);
            if (temp == 1)
            {
                cmd = new SqlCommand("select uid, uemail, upassword from[dbo].[userprofile] where uemail = @uemail", c.conn);
                cmd.Parameters.AddWithValue("@uemail", faceBookUser.Email);
                c.Retrieve(cmd);
                while (c.dr.Read())
                {
                    HttpCookie cookie = new HttpCookie("userinfo");
                    cookie["email"] = faceBookUser.Email;
                    cookie["uid"] = Convert.ToString(c.dr["uid"]);
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                    Response.Redirect("../Default.aspx");
                }
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO [dbo].[userprofile] (uname,uemail,uregisteredon,ustatus) VALUES (@uname,@uemail,@uregisteredon,@ustatus)", c.conn);
                cmd.Parameters.AddWithValue("@uname", faceBookUser.Name);
                cmd.Parameters.AddWithValue("@uemail", faceBookUser.Email);
                cmd.Parameters.AddWithValue("@uregisteredon", System.DateTime.Today);
                cmd.Parameters.AddWithValue("@ustatus", "V");
                c.Insert(cmd);

                cmd = new SqlCommand("select uid, uemail, upassword from[dbo].[userprofile] where uemail = @uemail", c.conn);
                cmd.Parameters.AddWithValue("@uemail", faceBookUser.Email);
                c.Retrieve(cmd);
                while (c.dr.Read())
                {
                    HttpCookie cookie = new HttpCookie("userinfo");
                    cookie["email"] = faceBookUser.Email;
                    cookie["uid"] = Convert.ToString(c.dr["uid"]);
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                    Response.Redirect("../Default.aspx");
                }
            }
        }
        FaceBookConnect.Authorize("user_photos,email", Request.Url.AbsoluteUri.Split('?')[0]);
    }
}
public class FaceBookUser
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string PictureUrl { get; set; }
    public string Email { get; set; }
}