using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent1
{
	class Day15
	{
		private string inputPath = "../../../../Input/Input15a.txt";

		private void ReadInputs(string file, ref List<int> startNumbers)
		{
			if (startNumbers == null)
			{
				startNumbers = new List<int>();
			}

			startNumbers.Clear();

			string[] lines = File.ReadAllLines(file);
			foreach (string l in lines)
			{
				string[] numStrings = l.Split(',');
				foreach(string s in numStrings)
				{
					startNumbers.Add(int.Parse(s));
				}
			}
		}

		private int PlayGame(ref List<int> startNumbers, int turns)
		{
			int nextNumber = 0;
			int currentStep = 1;
			Dictionary<int, int> lastPos = new Dictionary<int, int>();

			for(int i = 0; i < startNumbers.Count; ++i)
			{
				if(lastPos.ContainsKey(startNumbers[i]))
				{
					lastPos[startNumbers[i]] = currentStep;
				}
				else
				{
					lastPos.Add(startNumbers[i], currentStep);
				}
				++currentStep;
			}

			for(; currentStep < turns; ++currentStep)
			{
				if(lastPos.ContainsKey(nextNumber))
				{
					int temp = nextNumber;
					nextNumber = currentStep - lastPos[nextNumber];
					lastPos[temp] = currentStep;
				}
				else
				{
					lastPos.Add(nextNumber, currentStep);
					nextNumber = 0;
				}
			}

			return nextNumber;
		}

		public int Solve1()
		{
			List<int> startNumbers = new List<int>();
			ReadInputs(inputPath, ref startNumbers);

			int result = PlayGame(ref startNumbers, 30000000);

			return result;
		}
	}
}
