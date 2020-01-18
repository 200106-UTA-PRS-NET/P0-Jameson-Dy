using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public partial class Cheese
    {
        public int CheeseId { get; set; }
        public string CheeseName { get; set; }
        public decimal Price { get; set; }
    }
}
