using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain
{
    public class User
    {
        private string name;
        public int id { get; set; }
        private List<Order> orderHistory = new List<Order>();
        private List<int> orderHistoryID = new List<int>();
        public string userName { get; set; }
        public string password { get; set; }

        public User() { }

        public User(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public void AddOrder(Order order)
        {
            orderHistory.Add(order);
        }

        public List<Order> GetOrderHistory()
        {
            return orderHistory;
        }
    }
}
