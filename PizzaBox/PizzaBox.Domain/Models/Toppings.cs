using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public partial class Toppings
    {
        public Toppings()
        {
            PizzaToppingsMap = new HashSet<PizzaToppingsMap>();
        }

        public int ToppingId { get; set; }
        public string ToppingName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<PizzaToppingsMap> PizzaToppingsMap { get; set; }
    }
}
