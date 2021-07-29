using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DarwoftMarket.DataAccess
{
    class DiscountDataAccess
    {
        public static DataTable GetDiscount(string name = "" ,int id = -1 )
        {
            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);

            try
            {
                var cmd = new SqlCommand();

                var query = "SELECT * FROM  Discounts WHERE name = @name or id = @id  ";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name" ,name);
                cmd.Parameters.AddWithValue("@id", id);
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
                Console.WriteLine("Hubo un problema al obtener los descuentos");
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
        public static DataTable GetAllDiscounts()
        {
            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);

            try
            {
                var cmd = new SqlCommand();
               
                var query = "SELECT * FROM  Discounts ";
              
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
                Console.WriteLine("Hubo un problema al obtener los descuentos");
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
        public static void CreateDiscount(string name, string description, float discount, DateTime since, DateTime until)
        {
            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);

            try
            {

                var cmd = new SqlCommand();

                string query = "INSERT INTO Discounts (name ,description ,discount ,since ,until ) VALUES (@name, @description, @discount, @since, @until) ";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@discount", discount);
                cmd.Parameters.AddWithValue("@since", since);
                cmd.Parameters.AddWithValue("@until", until);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Hubo un problema al cargar el Descuento");
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
        public static void DeleteDiscount(int id)
        {
            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);

            try
            {

                var cmd = new SqlCommand();

                string query = "DELETE FROM Discounts WHERE id = @id";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Hubo un problema al eliminar el Descuento");
                throw;
            }
            finally
            {
                cn.Close();
            }

        }
        public static void UpdateDiscount(int id, string name, string description, float discount, DateTime since, DateTime until)
        {
            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);

            try
            {

                var cmd = new SqlCommand();

                string query = "UPDATE Discounts SET name = @name ,description = @description ,discount = @discount ,since = @since ,until = @until  WHERE id = @id";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@discount", discount);
                cmd.Parameters.AddWithValue("@since", since);
                cmd.Parameters.AddWithValue("@until", until);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Hubo un problema al actualizar el Descuento");
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
