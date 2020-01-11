using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace PizzaBox.Domain.Models
{

    public sealed class AccountManager
    {
        private static readonly AccountManager instance = new AccountManager();
        //private static int totalUsers;
        private static Dictionary<int, User> users = new Dictionary<int, User>(); // key - userID, value - User object 
        private static Dictionary<string, int> userIDs = new Dictionary<string, int>(); // key - username, value - userID
        private static User currUser;

        const int MIN_PASSWORD_LENGTH = 8;
        const int MAX_PASSWORD_LENGTH = 15;
        const int MIN_USERNAME_LENGTH = 8;
        const int MAX_USERNAME_LENGTH = 15;


        static AccountManager()
        {
        }
        private AccountManager()
        {
        }

        public static AccountManager Instance
        {
            get
            {
                return instance;
            }
        }

        public bool CreateUser(string username, string password)
        {
            if (IsValidUserNamePassword(username, password))
            {
                // create user
                User newUser = new User();
                newUser.userName = username;
                newUser.password = password;
                newUser.id = users.Count + 1;

                userIDs.Add(username, newUser.id);
                users.Add(newUser.id, newUser);

                return true;
            } else
            {
                return false;
            }
        }

        // returns true if username and password entry is valid
        public bool IsValidUserNamePassword(string username, string password)
        {
            bool validUsername = false;
            bool validPassword = false;

            if (username.Length >= MIN_USERNAME_LENGTH && username.Length <= MAX_USERNAME_LENGTH)
            {
                validUsername = true;
            }

            // validate password
            if (password.Length >= MIN_PASSWORD_LENGTH && password.Length <= MAX_PASSWORD_LENGTH)
            {
                validPassword = true;
            }

            if (validUsername && validPassword)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool SignIn(string username, string password)
        {
            if (IsValidUserNamePassword(username, password))
            {
                User user = users[userIDs[username]];
                if (user.password == password)
                {
                    Console.WriteLine("\nSign in successful");
                    currUser = user;
                    return true;
                } else
                {
                    Console.WriteLine("\nSign in failed :(");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("\nSign in failed :(");
                return false;
            }


        }

        public void GetUserInfo(int id)
        {
            Console.WriteLine(users[id].userName);
        }

        public void UpdateUserInfo()
        {
            Console.Write("Name: ");
            string name =  Console.ReadLine();
            Console.Write("Username: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
        }

        // Displays all user's username and id
        public void ListUsers()
        {
            Console.WriteLine($"\nTotal Users: {users.Count}");
            Console.WriteLine($"{"Username", -20}UserID");
            Console.WriteLine("".PadLeft(40, '-'));
            foreach (User u in users.Values) {
                string n = u.id.ToString("D" + 8);  // converts to string with leading decimal 0s
                Console.WriteLine($"{u.userName, -20}{n}");
            }
        }

        public int GetTotalUsers()
        {
            return users.Count;
        }

        public User GetCurrUser()
        {
            return currUser;
        }

        public void SignOut()
        {
            currUser = null;
            Console.WriteLine("\nSigned out");
        }






    }
}
