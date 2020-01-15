using System;
using System.Collections.Generic;
using System.Text;



namespace PizzaBox.Domain.Models
{

    public class Pizza
    {
        public int id { get; set; }
        public string name { get; set; }
        private float totalPrice;
        private float businessMarkup;

        public enum Crust
        {
            Regular = 5,
            Thin = 6,
            Cheesy = 7,
        }

        public enum Size
        {
            Small = -2,
            Medium = 0,
            Large = 3,
        }

        public enum Sauce
        {
            Red = 1,
            White = 1,
            Secret = 2
        }

        public enum Toppings
        {
            Pepperoni = 1,
            Mushrooms = 1,
            Onions = 1,
            Sausage = 1,
            Bacon = 2,
            ExtraCheese = 1,
            BlackOlives = 1,
            GreenPeppers = 1,
            Pineapple = 1,
            Spinach = 1,
            Banana = 10
        }



        public Crust crust { get; set; }
        public Size size { get; set; }
        public Sauce sauce { get; set; }
        private List<Toppings> toppings = new List<Toppings>();

        public Pizza() { }

        public Pizza(int id, string name)
        {
            // Default Pizza
            this.id = id;
            this.name = name;
            crust = Crust.Regular;
            size = Size.Medium;
            sauce = Sauce.Red;

            toppings.Add(Toppings.Pepperoni);
            toppings.Add(Toppings.Mushrooms);

            totalPrice = (float)size + (float)crust + GetToppingsPrice() + businessMarkup;
        }

        public Pizza(int id, string name, float businessMarkup)
        {
            // Default Pizza
            this.id = id;
            this.name = name;
            crust = Crust.Regular;
            size = Size.Medium;
            sauce = Sauce.Red;

            toppings.Add(Toppings.Pepperoni);
            toppings.Add(Toppings.Mushrooms);

            totalPrice =  (float)size + (float)crust + GetToppingsPrice() + businessMarkup;
        }

        private float GetToppingsPrice()
        {
            float toppingsPrice = 0;
            foreach (Toppings t in toppings)
            {
                toppingsPrice += (float)t;
            }
            return toppingsPrice;
        }
        public void SetSize(Size size)
        {
            this.size = size;
        }

        public void SetCrust(Crust crust)
        {
            this.crust = crust;
        }

        public void SetToppings(List<Toppings> toppings)
        {
            this.toppings = toppings;
        }

        public float GetTotalPrice()
        {
            return (float)crust + (float)size + (float)sauce + GetToppingsPrice();
        }
    }
}
