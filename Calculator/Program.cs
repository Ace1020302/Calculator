namespace Calculator;
class Program
{
    static void Main(string[] args)
    {
        Calculator calc = new Calculator();
        Menu.dispatchTable["+"] = calc.Add;
        Menu.dispatchTable["-"] = calc.Sub;
        Menu.dispatchTable["*"] = calc.Multiply;
        Menu.dispatchTable["/"] = calc.Divide;
        Menu.dispatchTable["%"] = calc.Mod;
        Menu.dispatchTable["^"] = calc.Expontentiate;

        while (true)
        { 
            string input = Console.ReadLine();

            if (input.ToLower().Equals("exit"))
                break;

            string[] inputs = input.Split(" ");

            var userFunc = Menu.dispatchTable[inputs[1]];
            int firstNum = int.Parse(inputs[0]);
            int secondNum = int.Parse(inputs[2]);
            Console.WriteLine(userFunc(firstNum, secondNum));
        }

        Console.WriteLine("Bye!");
    }
}

