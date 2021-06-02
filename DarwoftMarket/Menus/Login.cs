using DarwoftMarket.DataAccess;
using DarwoftMarket.Entities;
using DarwoftMarket.ProjectUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DarwoftMarket.Menus
{
    public class Login
    {
        public Login()
        {
            
        }
        public void ShowPreLogin()
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("        Login       ");
            Console.WriteLine("Sos nuevo ? (s/n)");
            var opc = Console.ReadLine();
            opc.ToLower();
            
            if (opc == "s")
            {
                RegisterClientView();
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

        public void RegisterClientView()
        {
            
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Ya que sos nuevo ! Nos registramos\n");
            Console.WriteLine("La contraseña debe tener al menos una mayuscula , una minscula  y un numero\n");

            Console.WriteLine("Ingresa un Usario:");
            var username = Console.ReadLine();
            Console.WriteLine("Ingresa una Contraseña:");
            var password = Console.ReadLine();
            Console.WriteLine("Ingresala Nuevamente :");
            var password2 = Console.ReadLine();
            
            if (password == password2 && ValidatesConsole.IsValidPassword(password))
            {
                UserDataAccess.InsertUser(username, password , 1);
                ShowLogin();
            }   
            else
            {
                Console.WriteLine("las contraseñas son disntitas\n");
                RegisterClientView();
                
            }
        }

        public void ShowLogin()
        {
            Console.Clear();
            Console.WriteLine("--------------------");
            Console.WriteLine("        Login       ");
            Console.WriteLine("ingresar usario:");
            var username = Console.ReadLine();
            Console.WriteLine("ingresar Contraseña:");
            var password = Console.ReadLine();
            var userTable = new DataTable() ;

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
                var menu = new Menu();
                menu.showMenus();
            }
            else
            {
                Console.WriteLine("Algun dato no es valido");
                ShowLogin();
            }
        }
    }
}
