using System;
using System.Linq;

namespace MatrixShuffling
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

            string[] command = Console.ReadLine()
                .Split()
                .ToArray();

            while (command[0] != "END")
            {
                if (command[0] == "swap" && command.Length == 5)
                {
                    int x = int.Parse(command[1]);
                    int y = int.Parse(command[2]);
                    int x2 = int.Parse(command[3]);
                    int y2 = int.Parse(command[4]);

                    if(validInfo(matrix, x, y, x2 ,y2))
                    {
                        string swapOne = matrix[x, y];
                        string swapTwo = matrix[x2, y2];

                        matrix[x, y] = swapTwo;
                        matrix[x2, y2] = swapOne;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine()
                .Split()
                .ToArray();
            }
        }

        static bool validInfo(string[,] matrix, int x, int y, int x2, int y2)
        {
            if (x >= 0 && x <= matrix.GetLength(0) - 1 &&
                y >= 0 && y <= matrix.GetLength(1) - 1 &&
                x2 >= 0 && x2 <= matrix.GetLength(0) - 1 &&
                y2 >= 0 && y2 <= matrix.GetLength(1) - 1)
            {
                return true;
            }

            return false;
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
