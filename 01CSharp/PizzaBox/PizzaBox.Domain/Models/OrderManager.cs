using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    public sealed class OrderManager
    {
        private static readonly OrderManager instance = new OrderManager();
        private static Order currOrder = new Order();

        static OrderManager() { }
        private OrderManager() { }
        

    }
}
