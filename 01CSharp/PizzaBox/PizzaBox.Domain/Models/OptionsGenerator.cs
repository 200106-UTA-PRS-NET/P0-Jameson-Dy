using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    public class OptionsGenerator
    {
        private Dictionary<string, string> options;

        public OptionsGenerator() 
        {
            options = new Dictionary<string, string>();
        }
        public OptionsGenerator(List<string> symbols, List<string> descriptions )
        {
            options = new Dictionary<string, string>();

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

        public void DisplayOptions(int gapSize)
        {
            foreach (var o in options)
            {
                Console.WriteLine($"{o.Key}".PadLeft(gapSize, '-') + "A");

            }
        }

        public void DisplayOptions()
        {
            foreach (var o in options)
            {
                Console.WriteLine($"{o.Key}:\t\t{o.Value}");
            }
        }

    }


}
