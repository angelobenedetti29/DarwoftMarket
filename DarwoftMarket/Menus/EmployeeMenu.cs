using DarwoftMarket.DataAccess;
using DarwoftMarket.ProjectUtilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DarwoftMarket.Menus
{
    class EmployeeMenu
    {
        public static void CreateProduct()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("              Carga de Prodcutos");
            Console.WriteLine("ingresar la cantidad de productos a cargar:");
            var quantityProducts = Console.ReadLine();
            Console.Clear();
            for (int i = 0; i < int.Parse(quantityProducts); i++)
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("              Carga de Prodcutos\n");
                Console.WriteLine("nombre:");
                var name = ValidatesConsole.ValidateInputString() ;
                Console.WriteLine("Description:");
                var description = ValidatesConsole.ValidateInputString();
                Console.WriteLine("Cantidad inicial:");
                int quantity = ValidatesConsole.ValidateInputInt();
                Console.WriteLine("Precio inicial:");
                float price = ValidatesConsole.ValidateInputFloat();
                if (ProductDataAccess.GetProduct(name).Rows.Count == 0)
                {
                    ProductDataAccess.InsertProduct(name, quantity, price, description);
                    Console.WriteLine("El prodcuto fue cargado  con exito");
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("El nombre del producto ya existe , ingrese otro por favor !");
                     i = i - 1;
                    continue; 

                }


            }










        }
        
    }
}
