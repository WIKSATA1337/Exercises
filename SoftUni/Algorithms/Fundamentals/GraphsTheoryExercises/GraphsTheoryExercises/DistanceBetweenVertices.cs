namespace GraphsTheoryExercises
{
    public static class DistanceBetweenVertices
    {
        private static Dictionary<int, List<int>> graph;
        private static List<string> results;
        public static void Run()
        {
            results = new List<string>();
            graph = new Dictionary<int, List<int>>();

            int nodes = int.Parse(Console.ReadLine());
            int pairs = int.Parse(Console.ReadLine());

            for (int i = 0; i < nodes; i++)
            {
                var data = Console.ReadLine()
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var newNode = int.Parse(data[0]);

                if (data.Length == 1)
                {
                    graph[newNode] = new List<int>();
                }
                else
                {
                    var children = data[1]
                        .Split(' ')
                        .Select(int.Parse)
                        .ToList();

                    graph[newNode] = children;
                }
            }

            for (int i = 0; i < pairs; i++)
            {
                var pair = Console.ReadLine()
                    .Split('-')
                    .Select(int.Parse)
                    .ToArray();

                var start = pair[0];
                var dest = pair[1];

                var steps = BFS(start, dest);

                results.Add($"{{{start}, {dest}}} -> {steps}");
            }

            Console.WriteLine(string.Join("\n", results));
        }

        private static int BFS(int start, int destination)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            var visited = new HashSet<int> { start };
            var parents = new Dictionary<int, int> { { start, -1 } };

            while (queue.Any())
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return GetSteps(parents, destination);
                }

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                        parents[child] = node;
                    }
                }
            }

            return -1;
        }

        private static int GetSteps(Dictionary<int, int> parents, int destination)
        {
            int steps = 0;
            var node = destination;

            while (node != -1)
            {
                node = parents[node];
                steps++;
            }

            return steps - 1;
        }
    }
}
