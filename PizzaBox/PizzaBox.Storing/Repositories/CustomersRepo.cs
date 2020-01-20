using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain;
using PizzaBox.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
    public class CustomersRepo : ICustomersRepo
    {
        readonly PizzaBoxDbContext db;
        readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        static Customers currCustomer = new Customers();

        public CustomersRepo()
        {
            db = new PizzaBoxDbContext();
        }
        public CustomersRepo(PizzaBoxDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Customers> GetCustomers()
        {
            var query = from e in db.Customers
                        select e;

            return query;
        }

        public bool RegisterCustomer(string username, string password, string fname, string lname)
        {
            // change name to proper case
            string fistnameTitle = textInfo.ToTitleCase(fname);
            string lastnameTitle = textInfo.ToTitleCase(lname);

            Customers c = new Customers();
            c.Username = username;
            c.Password = password;
            c.FirstName = fistnameTitle;
            c.LastName = lastnameTitle;


            db.Customers.Add(c);

            try
            {
                db.SaveChanges();

            }
            catch (DbUpdateException e)
            {
                // fail
                // log exception

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
            // success
            return true;
        }


        public List<string> GetUsernames()
        {
            var query = from e in db.Customers
                        select e.Username;

            return new List<string>(query);

        }

        public Customers GetCurrentCustomer()
        {
            return currCustomer;
        }

        public bool SignIn(string username, string password)
        {

            var query = from e in db.Customers
                        where e.Username.Equals(username)
                        select e;

            try
            {
                Customers c = query.Single();

                if (password == c.Password)
                {
                    currCustomer = c;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (InvalidOperationException e)
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
