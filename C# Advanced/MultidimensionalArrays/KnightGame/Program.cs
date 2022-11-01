using System;
using System.Linq;

namespace KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] chessBoard = new string[size, size];

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = currentRow[col].ToString();
                }
            }

            int dangerCount = 0;
            int removedCount = 0;

            for (int maxAttackPotential = 8; maxAttackPotential > 0; maxAttackPotential--)
            {
                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < chessBoard.GetLength(1); col++)
                    {
                        if (chessBoard[row, col] == "K")
                        {
                            // Top side check
                            if (row - 1 >= 0)
                            {
                                if (col - 2 >= 0)
                                {
                                    if (chessBoard[row - 1, col - 2] == "K")
                                    {
                                        dangerCount++;
                                    }
                                }

                                if (col + 2 < chessBoard.GetLength(1))
                                {
                                    if (chessBoard[row - 1, col + 2] == "K")
                                    {
                                        dangerCount++;
                                    }
                                }
                            }

                            if (row - 2 >= 0)
                            {
                                if (col - 1 >= 0)
                                {
                                    if (chessBoard[row - 2, col - 1] == "K")
                                    {
                                        dangerCount++;
                                    }
                                }

                                if (col + 1 < chessBoard.GetLength(1))
                                {
                                    if (chessBoard[row - 2, col + 1] == "K")
                                    {
                                        dangerCount++;
                                    }
                                }
                            }

                            // Bottom side check
                            if (row + 1 < chessBoard.GetLength(0))
                            {
                                if (col - 2 >= 0)
                                {
                                    if (chessBoard[row + 1, col - 2] == "K")
                                    {
                                        dangerCount++;
                                    }
                                }

                                if (col + 2 < chessBoard.GetLength(1))
                                {
                                    if (chessBoard[row + 1, col + 2] == "K")
                                    {
                                        dangerCount++;
                                    }
                                }
                            }

                            if (row + 2 < chessBoard.GetLength(0))
                            {
                                if (col - 1 >= 0)
                                {
                                    if (chessBoard[row + 2, col - 1] == "K")
                                    {
                                        dangerCount++;
                                    }
                                }

                                if (col + 1 < chessBoard.GetLength(1))
                                {
                                    if (chessBoard[row + 2, col + 1] == "K")
                                    {
                                        dangerCount++;
                                    }
                                }
                            }
                        }

                        if (dangerCount == maxAttackPotential)
                        {
                            chessBoard[row, col] = "0";
                            removedCount++;
                        }

                        dangerCount = 0;
                    }
                }
            }

            Console.WriteLine(removedCount);
        }
    }
}
