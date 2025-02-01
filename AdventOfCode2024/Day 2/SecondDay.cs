namespace AdventOfCode2024.Day_2;

internal class SecondDay
{
	public int SafeList(List<int> line)
	{
		int flag = line[0] - line[1];
		if (Math.Abs(flag) <= 0 || Math.Abs(flag) >= 4)
			return 0;
		for (int i = 1; i < line.Count - 1; i++)
		{
			bool decreasing = flag < 0 && ((line[i] - line[i + 1]) < 0 && (line[i] - line[i + 1]) > -4);
			bool increasing = flag > 0 && ((line[i] - line[i + 1]) > 0 && (line[i] - line[i + 1]) < 4);
			if (!decreasing && !increasing)
				return 0;
		}
		return 1;
	}
}
