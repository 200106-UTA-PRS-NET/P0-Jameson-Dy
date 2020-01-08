using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mathematics m = new Mathematics();
            Console.WriteLine("Substraction: " + m.Subs(5, 6));
            Console.WriteLine("Addition: " + m.Add(5, 6, 4));
            Console.WriteLine("Division: " + m.Divide(5, 2));
        }
    }
}
