using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public partial class Crust
    {
        public int CrustId { get; set; }
        public string CrustName { get; set; }
        public decimal Price { get; set; }
    }
}
