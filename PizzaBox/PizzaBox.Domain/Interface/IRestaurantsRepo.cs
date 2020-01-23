using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interface
{
    public interface IRestaurantsRepo
    {
        public IEnumerable<Restaurants> GetRestaurants();
        public Restaurants GetCurrentRestaurant();
        public List<int> GetRestaurantIDList();
        public bool SetCurrentRestaurant(int id);
        public bool SetCurrentRestaurant(Restaurants r);
        public void RemoveCurrentRestaurant();
        public IEnumerable<Pizza> GetCurrRestaurantPizzas();

        public DateTime? GetLastOrderDate(int restaurantID, int customerID);
        public List<int> GetCurrRestaurantPizzaIDList();

    }
}
