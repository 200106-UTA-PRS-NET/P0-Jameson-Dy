using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Interfaces;

namespace PizzaBox.Client
{
    public static class Dependencies
    {
        public static ICustomerRepo CreateCustomerRepository()
        {
            PizzaBoxDbContext db = new PizzaBoxDbContext(ConfigBuilderSystem.Instance.GetOptions());
            return new CustomerRepo(db);
        }

    }
}
