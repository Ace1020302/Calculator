using System;
namespace Calculator
{
	public class Menu
	{
        // establishes dispatch table for menu.
        public static Dictionary<string, Func<int, int, int>> numberFunctionTable = new();
        public static Dictionary<string, Action> noReturnFunctionTable = new();
        public static Dictionary<string, Action<string, int>> singleReturnsTable = new();
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
            Console.WriteLine("To Exit, type 'exit'");
            Console.WriteLine("===================================");
            
        }

        public static void displayEnd() => Console.WriteLine("Bye");
    }
}

