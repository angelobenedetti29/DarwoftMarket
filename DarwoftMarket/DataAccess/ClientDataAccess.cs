using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DarwoftMarket.DataAccess
{
    public static class ClientDataAccess
    {
        public static void InsertClint(int id, string name, string surname, float amount = 0)
        {
            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);

            try
            {
                var cmd = new SqlCommand();

                string query = "INSERT INTO Clients (id, name , surname, amount ) VALUES (@id, @name, @surname, @amount) ";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Hubo un problema al cargar el Cliente");
                throw;
            }

            finally
            {
                cn.Close();
            }
        }
        public static DataTable GetClient(string name, string surname)
        {
            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);

            try
            {

                var cmd = new SqlCommand();
                string query = "SELECT * FROM Clients WHERE name like @name AND surname like @surname";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
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
    }
}
