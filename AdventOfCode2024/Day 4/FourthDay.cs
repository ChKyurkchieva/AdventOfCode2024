using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;

namespace AdventOfCode2024.Day_4;

internal class FourthDay
{
	int XmasNumberLines(string[] text)
	{
		int result = 0;
		foreach (string s in text)
		{
			result += Regex.Count(s, "XMAS");
			string reverse = new string(s.ToCharArray().Reverse().ToArray());
			result += Regex.Count(reverse, "XMAS");
		}
		return result;
	}

	char[,] ToTwoDArray(string[] text)
	{
		char[,] array = new char[text.Length, text.Length];
		for (int i = 0; i < text.Length; i++)
			for (int j = 0; j < text.Length; j++)
				array[i, j] = text[i][j];
		return array;
	}
	char[,] Transpose(string[] text)
	{
		char[,] array = ToTwoDArray(text);
		char[,] transposed = new char[text.Length, text.Length];
		for (int i = 0; i < text.Length; i++)
			for (int j = 0; j < text.Length; j++)
				transposed[j, i] = array[i,j];
		return transposed;
	}
	int XmasNumebrColumn(string[] text)
	{
		int result = 0;
		char[,] transposed = Transpose(text);
		string[] transposedText = new string[text.Length];
		for (int i = 0; i < text.Length; i++)
		{
			for (int j = 0; j < text.Length; j++)
				transposedText[i] += transposed[i, j];
		}
		result += XmasNumberLines(transposedText);
		return result;
	}
	int XmasNumberDiagonal(string[] text)
	{
		int result = 0;
		char[,] array = ToTwoDArray(text);
		for (int i = text.Length - 4; i > 0; i--)
		{
			string diagonal = " ";
			string diagonal2 = " ";
			for (int j = 0; j < text.Length - i; j++)
			{
				diagonal += array[i, j];
				diagonal2 += array[j, i];
			}
			result += Regex.Count(diagonal, "XMAS");
			result += Regex.Count(diagonal2, "XMAS");
			string reverse1 = new string(diagonal.ToCharArray().Reverse().ToArray());
			result += Regex.Count(reverse1, "XMAS");
			string reverse2 = new string(diagonal2.ToCharArray().Reverse().ToArray());
			result += Regex.Count(reverse2, "XMAS");
		}
		string d = " ";
		for(int i = 0; i < text.Length; i++)
			d += array[i,i];
		result += Regex.Count(d, "XMAS");
		string reverse = new string(d.ToCharArray().Reverse().ToArray());
		result += Regex.Count(reverse, "XMAS");
		return result;
	}
	int XmasNumberOtherDiagonal(string[] text)
	{
		int result = 0;
		char[,] transposed = Transpose(text);
		string[] transposedText = new string[text.Length];
		for (int i = 0; i < text.Length; i++)
		{
			for (int j = 0; j < text.Length; j++)
				transposedText[i] += transposed[i, j];
		}
		result += XmasNumberDiagonal(transposedText);
		return result;
	}
	public int XmasNumber(string[] text)
	{
		int result = 0;
		result += XmasNumberLines(text);
		result += XmasNumebrColumn(text);
		result += XmasNumberDiagonal(text);
		result += XmasNumberOtherDiagonal(text);
		return result;
	}
}
