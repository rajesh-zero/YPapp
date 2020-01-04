using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddCategory : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-RAJESH\SQLEXPRESS;Initial Catalog=YouPaper;Integrated Security=True");
    SqlCommand cmd = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.LoadCategoryData();
        }
    }

    private void LoadCategoryData()
    {
        try
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT [cid] ,[cname] ,[cdescription] FROM [YouPaper].[dbo].[category]";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Repeater1.DataSource = ds.Tables[0];
            Repeater1.DataBind();

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
    protected void btnSaveCategory_Click(object sender, EventArgs e)
    {
        if (btnSaveCategory.Text == "Update Category")
        {
            UpdateCategoryMethod();
        }
        else if (btnSaveCategory.Text == "Add Category")
        {
            AddCategoryMethod();
        }

    }

    private void UpdateCategoryMethod()
    {
        try
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            Int32 CategoryId = Convert.ToInt32(ViewState["cid"]);
            string query = "UPDATE [dbo].[category] SET cname=@cname, cdescription=@cdescription where cid=@cid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@cid", CategoryId);
            cmd.Parameters.AddWithValue("@cname", txtCname.Text.Trim());
            cmd.Parameters.AddWithValue("@cdescription", txtCdescription.Text.Trim());
            int isChange = cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            Label1.Text = txtCname.Text + " Updated Successfully...";
            txtCname.Text = "";
            txtCdescription.Text = "";
            LoadCategoryData();
            btnSaveCategory.Text = "Add Category";

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void AddCategoryMethod()
    {
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd = new SqlCommand("INSERT INTO [dbo].[category] (cname,cdescription) VALUES (@cname,@cdescription)", conn);
            cmd.Parameters.AddWithValue("@cname", txtCname.Text.Trim());
            cmd.Parameters.AddWithValue("@cdescription", txtCdescription.Text.Trim());
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            Label1.Text = txtCname.Text + " inserted successfully ..";
            txtCname.Text = "";
            txtCdescription.Text = "";
            LoadCategoryData();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ImgEditCategory_Click(object sender, EventArgs e)
    {
        string[] arguments = (((ImageButton)sender).CommandArgument).ToString().Split(',');
        int cid = Convert.ToInt32(arguments[0]);
        ViewState["cid"] = cid;
        btnSaveCategory.Text = "Update Category";
        Label1.Text = "";
        FillCategoryDetails(cid);
        btnCancel.Visible = true;
    }

    private void FillCategoryDetails(int cid)
    {
        try
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            Int32 CategoryId = Convert.ToInt32(cid);
            string query = "SELECT [cname] ,[cdescription] FROM [YouPaper].[dbo].[category] WHERE cid = @cid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@cid", cid);

            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtCname.Text = Convert.ToString(dr["cname"]);
                txtCdescription.Text = Convert.ToString(dr["cdescription"]);
            }
            dr.Close();
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

    //protected void ImgDeleteCategory_Click(object sender, EventArgs e)
    //{
    //    string[] arguments = (((ImageButton)sender).CommandArgument).ToString().Split(',');
    //    int cid = Convert.ToInt32(arguments[0]);
    //    ViewState["cid"] = cid;
    //    DeleteCategoryMethod(cid);
    //    LoadCategoryData();
    //    Label1.Text = " Deleted Successfully..";
    //    btnSaveCategory.Text = "Add Category";
    //    txtCname.Text = "";
    //    txtCdescription.Text = "";
    //}

    private void DeleteCategoryMethod(int cid)
    {
        try
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "DELETE FROM  [dbo].[category] WHERE cid=@cid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@cid", cid);
            cmd.ExecuteNonQuery();
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Label1.Text = "";
        txtCdescription.Text = "";
        txtCname.Text = "";
        btnCancel.Visible = false;
        btnSaveCategory.Text = "Add Category";
    }
}