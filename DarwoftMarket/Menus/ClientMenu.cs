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
            var clientArray = new string[3];
            var con = true;
            while ( con )
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Ahora Ingresame Tus datos Personales");
                Console.WriteLine("ingresa tu nombre:");
                var name = Console.ReadLine();
                Console.WriteLine("ingresa tu apellido:");
                var surname = Console.ReadLine();
                var ClientExist = ClientDataAccess.GetClient(name, surname);

                if (ClientExist.Rows.Count <= 0)
                {

                    clientArray[0] = name;
                    clientArray[1] = surname;
                    clientArray[2] = "0";
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
            float amount = Convert.ToInt32(instanceUserTable.Rows[0][3]);
            bool con = true;
            while (con)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Pantalla de recarga de saldo!\n");
                Console.WriteLine($"Tu saldo actual es : {amount} Pesos\n");
                Console.WriteLine("Ingresar el monto a cargar:\n");
                float quantity = Convert.ToInt32(Console.ReadLine());
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

    }
} 
 