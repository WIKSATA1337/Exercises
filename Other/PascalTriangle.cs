namespace PascalTriangle
{
	public class Program
	{
		static Dictionary<string, int> dp = new Dictionary<string, int>();

		static void Main(string[] args)
		{
			int rows = int.Parse(Console.ReadLine());

			int[,] matrix = new int[rows, rows];

			matrix[0, 0] = 1;

			for (int i = 1; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j <= i; j++)
				{
					matrix[i, j] = Pascal(i, j);
				}
			}

			Print(matrix);
		}

		static int Pascal(int row, int col)
		{
			if (col == 0)
			{
				return 1;
			}
			else if (row == 0)
			{
				return 0;
			}
			else
			{
				if (!dp.ContainsKey($"{row} {col}"))
				{
					dp[$"{row} {col}"] = Pascal(row - 1, col) + Pascal(row - 1, col - 1);
				}

				return dp[$"{row} {col}"];
			}
		}

		static void Print(int[,] matrix)
		{
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				Console.Write(new string(' ', matrix.GetLength(0) - row - 1));

				for (int col = 0; col < matrix.GetLength(0); col++)
				{
					if (matrix[row, col] > 0)
					{
						Console.Write($"{matrix[row, col]} ");
					}
				}

				Console.WriteLine();
			}
		}
	}
}