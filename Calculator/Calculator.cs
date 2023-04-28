
///////////////////////////////////////////////////////////////////////////////
//
// Author: Phillip Edwards, edwardspb1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Calculator Project 7
// Description: Class that provides calculator functionality.
//
///////////////////////////////////////////////////////////////////////////////


using System;
using System.Text.RegularExpressions;

namespace Calculator
{
	public class Calculator
	{

		// TODO:
		// Bonuses:
		// Reverse polish notation
		// nth Fib number where n is the value in calculator's current state


		private Stack<double> answers = new Stack<double>();

		public double answer { get => answers.Count() == 0 ? 0 : answers.Peek(); set { answers.Push(value); } }

		public Dictionary<string, double> StoredVars = new();

		/// <summary>
		/// Adds two numbers together
		/// </summary>
		/// <param name="x"> first number </param>
		/// <param name="y"> second number </param>
		public void Add(string x, string y)
		{
			double intOne = Parse(x);
            double intTwo = Parse(y);

			answer = intOne + intTwo;
		}

		/// <summary>
		/// Undoes the last calculation
		/// </summary>
		public void Undo()
		{
			double x;
			answers.TryPop(out x);
		}

		/// <summary>
		/// Subtracts two numbers
		/// </summary>
		/// <param name="x"> first number </param>
		/// <param name="y"> second number </param>
        public void Sub(string x, string y)
        {
            double intOne = Parse(x);
            double intTwo = Parse(y);

            answer = intOne - intTwo;
        }

        /// <summary>
        /// Multiplies two numbers
        /// </summary>
        /// <param name="x"> first number </param>
        /// <param name="y"> second number </param>
        public void Multiply(string x, string y)
        {
            double intOne = Parse(x);
            double intTwo = Parse(y);

            answer = intOne * intTwo;
        }

        /// <summary>
        /// Divides two numbers
        /// </summary>
        /// <param name="x"> first number </param>
        /// <param name="y"> second number </param>
        public void Divide(string x, string y)
        {
            double intOne = Parse(x);
            double intTwo = Parse(y);

            answer = intOne / intTwo;
        }

        /// <summary>
        /// Finds remainder of two numbers when divided
        /// </summary>
        /// <param name="x"> first number </param>
        /// <param name="y"> second number </param>
        public void Mod(string x, string y)
        {
            double intOne = Parse(x);
            double intTwo = Parse(y);

            answer = intOne % intTwo;
        }

        /// <summary>
        /// Finds number put to the power of another
        /// </summary>
        /// <param name="x"> first number </param>
        /// <param name="y"> second number </param>
        public void Expontentiate(string x, string y)
        {
            double intOne = Parse(x);
            double intTwo = Parse(y);

            answer = Math.Pow(intOne, intTwo);
        }

		/// <summary>
		/// Finds square root of number
		/// </summary>
		/// <param name="x"> the number </param>
		public void SquareRoot(string x)
		{
			double intOne = Parse(x);

			answer = Math.Sqrt(intOne);
        }

		/// <summary>
		/// Finds square of number
		/// </summary>
		/// <param name="x"> the number </param>
        public void Square(string x)
        {
			Expontentiate(x, "2");
        }

		/// <summary>
		/// Finds the factorial of a number
		/// </summary>
		/// <param name="x"> the number </param>
        public void Factorial(string x)
		{
			double total = 1;
			double intOne = (double) Parse(x);
			if (Double.IsInfinity(intOne))
			{
                answer = intOne;
				return;
            }
				
			for (double i = intOne; i > 0; i--)
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

		/// <summary>
		/// Parses input safetly and switches out for variables when needed
		/// </summary>
		/// <param name="input"> input to parse</param>
		/// <returns> value that came out of parse </returns>
		private double Parse(string input)
		{

			double returnVal = 0;
			if (StoredVars.ContainsKey(input))
				return StoredVars[input];
			bool tmpBool = double.TryParse(input, out returnVal);
			if (tmpBool != true)
			{
				throw new ArgumentException();
			}
			else
				return returnVal;
		}

		/// <summary>
		/// Displays the variables stored in the calculator
		/// </summary>
		public void DisplayVars()
		{
			foreach (string key in StoredVars.Keys)
				Console.WriteLine($"{key} = {StoredVars[key]}");
		}

    }
}

