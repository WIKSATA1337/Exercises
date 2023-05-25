namespace GraphsTheory
{
    public static class SourceRemoval
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;

        public static void Run()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount);

            dependencies = ExtractDependencies();

            var sorted = new List<string>();

            while (dependencies.Any())
            {
                var nodeToRemove = dependencies.FirstOrDefault(d => d.Value == 0).Key;

                if (nodeToRemove is null)
                {
                    break;
                }

                dependencies.Remove(nodeToRemove);
                sorted.Add(nodeToRemove);

                foreach (var child in graph[nodeToRemove])
                {
                    dependencies[child]--;
                }
            }

            Console.WriteLine();

            if (dependencies.Count > 0)
            {
                Console.WriteLine("Invalid topological sorting!");
            }
            else
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
            }
        }

        private static Dictionary<string, int> ExtractDependencies()
        {
            var result = new Dictionary<string, int>();

            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;

                if (!result.ContainsKey(node))
                {
                    result.Add(node, 0);
                }

                foreach (var child in children)
                {
                    if (!result.ContainsKey(child))
                    {
                        result.Add(child, 1);
                    }
                    else
                    {
                        result[child]++;
                    }
                }
            }

            return result;
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
