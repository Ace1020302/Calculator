
///////////////////////////////////////////////////////////////////////////////
//
// Author: Phillip Edwards, edwardspb1@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Calculator Project 7
// Description: Class that provides file creation and reading options for the calculator.
//
///////////////////////////////////////////////////////////////////////////////

using System;
using YamlDotNet.Serialization;

namespace Calculator
{
	public class FileManager
	{
        static string fileName = "LastCalculatorState.yaml";
        static string filePath = $"../../{fileName}";

		/// <summary>
		/// Saves the current calculator state (only the most recent answer is saved)
		/// </summary>
		/// <param name="calc"> Calculator object to save the state of </param>
        public static void saveCalcState(Calculator calc)
		{
            // repurposed code from https://stackoverflow.com/questions/73786590/serializing-a-c-sharp-object-in-yaml for yaml translation
            var serializer = new SerializerBuilder().Build();
			var yaml = serializer.Serialize(calc.answer);
            yaml += serializer.Serialize(calc.StoredVars);

			File.WriteAllText(filePath, yaml);
			Console.WriteLine("State Saved!");
		}

		/// <summary>
		/// Loads the calculator's state into the calculator object
		/// </summary>
		/// <param name="calc"> Calculator object to load the state into </param>
		public static void loadCalcState(Calculator calc)
		{
			string[] lines = File.ReadAllText(filePath).Split("\n");
			calc.answer = Double.Parse(lines[0]);
			
			Dictionary<string, double> dictonaryToLoad = new();
			for(int i = 1; i < lines.Length-1; i++)
			{
				string[] arr = lines[i].Split(':');
				dictonaryToLoad[arr[0]] = Double.Parse(arr[1]);
			}

			calc.StoredVars = dictonaryToLoad;
			Console.WriteLine("State Loaded!");
		}
	}
}

