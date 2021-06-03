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
                var opc = Console.ReadLine();
                opc = opc.ToLower();
                Console.Clear();
                if (opc == "s")
                {
                    RegisterClientMenu.RegisterUserView();
                    con = false;
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
                var username = Console.ReadLine();
                Console.WriteLine("ingresar Contraseña:");
                var password = Console.ReadLine();
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
                    Menu.showMenus(Convert.ToInt32(userTable.Rows[0][0]), Convert.ToInt32(userTable.Rows[0][3]));
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
