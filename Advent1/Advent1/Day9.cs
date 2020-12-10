using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent1
{
	class Day9
	{
		private string inputPath = "../../../../Input/Input9a.txt";

		private void ReadInputs(string file, int preambleSize, ref Queue<long> preamble, ref List<long> remainder)
		{
			if (preamble == null)
			{
				preamble = new Queue<long>();
			}
			if (remainder == null)
			{
				remainder = new List<long>();
			}

			preamble.Clear();
			remainder.Clear();

			int pos = 0;

			string[] lines = File.ReadAllLines(file);
			foreach (string line in lines)
			{
				long parsed = long.Parse(line);
				if (pos < preambleSize)
				{
					preamble.Enqueue(parsed);
				}
				else
				{
					remainder.Add(parsed);
				}

				++pos;
			}
		}

		private bool PreambleContainsSum(ref List<long> preamble, long sum)
		{
			for (int i = 0; i < preamble.Count; ++i)
			{
				long rem = sum - preamble[i];
				if (preamble.Contains(rem))
				{
					return true;
				}
			}

			return false;
		}

		private long FindFirstMistake(Queue<long> preamble, ref List<long> remainder)
		{
			for (int i = 0; i < remainder.Count; ++i)
			{
				List<long> preambleList = new List<long>(preamble.ToArray());
				if (!PreambleContainsSum(ref preambleList, remainder[i]))
				{
					return remainder[i];
				}

				preamble.Dequeue();
				preamble.Enqueue(remainder[i]);
			}

			return 0;
		}

		private long FindWeakness(ref Queue<long> preamble, ref List<long> remainder)
		{
			long firstMistake = FindFirstMistake(preamble, ref remainder);

			List<long> list = new List<long>();
			list.AddRange(preamble.ToArray());
			list.AddRange(remainder);

			int first = 0;
			int last = 1;
			long currentSum = list[0];
			while(last < list.Count)
			{
				if(currentSum < firstMistake)
				{
					currentSum += list[last++];
				}
				else if(currentSum > firstMistake)
				{
					currentSum -= list[first++];
				}

				if(currentSum == firstMistake)
				{
					break;
				}
			}

			long min = list[first];
			long max = list[first];
			for(int i = first + 1; i < last; ++i)
			{
				if(list[i] < min)
				{
					min = list[i];
				}
				if(list[i] > max)
				{
					max = list[i];
				}
			}

			return min + max;
		}

		public long Solve1()
		{
			Queue<long> preamble = new Queue<long>();
			List<long> remainder = new List<long>();

			ReadInputs(inputPath, 25, ref preamble, ref remainder);

			long foundMistake = FindFirstMistake(preamble, ref remainder);

			return foundMistake;
		}

		public long Solve2()
		{
			Queue<long> preamble = new Queue<long>();
			List<long> remainder = new List<long>();

			ReadInputs(inputPath, 25, ref preamble, ref remainder);

			long weakness = FindWeakness(ref preamble, ref remainder);

			return weakness;
		}
	}
}
