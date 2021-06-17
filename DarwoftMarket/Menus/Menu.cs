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
            var idUser = Convert.ToInt32(userTable.Rows[0][0]);
            var idTypeUser = Convert.ToInt32(userTable.Rows[0][3]);
           
            if (idTypeUser == 1)
            {
                ClientLobby(idUser);
            }
            else if (idTypeUser == 2)
            {
                EmployeeMenu(idUser);
            }
            else if (idTypeUser == 3)
            {
                BossMenu(idUser);
            }
            else
            {
                Console.WriteLine("Esto no deberia pasar");
            }
        }

        public static void ClientLobby(int idUser)
        {
            var con = true;
            while ( con )
            {
                var instanceUserTable = ClientDataAccess.GetClient("", "", idUser);
                var id = Convert.ToInt32(instanceUserTable.Rows[0][0]);
                var name = instanceUserTable.Rows[0][1];

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

        public static void BossMenu(int idUser)
        {
            var instanceUserTable = BossDataAccess.GetBoss("", "", idUser);
            var id = Convert.ToInt32(instanceUserTable.Rows[0][0]);
            var name = instanceUserTable.Rows[0][1];
            var con = true;
            while ( con )
            {
                Console.Clear();
                Console.WriteLine("----DARWOFT MARKET----");
                Console.WriteLine($"Bien venido {name}!!!\n\n\n");
                Console.WriteLine("1-Crear Empleado");
                Console.WriteLine("2-Revisar saldo");
                Console.WriteLine("3-Salir\n\n\n");
                Console.WriteLine("Ingresa Una Opcion:");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        EmployeeDataAccess.CreateEmployee(id);
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
        public static  void EmployeeMenu(int idUser)
        {
            var instanceUserTable = EmployeeDataAccess.GetEmployee("", "", idUser);
            var id = Convert.ToInt32(instanceUserTable.Rows[0][0]);
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
