using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChooseChannel : System.Web.UI.Page
{
    Crud c = new Crud();
    SqlCommand cmd = null;
    int chid;
    string chname;
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userinfo"];
        if (cookie == null)
        {
            Response.Redirect("PleaseRegister.aspx");
        }
        if (!Page.IsPostBack)
        {
            cmd = new SqlCommand("select count(*) from [dbo].[channel] where uid=@uid", c.conn);
            cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
            int temp = c.getCount(cmd);
            if (temp==1)
            {
                cmd = new SqlCommand("SELECT [chid] ,[uid] ,[chname] FROM [dbo].[channel] where uid=@uid", c.conn);
                cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
                c.Retrieve(cmd);
                while (c.dr.Read())
                {
                    temp = Convert.ToInt32(c.dr["chid"]);
                    chname = Convert.ToString(c.dr["chname"]);
                }
                c.conn.Close();
                Response.Redirect("~/User/Channel/WriteArticles.aspx?ChName=" + chname + "&ChId=" + temp);
            }
            if (temp>0)
            {
                cmd = new SqlCommand("SELECT [chid] ,[uid] ,[chname] FROM [dbo].[channel] where uid=@uid", c.conn);
                cmd.Parameters.AddWithValue("@uid", cookie["uid"]);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
                ChannelExists.Visible = true;
            }
            else
            {
                ChannelDoesnotExist.Visible = true;
            }
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        string chname = Convert.ToString(DropDownList1.SelectedItem);
        int temp = Convert.ToInt32(DropDownList1.SelectedValue);
        Response.Redirect("~/User/Channel/WriteArticles.aspx?ChName=" + chname+ "&ChId=" + temp);
    }
}