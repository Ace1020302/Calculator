using System;
namespace Calculator
{
	public class CalculatorAction
	{
		string description;

		dynamic action;

		public CalculatorAction(string description="Undocumented", dynamic action = null)
		{
			this.description = description;
			this.action = action;
		}
	}
}

