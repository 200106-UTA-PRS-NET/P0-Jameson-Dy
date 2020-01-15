using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    public class Restaurant
    {
        public int restaurantID { get; set; }
        public string restaurantName { get; set; }
        public List<int> orderHistoryID { get; set; }   // list of orders obtained by orderID
        public List<Pizza> presetPizzas { get; set; }

        public virtual void Greetings() 
        {
            Console.WriteLine("\nWelcome to Generic Pizza Store");
        }
    }
}
