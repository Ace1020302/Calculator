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

        // Dispatch table with string comparisons
        Menu.numberFunctionTable["="] = new Action<string, string>((first, second) => calc.StoreVar(first, second)); ;
        Menu.numberFunctionTable["undo"] = new Action(() => calc.Undo());
        Menu.numberFunctionTable["clear"] = new Action(() => calc.Clear());
        Menu.numberFunctionTable["start"] = new Action(() => Menu.displayStart());
        Menu.numberFunctionTable["exit"] = new Action(() => { Menu.displayEnd(); active = false; });
        Menu.numberFunctionTable["vars"] = new Action(() => calc.DisplayVars());

        // Dispatch table for no-param operations
        //Menu.noReturnFunctionTable["clear"] = calc.Clear;
        //Menu.noReturnFunctionTable["start"] = Menu.displayStart;
        //Menu.noReturnFunctionTable["exit"] = ( () => { Menu.displayEnd(); active = false; });
        //Menu.noReturnFunctionTable["vars"] = calc.DisplayVars;
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


            if (inputCount == 1)
            {
                if (Menu.numberFunctionTable.ContainsKey(inputs[0]))
                {
                    Menu.numberFunctionTable[inputs[0]]();
                    if (inputs[0].Contains("exit"))
                        continue;
                }
                else
                {
                    Console.WriteLine("Not a recognized command");
                }
            }

            /* Reg. Notation
            // 1 + 1 + 1 => 3
            // input[0] input[1] input[2] input[3] input[4]
            // num operator num  // pattern */

            if (inputCount >= 3)
            {
                if (!inputs[1].Contains("="))
                    Menu.numberFunctionTable[inputs[1]](inputs[0], inputs[2]);
                else
                    Menu.numberFunctionTable[inputs[1]](inputs[0], inputs[2]);
            }

            Console.WriteLine(calc.answer);

            // Polish Notation
            // 1 1 + 1 +
            // input[0] input[1] input[2] input[3] input[4]
            // num num operator // pattern
        }
            

        // conclusion
        Console.WriteLine("Bye!");
    }
}

