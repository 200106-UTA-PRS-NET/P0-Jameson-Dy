using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{

    class Program
    {
        const float Pi = 3.14f; // value cannot be changed
        readonly int gavity = 4;    // value cannot be changed except in constructor

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
            
            // 2d array
            int[,] twoDArray = new int[3, 4];   // 3 x 4 array

            // Jagged array - array within an array
            int[][] jaggedArray = new int[3][]; // initialize rows first
            // initialize columns for each row
            jaggedArray[0] = new int[3] { 1, 2, 3};
            jaggedArray[1] = new int[2] { 6, 4 };

            // loop through the rows
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                // loop through the columns
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.WriteLine(jaggedArray[i][j]);
                }
            }

            //Dictionary
            Dictionary<int, string> books = new Dictionary<int, string>();
            books.Add(23, "How to Read");
            books.Add(43, "Books for sale");

            foreach (var bookKey in books.Keys)
            {
                Console.WriteLine($"{bookKey}  {books[bookKey]}");
            }

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
