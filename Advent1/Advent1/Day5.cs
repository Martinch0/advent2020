using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent1
{
	class Day5
	{
		private string inputPath = "../../../../Input/Input5a.txt";

		private void ReadInputs(string file, ref List<string> tickets)
		{
			if (tickets == null)
			{
				tickets = new List<string>();
			}

			tickets.Clear();

			string[] lines = File.ReadAllLines(file);
			tickets.AddRange(lines);
		}

		private int GetID(string ticket)
		{
			int minRow = 0;
			int maxRow = 127;
			for(int i = 0; i < 7; ++i)
			{
				int mid = (minRow + maxRow) / 2;
				if(ticket[i] == 'F')
				{
					maxRow = mid;
				}
				else
				{
					minRow = mid + 1;
				}
			}

			int minCol = 0;
			int maxCol = 7;
			for (int i = 7; i < 10; ++i)
			{
				int mid = (minCol + maxCol) / 2;
				if (ticket[i] == 'L')
				{
					maxCol = mid;
				}
				else
				{
					minCol = mid + 1;
				}
			}

			int seatID = minRow * 8 + minCol;

			//Console.WriteLine($"all true: {minRow == maxRow && minCol == maxCol}; row: {minRow}; col: {minCol}; seatID: {seatID}");

			return seatID;
		}

		private int FindHighestID(ref List<string> tickets)
		{
			int maxID = -1;
			foreach(string t in tickets)
			{
				int id = GetID(t);
				if(id > maxID)
				{
					maxID = id;
				}
			}
			return maxID;
		}

		private int FindMissingID(ref List<string> tickets)
		{
			List<int> ids = new List<int>();

			foreach(string t in tickets)
			{
				ids.Add(GetID(t));
			}

			ids.Sort();

			for(int i = 1; i < ids.Count; ++i)
			{
				if(ids[i-1] != ids[i] - 1)
				{
					return ids[i] - 1;
				}
			}

			return 0;
		}

		public int Solve1()
		{
			List<string> tickets = new List<string>();
			ReadInputs(inputPath, ref tickets);

			int maxID = FindHighestID(ref tickets);

			return maxID;
		}

		public int Solve2()
		{
			List<string> tickets = new List<string>();
			ReadInputs(inputPath, ref tickets);

			int missingID = FindMissingID(ref tickets);

			return missingID;
		}
	}
}
