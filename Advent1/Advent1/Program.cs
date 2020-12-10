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

			//Day2 day2 = new Day2();

			//Console.WriteLine($"Valid Passwords: {day2.Solve1()}");
			//Console.WriteLine($"Valid Passwords: {day2.Solve2()}");

			//Day3 day3 = new Day3();

			//Console.WriteLine($"Trees: {day3.Solve1()}");
			//Console.WriteLine($"Trees: {day3.Solve2()}");

			//Day4 day4 = new Day4();

			//Console.WriteLine($"ValidPassports: {day4.Solve1()}");
			//Console.WriteLine($"ValidPassports2: {day4.Solve2()}");

			//Day5 day5 = new Day5();

			//Console.WriteLine($"MaxID: {day5.Solve1()}");
			//Console.WriteLine($"MissingID: {day5.Solve2()}");

			//Day6 day6 = new Day6();

			//Console.WriteLine($"GroupCount: {day6.Solve1()}");
			//Console.WriteLine($"GroupCount2: {day6.Solve2()}");

			//Day7 day7 = new Day7();

			//Console.WriteLine($"GoldBagContainers: {day7.Solve1()}");
			//Console.WriteLine($"GoldBags Contain: {day7.Solve2()}");

			//Day8 day8 = new Day8();

			//Console.WriteLine($"LastValueBeforeLoop: {day8.Solve1()}");
			//Console.WriteLine($"LastValueFixed: {day8.Solve2()}");

			//Day9 day9 = new Day9();

			//Console.WriteLine($"FirstMistake: {day9.Solve1()}");
			//Console.WriteLine($"Weakness: {day9.Solve2()}");

			Day10 day10 = new Day10();

			Console.WriteLine($"1jolt*3jolt: {day10.Solve1()}");
			Console.WriteLine($"Combos: {day10.Solve2()}");

			// Wait for keypress
			Console.ReadKey();
		}
	}
}
