using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    public class Restaurant
    {
        public string name { get; set; }
        public int id { get; set; }
        private Dictionary<int, Pizza> pizzas = new Dictionary<int, Pizza>();

        private Pizza currPizza;
        private List<Order> completedOrders = new List<Order>();
        private Order currOrder;

        public virtual void Greetings() 
        {
            Console.WriteLine("\nWelcome to Generic Pizza Store");
        }

        public List<Pizza> GetPizzaList()
        {
            return new List<Pizza>(pizzas.Values);
        }
        public List<int> GetPizzaIDList()
        {
            return new List<int>(pizzas.Keys);
        }

        public Pizza GetPizzaByID(int id)
        {
            return pizzas[id];
        }

        public void AddPizza(Pizza p)
        {
            pizzas.Add(p.id, p);
        }

        public void AddOrder(Order o)
        {
            completedOrders.Add(o);
        }
    }
}
