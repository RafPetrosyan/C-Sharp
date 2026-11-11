
using System;

class Program
{

	static void InitByZero(char[,] matrix)
	{
		for (int i = 0; i < 11; i++)
		{
			for (int j = 0; j < 10; j++)
			{
				matrix[i, j] = '5';
			}
		}
	}

	static void PrintMatrix(in char[,] matrix)
	{
		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 10; j++)
			{
				System.Console.Write($"{matrix[i, j]} ");
			}
			System.Console.WriteLine();
		}
	}

	static bool CheckVerev(int x, int y, in char[,] matrix)
	{
		while (y >= 0)
		{
			if (matrix[y, x] == 'Q')
				return false;
			--y;
		}
		return true;
	}

	static bool CheckAnkyunagic(int x, int y, in char[,] matrix)
	{
		int temp_x = x - 1;
		int temp_y = y - 1;

		while (temp_x >= 0 && temp_y >= 0)
		{
			if (matrix[temp_y, temp_x] == 'Q')
				return false;
			--temp_x;
			--temp_y;
		}

		temp_x = x + 1;
		temp_y = y - 1;
		while (temp_x <= 9 && temp_y >= 0)
		{
			if (matrix[temp_y, temp_x] == 'Q')
				return false;
			++temp_x;
			--temp_y;
		}
		return true;
	}

	static void PrintAnswer(char[,] matrix)
	{
		int i = 0;
		
		while (i < 10)
		{
			System.Console.Write(matrix[10, i]);
			++i;
		}
		System.Console.WriteLine();
	}

	static void Rec(int y, char[,] matrix, ref int count)
	{
		int x = 0;

		if (y == 10)
		{
			PrintAnswer(matrix);
			++count;
			return ;
		}
		while (x < 10)
		{
			if (CheckAnkyunagic(x, y, matrix) == true && CheckVerev(x, y, matrix) == true)
			{
				matrix[y, x] = 'Q';
				matrix[10, y] = Convert.ToString(x)[0];
				Rec(y + 1, matrix, ref count);
				matrix[y, x] = '0';
				matrix[10, y] = '0';
			}
			++x;
		}
	}
	static void Main()
	{
		int count = 0;
		char[,]	matrix = new char[11,10];

		InitByZero(matrix);
		Rec(0, matrix, ref count);
		System.Console.WriteLine(count);
	}
}