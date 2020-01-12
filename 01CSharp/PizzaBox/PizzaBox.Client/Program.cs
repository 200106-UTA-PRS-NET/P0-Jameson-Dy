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

            // test store
            PizzaStore pizahat = new PizzaStore();
            pizahat.name = "Pizahat";
            pizahat.id = 1;
            PizzaStoreManager.Instance.AddStore(pizahat);

            PizzaStore mamajohn = new PizzaStore();
            mamajohn.name = "Mama Johns";
            mamajohn.id = 2;
            PizzaStoreManager.Instance.AddStore(mamajohn);

            MainMenu();

        }

        private static void StoreMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();
            PizzaStore store = PizzaStoreManager.Instance.GetCurrStore();
            OptionsGenerator storeMenu = new OptionsGenerator();
            storeMenu.Add("m", "Menu");
            storeMenu.Add("c", "CustomPizza");
            storeMenu.Add("b", "Back to Store Selection");
            storeMenu.Add("s", "SignOut");
            storeMenu.Add("q", "Quit");


            var userInput = "";
            store.Greetings();
            do
            {
                Console.WriteLine($"----------{store.name} ({user.userName})----------");
                storeMenu.DisplayOptions();
                Console.Write("\nInput: ");
                userInput = Console.ReadLine();
                
                switch(userInput)
                {
                    case "m":
                        //TODO open menu
                        break;
                    case "c":
                        //TODO custom pizza
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

            OptionsGenerator storeSelectMenu = new OptionsGenerator();
            storeSelectMenu.Add("b", "Back to UserMenu");
            storeSelectMenu.Add("q", "Quit");
            foreach (PizzaStore p in stores)
            {
                storeSelectMenu.Add(p.id.ToString(),p.name);
                Console.WriteLine(p.name);
            }

            do
            {
                Console.WriteLine($"\n----------Store Selection ({user.userName})----------");
                Console.WriteLine($"{"Code"}\t\tStoreName");
                Console.WriteLine("".PadLeft(40, '-'));
                storeSelectMenu.DisplayOptions();
                Console.Write("\nInput: ");
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
                Console.Write("\nInput: ");
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
                Console.Write("\nInput: ");
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
