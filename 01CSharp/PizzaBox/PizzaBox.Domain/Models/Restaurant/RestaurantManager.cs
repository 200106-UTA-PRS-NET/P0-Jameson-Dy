using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    public sealed class RestaurantManager
    {
        private static readonly RestaurantManager instance = new RestaurantManager();
        private static Dictionary<int, Restaurant> restaurants = new Dictionary<int, Restaurant>();
        private static Restaurant currRestaurant;

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

        private List<string> GetRestaurantNameList()
        {
            List<string> names = new List<string>();
            foreach(Restaurant r in restaurants.Values)
            {
                names.Add(r.restaurantName);
            }
            return names;
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
        public bool AddRestaurant(Restaurant store)
        {
            if (store != null)
            {
                if (GetRestaurantNameList().Contains(store.restaurantName))
                {
                    Console.WriteLine("Restaurant name" + "(" + store.restaurantName + ") is already taken");
                    return false;
                }

                int newID = restaurants.Count + 1;

                store.restaurantID = newID;
                restaurants.Add(newID, store); //TODO: better indexing
                Console.WriteLine("Added " + restaurants[restaurants.Count].restaurantID + " " + restaurants[restaurants.Count].restaurantName);
                return true;
            }
            else
            {
                Console.WriteLine("Adding restaurant failed");
                return false;
            }
        }

        public Restaurant GetCurrStore()
        {
            return currRestaurant;
        }

        public void SetCurrStore(int storeID)
        {
            currRestaurant = restaurants[storeID];
        }

        public void AddPizzaToStore(Pizza p, Restaurant store)
        {
            store.AddPizza(p);
        }
    }
}
