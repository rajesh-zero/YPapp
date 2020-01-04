using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Profile_ProfilePage : System.Web.UI.Page
{
    Crud c = new Crud();
    
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
                LoadProfileData();
            }
            if (!IsPostBack)
            {
                loadAllChannels();
            }
        }
    }

    private void loadAllChannels()
    {
        try
        {
            if (c.conn.State == ConnectionState.Closed)
            {
                c.conn.Open();
            }
            string query = "SELECT [chid],[chname] ,[chdescription] ,[chimage]  FROM [dbo].[channel] WHERE uid=@uid";
            HttpCookie cookie = Request.Cookies["userinfo"];
            SqlCommand cmd = new SqlCommand(query, c.conn);
            cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            rptChannels.DataSource = ds.Tables[0];
            rptChannels.DataBind();
            if (c.conn.State == ConnectionState.Open)
            {
                c.conn.Close();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadProfileData()
    {
        SqlCommand cmd = new SqlCommand("SELECT [uid] ,[uemail] ,[upassword] ,[umobile] ,[uname] ,[ugender] ,[uprofilepic] ,[udob] ,[uregisteredon] ,[udescription] ,[ucountry] FROM [YouPaper].[dbo].[userprofile] WHERE uemail=@uemail", c.conn);
        HttpCookie cookie = Request.Cookies["userinfo"];
        cmd.Parameters.AddWithValue("@uemail", cookie["email"]);
        c.Retrieve(cmd);
        while (c.dr.Read())
        {
            lblAbout.Text = Convert.ToString(c.dr["udescription"]);
            lblEmail.Text = Convert.ToString(c.dr["uemail"]);
            lblMobile.Text = Convert.ToString(c.dr["umobile"]);
            lblCountry.Text = Convert.ToString(c.dr["ucountry"]);
            Session["udob"] = Convert.ToString(c.dr["udob"]);
            Session["uid"] = Convert.ToString(c.dr["uid"]);
            ViewState["ID"] = Convert.ToString(c.dr["uid"]);
            if (Convert.ToString(c.dr["ugender"]) == "M")
            {
                lblGender.Text = "Male";
                ViewState["gend"] = Convert.ToString(c.dr["ugender"]);

            }
            else if (Convert.ToString(c.dr["ugender"]) == "F")
            {
                lblGender.Text = "Female";
                ViewState["gend"] = Convert.ToString(c.dr["ugender"]);
            }
            if (Convert.ToString(c.dr["udob"]) != "")
            {
                int age = 0;
                age = DateTime.Now.Year - Convert.ToDateTime(c.dr["udob"]).Year;
                if (DateTime.Now.DayOfYear < Convert.ToDateTime(c.dr["udob"]).DayOfYear)
                    age = age - 1;
                lblAge.Text = Convert.ToString(age);
            }

        }
        c.conn.Close();
    }

    protected void btnEditView_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditProfile.aspx");
    }

    protected void btnUpdatePwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("UpdatePassword.aspx");
    }

    protected void btnCreateChannel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Channel/CreateChannel.aspx");
    }

    protected void btnChName_Click(object sender, EventArgs e)
    {
        string[] arguments = (((LinkButton)sender).CommandArgument).ToString().Split(',');
        string chid = Convert.ToString(arguments[0]);
        Response.Redirect("../Channel/ChannelPage.aspx?chid=" + chid);
    }


    protected void btnDeleteUser_Click(object sender, EventArgs e)
    {
        string query = null;
        HttpCookie cookie = Request.Cookies["userinfo"];
        query = "DELETE FROM [dbo].[userprofile] WHERE uid =" + cookie["uid"];
        c.delete(query);
        Response.Redirect("../../RegisterLogin/Logout.aspx");
    }
}