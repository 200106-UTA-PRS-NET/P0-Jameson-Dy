using System;
using System.IO; // file Input/Output ops

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = "C:/Users/dyjam/OneDrive/Documents/Revature/test.txt";
            string path = "C:/Users/dyjam/OneDrive/Documents/Revature/te.txt";

            try
            {
                StreamReader reader = new StreamReader(path);
                Console.WriteLine(reader.ReadToEnd());
            } catch (FileNotFoundException e)
            {
                Console.WriteLine(e.StackTrace);
                // log exception
            } catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Console.Read();
        }
    }
}
