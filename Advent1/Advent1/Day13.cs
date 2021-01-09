using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent1
{
	class Day13
	{
		private string inputPath = "../../../../Input/Input13a.txt";

		private void ReadInputs(string file, ref List<string> buses)
		{
			if (buses == null)
			{
				buses = new List<string>();
			}

			buses.Clear();

			string[] lines = File.ReadAllLines(file);
			buses.Add(lines[0]);
			string[] ids = lines[1].Split(',');
			buses.AddRange(ids);
		}

		private int FindEarliest(ref List<string> buses)
		{
			int arrival = int.Parse(buses[0]);
			int nearestBusId = 0;
			int nearestBusTime = 0;

			for(int i = 1; i < buses.Count; ++i)
			{
				if(buses[i] == "x")
				{
					continue;
				}

				int busId = int.Parse(buses[i]);
				int nextArrival = busId * (arrival / busId + 1);
				if (nearestBusId == 0 || (nearestBusTime - arrival > nextArrival - arrival))
				{
					nearestBusId = busId;
					nearestBusTime = nextArrival;
				}
			}

			return (nearestBusTime - arrival) * nearestBusId;
		}

		private bool CheckIsValid(ref int[] buses, long num)
		{
			for(int i = 0; i < buses.Length; ++i)
			{
				if(buses[i] == 0)
				{
					continue;
				}

				if((num + i) % buses[i] != 0)
				{
					return false;
				}
			}

			return true;
		}

		private long BruteForceFind(ref List<string> buses)
		{
			int[] numbers = new int[buses.Count - 1];
			for(int i = 1; i < buses.Count; ++i)
			{
				if(buses[i] == "x")
				{
					numbers[i - 1] = 0;
				}
				else
				{
					numbers[i - 1] = int.Parse(buses[i]);
				}
			}

			int arrival = int.Parse(buses[0]);

			long start = numbers[0] * (arrival / numbers[0] + 1);
			long step = numbers[0];
			for (int i = 1; i < numbers.Length;)
			{
				if (numbers[i] == 0)
				{
					++i;
					continue;
				}

				if ((start + i) % numbers[i] == 0)
				{
					step *= numbers[i];
					++i;
				}
				else
				{
					start += step;
				}
			}

			return start;
		}

		public int Solve1()
		{
			List<string> buses = new List<string>();
			ReadInputs(inputPath, ref buses);

			int earliest = FindEarliest(ref buses);

			return earliest;
		}

		public long Solve2()
		{
			List<string> buses = new List<string>();
			ReadInputs(inputPath, ref buses);

			long result = BruteForceFind(ref buses);

			return result;
		}
	}
}
