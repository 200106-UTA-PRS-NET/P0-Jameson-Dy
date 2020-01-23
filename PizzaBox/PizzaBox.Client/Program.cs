using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using PizzaBox.Domain;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write(Fred());
            //Rave(Fred());
            //Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.Yellow;
            MenuSystemManager.MainMenu();
        }

        public static string Fred()
        {
            string f =
                       " /$$$$$$$$                        /$$\n" +
                       "| $$_____/                       | $$\n" +
                       "| $$     /$$$$$$   /$$$$$$   /$$$$$$$\n" +
                       "| $$$$$ /$$__  $$ /$$__  $$ /$$__  $$\n" +
                       "| $$__/| $$  \\__/| $$$$$$$$| $$  | $$\n" +
                       "| $$   | $$      | $$_____/| $$  | $$\n" +
                       "| $$   | $$      |  $$$$$$$|  $$$$$$$\n" +
                       "|__/   |__/       \\_______/ \\_______/\n";
            return f;

        }

        public static void Rave(string f)
        {
            while (true)
            {
                foreach (ConsoleColor color in Enum.GetValues(typeof(ConsoleColor)))
                {
                    Console.BackgroundColor = color;
                    Console.Write($"{f}");
                    Thread.Sleep(25);
                }
            }
        }

        static void Rainbowfy(string text)
        {
            ConsoleColor color = ConsoleColor.Red;
            

            for (int i = 0; i < text.Count(); i++)
            {
                Console.ForegroundColor = color;
                Console.Write(text[i]);
                color++;
                if (color == ConsoleColor.Yellow)
                {
                    color = ConsoleColor.DarkBlue;
                }

            }
            Console.Read();
        }
    }
}
