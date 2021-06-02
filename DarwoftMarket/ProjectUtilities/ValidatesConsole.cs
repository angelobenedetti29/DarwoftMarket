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
    }
}
