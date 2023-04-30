﻿
///////////////////////////////////////////////////////////////////////////////
//
// Author: Phillip Edwards, edwardspb1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Calculator Project 7
// Description: Class that starts the program and handles the console input.
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Text.RegularExpressions;

namespace Calculator;
class Program
{
    static void Main(string[] args)
    {
        // Starts the calculator
        Calculator calc = new Calculator();
        bool active = true;

        // Dispatch table for operations requiring multiple inputs
        // Wrap into actions, save return in calculator and revmoe the return.
        Menu.numberFunctionTable["+"] = new Action<string, string>((first, second) => calc.Add(first, second));
        Menu.numberFunctionTable["-"] = new Action<string, string>((first, second) => calc.Sub(first, second));
        Menu.numberFunctionTable["*"] = new Action<string, string>((first, second) => calc.Multiply(first, second));
        Menu.numberFunctionTable["/"] = new Action<string, string>((first, second) => calc.Divide(first, second));
        Menu.numberFunctionTable["%"] = new Action<string, string>((first, second) => calc.Mod(first, second));
        Menu.numberFunctionTable["^"] = new Action<string, string>((first, second) => calc.Expontentiate(first, second));
        Menu.numberFunctionTable["!"] = new Action<string>((number) => calc.Factorial(number));
        Menu.numberFunctionTable["sq"] = new Action<string>((number) => calc.Square(number));
        Menu.numberFunctionTable["sqrt"] = new Action<string>((number) => calc.SquareRoot(number));

        // Dispatch table with string comparisons
        Menu.numberFunctionTable["="] = new Action<string, string>((first, second) => calc.StoreVar(first, second));
        Menu.numberFunctionTable["undo"] = new Action(() => calc.Undo());
        Menu.numberFunctionTable["clear"] = new Action(() => calc.Clear());
        Menu.numberFunctionTable["start"] = new Action(() => Menu.displayStart());
        Menu.numberFunctionTable["exit"] = new Action(() => { active = false; });
        Menu.numberFunctionTable["vars"] = new Action(() => calc.DisplayVars());
        Menu.numberFunctionTable["save"] = new Action(() => FileManager.saveCalcState(calc));
        Menu.numberFunctionTable["load"] = new Action(() => FileManager.loadCalcState(calc));
        Menu.numberFunctionTable["help"] = new Action(() => Menu.displayCommands());


        Menu.descriptionDictionary["+"] = "Adds two numbers.";
        Menu.descriptionDictionary["-"] = "Subtracts two numbers.";
        Menu.descriptionDictionary["*"] = "Multiplies two numbers.";
        Menu.descriptionDictionary["/"] = "Divides two numbers.";
        Menu.descriptionDictionary["%"] = "Finds the Remainder of a division between two numbers.";
        Menu.descriptionDictionary["^"] = "Takes one number to the power of another.";
        Menu.descriptionDictionary["!"] = "Finds Factorial of a number.";
        Menu.descriptionDictionary["sq"] = "Squares a single number.";
        Menu.descriptionDictionary["sqrt"] = "Finds Square Root of a single number.";

        // DidescriptionDictionarytring co
        Menu.descriptionDictionary["="] = "Sets a lower-case string to a value for calculations.";
        Menu.descriptionDictionary["undo"] = "Undoes the last operation.";
        Menu.descriptionDictionary["clear"] = "Clears the State (sets it to 0).";
        Menu.descriptionDictionary["start"] = "Shows the start screen.";
        Menu.descriptionDictionary["exit"] = "Exits the program.";
        Menu.descriptionDictionary["vars"] = "Shows the variables in use and their values.";
        Menu.descriptionDictionary["save"] = "Saves the state of the calculator.";
        Menu.descriptionDictionary["load"] = "Loads the previousily saved calculator state.";
        Menu.descriptionDictionary["help"] = "Displays the commands and their descriptions.";
        // displays the start text
        Menu.displayStart();

        // Ask if they want to load last state
        PromptLoading(calc);

        // output for current loop
        string output = "";

        //string regPatForOps = """[0-9]{1+}[\s]*[=-*/%^][\s]*[0-9]{1+}""";
        //string regPatForFuncs = """[-a-zA-Z]*""";

        // The main loop
        while (active)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            string[] inputs = input.Split(" ");
            int inputCount = inputs.Length;


            // UGLY STUFF BELOW!
            Console.WriteLine("-----------------------------------");
            if (inputCount == 1)
            {
                if (inputs[0].Equals("sq") || inputs[0].Equals("sqrt") || inputs[0].Equals("!"))
                {
                    try
                    {
                        Menu.numberFunctionTable[inputs[0]](calc.answer.ToString());
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                else if (Menu.numberFunctionTable.ContainsKey(inputs[0]))
                {
                    try
                    {
                        Menu.numberFunctionTable[inputs[0]]();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid Input");
                        Console.WriteLine(e.Message);
                    }
                }
                else if (calc.StoredVars.ContainsKey(inputs[0]))
                {
                    calc.Set(inputs[0]);
                }
                else
                {
                    Console.WriteLine("Not a recognized command");
                }
        }

            if (inputCount == 2)
            {
                if (inputs[0].Equals("sq") || inputs[0].Equals("sqrt"))
                {
                    try
                    {
                        Menu.numberFunctionTable[inputs[0]](inputs[1]);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                else if (inputs[1].Equals("!"))
                {
                    try
                    {
                        Menu.numberFunctionTable[inputs[1]](inputs[0]);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                else
                {
                    try
                    {
                        string stateNum = calc.answer.ToString();
                        Menu.numberFunctionTable[inputs[0]](stateNum, inputs[1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }


            }

            /* Reg. Notation
            // 1 + 1 + 1 => 3
            // input[0] input[1] input[2] input[3] input[4]
            // num operator num  // pattern */

            if (inputCount >= 3)
            {
                try
                {
                    Menu.numberFunctionTable[inputs[1]](inputs[0], inputs[2]);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Invalid Input");
                }

            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine(calc.answer);
            Console.WriteLine("-----------------------------------");
        }


        // conclusion
        Console.WriteLine("Bye!");
    }

    /// <summary>
    /// Prmopts user if they want to load a file at the beginning
    /// </summary>
    /// <param name="calc"> Calculator object to load file into </param>
    private static void PromptLoading(Calculator calc)
    {
        Console.Write("> Load Previous File? ");
        string ans = Console.ReadLine();
        if (ans.ToLower().Equals("yes"))
            FileManager.loadCalcState(calc);
        else
            Console.WriteLine("If you change your mind, type 'load'");
    }
}

