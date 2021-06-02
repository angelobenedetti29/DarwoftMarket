using DarwoftMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DarwoftMarket.Menus
{
    class Menu
    {
        public Menu()
        {

        }
        
        public void showMenus()
        {
            Console.Clear();
            var user = new Client();
            if (user is Client)
            {
                ClientMenu();
            }
            else if (user is Employee)
            {
                EmployeeMenu();
            }
            else if (user is Boss)
            {
                BossMenu();

            }
            else
            {
                Console.WriteLine("Esto no deberia pasar ");
            }
        }
        public void ClientMenu()
        {
            bool Run = true;
            while (Run)
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
                        // code block
                        break;

                    default:
                        ClientMenu();
                        break;
                }

            }
        }

        public void BossMenu()
        {
            bool Run = true;
            while (Run)
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
                        // code block
                        break;

                    default:
                        BossMenu();
                        break;
                }

            }
        }
        public void EmployeeMenu()
        {
            bool Run = true;
            while (Run)
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
                        // code block
                        break;

                    default:
                        EmployeeMenu();
                        break;
                }

            }
        }
    }
}
