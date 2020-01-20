using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interface
{
    public interface IPizzasRepo
    {
        public decimal GetTotalPrice(int pizzaID);
        public decimal GetTotalPrice(Pizza p);
        public decimal GetTotalPrice(Pizza p, decimal restaurantMarkup);

        public Pizza GetPizzaByID(int pizzaID);
        public bool SetCurrentPizza(int pizzaID, Restaurants r);
        public Pizza GetCurrentPizza();
        public void DisplayCurrPizzaInfo();
        public void DisplayToppingsInfo(ICollection<PizzaToppingsMap> ptm);
        public void DisplayFullPizzaInfo(Pizza p, decimal restaurantMarkup);
        public void DisplayPizzaInfo(Pizza p);
    }
}
