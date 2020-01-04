using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Profile_UpdateProfilePic : System.Web.UI.Page
{
    Crud c = new Crud();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == "")
        {
            Response.Redirect("../../RegisterLogin/Login.aspx");
        }
    }

    protected void btnUpdateImage_Click(object sender, EventArgs e)
    {
        try
        {
            string filename = null;
            string extension = null;
            if (fuphoto.HasFile)
            {
                try
                {
                    filename = Request.QueryString["ID"];
                    extension = Path.GetExtension(fuphoto.PostedFile.FileName);
                    uploadImage(filename, extension);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (c.conn.State != ConnectionState.Open)
            {
                c.conn.Open();
            }
            SqlCommand cmd = new SqlCommand("UPDATE userprofile SET uprofilepic = @uprofilepic WHERE uid=@uid", c.conn);
            cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(Request.QueryString["ID"]));
            cmd.Parameters.AddWithValue("@uprofilepic", filename + extension);
            int i = cmd.ExecuteNonQuery();
            c.conn.Close();
            Response.Redirect("EditSuccessfull.aspx?Check=true");
            //Server.TransferRequest(Request.Url.AbsolutePath, false);
            //loadData();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    private void uploadImage(string filename, string extension)
    {
        fuphoto.SaveAs(Server.MapPath("~/images/profileimage/") + filename + extension);
        //if image not working comment and uncomment below line also try clearing cookies and caches Or try Shift+refresh i.e F5
        // ImageButton1.ImageUrl= "~/images/profileimage/" + filename + extension;
    }

    protected void btnCancelImage_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProfilePage.aspx");
    }
}