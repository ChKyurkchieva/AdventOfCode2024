using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;
namespace AdventOfCode2024.Day_7;

internal class SeventhDay
{
	private static string[] GenerateAllPermutations(int n)
	{
		int size = (int)Math.Pow(2, n);
		string[] result = new string[size];
		for (int i = 0; i < size; i++)
		{
			string binary = Convert.ToString(i, 2).PadLeft(n, '0');
			result[i] = binary;
		}
		return result;
	}
	public static UInt128 FindTotalCalibrationResult()
	{
		UInt128 result = 0;
		string filePath = @"..\..\..\Day 7\Input.txt";
		string[] lines = File.ReadAllLines(filePath);
		foreach (string line in lines)
		{
			MatchCollection matches = Regex.Matches(line, "([0-9]+){1}");
			if (matches.Count > 0)
			{
				List<UInt128> numbers = new(matches.Count);
				for (int i = 0; i < matches.Count; i++)
				{
					if(UInt128.TryParse(matches.ElementAt(i).ToString(), out UInt128 n))
						numbers.Add(n);
				}
				string[] permutations = GenerateAllPermutations(numbers.Count - 2);
				foreach (var permutation in permutations)
				{
					UInt128 candidate = numbers[1];
					for (int i = 0; i < permutation.Length; i++)
					{
						if (permutation[i] == '0')
							candidate += numbers[i + 2];
						if (permutation[i] == '1')
							candidate *= numbers[i + 2];
					}
					if (candidate == numbers[0])
					{
						result += (UInt128)numbers[0];
						break;
					}
				}
			}
		}
		return result;
	}
}
