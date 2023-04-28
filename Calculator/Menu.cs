using System;
using System.ComponentModel;

namespace Calculator
{
	public class Menu
	{
        // Establishes dispatch table for menu
        public static Dictionary<string, dynamic> numberFunctionTable = new();

        // Could fold into a single dictionary with the other and make a class to hold an action and a description...
        public static Dictionary<string, string> descriptionDictionary = new();


        // Handles HCI's
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
            Console.WriteLine("For other commands, type 'help'");
            Console.WriteLine("To see this again, type 'start'");
            Console.WriteLine("To exit, type 'exit'");
            Console.WriteLine("===================================");  
        }

        public static void displayCommands()
        {
            foreach(string key in descriptionDictionary.Keys)
                Console.WriteLine($"{key}: {descriptionDictionary[key]}");
        }
    }
}

