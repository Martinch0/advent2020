using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent1
{
	class Day1
	{
		private string inputPath = "../../../../Input/Input1a.txt";

		private void ReadInputs(string file, ref List<int> numbers)
		{
			if (numbers == null)
			{
				numbers = new List<int>();
			}

			numbers.Clear();

			string[] lines = File.ReadAllLines(file);

			foreach (string n in lines)
			{
				int number = int.Parse(n);
				numbers.Add(number);
			}
		}

		public int SolveTwoNumbers()
		{
			List<int> numbers = new List<int>();

			ReadInputs(inputPath, ref numbers);

			for (int i = 0; i < numbers.Count; ++i)
			{
				int remaining = 2020 - numbers[i];
				for (int j = i + 1; j < numbers.Count; ++j)
				{
					if (remaining == numbers[j])
					{
						//Console.WriteLine($"Found numbers: {numbers[i]} and {numbers[j]}; multiplication = {numbers[i] * numbers[j]}");
						return numbers[i] * numbers[j];
					}
				}
			}

			return -1;
		}

		public int SolveThreeNumbers()
		{
			List<int> numbers = new List<int>();

			ReadInputs(inputPath, ref numbers);

			for (int i = 0; i < numbers.Count; ++i)
			{
				int remaining = 2020 - numbers[i];
				for (int j = i + 1; j < numbers.Count; ++j)
				{
					int rem = remaining - numbers[j];
					for (int p = j + 1; p < numbers.Count; ++p)
					{
						if (rem == numbers[p])
						{
							Console.WriteLine($"Found numbers: {numbers[i]} and {numbers[j]} and {numbers[p]}; multiplication = {numbers[i] * numbers[j] * numbers[p]}");
							return numbers[i] * numbers[j] * numbers[p];
						}
					}
				}
			}

			return -1;
		}
	}
}
