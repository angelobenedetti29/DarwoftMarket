﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DarwoftMarket.Entities
{
    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Product(int ID, string name, string description, int quantity)
        {
            this.ID = ID;
            this.Name = name;
            this.Description = description;
            this.Quantity = quantity;

        }

        
    }
}
