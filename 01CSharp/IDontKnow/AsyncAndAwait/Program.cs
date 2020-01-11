using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class Program
    {
        static void Main(string[] args) // Main thread is created
        {
            Console.WriteLine("Inside Main Method");
            MethodCall();
            Console.WriteLine("Main Method finished");


        }
        public async static void MethodCall()
        {
            Console.WriteLine("---------Inside Method 2 - starting---------");
            await Task.Run(new Action(LongMethod)); // creates a new thread
            Console.WriteLine("---------Method 2 - finished---------");

        }

        public static void LongMethod()
        {
            Console.WriteLine("----------Starting Long Method----------");
            Thread.Sleep(5000);
            Console.WriteLine("----------Long Method Finished----------");
        }
    }
}
