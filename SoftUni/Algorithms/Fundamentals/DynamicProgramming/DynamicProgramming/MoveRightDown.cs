namespace DynamicProgramming
{
    public static class MoveRightDown
    {
        public static void Run()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            var matrix = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var rowElements = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < rowElements.Length; c++)
                {
                    matrix[r, c] = rowElements[c];
                }
            }

            var dpMatrix = new int[rows, cols];

            dpMatrix[0, 0] = matrix[0, 0];

            for (int c = 1; c < cols; c++)
            {
                dpMatrix[0, 1] = dpMatrix[0, c - 1] + matrix[0, c];
            }

            for (int r = 1; r < rows; r++)
            {
                dpMatrix[r, 0] = dpMatrix[r - 1, 0] + matrix[r, 0];
            }

            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    dpMatrix[r, c] = Math.Max(dpMatrix[r - 1, c], dpMatrix[r, c - 1]) + matrix[r, c];
                }
            }

            var path = new Stack<string>();

            var row = rows - 1;
            var col = cols - 1;

            while (row > 0 && col > 0)
            {
                path.Push($"[{row}, {col}]");
                int up = dpMatrix[row - 1, col];
                int left = dpMatrix[row, col - 1];

                if (up > left)
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            while (row > 0)
            {
                path.Push($"[{row}, {col}]");
                row--;
            }

            while (col > 0)
            {
                path.Push($"[{row}, {col}]");
                col--;
            }

            path.Push($"[{row}, {col}]");
            Console.WriteLine(string.Join(' ', path));
        }
    }
}
