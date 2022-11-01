using System;
using System.Linq;
using System.Security;

namespace Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[,] fieldMatrix = new string[fieldSize, fieldSize];

            string[] moves = Console.ReadLine()
                .Split()
                .ToArray();

            FillMatrix(ref fieldMatrix);

            var currentLocation = FindStartingPoint(fieldMatrix);
            int allCoalCount = GetAllCoalCount(fieldMatrix);
            int coalMinedCount = 0;
            bool reachedEnd = false;

            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] == "up" && currentLocation[0] - 1 >= 0)
                {
                    currentLocation[0] -= 1;
                }
                else if (moves[i] == "down" && currentLocation[0] + 1 < fieldMatrix.GetLength(0))
                {
                    currentLocation[0] += 1;
                }
                else if (moves[i] == "right" && currentLocation[1] + 1 < fieldMatrix.GetLength(0))
                {
                    currentLocation[1] += 1;
                }
                else if (moves[i] == "left" && currentLocation[1] - 1 >= 0)
                {
                    currentLocation[1] -= 1;
                }

                if (fieldMatrix[currentLocation[0], currentLocation[1]] == "e")
                {
                    reachedEnd = true;
                    break;
                }
                else if (fieldMatrix[currentLocation[0], currentLocation[1]] == "c")
                {
                    coalMinedCount++;
                    fieldMatrix[currentLocation[0], currentLocation[1]] = "*";
                }
            }

            if (coalMinedCount == allCoalCount)
            {
                Console.WriteLine($"You collected all coals! ({currentLocation[0]}, {currentLocation[1]})");
            }
            else if (reachedEnd)
            {
                Console.WriteLine($"Game over! ({currentLocation[0]}, {currentLocation[1]})");
            }
            else
            {
                Console.WriteLine($"{allCoalCount - coalMinedCount} coals left. ({currentLocation[0]}, {currentLocation[1]})");
            }
        }

        private static int GetAllCoalCount(string[,] fieldMatrix)
        {
            int count = 0;

            for (int row = 0; row < fieldMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < fieldMatrix.GetLength(1); col++)
                {
                    if (fieldMatrix[row, col] == "c")
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static int[] FindStartingPoint(string[,] fieldMatrix)
        {
            for (int row = 0; row < fieldMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < fieldMatrix.GetLength(1); col++)
                {
                    if (fieldMatrix[row, col] == "s")
                    {
                        return new int[] { row, col };
                    }
                }
            }

            return new int[] { 0 };
        }

        public static void FillMatrix(ref string[,] fieldMatrix)
        {
            for (int row = 0; row < fieldMatrix.GetLength(0); row++)
            {
                string[] rowInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                for (int col = 0; col < fieldMatrix.GetLength(1); col++)
                {
                    fieldMatrix[row, col] = rowInfo[col];
                }
            }
        }
    }
}
