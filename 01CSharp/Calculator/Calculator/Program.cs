using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Mathematics m = new Mathematics();
            Console.WriteLine("Substraction: " + m.Subs(5, 6));
            Console.WriteLine("Addition: " + m.Add(5, 6, 4));
            Console.WriteLine("Division: " + m.Divide(5, 2));
            */

            int[] nums;
            nums = new int[10];
            Console.WriteLine("Enter 10 numbers");

            for (int i = 0; i < 10; i++)
            {
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Display");
            foreach (int i in nums)
            {
                Console.WriteLine(i);
            }

        }


    }
}
