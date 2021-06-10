using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DarwoftMarket.DataAccess
{
    class GenericDataAccess
    {
		public static DataTable Query(string connectionLink, string query, Dictionary<string, string> parameters,string message)
		{
			var cn = new SqlConnection(connectionLink);
			cn.Open();
            try
            {
				var cmd = new SqlCommand(query, cn);
				foreach (var item in parameters) cmd.Parameters.AddWithValue(item.Key, item.Value);

				var adapter = new SqlDataAdapter(cmd);

				var table = new DataTable();
				adapter.Fill(table);

				return table;

			}
            catch (Exception)
            {
				Console.WriteLine(message);
				throw;
            }
			finally
            {
				cn.Close();
            }
			
		}

		public static void Execute(string connectionLink, string query, Dictionary<string, string> parameters , string message)
		{
			var cn = new SqlConnection(connectionLink);
			cn.Open();
			try
            {
				var cmd = new SqlCommand(query, cn);
				foreach (var item in parameters) cmd.Parameters.AddWithValue(item.Key, item.Value);

				cmd.ExecuteNonQuery();

			}
            catch (Exception)
            {
				Console.WriteLine(message);
                throw;
            }
			finally
            {
				cn.Close();
            }
		}
	}
}
