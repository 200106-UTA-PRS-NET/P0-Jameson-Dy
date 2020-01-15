using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    public class Order
    {
        private int id;
        private int customerID;
        private int restaurantID;
        private float totalPrice;
        private List<Pizza> pizzaOrders = new List<Pizza>();

        public Order() { }

        public Order(List<Pizza> pizzaOrders, int customerID, int restaurantID)
        {
            this.pizzaOrders = pizzaOrders;
            this.customerID = customerID;
            this.restaurantID = restaurantID; 
        }

        public void DisplayOrder()
        {
            foreach (var pizza in pizzaOrders)
            {
                Console.WriteLine("Pizza " + pizza.name);
                Console.WriteLine("total price " + totalPrice);
            }
        }

    }
}
