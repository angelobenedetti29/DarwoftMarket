using DarwoftMarket.DataAccess;
using DarwoftMarket.ProjectUtilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DarwoftMarket.Menus
{
    class DiscountMenu
    {
        public static void CreateDiscountMenu()
        {
            var end = false;
            while (end == false)
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine("                              Menu para crear Descuento\n\n");
                var con = true;
                var name = "";
                while(con)
                {
                    Console.WriteLine("Ingresar el nombre del descuento:");
                    name = ValidatesConsole.ValidateInputString();
                    if (DiscountDataAccess.GetDiscount(name).Rows.Count <= 0 )
                    {
                        con = false;
                    }
                    else
                    {
                        Console.WriteLine("El nombre ingresado ya existe...\n");
                    }
                }
                Console.WriteLine("Ingrese la descripcion:");
                var description = ValidatesConsole.ValidateInputString();
                Console.WriteLine("Ingresar el valor del descuento:");
                var discount = ValidatesConsole.ValidateInputFloat();
                Console.WriteLine("Desde cuando  es valido el descuento:");
                var since = ValidatesConsole.ValidateInputDateTime();
                Console.WriteLine("Hasta cuando es valido el descuneto:");
                var until = ValidatesConsole.ValidateInputDateTime();
                DiscountDataAccess.CreateDiscount(name ,description ,discount ,since, until);
                Console.WriteLine("Producto cargado con exito....\n");
                Console.WriteLine("Queres cargar otro descuento(s/n):");
                var opc = ValidatesConsole.ValidateInputString();
                if(opc == "n" || opc == "N")
                {
                    end = true;
                }
                

            }
        }
        public static void DeleteDiscount()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                      Menu para eliminar Descuento\n\n");
            ShowDiscounts();
            Console.WriteLine("Ingresar el codigo del producto a eliminar:");
            var id = ValidatesConsole.ValidateInputInt();
            DiscountDataAccess.DeleteDiscount(id);
            Console.WriteLine("Descuento eliminado con excito....");
        }

        public static void UpdateDiscount()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("                         Menu para Modificar un Descuento\n\n");
            var end1 = false;
            while (end1 == false)
            {
                DiscountMenu.ShowDiscounts();
                Console.WriteLine("Ingresa el CODIGO del Descuento a modificar:");
                var id = ValidatesConsole.ValidateInputInt();
                var discount = DiscountDataAccess.GetDiscount("", id);
                var end2 = false;
                while (end2 == false)
                {
                    Console.WriteLine($"Seleccionaste el descuento : {discount.Rows[0][1]} ");
                    Console.WriteLine("1-Nombre");
                    Console.WriteLine("2-Descripcion ");
                    Console.WriteLine("3-Descuento");
                    Console.WriteLine("4-Desde cuando es valido ");
                    Console.WriteLine("5-Hasta cuando es valido ");
                    Console.WriteLine("6-Salir");
                    Console.WriteLine("Ingresar uno de los campos a modificar:");
                    var opc = ValidatesConsole.ValidateInputInt();

                    switch (opc)
                    {
                        case 1:
                            Console.WriteLine("Ingresar el nuevo nombre:");
                            var name = ValidatesConsole.ValidateInputString();
                            if (DiscountDataAccess.GetDiscount(name).Rows.Count == 0)
                            {
                                var sin = (string)discount.Rows[0][4];
                                var unt = (string)discount.Rows[0][5];
                              
                                DiscountDataAccess.UpdateDiscount(id, name, (string)discount.Rows[0][2], (float)((double)discount.Rows[0][3]), DateTime.Parse(sin), DateTime.Parse(unt));
                            }
                            else
                            {
                                Console.WriteLine("Ese nombre ya esta siendo utlizado....");
                            }

                            break;
                        case 2:
                            Console.WriteLine("Ingresar la nueva descripcion:");
                            var description = ValidatesConsole.ValidateInputString();
                            DiscountDataAccess.UpdateDiscount(id, (string)discount.Rows[0][1], description, (float)((double)discount.Rows[0][3]), DateTime.Parse((string)discount.Rows[0][4]), DateTime.Parse((string)discount.Rows[0][5]));

                            break;
                        case 3:
                            Console.WriteLine("Ingresar el nuevo porcentaje de descuento:");
                            var discountvalue = ValidatesConsole.ValidateInputFloat();
                            DiscountDataAccess.UpdateDiscount(id, (string)discount.Rows[0][1], (string)discount.Rows[0][2], discountvalue,DateTime.Parse((string)discount.Rows[0][4]), DateTime.Parse((string)discount.Rows[0][5]));

                            break;
                        case 4:
                            Console.WriteLine("Ingresar desde cuando es valido:");
                            var since = ValidatesConsole.ValidateInputDateTime();
                            DiscountDataAccess.UpdateDiscount(id, (string)discount.Rows[0][1], (string)discount.Rows[0][2], (float)((double)discount.Rows[0][3]), since, DateTime.Parse((string)discount.Rows[0][5]));

                            break;
                        case 5:
                            Console.WriteLine("Ingresar hasta cuando es valido");
                            var until = ValidatesConsole.ValidateInputDateTime();
                            DiscountDataAccess.UpdateDiscount(id, (string)discount.Rows[0][1], (string)discount.Rows[0][2], (float)((double)discount.Rows[0][3]), DateTime.Parse((string)discount.Rows[0][4]), until);

                            break;
                        case 6:
                            end2 = true;

                            break;
                    }
                    Console.Clear();
                    var discountChange = DiscountDataAccess.GetDiscount("",id);
                    Console.WriteLine("Los cambios Fueron realizados:");
                    Console.WriteLine($"CODIGO:{discountChange.Rows[0][0]}   NOMBRE:{discountChange.Rows[0][1]}   DESCUENTO:{discountChange.Rows[0][3]}   DESDE:{discountChange.Rows[0][4]}   HASTA:{discountChange.Rows[0][5]}\n\n");
                }
                Console.WriteLine("Queres modificar otro Descuento?(s/n)");
                var opc1 = ValidatesConsole.ValidateInputString();
                if (opc1 == "N" || opc1 == "n")
                {
                    end1 = true;
                }
            }
            

        }
    
        public static void ShowDiscounts()
        {
            var discountsTable = DiscountDataAccess.GetAllDiscounts();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("                           Lista de descuentos");
            for (int i = 0; i < discountsTable.Rows.Count; i++)
            {
                Console.WriteLine($"CODIGO:{discountsTable.Rows[i][0]}  NOMBRE:{discountsTable.Rows[i][1]}   DESCRIPCION:{discountsTable.Rows[i][2]}   DESCUENTO:{discountsTable.Rows[i][3]}   DESDE:{discountsTable.Rows[i][4]}   HASTA:{discountsTable.Rows[i][5]}"); 
            }
            Console.ReadLine();

        }
       
    }
}
