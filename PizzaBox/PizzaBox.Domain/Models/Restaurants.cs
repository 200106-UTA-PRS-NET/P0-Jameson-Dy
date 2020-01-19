using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public partial class Restaurants
    {
        public Restaurants()
        {
            Orders = new HashSet<Orders>();
            RestaurantPizzasMap = new HashSet<RestaurantPizzasMap>();
        }

        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public decimal? RestaurantMarkup { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<RestaurantPizzasMap> RestaurantPizzasMap { get; set; }
    }
}
