using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using PizzaBox.Client;
using PizzaBox.Storing.Interfaces;

namespace PizzaBox.Domain
{
    public class MenuSystemManager
    {
        private static readonly MenuSystemManager instance = new MenuSystemManager();

        static MenuSystemManager() { }
        private MenuSystemManager() { }

        public static MenuSystemManager Instance
        {
            get { return instance; }
        }
        static void DashPaddings(int size = 80)
        {
            Console.WriteLine("".PadLeft(size, '-'));
        }

        public static void PressEnterToContinue()
        {
            Console.Write("\nPress any key to continue");
            Console.ReadKey(true);
        }

        static string PadMiddle(string s, int padLength = 40, char c = '-')
        {
            return s.PadLeft(padLength, c).PadRight(padLength * 2, c);
        }

        public static void MainMenu()
        {

            var userInput = "";
            OptionsGenerator mainMenuOptions = new OptionsGenerator();
            mainMenuOptions.Add("s", "Signin");
            mainMenuOptions.Add("r", "Register");
            mainMenuOptions.Add("l", "ListUsers");
            mainMenuOptions.Add("q", "Quit");

            do
            {
                var customerRepo = Dependencies.CreateCustomerRepository();

                Console.Clear();
                Console.WriteLine("\n" + "Main Menu".PadLeft(40, '-').PadRight(80, '-'));
                mainMenuOptions.DisplayOptions();
                DashPaddings();
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "s":
                        // signin option
                        string usernameInput = "";
                        string passwordInput = "";

                        Console.WriteLine("\n----------Sign In----------");

                        Console.Write("Username: ");
                        usernameInput = Console.ReadLine();
                        Console.Write("Password: ");
                        passwordInput = Console.ReadLine();

                        //validate username and password      
                        /*
                        if (CustomerDAO.Instance.SignIn(usernameInput, passwordInput))
                        {
                            //UserMenu();
                        }
                        */
                        break;
                    case "r":
                        // register option
                        Console.WriteLine("\n------------Creating Account------------");
                        Console.WriteLine("Username and Password must be between 8 and 20 characters\n");

                        Console.Write("Username: ");
                        usernameInput = Console.ReadLine();
                        Console.Write("Password: ");
                        passwordInput = Console.ReadLine();
                        Console.Write("First Name: ");
                        string firstNameInput = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string lastNameInput = Console.ReadLine();

                        bool isCreateSuccess = customerRepo.RegisterCustomer(usernameInput, passwordInput, firstNameInput, lastNameInput);
                        if (isCreateSuccess)
                        {
                            Console.WriteLine("Account successfully created");
                            MenuSystemManager.PressEnterToContinue();
                        }
                        else
                        {
                            Console.WriteLine("Creating account failed");
                            MenuSystemManager.PressEnterToContinue();
                        }

                        //customerRepo.RegisterCustomerTest(usernameInput, passwordInput, firstNameInput, lastNameInput);


                        break;
                    case "l":
                        //Display all customers
                        IEnumerable<Customer> customers = customerRepo.GetCustomers();
                        Console.WriteLine(PadMiddle("Customer List"));
                        Console.WriteLine("Total Users: " + customers.Count() + "\n");
                        Console.WriteLine("ID".PadRight(10) + "Name".PadRight(30) + "Username".PadRight(15) + "Password");
                        Console.WriteLine("--".PadRight(10) + "----".PadRight(30) + "--------".PadRight(15) + "--------");
                        foreach (Customer c in customers)
                        {
                            Console.WriteLine($"{c.CustomerId}".PadRight(10) + $"{c.FirstName} {c.LastName}".PadRight(30) + 
                                $"{c.Username}".PadRight(15) + $"{c.Password}");
                        }
                        PressEnterToContinue();
                        break;
                    case "q":
                        Environment.Exit(-1);
                        break;
                }
            } while (userInput != "q");
        }
    }
}

