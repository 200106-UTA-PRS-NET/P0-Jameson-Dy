using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Domain.Models
{
    public class CustomerDAO
    {
        private static readonly CustomerDAO instance = new CustomerDAO();

        static CustomerDAO(){ }
        private CustomerDAO() {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("<name you gave to the data source>"));
            var options = optionsBuilder.Options;
        }

        public static CustomerDAO Instance
        {
            get {return instance;}
        }

        static IEnumerable<Customer> GetCustomers(PizzaBoxDbContext db)
        {
            var query = from e in db.Customer
                        select e;
            return query;
        }
    }
}

