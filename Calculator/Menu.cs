
///////////////////////////////////////////////////////////////////////////////
//
// Author: Phillip Edwards, edwardspb1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Calculator Project 7
// Description: Class that provides calculator menu/text functions.
//
///////////////////////////////////////////////////////////////////////////////

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

        /// <summary>
        /// Displays the start menu
        /// </summary>
        public static void displayStart()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("WELCOME TO CONSOLE CALCULATOR");
            Console.WriteLine();
            Console.WriteLine("Please remember to space out input!");
            Console.WriteLine("Examples: 1 + 3, 4 - 3, 10 % 3");
            Console.WriteLine();
            Console.WriteLine("Also, if you have saved variables" +
                "\n  you can set the state to the variables" + 
                "\n  by just typing the variable name");
            Console.WriteLine();
            Console.WriteLine("For other commands, type 'help'");
            Console.WriteLine("To see this again, type 'start'");
            Console.WriteLine();
            Console.WriteLine("To exit, type 'exit'");
            Console.WriteLine("===================================");  
        }

        /// <summary>
        /// Displays the commands of the Calculator
        /// </summary>
        public static void displayCommands()
        {
            foreach(string key in descriptionDictionary.Keys)
                Console.WriteLine($"{key}: {descriptionDictionary[key]}");
        }
    }
}

