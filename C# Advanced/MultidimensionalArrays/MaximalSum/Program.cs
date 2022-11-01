using System;
using System.Linq;
using System.Reflection;
using System.Security;

namespace MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
            int currentMaxSum = int.MinValue;
            string winnerRow1 = "";
            string winnerRow2 = "";
            string winnerRow3 = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] readRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = readRow[j];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int x = matrix[row, col];
                    int y = matrix[row, col + 1];
                    int z = matrix[row, col + 2];
                    int x2 = matrix[row + 1, col];
                    int y2 = matrix[row + 1, col + 1];
                    int z2 = matrix[row + 1, col + 2];
                    int x3 = matrix[row + 2, col];
                    int y3 = matrix[row + 2, col + 1];
                    int z3 = matrix[row + 2, col + 2];

                    int currentResult = x + y + z + x2 + y2 + z2 + x3 + y3 + z3;

                    if (currentResult > currentMaxSum)
                    {
                        currentMaxSum = currentResult;
                        winnerRow1 = $"{x} {y} {z}";
                        winnerRow2 = $"{x2} {y2} {z2}";
                        winnerRow3 = $"{x3} {y3} {z3}";
                    }
                }
            }

            Console.WriteLine($"Sum = {currentMaxSum}");
            Console.WriteLine(winnerRow1);
            Console.WriteLine(winnerRow2);
            Console.WriteLine(winnerRow3);
        }
    }
}
