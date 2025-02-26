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
		static List<UInt128> SplitLine(string line) =>
			line
			.Split([' ', ':'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
			.Select(UInt128.Parse).ToList();
		List<List<UInt128>> input =
			File.ReadAllLines(filePath)
			.Select(SplitLine)
			.ToList();
		input.ForEach(x => result = FindCalibrationsNumber(powerBase, result, x));
		return result;
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

	public static string[] GenerateAllPermutations(int powerBase, int n) =>
		Enumerable.Range(0, (int)Math.Pow(powerBase, n))
				  .Select(x => ConvertToBase(x, powerBase, n)).ToArray();

	private static string ConvertToBase(int num, int powerBase, int length)
	{
		var result = Enumerable.Range(0, length).Aggregate(new List<char>(length), (result, i) =>
		{
			result.Add((char)('0' + (num % powerBase)));
			num /= powerBase;
			return result;
		}).Reverse<char>().ToArray();
		return new string(result);
	}
}
