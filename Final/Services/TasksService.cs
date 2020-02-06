using Final.DataBase;
using Final.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final.Services
{
    public class TasksService
    {
        public bool Create(Tasks task)
        {
            using(SqlConnection con = new SqlConnection(Addonet.Get()))
            {
                string query = "Insert Into Tasks(Name,Type,Cost) Values (@N,@T,@C)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@N" ,task.Name);
                cmd.Parameters.AddWithValue("@T", task.Type);
                cmd.Parameters.AddWithValue("@C", task.Cost);
                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public bool Update (Tasks task)
        {
            using (SqlConnection con = new SqlConnection(Addonet.Get()))
            {
                string query = "Update Tasks Set Name = @N, Type = @T,Cost = @C Where Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@N", task.Name);
                cmd.Parameters.AddWithValue("@T", task.Type);
                cmd.Parameters.AddWithValue("@C", task.Cost);
                cmd.Parameters.AddWithValue("@Id", task.Id);
                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }
        public bool Delete (int Id)
        {
            using (SqlConnection con = new SqlConnection(Addonet.Get()))
            {
                string query = "Delete From Tasks Where Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }
        public Tasks GetTaskByID(int Id)
        {
            using (SqlConnection con = new SqlConnection(Addonet.Get()))
            {
                string query = "Select Id,Name,Type,Cost From Tasks Where Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Tasks t = new Tasks()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Type = reader.GetString(2),
                            Cost = reader.GetInt32(3)
                        };
                        return t;
                    }
                }
            }
            return null;
        }
        public List<Tasks> GetTasks()
        {
            List<Tasks> tasks = new List<Tasks>();
            using (SqlConnection con = new SqlConnection(Addonet.Get()))
            {
                string query = "Select Id , Name,Type,Cost From Tasks ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tasks t = new Tasks()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Type = reader.GetString(2),
                            Cost = reader.GetInt32(3)
                        };
                        tasks.Add(t);
                    }
                }
            }
            return tasks;
        }

    }
}