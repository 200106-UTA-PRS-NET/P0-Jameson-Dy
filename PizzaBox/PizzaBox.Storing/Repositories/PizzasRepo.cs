using PizzaBox.Domain;
using PizzaBox.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
    public class PizzasRepo : IPizzasRepo
    {
        readonly PizzaBoxDbContext db;
        readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        static Pizza currPizza = new Pizza();
        static List<Toppings> currToppings = new List<Toppings>();

        public PizzasRepo()
        {
            db = new PizzaBoxDbContext();
        }
        public PizzasRepo(PizzaBoxDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Pizza GetPizzaByID(int pizzaID)
        {
            var query = from p in db.Pizza
                        where p.PizzaId == pizzaID
                        select p;

            try
            {
                return query.Single();
            } 
            catch (InvalidOperationException)
            {
                return null;
            }

        }


        public decimal GetTotalPrice(Pizza p, decimal restaurantMarkup)
        {
            var toppings = p.PizzaToppingsMap.Select(ptm => ptm.Topping).Sum(t => t.Price);
            decimal pizza = (p.Sauce.Price + p.Cheese.Price + p.Crust.Price + toppings) *  (decimal) p.Size.PriceMultiplier.Value;

            return pizza + restaurantMarkup;
        }

        public decimal GetTotalPrice(Pizza p)
        {
            decimal toppings = p.PizzaToppingsMap.Select(m => m.Topping).Sum(t => t.Price);
            decimal pizza = (p.Sauce.Price + p.Cheese.Price + p.Crust.Price + toppings) * (decimal) p.Size.PriceMultiplier.Value;
            decimal markup = p.RestaurantPizzasMap.Select(m => m.Restaurant).Select(r => r.RestaurantMarkup).Single().Value;

            return pizza + markup;
        }

        public decimal GetTotalPrice(int pizzaID)
        {
            var qToppingsPrice =    from p in db.Pizza
                                    from pt in db.PizzaToppingsMap
                                    from t in db.Toppings
                                    where p.PizzaId == pt.PizzaId &&
                                          pt.ToppingId == t.ToppingId && 
                                          pizzaID == p.PizzaId
                                    select t.Price;

            var qPizzaNoToppingsPrice = from p in db.Pizza
                                        from ch in db.Cheese
                                        from cr in db.Crust
                                        from sc in db.Sauce
                                        where p.CheeseId == ch.CheeseId &&
                                              p.CrustId == cr.CrustId &&
                                              p.SauceId == sc.SauceId &&
                                              pizzaID == p.PizzaId
                                       select ch.Price + cr.Price + sc.Price;

            var qSizePriceMultiplier = from p in db.Pizza
                                      from sz in db.Size
                                      where p.SizeId == sz.SizeId &&
                                            pizzaID == p.PizzaId
                                      select sz.PriceMultiplier;

            try
            {
                decimal toppings = qToppingsPrice.Sum();
                decimal pizza = qPizzaNoToppingsPrice.Single();
                decimal sizeMult = Convert.ToDecimal(qSizePriceMultiplier.Single());
                decimal totalPrice = (toppings + pizza) * sizeMult;
                return totalPrice;
            }
            catch (InvalidCastException)
            {
                // convertion error
                return 0;
            }
            catch (ArgumentNullException)
            {
                //sum error
                return 0;
            }
            catch (InvalidOperationException)
            {
                // pizzanotoppings error 
                return 0;
                
            }
        }

        public decimal GetTotalPrice(int pizzaID, Size size)
        {
            var qToppingsPrice = from p in db.Pizza
                                 from pt in db.PizzaToppingsMap
                                 from t in db.Toppings
                                 where p.PizzaId == pt.PizzaId &&
                                       pt.ToppingId == t.ToppingId &&
                                       pizzaID == p.PizzaId
                                 select t.Price;

            var qPizzaNoToppingsPrice = from p in db.Pizza
                                        from ch in db.Cheese
                                        from cr in db.Crust
                                        from sc in db.Sauce
                                        where p.CheeseId == ch.CheeseId &&
                                              p.CrustId == cr.CrustId &&
                                              p.SauceId == sc.SauceId &&
                                              pizzaID == p.PizzaId
                                        select ch.Price + cr.Price + sc.Price;
            try
            {
                decimal toppings = qToppingsPrice.Sum();
                decimal pizza = qPizzaNoToppingsPrice.Single();
                decimal sizeMult = Convert.ToDecimal(size.PriceMultiplier.Value);
                decimal totalPrice = (toppings + pizza) * sizeMult;
                return totalPrice;
            }
            catch (InvalidCastException)
            {
                // convertion error
                return 0;
            }
            catch (ArgumentNullException)
            {
                //sum error
                return 0;
            }
            catch (InvalidOperationException)
            {
                // pizzanotoppings error 
                return 0;

            }
        }



        public bool SetCurrentPizza(int pizzaID, Restaurants r)
        {
            var query = from p in db.Pizza
                        where p.PizzaId == pizzaID
                        select p;
            var crust = from cr in db.Crust
                        from p in db.Pizza
                        where p.CrustId == cr.CrustId && p.PizzaId == pizzaID
                        select cr;
            var cheese = from ch in db.Cheese
                        from p in db.Pizza
                        where p.CheeseId == ch.CheeseId && p.PizzaId == pizzaID
                         select ch;
            var sauce = from sc in db.Sauce
                        from p in db.Pizza
                        where p.SauceId == sc.SauceId && p.PizzaId == pizzaID
                        select sc;
            var size = from sz in db.Size
                        from p in db.Pizza
                        where p.SizeId == sz.SizeId && p.PizzaId == pizzaID
                       select sz;

            var toppings = from pt in db.PizzaToppingsMap
                           where pt.PizzaId == pizzaID
                           select pt.Topping;

            var toppingsMap = from pt in db.PizzaToppingsMap
                           where pt.PizzaId == pizzaID
                           select pt;
            try
            {
                currPizza = query.Single();
                currPizza.Crust = crust.Single();
                currPizza.Cheese = cheese.Single();
                currPizza.Sauce = sauce.Single();
                currPizza.Size = size.Single();

                currPizza.PizzaToppingsMap = toppingsMap.ToHashSet();
                currPizza.RestaurantPizzasMap.Add(new RestaurantPizzasMap() { Restaurant = r });
                currToppings = toppings.ToList();

                currPizza.PriceTotal = GetTotalPrice(currPizza);
            }
            catch (ArgumentNullException)
            {
                // id not in query
                return false;
            }

            return true;
        }

        public void SetCurrentToppings()
        {

        }

        public Pizza GetCurrentPizza()
        {
            return currPizza;
        }

        public void DisplayFullPizzaInfo(Pizza p, decimal markup)
        {
            Console.WriteLine($"Name:".PadRight(10) + p.PizzaName);
            Console.WriteLine($"Crust:".PadRight(10) + p.Crust.CrustName);
            Console.WriteLine($"Sauce:".PadRight(10) + p.Sauce.SauceName);
            Console.WriteLine($"Cheese:".PadRight(10) + p.Cheese.CheeseName);
            Console.WriteLine($"Size:".PadRight(10) + p.Size.SizeName);

            var toppings = p.PizzaToppingsMap.Select(ptm => ptm.Topping);

            Console.Write("Toppings:".PadRight(10));
            Console.Write(string.Join(", ", from tn in toppings select tn.ToppingName));    

        }

        public void DisplayPizzaInfo(Pizza p)
        {
            Console.WriteLine($"Name:".PadRight(10) + currPizza.PizzaName);
            Console.WriteLine($"Crust:".PadRight(10) + currPizza.Crust.CrustName);
            Console.WriteLine($"Sauce:".PadRight(10) + currPizza.Sauce.SauceName);
            Console.WriteLine($"Cheese:".PadRight(10) + currPizza.Cheese.CheeseName);
            Console.WriteLine($"Size:".PadRight(10) + currPizza.Size.SizeName);
        }

        public void DisplayToppingsInfo(ICollection<PizzaToppingsMap> maps)
        {


            var toppings = maps.Select(ptm => ptm.Topping);

            Console.WriteLine("\nToppings:");
            foreach (Toppings t in toppings)
            {
                Console.WriteLine("".PadRight(10) + t.ToppingName);
            }

        }

        public void DisplayCurrPizzaInfo()
        {

            //Display more fields
            Console.WriteLine($"Name:".PadRight(10) + currPizza.PizzaName);
            Console.WriteLine($"Crust:".PadRight(10) + currPizza.Crust.CrustName);
            Console.WriteLine($"Sauce:".PadRight(10) + currPizza.Sauce.SauceName);
            Console.WriteLine($"Cheese:".PadRight(10) + currPizza.Cheese.CheeseName);
            Console.WriteLine($"Size:".PadRight(10) + currPizza.Size.SizeName);

            int i = 0;
            foreach(Toppings t in currToppings)
            {
                if (i == 0)
                {
                    Console.WriteLine("\n" + "Toppings:".PadRight(10) + t.ToppingName);
                }
                else
                {
                    Console.WriteLine("".PadRight(10) + t.ToppingName);
                }
                i++;
            }

            Console.WriteLine("\n" + "Total:".PadRight(10) + GetTotalPrice(currPizza).ToString("$ 0.00"));

        }

        public void SetCurrentPizza(Pizza p)
        {
            currPizza = p;
        }

        public void SetCurrentPizzaSize(int sizeID)
        {
            var query = db.Size.Where(s => s.SizeId == sizeID).Single();

            currPizza.Size = query;
        }
    }
}
