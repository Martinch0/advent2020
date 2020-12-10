using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent1
{
	class Day8
	{
		private string inputPath = "../../../../Input/Input8a.txt";

		private void ReadInputs(string file, ref List<(string, int)> instructions)
		{
			if (instructions == null)
			{
				instructions = new List<(string, int)>();
			}

			instructions.Clear();

			string[] lines = File.ReadAllLines(file);
			foreach(string line in lines)
			{
				string[] split = line.Split(' ');
				int number = int.Parse(split[1]);
				instructions.Add((split[0], number));
			}
		}

		private void ExecuteCommand(string command, int value, ref int pointer, ref int acc)
		{
			switch(command)
			{
				case "acc":
					acc += value;
					++pointer;
					break;
				case "jmp":
					pointer += value;
					break;
				case "nop":
				default:
					++pointer;
					break;
			}
		}

		private bool ExecuteUntilLoop(ref List<(string, int)> instructions, ref int acc)
		{
			HashSet<int> visited = new HashSet<int>();

			int currentPointer = 0;

			while(!visited.Contains(currentPointer) && currentPointer < instructions.Count)
			{
				visited.Add(currentPointer);
				ExecuteCommand(instructions[currentPointer].Item1, instructions[currentPointer].Item2, ref currentPointer, ref acc);
			}

			return currentPointer == instructions.Count;
		}

		private int FindNonLoopingResult(ref List<(string, int)> instructions)
		{
			for(int i = 0; i < instructions.Count; ++i)
			{
				if(instructions[i].Item1 == "jmp" || instructions[i].Item1 == "nop")
				{
					string origInstr = instructions[i].Item1;
					int acc = 0;
					bool success = false;

					instructions[i] = ("jmp", instructions[i].Item2);
					success = ExecuteUntilLoop(ref instructions, ref acc);
					if(success)
					{
						Console.WriteLine($"Found a nonloop by modifying: {i} into jmp");
						instructions[i] = (origInstr, instructions[i].Item2);
						return acc;
					}


					instructions[i] = ("nop", instructions[i].Item2);
					acc = 0;
					success = ExecuteUntilLoop(ref instructions, ref acc);
					if (success)
					{
						Console.WriteLine($"Found a nonloop by modifying: {i} into nop");
						instructions[i] = (origInstr, instructions[i].Item2);
						return acc;
					}

					instructions[i] = (origInstr, instructions[i].Item2);
				}
			}

			return 0;
		}

		public int Solve1()
		{
			List<(string, int)> instructions = new List<(string, int)>();
			ReadInputs(inputPath, ref instructions);

			int acc = 0;

			ExecuteUntilLoop(ref instructions, ref acc);

			return acc;
		}

		public int Solve2()
		{
			List<(string, int)> instructions = new List<(string, int)>();
			ReadInputs(inputPath, ref instructions);

			int acc = FindNonLoopingResult(ref instructions);

			return acc;
		}
	}
}
