using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent1
{
	class Day3
	{
		private string inputPath = "../../../../Input/Input3a.txt";

		private void ReadInputs(string file, ref List<string> map)
		{
			if (map == null)
			{
				map = new List<string>();
			}

			map.Clear();

			string[] lines = File.ReadAllLines(file);
			map.AddRange(lines);
		}

		private long WalkThrough(int stepX, int stepY, ref List<string> map)
		{
			int x = 0;
			int y = 0;

			long trees = 0;

			while(y + stepY < map.Count)
			{
				y += stepY;
				x = (x + stepX) % map[0].Length;

				if(map[y][x] == '#')
				{
					++trees;
				}
			}

			return trees;
		}

		public long Solve1()
		{
			List<string> map = new List<string>();

			ReadInputs(inputPath, ref map);

			return WalkThrough(3, 1, ref map);
		}

		public long Solve2()
		{
			List<string> map = new List<string>();

			ReadInputs(inputPath, ref map);

			long res1 = WalkThrough(1, 1, ref map);
			long res2 = WalkThrough(3, 1, ref map);
			long res3 = WalkThrough(5, 1, ref map);
			long res4 = WalkThrough(7, 1, ref map);
			long res5 = WalkThrough(1, 2, ref map);

			return res1 * res2 * res3 * res4 * res5;
		}
	}
}
