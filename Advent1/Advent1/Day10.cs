using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent1
{
	class Day10
	{
		private string inputPath = "../../../../Input/Input10a.txt";

		private void ReadInputs(string file, ref List<int> adapters)
		{
			if (adapters == null)
			{
				adapters = new List<int>();
			}

			adapters.Clear();

			string[] lines = File.ReadAllLines(file);
			foreach (string line in lines)
			{
				int number = int.Parse(line);
				adapters.Add(number);
			}
		}

		private void FindDifferences(ref List<int> adapters, ref int[] diff)
		{
			adapters.Sort();

			int prevJolt = 0;

			for(int i = 0; i < adapters.Count; ++i)
			{
				int d = adapters[i] - prevJolt;
				if(d <= 3)
				{
					++diff[d - 1];
				}

				prevJolt = adapters[i];
			}
		}

		private long FindCombinations(List<int> adapters)
		{
			adapters.Add(0);
			adapters.Sort();
			adapters.Add(adapters[adapters.Count - 1] + 3);

			long[] comboList = new long[adapters.Count];
			comboList[adapters.Count - 1] = 1;

			for(int i = adapters.Count - 2; i >= 0; --i)
			{
				int j = i + 1;
				long combos = comboList[j];
				while(j + 1 < adapters.Count && adapters[j + 1] - adapters[i] <= 3)
				{
					++j;
					combos += comboList[j];
				}

				comboList[i] = combos;
			}

			return comboList[0];
		}

		public long Solve1()
		{
			List<int> adapters = new List<int>();
			ReadInputs(inputPath, ref adapters);

			int[] diff = new int[] { 0, 0, 1 };

			FindDifferences(ref adapters, ref diff);

			return diff[0] * diff[2];
		}

		public long Solve2()
		{
			List<int> adapters = new List<int>();
			ReadInputs(inputPath, ref adapters);

			long combos = FindCombinations(adapters);

			return combos;
		}
	}
}
