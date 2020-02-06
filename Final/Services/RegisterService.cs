using Final.DataBase;
using Final.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final.Services
{
    public class RegisterService
    {

        public bool Register(UserViewModel user)
        {
            using (SqlConnection con = new SqlConnection(Addonet.Get()))
            {
                string query = "Select Id From Users Where Email = @Email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) { return false; }
                }

                query = "Insert Into Users (Email,Password) Values(@Email,@Password)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                bool result = cmd.ExecuteNonQuery() == 1;
                return result;
            }

        }
    }
}