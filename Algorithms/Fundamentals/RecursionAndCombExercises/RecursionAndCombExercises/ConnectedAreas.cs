namespace RecursionAndCombExercises
{
    public static class ConnectedAreas
    {
        // Example:
        // var area = new char[,]
        // {
        //     { '-', '-', '-', '*', '-', '-', '-', '*', '-'},
        //     { '-', '-', '-', '*', '-', '-', '-', '*', '-'},
        //     { '-', '-', '-', '*', '-', '-', '-', '*', '-'},
        //     { '-', '-', '-', '-', '*', '-', '*', '-', '-'},
        // };
    public class Area
        {
            public Area(int row, int col, int size)
            {
                Row = row;
                Col = col;
                Size = size;
            }
            public int Row{ get; set; }
            public int Col { get; set; }
            public int Size { get; set; }
        }

        private static char[,] matrix;
        private static List<Area> areas;
        private static int size;
        public static void Run(char[,] filledMatrix)
        {
            matrix = filledMatrix;
            areas = new List<Area>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    size = 0;
                    FindAreas(row, col);

                    if (size != 0)
                    {
                        areas.Add(new Area(row, col, size));
                    }
                }
            }

            areas = areas.OrderByDescending(a => a.Size)
                .ThenBy(a => a.Row)
                .ThenBy(a => a.Col)
                .ToList();

            for (int i = 0; i < areas.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({areas[i].Row}, {areas[i].Col}), size: {areas[i].Size}");
            }
        }

        private static void FindAreas(int row, int col)
        {
            if (IsOutside(row, col) || IsWall(row, col) || IsVisited(row, col))
            {
                return;
            }

            size++;
            matrix[row, col] = 'v';

            FindAreas(row - 1, col); // Up
            FindAreas(row + 1, col); // Down
            FindAreas(row, col - 1); // Left
            FindAreas(row, col + 1); // Right
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsVisited(int row, int col)
        {
            return matrix[row, col] == 'v';
        }

        private static bool IsOutside(int row, int col)
        {
            return 
                row < 0 ||
                row >= matrix.GetLength(0) ||
                col < 0 ||
                col >= matrix.GetLength(1);
        }
    }
}
