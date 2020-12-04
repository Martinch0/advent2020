using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Advent1
{
	class Day4
	{
		private string inputPath = "../../../../Input/Input4a.txt";

		private int CountValidPassports(ref List<Dictionary<string, string>> passports, ref string[] requiredFields, ref Regex[] validationRegex)
		{
			int validPassports = 0;

			foreach (Dictionary<string, string> passport in passports)
			{
				bool isValid = true;

				for (int i = 0; i < requiredFields.Length; ++i)
				{
					string field = requiredFields[i];
					if (!passport.ContainsKey(field)
						|| (i < validationRegex.Length && !validationRegex[i].IsMatch(passport[field])))
					{
						isValid = false;
						break;
					}
				}

				if (isValid)
				{
					++validPassports;
				}
			}

			return validPassports;
		}

		private void ReadInputs(string file, ref List<Dictionary<string, string>> passports)
		{
			if (passports == null)
			{
				passports = new List<Dictionary<string, string>>();
			}

			passports.Clear();

			string[] lines = File.ReadAllLines(file);

			Dictionary<string, string> currentEntry = new Dictionary<string, string>();

			foreach (string l in lines)
			{
				if (l == "")
				{
					passports.Add(currentEntry);
					currentEntry = new Dictionary<string, string>();
					continue;
				}

				string[] entries = l.Split(' ');
				foreach(string entry in entries)
				{
					string[] curEntry = entry.Split(':');
					if(!currentEntry.ContainsKey(curEntry[0]))
					{
						currentEntry.Add(curEntry[0], curEntry[1]);
					}
				}
			}

			passports.Add(currentEntry);
		}

		public int Solve1()
		{
			List<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();
			ReadInputs(inputPath, ref passports);

			string[] requiredFields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
			Regex[] validationRegex = { };

			int validPassports = CountValidPassports(ref passports, ref requiredFields, ref validationRegex);
			return validPassports;
		}

		public int Solve2()
		{
			List<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();
			ReadInputs(inputPath, ref passports);

			string[] requiredFields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
			Regex[] validationRegex = { new Regex(@"^19[2-9]\d$|^200[0-2]$") // byr between 1920 and 2002
										, new Regex(@"^201\d$|^2020$") // iyr between 2010 and 2020
										, new Regex(@"^202\d$|^2030$") // eyr between 2020 and 2030
										, new Regex(@"^1[5-8]\dcm$|^19[0-3]cm$|^59in$|^6\din$|^7[0-6]in$") // hgt between 150cm and 193cm or 59in and 76in
										, new Regex(@"^#[0-9a-f]{6}$") // hcl a hex color
										, new Regex(@"^amb$|^blu$|^brn$|^gry$|^grn$|^hzl$|^oth$") // ecl is exactly one of: amb blu brn gry grn hzl oth
										, new Regex(@"^[0-9]{9}$") // pid is 9 digits
										};

			int validPassports = CountValidPassports(ref passports, ref requiredFields, ref validationRegex);

			return validPassports;
		}
	}
}
