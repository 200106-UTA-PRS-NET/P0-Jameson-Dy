using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    public class OptionsGenerator
    {
        private Dictionary<char, string> options;

        public OptionsGenerator() 
        {
            options = new Dictionary<char, string>();
        }
        public OptionsGenerator(List<char> symbols, List<string> descriptions )
        {
            options = new Dictionary<char, string>();

            for (int i = 0; i < symbols.Count; i++)
            {
                options.Add(symbols[i], descriptions[i]);
            }
        }

        public Dictionary<char, string> GetOptions()
        {
            return options;
        }

        public void Add(char c, string description)
        {
            options.Add(c, description);
        }

        public void DisplayOptions()
        {
            foreach (var o in options)
            {
                Console.WriteLine($"{o.Key}:\t{o.Value}");
            }
        }

    }


}
