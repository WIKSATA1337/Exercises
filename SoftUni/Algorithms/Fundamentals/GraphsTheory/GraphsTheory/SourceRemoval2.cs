namespace GraphsTheory
{
    public static class SourceRemoval2
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;
        private static Stack<string> sorted;

        public static void Run()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount);

            visited = new HashSet<string>();
            cycles = new HashSet<string>();
            sorted = new Stack<string>();

            foreach (var node in graph.Keys)
            {
                try
                {
                    DFS(node);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException("Invalid topological sorting!");
            }

            if (visited.Contains(node))
            {
                return;
            }

            cycles.Add(node);
            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            sorted.Push(node);
            cycles.Remove(node);
        }

        private static Dictionary<string, List<string>> ReadGraph(int nodesCount)
        {
            var result = new Dictionary<string, List<string>>();

            for (int node = 0; node < nodesCount; node++)
            {
                var splitted = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => e.Trim())
                    .ToArray();

                var key = splitted[0];

                if (splitted.Length == 1)
                {
                    result[key] = new List<string>();
                }
                else
                {
                    var children = splitted[1]
                    .Split(", ")
                    .ToList();

                    result[key] = children;
                }
            }

            return result;
        }
    }
}
