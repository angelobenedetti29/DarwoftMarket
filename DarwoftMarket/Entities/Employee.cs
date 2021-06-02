using System;
using System.Collections.Generic;
using System.Text;

namespace DarwoftMarket.Entities
{
    class Employee : User
    {
        public Employee()
        {

        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Boss { get; set; }


        public Employee(int ID , string name, string surname, int boss )
        {
            this.ID = ID;
            this.Name = name;
            this.Surname = surname;
            this.Boss = boss;
            
        }
        
    }
}
