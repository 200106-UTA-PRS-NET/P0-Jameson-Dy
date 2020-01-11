using System;
using System.Threading;

namespace PassByReference
{
    class Program
    {
        static void Main(string[] args)
        {

            CEOSingleton.Instance.setName("James");

            Thread t = new Thread(printName);
            t.Start();

            Console.WriteLine(CEOSingleton.Instance.getName());


        }

        static void printName()
        {
            CEOSingleton.Instance.setName("Fred");
            Console.WriteLine(CEOSingleton.Instance.getName());
        }
    }
}
