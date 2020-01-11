using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    public class PizzaStore
    {
        public string name { get; set; }
        public int id { get; set; }
        private List<Pizza> pizzas;

        public virtual void Greetings() 
        {
            Console.WriteLine("\nWelcome to Generic Pizza Store");
        }
    }
}
