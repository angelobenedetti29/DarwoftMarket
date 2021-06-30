using DarwoftMarket.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DarwoftMarket.Menus
{
    class ProductMenu
    {
        public static void ShowProdcuts()
        {
            Console.Clear();
            var productsTable = ProductDataAccess.GetProducts();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("                   Productos Disponibles          ");
            Console.WriteLine("queres ver un producto en especial ?");
            var opc = Console.ReadLine();
            if (opc == "S" || opc == "s")
            {
                Console.WriteLine("Ingresa el nombre del producto:");
                var name = Console.ReadLine().Trim();
                bool isIn = false;
                for (int i = 0; i < productsTable.Rows.Count; i++)
                {
                    
                    if (name == productsTable.Rows[i][1].ToString())
                    {
                        Console.WriteLine($"CODIGO:{productsTable.Rows[i][0]}   NOMBRE:{productsTable.Rows[i][1]}   CANTIDAD:{productsTable.Rows[i][3]}");
                        isIn = true;
                        Console.ReadLine();
                    }

                }
                if (isIn == false)
                {
                    Console.WriteLine("El nombre ingresado no corresponde con ningun prodocuto");
                    Console.ReadLine();
                }
            }
            else
            {
                ShowListProducts();
            }
           
        }
        public static void UpdateQuantity()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("                   Productos Disponibles          ");
            Console.WriteLine("ingresar cuantos productos hay que modificar:");
            var quantityProducts = Console.ReadLine();
            for (int n = 0; n < int.Parse(quantityProducts); n++)
            {
                Console.Clear();
                var productsTable = ProductDataAccess.GetProducts();
                ShowListProducts();
                Console.WriteLine("Ingresa el CODIGO del Producto a modificar:");
                var id = int.Parse(Console.ReadLine().Trim());
                Console.WriteLine("Ingresar cuanto se agrego:");
                var quantity = int.Parse(Console.ReadLine().Trim());
                // type is equal to 0 because the query needs to increment the stock
                ProductDataAccess.UpdateProduct(id, quantity , 0);
            } 
        }

        public static void BuyProducts()
        {
            
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("                   Lista De Productos          ");
            ShowListProducts(1);
            Console.WriteLine("Ingresar la cantidad de prodcutos que desea comprar:");
            var quantityProducts = int.Parse(Console.ReadLine().Trim());
            for (int i = 0; i < quantityProducts; i++)
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("                   Lista De Productos          ");
                ShowListProducts(1);
                Console.WriteLine("Ingresa el CODIGO del Producto a comprar:");
                var id = int.Parse(Console.ReadLine().Trim());
                Console.WriteLine("Ingresar cantidad:");
                var quantity = int.Parse(Console.ReadLine().Trim());
                // type is equal to 0 because the query needs to increment the stock
                ProductDataAccess.UpdateProduct(id, quantity, 1);
            }
            
        }
        public static void ShowListProducts(int type = 0)
        {
            var productsTable = ProductDataAccess.GetProducts(type);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("                   Productos Disponibles          ");
            for (int i = 0; i < productsTable.Rows.Count; i++)
            {
                Console.WriteLine($"CODIGO:{productsTable.Rows[i][0]}   NOMBRE:{productsTable.Rows[i][1]}   CANTIDAD:{productsTable.Rows[i][3]}");
            }
            Console.ReadLine();
        }

    }
}
