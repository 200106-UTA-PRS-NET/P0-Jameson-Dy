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

            MainMenu();

        }

        private static void StoreMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();
            PizzaStore store = PizzaStoreManager.Instance.GetCurrStore();

            store.Greetings();
            Console.WriteLine($"----------{store.name} ({user.userName})----------");


        }

        private static void StoreSelectMenu()
        {
            User user = AccountManager.Instance.GetCurrUser();

            var userInput = "";
            List<PizzaStore> stores = PizzaStoreManager.Instance.GetStoreList();
            List<int> storeIDs = PizzaStoreManager.Instance.GetStoreIDList();

            do
            {
                Console.WriteLine($"\n----------Store Selection ({user.userName})----------");
                Console.WriteLine($"Enter store id or \n'b' to go back to UserMenu \n'q' to Quit\n");
                Console.WriteLine($"{"StoreID",-20}StoreName");
                Console.WriteLine("".PadLeft(40, '-'));
                foreach (PizzaStore p in stores)
                {
                    Console.WriteLine($"{p.id,-20}{p.name}");
                }

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

            do
            {
                Console.WriteLine($"----------User Menu ({user.userName})----------");
                Console.WriteLine("o:\t OrderPizza");
                Console.WriteLine("h:\t ViewOrderHistory");
                Console.WriteLine("i:\t ViewUserInfo");
                Console.WriteLine("e:\t EditUserInfo");
                Console.WriteLine("s:\t SignOut");
                Console.WriteLine("q:\t Quit");
                Console.Write("\nInput: ");
                userInput = Console.ReadLine();

                if (userInput == "s")
                {
                    // signout
                    AccountManager.Instance.SignOut();
                    MainMenu();
                    break;
                } else if (userInput == "o") 
                {
                    StoreSelectMenu();
                    break;

                } else if (userInput == "h")
                {
                    //TODO: view order history
                } else if (userInput == "i")
                {
                    //TODO: view user info
                } else if (userInput == "e")
                {
                    //TODO: edit user info
                }

            } while (userInput != "q");
        }


        static void MainMenu()
        {
            var userInput = "";
            do
            {
                Console.WriteLine("\n----------Main Menu----------");
                Console.WriteLine("Must have an account to order:");
                Console.WriteLine("s:\t Signin");
                Console.WriteLine("r:\t Register");
                Console.WriteLine("l:\t ListUsers");
                Console.WriteLine("q:\t Quit");
                Console.Write("\nInput: ");
                userInput = Console.ReadLine();

                if (userInput == "s")
                {
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
                        break;
                    }

                }
                else if (userInput == "r")
                {
                    // register option
                    string usernameInput;
                    string passwordInput;
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

                    } else
                    {
                        Console.WriteLine("Creating account failed");
                    }
                } else if (userInput == "l")
                {
                    AccountManager.Instance.ListUsers();
                }
                else if (userInput == "q")
                {
                    return;
                }
            } while (userInput != "q");
        }


    }
}
