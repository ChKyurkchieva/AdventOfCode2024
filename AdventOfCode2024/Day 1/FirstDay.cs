namespace AdventOfCode2024.Day_1;

internal class FirstDayTask1
{
	public int Distance(List<int> first, List<int> second)
	{
		int distance = 0;
		if (first.Count == second.Count)
		{
			first.Sort();
			second.Sort();
			for (int i = 0; i < first.Count; i++)
			{
				int difference = first[i] - second[i];
				distance += Math.Abs(difference);
			}
		}
		return distance;
	}
	public int Similarity(List<int> first, List<int> second)
	{
		int similarity = 0;
		foreach (int i in first)
		{
			int countInSecond = second.FindAll(x => i == x).Count();
			similarity += (countInSecond * i);
		}
		return similarity;
	}
}
