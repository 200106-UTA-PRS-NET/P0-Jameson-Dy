using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interface
{
    public interface IOrdersRepo
    {
        public Orders GetCurrentOrder();
        public IEnumerable<Orders> GetOrders();
        public IEnumerable<Pizza> GetOrderPizzas(int orderID);
        public List<Pizza> GetCurrOrderPizzas();
        public void RemoveCurrOrder();
        public void AddPizzaToOrder(Pizza p, int customerID, int restaurantID);

        public decimal GetSubtotal();
        public decimal GetCurrOrderTotalPrice();

        public void ViewOrderHistory(int customerID);
        public bool SubmitOrder(int customerID, int restaurantID)
;

    }
}
