using DarwoftMarket.DataAccess;
using DarwoftMarket.ProjectUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DarwoftMarket.Menus
{
    class Usermenu
    {
        public static Array RegisteUserView()
        {
            var userArray = new string[3];

            var con = true;
            while (con)
            {

                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("                         Menu para registrar un Usario\n");
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
                    userArray[0] = username;
                    userArray[1] = password;
                    userArray[2] = "1";
                    con = false;
                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("las contraseñas son disntitas\n" +
                                     "o  el usario ya existe");

                }  
            }
          
            return userArray;
        }
    }
}
