using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace AdventOfCode2024.Day_6;

public  class SixthDay
{
	private char[][] InitiallizeGrid(string[] lines, int rows, int columns)
	{
		char[][] grid = new char[rows][];
		int i = 0;
		foreach(string line in lines)
		{
			grid[i] = new char[columns];
			int j = 0;
			foreach(char c in line)
			{
				grid[i][j] = c;
				j++;
			}
			i++;
		}
		return grid;
	}
	private void ChangePosition(ref char c)
	{
		switch(c)
		{
			case '^': c = '>';
				break;
			case '>': c = 'v';
				break;
			case 'v': c = '<';
				break;
			case '<': c = '^';
				break;
		}
	}
	private (int, int) FindInitialPosition(char[][] grid, int rows, int columns)
	{
		(int, int) result = (0, 0);
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				if (grid[i][j] == '^' || grid[i][j] == '>' || grid[i][j] == 'v' || grid[i][j] == '<')
				{
					result.Item1 = i;
					result.Item2 = j;
				}
			}
		}
			return result;
	}
	private void MoveLeft(char[][] grid, int gridRow,int gridColumn, ref int rowPosition, ref int columnPosition) 
	{
		if(grid == null) return;
		bool isSaveMovingLeft(int columnPosition) => columnPosition > 0 && columnPosition < gridColumn;
		while(isSaveMovingLeft(columnPosition))
		{
			if (rowPosition == gridRow - 1 || columnPosition == gridColumn - 1)
			{
				grid[rowPosition][columnPosition] = 'X';
				return;
			}
			if (grid[rowPosition][columnPosition - 1] == '#')
				return;
			grid[rowPosition][columnPosition - 1] = grid[rowPosition][columnPosition];
			grid[rowPosition][columnPosition] = 'X';
			columnPosition--;
		}

	}
	private void MoveRight(char[][] grid, int gridRow, int gridColumn, ref int rowPosition, ref int columnPosition) 
	{
		if(grid == null) return;
		bool isSaveMovingRight(int columnPosition) => columnPosition > 0 && columnPosition < (gridColumn - 1);
		while(isSaveMovingRight(columnPosition))
		{
			if (rowPosition == gridRow - 1 || columnPosition == gridColumn - 1)
			{
				grid[rowPosition][columnPosition] = 'X';
				return;
			}
			if (grid[rowPosition][columnPosition + 1] == '#')
				return;
			grid[rowPosition][columnPosition + 1] = grid[rowPosition][columnPosition];
			grid[rowPosition][columnPosition]= 'X';
			columnPosition++;
		}
	}
	private void MoveUp(char[][] grid, int gridRow, int gridColumn, ref int rowPosition, ref int columnPosition) 
	{
		if (grid == null) return;
		bool isSaveMovingUp(int rowPosition) => rowPosition > 0 && rowPosition < (gridRow - 1);
		while (isSaveMovingUp(rowPosition))
		{
			if (rowPosition == gridRow - 1 || columnPosition == gridColumn - 1)
			{
				grid[rowPosition][columnPosition] = 'X';
				return;
			}
			if (grid[rowPosition - 1][columnPosition] == '#')
				return;
			grid[rowPosition - 1][columnPosition] = grid[rowPosition][columnPosition];
			grid[rowPosition][columnPosition] = 'X';
			rowPosition--;
		}
	}
	private void MoveDown(char[][] grid, int gridRow, int gridColumn, ref int rowPosition, ref int columnPosition) 
	{
		if (grid == null) return;
		bool isSaveMovingDown(int rowPosition) => rowPosition > 0 && rowPosition < (gridRow - 1);
		while (isSaveMovingDown(rowPosition))
		{
			if (rowPosition == gridRow - 1 || columnPosition == gridColumn -1)
			{
				grid[rowPosition][columnPosition] = 'X';
				return;
			}
			if (grid[rowPosition + 1][columnPosition] == '#')
				return;
			if (rowPosition == gridRow - 1)
				grid[rowPosition][columnPosition] = 'X';
			grid[rowPosition + 1][columnPosition] = grid[rowPosition][columnPosition];
			grid[rowPosition][columnPosition] = 'X';
			rowPosition++;
		}
	}
	private void Move(char[][] grid, int gridRow, int gridColumn, ref int startingPointRow, ref int startingPointColumn)
	{
		bool isInRange = startingPointRow > 0 && startingPointRow < gridRow - 1 && 
			startingPointColumn > 0 && startingPointColumn < gridColumn - 1;
		switch (grid[startingPointRow][startingPointColumn])
		{
			case '^':
				{
					MoveUp(grid, gridRow, gridColumn, ref startingPointRow, ref startingPointColumn);
					if (isInRange)
						ChangePosition(ref grid[startingPointRow][startingPointColumn]);
					break;
				}
			case '>':
				{
					MoveRight(grid, gridRow, gridColumn, ref startingPointRow, ref startingPointColumn);
					if (isInRange)
						ChangePosition(ref grid[startingPointRow][startingPointColumn]);
					break;
				}
			case 'v':
				{
					MoveDown(grid, gridRow, gridColumn, ref startingPointRow, ref startingPointColumn);
					if (isInRange)
						ChangePosition(ref grid[startingPointRow][startingPointColumn]);
					break;
				}
			case '<':
				{
					MoveLeft(grid, gridRow, gridColumn, ref startingPointRow, ref startingPointColumn);
					if (isInRange)
						ChangePosition(ref grid[startingPointRow][startingPointColumn]);
					break;
				}

		}
	}
	public int GetWayOut(string[] lines)
	{
		int result = 0;
		int rows = lines.Length;
		int columns = lines[0].Length;
		char[][] grid = InitiallizeGrid(lines, rows, columns);
		(int, int) startingPoint = FindInitialPosition(grid, rows, columns);
		bool exited() => grid[0].Any(x => x == 'X') || grid[rows - 1].Any(x => x == 'X') || grid.Select(row => row[0]).Any(x => x == 'X') ||grid.Select(row => row[columns - 1]).Any(x => x == 'X');
		int startingPointRow = startingPoint.Item1;
		int startingPointColumn = startingPoint.Item2;
		while(!exited())
		{
			Move(grid, rows, columns, ref startingPointRow, ref startingPointColumn);
		}
		return result;
	}
}
