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
			string diagonal = "";
			string diagonal2 = "";
			for (int j = 0; i+j < text.Length; j++)
			{
				diagonal += array[i+j, j];
				diagonal2 += array[j, i+j];
			}
			result += Regex.Count(diagonal, "XMAS");
			result += Regex.Count(diagonal2, "XMAS");
			string reverse1 = new string(diagonal.ToCharArray().Reverse().ToArray());
			result += Regex.Count(reverse1, "XMAS");
			string reverse2 = new string(diagonal2.ToCharArray().Reverse().ToArray());
			result += Regex.Count(reverse2, "XMAS");
		}
		string d = "";
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
		char[,] array = ToTwoDArray(text);
		for (int i = 3; i < text.Length - 1; i++)
		{
			string diagonal = "";
			string diagonal2 = "";
			for (int j = 0; j <= i; j++)
			{
				diagonal += array[i - j, j];
				diagonal2 += array[text.Length-1 - j, text.Length -i + j -1];
			}
			result += Regex.Count(diagonal, "XMAS");
			result += Regex.Count(diagonal2, "XMAS");
			string reverse1 = new string(diagonal.ToCharArray().Reverse().ToArray());
			result += Regex.Count(reverse1, "XMAS");
			string reverse2 = new string(diagonal2.ToCharArray().Reverse().ToArray());
			result += Regex.Count(reverse2, "XMAS");
		}
		string d = "";
		for (int j = 0; j < text.Length; j++)
			d += array[text.Length-1 - j, j];
		result += Regex.Count(d, "XMAS");
		string reverse = new string(d.ToCharArray().Reverse().ToArray());
		result += Regex.Count(reverse, "XMAS");
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

	bool MasTop(char[,] array, int i, int j) => array[i, j] == 'M' && array[i, j + 2] == 'M' && array[i + 1, j + 1] == 'A' && array[i + 2, j] == 'S' && array[i + 2, j + 2] == 'S';
	bool MasBottom(char[,] array, int i, int j) => array[i, j] == 'S' && array[i, j + 2] == 'S' && array[i + 1, j + 1] == 'A' && array[i + 2, j] == 'M' && array[i + 2, j + 2] == 'M';
	bool MasLeft(char[,] array, int i, int j) => array[i, j] == 'M' && array[i, j + 2] == 'S' && array[i + 1, j + 1] == 'A' && array[i + 2, j] == 'M' && array[i + 2, j + 2] == 'S';
	bool MasRight(char[,] array, int i, int j) => array[i, j] == 'S' && array[i, j + 2] == 'M' && array[i + 1, j + 1] == 'A' && array[i + 2, j] == 'S' && array[i + 2, j + 2] == 'M';
	public int MasX(string[] text)
	{
		int result = 0;
		char[,] array = ToTwoDArray(text);
		for(int i = 0; i < text.Length-2; i++)
		{
			for (int j = 0; j < text.Length - 2; j++)
			{
				if (MasTop(array, i, j) || MasBottom(array, i, j) || MasLeft(array, i, j) || MasRight(array, i, j))
					result++;
			}
		}
		return result;
	}
}
