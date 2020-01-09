using System;

namespace PassByReference
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "a";

            Console.WriteLine(aaa(s));

            Console.WriteLine(s);
        }

        public static string aaa(string s)
        {
            s += "b";
            return s;
        }
    }
}
