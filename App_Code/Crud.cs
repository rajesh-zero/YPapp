using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Crud
/// </summary>
public class Crud
{
    public SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-RAJESH\SQLEXPRESS;Initial Catalog=YouPaper;Integrated Security=True");
    public SqlCommand cmd = null;
    public SqlDataReader dr = null;
    public Crud()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Insert(SqlCommand cmd)
    {
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            int i = cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void delete(SqlCommand cmd)
    {
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            int i = cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void delete(string query)
    {
        //conn.Close();
        if (conn.State != ConnectionState.Closed)
        {
            conn.Close();
        }
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd = new SqlCommand(query, conn);
            int i = cmd.ExecuteNonQuery();
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void Retrieve(SqlCommand cmd)
    {
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            dr = cmd.ExecuteReader();
            // conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //// //sample
    //private void retriveData()
    //{
    //    cmd = new SqlCommand("SELECT [uid] ,[uemail] ,[upassword] ,[umobile] ,[uname] ,[ugender] ,[uprofilepic] ,[udob] ,[uregisteredon] ,[udescription] ,[ucountry] FROM [YouPaper].[dbo].[userprofile] WHERE uemail=@uemail", c.conn);
    //    cmd.Parameters.AddWithValue("@uemail", "rajyafav@gmail.com");
    //    c.Retrieve(cmd);
    //    while (c.dr.Read())
    //    {
    //        txtRName.Text = Convert.ToString(c.dr["uname"]);
    //        Label1.Text = Convert.ToString(c.dr["uid"]);
    //    }
    //    c.conn.Close();
    //}


    public void Update(SqlCommand cmd)
    {
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            int i = cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int getCount(string query)
    {
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd = new SqlCommand(query, conn);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            conn.Close();
            return temp;
        }
        catch (Exception)
        {
           // return 0;
            throw;
        }
    }

    public int getCount(SqlCommand cmd)
    {
        if (conn.State != ConnectionState.Open)
        {
            conn.Open();
        }
        int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        conn.Close();
        return temp;
    }

}
    