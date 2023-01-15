namespace RecursionAndBacktracking
{
    public static class EightQueens
    {
        private static HashSet<int> dangerRows = new HashSet<int>();
        private static HashSet<int> dangerCols = new HashSet<int>();
        private static HashSet<int> dangerDiagonalOne = new HashSet<int>();
        private static HashSet<int> dangerDiagonalTwo = new HashSet<int>();
        public static void Run()
        {
            bool[,] board = new bool[8, 8];

            Solve(board, 0);
        }

        private static void Solve(bool[,] board, int row)
        {
            if (row >= board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); ++col)
            {
                if (CanPlaceQueen(row, col))
                {
                    // pre recursion
                    board[row, col] = true;
                    dangerRows.Add(row);
                    dangerCols.Add(col);
                    dangerDiagonalOne.Add(row - col);
                    dangerDiagonalTwo.Add(row + col);

                    // recursion
                    Solve(board, row + 1);

                    // post recursion
                    board[row, col] = false;
                    dangerRows.Remove(row);
                    dangerCols.Remove(col);
                    dangerDiagonalOne.Remove(row - col);
                    dangerDiagonalTwo.Remove(row + col);
                }
            }
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col])
                    {
                        Console.Write("X ");
                        continue;
                    }

                    Console.Write("- ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            return 
                !dangerRows.Contains(row) &&
                !dangerCols.Contains(col) &&
                !dangerDiagonalOne.Contains(row - col) &&
                !dangerDiagonalTwo.Contains(row + col);
        }
    }
}
