using System;
using System.Collections.Generic;
using System.IO;

namespace Advent1
{
	class Program
	{
		static void Main(string[] args)
		{
			Day1 day1 = new Day1();

			Console.WriteLine($"TwoNumbers: {day1.SolveTwoNumbers()}");
			Console.WriteLine($"ThreeNumbers: {day1.SolveThreeNumbers()}");

			// Wait for keypress
			Console.ReadKey();
		}
	}
}
