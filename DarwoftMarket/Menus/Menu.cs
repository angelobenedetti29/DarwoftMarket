using DarwoftMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DarwoftMarket.Menus
{
    public static class Menu
    {
        
        public static  void showMenus( int id , int idTypeUser )
        {
            if (idTypeUser == 1)
            {
                ClientMenu();
            }
            else if (idTypeUser == 2)
            {
                EmployeeMenu();
            }
            else if (idTypeUser == 3)
            {
                BossMenu();
            }
            else
            {
                Console.WriteLine("Esto no deberia pasar ");
            }
        }

        public static void ClientMenu()
        {
            var con = true;
            while ( con )
            {
                Console.Clear();
                Console.WriteLine("----DARWOFT MARKET----");
                Console.WriteLine("Bien venido (nombre)!!!\n\n\n");
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

        public static void BossMenu()
        {
            var con = true;
            while ( con )
            {
                Console.Clear();
                Console.WriteLine("----DARWOFT MARKET----");
                Console.WriteLine("Bien venido (nombre)!!!\n\n\n");
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
        public static  void EmployeeMenu()
        {
            var con = true;
            while (con)
            {
                Console.Clear();
                Console.WriteLine("----DARWOFT MARKET----");
                Console.WriteLine("Bien venido (nombre)!!!\n\n\n");
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
