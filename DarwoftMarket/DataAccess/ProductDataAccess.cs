using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DarwoftMarket.DataAccess
{
    public static class ProductDataAccess
    {
    
        public static void InsertProduct(string name, int quantity, string description = "NOT DESCRIBED ")
        {
            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);

            try
            {

                var cmd = new SqlCommand();

                string query = "INSERT INTO Products (name, description, quantity) VALUES (@name, @description, @quantity) ";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", name); 
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                cn.Open(); 
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Hubo un problema al cargar el Producto");
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
