using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Channel_EditChannel : System.Web.UI.Page
{
    SqlCommand cmd = null;
    string chid, chname = null;
    Crud c = new Crud();
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        if (cookie == null)
        {
            Response.Redirect("../../RegisterLogin/Login.aspx");
        }
        if (Request.QueryString["chid"] == null)
        {
            Response.Redirect("../../PleaseRegister.aspx");
        }
        else
        {
            searchExist();
            loadChannelData();
        }
    }

    private void loadChannelData()
    {
        try
        {
            if (c.conn.State != ConnectionState.Open)
            {
                c.conn.Open();
            }

            cmd = new SqlCommand("SELECT [chid] ,[uid] ,[chname] ,[chdescription] ,[chart] ,[chimage] ,[chcreatedon] ,[status] FROM[dbo].[channel] WHERE chid=@chid", c.conn);
            //HttpCookie cookie = Request.Cookies["userinfo"];
            //cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
            cmd.Parameters.AddWithValue("@chid", (Request.QueryString["chid"]));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
            }
            c.conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void searchExist()
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        string checkuser = "select count(*) from [dbo].[channel] where uid='" + cookie["uid"] + "' and chid='" + Request.QueryString["chid"] + "'";
        int i = c.getCount(checkuser);
        if (i != 1)
        {
            Response.Redirect("Error.aspx");
        }
    }

    protected void btnUpdateChannel_Click(object sender, EventArgs e)
    {

    }

    protected void btnCancelChannel_Click(object sender, EventArgs e)
    {

    }
}