using System;
using System.Collections.Generic;
using System.Text;



namespace PizzaBox.Domain.Models
{

    public class Pizza
    {
        public int id { get; set; }
        public string name { get; set; }
        public float totalPrice { get; set; }
        public float origPrice { get; set; }

        public enum Crust
        {
            Regular = 0,
            Thin = 2,
            Cheesy = 3,
        }

        public enum Size
        {
            Small = -2,
            Medium = 0,
            Large = 3,
        }

        public Crust crust { get; set; }
        public Size size { get; set; }

        public Pizza() { }
        public Pizza(int id, string name )
        {
            this.id = id;
            this.name = name;
            origPrice = 8f;
            totalPrice = origPrice;
            crust = Crust.Regular;
            size = Size.Medium;
        }

        public Pizza(int id, string name, float price = 8f)
        {
            this.id = id;
            this.name = name;
            origPrice = price;
            totalPrice = origPrice;
            crust = Crust.Regular;
            size = Size.Medium;
        }
        
        public float SetSize(Size size)
        {
            this.size = size;
            totalPrice = origPrice + (float)size + (float) crust;
            Console.WriteLine("change size to" + size + " nprice: " + totalPrice);
            return totalPrice;
        }

        public float SetCrust(Crust crust)
        {
            this.crust = crust;
            totalPrice = origPrice + (float) size + (float)crust;
            Console.WriteLine("change crust to" + crust + " nprice: " + totalPrice);
            return totalPrice;
        }

        public Pizza(int id, string name, float price = 8f, Crust crust = Crust.Regular, Size size = Size.Medium)
        {
            this.id = id;
            this.name = name;
            origPrice = price;
            totalPrice = origPrice;
            this.crust = crust;
            this.size = size;
        }
    }
}
