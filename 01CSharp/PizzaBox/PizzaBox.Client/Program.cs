using System;
using System.Collections.Generic;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Hello, Welcome to PizzaBox");

            // test accounts
            AccountManager.Instance.CreateUser("jamesondy", "dyjameson");
            AccountManager.Instance.CreateUser("fredfred", "fredfred");
            AccountManager.Instance.CreateUser("mcdonald", "imlovinit");

            // test restaurants
            Restaurant restaurant1 = new Restaurant();
            restaurant1.restaurantName = "Pizahat";
            RestaurantManager.Instance.AddRestaurant(restaurant1);

            Restaurant restaurant2 = new Restaurant();
            restaurant2.restaurantName = "Mama Johns";
            RestaurantManager.Instance.AddRestaurant(restaurant2);

            Restaurant restaurant3 = new Restaurant();
            restaurant3.restaurantName = "Hotdogs Only";
            RestaurantManager.Instance.AddRestaurant(restaurant3);


            // test pizzas
            Pizza peperoniPizza = new Pizza(1, "Peperoni", 0f);
            Pizza supremePizza = new Pizza(2, "Supreme"), 0f);
            Pizza waterPizza = new Pizza(3, "Water");
            Pizza ultimaPizza = new Pizza(4, "Ultima");
            Pizza 

            RestaurantManager.Instance.AddPizzaToStore(peperoniPizza, restaurant1);
            RestaurantManager.Instance.AddPizzaToStore(supremePizza, restaurant1);
            RestaurantManager.Instance.AddPizzaToStore(waterPizza, restaurant2);
            RestaurantManager.Instance.AddPizzaToStore(ultimaPizza, restaurant2);

            MainMenu();

        }

        static void DashPaddings(int size)
        {
            Console.WriteLine("".PadLeft(size, '-'));
        }

        /*
        static void ViewOrderMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();
            OptionsGenerator pizzaOrderOptions = new OptionsGenerator();
            Pizza currPizza = OrderManager.Instance.GetCurrPizza();

            pizzaOrderOptions.Add("Type:", currPizza.name, currPizza.origPrice);
            pizzaOrderOptions.Add("Size:", currPizza.size.ToString(), (float)currPizza.size);
            pizzaOrderOptions.Add("Crust:", currPizza.crust.ToString(), (float)currPizza.crust);

            OptionsGenerator extraOptions = new OptionsGenerator();
            extraOptions.Add("b", "Back to Store Menu");
            extraOptions.Add("q", "Quit");

            var userInput = "";
            do
            {
                Console.WriteLine($"\n------------View Order ({user.userName}) (Total = $ {currPizza.totalPrice})------------");
                if (currPizza != null)
                {
                    pizzaOrderOptions.DisplayOptions(1);
                }
                else
                {
                    Console.WriteLine("No pizza selected");
                }

                DashPaddings(60);
                extraOptions.DisplayOptions();
                DashPaddings(60);
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "b":
                        StoreMenu();
                        break;
                    case "q":
                        Environment.Exit(-1);
                        break;
                }
            } while (userInput != "q");
        }
        */

        
         /*
        private static void ConfirmOrderMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();
            Restaurant restaurant = RestaurantManager.Instance.GetCurrStore();
            Pizza currPizza = OrderManager.Instance.GetCurrPizza();

            OptionsGenerator pizzaOrderOptions = new OptionsGenerator();
            pizzaOrderOptions.Add("Type:", currPizza.name, currPizza.origPrice);
            pizzaOrderOptions.Add("Size:", currPizza.size.ToString(), (float) currPizza.size);
            pizzaOrderOptions.Add("Crust:", currPizza.crust.ToString(), (float) currPizza.crust);

            OptionsGenerator extraOptions = new OptionsGenerator();
            extraOptions.Add("c", "Confirm Order");
            extraOptions.Add("e", "Edit Order");
            extraOptions.Add("b", "Back to Store Menu");
            extraOptions.Add("q", "Quit");


            var userInput = "";
            do
            {
                Console.WriteLine($"\n------------View Order ({user.userName}) (Total = $ {currPizza.totalPrice})------------");
                if (currPizza != null)
                {
                    pizzaOrderOptions.DisplayOptions(1);
                } else
                {
                    Console.WriteLine("No pizza selected");
                }

                DashPaddings(60);
                extraOptions.DisplayOptions();
                DashPaddings(60);
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "c":
                        //TODO Confirm order
                        List<Pizza> list = new List<Pizza>();
                        list.Add(currPizza);
                        Order order = new Order(list, user.id, restaurant.id);
                        OrderManager.Instance.SubmitOrder(order);
                        Console.WriteLine("Order Confirmed!");
                        StoreMenu();
                        // add order to user order list
                        // add order to store order list
                        
                        break;
                    case "e":
                        //TODO edit order
                        PizzaSelectMenu();
                        break;
                    case "b":
                        StoreMenu();
                        break;
                    case "q":
                        Environment.Exit(-1);
                        break;
                }
            } while (userInput != "q");
        }
        */

        /*
        private static void CrustTypeMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();
            Restaurant store = RestaurantManager.Instance.GetCurrStore();
            OptionsGenerator pizzasMenu = new OptionsGenerator();
            List<Pizza> pizzaList = store.GetPizzaList();
            List<int> pizzaIDList = store.GetPizzaIDList();
            Pizza currPizza = OrderManager.Instance.GetCurrPizza();

            OptionsGenerator extraMenu = new OptionsGenerator();
            extraMenu.Add("b", "Back to Pizza Selection Menu");
            extraMenu.Add("q", "Quit");

            var userInput = "";
            do
            {
                Console.WriteLine($"\n------------Pizza Crust: ({currPizza.name}) ({currPizza.size} size) ({currPizza.crust} crust) ({user.userName}) (Total = $ {currPizza.totalPrice})------------");
                Console.WriteLine("Code".PadRight(12) + "Crust Type".PadRight(20) + "Price");
                DashPaddings(60);

                // new pizza prices
                float pThin = currPizza.totalPrice + (float) Pizza.Crust.Thin;
                float pCheesy = currPizza.totalPrice + (float) Pizza.Crust.Cheesy;
                Console.WriteLine("r".PadRight(12) + "Regular".PadRight(20) + $"$ {currPizza.totalPrice}");
                Console.WriteLine("t".PadRight(12) + "Thin".PadRight(20) + $"$ {pThin}");
                Console.WriteLine("c".PadRight(12) + "Cheesy".PadRight(20) + $"$ {pCheesy}");
                DashPaddings(60);
                extraMenu.DisplayOptions();
                DashPaddings(60);

                Console.Write("Input: ");
                userInput = Console.ReadLine();
                if (userInput == "r")
                {
                    // select regular 
                    currPizza.SetCrust(Pizza.Crust.Regular);
                    OrderManager.Instance.SetCurrPizza(currPizza);
                    ConfirmOrderMenu();
                    break;
                }
                else if (userInput == "t")
                {
                    // select thin
                    currPizza.SetCrust(Pizza.Crust.Thin);
                    OrderManager.Instance.SetCurrPizza(currPizza);
                    ConfirmOrderMenu();
                    break;
                }
                else if (userInput == "c")
                {
                    // select cheesy
                    currPizza.SetCrust(Pizza.Crust.Cheesy);
                    OrderManager.Instance.SetCurrPizza(currPizza);
                    ConfirmOrderMenu();
                    break;
                }
                else if (userInput == "b")
                {
                    PizzaSelectMenu();
                    break;
                }
                else if (userInput == "q")
                {
                    Environment.Exit(-1);
                    break;
                }
            }
            while (userInput != "q");
        }

    */

        /*
        private static void PizzaSizeMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();
            Restaurant store = RestaurantManager.Instance.GetCurrStore();
            OptionsGenerator pizzasMenu = new OptionsGenerator();
            List<Pizza> pizzaList = store.GetPizzaList();
            List<int> pizzaIDList = store.GetPizzaIDList();
            Pizza currPizza = OrderManager.Instance.GetCurrPizza();
           
            OptionsGenerator extraMenu = new OptionsGenerator();
            extraMenu.Add("b", "Back to Pizza Selection Menu");
            extraMenu.Add("q", "Quit");

            var userInput = "";
            do
            {
                Console.WriteLine($"\n----------Pizza Size: ({currPizza.name}) ({currPizza.size} size) ({currPizza.crust} crust) ({user.userName}) (Total = $ {currPizza.totalPrice})----------");
                Console.WriteLine("Code".PadRight(12) + "Size".PadRight(20) + "Price");
                DashPaddings(60);

                // new pizza prices
                float pSmall = currPizza.totalPrice + (float) Pizza.Size.Small;
                float pLarge = currPizza.totalPrice + (float) Pizza.Size.Large;
                Console.WriteLine("s".PadRight(12) + "8 in".PadRight(20) + $"$ {pSmall}");
                Console.WriteLine("m".PadRight(12) + "12 in".PadRight(20) + $"$ {currPizza.totalPrice}");
                Console.WriteLine("l".PadRight(12) + "16 in".PadRight(20) + $"$ {pLarge}");
                DashPaddings(60);
                extraMenu.DisplayOptions();
                DashPaddings(60);

                Console.Write("Input: ");
                userInput = Console.ReadLine();
                if (userInput == "s")
                {
                    // select small 
                    currPizza.SetSize(Pizza.Size.Small);
                    OrderManager.Instance.SetCurrPizza(currPizza);
                    CrustTypeMenu();
                    break;
                } else if (userInput == "m")
                {
                    // select medium
                    currPizza.SetSize(Pizza.Size.Medium);
                    OrderManager.Instance.SetCurrPizza(currPizza);
                    CrustTypeMenu();
                    break;

                }
                else if (userInput == "l")
                {
                    // select large
                    currPizza.SetSize(Pizza.Size.Large);
                    OrderManager.Instance.SetCurrPizza(currPizza);
                    CrustTypeMenu();
                    break;

                }
                else if (userInput == "b")
                {
                    currPizza.SetSize(Pizza.Size.Medium);
                    OrderManager.Instance.SetCurrPizza(currPizza);
                    PizzaSelectMenu();
                    break;
                } else if (userInput == "q")
                {
                    Environment.Exit(-1);
                    break;
                }
            }
            while (userInput != "q");
        }
        */

        /*
        private static void PizzaSelectMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();
            Restaurant store = RestaurantManager.Instance.GetCurrStore();
            OptionsGenerator pizzasMenu = new OptionsGenerator();
            Pizza currPizza = OrderManager.Instance.GetCurrPizza();

            List<Pizza> pizzaList = store.GetPizzaList();
            List<int> pizzaIDList = store.GetPizzaIDList();

            OptionsGenerator extraMenu = new OptionsGenerator();
            extraMenu.Add("b", "Back to StoreMenu");
            extraMenu.Add("q", "Quit");

            foreach (Pizza p in pizzaList)
            {
                pizzasMenu.Add(p.id.ToString(), p.name, p.totalPrice);
            }

            var userInput = "";
            do
            {
                Console.WriteLine($"\n----------Pizza Selection ({store.name}) ({user.userName}) (Total = $ {currPizza.totalPrice})----------");
                Console.WriteLine("Code".PadRight(12)+"Pizza Type".PadRight(20) +"Price(Medium Size)");
                DashPaddings(60);
                pizzasMenu.DisplayOptions(1);
                DashPaddings(60);
                extraMenu.DisplayOptions();
                DashPaddings(60);
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int pizzaID))
                {
                    // numeric input
                    if (pizzaIDList.Contains(pizzaID))
                    {
                        // select pizza
                        OrderManager.Instance.SetCurrPizza(store.GetPizzaByID(pizzaID));
                        PizzaSizeMenu();
                        break;
                    }
                } else if (userInput == "b")
                {
                    StoreMenu();
                    break;
                } else if (userInput == "q")
                {
                    Environment.Exit(-1);
                    break;
                }

            } while (userInput != "q");
        }

    */

        static void StoreMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();
            Restaurant store = RestaurantManager.Instance.GetCurrStore();
            OptionsGenerator storeMenu = new OptionsGenerator();
            Pizza currPizza = OrderManager.Instance.GetCurrPizza();

            storeMenu.Add("a", "Add from PizzaMenu");
            storeMenu.Add("c", "CustomPizza(TODO)");
            storeMenu.Add("v", "ViewCurrentOrder(TODO)");
            storeMenu.Add("h", "ViewStoreOrderHistory(TODO)");
            storeMenu.Add("b", "Back to Store Selection");
            storeMenu.Add("s", "SignOut");
            storeMenu.Add("q", "Quit");

            var userInput = "";
            do
            {
                Console.Clear();
                store.Greetings();
                Console.WriteLine("\n" + $"Store Menu ({store.restaurantName}) ({user.username}) (Total = $ {currPizza.GetTotalPrice()})".PadLeft(50, '-').PadRight(60, '-'));
                storeMenu.DisplayOptions();
                DashPaddings(60);
                Console.Write("Input: ");
                userInput = Console.ReadLine();
                
                switch(userInput)
                {
                    case "a":
                        //PizzaSelectMenu();
                        break;
                    case "c":
                        //TODO custom pizza
                        break;
                    case "v":
                        //ViewOrderMenu();
                        break;
                    case "h":
                        //ViewStoreOrderHistory
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

        static void RestaurantSelectMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();

            List<Restaurant> restaurants = RestaurantManager.Instance.GetRestaurantList();

            OptionsGenerator extraMenu = new OptionsGenerator();
            extraMenu.Add("b", "Back to UserMenu");
            extraMenu.Add("q", "Quit");

            OptionsGenerator storeSelectMenu = new OptionsGenerator();
            foreach (Restaurant store in restaurants)
            {
                storeSelectMenu.Add(store.restaurantID.ToString(), store.restaurantName);
            }

            var userInput = "";
            do
            {
                Console.Clear();
                Console.WriteLine("\n" + $"Store Selection ({user.username})".PadLeft(30, '-').PadRight(60, '-'));
                Console.WriteLine("Code".PadRight(12) + "StoreName");
                DashPaddings(60);
                storeSelectMenu.DisplayOptions();
                DashPaddings(60);
                extraMenu.DisplayOptions();
                DashPaddings(60);
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int id))
                {
                    // numeric input
                    if (RestaurantManager.Instance.GetRestaurantIDList().Contains(id))
                    {
                        // Go to that store 
                        RestaurantManager.Instance.SetCurrStore(id);
                        StoreMenu();
                        break;
                    }
                }
                else if (userInput  == "b")
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
            // 
            while (userInput != "q");
        }
  
        static void UserMenu()
        {
            var userInput = "";
            User user = AccountManager.Instance.GetCurrUser();

            OptionsGenerator userMenuOptions = new OptionsGenerator();
            userMenuOptions.Add("g", "GoToPizzaStore");
            userMenuOptions.Add("h", "ViewOrderHistory(TODO)");
            userMenuOptions.Add("v", "ViewUserInfo");
            userMenuOptions.Add("e", "EditUserInfo(TODO)");
            userMenuOptions.Add("s", "SignOut");
            userMenuOptions.Add("q", "Quit");

            do
            {
                Console.Clear();
                Console.WriteLine("\n" + $"User Menu ({user.username})".PadLeft(30, '-').PadRight(60, '-'));
                userMenuOptions.DisplayOptions();
                DashPaddings(60);
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "g":
                        RestaurantSelectMenu();
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
                        AccountManager.Instance.DisplayCurrUserInfo();
                        Console.Write("\nPress enter to continue");
                        Console.Read();
                        break;
                    case "e":
                        //TODO: edit user info
                        break;
                    case "s":
                        SignOut();
                        break;
                    case "q":
                        Environment.Exit(-1);
                        break;
                }

            } while (userInput != "q");
        }

        static void SignOut()
        {
            AccountManager.Instance.SignOut();
            MainMenu();
        }

        static void MainMenu()
        {
            var userInput = "";
            OptionsGenerator mainMenuOptions = new OptionsGenerator();
            mainMenuOptions.Add("s", "Signin");
            mainMenuOptions.Add("r", "Register");
            mainMenuOptions.Add("l", "ListUsers");
            mainMenuOptions.Add("q", "Quit");

            do
            {
                Console.Clear();
                Console.WriteLine("\n" + "Main Menu".PadLeft(30, '-').PadRight(60, '-'));
                mainMenuOptions.DisplayOptions();
                DashPaddings(60);
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "s":
                        // signin option
                        string usernameInput;
                        string passwordInput;

                        Console.WriteLine("\n----------Sign In----------");

                        Console.Write("Username: ");
                        usernameInput = Console.ReadLine();
                        Console.Write("Password: ");
                        passwordInput = Console.ReadLine();

                        //validate username and password         
                        if (AccountManager.Instance.SignIn(usernameInput, passwordInput))
                        {
                            UserMenu();
                        }
                        break;
                    case "r":
                        // register option
                        Console.WriteLine("\n------------Creating Account------------");
                        Console.WriteLine("Username and Password must be between 8 - 15 characters\n");

                        Console.Write("Username: ");
                        usernameInput = Console.ReadLine();
                        Console.Write("Password: ");
                        passwordInput = Console.ReadLine();

                        bool isCreateSuccess = AccountManager.Instance.CreateUser(usernameInput, passwordInput);
                        if (isCreateSuccess)
                        {
                            Console.WriteLine("Account successfully created");
                        }
                        else
                        {
                            Console.WriteLine("Creating account failed");
                        }
                        break;
                    case "l":
                        AccountManager.Instance.DisplayAllUsers();
                        break;
                    case "q":
                        Environment.Exit(-1);
                        break;
                }
            } while (userInput != "q");
        }
    }
}
