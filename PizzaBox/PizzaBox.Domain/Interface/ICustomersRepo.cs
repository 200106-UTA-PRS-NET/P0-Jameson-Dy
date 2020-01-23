using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interface
{
    public interface ICustomersRepo
    {
        public bool SignIn(string username, string password);


        public IEnumerable<Customers> GetCustomers();
        public bool RegisterCustomer(string username, string password, string fname, string lname);

        public void SignOut();
        public Customers GetCurrentCustomer();
        public void DisplayCurrCustomerInfo();
    }
}
