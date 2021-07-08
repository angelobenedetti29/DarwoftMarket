using DarwoftMarket.DataAccess;
using DarwoftMarket.ProjectUtilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DarwoftMarket.Menus
{
    class BossMenu
    {
        public static Array RegisterEmployee()
        {
            var employeeArray = new string[2];
            var con = true;
            while (con)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine($"ingresa los datos para Cargar un nuevo Empleado ");
                Console.WriteLine("ingresa tu nombre:");
                var name = ValidatesConsole.ValidateInputString() ;
                Console.WriteLine("ingresa tu apellido:");
                var surname = ValidatesConsole.ValidateInputString();
                var employeeExist = EmployeeDataAccess.GetEmployee(name, surname);
              
                if (employeeExist.Rows.Count <= 0)
                {

                    employeeArray[0] = name;
                    employeeArray[1] = surname;
                    con = false;
                }
                else
                {

                    Console.Clear();
                }
            }
            return employeeArray;
        }
    }
}
