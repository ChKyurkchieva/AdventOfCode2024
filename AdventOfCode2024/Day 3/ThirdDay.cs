using System.Text.RegularExpressions;

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
}
