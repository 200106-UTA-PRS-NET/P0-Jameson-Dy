using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public partial class OrderPizzasMap
    {
        public int OrderId { get; set; }
        public int PizzaId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
