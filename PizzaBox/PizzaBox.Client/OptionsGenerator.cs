using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Client
{
    public class OptionsGenerator
    {
        private Dictionary<string, string> options;
        private List<float> prices = new List<float>();

        public OptionsGenerator()
        {
            options = new Dictionary<string, string>();
        }
        public OptionsGenerator(List<string> symbols, List<string> descriptions)
        {
            options = new Dictionary<string, string>();

            for (int i = 0; i < symbols.Count; i++)
            {
                options.Add(symbols[i], descriptions[i]);
            }
        }

        public OptionsGenerator(List<string> symbols, List<string> descriptions, List<float> prices)
        {
            options = new Dictionary<string, string>();
            this.prices.AddRange(prices);

            for (int i = 0; i < symbols.Count; i++)
            {
                options.Add(symbols[i], descriptions[i]);
            }
        }

        public Dictionary<string, string> GetOptions()
        {
            return options;
        }

        public void Add(string c, string description)
        {
            options.Add(c, description);
        }

        public void Add(string c, string description, float price)
        {
            options.Add(c, description);
            prices.Add(price);
        }

        public void DisplayOptions(int displayType)
        {
            switch (displayType)
            {
                case 1:
                    // displays symbol, description, and price
                    int i = 0; // to iterate price list
                    foreach (var o in options)
                    {
                        //Console.WriteLine($"{o.Key}:\t\t{o.Value}\t\t\t{prices[i]}");
                        Console.Write($"{o.Key}".PadRight(12));
                        Console.Write($"{o.Value}".PadRight(20));
                        Console.Write($"$ {prices[i].ToString("###0.00")}\n");

                        i++;
                    }
                    break;
                default:
                    DisplayOptions();
                    break;

            }

        }

        public void DisplayOptions()
        {
            foreach (var o in options)
            {
                Console.WriteLine($"{o.Key}:".PadRight(12) + $"{o.Value}");
            }
        }

    }
}
