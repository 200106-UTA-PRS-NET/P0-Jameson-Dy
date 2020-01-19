using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderPizzasMap = new HashSet<OrderPizzasMap>();
            PizzaToppingsMap = new HashSet<PizzaToppingsMap>();
            RestaurantPizzasMap = new HashSet<RestaurantPizzasMap>();
        }

        public int PizzaId { get; set; }
        public int CrustId { get; set; }
        public int SauceId { get; set; }
        public int CheeseId { get; set; }
        public int SizeId { get; set; }
        public decimal? PriceTotal { get; set; }
        public string PizzaName { get; set; }

        public virtual Cheese Cheese { get; set; }
        public virtual Crust Crust { get; set; }
        public virtual Sauce Sauce { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<OrderPizzasMap> OrderPizzasMap { get; set; }
        public virtual ICollection<PizzaToppingsMap> PizzaToppingsMap { get; set; }
        public virtual ICollection<RestaurantPizzasMap> RestaurantPizzasMap { get; set; }
    }
}
