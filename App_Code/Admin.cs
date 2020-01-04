using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Admin
/// </summary>
public class Admin
{
   public SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-RAJESH\SQLEXPRESS;Initial Catalog=YouPaper;Integrated Security=True");
   public  SqlCommand cmd = null;
    public Admin()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void VerifyAdmin(SqlCommand cmd)
    {
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}