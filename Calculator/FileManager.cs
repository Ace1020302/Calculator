using System;
using YamlDotNet.Serialization;

namespace Calculator
{
	public class FileManager
	{
        static string fileName = "LastCalculatorState.yaml";
        static string filePath = $"../../{fileName}";

        public static void saveCalcState(Calculator calc)
		{
			
			var serializer = new SerializerBuilder().Build();
			var yaml = serializer.Serialize(calc.answer);
            yaml += serializer.Serialize(calc.StoredVars);
			//Console.WriteLine(yaml);

            

			//File.Create(filePath);
			File.WriteAllText(filePath, yaml);
			
		}

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
		}
	}
}

