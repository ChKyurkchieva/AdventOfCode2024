using AdventOfCode2024.Day_1;
using AdventOfCode2024.Day_2;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using AdventOfCode2024.Day_3;
using AdventOfCode2024.Day_4;
using AdventOfCode2024.Day_5;
using AdventOfCode2024.Day_6;
using AdventOfCode2024.Day_7;
using System.Numerics;

////DAY 1
//{
//	List<int> first = new List<int>();
//	List<int> second = new List<int>();
//	string firstfilePath = @"..\..\..\Day 1\Numbers.txt";
//	string[] lines = File.ReadAllLines(firstfilePath);

//	foreach (string l in lines)
//	{
//		string[] parts = l.Split("   ");
//		if (int.TryParse(parts[0], out int number1) && int.TryParse(parts[1], out int number2))
//		{
//			first.Add(number1);
//			second.Add(number2);
//		}
//	}
//	FirstDayTask1 firstDay = new FirstDayTask1();
//	Console.WriteLine(firstDay.Distance(first, second));
//	Console.WriteLine(firstDay.Similarity(first, second));
//}

////DAY 2
//{
//	string secondfilePath = @"..\..\..\Day 2\Numbers.txt";
//	string[] lineNumbers = File.ReadAllLines(secondfilePath);
//	int safeTolerate = 0;
//	int safe = 0;
//	SecondDay secondDay = new SecondDay();
//	int index = 0;
//	foreach (string l in lineNumbers)
//	{
//		string[] parts = l.Split(" ");
//		List<int> line = new List<int>();
//		foreach (string i in parts)
//		{
//			if (int.TryParse(i, out int number))
//				line.Add(number);
//		}
//		safe += secondDay.SafeList(line);
//		safeTolerate += secondDay.SafeTolerate(line);
//	}
//	Console.WriteLine(safe);
//	Console.WriteLine(safeTolerate);
//}

////DAY 3
//{
//	string filePath = @"..\..\..\Day 3\Text.txt";
//	string[] lines = File.ReadAllLines(filePath);
//	ThirdDay thirdDay = new ThirdDay();
//	Int128 result = thirdDay.SumOfMultiplications(lines);
//	Int128 result2 = thirdDay.SumOfDoMultiplications(lines);
//	Console.WriteLine(result);
//	Console.WriteLine(result2);
//}

////DAY 4
//{
//	string filePath = @"..\..\..\Day 4\Text.txt";
//	string[] lines = File.ReadAllLines(filePath);
//	FourthDay fourthDay = new FourthDay();
//	Int128 result = fourthDay.XmasNumber(lines);
//	Int128 result1 = fourthDay.MasX(lines);
//	Console.WriteLine(result);
//	Console.WriteLine(result1);
//}

//DAY 5
//{
//	string filePath = @"..\..\..\Day 5\Input.txt";
//	string[] lines = File.ReadAllLines(filePath);
//	FifthDay fifthDay = new FifthDay(lines);
//	int result = fifthDay.SubsequencesMultiplication(lines);
//	string[] little = new string[1];
//	//little[0] = "49,76,62,16,22,25,27,41,34,35,95,78,14";
//	int result2 = fifthDay.RepairSubsequence(lines);
//	Console.WriteLine(result);
//	Console.WriteLine(result2);
//}

//DAY 6
//{
//	string filePath = @"..\..\..\Day 6\Input.txt";
//	string[] lines = File.ReadAllLines(filePath);
//	SixthDay sixthDay = new SixthDay();
//	int result = sixthDay.GetWayOut(lines);
//	Console.WriteLine(result);
//}

//DAY 7

BigInteger result1 = SeventhDay.FindTotalCalibrationResult(2);
Console.WriteLine(result1);
//SeventhDay.GenerateAllPermutations(3, 4);
BigInteger result2 = SeventhDay.FindTotalCalibrationResult(3);
Console.WriteLine(result2);
