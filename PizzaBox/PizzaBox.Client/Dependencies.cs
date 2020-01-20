using PizzaBox.Domain;
using PizzaBox.Domain.Interface;
using PizzaBox.Storing.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Client
{
    public static class Dependencies
    {
        public static ICustomersRepo CreateCustomerRepository()
        {
            PizzaBoxDbContext db = DatabaseSystemBuilder.Instance.GetDatabase();
            return new CustomersRepo(db);
        }
        public static IRestaurantsRepo CreateRestaurantRepository()
        {
            PizzaBoxDbContext db = DatabaseSystemBuilder.Instance.GetDatabase();
            return new RestaurantsRepo(db);
        }

        public static IPizzasRepo CreatePizzaRepository()
        {
            PizzaBoxDbContext db = DatabaseSystemBuilder.Instance.GetDatabase();
            return new PizzasRepo(db);
        }

        public static IOrdersRepo CreateOrderRepository()
        {
            PizzaBoxDbContext db = DatabaseSystemBuilder.Instance.GetDatabase();
            return new OrdersRepo(db);
        }
    }
}
