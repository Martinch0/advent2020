using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent1
{
	class Day11
	{
		private string inputPath = "../../../../Input/Input11a.txt";

		private void ReadInputs(string file, ref List<string> seats)
		{
			if (seats == null)
			{
				seats = new List<string>();
			}

			seats.Clear();

			string[] lines = File.ReadAllLines(file);
			foreach (string line in lines)
			{
				seats.Add(line);
			}
		}

		private int CountNearbyOccupied(ref List<string> seats, int x, int y)
		{
			int result = 0;

			(int, int)[] positions = new (int, int)[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };

			foreach((int i, int j) in positions)
			{
				int newX = x + i;
				int newY = y + j;
				if(newX >= 0 && newY >= 0 && newX < seats.Count && newY < seats[0].Length)
				{
					if(seats[newX][newY] == '#')
					{
						++result;
					}
				}
			}

			return result;
		}

		private bool Stabilize(ref List<string> seats)
		{
			List<string> newSeats = new List<string>(seats);

			bool modified = false;

			for(int x = 0; x < seats.Count; ++x)
			{
				for(int y = 0; y < seats[0].Length; ++y)
				{
					int nearbyOcc = CountNearbyOccupied(ref seats, x, y);
					if(seats[x][y] == 'L' && nearbyOcc == 0)
					{
						newSeats[x] = newSeats[x].Remove(y, 1).Insert(y, "#");
						modified = true;
					}
					else if(seats[x][y] == '#' && nearbyOcc >= 4)
					{
						newSeats[x] = newSeats[x].Remove(y, 1).Insert(y, "L");
						modified = true;
					}
				}
			}

			seats = newSeats;

			return modified;
		}

		private int CountPeople(ref List<string> seats)
		{
			int people = 0;

			for (int x = 0; x < seats.Count; ++x)
			{
				for (int y = 0; y < seats[0].Length; ++y)
				{
					if(seats[x][y] == '#')
					{
						++people;
					}
				}
			}

			return people;
		}

		private bool Stabilize2(ref List<string> seats)
		{
			List<string> newSeats = new List<string>(seats);

			bool modified = false;

			for (int x = 0; x < seats.Count; ++x)
			{
				for (int y = 0; y < seats[0].Length; ++y)
				{
					int nearbyOcc = CountNearbyOccupied2(ref seats, x, y);
					if (seats[x][y] == 'L' && nearbyOcc == 0)
					{
						newSeats[x] = newSeats[x].Remove(y, 1).Insert(y, "#");
						modified = true;
					}
					else if (seats[x][y] == '#' && nearbyOcc >= 5)
					{
						newSeats[x] = newSeats[x].Remove(y, 1).Insert(y, "L");
						modified = true;
					}
				}
			}

			seats = newSeats;

			return modified;
		}

		private int CountNearbyOccupied2(ref List<string> seats, int x, int y)
		{
			int result = 0;

			(int, int)[] positions = new (int, int)[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };

			foreach ((int i, int j) in positions)
			{
				int newX = x + i;
				int newY = y + j;
				while (newX >= 0 && newY >= 0 && newX < seats.Count && newY < seats[0].Length)
				{
					if (seats[newX][newY] == '#')
					{
						++result;
						break;
					}
					if (seats[newX][newY] == 'L')
					{
						break;
					}
					newX = newX + i;
					newY = newY + j;
				}
			}

			return result;
		}

		public int Solve1()
		{
			List<string> seats = new List<string>();
			ReadInputs(inputPath, ref seats);

			while (Stabilize(ref seats));

			int numberOfPeople = CountPeople(ref seats);

			return numberOfPeople;
		}

		public int Solve2()
		{
			List<string> seats = new List<string>();
			ReadInputs(inputPath, ref seats);

			while (Stabilize2(ref seats)) ;

			int numberOfPeople = CountPeople(ref seats);

			return numberOfPeople;
		}
	}
}
