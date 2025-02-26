using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;
namespace AdventOfCode2024.Day_7;

internal class SeventhDay
{
	public static BigInteger FindTotalCalibrationResult(int powerBase)
	{
		BigInteger result = 0;
		string filePath = @"..\..\..\Day 7\Input.txt";
		string[] lines = File.ReadAllLines(filePath);
		foreach (string line in lines)
		{
			MatchCollection matches = Regex.Matches(line, "([0-9]+){1}");
			if (matches.Count > 0)
			{
				List<UInt128> numbers = ExtractNumbersToList(matches);
				result = FindCalibrationsNumber(powerBase, result, numbers);
			}
		}
		return result;
	}

	private static List<UInt128> ExtractNumbersToList(MatchCollection matches)
	{
		List<UInt128> numbers = new(matches.Count);
		for (int i = 0; i < matches.Count; i++)
		{
			if (UInt128.TryParse(matches.ElementAt(i).ToString(), out UInt128 n))
				numbers.Add(n);
		}

		return numbers;
	}

	private static BigInteger FindCalibrationsNumber(int powerBase, BigInteger result, List<UInt128> numbers)
	{
		string[] permutations = GenerateAllPermutations(powerBase, numbers.Count - 2);
		foreach (var permutation in permutations)
		{
			BigInteger candidate = CalibrationNumberCandidate(numbers, permutation);
			if (candidate == numbers[0])
			{
				result += numbers[0];
				break;
			}
		}
		return result;
	}

	private static BigInteger CalibrationNumberCandidate(List<UInt128> numbers, string permutation)
	{
		BigInteger candidate = numbers[1];
		for (int i = 0; i < permutation.Length; i++)
		{
			if (i + 2 < numbers.Count)
			{
				if (permutation[i] == '0')
					candidate += numbers[i + 2];
				if (permutation[i] == '1')
					candidate *= numbers[i + 2];
				if (permutation[i] == '2')
				{
					candidate *= (BigInteger)Math.Pow(10, numbers[i + 2].ToString().Length);
					candidate += numbers[i + 2];
				}
			}
		}
		return candidate;
	}

	public static string[] GenerateAllPermutations(int powerBase, int n)
	{
		int size = (int)Math.Pow(powerBase, n);
		string[] result = new string[size];
		for (int i = 0; i < size; i++)
		{
			//string binary = Convert.ToString(i, powerBase).PadLeft(n, '0');
			//result[i] = binary;
			result[i] = ConvertToBase(i, powerBase, n); 
		}
		return result;
	}

	private static string ConvertToBase(int num, int powerBase, int length)
	{
		char[] result = new char[length];

		for (int i = length - 1; i >= 0; i--)
		{
			result[i] = (char)('0' + (num % powerBase));
			num /= powerBase;
		}

		return new string(result);
	}

}
