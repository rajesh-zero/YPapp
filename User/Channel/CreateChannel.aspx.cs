using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Channel_CreateChannel : System.Web.UI.Page
{
    Crud c = new Crud();
    string query2 = "Select @@Identity";
    SqlCommand cmd = null;
    string fuChImageName = null;
    string fuChImageNameExtension = null;
    string fuChImageArtName = null;
    string fuChImageArtExtension = null;
    int chid;
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        if (cookie == null)
        {
            Response.Redirect("../../RegisterLogin/Login.aspx");
        }
    }

    protected void btnCreateChannel_Click(object sender, EventArgs e)
    {
        saveChannel();
        saveImages();
        UpdateImagesInDB();
        Response.Redirect("ChannelPage.aspx?chid="+chid);
    }

    private void UpdateImagesInDB()
    {
        cmd = new SqlCommand("UPDATE channel SET chart = @chart, chimage = @chimage WHERE chid=@chid", c.conn);
        cmd.Parameters.AddWithValue("@chid", chid);
        cmd.Parameters.AddWithValue("@chart", fuChImageArtName + fuChImageArtExtension);
        cmd.Parameters.AddWithValue("@chimage", fuChImageName + fuChImageNameExtension);
        c.Update(cmd);
    }

    private void saveImages()
    {
        try
        {
            if (fuChImage.HasFile)
            {
                try
                {
                    fuChImageName = Convert.ToString(chid);
                    fuChImageNameExtension = Path.GetExtension(fuChImage.PostedFile.FileName);
                    fuChImage.SaveAs(Server.MapPath(" ../../images/channel/images/") + fuChImageName + fuChImageNameExtension);
                    //uploadImage(fuChImageName, fuChImageNameExtension);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (fuChArt.HasFile)
            {

                try
                {
                    fuChImageArtName = Convert.ToString(chid);
                    fuChImageArtExtension = Path.GetExtension(fuChArt.PostedFile.FileName);
                    fuChArt.SaveAs(Server.MapPath("../../images/channel/art/") + fuChImageArtName + fuChImageArtExtension);
                    //uploadImage(fuChImageArtName, fuChImageArtExtension);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void saveChannel()
    {
        try
        {
            if (c.conn.State != ConnectionState.Open)
            {
                c.conn.Open();
            }
            cmd = new SqlCommand("INSERT INTO [dbo].[channel] ([uid] ,[chname] ,[chdescription] ,[chcreatedon]) VALUES (@uid,@chname,@chdescription,@chreatedon)", c.conn);
            cmd.Parameters.AddWithValue("@chname", txtChName.Text.Trim());
            HttpCookie cookie = Request.Cookies["userinfo"];
            cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
            cmd.Parameters.AddWithValue("@chdescription", txtAboutChannel.Text.Trim());
            cmd.Parameters.AddWithValue("@chreatedon", System.DateTime.Today);
            int i = cmd.ExecuteNonQuery();
            cmd.CommandText = query2;
            chid = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            c.conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnCancelChannel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Profile/ProfilePage.aspx");
    }
}