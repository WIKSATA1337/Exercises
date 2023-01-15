namespace RecursionAndBacktracking
{
    public static class PathsFinder
    {
        private static char wall = '*';
        private static char end = 'X';
        public static void Run()
        {
            char[,] map = new char[,] {
                {'-', '-', '-' },
                {'-', '*', '-' },
                {'-', '-', 'X' }
            };

            FindPaths(map, 0, 0, new List<string>(), "");
        }

        private static void FindPaths(char[,] map, int row, int col,
            List<string> movements, string movement)
        {
            if (row < 0 || row >= map.GetLength(0) ||
                col < 0 || col >= map.GetLength(1))
            {
                return;
            }

            if (map[row, col] == wall || map[row, col] == '+')
            {
                return;
            }

            movements.Add(movement);

            if (map[row, col] == end)
            {
                Console.WriteLine(string.Join("", movements));
                movements.RemoveAt(movements.Count - 1);
                return;
            }

            // We do this down here and not up there where we add the movement,
            // because if we put it up there, our final (X) will turn into '+'
            // then into '-' and we will never find the exit.
            map[row, col] = '+';

            FindPaths(map, row + 1, col, movements, "D"); // Down
            FindPaths(map, row - 1, col, movements, "U"); // Up
            FindPaths(map, row, col + 1, movements, "R"); // Right
            FindPaths(map, row, col - 1, movements, "L"); // Left

            map[row, col] = '-';
            movements.RemoveAt(movements.Count - 1);
        }
    }
}
