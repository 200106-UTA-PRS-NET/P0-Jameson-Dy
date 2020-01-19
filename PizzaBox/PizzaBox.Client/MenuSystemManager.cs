using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using PizzaBox.Client;

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

        public static void PressAnyToContinue()
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
                var customersRepo = Dependencies.CreateCustomerRepository();

                Console.Clear();
                Console.WriteLine("\n" + "Main Menu".PadLeft(40, '-').PadRight(80, '-'));
                mainMenuOptions.DisplayOptions();
                DashPaddings();
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                string usernameInput;
                string passwordInput;

                switch (userInput)
                {
                    case "s":
                        // signin option
                        Console.WriteLine(PadMiddle("Sign In"));

                        Console.Write("Username: ");
                        usernameInput = Console.ReadLine();
                        Console.Write("Password: ");
                        passwordInput = Console.ReadLine();

                        if (customersRepo.SignIn(usernameInput, passwordInput))
                        {
                            Console.WriteLine("\nSigning in account successful");
                            MenuSystemManager.PressAnyToContinue();
                            UserMenu();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nSigning in account failed");
                            MenuSystemManager.PressAnyToContinue();
                        }
                        break;
                    case "r":
                        // register option
                        Console.WriteLine(PadMiddle("Creating Account"));
                        Console.WriteLine("Username and Password must be between 8 and 20 characters\n");

                        Console.Write("Username: ");
                        usernameInput = Console.ReadLine();
                        Console.Write("Password: ");
                        passwordInput = Console.ReadLine();
                        Console.Write("First Name: ");
                        string firstNameInput = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string lastNameInput = Console.ReadLine();

                        bool isCreateSuccess = customersRepo.RegisterCustomer(usernameInput, passwordInput, firstNameInput, lastNameInput);
                        if (isCreateSuccess)
                        {
                            Console.WriteLine("\nAccount successfully created");
                            MenuSystemManager.PressAnyToContinue();
                        }
                        else
                        {
                            Console.WriteLine("\nCreating account failed");
                            MenuSystemManager.PressAnyToContinue();
                        }
                        break;
                    case "l":
                        //Display all customers
                        IEnumerable<Customers> customers = customersRepo.GetCustomers();
                        Console.WriteLine(PadMiddle("Customer List"));
                        Console.WriteLine("Total Users: " + customers.Count() + "\n");
                        Console.WriteLine("ID".PadRight(10) + "Name".PadRight(30) + "Username".PadRight(15) + "Password");
                        Console.WriteLine("--".PadRight(10) + "----".PadRight(30) + "--------".PadRight(15) + "--------");
                        foreach (Customers c in customers)
                        {
                            Console.WriteLine($"{c.CustomerId}".PadRight(10) + $"{c.FirstName} {c.LastName}".PadRight(30) +
                                $"{c.Username}".PadRight(15) + $"{c.Password}");
                        }
                        PressAnyToContinue();
                        break;
                    case "q":
                        Environment.Exit(-1);
                        break;
                }
            } while (userInput != "q");
        }
        static void UserMenu()
        {
            var userInput = "";

            OptionsGenerator userMenuOptions = new OptionsGenerator();
            userMenuOptions.Add("g", "GoToPizzaStore");
            userMenuOptions.Add("h", "ViewOrderHistory(TODO)");
            userMenuOptions.Add("v", "ViewUserInfo");
            userMenuOptions.Add("e", "EditUserInfo(TODO)");
            userMenuOptions.Add("s", "SignOut");
            userMenuOptions.Add("q", "Quit");

            do
            {
                var customerRepo = Dependencies.CreateCustomerRepository();
                Customers currCustomer = customerRepo.GetCurrentCustomer();

                Console.Clear();
                Console.WriteLine("\n" + $"User Menu ({currCustomer.Username}) ".PadLeft(30, '-').PadRight(60, '-'));
                userMenuOptions.DisplayOptions();
                DashPaddings(60);
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "g":
                        //RestaurantSelectMenu();
                        break;
                    case "h":
                        //TODO: view order history menu
                        /*
                        List<Order> orders = user.GetOrderHistory();
                        if (orders.Count > 0)
                        {
                            Order firstOrder = orders[0];
                            firstOrder.DisplayOrder();
                        } else
                        {
                            Console.WriteLine("No orders");
                        }
                        */
                        break;
                    case "v":
                        customerRepo.DisplayCurrCustomerInfo();
                        PressAnyToContinue();
                        break;
                    case "e":
                        //TODO: edit user info
                        break;
                    case "s":
                        customerRepo.SignOut();
                        MainMenu();
                        break;
                    case "q":
                        Environment.Exit(-1);
                        break;
                }

            } while (userInput != "q");
        }
    }
}

