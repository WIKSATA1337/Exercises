using System;
using System.Linq;

namespace SnakeMoves
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
            string snake = Console.ReadLine();
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                        matrix[row, col] = snake[counter].ToString();
                        counter++;
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) -1; col >= 0; col--)
                    {
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                        matrix[row, col] = snake[counter].ToString();
                        counter++;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
