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
        Menu.numberFunctionTable["+"] = calc.Add;
        Menu.numberFunctionTable["-"] = calc.Sub;
        Menu.numberFunctionTable["*"] = calc.Multiply;
        Menu.numberFunctionTable["/"] = calc.Divide;
        Menu.numberFunctionTable["%"] = calc.Mod;
        Menu.numberFunctionTable["^"] = calc.Expontentiate;

        // Dispatch table for no-param operations
        Menu.noReturnFunctionTable["clear"] = calc.Clear;
        Menu.noReturnFunctionTable["start"] = Menu.displayStart;
        Menu.noReturnFunctionTable["exit"] = (() => { Menu.displayEnd(); active = false; });

        // displays the start text
        Menu.displayStart();

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
        }
            

        /* 
            if (inputCount == 1)
            {
                try
                {
                    Menu.noReturnFunctionTable[inputs[0]]();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Not a command.");
                }
            }
            else if (inputCount == 3) {
                try
                {
                    var userFunc = Menu.numberFunctionTable[inputs[1]];
                    int firstNum = int.Parse(inputs[0]);
                    int secondNum = int.Parse(inputs[2]);
                    Console.WriteLine(userFunc(firstNum, secondNum));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input, try again");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input, try again");
            }
        */

        // conclusion
        Console.WriteLine("Bye!");
    }
}

