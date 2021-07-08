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
        public static DataTable GetDiscounts()
        {
            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);

            try
            {
                string query = "";
                var cmd = new SqlCommand();
               
                query = "SELECT * FROM  Discounts ";
              
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
    }
}
