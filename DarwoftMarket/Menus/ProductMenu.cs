using DarwoftMarket.DataAccess;
using DarwoftMarket.ProjectUtilities;
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
                var name = ValidatesConsole.ValidateInputString();
                bool isIn = false;
                for (int i = 0; i < productsTable.Rows.Count; i++)
                {
                    
                    if (name == productsTable.Rows[i][1].ToString())
                    {
                        Console.WriteLine($"CODIGO:{productsTable.Rows[i][0]}   NOMBRE:{productsTable.Rows[i][1]}   CANTIDAD:{productsTable.Rows[i][3]} PRECIO:{productsTable.Rows[i][4]}");
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
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("                   Productos Disponibles          ");
            Console.WriteLine("ingresar cuantos productos hay que modificar:");
            var quantityProducts = ValidatesConsole.ValidateInputInt();
            for (int n = 0; n < quantityProducts ; n++)
            {
                Console.Clear();
                ShowListProducts();
                Console.WriteLine("Ingresa el CODIGO del Producto a modificar:");
                var id = ValidatesConsole.ValidateInputInt() ;
                Console.WriteLine("Ingresar cuanto se agrego:");
                var quantity = ValidatesConsole.ValidateInputInt();
                // type is equal to 0 because the query needs to increment the stock
                ProductDataAccess.UpdateProduct(id, quantity , 0);
            } 
        }

        public static void BuyProducts(int idClient)
        {
            
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("                   Lista De Productos          ");
            ShowListProducts(1);
            Console.WriteLine("Ingresar la cantidad de prodcutos que desea comprar:");
            float amount = ClientDataAccess.GetAmount(idClient);
            var end = false;
            var discountsTable = DiscountDataAccess.GetDiscounts();
            var discount1 = discountsTable.Rows[0];
            var discount2 = discountsTable.Rows[1];
           
            while (end  == false)
            {
                Console.Clear(); 
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("                   Lista De Productos          ");
                ShowListProducts(1);
                
                Console.WriteLine("Ingresa el CODIGO del Producto a comprar:");
                int idProduct = ValidatesConsole.ValidateInputInt();
                Console.WriteLine("Ingresar cantidad:");
                var quantity = ValidatesConsole.ValidateInputInt();

                var product = ProductDataAccess.GetProduct("",idProduct);
                amount = ClientDataAccess.GetAmount(idClient);
                var priceProdcut = (float)((double)(product.Rows[0][4]));
                priceProdcut = priceProdcut * quantity ;
                var quantityProduct = (int)(product.Rows[0][3]);

                if (quantity == 2) 
                {
                    amount = amount - (priceProdcut - (priceProdcut *  (float)((double)discount1[3]))); 
                }
                if (quantity == 3)
                {
                    amount = amount - (priceProdcut - (priceProdcut * (float)((double)discount2[3])));
                }



                if ( quantityProduct >= 0 && amount >= 0)
                {
                    // type is equal to 0 because the query needs to increment the stock
                    ProductDataAccess.UpdateProduct(idProduct, quantity, 1);
                    ClientDataAccess.UpdateAmount(idClient,amount);
                }
                else
                {
                    if (amount < priceProdcut )
                    {
                        Console.WriteLine("No tenes saldo Suficiente para realizar una compra\n");
                    }
                    if (quantityProduct < quantity)
                    {
                        Console.WriteLine("No queda mas prodcutos en Stock\n");
                    }
                    
                }

                Console.WriteLine("queres comprar otro producto?(s/n)");
                var opc = ValidatesConsole.ValidateInputString();
                if (opc == "N" || opc == "n")
                {
                    end = true;
                }
                
            }
           
        }
        public static void ShowListProducts(int type = 0)
        {
            var productsTable = ProductDataAccess.GetProducts(type);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("                   Productos Disponibles          ");
            for (int i = 0; i < productsTable.Rows.Count; i++)
            {
                Console.WriteLine($"CODIGO:{productsTable.Rows[i][0]}   NOMBRE:{productsTable.Rows[i][1]}   CANTIDAD:{productsTable.Rows[i][3]}   PRECIO:{productsTable.Rows[i][4]}");
            }
            Console.ReadLine();
        }

    }
}
