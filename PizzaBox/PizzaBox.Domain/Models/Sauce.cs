using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public partial class Sauce
    {
        public Sauce()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int SauceId { get; set; }
        public string SauceName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
