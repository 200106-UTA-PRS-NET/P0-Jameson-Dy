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

            // test stores
            PizzaStore pizahat = new PizzaStore();
            pizahat.name = "Pizahat";
            pizahat.storeID = 1;
            PizzaStoreManager.Instance.AddStore(pizahat);

            PizzaStore mamajohn = new PizzaStore();
            mamajohn.name = "Mama Johns";
            mamajohn.storeID = 2;
            PizzaStoreManager.Instance.AddStore(mamajohn);

            // test pizzas
            Pizza peperoniPizza = new Pizza(1, "Peperoni");
            Pizza supremePizza = new Pizza(2, "Supreme", 9f, Pizza.Crust.Thin, Pizza.Size.Large);
            Pizza waterPizza = new Pizza(3, "Water", 20f, Pizza.Crust.Cheesy, Pizza.Size.Small);
            Pizza ultimaPizza = new Pizza(4, "Ultima", 9999.50f);

            PizzaStoreManager.Instance.AddPizzaToStore(peperoniPizza, pizahat);
            PizzaStoreManager.Instance.AddPizzaToStore(supremePizza, pizahat);
            PizzaStoreManager.Instance.AddPizzaToStore(waterPizza, mamajohn);
            PizzaStoreManager.Instance.AddPizzaToStore(ultimaPizza, mamajohn);

            MainMenu();

        }

        static void DashPaddings(int size)
        {
            Console.WriteLine("".PadLeft(size, '-'));
        }

        private static void ViewOrderMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();
            PizzaStore store = PizzaStoreManager.Instance.GetCurrStore();
            Pizza currPizza = OrderManager.Instance.getCurrPizza();

            var userInput = "";
            do
            {
                Console.WriteLine($"\n----------View Order ({user.userName}) (Total = $ {currPizza.totalPrice})----------");
                Console.WriteLine("Pizza Type:".PadRight(15) + $"{currPizza.name}".PadRight(15) + $"{currPizza.origPrice.ToString("###0.00")}");
                Console.WriteLine("Size:".PadRight(15) + $"{currPizza.size}".PadRight(15) + $"{((float) currPizza.size).ToString("###0.00")}");
                Console.WriteLine("Crust:".PadRight(15) + $"{currPizza.crust}".PadRight(15) + $"{((float) currPizza.crust).ToString("###0.00")}");

                DashPaddings(60);
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                switch(userInput)
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

        private static void CrustTypeMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();
            PizzaStore store = PizzaStoreManager.Instance.GetCurrStore();
            OptionsGenerator pizzasMenu = new OptionsGenerator();
            List<Pizza> pizzaList = store.GetPizzaList();
            List<int> pizzaIDList = store.GetPizzaIDList();
            Pizza currPizza = OrderManager.Instance.getCurrPizza();

            OptionsGenerator extraMenu = new OptionsGenerator();
            extraMenu.Add("b", "Back to Pizza Selection Menu");
            extraMenu.Add("q", "Quit");

            var userInput = "";
            do
            {
                Console.WriteLine($"\n----------Pizza: ({currPizza.name}) ({currPizza.size} size) ({currPizza.crust} crust) ({user.userName}) (Total = $ {currPizza.totalPrice})----------");
                Console.WriteLine("Code".PadRight(10) + "Crust Type".PadRight(10) + "Price");
                DashPaddings(60);

                // new pizza prices
                float pThin = currPizza.totalPrice + (float) Pizza.Crust.Thin;
                float pCheesy = currPizza.totalPrice + (float) Pizza.Crust.Cheesy;
                Console.WriteLine("r".PadRight(10) + "8 in".PadRight(10) + $"$ {currPizza.totalPrice}");
                Console.WriteLine("t".PadRight(10) + "12 in".PadRight(10) + $"$ {pThin}");
                Console.WriteLine("c".PadRight(10) + "16 in".PadRight(10) + $"$ {pCheesy}");
                DashPaddings(60);
                extraMenu.DisplayOptions();
                DashPaddings(60);

                Console.Write("Input: ");
                userInput = Console.ReadLine();
                if (userInput == "r")
                {
                    // select regular 
                    currPizza.SetCrust(Pizza.Crust.Regular);
                    OrderManager.Instance.setCurrPizza(currPizza);
                    ViewOrderMenu();
                    break;
                }
                else if (userInput == "t")
                {
                    // select thin
                    currPizza.SetCrust(Pizza.Crust.Thin);
                    OrderManager.Instance.setCurrPizza(currPizza);
                    ViewOrderMenu();
                    break;
                }
                else if (userInput == "c")
                {
                    // select cheesy
                    currPizza.SetCrust(Pizza.Crust.Cheesy);
                    OrderManager.Instance.setCurrPizza(currPizza);
                    ViewOrderMenu();
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

        private static void PizzaSizeMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();
            PizzaStore store = PizzaStoreManager.Instance.GetCurrStore();
            OptionsGenerator pizzasMenu = new OptionsGenerator();
            List<Pizza> pizzaList = store.GetPizzaList();
            List<int> pizzaIDList = store.GetPizzaIDList();
            Pizza currPizza = OrderManager.Instance.getCurrPizza();
           
            OptionsGenerator extraMenu = new OptionsGenerator();
            extraMenu.Add("b", "Back to Pizza Selection Menu");
            extraMenu.Add("q", "Quit");

            var userInput = "";
            do
            {
                Console.WriteLine($"\n----------Pizza Size: ({currPizza.name}) ({currPizza.size} size) ({currPizza.crust} crust) ({user.userName}) (Total = $ {currPizza.totalPrice})----------");
                Console.WriteLine("Code".PadRight(10) + "Size".PadRight(10) + "Price");
                DashPaddings(60);

                // new pizza prices
                float pSmall = currPizza.totalPrice + (float) Pizza.Size.Small;
                float pLarge = currPizza.totalPrice + (float) Pizza.Size.Large;
                Console.WriteLine("s".PadRight(10) + "8 in".PadRight(10) + $"$ {pSmall}");
                Console.WriteLine("m".PadRight(10) + "12 in".PadRight(10) + $"$ {currPizza.totalPrice}");
                Console.WriteLine("l".PadRight(10) + "16 in".PadRight(10) + $"$ {pLarge}");
                DashPaddings(60);
                extraMenu.DisplayOptions();
                DashPaddings(60);

                Console.Write("Input: ");
                userInput = Console.ReadLine();
                if (userInput == "s")
                {
                    // select small 
                    currPizza.SetSize(Pizza.Size.Small);
                    OrderManager.Instance.setCurrPizza(currPizza);
                    CrustTypeMenu();
                    break;
                } else if (userInput == "m")
                {
                    // select medium
                    currPizza.SetSize(Pizza.Size.Medium);
                    OrderManager.Instance.setCurrPizza(currPizza);
                    CrustTypeMenu();
                    break;

                }
                else if (userInput == "l")
                {
                    // select large
                    currPizza.SetSize(Pizza.Size.Large);
                    OrderManager.Instance.setCurrPizza(currPizza);
                    CrustTypeMenu();
                    break;

                }
                else if (userInput == "b")
                {
                    currPizza.SetSize(Pizza.Size.Medium);
                    OrderManager.Instance.setCurrPizza(currPizza);
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

        private static void PizzaSelectMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();
            PizzaStore store = PizzaStoreManager.Instance.GetCurrStore();
            OptionsGenerator pizzasMenu = new OptionsGenerator();
            Pizza currPizza = OrderManager.Instance.getCurrPizza();

            List<Pizza> pizzaList = store.GetPizzaList();
            List<int> pizzaIDList = store.GetPizzaIDList();

            OptionsGenerator extraMenu = new OptionsGenerator();
            extraMenu.Add("b", "Back to StoreMenu");
            extraMenu.Add("q", "Quit");

            foreach (Pizza p in pizzaList)
            {
                pizzasMenu.Add(p.id.ToString(), p.name, p.origPrice);
            }

            var userInput = "";
            do
            {
                Console.WriteLine($"\n----------Pizza Selection ({store.name}) ({user.userName}) (Total = $ {currPizza.totalPrice})----------");
                Console.WriteLine("Code".PadRight(10)+"Pizza Type".PadRight(30) +"Price(Medium Size)");
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
                        OrderManager.Instance.setCurrPizza(store.GetPizzaByID(pizzaID));
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

        private static void StoreMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();
            PizzaStore store = PizzaStoreManager.Instance.GetCurrStore();
            OptionsGenerator storeMenu = new OptionsGenerator();
            Pizza currPizza = OrderManager.Instance.getCurrPizza();

            storeMenu.Add("a", "Add from PizzaMenu");
            storeMenu.Add("c", "CustomPizza");
            storeMenu.Add("v", "ViewOrder");
            storeMenu.Add("b", "Back to Store Selection");
            storeMenu.Add("s", "SignOut");
            storeMenu.Add("q", "Quit");


            var userInput = "";
            store.Greetings();
            do
            {
                Console.WriteLine($"----------{store.name} ({user.userName}) (Total = $ {currPizza.totalPrice})----------");
                storeMenu.DisplayOptions();
                DashPaddings(60);
                Console.Write("Input: ");
                userInput = Console.ReadLine();
                
                switch(userInput)
                {
                    case "a":
                        PizzaSelectMenu();
                        break;
                    case "c":
                        //TODO custom pizza
                        break;
                    case "v":
                        ViewOrderMenu();
                        break;
                    case "b":
                        StoreSelectMenu();
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

        private static void StoreSelectMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();

            var userInput = "";
            List<PizzaStore> stores = PizzaStoreManager.Instance.GetStoreList();
            List<int> storeIDs = PizzaStoreManager.Instance.GetStoreIDList();

            OptionsGenerator extraMenu = new OptionsGenerator();
            extraMenu.Add("b", "Back to UserMenu");
            extraMenu.Add("q", "Quit");

            OptionsGenerator storeSelectMenu = new OptionsGenerator();
            foreach (PizzaStore store in stores)
            {
                storeSelectMenu.Add(store.storeID.ToString(), store.name);
                //Console.WriteLine(store.name);
            }

            do
            {
                Console.WriteLine($"\n----------Store Selection ({user.userName})----------");
                Console.WriteLine("Code".PadRight(10) + "StoreName");
                DashPaddings(60);
                storeSelectMenu.DisplayOptions();
                DashPaddings(60);
                extraMenu.DisplayOptions();
                DashPaddings(60);
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int storeID))
                {
                    // numeric input
                    if (storeIDs.Contains(storeID))
                    {
                        // Go to that store 
                        PizzaStoreManager.Instance.SetCurrStore(storeID);
                        StoreMenu();
                        break;

                    }
                }
                else if (userInput  == "b")
                {
                    //return to usermenu
                    UserMenu();
                }
                else if (userInput == "q")
                {
                    Environment.Exit(-1);
                    return;
                }
            } 
            // 
            while (userInput != "q" && userInput != "b");
        }



        private static void UserMenu()
        {
            var userInput = "";
            User user = AccountManager.Instance.GetCurrUser();

            OptionsGenerator userMenuOptions = new OptionsGenerator();
            userMenuOptions.Add("g", "GoToPizzaStore");
            userMenuOptions.Add("h", "ViewOrderHistory");
            userMenuOptions.Add("i", "ViewUserInfo");
            userMenuOptions.Add("e", "EditUserInfo");
            userMenuOptions.Add("s", "SignOut");
            userMenuOptions.Add("q", "Quit");

            do
            {
                Console.WriteLine($"----------User Menu ({user.userName})----------");
                userMenuOptions.DisplayOptions();
                DashPaddings(60);
                Console.Write("Input: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "g":
                        StoreSelectMenu();
                        break;
                    case "h":
                        //TODO: view order history
                        break;
                    case "i":
                        //TODO: view user info
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
                Console.WriteLine("\n----------Main Menu----------");
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
                        Console.WriteLine("\n----------Creating Account----------");
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
                        AccountManager.Instance.ListUsers();
                        break;
                    case "q":
                        Environment.Exit(-1);
                        break;

                }
            } while (userInput != "q");
        }
    }
}
