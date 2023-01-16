using System;
using System.Data;
using System.Linq;

namespace JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());
            int[][] actualMatrix = new int[matrixRows][];

            for (int i = 0; i < matrixRows; i++)
            {
                actualMatrix[i] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < actualMatrix.Length - 1; row++)
            {
                if (actualMatrix[row].Length == actualMatrix[row + 1].Length)
                {
                    for (int col = 0; col < actualMatrix[row].Length; col++)
                    {
                        actualMatrix[row][col] *= 2;
                        actualMatrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < actualMatrix[row].Length; col++)
                    {
                        actualMatrix[row][col] /= 2;
                    }
                    for (int col = 0; col < actualMatrix[row + 1].Length; col++)
                    {
                        actualMatrix[row + 1][col] /= 2;
                    }
                }
            }

            string[] command = Console.ReadLine()
                .Split()
                .ToArray();

            while (command[0] != "End")
            {
                if (command[0] == "Add")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int value = int.Parse(command[3]);
                    if (row >= 0 && row < actualMatrix.Length &&
                        col >= 0 && col < actualMatrix[row].Length)
                    {
                        actualMatrix[row][col] += value;
                    }
                }
                else if (command[0] == "Subtract")
                {
                    int row = int.Parse(command[1]);
                    int col = int.Parse(command[2]);
                    int value = int.Parse(command[3]);
                    if (row >= 0 && row < actualMatrix.Length &&
                        col >= 0 && col < actualMatrix[row].Length)
                    {
                        actualMatrix[row][col] -= value;
                    }
                }

                command = Console.ReadLine()
                .Split()
                .ToArray();
            }

            PrintMatrix(actualMatrix);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
