using DarwoftMarket.DataAccess;
using DarwoftMarket.Entities;
using DarwoftMarket.ProjectUtilities;
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
                EmployeeLobby(idUser);
            }
            else if (idTypeUser == 3)
            {
                BossLobby(idUser);
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
                var name = instanceUserTable.Rows[0][1];

                Console.Clear();
                Console.WriteLine("----DARWOFT MARKET----");
                Console.WriteLine($"Bien venido {name}!!!\n\n\n");
                Console.WriteLine("1-Comprar sin ticket");
                Console.WriteLine("2-Comprar con ticket y por lote");
                Console.WriteLine("3-Revisar saldo");
                Console.WriteLine("4-Cargar saldo");
                Console.WriteLine("5-Eliminar mi cuenta");
                Console.WriteLine("6-Salir\n\n\n");
                Console.WriteLine("Ingresa Una Opcion:");
                int option = ValidatesConsole.ValidateInputInt() ;
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        ProductMenu.BuyProducts(idUser);
                        break;
                    case 2:
                        Console.Clear();
                        ProductMenu.BuyProductsWichTicket(idUser);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("-------------------------------------------------------------------------------");
                        Console.WriteLine($"Tu saldo actual es: {Convert.ToInt32(instanceUserTable.Rows[0][3])} pesos");
                        Console.ReadLine();
                        break;
                    case 4:
                        ClientMenu.InsertAmountMenu(instanceUserTable);
                        break;
                    case 5:
                        ClientMenu.DeleteClientMenu(idUser); 
                        break;
                    case 6:
                        con = false;
                        break;
                }
            }
        }

        public static void BossLobby(int idUser)
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
                Console.WriteLine("2-Crear producto");
                Console.WriteLine("3-Modificar productos");
                Console.WriteLine("4-Eliminar producto");
                Console.WriteLine("5-Crear descuento");
                Console.WriteLine("6-Modificar descuento");
                Console.WriteLine("7-Eliminar descuento");
                Console.WriteLine("8-Salir\n\n\n");
                Console.WriteLine("Ingresa Una Opcion:");
                int option = ValidatesConsole.ValidateInputInt();
                switch (option)
                {
                    case 1:
                        EmployeeDataAccess.CreateEmployee(id);
                        break;
                    case 2:
                        ProductMenu.CreateProduct();
                        break;
                    case 3:
                        ProductMenu.UpdateProduct();
                        break;
                    case 4:
                        ProductMenu.DeleteProduct();
                        break;
                    case 5:
                        DiscountMenu.CreateDiscountMenu();
                        break;
                    case 6:
                        DiscountMenu.UpdateDiscount();
                        break;
                    case 7:
                        DiscountMenu.DeleteDiscount();
                        break;
                    case 8:
                        con = false;
                        break;
                }
            }
        }
        public static  void EmployeeLobby(int idUser)
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
                Console.WriteLine("1-Cargar Producto");
                Console.WriteLine("2-Consultar Productos");
                Console.WriteLine("3-ActualizarStock");
                Console.WriteLine("4-Consultar Productos Faltantes");
                Console.WriteLine("5-Salir\n\n\n");
                Console.WriteLine("Ingresa Una Opcion:");
                int option = ValidatesConsole.ValidateInputInt();
                switch (option)
                {
                    case 1:
                        ProductMenu.CreateProduct();
                        break;
                    case 2:
                        ProductMenu.ShowProdcuts();
                        break;
                    case 3:
                        ProductMenu.UpdateQuantity();
                        break;
                    case 4:
                        ProductMenu.ShowListProducts(2);
                        break;
                    case 5:
                        con = false;
                        break;
                }
            }
        }
    }
}
