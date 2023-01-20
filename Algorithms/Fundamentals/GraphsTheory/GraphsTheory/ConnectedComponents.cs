namespace GraphsTheory
{
    public static class ConnectedComponents
    {
        private static List<int>[] graph;
        private static bool[] visited;

        public static void Run()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            graph = new List<int>[nodesCount];
            visited = new bool[nodesCount];

            for (int node = 0; node < nodesCount; node++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    var children = line
                        .Split(' ')
                        .Select(int.Parse)
                        .ToList();

                    graph[node] = children;
                }
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                List<int> comp = new List<int>();
                DFS(node, comp);

                Console.WriteLine($"Connected component: {string.Join(" ", comp)}");
            }
        }

        private static void DFS(int node, List<int> components)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, components);
            }

            components.Add(node);
        }
    }
}
