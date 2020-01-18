using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public partial class Sauce
    {
        public int SauceId { get; set; }
        public string SauceName { get; set; }
        public decimal Price { get; set; }
    }
}
