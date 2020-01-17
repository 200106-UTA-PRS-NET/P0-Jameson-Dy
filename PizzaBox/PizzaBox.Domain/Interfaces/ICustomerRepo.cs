﻿using PizzaBox.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Interfaces
{
    public interface ICustomerRepo
    {
        public IEnumerable<Customer> GetCustomers();
        public bool RegisterCustomer(string username, string password, string fname, string lname);
        public void RegisterCustomerTest(string username, string password, string fname, string lname);
        public bool SignIn();

        public List<string> GetUsernames();

    }
}
