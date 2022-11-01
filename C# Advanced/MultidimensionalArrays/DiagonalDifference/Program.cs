using System;
using System.Diagnostics.Tracing;
using System.Linq;

namespace DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                int[] readRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = readRow[j];
                }
            }

            int firstDiagonalSum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                firstDiagonalSum += matrix[i, i];
            }

            int secondDiagonalSum = 0;
            int counter = 0;
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                secondDiagonalSum += matrix[counter++, i];
            }

            int result = firstDiagonalSum - secondDiagonalSum;

            if (result < 0)
            {
                Console.WriteLine(result * -1);
            }
            else
            {
                Console.WriteLine(result);
            }

            // 0,2 1,1 2,0

            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        Console.Write($"{matrix[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
