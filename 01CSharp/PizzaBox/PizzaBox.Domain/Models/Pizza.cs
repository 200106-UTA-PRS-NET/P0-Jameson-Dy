using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{

    public class Pizza
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }

        private string crust;
        private int size;

        public Pizza() { }
        public Pizza(int id, string name )
        {
            this.id = id;
            this.name = name;
            this.price = 8f;

        }

        public Pizza(int id, string name, float price = 8f)
        {
            this.id = id;
            this.name = name;
            this.price = price;

        }
    }
}
