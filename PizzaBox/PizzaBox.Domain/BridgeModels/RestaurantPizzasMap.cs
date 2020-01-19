using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public partial class RestaurantPizzasMap
    {
        public int RestaurantId { get; set; }
        public int PizzaId { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual Restaurants Restaurant { get; set; }
    }
}
