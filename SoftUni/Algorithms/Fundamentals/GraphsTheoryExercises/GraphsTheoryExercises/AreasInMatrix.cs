using System.Diagnostics.Metrics;

namespace GraphsTheoryExercises
{
    public static class AreasInMatrix
    {
        private static SortedDictionary<char, int> areas;
        private static bool[,] visited;
        private static char[,] graph;
        public static void Run()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            graph = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();

            FillMatrix(rows, cols);

            int areasCount = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (!visited[r, c])
                    {
                        var nodeValue = graph[r, c];
                        DFS(nodeValue, r, c);

                        if (!areas.ContainsKey(nodeValue))
                        {
                            areas.Add(nodeValue, 0);
                            
                        }

                        areas[nodeValue]++;
                        areasCount++;
                    }
                }
            }

            Console.WriteLine($"Areas: {areasCount}");

            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}'-> {area.Value}");
            }
        }

        private static void DFS(char parentValue, int row, int col)
        {
            if (OutOfBoundaries(row, col))
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            if (graph[row, col] != parentValue)
            {
                return;
            }

            visited[row, col] = true;

            DFS(parentValue, row - 1, col);
            DFS(parentValue, row + 1, col);
            DFS(parentValue, row, col - 1);
            DFS(parentValue, row, col + 1);
        }

        private static bool OutOfBoundaries(int row, int col)
        {
            return 
                row < 0 ||
                row >= graph.GetLength(0) ||
                col < 0 ||
                col >= graph.GetLength(1);
        }

        private static void FillMatrix(int rows, int cols)
        {
            for (int r = 0; r < rows; r++)
            {
                string rowElements = Console.ReadLine();
                for (int c = 0; c < cols; c++)
                {
                    graph[r, c] = rowElements[c];
                }
            }
        }
    }
}
