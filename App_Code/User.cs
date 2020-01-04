using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{

    string query2 = "Select @@Identity";
    public SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-RAJESH\SQLEXPRESS;Initial Catalog=YouPaper;Integrated Security=True");
    public SqlCommand cmd = null;
    public SqlDataReader dr = null;
    public User()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public void Register(SqlCommand cmd)
    {

    }

    public int Insert(SqlCommand cmd)
    {
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            int i = cmd.ExecuteNonQuery();
            cmd.CommandText = query2;
            int id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            conn.Close();
            return id;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
}