using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain
{
    public class User
    {
        private string name;
        public int id { get; set; }
        private List<Order> orderHistory;
        public string userName { get; set; }
        public string password { get; set; }

        public User() { }

        public User(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

    }
}
