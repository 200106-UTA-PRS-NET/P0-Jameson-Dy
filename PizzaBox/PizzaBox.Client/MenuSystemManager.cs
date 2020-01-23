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
        static void SignOut()
        {
            var customersRepo = Dependencies.CreateCustomerRepository();
            var restaurantsRepo = Dependencies.CreateRestaurantRepository();
            var ordersRepo = Dependencies.CreateOrderRepository();
            var pizzasRepo = Dependencies.CreateOrderRepository();

            customersRepo.SignOut();
            restaurantsRepo.RemoveCurrentRestaurant();

            MainMenu();
        }

        static void Quit()
        {
            Console.WriteLine("Goodbye");
            Environment.Exit(-1);
        }

        public static void MainMenu()
        {
            OptionsGenerator mainMenuOptions = new OptionsGenerator();
            mainMenuOptions.Add("s", "Signin");
            mainMenuOptions.Add("r", "Register");
            mainMenuOptions.Add("l", "ListUsers");
            mainMenuOptions.Add("q", "Quit");

            string userInput;
            do
            {
                var customersRepo = Dependencies.CreateCustomerRepository();

                Console.Clear();
                Console.WriteLine("\n" + PadMiddle("Main Menu"));
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
                        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                        Console.WriteLine(PadMiddle("Customer List"));
                        Console.WriteLine("Total Users: " + customers.Count() + "\n");
                        Console.WriteLine("ID".PadRight(10) + "Name".PadRight(30) + "Username".PadRight(20) + "Password");
                        DashPaddings();
                        foreach (Customers c in customers)
                        {
                            String name = textInfo.ToTitleCase(c.FirstName + " " + c.LastName);
                            Console.WriteLine($"{c.CustomerId}".PadRight(10) + $"{name}".PadRight(30) +
                                $"{c.Username}".PadRight(20) + $"{c.Password}");
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

            var orderRepo = Dependencies.CreateOrderRepository();

            OptionsGenerator userMenuOptions = new OptionsGenerator();
            userMenuOptions.Add("g", "GoToPizzaStore");
            userMenuOptions.Add("h", "ViewOrderHistory");
            userMenuOptions.Add("v", "ViewUserInfo");
            userMenuOptions.Add("e", "EditUserInfo(TODO)");
            userMenuOptions.Add("s", "SignOut");
            userMenuOptions.Add("q", "Quit");

            string userInput;
            do
            {
                var customerRepo = Dependencies.CreateCustomerRepository();
                Customers currCustomer = customerRepo.GetCurrentCustomer();

                Console.Clear();
                Console.WriteLine("\n" + PadMiddle($"User Menu ({currCustomer.Username}) "));
                userMenuOptions.DisplayOptions();
                DashPaddings();
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "g":
                        RestaurantSelectMenu();
                        break;
                    case "h":
                        orderRepo.ViewOrderHistory(currCustomer.CustomerId);
                        PressAnyToContinue();
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
        static void RestaurantSelectMenu()
        {
            var customersRepo = Dependencies.CreateCustomerRepository();
            Customers currCustomer = customersRepo.GetCurrentCustomer();

            var restaurantsRepo = Dependencies.CreateRestaurantRepository();
            restaurantsRepo.RemoveCurrentRestaurant();

            var ordersRepo = Dependencies.CreateOrderRepository();
            ordersRepo.RemoveCurrOrder();

            List<Restaurants> restaurants = restaurantsRepo.GetRestaurants().ToList();

            //OptionsGenerator storeSelectMenu = new OptionsGenerator();
            //foreach (Restaurants store in restaurants)
            //{
            //   storeSelectMenu.Add(store.RestaurantId.ToString(), store.RestaurantName);
            //}

            OptionsGenerator extraMenu = new OptionsGenerator();
            extraMenu.Add("b", "Back to UserMenu");
            extraMenu.Add("q", "Quit");

            double hoursToWait = 1;

            string userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("\n" + PadMiddle($"Store Selection ({currCustomer.Username}) "));
                Console.WriteLine("Code".PadRight(10) + "StoreName".PadRight(30) + "WaitTime(hr:min)".PadRight(20) + "DateLastOrdered" );
                DashPaddings();

                Dictionary<int, bool> storeAvailable = new Dictionary<int, bool>();
                storeAvailable.Clear();
                foreach (Restaurants store in restaurants)
                {
                    string rID = store.RestaurantId.ToString();
                    string rName = store.RestaurantName;
                    if (restaurantsRepo.GetLastOrderDate(store.RestaurantId, currCustomer.CustomerId).HasValue)
                    {
                        // has previous order
                        DateTime lastOrder = restaurantsRepo.GetLastOrderDate(store.RestaurantId, currCustomer.CustomerId).Value;
                        TimeSpan timeSinceLastOrder = DateTime.Now - lastOrder;
                        TimeSpan waitTime = DateTime.Now - lastOrder.AddHours(hoursToWait);

                        if (timeSinceLastOrder.TotalHours > hoursToWait)
                        {
                            // time since last order more than an hour from now
                            Console.WriteLine(rID.PadRight(10) + rName.PadRight(30) + "Available".PadRight(20) + lastOrder);
                            storeAvailable.Add(store.RestaurantId, true);
                        }
                        else
                        {
                            // last order was within an hour before
                            Console.WriteLine(rID.PadRight(10) + rName.PadRight(30) + waitTime.ToString(@"hh\:mm").PadRight(20) + lastOrder);
                            storeAvailable.Add(store.RestaurantId, false);

                        }
                    }
                    else
                    {
                        // no previous order
                        Console.WriteLine(rID.PadRight(10) + rName.PadRight(30) + "Available");
                        storeAvailable.Add(store.RestaurantId, true);
                    }


                }
                //storeSelectMenu.DisplayOptions();
                DashPaddings();
                extraMenu.DisplayOptions();
                DashPaddings();
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int id))
                {
                    // numeric input
                    if (restaurantsRepo.GetRestaurantIDList().Contains(id))
                    {
                        // Go to that store 
                        if (storeAvailable[id])
                        {
                            restaurantsRepo.SetCurrentRestaurant(id);
                            RestaurantMenu();
                        } else
                        {
                            // last order is within hoursToWait -> store not available
                            Console.WriteLine("\nStore not available");
                            Console.ReadKey(true);
                            RestaurantSelectMenu();
                        }

                        break;
                    }
                }
                else if (userInput == "b")
                {
                    UserMenu();
                    break;
                }
                else if (userInput == "q")
                {
                    Environment.Exit(-1);
                    return;
                }
            }
            while (userInput != "q");
        }
        static void RestaurantMenu()
        {
            var customersRepo = Dependencies.CreateCustomerRepository();
            Customers currCustomer = customersRepo.GetCurrentCustomer();

            var restaurantsRepo = Dependencies.CreateRestaurantRepository();
            Restaurants currRestaurant = restaurantsRepo.GetCurrentRestaurant();

            var ordersRepo = Dependencies.CreateOrderRepository();

            OptionsGenerator storeMenu = new OptionsGenerator();
            storeMenu.Add("p", "PresetPizzas");
            storeMenu.Add("c", "CustomPizza(TODO)");
            storeMenu.Add("v", "ViewCurrentOrder");
            storeMenu.Add("h", "UserStoreOrderHistory");
            storeMenu.Add("r", "StoreOrderHistory");
            storeMenu.Add("b", "Back to Store Selection");
            storeMenu.Add("s", "SignOut");
            storeMenu.Add("q", "Quit");

            string userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("\n" + PadMiddle($"Store Menu ({currRestaurant.RestaurantName}) ({currCustomer.Username}) "));
                storeMenu.DisplayOptions();
                DashPaddings();
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "p":
                        PresetPizzaMenu();
                        break;
                    case "c":
                        CustomPizzaMenu();
                        break;
                    case "v":
                        OrderConfirmMenu();
                        break;
                    case "h":
                        ordersRepo.ViewOrderHistory(currCustomer.CustomerId, currRestaurant.RestaurantId);
                        PressAnyToContinue();
                        break;
                    case "r":
                        ordersRepo.ViewStoreOrderHistory(currRestaurant.RestaurantId);
                        PressAnyToContinue();
                        break;
                    case "b":
                        RestaurantSelectMenu();
                        break;
                    case "s":
                        SignOut();
                        break;
                    case "q":
                        Environment.Exit(-1);
                        break;
                }
            }
            while (userInput != "q");
        }
        static void PresetPizzaMenu()
        {
            var customersRepo = Dependencies.CreateCustomerRepository();
            Customers currCustomer = customersRepo.GetCurrentCustomer();

            var restaurantsRepo = Dependencies.CreateRestaurantRepository();
            Restaurants currRestaurant = restaurantsRepo.GetCurrentRestaurant();

            var pizzasRepo = Dependencies.CreatePizzaRepository();

            List<int> pizzaIDList = restaurantsRepo.GetCurrRestaurantPizzaIDList();

            OptionsGenerator extraMenu = new OptionsGenerator();
            extraMenu.Add("b", "Back to RestaurantMenu");
            extraMenu.Add("q", "Quit");

            //OptionsGenerator pizzasMenu = new OptionsGenerator();

            //foreach (Pizza p in restaurantsRepo.GetCurrRestaurantPizzas())
            //{
            //    pizzasMenu.Add(p.PizzaId.ToString(), p.PizzaName, pizzasRepo.GetTotalPrice(p.PizzaId) + currRestaurant.RestaurantMarkup.Value);
            //}

            string userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("\n" + PadMiddle($"Pizza Selection ({currRestaurant.RestaurantName}) ({currCustomer.Username}) "));
                Console.WriteLine("Code".PadRight(10) + "Pizza".PadRight(30) + "Personal".PadRight(10) + "Medium".PadRight(10) + "Large".PadRight(10) + "XLarge");
                DashPaddings();
                foreach (Pizza p in restaurantsRepo.GetCurrRestaurantPizzas())
                {
                    string pricePersonal = (pizzasRepo.GetTotalPrice(p.PizzaId, new Size { PriceMultiplier = 0.8 }) + currRestaurant.RestaurantMarkup.Value).ToString("0.00");
                    string priceMedium = (pizzasRepo.GetTotalPrice(p.PizzaId, new Size { PriceMultiplier = 1 }) + currRestaurant.RestaurantMarkup.Value).ToString("0.00");
                    string priceLarge = (pizzasRepo.GetTotalPrice(p.PizzaId, new Size { PriceMultiplier = 1.5 }) + currRestaurant.RestaurantMarkup.Value).ToString("0.00");
                    string priceXtraLarge = (pizzasRepo.GetTotalPrice(p.PizzaId, new Size { PriceMultiplier = 2.1 }) + currRestaurant.RestaurantMarkup.Value).ToString("0.00");
                    Console.WriteLine(p.PizzaId.ToString().PadRight(10) + p.PizzaName.PadRight(30) + pricePersonal.PadRight(10) + priceMedium.PadRight(10) + priceLarge.PadRight(10) +  priceXtraLarge);
                }
                //pizzasMenu.DisplayOptions(1);
                DashPaddings();
                extraMenu.DisplayOptions();
                DashPaddings();
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int pizzaID))
                {
                    // numeric input
                    if (pizzaIDList.Contains(pizzaID))
                    {
                        pizzasRepo.SetCurrentPizza(pizzaID, currRestaurant);
                        Pizza currPizza = pizzasRepo.GetCurrentPizza();
                        // select pizza
                        Console.Write("\nSize? (p) (m) (l) (x): " );
                        userInput = Console.ReadLine();
                        if (userInput == "p")
                        {
                            pizzasRepo.SetCurrentPizzaSize(1);
                        } 
                        else if (userInput == "m")
                        {
                            pizzasRepo.SetCurrentPizzaSize(2);
                        }
                        else if (userInput == "l")
                        {
                            pizzasRepo.SetCurrentPizzaSize(3);
                        }
                        else if (userInput == "x")
                        {
                            pizzasRepo.SetCurrentPizzaSize(4);
                        }
                        AddPizzaConfirmMenu();
                        break;
                    }
                }
                else if (userInput == "b")
                {
                    RestaurantMenu();
                    break;
                }
                else if (userInput == "q")
                {
                    Environment.Exit(-1);
                    break;
                }

            } while (userInput != "q");
        }

        static void CustomPizzaMenu()
        {
            var customersRepo = Dependencies.CreateCustomerRepository();
            Customers currCustomer = customersRepo.GetCurrentCustomer();

            var restaurantsRepo = Dependencies.CreateRestaurantRepository();
            Restaurants currRestaurant = restaurantsRepo.GetCurrentRestaurant();

            var pizzasRepo = Dependencies.CreatePizzaRepository();


            OptionsGenerator extraMenu = new OptionsGenerator();
            extraMenu.Add("b", "Back to RestaurantMenu");
            extraMenu.Add("q", "Quit");

            var userInput = "";
            do
            {
                Console.Clear();
                Console.WriteLine("\n" + PadMiddle($"Custom Pizza ({currRestaurant.RestaurantName}) ({currCustomer.Username}) "));
                
                DashPaddings();
                extraMenu.DisplayOptions();
                DashPaddings();
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                if (userInput == "b")
                {
                    RestaurantMenu();
                    break;
                } else if (userInput == "q")
                {
                    Quit();
                    break;
                }

            } while (userInput != "q");
        }
        static void AddPizzaConfirmMenu()
        {
            var customersRepo = Dependencies.CreateCustomerRepository();
            Customers currCustomer = customersRepo.GetCurrentCustomer();

            var restaurantsRepo = Dependencies.CreateRestaurantRepository();
            Restaurants currRestaurant = restaurantsRepo.GetCurrentRestaurant();

            var pizzasRepo = Dependencies.CreatePizzaRepository();
            Pizza currPizza = pizzasRepo.GetCurrentPizza();

            var ordersRepo = Dependencies.CreateOrderRepository();


            OptionsGenerator pizzaConfirmMenu = new OptionsGenerator();
            pizzaConfirmMenu.Add("y", "yes");
            pizzaConfirmMenu.Add("n", "no");

            var userInput = "";
            do
            {
                Console.Clear();
                Console.WriteLine("\n" + PadMiddle($"Confirm Add Pizza ({currRestaurant.RestaurantName}) ({currCustomer.Username}) "));
                pizzasRepo.DisplayCurrPizzaInfo();
                DashPaddings();
                pizzaConfirmMenu.DisplayOptions();
                DashPaddings();
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "y":
                        Console.WriteLine("ADDED TO ORDER");
                        // add currpizza to order
                        currPizza.PriceTotal = pizzasRepo.GetTotalPrice(currPizza, currRestaurant.RestaurantMarkup.Value);
                        ordersRepo.AddPizzaToOrder(currPizza, currCustomer.CustomerId, currRestaurant.RestaurantId);
                        // 
                        OrderConfirmMenu();
                        break;
                    case "n":
                        Console.WriteLine("NOT ADDED TO ORDER");
                        RestaurantMenu();
                        break;
                }
            } while (true);
        }
        static void OrderConfirmMenu()
        {
            var pizzasRepo = Dependencies.CreatePizzaRepository();

            var ordersRepo = Dependencies.CreateOrderRepository();
            Orders currOrder = ordersRepo.GetCurrentOrder();

            OptionsGenerator extraOptions = new OptionsGenerator();
            extraOptions.Add("c", "Confirm Order");
            extraOptions.Add("x", "Cancel Order");
            extraOptions.Add("e", "Edit Order(TODO)");
            extraOptions.Add("b", "Back to Store Menu");
            extraOptions.Add("q", "Quit");

            List<Pizza> pizzas = ordersRepo.GetCurrOrderPizzas();

            if (pizzas.Count <= 0)
            {
                Console.WriteLine("NO CURRENT ORDER");
                PressAnyToContinue();
                RestaurantMenu();
            }

            string userInput;
            do
            {
                var customersRepo = Dependencies.CreateCustomerRepository();
                Customers currCustomer = customersRepo.GetCurrentCustomer();

                var restaurantsRepo = Dependencies.CreateRestaurantRepository();
                Restaurants currRestaurant = restaurantsRepo.GetCurrentRestaurant();

                Console.Clear();
                Console.WriteLine("\n" + PadMiddle($"View Order ({currCustomer.Username}) ({currRestaurant.RestaurantName}) (Total = $)"));
                int i = 1;
                foreach (Pizza p in pizzas)
                {
                    DashPaddings();
                    Console.WriteLine("Pizza #".PadRight(10) + i);
                    pizzasRepo.DisplayFullPizzaInfo(p, currRestaurant.RestaurantMarkup.Value);
                    Console.WriteLine("\n" + $"Total# {i}:".PadRight(70) + $"$ {pizzasRepo.GetTotalPrice(p).ToString("0.00")}");
                    i++;
                }
                DashPaddings();
                Console.WriteLine("Subtotal:".PadRight(70) + $"$ {ordersRepo.GetSubtotal().ToString(("0.00"))}");

                DashPaddings();
                extraOptions.DisplayOptions();
                DashPaddings();
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "c":
                        ordersRepo.SubmitOrder(currCustomer.CustomerId, currRestaurant.RestaurantId);
                        RestaurantSelectMenu();
                        break;
                    case "x":
                        // cancel order
                        ordersRepo.RemoveCurrOrder();
                        RestaurantMenu();
                        break;
                    case "e":
                        //TODO edit order
                        //PizzaSelectMenu();
                        break;
                    case "b":
                        RestaurantMenu();
                        break;
                    case "q":
                        Environment.Exit(-1);
                        break;
                }
            } while (userInput != "q");
        }

    }
}

