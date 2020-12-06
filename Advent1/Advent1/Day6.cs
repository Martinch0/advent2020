using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent1
{
	class Day6
	{
		private string inputPath = "../../../../Input/Input6a.txt";

		private void ReadInputs(string file, ref List<Dictionary<char, int>> forms)
		{
			if (forms == null)
			{
				forms = new List<Dictionary<char, int>>();
			}

			forms.Clear();

			string[] lines = File.ReadAllLines(file);

			Dictionary<char, int> currentEntry = new Dictionary<char, int>();

			foreach (string l in lines)
			{
				if (l == "")
				{
					forms.Add(currentEntry);
					currentEntry = new Dictionary<char, int>();

					continue;
				}

				if (!currentEntry.ContainsKey('-'))
				{
					currentEntry.Add('-', 1);
				}
				else
				{
					++currentEntry['-'];
				}

				foreach (char entry in l)
				{
					if (!currentEntry.ContainsKey(entry))
					{
						currentEntry.Add(entry, 1);
					}
					else
					{
						++currentEntry[entry];
					}
				}
			}

			forms.Add(currentEntry);
		}

		private int CountGroups(ref List<Dictionary<char, int>> forms)
		{
			int sum = 0;
			foreach (Dictionary<char, int> form in forms)
			{
				sum += form.Count - 1;
			}

			return sum;
		}

		private int CountGroups2(ref List<Dictionary<char, int>> forms)
		{
			int sum = 0;

			foreach (Dictionary<char, int> form in forms)
			{
				foreach(char k in form.Keys)
				{
					if(k == '-')
					{
						continue;
					}
					else
					{
						if(form[k] == form['-'])
						{
							++sum;
						}
					}
				}
			}

			return sum;
		}

		public int Solve1()
		{
			List<Dictionary<char, int>> forms = new List<Dictionary<char, int>>();
			ReadInputs(inputPath, ref forms);

			int countGroups = CountGroups(ref forms);
			return countGroups;
		}

		public int Solve2()
		{
			List<Dictionary<char, int>> forms = new List<Dictionary<char, int>>();
			ReadInputs(inputPath, ref forms);

			int countGroups = CountGroups2(ref forms);
			return countGroups;
		}
	}
}
