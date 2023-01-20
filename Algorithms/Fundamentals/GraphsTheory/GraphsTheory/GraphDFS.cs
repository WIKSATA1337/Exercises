namespace GraphsTheory
{
    public static class GraphDFS
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;
        public static void Run()
        {
            visited = new HashSet<int>();
            graph = new Dictionary<int, List<int>>
            {
                {1, new List<int> {19, 21, 14} },
                {19, new List<int> {7, 12, 31, 21} },
                {7, new List<int> {1} },
                {31, new List<int> {21} },
                {21, new List<int> {14} },
                {23, new List<int> {21} },
                {14, new List<int> {6, 23} },
                {12, new List<int>() },
                {6, new List<int>() },
            };

            foreach (var node in graph.Keys)
            {
                DFS(node);
            }
        }

        private static void DFS(int node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            Console.WriteLine(node);
        }
    }
}
