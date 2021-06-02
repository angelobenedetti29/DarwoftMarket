using DarwoftMarket.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Data;

namespace DarwoftMarket.DataAccess
{
    public static class UserDataAccess
    {
        public static DataTable GetUser(string username, string password)
        {
            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);

            try
            {
               
                var cmd = new SqlCommand();
                string query = "SELECT * FROM Users WHERE username like @username AND password like @password";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@username",username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                cn.Open();
                cmd.Connection = cn;

                var table = new DataTable();

                var da = new SqlDataAdapter(cmd);
                da.Fill(table);
               
                return table;

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                cn.Close();
            }
        }

        public static void InsertUser(string username, string password , int idTypeUser)
        {
            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);
            
            try
            {
                
                var cmd = new SqlCommand();
               
                string query = "INSERT INTO Users (username, password,idTypeUser) VALUES (@username, @password,@idTypeUser) ";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@idTypeUser", idTypeUser);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                Console.WriteLine("seeeeee");
            }
            catch (Exception)
            {
                Console.WriteLine("Hubo un problema al cargar el Usario");
                throw;
            }

            finally
            {
                cn.Close();
            }
        }
    }
}
