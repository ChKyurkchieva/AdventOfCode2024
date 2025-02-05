using AdventOfCode2024.Day_2;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day_5;

internal class FifthDay
{
	private List<List<int>> _graph;
	private List<(int, int)> _rules;
	public FifthDay(string[] text)
	{
		_rules = Rules(text);
	}
	public List<(int, int)> Rules(string[] text)
	{
		_rules = new List<(int, int)>();
		foreach (string line in text)
		{
			var match = Regex.Match(line, @"([0-9]+)\|([0-9]+)");
			if (match.Success)
			{
				var a = match.Groups[1];
				var b = match.Groups[2];
				int.TryParse(a.ToString(), out int first);
				int.TryParse(b.ToString(), out int second);
				_rules.Add((first,second));
			}
		}
		return _rules;
	}

	public int SubsequencesMultiplication(string[] text)
	{
		int result = 0;
		foreach (string line in text)
		{
			var match = Regex.Match(line, @"((([0-9]+),)+([0-9]+))", RegexOptions.Multiline);
			if (match.Success)
			{
				string numbers = match.Value;
				List<int> sequence = new List<int>();
				string[] strings = numbers.Split(',');
				foreach (var s in strings)
				{
					int.TryParse(s, out int number);
					sequence.Add(number);
				}
				for (int i = 0; i < sequence.Count - 1; i++)
				{
					List<int> candidate = new List<int>();
					if (_rules.Contains((sequence[i], sequence[0])) || _rules.Contains((sequence[i+1], sequence[i])))
						break;
					if (i + 1 == sequence.Count - 1)
						result += sequence[sequence.Count / 2];
				}
			}
		}
		return result;
	}

	public int RepairSubsequence(string[] text)
	{
		int result = 0;
		return result;
	}
}