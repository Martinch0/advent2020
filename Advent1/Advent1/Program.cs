using System;
using System.Collections.Generic;
using System.IO;

namespace Advent1
{
	class Program
	{
		static void Main(string[] args)
		{
			//Day1 day1 = new Day1();

			//Console.WriteLine($"TwoNumbers: {day1.SolveTwoNumbers()}");
			//Console.WriteLine($"ThreeNumbers: {day1.SolveThreeNumbers()}");

			Day2 day2 = new Day2();

			Console.WriteLine($"Valid Passwords: {day2.Solve1()}");
			Console.WriteLine($"Valid Passwords: {day2.Solve2()}");

			// Wait for keypress
			Console.ReadKey();
		}
	}
}
