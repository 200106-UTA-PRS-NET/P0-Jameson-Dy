using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    public sealed class OrderManager
    {
        private static readonly OrderManager instance = new OrderManager();
        private static Order currOrder = new Order();
        private static Pizza selectedPizza = new Pizza();

        static OrderManager() { }
        private OrderManager() { }

        public static OrderManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void SetCurrPizza(Pizza p)
        {
            selectedPizza = p;
        }
        public Pizza GetCurrPizza()
        {
            return selectedPizza;
        }

        public void SubmitOrder(Order order)
        {
            User user = AccountManager.Instance.GetCurrUser();
            user.AddOrder(order);

            Restaurant store = RestaurantManager.Instance.GetCurrStore();
            store.AddOrder(order);
        }

    }
}
