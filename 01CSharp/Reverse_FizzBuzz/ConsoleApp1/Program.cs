using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            Console.WriteLine("Write string to reverse: ");
            userInput = Console.ReadLine();

            Console.WriteLine(Reverse(userInput) + "\n");

            int userInputInt = 0;
            do
            {
                Console.Write("Write FizzBuzz number (0) to quit: ");
                userInputInt = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(FizzBuzz(userInputInt));
            }
            while (userInputInt != 0);

        }

        // write program to reverse string w/o using reverse method
        public static string Reverse(string s)
        {
            string result = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                result += s[i];
            }
            return result;
        }

        // write a fizzbuzz game
        public static string FizzBuzz(int n)
        {
            if ((n % 3 == 0) && (n % 5 == 0))
            {
                return "FizzBuzz";
            } else if (n % 3 == 0)
            {
                return "Fizz";
            } else if (n % 5 == 0)
            {
                return "Buzz";
            } else
            {
                return n.ToString();
            }
        }
    }
}
