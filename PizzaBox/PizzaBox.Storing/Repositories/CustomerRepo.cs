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

        
        public List<string> GetUsernames()
        {
            var query = from e in db.Customer
                        select e.Username;

            return new List<string>(query);
            
        }

        public Customer GetCurrentCustomer()
        {
            return currCustomer;
        }

        public bool SignIn(string username, string password)
        {

            var query = from e in db.Customer
                        where e.Username.Equals(username)
                        select e;

            try
            {
                Customer c = query.Single();

                if (password == c.Password)
                {
                    currCustomer = c;
                    return true;
                }
                else
                {
                    return false;
                }
            } catch (InvalidOperationException e)
            {
                // username does not exist
                return false;
            } 

        }

        public void DisplayCurrCustomerInfo()
        {
            //Display more fields
            Console.WriteLine($"UserID:".PadRight(15) + currCustomer.CustomerId);
            Console.WriteLine($"Username:".PadRight(15) + currCustomer.Username);
            Console.WriteLine($"Name:".PadRight(15) + currCustomer.FirstName + " " + currCustomer.LastName);
        }

        public void SignOut()
        {
            currCustomer = null;
            Console.WriteLine("\nSigned Out");
        }
    }
}

