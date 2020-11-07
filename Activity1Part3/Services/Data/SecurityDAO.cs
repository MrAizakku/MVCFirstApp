using Activity1Part3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Activity1Part3.Services.Data
{
    public class SecurityDAO
    {
        public bool FindByUser(UserModel user)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string query = $"SELECT rtrim(USERNAME) FROM dbo.Users WHERE USERNAME = @Username";
            bool results = false;       //default assumption of result

            using (SqlConnection con = new SqlConnection(connectionString)) //using ensures connections are closed after use.
            {
                SqlCommand comm = new SqlCommand(query, con);
                try
                {
                    comm.Connection.Open();
                    comm.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows) { results = true; }
                } catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            return results;
        }
    }
}