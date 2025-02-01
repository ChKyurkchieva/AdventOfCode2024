using System.Collections.Immutable;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode2024.Day_3;
internal class ThirdDay
{
	public int SumOfMultiplications(string[] text)
	{
		int result = 0;
		foreach (string line in text)
			foreach (Match item in Regex.Matches(line, "mul\\(([0-9]+),([0-9]+)\\)"))
			{
				var a = item.Groups[1];
				var b = item.Groups[2];
				int.TryParse(a.ToString(), out int first);
				int.TryParse(b.ToString(), out int second);
				result += first * second;
			};
		return result;
	}
	public int SumOfDoMultiplications(string[] text)
	{
		int result = 0;
		List<Match> matches = new List<Match>();
		RegexOptions options= RegexOptions.Multiline;
		foreach(string line in text)
			matches.AddRange(Regex.Matches(line, @"(mul\([0-9]+,[0-9]+\))|(don't\(\))|(do\(\))", options));
		bool isDont = false;
		List<string> results = new List<string>();
		foreach (var m in matches)
		{
			if (m.Value.StartsWith("don't"))
				isDont = true;
			if (m.Value.StartsWith("do()"))
				isDont = false;
			if (!isDont && m.Value.StartsWith("mul"))
				results.Add(m.Value);
		}
		result = SumOfMultiplications(results.ToArray());
		return result;
	}
}
