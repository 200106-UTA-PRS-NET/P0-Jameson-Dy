using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public partial class Orders
    {
        public Orders()
        {
            OrderPizzasMap = new HashSet<OrderPizzasMap>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? RestaurantId { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Restaurants Restaurant { get; set; }
        public virtual ICollection<OrderPizzasMap> OrderPizzasMap { get; set; }
    }
}
