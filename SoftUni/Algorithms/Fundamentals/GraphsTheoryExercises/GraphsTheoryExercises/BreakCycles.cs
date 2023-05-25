namespace GraphsTheoryExercises
{
    public class Edge
    {
        public Edge(string first, string second)
        {
            First = first;
            Second = second;
        }

        public string First { get; set; }
        public string Second { get; set; }

        public override string ToString()
        {
            return $"{First} - {Second}";
        }
    }

    public static class BreakCycles
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;

        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var node = data[0];
                var children = data[1].Split(' ').ToList();
                    
                graph[node] = children;

                foreach (var child in children)
                {
                    edges.Add(new Edge(node, child));
                }
            }

            edges = edges
                .OrderBy(e => e.First)
                .ThenBy(e => e.Second)
                .ToList();

            var removedEdges = new List<Edge>();

            foreach (var edge in edges)
            {
                var removed =
                    graph[edge.First].Remove(edge.Second) &&
                    graph[edge.Second].Remove(edge.First);

                if (!removed)
                {
                    continue;
                }

                if (BFS(edge.First, edge.Second))
                {
                    removedEdges.Add(edge);
                    continue;
                }

                graph[edge.First].Add(edge.Second);
                graph[edge.Second].Add(edge.First);
            }

            Console.WriteLine($"\nEdges to remove: {removedEdges.Count}");

            Console.WriteLine(string.Join('\n', removedEdges));
        }

        private static bool BFS(string start, string dest)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(start);

            var visited = new HashSet<string> { start };

            while (queue.Any())
            {
                var node = queue.Dequeue();

                if (node == dest)
                {
                    return true;
                }

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            return false;
        }
    }
}
