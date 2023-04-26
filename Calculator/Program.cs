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
        Menu.numberFunctionTable["exit"] = new Action(() => { active = false; });
        Menu.numberFunctionTable["vars"] = new Action(() => calc.DisplayVars());
        Menu.numberFunctionTable["save"] = new Action(() => FileManager.saveCalcState(calc));
        Menu.numberFunctionTable["load"] = new Action(() => FileManager.loadCalcState(calc));

        // displays the start text
        Menu.displayStart();

        // Ask if they want to load last state
        Console.Write("> Load Previous File? ");
        string ans = Console.ReadLine();
        if (ans.ToLower().Equals("yes"))
            FileManager.loadCalcState(calc);
        else
            Console.WriteLine("If you change your mind, type 'load'");
        
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

            Console.WriteLine("-----------------------------------");
            if (inputCount == 1)
            {
                if (Menu.numberFunctionTable.ContainsKey(inputs[0]))
                {
                    Menu.numberFunctionTable[inputs[0]]();
                }
                else
                {
                    Console.WriteLine("Not a recognized command");
                }
            }

            if (inputCount == 2)
            {
                string stateNum = calc.answer.ToString();
                Menu.numberFunctionTable[inputs[0]](stateNum, inputs[1]);
            }

            /* Reg. Notation
            // 1 + 1 + 1 => 3
            // input[0] input[1] input[2] input[3] input[4]
            // num operator num  // pattern */

            if (inputCount >= 3)
            {

                Menu.numberFunctionTable[inputs[1]](inputs[0], inputs[2]);
            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine(calc.answer);
            Console.WriteLine("-----------------------------------");
        }
            

        // conclusion
        Console.WriteLine("Bye!");
    }
}

