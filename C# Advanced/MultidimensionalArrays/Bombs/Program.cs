using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Bombs
{
    internal class Program
    {
        public static List<string[]> explodedBombs = new List<string[]>();
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] matrixRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = matrixRow[col];
                }
            }

            string[] bombsLocations = Console.ReadLine()
                .Split()
                .ToArray();

            for (int iter = 0; iter < bombsLocations.Length; iter++)
            {
                string[] currentBombLocation = bombsLocations[iter].Split(',');
                int row = int.Parse(currentBombLocation[0]);
                int col = int.Parse(currentBombLocation[1]);

                BombExplode(row, col, ref matrix);

                explodedBombs.Add(currentBombLocation);
            }

            Console.WriteLine($"Alive cells: {aliveCellsCount(matrix)}");
            Console.WriteLine($"Sum: {aliveCellsSum(matrix)}");
            PrintMatrix(matrix);
        }

        public static int aliveCellsSum(int[,] matrix)
        {
            int aliveCellsSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCellsSum += matrix[row, col];
                    }
                }
            }

            return aliveCellsSum;
        }

        public static int aliveCellsCount(int[,] matrix)
        {
            int aliveCellsCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCellsCount++;
                    }
                }
            }

            return aliveCellsCount;
        }

        public static bool isExplodedBomb(int row, int col)
        {
            foreach (var bomb in explodedBombs)
            {
                if (int.Parse(bomb[0]) == row && int.Parse(bomb[1]) == col)
                {
                    return true;
                }
            }

            return false;
        }

        private static void BombExplode(int row, int col, ref int[,] matrix)
        {
            int bomb = matrix[row, col];

            if (row + 1 < matrix.GetLength(0))
            {
                // if down row is available

                // here remove the middle one obv
                if (!isExplodedBomb(row + 1, col) && !isDeadCell(row + 1, col, matrix))
                {
                    matrix[row + 1, col] -= bomb;
                }

                if (col + 1 < matrix.GetLength(1))
                {
                    // if right bottom elem exists
                    if (!isExplodedBomb(row + 1, col + 1) && !isDeadCell(row + 1, col + 1, matrix))
                    {
                        matrix[row + 1, col + 1] -= bomb;
                    }
                }
                if (col - 1 >= 0)
                {
                    // if left bottom elem exists
                    if (!isExplodedBomb(row + 1, col - 1) && !isDeadCell(row + 1, col - 1, matrix))
                    {
                        matrix[row + 1, col - 1] -= bomb;
                    }
                }
            }
            if (row - 1 >= 0)
            {
                // if down row is available

                // here remove the middle one obv
                if (!isExplodedBomb(row - 1, col) && !isDeadCell(row - 1, col, matrix))
                {
                    matrix[row - 1, col] -= bomb;
                }

                if (col + 1 < matrix.GetLength(1))
                {
                    // if right top remove
                    if (!isExplodedBomb(row - 1, col + 1) && !isDeadCell(row - 1, col + 1, matrix))
                    {
                        matrix[row - 1, col + 1] -= bomb;
                    }
                }
                if (col - 1 >= 0)
                {
                    // if left top remove
                    if (!isExplodedBomb(row - 1, col - 1) && !isDeadCell(row - 1, col - 1, matrix))
                    {
                        matrix[row - 1, col - 1] -= bomb;
                    }
                }
            }

            if (col + 1 < matrix.GetLength(1))
            {
                // middle right
                if (!isExplodedBomb(row, col + 1) && !isDeadCell(row, col + 1, matrix))
                {
                    matrix[row, col + 1] -= bomb;
                }
            }
            if (col - 1 >= 0)
            {
                // middle left
                if (!isExplodedBomb(row, col - 1) && !isDeadCell(row, col - 1, matrix))
                {
                    matrix[row, col - 1] -= bomb;
                }
            }

            matrix[row, col] = 0;
        }

        private static bool isDeadCell(int row, int col, int[,] matrix)
        {
            if (matrix[row, col] <= 0)
            {
                return true;
            }
            return false;
        }

        static void PrintMatrix(int[,] matrix)
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
