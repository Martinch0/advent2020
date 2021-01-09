using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent1
{
	class Day14
	{
		private string inputPath = "../../../../Input/Input14a.txt";

		private void ReadInputs(string file, ref List<(long, string)> commands)
		{
			if (commands == null)
			{
				commands = new List<(long, string)>();
			}

			commands.Clear();

			string[] lines = File.ReadAllLines(file);
			foreach(string l in lines)
			{
				string[] com = l.Split('=');
				long command = 0;
				if(com[0].Trim() == "mask")
				{
					command = -1;
				}
				else
				{
					int left = com[0].IndexOf('[');
					int right = com[0].IndexOf(']');
					command = long.Parse(com[0].Substring(left + 1, right - left - 1));
				}

				commands.Add((command, com[1].Trim()));
			}
		}

		private long ProcessCommands(ref List<(long, string)> commands)
		{
			long andMask = long.MaxValue;
			long orMask = 0;

			Dictionary<long, long> memory = new Dictionary<long, long>();

			foreach((long com, string s) in commands)
			{
				if(com == -1)
				{
					andMask = long.MaxValue;
					orMask = 0;
					long currentBit = 1;
					for (int i = s.Length - 1; i >= 0; --i)
					{
						if(s[i] == '1')
						{
							orMask = orMask | currentBit;
						}
						else if(s[i] == '0')
						{
							andMask = andMask ^ currentBit;
						}

						currentBit *= 2;
					}
				}
				else
				{
					long val = long.Parse(s);
					val = val & andMask;
					val = val | orMask;
					if (memory.ContainsKey(com))
					{
						memory[com] = val;
					}
					else
					{
						memory.Add(com, val);
					}
				}
			}

			long result = 0;

			foreach(long key in memory.Keys)
			{
				result += memory[key];
			}

			return result;
		}

		private long ProcessCommands2(ref List<(long, string)> commands)
		{
			long andMask = long.MaxValue;
			long orMask = 0;
			List<long> maskAddresses = new List<long>();

			Dictionary<long, long> memory = new Dictionary<long, long>();

			foreach ((long com, string s) in commands)
			{
				if (com == -1)
				{
					maskAddresses.Clear();
					maskAddresses.Add(0);
					andMask = long.MaxValue;
					orMask = 0;
					long currentBit = 1;
					for (int i = s.Length - 1; i >= 0; --i)
					{
						if (s[i] == '1')
						{
							orMask = orMask | currentBit;
						}
						else if (s[i] == 'X')
						{
							andMask = andMask ^ currentBit;
							List<long> toAdd = new List<long>();
							foreach (long m in maskAddresses)
							{
								toAdd.Add(m | currentBit);
							}
							maskAddresses.AddRange(toAdd);
						}

						currentBit *= 2;
					}
				}
				else
				{
					long val = long.Parse(s);
					long addr = com | orMask;
					addr = addr & andMask;

					foreach(long m in maskAddresses)
					{
						long tempAddr = addr | m;
						if (memory.ContainsKey(tempAddr))
						{
							memory[tempAddr] = val;
						}
						else
						{
							memory.Add(tempAddr, val);
						}
					}
				}
			}

			long result = 0;

			foreach (long key in memory.Keys)
			{
				result += memory[key];
			}

			return result;
		}

		public long Solve1()
		{
			List<(long, string)> commands = new List<(long, string)>();
			ReadInputs(inputPath, ref commands);

			long result = ProcessCommands(ref commands);

			return result;
		}

		public long Solve2()
		{
			List<(long, string)> commands = new List<(long, string)>();
			ReadInputs(inputPath, ref commands);

			long result = ProcessCommands2(ref commands);

			return result;
		}
	}
}
