using DarwoftMarket.DataAccess;
using DarwoftMarket.ProjectUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DarwoftMarket.Menus
{
    class ProductMenu
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
                var name = ValidatesConsole.ValidateInputString();
                Console.WriteLine("Description:");
                var description = ValidatesConsole.ValidateInputString();
                Console.WriteLine("Cantidad inicial:");
                int quantity = ValidatesConsole.ValidateInputInt();
                Console.WriteLine("Precio inicial:");
                float price = ValidatesConsole.ValidateInputFloat();
                Console.WriteLine("Cantidad Minima en Stock:");
                int minimumStock = ValidatesConsole.ValidateInputInt();
                if (ProductDataAccess.GetProduct(name).Rows.Count == 0)
                {
                    ProductDataAccess.InsertProduct(name, quantity, price, minimumStock, description);
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
        public static void ShowProdcuts()
        {
            //ShowListProducts(2) shows an out of stock message
            Console.Clear();
            ShowListProducts(2);
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
                Console.Clear();
                ShowListProducts();
            }
           
        }

        public static void BuyProducts(int idClient)
        {
            
            float amount = ClientDataAccess.GetAmount(idClient);
            var end = false;
            var discountsTable = DiscountDataAccess.GetAllDiscounts();
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
                quantityProduct = quantityProduct - quantity;

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
                    ProductDataAccess.UpdateStock(idProduct, quantity, 1);
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
        public static void BuyProductsWichTicket(int idClient)
        {
            DataTable tableProductsToBuy = new DataTable();
            tableProductsToBuy.Columns.Add();
            tableProductsToBuy.Columns.Add();
            tableProductsToBuy.Columns.Add();
            tableProductsToBuy.Columns.Add();
            var end = false;
            var localAmount = ClientDataAccess.GetAmount(idClient);
            var tableProductsLocal = ProductDataAccess.GetProducts();
            float amountToPay = 0;
            while (end == false)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("                     Lista de producutos");
                for (int i = 0; i < tableProductsLocal.Rows.Count; i++)
                {
                    Console.WriteLine($"CODIGO:{tableProductsLocal.Rows[i][0]}   NOMBRE:{tableProductsLocal.Rows[i][1]}   CANTIDAD:{tableProductsLocal.Rows[i][3]}   PRECIO:{tableProductsLocal.Rows[i][4]}"); 
                }
                Console.WriteLine("Ingresa el CODIGO del Producto a comprar:");
                int idProduct = ValidatesConsole.ValidateInputInt();
                Console.WriteLine("Ingresar cantidad:");
                var quantity = ValidatesConsole.ValidateInputInt();

                

                for (int i = 0; i < tableProductsLocal.Rows.Count ; i++)
                {
                    if ((int)tableProductsLocal.Rows[i][0] == idProduct)
                    {
                        var product = tableProductsLocal.Rows[i];
                        var priceProdcut = (float)((double)(product.Table.Rows[0][4]));
                        amountToPay = priceProdcut * quantity;
                        var quantityProduct = (int)product.Table.Rows[0][3];
                        
                        if ((int)tableProductsLocal.Rows[i][3] - quantity >= 0 && (localAmount - amountToPay) >= 0)
                        {
                            //add a product in the tableProductsToBuy
                            tableProductsToBuy.Rows.Add(idProduct,quantity,amountToPay, tableProductsLocal.Rows[i][1]);

                            //modify tableProducts to validate future purchases within this package
                            tableProductsLocal.Rows[i][3] = quantityProduct -quantity;
                            Console.WriteLine(localAmount);
                            localAmount = localAmount - amountToPay;
                        }
                        else
                        {
                            if ( localAmount < amountToPay)
                            {
                                Console.WriteLine("No tenes saldo Suficiente para realizar una compra\n");
                                Console.ReadLine();
                            }
                            if (quantityProduct < quantity)
                            {
                                Console.WriteLine("No queda mas prodcutos en Stock\n");
                                Console.ReadLine();
                            }
                        }
                    }
                    
                }
                Console.WriteLine("queres comprar otro producto?(s/n)");
                var opc = ValidatesConsole.ValidateInputString();
                if (opc == "N" || opc == "n")
                {
                    end = true;
                    Console.WriteLine("Deseas confirmar la compra(s/n)?");
                    var opc1 = ValidatesConsole.ValidateInputString();
                    if (opc1 == "S" || opc1 == "s")
                    {
                        var tableProductsActual = ProductDataAccess.GetProducts();
                        Console.Clear();
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("              TICKET");
                        Console.WriteLine("Productos comprados:");
                        for (int i = 0; i < tableProductsToBuy.Rows.Count; i++)
                        {
                            // type is equal to 0 because the query needs to increment the stock
                            ProductDataAccess.UpdateStock( Convert.ToInt32(tableProductsToBuy.Rows[i][0]),Convert.ToInt32(tableProductsToBuy.Rows[i][1]));
                  
                            ClientDataAccess.UpdateAmount(idClient ,localAmount);
                            Console.WriteLine($"{tableProductsToBuy.Rows[i][3]}   CANTIDAD:{tableProductsToBuy.Rows[i][1]}   PRECIO:{tableProductsToBuy.Rows[i][2]}");
                        }
                        Console.WriteLine("Compra realizada con Excito");
                        Console.ReadLine();
                    }
                }
                
            }

        }
        public static void UpdateQuantity()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("                   Productos Disponibles          ");
            Console.WriteLine("ingresar cuantos productos hay que modificar:");
            var quantityProducts = ValidatesConsole.ValidateInputInt();
            for (int n = 0; n < quantityProducts; n++)
            {
                Console.Clear();
                ShowListProducts();
                Console.WriteLine("Ingresa el CODIGO del Producto a modificar:");
                var id = ValidatesConsole.ValidateInputInt();
                Console.WriteLine("Ingresar cuanto se agrego:");
                var quantity = ValidatesConsole.ValidateInputInt();
                // type is equal to 0 because the query needs to increment the stock
                ProductDataAccess.UpdateStock(id, quantity, 0);
            }
        }
        public static void UpdateProduct()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("                                   Menu para Modificar un Prodcuto\n\n");
            var end1 = false;
            while (end1 == false)
            {
                ShowListProducts();
                Console.WriteLine("Ingresa el CODIGO del Producto a modificar:");
                var id = ValidatesConsole.ValidateInputInt();
                var product = ProductDataAccess.GetProduct("", id);
                var end2 = false;
                while (end2 == false)
                {
                    Console.WriteLine($"Seleccionaste el descuento : {product.Rows[0][1]} ");
                    Console.WriteLine("1-Nombre");
                    Console.WriteLine("2-Descripcion ");
                    Console.WriteLine("3-Cantidad en stock");
                    Console.WriteLine("4-Precio ");
                    Console.WriteLine("5-Cantidad de stock minimo ");
                    Console.WriteLine("6-Salir");
                    Console.WriteLine("Ingresar uno de los campos a modificar:");
                    var opc = ValidatesConsole.ValidateInputInt();

                    switch (opc)
                    {
                        case 1:
                            Console.WriteLine("Ingresar el nuevo nombre:");
                            var name = ValidatesConsole.ValidateInputString();
                            if (ProductDataAccess.GetProduct(name).Rows.Count == 0)
                            {
                                ProductDataAccess.UpdateProduct(id, name, (string)product.Rows[0][2], (int)product.Rows[0][3], (float)((double)product.Rows[0][4]), (int)product.Rows[0][5]);
                            }
                            else
                            {
                                Console.WriteLine("Ese nombre ya esta siendo utlizado....");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Ingresar la nueva descripcion:");
                            var description = ValidatesConsole.ValidateInputString();
                            ProductDataAccess.UpdateProduct(id, (string)product.Rows[0][1], description, (int)product.Rows[0][3], (float)((double)product.Rows[0][4]) ,(int)product.Rows[0][5]);

                            break;
                        case 3:
                            Console.WriteLine("Ingresar el nuevo porcentaje de Cantidad en stock:");
                            var quantity = ValidatesConsole.ValidateInputInt();
                            ProductDataAccess.UpdateProduct(id, (string)product.Rows[0][1], (string)product.Rows[0][2], quantity, (float)((double)product.Rows[0][4]), (int)product.Rows[0][5]);

                            break;
                        case 4:
                            Console.WriteLine("Ingresar El precio:");
                            var price = ValidatesConsole.ValidateInputFloat();
                            ProductDataAccess.UpdateProduct(id, (string)product.Rows[0][1], (string)product.Rows[0][2], (int)product.Rows[0][3], price ,(int)product.Rows[0][5]) ;

                            break;
                        case 5:
                            Console.WriteLine("Ingresar el stock minimo");
                            var momimunStock = ValidatesConsole.ValidateInputInt();
                            ProductDataAccess.UpdateProduct(id, (string)product.Rows[0][1], (string)product.Rows[0][2], (int)product.Rows[0][3], (float)((double)product.Rows[0][4]), (int)product.Rows[0][5]);

                            break;
                        case 6:
                            end2 = true;

                            break;
                    }
                    Console.Clear();
                    var productChange = ProductDataAccess.GetProduct("", id);
                    Console.WriteLine("Los cambios Fueron realizados:");
                    Console.WriteLine($"CODIGO:{productChange.Rows[0][0]}   NOMBRE:{productChange.Rows[0][1]}   CANTIDAD:{productChange.Rows[0][3]}   PRECIO:{productChange.Rows[0][4]}   STOCK MINIMO:{productChange.Rows[0][5]}\n\n");
                }
                Console.WriteLine("Queres modificar otro producot?(s/n)");
                var opc1 = ValidatesConsole.ValidateInputString();
                if (opc1 == "N" || opc1 == "n")
                {
                    end1 = true;
                }
            }


        }
        public static void DeleteProduct()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("          Menu para eliminar un producto          ");
            ShowListProducts();
            Console.WriteLine("ingresar el CODIGO del producto a eliminar:");
            var id = ValidatesConsole.ValidateInputInt();
            ProductDataAccess.DeleteProduct(id);
        }

        public static void ShowListProducts(int type = 0)
        {
            var productsTable = ProductDataAccess.GetProducts(type);
           
            if (productsTable.Rows.Count > 0)
            {
                if (type == 2)
                {
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("            Prodcutos con falta de Stock          ");
                }
                else
                {
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("                   Productos Disponibles          ");
                }
                for (int i = 0; i < productsTable.Rows.Count; i++)
                {
                    Console.WriteLine($"CODIGO:{productsTable.Rows[i][0]}   NOMBRE:{productsTable.Rows[i][1]}   CANTIDAD:{productsTable.Rows[i][3]}   PRECIO:{productsTable.Rows[i][4]}");
                }
                Console.ReadLine();
                
            }
            else
            {
                if(type == 2)
                {
                    Console.WriteLine("No hay productos con falta de stock");
                }
                else
                {
                    Console.WriteLine("No existen productos disponibles");
                }
            }
        }
        
    }
}
