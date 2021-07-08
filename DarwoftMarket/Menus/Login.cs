using DarwoftMarket.DataAccess;
using DarwoftMarket.ProjectUtilities;
using System;
using System.Data;

namespace DarwoftMarket.Menus
{
    public static class Login
    {
        
        public static void ShowPreLogin()
        {
            var con = true;
            while ( con )
	        {
                Console.WriteLine("--------------------");
                Console.WriteLine("        Login       ");
                Console.WriteLine("Sos nuevo ? (s/n)");
                var opc = ValidatesConsole.ValidateInputString();
                opc = opc.ToLower();
                Console.Clear();
                if (opc == "s")
                {
                    ClientDataAccess.CreateClint();
                    con = false;
                    ShowLogin();
                }
                else if (opc == "n")
                {
                    ShowLogin();
                    con = false;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ingresaste un valor erroneo...\n");
                }
	        }
        }

        public static void ShowLogin()
        {
            var con = true;
            while ( con )
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("        Login       ");
                Console.WriteLine("ingresar usario:");
                var username = ValidatesConsole.ValidateInputString();
                Console.WriteLine("ingresar Contraseña:");
                var password = ValidatesConsole.ValidateInputString() ;
                var userTable = new DataTable();

                try
                {
                    userTable = UserDataAccess.GetUser(username, password);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error al Obtener Usario");
                }

                if (userTable.Rows.Count == 1)
                {
                    Menu.showMenus(userTable);
                    con = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Algun dato no es valido");
                }
            }
        }
    }
}
