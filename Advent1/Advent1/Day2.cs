using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent1
{
	class Day2
	{
		private string inputPath = "../../../../Input/Input2a.txt";

		private bool VerifyPassword1(int minOccurance, int maxOccurance, char letter, string password)
		{
			int occurances = 0;

			for (int i = 0; i < password.Length; ++i)
			{
				if (password[i] == letter)
				{
					++occurances;
				}
			}

			return minOccurance <= occurances && occurances <= maxOccurance;
		}

		private bool VerifyPassword2(int firstIndex, int secondIndex, char letter, string password)
		{
			return password[firstIndex - 1] == letter ^ password[secondIndex - 1] == letter;
		}

		private int ReadInputs(string file, Func<int, int, char, string, bool> VerifyPassword)
		{
			string[] lines = File.ReadAllLines(file);

			int validPasswords = 0;

			foreach (string line in lines)
			{
				string[] substrings = line.Split(' ');
				string[] occstrings = substrings[0].Split('-');

				int minOcc = int.Parse(occstrings[0]);
				int maxOcc = int.Parse(occstrings[1]);

				char letter = substrings[1][0];

				string password = substrings[2];

				bool valid = VerifyPassword(minOcc, maxOcc, letter, password);

				//Console.WriteLine($"Min: {minOcc}; Max: {maxOcc}; Letter: {letter}; Password: {password}; Valid: {valid}");

				if (valid)
				{
					++validPasswords;
				}
				else
				{
					Console.WriteLine($"Min: {minOcc}; Max: {maxOcc}; Letter: {letter}; Password: {password}; Valid: {valid}");
				}
			}

			return validPasswords;
		}

		public int Solve1()
		{
			return ReadInputs(inputPath, VerifyPassword1);
		}

		public int Solve2()
		{
			return ReadInputs(inputPath, VerifyPassword2);
		}
	}
}
