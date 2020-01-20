using PizzaBox.Domain;
using PizzaBox.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
    public class RestaurantsRepo : IRestaurantsRepo
    {
        readonly PizzaBoxDbContext db;
        readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        static Restaurants currRestaurant = new Restaurants();

        public RestaurantsRepo()
        {
            db = new PizzaBoxDbContext();
        }
        public RestaurantsRepo(PizzaBoxDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Restaurants GetCurrentRestaurant()
        {
            return currRestaurant;
        }

        public IEnumerable<Restaurants> GetRestaurants()
        {
            var query = from e in db.Restaurants
                        select e;
            return query;

        }

        public List<int> GetRestaurantIDList()
        {
            var query = from e in db.Restaurants
                        select e.RestaurantId;
            return new List<int>(query).ToList();
        }

        public bool SetCurrentRestaurant(int id)
        {

            var restaurant = db.Restaurants.Where(r => r.RestaurantId == id);
            var pizzamap = db.RestaurantPizzasMap.Where(m => m.RestaurantId == id);

            try
            {
                currRestaurant = restaurant.Single();
                currRestaurant.RestaurantPizzasMap = pizzamap.ToHashSet();

            } catch (ArgumentNullException)
            {
                // id not in query
                return false;
            }
            return true;
        }

        public bool SetCurrentRestaurant(Restaurants r)
        {
            if (r != null)
            {
                currRestaurant = r;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveCurrentRestaurant()
        {
            currRestaurant = null;

        }

        public IEnumerable<Pizza> GetCurrRestaurantPizzas()
        {
            var query = from p in db.Pizza
                        from r in db.Restaurants
                        from rp in db.RestaurantPizzasMap
                        where p.PizzaId == rp.PizzaId && r.RestaurantId == rp.RestaurantId && currRestaurant.RestaurantId == r.RestaurantId
                        select p;

            return query;                    
        }


        public List<int> GetCurrRestaurantPizzaIDList()
        {
            var query = from rp in db.RestaurantPizzasMap
                        where rp.RestaurantId == currRestaurant.RestaurantId
                        select rp.PizzaId;
            return query.ToList();
        }
    }
}
