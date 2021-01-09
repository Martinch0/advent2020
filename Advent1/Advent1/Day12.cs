using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent1
{
	class Day12
	{
		private string inputPath = "../../../../Input/Input12a.txt";

		private void ReadInputs(string file, ref List<string> commands)
		{
			if (commands == null)
			{
				commands = new List<string>();
			}

			commands.Clear();

			string[] lines = File.ReadAllLines(file);
			foreach (string line in lines)
			{
				commands.Add(line);
			}
		}

		private int FollowInstructions(ref List<string> commands)
		{
			(int, int)[] directions = new (int, int)[] { (1, 0), (0, -1), (-1, 0), (0, 1) };
			int x = 0;
			int y = 0;
			int d = 0;

			foreach(string s in commands)
			{
				int units = int.Parse(s.Substring(1));
				int i, j;
				switch (s[0])
				{
					case 'F':
						(i, j) = directions[d];
						x += i * units;
						y += j * units;
						break;
					case 'R':
						d = (d + (units / 90)) % 4;
						break;
					case 'L':
						d = d - (units / 90);
						if(d < 0)
						{
							d += 4;
						}
						break;
					case 'N':
						(i, j) = directions[3];
						x += i * units;
						y += j * units;
						break;
					case 'S':
						(i, j) = directions[1];
						x += i * units;
						y += j * units;
						break;
					case 'E':
						(i, j) = directions[0];
						x += i * units;
						y += j * units;
						break;
					case 'W':
						(i, j) = directions[2];
						x += i * units;
						y += j * units;
						break;
					default:
						break;
				}
			}

			return Math.Abs(x) + Math.Abs(y);
		}

		private int FollowInstructions2(ref List<string> commands)
		{
			(int, int)[] directions = new (int, int)[] { (1, 0), (0, -1), (-1, 0), (0, 1) };
			int x = 10;
			int y = 1;
			int d = 0;

			int posX = 0;
			int posY = 0;

			foreach (string s in commands)
			{
				int units = int.Parse(s.Substring(1));
				int i, j;
				switch (s[0])
				{
					case 'F':
						posX += x * units;
						posY += y * units;
						break;
					case 'R':
						while(units > 0)
						{
							int temp = x;
							x = y;
							y = temp;
							y *= -1;
							units -= 90;
						}
						break;
					case 'L':
						while (units > 0)
						{
							int temp = x;
							x = y;
							y = temp;
							x *= -1;
							units -= 90;
						}
						break;
					case 'N':
						(i, j) = directions[3];
						x += i * units;
						y += j * units;
						break;
					case 'S':
						(i, j) = directions[1];
						x += i * units;
						y += j * units;
						break;
					case 'E':
						(i, j) = directions[0];
						x += i * units;
						y += j * units;
						break;
					case 'W':
						(i, j) = directions[2];
						x += i * units;
						y += j * units;
						break;
					default:
						break;
				}
			}

			return Math.Abs(posX) + Math.Abs(posY);
		}

		public int Solve1()
		{
			List<string> commands = new List<string>();
			ReadInputs(inputPath, ref commands);

			int manDist = FollowInstructions(ref commands);
			return manDist;
		}

		public int Solve2()
		{
			List<string> commands = new List<string>();
			ReadInputs(inputPath, ref commands);

			int manDist = FollowInstructions2(ref commands);
			return manDist;
		}
	}
}
