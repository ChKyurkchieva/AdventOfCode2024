using AdventOfCode2024.Day_2;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day_5;

internal class FifthDay
{
	public List<(int, int)> _rules;
	public FifthDay(string[] text)
	{
		_rules = new List<(int, int)>();
		Rules(text);
	}
	public void Rules(string[] text)
	{
		foreach (string line in text)
		{
			var match = Regex.Match(line, @"([0-9]+)\|([0-9]+)");
			if (match.Success == true)
			{
				var a = match.Groups[1];
				var b = match.Groups[2];
				int.TryParse(a.ToString(), out int first);
				int.TryParse(b.ToString(), out int second);
				_rules.Add((first, second));
			}
		}
	}
	public int SubsequencesMultiplication(string[] text)
	{
		int result = 0;
		List<string> orderedSubsequences = new List<string>();
		orderedSubsequences = GetOrderedSequences(text);
		foreach (string line in orderedSubsequences)
		{
			string[] splited = line.Split(',');
			int[] numbers = new int[splited.Length];
			int index = 0;
			foreach (string number in splited)
			{
				int.TryParse(number, out int n);
				numbers[index] = n;
				index++;
			}
			result += numbers[numbers.Length / 2];
		}
		return result;
	}
	public List<string> GetSubsequences(string[] text)
	{
		List<string> subsequences = new List<string>();
		foreach (string line in text)
		{
			var match = Regex.Match(line, @"((([0-9]+),)+([0-9]+))", RegexOptions.Multiline);
			if (match.Success)
				subsequences.Add(match.Value);
		}
		return subsequences;
	}
	public List<string> GetOrderedSequences(string[] text)
	{
		List<string> subsequences = new List<string>();
		subsequences = GetSubsequences(text);
		List<string> ordered = new List<string>();
		foreach (string line in subsequences)
		{
			string candidate = line;
			string[] numbers = line.Split(',');
			int.TryParse(numbers[0], out int first);
			for (int i = 1; i < numbers.Length - 1; i++)
			{
				int.TryParse(numbers[i], out int ith);
				int.TryParse(numbers[i + 1], out int next);
				if (_rules.Contains((ith, first)) || _rules.Contains((next, ith)))
				{
					break;
				}
				if (i + 1 == numbers.Length - 1 && !_rules.Contains((next, first)))
				{
					ordered.Add(line);
				}
			}
		}
		return ordered;
	}
	public List<string> GetUnorderedSequences(string[] text)
	{
		List<string> sequences = new List<string>();
		sequences = GetSubsequences(text);
		List<string> unordered = new List<string>();
		foreach(string line in sequences)
		{
			string[] numbers = line.Split(',');
			int.TryParse(numbers[0], out int first);
			for (int i = 1; i < numbers.Length - 1; i++)
			{
				int.TryParse(numbers[i], out int ith);
				int.TryParse(numbers[i + 1], out int next);
				if (_rules.Contains((ith, first)) || _rules.Contains((next, ith)))
				{
					unordered.Add(line);
					break;
				}
			}
		}
		return unordered;
	}
	public bool IsSubsequencesMultiplication(string sequence)
	{
		string[] numbers = sequence.Split(',');
		int.TryParse(numbers[0], out int first);
		for(int i = 1; i < numbers.Length; i++)
		{
			int.TryParse(numbers[i], out int ith);
			for (int j = i - 1; j >= 0; j--)
			{
				int.TryParse(numbers[j], out int jth);
				if (_rules.Contains((jth, ith)))
					return false;
			}
		}
		return true;
	}
	public int RepairSubsequence(string[] text)
	{
		int result = 0;
		List<string> unordered = GetUnorderedSequences(text);
		foreach (string line in unordered)
		{
			string[] numbers = line.Split(',');
			List<string> order = new List<string>();
			order.Clear();
			order.Add(numbers[0]);
			for (int i = 1; i < numbers.Length; i++)
			{
				int.TryParse(numbers[i], out int ith);
				for (int j = 0; j < i; j++)
				{
					int.TryParse(order[j],out int lastsmaller);
					if (_rules.Contains((lastsmaller, ith)) && j == i - 1)
					{
						order.Add(numbers[i]);
						break;
					}
					if (j < i - 1)
					{
						int.TryParse(order[j + 1], out int next);
						if (_rules.Contains((lastsmaller, ith)) && _rules.Contains((ith, next)))
						{
							order.Insert(j + 1, numbers[i]);
							break;
						}
					}
					if(j == 0 && _rules.Contains((ith, lastsmaller)))
					{
						order.Insert(0, numbers[i]);
						break;
					}
				}
			}
			string middle = order[order.Count / 2];
			int.TryParse(middle, out int n);
			result += n;
		}
		return result;
	}
}