using System;
using System.Text;
using ContactLib;

namespace ContactUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********Revature EMS**********");

            Contact contact = new Contact("James", "Dy", 99, "911", "gmail.com", 443);

            StringBuilder emp = new StringBuilder();
            emp.Append("Default Employee Name: ").Append(contact.firstName).Append(" ").Append(contact.lastName);
            Console.WriteLine(emp + "\n");

            string empDetails = contact.GetContact();
            Console.WriteLine(empDetails);

            Console.Write("\n");

            Employee employee = new Employee();
            Console.WriteLine("Salary = " + employee.GetSalary());

            Manager manager = new Manager(8000, 2000, 800, 4000, 1000, 6);
            Console.WriteLine("Manager salary = " + manager.GetSalary());

        }
    }
}
