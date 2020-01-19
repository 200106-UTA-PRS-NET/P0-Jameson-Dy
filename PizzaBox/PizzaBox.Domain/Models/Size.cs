using System;
using System.Collections.Generic;

namespace PizzaBox.Domain
{
    public partial class Size
    {
        public Size()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int SizeId { get; set; }
        public string Size1 { get; set; }
        public double? PriceMultiplier { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
