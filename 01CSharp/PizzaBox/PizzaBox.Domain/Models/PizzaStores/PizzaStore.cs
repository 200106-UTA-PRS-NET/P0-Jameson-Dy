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
        private Pizza currPizza;
        private List<Order> completedOrders;
        private Order currOrder;

        public virtual void Greetings() 
        {
            Console.WriteLine("\nWelcome to Generic Pizza Store");
        }

        public List<Pizza> GetPizzaList()
        {
            return pizzas;
        }
    }
}
