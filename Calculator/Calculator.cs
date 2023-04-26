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


		private Stack<double> answers = new Stack<double>();

		public double answer { get => answers.Count() == 0 ? 0 : answers.Peek(); set { answers.Push(value); } }

		public Dictionary<string, double> StoredVars = new();

		public void Add(string x, string y)
		{
			double intOne = Parse(x);
            double intTwo = Parse(y);

			answer = intOne + intTwo;
		}

		public void Undo()
		{
			double x;
			answers.TryPop(out x);
		}
        public void Sub(string x, string y)
        {
            double intOne = Parse(x);
            double intTwo = Parse(y);

            answer = intOne - intTwo;
        }
        public void Multiply(string x, string y)
        {
            double intOne = Parse(x);
            double intTwo = Parse(y);

            answer = intOne * intTwo;
        }
        public void Divide(string x, string y)
        {
            double intOne = Parse(x);
            double intTwo = Parse(y);

            answer = intOne / intTwo;
        }
        public void Mod(string x, string y)
        {
            double intOne = Parse(x);
            double intTwo = Parse(y);

            answer = intOne % intTwo;
        }
        public void Expontentiate(string x, string y)
        {
            double intOne = Parse(x);
            double intTwo = Parse(y);

            answer = Math.Pow(intOne, intTwo);
        }
		public void SquareRoot(string x)
		{
			double intOne = Parse(x);

			answer = Math.Sqrt(intOne);
        }
        public void Square(string x)
        {
			Expontentiate(x, "2");
        }
        public void Factorial(string x)
		{
			int total = 1;
			int intOne = (int) Parse(x);

			for (int i = intOne; i > 0; i--)
				total *= i;

			answer = total;
        }


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
		public void StoreVar(string name, string val)
		{
            // Regex from https://www.techiedelight.com/check-string-consists-alphanumeric-characters-csharp/

			if (name == name.ToLower() && Regex.IsMatch(name, "^[a-zA-Z]*$"))
                StoredVars[name] = int.Parse(val);
			else
				Console.WriteLine("Invalid Variable Name");
        }

		private double Parse(string input)
		{

			if (StoredVars.ContainsKey(input))
				return StoredVars[input];
			return int.Parse(input);
		}


		public void DisplayVars()
		{
			foreach (string key in StoredVars.Keys)
				Console.WriteLine($"{key} = {StoredVars[key]}");
		}
    }
}

