using System;
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


		// Stores state
		public Calculator()
		{
			
		}

        public int Add(int x, int y) => x + y;
        public int Sub(int x, int y) => x - y;
        public int Multiply(int x, int y) => x * y;
        public int Divide(int x, int y) => x / y;
        public int Mod(int x, int y) => x % y;
        public int Expontentiate(int x, int y) => x ^ y;
        //public int Root(int x, int y) => Expontentiate(x, 1 / y);
        //public int Factorial(int x) => x!;
    }
}

