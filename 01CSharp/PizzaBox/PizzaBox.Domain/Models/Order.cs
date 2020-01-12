using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    public class Order
    {
        private long id;
        private string customerName;
        private int customerID;
        private float totalPrice;
        private List<Pizza> pizzaList = new List<Pizza>();

        public Order() { }

        public Order(List<Pizza> pizzaList, int customerID, float totalPrice, string customerName)
        {
            this.pizzaList = pizzaList;
            this.customerID = customerID;
            this.totalPrice = totalPrice;
            this.customerName = customerName;
        }

        public void DisplayOrder()
        {
            foreach (var pizza in pizzaList)
            {
                Console.WriteLine("Pizza " + pizza.name);
                Console.WriteLine("total price " + totalPrice);
            }
        }

    }
}
