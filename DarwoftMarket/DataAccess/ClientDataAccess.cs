using DarwoftMarket.Menus;
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
       
        public static void UpdateAmount(int id, float amount = 0)
        {
            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);

            try
            {
                var cmd = new SqlCommand();

                string query = "UPDATE Clients SET amount = @amount  WHERE  id = @id";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Hubo un problema al cargarle saldo al Cliente");
                throw;
            }

            finally
            {
                cn.Close();
            }
        }

        public static DataTable GetClient(string name = "", string surname = "", int id = -1 )
        {
            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);

            try
            {

                var cmd = new SqlCommand();
                string query = "SELECT * FROM Clients WHERE name like @name AND surname like @surname OR id like @id";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
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

                throw;
            }

            finally
            {
                cn.Close();
            }
        }

        public static void CreateClint()
        {
            var userArray = (string[])Usermenu.RegisteUserView();
            var clientArray = (string[])ClientMenu.RegisterClient();
            
            var username = userArray[0];
            var password = userArray[1];
            var idTypeUser = userArray[2];
           
            var name = clientArray[0]; 
            var surname = clientArray[1];
            var amount = clientArray[2];

            string connectionLink = ConfigurationManager.AppSettings["connectionLink"];
            var cn = new SqlConnection(connectionLink);
            SqlTransaction objTransaction = null;

            try
            {
               
                var cmd = new SqlCommand();
                string query1 = "INSERT INTO Users (username,password,idTypeUser ) VALUES ( @username,@password,@idTypeUser ) ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@idTypeUser", idTypeUser);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query1;

                cn.Open();
                objTransaction = cn.BeginTransaction("CreateClient");
                cmd.Transaction = objTransaction;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
               
                string query2 = "SELECT id FROM Users WHERE username like @username AND password like @password";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query2;
                var userDataTable = new DataTable();
                var da = new SqlDataAdapter(cmd);
                da.Fill(userDataTable);

                int id = Convert.ToInt32(userDataTable.Rows[0][0]);
                Console.WriteLine(id);

                string query3= "INSERT INTO Clients (id, name , surname, amount ) VALUES (@id, @name, @surname, @amount)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query3;
                cmd.ExecuteNonQuery();

                objTransaction.Commit();
            }
            catch (Exception ex) 
            {
                objTransaction.Rollback();
                Console.WriteLine($"Hubo un problema al cargar el Cliente...\n ERROR: {ex}");
                throw;
            }

            finally
            {
                cn.Close();
            }
        }
    }

}
