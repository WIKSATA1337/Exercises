using System;
using System.Linq;

namespace SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[matrixSize[0], matrixSize[1]];
            int counter = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] readRow = Console.ReadLine()
                    .Split()
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = readRow[j];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    string topLeft = matrix[row, col];
                    string topRight = matrix[row, col + 1];
                    string botLeft = matrix[row + 1, col];
                    string botRight = matrix[row + 1, col + 1];

                    if (isSquare(matrix, topLeft, topRight, botLeft, botRight))
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }

        static bool isSquare(string[,] matrix, string topLeft, string topRight, string botLeft, string botRight)
        {
            if (topLeft == topRight)
            {
                if (topRight == botLeft)
                {
                    if (botLeft == botRight)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
