using DarwoftMarket.DataAccess;
using DarwoftMarket.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DarwoftMarket.Menus
{
    public static class Menu
    {
        
        public static  void showMenus( DataTable userTable )
        {
            var id = Convert.ToInt32(userTable.Rows[0][0]);
            var idTypeUser = Convert.ToInt32(userTable.Rows[0][3]);
            DataTable instanceUserTable = ClientDataAccess.GetClient("", "", id);
           
            if (idTypeUser == 1)
            {
                ClientLobby( instanceUserTable );
            }
            else if (idTypeUser == 2)
            {
                EmployeeMenu( instanceUserTable );
            }
            else if (idTypeUser == 3)
            {
                BossMenu( instanceUserTable );
            }
            else
            {
                Console.WriteLine("Esto no deberia pasar ");
            }
        }

        public static void ClientLobby(DataTable instanceUserTable)
        {
            var id = Convert.ToInt32(instanceUserTable.Rows[0][0]);
            var name = instanceUserTable.Rows[0][1];
            var con = true;
            while ( con )
            {
                instanceUserTable = ClientDataAccess.GetClient("", "", id);

                Console.Clear();
                Console.WriteLine("----DARWOFT MARKET----");
                Console.WriteLine($"Bien venido {name}!!!\n\n\n");
                Console.WriteLine("1-Comprar");
                Console.WriteLine("2-Revisar saldo");
                Console.WriteLine("3-Cargar saldo");
                Console.WriteLine("4-Salir\n\n\n");
                Console.WriteLine("Ingresa Una Opcion:");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        // code block
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("-------------------------------------------------------------------------------");
                        Console.WriteLine($"Tu saldo actual es: {Convert.ToInt32(instanceUserTable.Rows[0][3])} pesos");
                        Console.ReadLine();
                        break;
                    case 3:
                        ClientMenu.InsertAmountMenu(instanceUserTable);
   
                        break;
                    case 4:
                        con = false;
                        break;
                }
            }
        }

        public static void BossMenu( DataTable instanceUserTable )
        {
            var name = instanceUserTable.Rows[0][1];
            var con = true;
            while ( con )
            {
                Console.Clear();
                Console.WriteLine("----DARWOFT MARKET----");
                Console.WriteLine($"Bien venido {name}!!!\n\n\n");
                Console.WriteLine("1-Comprar");
                Console.WriteLine("2-Revisar saldo");
                Console.WriteLine("3-Salir\n\n\n");
                Console.WriteLine("Ingresa Una Opcion:");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        // code block
                        break;
                    case 2:
                        // code block
                        break;
                    case 3:
                        con = false;
                        break;
                }
            }
        }
        public static  void EmployeeMenu( DataTable instanceUserTable )
        {
            var name = instanceUserTable.Rows[0][1];
            var con = true;
            while (con)
            {
                Console.Clear();
                Console.WriteLine("----DARWOFT MARKET----");
                Console.WriteLine($"Bien venido {name}!!!\n\n\n");
                Console.WriteLine("1-CargarProducto");
                Console.WriteLine("2-ConsultarProductos");
                Console.WriteLine("3-Salir\n\n\n");
                Console.WriteLine("Ingresa Una Opcion:");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        // code block
                        break;
                    case 2:
                        // code block
                        break;
                    case 3:
                        con = false;
                        break;
                }
            }
        }
    }
}
