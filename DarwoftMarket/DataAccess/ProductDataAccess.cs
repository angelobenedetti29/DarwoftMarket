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

        public static DataTable GetProducts()
        {
            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);

            try
            {

                var cmd = new SqlCommand();

                string query = "SELECT * FROM  Products ";

                cmd.Parameters.Clear();
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
                Console.WriteLine("Hubo un problema al obtener un Producto");
                throw;
            }
            finally
            {
                cn.Close();
            }
        }


    }
}
