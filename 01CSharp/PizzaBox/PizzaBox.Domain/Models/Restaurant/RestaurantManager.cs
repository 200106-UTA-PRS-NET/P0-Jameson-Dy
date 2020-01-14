using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    public sealed class RestaurantManager
    {
        private static readonly RestaurantManager instance = new RestaurantManager();
        private static Dictionary<int, Restaurant> restaurants = new Dictionary<int, Restaurant>();

        //private int totalStores;
        private static Restaurant currStore;

        static RestaurantManager()
        {
        }
        private RestaurantManager()
        {
        }

        public static RestaurantManager Instance
        {
            get
            {
                return instance;
            }
        }

        public List<Restaurant> GetRestaurantList()
        {
            return new List<Restaurant>(restaurants.Values);
        }

        public List<int> GetRestaurantIDList()
        {
            return new List<int>(restaurants.Keys);
        }

        // add store using PizzaStore obj
        public bool AddStore(Restaurant store)
        {
            if (store != null)
            {
                restaurants.Add(store.id, store);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Restaurant GetCurrStore()
        {
            return currStore;
        }

        public void SetCurrStore(int storeID)
        {
            currStore = restaurants[storeID];
        }

        public void AddPizzaToStore(Pizza p, Restaurant store)
        {
            store.AddPizza(p);
        }
    }
}
