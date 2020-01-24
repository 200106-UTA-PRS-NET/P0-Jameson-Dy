using System;
using PizzaBox.Domain;
using System.Linq;
using System.Threading;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write(Fred2());
            //Rave(Fred2());
            //Console.ReadKey(true);

            Console.ForegroundColor = ConsoleColor.Yellow;
            MenuSystemManager.MainMenu();

        }

        public static string Fred()
        {
            string f =
                       " /$$$$$$$$                        /$$\n" +
                       "| $$_____/                       | $$\n" +
                       "| $$     /$$$$$$   /$$$$$$   /$$$$$$$\n" +
                       "| $$$$$ /$$__  $$ /$$__  $$ /$$__  $$\n" +
                       "| $$__/| $$  \\__/| $$$$$$$$| $$  | $$\n" +
                       "| $$   | $$      | $$_____/| $$  | $$\n" +
                       "| $$   | $$      |  $$$$$$$|  $$$$$$$\n" +
                       "|__/   |__/       \\_______/ \\_______/\n";
            return f;
        }
        public static string Fred2()
        {
            string f =
"          _____                    _____                    _____                    _____          \n" +
"         /\\    \\                  /\\    \\                  /\\    \\                  /\\    \\         \n" +
"        /::\\    \\                /::\\    \\                /::\\    \\                /::\\    \\        \n" +
"       /::::\\    \\              /::::\\    \\              /::::\\    \\              /::::\\    \\       \n" +
"      /::::::\\    \\            /::::::\\    \\            /::::::\\    \\            /::::::\\    \\      \n" +
"     /:::/\\:::\\    \\          /:::/\\:::\\    \\          /:::/\\:::\\    \\          /:::/\\:::\\    \\     \n" +
"    /:::/__\\:::\\    \\        /:::/__\\:::\\    \\        /:::/__\\:::\\    \\        /:::/  \\:::\\    \\    \n" +
"   /::::\\   \\:::\\    \\      /::::\\   \\:::\\    \\      /::::\\   \\:::\\    \\      /:::/    \\:::\\    \\   \n" +
"  /::::::\\   \\:::\\    \\    /::::::\\   \\:::\\    \\    /::::::\\   \\:::\\    \\    /:::/    / \\:::\\    \\  \n" +
" /:::/\\:::\\   \\:::\\    \\  /:::/\\:::\\   \\:::\\____\\  /:::/\\:::\\   \\:::\\    \\  /:::/    /   \\:::\\ ___\\ \n" +
"/:::/  \\:::\\   \\:::\\____\\/:::/  \\:::\\   \\:::|    |/:::/__\\:::\\   \\:::\\____\\/:::/____/     \\:::|    |\n" +
"\\::/    \\:::\\   \\::/    /\\::/   |::::\\  /:::|____|\\:::\\   \\:::\\   \\::/    /\\:::\\    \\     /:::|____|\n" +
" \\/____/ \\:::\\   \\/____/  \\/____|:::::\\/:::/    /  \\:::\\   \\:::\\   \\/____/  \\:::\\    \\   /:::/    / \n" +
"          \\:::\\    \\            |:::::::::/    /    \\:::\\   \\:::\\    \\       \\:::\\    \\ /:::/    /  \n" +
"           \\:::\\____\\           |::|\\::::/    /      \\:::\\   \\:::\\____\\       \\:::\\    /:::/    /   \n" +
"            \\::/    /           |::| \\::/____/        \\:::\\   \\::/    /        \\:::\\  /:::/    /    \n" +
"             \\/____/            |::|  ~|               \\:::\\   \\/____/          \\:::\\/:::/    /     \n" +
"                                |::|   |                \\:::\\    \\               \\::::::/    /      \n" +
"                                \\::|   |                 \\:::\\____\\               \\::::/    /       \n" +
"                                 \\:|   |                  \\::/    /                \\::/____/        \n" +
"                                  \\|___|                   \\/____/                  ~~              \n";
                                                                                                    

            return f;
        }
        public static void Rave(string f)
        {
            int i = 10;
            while (i > 0)
            {
                foreach (ConsoleColor color in Enum.GetValues(typeof(ConsoleColor)))
                {
                    Console.BackgroundColor = color;
                    Console.Write($"{f}");
                    Thread.Sleep(70);
                    i--;
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
                if (color == ConsoleColor.White)
                {
                    color = ConsoleColor.Black;
                }

            }
            Console.Read();
        }
    }
}
