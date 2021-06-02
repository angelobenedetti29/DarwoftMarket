using System;
using System.Collections.Generic;
using System.Text;

namespace DarwoftMarket.Entities
{
    class Boss : User
    { 
        
        public string Name { get; set; }
        public string Surname { get; set; }

        public Boss()
        {

        }

        public Boss(int id, string name, string surname)
        {
            //no es obligatorio usar el this
            ID = id;
            Name = name;
            Surname = surname;
        }
    }
}
