using Final.DataBase;
using Final.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final.Services
{
    public class LoginService
    {
        public User LoginAttempt(UserViewModel user)
        {
            User U = null;
            using (SqlConnection con = new SqlConnection(Addonet.Get()))
            {
                string query = "Select Id, Email, Password, Privilage From Users Where Email = @Email and Password = @Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User dbUser = new User();
                        dbUser.Id = reader.GetInt32(0);
                        dbUser.Email = reader.GetString(1);
                        dbUser.Privilage = reader.GetInt32(3);
                        U = dbUser;
                    }

                }
            }

            return U;
        }
    }
}