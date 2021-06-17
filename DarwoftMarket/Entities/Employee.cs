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
        public int idBoss { get; set; }


        public Employee(int ID , string name, string surname, int boss )
        {
            this.ID = ID;
            this.Name = name;
            this.Surname = surname;
            this.idBoss = boss;
            
        }
        
    }
}
