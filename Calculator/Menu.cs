using System;
namespace Calculator
{
	public class Menu
	{
		// establishes dispatch table for menu.
		public static Dictionary<string, Func<int, int, int>> dispatchTable = new();

		// Handles hci's
		public Menu()
		{

		}

        public static void displayStart()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("WELCOME TO CONSOLE CALCULATOR");
            Console.WriteLine();
            Console.WriteLine("Please remember to space out input!");
            Console.WriteLine("Examples: 1 + 3, 4 - 3, 10 % 3");
            Console.WriteLine("===================================");
            
        }
        //int Add(int x, int y) => x + y;
        //int Sub(int x, int y) => x - y;
        //int Multiply(int x, int y) => x * y;
        //int Divide(int x, int y) => x / y;
        //int Mod(int x, int y) => x % y;
        //int Expontentiate(int x, int y) => x ^ y;
        //int Root(int x, int y) => Expontentiate(x, 1 / y);
        //int Factorial(int x) => x!;
    }
}

