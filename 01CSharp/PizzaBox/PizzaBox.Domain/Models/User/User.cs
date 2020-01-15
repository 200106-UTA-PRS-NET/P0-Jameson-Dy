using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain
{
    public class User
    {
        public int userID { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<int> orderHistoryID { get; set; }   // list of orders obtained by orderID
        public Order lastOrder { get; set; }

        public User() { }

        
    }
}
