using PizzaBox.Domain;
using PizzaBox.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
    public class OrdersRepo : IOrdersRepo
    {
        readonly PizzaBoxDbContext db;
        readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        static Orders currOrder = new Orders();
        static List<Pizza> currPizzas = new List<Pizza>();

        public OrdersRepo()
        {
            db = new PizzaBoxDbContext();
        }
        public OrdersRepo(PizzaBoxDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Orders GetCurrentOrder()
        {
            return currOrder;
        }

        public IEnumerable<Pizza> GetOrderPizzas(int orderID)
        {
            var query = from op in db.OrderPizzasMap
                        where op.OrderId == orderID
                        select op.Pizza;
            return query;
        }

        public List<Pizza> GetCurrOrderPizzas()
        {
            return currPizzas;
        }

        public IEnumerable<Orders> GetOrders()
        {
            var query = from o in db.Orders
                        select o;
            return query;
        }


        public void AddPizzaToOrder(Pizza p, int customerID, int restaurantID)
        {
            currPizzas.Add(p);            
        }

        public void RemoveCurrOrder()
        {
            currOrder = null;
            currPizzas.Clear();
        }

        public decimal GetCurrOrderTotalPrice()
        {

            decimal total = 0;
            foreach(Pizza p in currPizzas)
            {
                total += p.PriceTotal.Value;
            }
            return total;

        }

        public decimal GetSubtotal()
        {
            return currPizzas.Sum(p => p.PriceTotal).Value;
        }

        public bool SubmitOrder(int customerID, int restaurantID)
        {
            currOrder = new Orders();

            currOrder.CustomerId = customerID;
            currOrder.RestaurantId = restaurantID;
            currOrder.TotalPrice = GetSubtotal();

            // add order
            db.Orders.Add(currOrder);
            db.SaveChanges();   

            // add to orderpizzasmap
            int currOrderID = currOrder.OrderId;

            Dictionary<int, int> pizzaIDCount = new Dictionary<int, int>();
            foreach (Pizza p in currPizzas)
            {
                if (pizzaIDCount.ContainsKey(p.PizzaId))
                {
                    // already in dict
                    pizzaIDCount[p.PizzaId]++;
                }
                else
                {
                    pizzaIDCount.Add(p.PizzaId, 1);
                }
            }

            var currPizzasDistinct = currPizzas.Select(p => p.PizzaId).Distinct();

            foreach(int pizzaId in currPizzasDistinct)
            {
                db.OrderPizzasMap.Add(new OrderPizzasMap() { OrderId = currOrderID, PizzaId = pizzaId, Quantity = pizzaIDCount[pizzaId] });
            }
            db.SaveChanges();

            Console.WriteLine("\n" + "You dropped $ " + currOrder.TotalPrice.Value.ToString("0.00"));
            Console.ReadKey(true);
            RemoveCurrOrder();


            return true;
        }

        public void ViewOrderHistory(int customerID)
        {
            var orders = db.Orders.Where(o => o.CustomerId == customerID).OrderByDescending(o => o.OrderDate);
            var restaurants = db.RestaurantPizzasMap.Select(r => r.Restaurant).Distinct();

            Dictionary<int, string> restaurantDict = new Dictionary<int, string>();
            foreach(Restaurants r in restaurants)
            {
                restaurantDict.Add(r.RestaurantId, r.RestaurantName);
            }

            Console.WriteLine("\n" + "Total Orders: " + orders.Count());
            Console.WriteLine("\n" + "Order#".PadRight(10) + "Restaurant".PadRight(20) + "Total".PadRight(15) + "Date".PadRight(15) + "Time".PadRight(10));
            Console.WriteLine("".PadLeft(80, '-'));

            foreach (Orders o in orders)
            {
                string id = o.OrderId.ToString("00000");
                string total = o.TotalPrice.Value.ToString("0.00");
                string restaurant = restaurantDict[o.RestaurantId.Value];
                string date = String.Format("{0:M/d/yyyy}", o.OrderDate.Value);
                string time = String.Format("{0:t}", o.OrderDate.Value);

                Console.WriteLine(id.PadRight(10) + restaurant.PadRight(20) + $"$ {total}".PadRight(15) + date.PadRight(15) + time.PadRight(10));
            }
        }

        public void ViewOrderHistory(int customerID, int restaurantID)
        {
            var orders = db.Orders.Where(o => o.CustomerId == customerID && o.RestaurantId == restaurantID).OrderByDescending(o => o.OrderDate);
            var restaurant = db.Restaurants.Where(r => r.RestaurantId == restaurantID).Single();
            var customer = db.Customers.Where(c => c.CustomerId == customerID).Single();

            string customerName = textInfo.ToTitleCase(customer.FirstName) + " " + textInfo.ToTitleCase(customer.LastName);
            
            Console.WriteLine("\n" + $"{customerName} orders from {restaurant.RestaurantName}: " + orders.Count().ToString());
            Console.WriteLine("\n" + "Order#".PadRight(10) + "Total".PadRight(15) + "Date".PadRight(15) + "Time".PadRight(10));
            foreach (Orders o in orders)
            {
                string id = o.OrderId.ToString("00000");
                string total = o.TotalPrice.Value.ToString("0.00");
                string date = String.Format("{0:M/d/yyyy}", o.OrderDate.Value);
                string time = String.Format("{0:t}", o.OrderDate.Value);

                Console.WriteLine(id.PadRight(10) + $"$ {total}".PadRight(15) + date.PadRight(15) + time.PadRight(10));
            }
        }

        public void ViewStoreOrderHistory(int restaurantID)
        {
            var orders = db.Orders.Where(o => o.RestaurantId == restaurantID).OrderByDescending(o => o.OrderDate);
            var restaurant = db.Restaurants.Where(r => r.RestaurantId == restaurantID).Single();

            Console.WriteLine("\n" + $"{restaurant.RestaurantName} total orders: " + orders.Count());
            Console.WriteLine("\n" + "Order#".PadRight(10) + "Total".PadRight(15) + "Date".PadRight(15) + "Time".PadRight(10));
            foreach (Orders o in orders)
            {
                string id = o.OrderId.ToString("00000");
                string total = o.TotalPrice.Value.ToString("0.00");
                string date = String.Format("{0:M/d/yyyy}", o.OrderDate.Value);
                string time = String.Format("{0:t}", o.OrderDate.Value);

                Console.WriteLine(id.PadRight(10) + $"$ {total}".PadRight(15) + date.PadRight(15) + time.PadRight(10));
            }

        }
    }
}
