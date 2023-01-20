namespace GraphsTheory
{
    public static class GraphBFS
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;

        public static void Run()
        {
            visited = new HashSet<int>();

            graph = new Dictionary<int, List<int>>
            {
                {7, new List<int> {19, 21, 14} },
                {19, new List<int> {1, 12, 31, 21} },
                {1, new List<int> {7} },
                {31, new List<int> {21} },
                {21, new List<int> {14} },
                {23, new List<int> {21} },
                {14, new List<int> {23, 6} },
                {12, new List<int>() },
                {6, new List<int>() },
            };

            foreach (var node in graph.Keys)
            {
                BFS(node);
            }
        }

        private static void BFS(int startNode)
        {
            if (visited.Contains(startNode))
            {
                return;
            }

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Any())
            {
                var node = queue.Dequeue();

                Console.WriteLine(node);

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }
        }
    }
}
