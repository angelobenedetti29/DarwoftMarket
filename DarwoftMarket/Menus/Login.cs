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
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("        Login       ");
            Console.WriteLine("Sos nuevo ? (s/n)");
            var opc = Console.ReadLine();
            opc = opc.ToLower();
            Console.Clear();
            if (opc == "s")
            {
               RegisterClientMenu.RegisterUserView();
            }
            else if (opc == "n")
            {
                ShowLogin();
            }
            else
            {
                Console.WriteLine("Ingresaste una opcion incorrecta\n\n\n");
                ShowPreLogin();
            }
        }

        public static void ShowLogin()
        {
            Console.Clear();
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
            }
            else
            {
                Console.WriteLine("Algun dato no es valido");
                ShowLogin();
            }
        }
    }
}
