using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace PizzaBox.Domain.Models
{
    public sealed class AccountManager
    {
        private static readonly AccountManager instance = new AccountManager();
        private static Dictionary<int, User> users = new Dictionary<int, User>(); // key - userID, value - User object 
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

        private List<int> GetUserIDList()
        {
            return new List<int>(users.Keys);
        }
        // returns a list of all usernames
        private List<string> GetUsernameList()
        {
            List<string> usernames = new List<string>();
            foreach (User u in users.Values)
            {
                usernames.Add(u.username);
            }

            return usernames;
        }

        private List<User> GetUsersList()
        {
            return new List<User>(users.Values);
        }

        private string GetUsernameByID(int id)
        {
            List<User> userList = GetUsersList();
            foreach (User u in userList)
            {
                if (u.userID == id)
                {
                    return u.username;
                }
            }
            throw new KeyNotFoundException();
        }

        private User GetUserByUsername(string username)
        {
            foreach (User u in GetUsersList())
            {
                if (u.username == username)
                {
                    return u;
                }
            }
            return null;
        }

        public bool CreateUser(string username, string password)
        {
            if (IsValidUserNamePassword(username, password))
            {
                if (GetUsernameList().Contains(username))
                {
                    Console.WriteLine("Username already in use");
                    return false;
                }
                // create user
                User newUser = new User();
                newUser.username = username;
                newUser.password = password;
                newUser.userID = users.Count + 1;   //TODO: need to adjust for when removing user functionality is added 

                // add to users dictionary
                users.Add(newUser.userID, newUser);

                return true;
            } else
            {
                return false;
            }
        }

        // returns true if username and password follows the constraints
        //TODO: (Optional) require stronger password (Capitalize, 1 char, 1 number)
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
                if (GetUsernameList().Contains(username))
                {
                    //Assert: username is in list
                    User user = GetUserByUsername(username);
                    if (user.password == password)
                    {
                        // password match
                        currUser = user;
                        Console.WriteLine("\nSign in successful :)");
                        return true;
                    }
                    else
                    {
                        // wrong password
                        Console.WriteLine("\nSign in failed :(");
                        return false;
                    }

                }
                else
                {
                    //username not found
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

        public User GetUser(int id)
        {
            return users[id];
        }

        public void DisplayCurrUserInfo()
        {         
            //TODO: Add more display info
            Console.WriteLine($"Username:".PadRight(15) + currUser.username);
            Console.WriteLine($"UserID:".PadRight(15) + currUser.userID);
        }

        // TODO: check if valid inputs + update user
        public void UpdateUserInfo(int id)
        {
            Console.Write("Name: ");
            string name =  Console.ReadLine();
            Console.Write("Username: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
        }

        // Displays all user's username and id
        public void DisplayAllUsers()
        {
            Console.WriteLine($"Total Users:".PadRight(15) + users.Count);
            Console.WriteLine("Username".PadRight(15) + "UserID");
            Console.WriteLine("".PadLeft(40, '-'));
            foreach (User u in users.Values) {
                string id = u.userID.ToString("D" + 8);  // converts to string with leading decimal 0s
                Console.WriteLine($"{u.username}".PadRight(15) + id);
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
