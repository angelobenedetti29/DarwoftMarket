using DarwoftMarket.DataAccess;
using DarwoftMarket.ProjectUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DarwoftMarket.Menus
{
    public static class RegisterClientMenu
    {
        public static void CreateClient(string username, string password)
        {
            UserDataAccess.InsertUser(username, password, 1);
            var user = UserDataAccess.GetUser(username, password);
            var id = Convert.ToInt32(user.Rows[0][0]);
            RegisterClient(id);
            Login.ShowLogin();

        }

        public static void RegisterClient(int id)
        {
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Ahora Ingresame Tus datos Personales");
            Console.WriteLine("ingresa tu nombre:");
            var name = Console.ReadLine();
            Console.WriteLine("ingresa tu apellido:");
            var surname = Console.ReadLine();
            var ClientExist = ClientDataAccess.GetClient(name, surname);
            
            if (ClientExist.Rows.Count <= 0)
            {
                ClientDataAccess.InsertClint(id, name, surname);
 
            }
            else
            {
                RegisterClient(id);
            }
        }

        public static void RegisterUserView()
        {

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Ya que sos nuevo ! Nos registramos\n");
            Console.WriteLine("La contraseña debe tener al menos:\n" +
                              "-una mayuscula\n" +
                              "-una minscula\n" +
                              "-un numero\n" +
                              "-un caracter\n");

            Console.WriteLine("Ingresa un Usario:");
            var username = Console.ReadLine();
            Console.WriteLine("Ingresa una Contraseña:");
            var password = Console.ReadLine();
            Console.WriteLine("Ingresala Nuevamente :");
            var password2 = Console.ReadLine();
            Console.Clear();
            if (UserDataAccess.GetUsername(username) == false && password == password2 && ValidatesConsole.IsValidPassword(password))
            {
                CreateClient(username,password);
                //UserDataAccess.InsertUser(username, password, 1);
                //var user = UserDataAccess.GetUser(username, password);
                //Login.ShowLogin();
            }
            else
            {
                Console.WriteLine("las contraseñas son disntitas\n" +
                                  "o  el usario ya existe");
                RegisterUserView();

            }
        }

    }
}
