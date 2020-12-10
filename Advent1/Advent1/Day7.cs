using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent1
{
	class Day7
	{
		private string inputPath = "../../../../Input/Input7a.txt";

		private void ReadInputs(string file, ref Dictionary<string, Dictionary<string, int>> bags)
		{
			if (bags == null)
			{
				bags = new Dictionary<string, Dictionary<string, int>>();
			}

			bags.Clear();

			string[] lines = File.ReadAllLines(file);

			foreach (string l in lines)
			{
				Dictionary<string, int> currentEntry = new Dictionary<string, int>();

				string[] parsedEntry = l.Split(" contain ");

				string key = parsedEntry[0].Replace(" bags", "");

				string[] containedBags = parsedEntry[1].Split(", ");

				foreach(string innerBag in containedBags)
				{
					if(!char.IsDigit(innerBag[0]))
					{
						continue;
					}

					string[] parsedInner = innerBag.Trim().Split(' ');
					currentEntry.Add(parsedInner[1] + " " + parsedInner[2], int.Parse(parsedInner[0]));
				}

				bags.Add(key, currentEntry);
			}
		}

		private int CountGoldBagContainers(ref Dictionary<string, Dictionary<string, int>> bags)
		{
			string goldBag = "shiny gold";

			Dictionary<string, HashSet<string>> bagMap = new Dictionary<string, HashSet<string>>();

			foreach(string bagKey in bags.Keys)
			{
				foreach(string innerBag in bags[bagKey].Keys)
				{
					if(!bagMap.ContainsKey(innerBag))
					{
						bagMap.Add(innerBag, new HashSet<string>());
					}

					if(!bagMap[innerBag].Contains(bagKey))
					{
						bagMap[innerBag].Add(bagKey);
					}
				}
			}

			HashSet<string> alreadyChecked = new HashSet<string>();
			Queue<string> toCheck = new Queue<string>();
			toCheck.Enqueue(goldBag);

			while(toCheck.Count > 0)
			{
				string next = toCheck.Dequeue();
				alreadyChecked.Add(next);
				if(bagMap.ContainsKey(next))
				{
					foreach (string bagsToCheck in bagMap[next])
					{
						if (!alreadyChecked.Contains(bagsToCheck))
						{
							toCheck.Enqueue(bagsToCheck);
						}
					}
				}
			}

			return alreadyChecked.Count - 1;
		}

		private int CountInsideBags(ref Dictionary<string, Dictionary<string, int>> bags, string currentBag)
		{
			int additionalBags = 0;

			foreach(string key in bags[currentBag].Keys)
			{
				additionalBags += bags[currentBag][key] * CountInsideBags(ref bags, key);
			}

			return 1 + additionalBags;
		}

		public int Solve1()
		{
			Dictionary<string, Dictionary<string, int>> bags = new Dictionary<string, Dictionary<string, int>>();
			ReadInputs(inputPath, ref bags);

			int result = CountGoldBagContainers(ref bags);

			return result;
		}

		public long Solve2()
		{
			Dictionary<string, Dictionary<string, int>> bags = new Dictionary<string, Dictionary<string, int>>();
			ReadInputs(inputPath, ref bags);

			string goldBag = "shiny gold";
			int result = CountInsideBags(ref bags, goldBag) - 1;

			return result;
		}
	}
}
