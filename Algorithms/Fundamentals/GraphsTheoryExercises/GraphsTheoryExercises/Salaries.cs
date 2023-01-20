namespace GraphsTheoryExercises
{
    public static class Salaries
    {
        private static List<int>[] graph;
        private static Dictionary<int, int> visited;

        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            visited = new Dictionary<int, int>();

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();

                var children = Console.ReadLine();

                for (int child = 0; child < children.Length; child++)
                {
                    if (children[child] == 'Y')
                    {
                        graph[node].Add(child);
                    }
                }
            }

            int salaries = 0;

            for (int node = 0; node < graph.Length; node++)
            {
                salaries += DFS(node);
            }

            Console.WriteLine(salaries);
        }

        private static int DFS(int node)
        {
            if (visited.ContainsKey(node))
            {
                return visited[node];
            }

            var salary = 0;

            if (!graph[node].Any())
            {
                salary = 1;
            }
            else
            {
                foreach (var child in graph[node])
                {
                    salary += DFS(child);
                }
            }

            visited[node] = salary;
            return salary;
        }
    }
}
