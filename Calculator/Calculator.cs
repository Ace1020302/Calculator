using System;
using System.Text.RegularExpressions;

namespace Calculator
{
	public class Calculator
	{

		// TODO:
		// Implement Menu
		// Actions:
		// Add, Subtract, Multiply, Divide, Mod, Sq,
		// Sq Root, Exponentiate, Facotrial

		// TODO:
		// Maintain State and Maintain Session

		// TODO:
		// Clear State

		// TODO:
		// lowercase only varbiable support

		// TODO:
		// Set State to saved variable

		// TODO:
		// Error msg for unknown variables

		// TODO:
		// Save vars in file for later (and load them)

		// TODO:
		// Bonuses:
		// Undo last operation (stack)
		// Reverse polish notation
		// nth Fib number where n is the value in calculator's current state


		public int answer { get; set; }

		public Dictionary<string, int> StoredVars = new();

        public int Add(int x, int y) => x + y;
        public int Sub(int x, int y) => x - y;
        public int Multiply(int x, int y) => x * y;
        public int Divide(int x, int y) => x / y;
        public int Mod(int x, int y) => x % y;
        public int Expontentiate(int x, int y) => x ^ y;
		public int SquareRoot(int x) => Expontentiate(x, 1 / 2);
		//public int Factorial(int x) => x!;


		/// <summary>
		/// Clears the calculator's state
		/// </summary>
		public void Clear()
		{
			Console.WriteLine("State set to 0");
			answer = 0;
		}

		/// <summary>
		/// Displays the answer stored in the state
		/// </summary>
		public void WriteAnswer()
		{
			Console.WriteLine(answer);
		}

		/// <summary>
		/// Stores a variable in the array
		/// </summary>
		/// <param name="name">Name of the variable</param>
		/// <param name="val">Value of the variable</param>
		public void StoreVar(string name, int val)
		{
            // Regex from https://www.techiedelight.com/check-string-consists-alphanumeric-characters-csharp/

			if (name == name.ToLower() && Regex.IsMatch(name, "^[a-zA-Z0-9]*$"))
                StoredVars[name] = val;
			else
				Console.WriteLine("Invalid Variable Name");
        }


		public void DisplayVars()
		{
			foreach (string key in StoredVars.Keys)
			{
				Console.WriteLine($"{key} = {StoredVars[key]}");
			}
		}
    }
}

