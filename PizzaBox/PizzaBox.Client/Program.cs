using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using PizzaBox.Domain;
using System.Linq;
using System.Collections.Generic;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            MenuSystemManager.MainMenu();
        }

        static void Rave()
        {
            while (true)
            {
                foreach (ConsoleColor color in Enum.GetValues(typeof(ConsoleColor)))
                {
                    Console.BackgroundColor = color;
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
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
