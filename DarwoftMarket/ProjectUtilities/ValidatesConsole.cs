using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DarwoftMarket.ProjectUtilities
{
    public class ValidatesConsole
    {
        public static bool IsValidPassword(string password)
        {
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,30}$", RegexOptions.Compiled).IsMatch(password);
            if (regex)
            {
                return true;
            }
            else
            {
                Console.WriteLine("La contraseña no cumple con las politicas");
                return false;
            }
        }

        public static string ValidateInputString()
        {
            var con = true;
            string input = "";
            while (con)
            {
                input = Console.ReadLine().Trim();
                int value;
                if (!int.TryParse(input, out value))
                {
                    con = false;
                }
                else
                {
                    
                    Console.WriteLine("No ingresaste un String , ingresa Otro valor: ");

                }
            }
            return input;
        }

        public static int ValidateInputInt()
        {
            var con = true;
            var input = 0;
            while (con)
            {
                string inputString = Console.ReadLine().Trim();
                int value;
                if (int.TryParse(inputString, out value))
                {
                    input = int.Parse(inputString);
                    con = false;
                }
                else
                {

                    Console.WriteLine("No ingresaste un int , ingresa Otro valor: ");

                }
            }
            return input;

        }
        public static float ValidateInputFloat()
        {
            var con = true;
            float input = 0;
            while (con)
            {
                string inputString = Console.ReadLine().Trim();
                int value;
                if (int.TryParse(inputString, out value))
                {
                    input = float.Parse(inputString) ;
                    con = false;
                }
                else
                {
                    Console.WriteLine("No ingresaste un float , ingresa Otro valor: ");

                }
            }
            return input;

        }
    }
}
