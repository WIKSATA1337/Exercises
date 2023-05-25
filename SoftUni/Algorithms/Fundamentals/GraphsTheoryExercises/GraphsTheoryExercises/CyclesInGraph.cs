namespace GraphsTheoryExercises
{
    public static class CyclesInGraph
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;
        public static void Run()
        {
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] data = command.Split('-');

                if (!graph.ContainsKey(data[0]))
                {
                    graph.Add(data[0], new List<string>());
                }

                if (!graph.ContainsKey(data[1]))
                {
                    graph.Add(data[1], new List<string>());
                }

                graph[data[0]].Add(data[1]);
            }

            foreach (var node in graph.Keys)
            {
                try
                {
                    DFS(node);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Acyclic: No");
                    return;
                }   
            }

            Console.WriteLine("Acyclic: Yes");
        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException();
            }

            if (visited.Contains(node))
            {
                return;
            }   

            visited.Add(node);
            cycles.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycles.Remove(node);
        }
    }
}
