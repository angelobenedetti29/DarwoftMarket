using System;
using System.Collections.Generic;
using System.Text;

namespace DarwoftMarket.Entities
{
    class Client : User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public float Amount { get; set; }
        


        public Client()
        {

        }

        public Client(int ID, string name, string surname, float amount)
        {
            this.ID = ID;
            this.Name = name;
            this.Surname = surname;
            this.Amount = amount;
            
        }
    }
}
