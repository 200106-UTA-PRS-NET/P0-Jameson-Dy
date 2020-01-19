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
    }
}
