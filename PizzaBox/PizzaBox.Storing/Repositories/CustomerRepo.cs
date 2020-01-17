using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using PizzaBox.Storing.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class CustomerRepo : ICustomerRepo
    {
        PizzaBoxDbContext db;
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        static Customer currCustomer = new Customer();

        public CustomerRepo()
        {
            db = new PizzaBoxDbContext();
        }
        public CustomerRepo(PizzaBoxDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var query = from e in db.Customer
                        select e;

            return query;
        }

        public void RegisterCustomerTest(string username, string password, string fname, string lname)
        {
            //string fistname = textInfo.ToTitleCase(fname);
            //string lastname = textInfo.ToTitleCase(lname);

            Customer c = new Customer(username, password, fname, lname);


            db.Customer.Add(c);
            try
            {
                db.SaveChanges();
            } catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"{c.CustomerId} {c.Username} {c.Password}");

                Console.ReadKey(true);
            }
        }

        public bool RegisterCustomer(string username, string password, string fname, string lname)
        {
            // change name to proper case
            string fistnameTitle = textInfo.ToTitleCase(fname);
            string lastnameTitle = textInfo.ToTitleCase(lname);

            Customer c = new Customer(username, password, fistnameTitle, lastnameTitle);


            db.Customer.Add(c);
            
            try
            {
                db.SaveChanges();

            } catch (DbUpdateException e)
            {
                // fail
                // log exception

                return false;
            } catch (Exception e)
            {
                return false;
            }
            // success
            return true;
        }

        public bool SignIn()
        {
            throw new NotImplementedException();
        }

        public List<string> GetUsernames()
        {
            var query = from e in db.Customer
                        select e.Username;

            return new List<string>(query);
            
        }
    }
}

