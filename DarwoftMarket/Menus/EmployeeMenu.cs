using DarwoftMarket.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DarwoftMarket.Menus
{
    class EmployeeMenu
    {
        public static void CreateProduct()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("              Carga de Prodcutos");
            Console.WriteLine("ingresar la cantidad de productos a cargar:");
            var quantityProducts = Console.ReadLine();
            Console.Clear();
            for (int i = 0; i < int.Parse(quantityProducts); i++)
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("              Carga de Prodcutos\n\n");
                Console.WriteLine("nombre:");
                var name = Console.ReadLine();
                Console.WriteLine("Description:");
                var description = Console.ReadLine();
                Console.WriteLine("Cantidad inicial:");
                var quantity = Console.ReadLine();
                if (ProductDataAccess.GetProduct(name).Rows.Count == 0)
                {
                    ProductDataAccess.InsertProduct(name, int.Parse(quantity), description);
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
