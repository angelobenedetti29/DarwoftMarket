using DarwoftMarket.DataAccess;
using DarwoftMarket.ProjectUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DarwoftMarket.Menus
{
    public static class ClientMenu
    {
        public static Array RegisterClient()
        {
            var clientArray = new string[2];
            var con = true;
            while ( con )
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Ahora Ingresame Tus datos Personales");
                Console.WriteLine("ingresa tu nombre:");
                var name = ValidatesConsole.ValidateInputString();
                Console.WriteLine("ingresa tu apellido:");
                var surname = ValidatesConsole.ValidateInputString() ;
                var ClientExist = ClientDataAccess.GetClient(name, surname);

                if (ClientExist.Rows.Count <= 0)
                {

                    clientArray[0] = name;
                    clientArray[1] = surname;
                    con = false;
                }
                else
                {
                    
                    Console.Clear();
                }
            }
            return clientArray;
        }

        
        public static void InsertAmountMenu(DataTable instanceUserTable)
        {
            int id = Convert.ToInt32(instanceUserTable.Rows[0][0]);
            float amount = (float)((double)(instanceUserTable.Rows[0][3]));
            bool con = true;
            while (con)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Pantalla de recarga de saldo!\n");
                Console.WriteLine($"Tu saldo actual es : {amount} Pesos\n");
                Console.WriteLine("Ingresar el monto a cargar:");
                float quantity = ValidatesConsole.ValidateInputFloat();
                quantity = amount + quantity;
                if (quantity > 0) ;
                {
                    ClientDataAccess.UpdateAmount(id , quantity);   
                    con = false;
                    Console.WriteLine($"Tu saldo final es : {quantity} Pesos\n");
                    Console.ReadLine();
                }
            }

        }
        public static void DeleteClientMenu(int idClient)
        {
            Console.Clear();
            Console.WriteLine("Seguro que quieres eliminar tu cuenta  ?");
            var opc = ValidatesConsole.ValidateInputString();
           
            if (opc == "S" || opc == "s")
            {
                var tableClient = UserDataAccess.GetUser("", "", idClient);
                Console.WriteLine("Ingresar su contraseña para eliminar la cuenta:");
                var password = ValidatesConsole.ValidateInputString();
                if (tableClient.Rows[0][2].ToString() == password)
                {
                    ClientDataAccess.DeleteClint(idClient);
                    Console.WriteLine("El cliente fue dado de baja con exito");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("La constraseña ingresada es incorrecta");
                }
            }
        }


    }
} 
 