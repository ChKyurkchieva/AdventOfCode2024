using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day_5;

internal class FifthDay
{
	private List<List<int>> _graph;
	public FifthDay(string[] text) => _graph = CreateGraph(text);
	public List<List<int>> CreateGraph(string[] text)
	{
		List<List<int>> graph = new List<List<int>>();
		for (int i = 1; i < 100; i++)
		{
			graph.Add(new List<int>());
		}
		foreach (string line in text)
		{
			if (line == string.Empty || !line.Contains('|'))
				return graph;

			var match = Regex.Match(line, @"([0-9]+)\|([0-9]+)");
			if (match.Success)
			{
				var a = match.Groups[1];
				var b = match.Groups[2];
				int.TryParse(a.ToString(), out int first);
				int.TryParse(b.ToString(), out int second);
				graph[first].Add(second);
			}
		}
		return graph;
	}
	public static void DisplayGraph(List<List<int>> graph)
	{
		for (int i = 0; i < graph.Count; i++)
		{
			Console.Write($"{i}: "); // Print the vertex
			foreach (int j in graph[i])
			{
				Console.Write($"{j} "); // Print its adjacent
			}
			Console.WriteLine();
		}
	}
	public  bool IsSubsequence(List<int> numbers, List<int> sequence)
	{
		if(numbers.Count == 0) return false;
		List<int> indeces = new List<int>();
		foreach (int n in sequence)
			indeces.Add(numbers.IndexOf(n));
		var ordered = indeces.Order();
		for (int i = 0; i < ordered.Count(); i++)
			if (ordered.ElementAt(i) != indeces[i]) return false;

		return true;
	}
	private void DepthFirstSearch(int start, List<int> path)
	{
		Boolean[] visited = new Boolean[100];

		Stack<int> stack = new Stack<int>();

		stack.Push(start);

		while (stack.Count > 0)
		{
			start = stack.Peek();
			stack.Pop();

			if (visited[start] == false)
			{
				path.Add(start);
				visited[start] = true;
			}

			foreach (int v in _graph[start])
			{
				if (!visited[v] && _graph[v].Count > 0)
					stack.Push(v);
			}

		}
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
					DepthFirstSearch(sequence[i], candidate);
					if (!candidate.Contains(sequence[i + 1]))
						break;
					if (i + 1 == sequence.Count - 1)
						result += sequence[sequence.Count / 2];
				}
			}
		}
		return result;
	}
}
