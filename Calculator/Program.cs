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

        // Dispatch table with string comparisons
        Menu.singleReturnsTable["="] = calc.StoreVar;

        // Dispatch table for no-param operations
        Menu.noReturnFunctionTable["clear"] = calc.Clear;
        Menu.noReturnFunctionTable["start"] = Menu.displayStart;
        Menu.noReturnFunctionTable["exit"] = (() => { Menu.displayEnd(); active = false; });
        Menu.noReturnFunctionTable["vars"] = calc.DisplayVars;
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

            // Commands
            if (inputCount == 1)
            {
               var userFunc = Menu.noReturnFunctionTable[inputs[0]];
            }

            // Reg. Notation
            // 1 + 1 + 1 => 3
            // input[0] input[1] input[2] input[3] input[4]
            // num operator num  // pattern

            if (inputCount >= 3)
            {
                if (Menu.singleReturnsTable.ContainsKey(inputs[1]))
                {
                    var userFunc = Menu.singleReturnsTable[inputs[1]];
                    calc.StoreVar(inputs[0], int.Parse(inputs[2]));
                }

                
            }

            // Polish Notation
            // 1 1 + 1 +
            // input[0] input[1] input[2] input[3] input[4]
            // num num operator // pattern
        }
            

        // conclusion
        Console.WriteLine("Bye!");
    }
}

