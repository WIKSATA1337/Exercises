using System.Dynamic;

namespace GraphsTheoryExercises
{
    public class ConstructionEdge
    {
        public int First { get; set; }
        public int Second { get; set; }

        public override string ToString()
        {
            return $"{First} {Second}";
        }
    }
    public static class RoadReconstruction
    {
        private static List<int>[] graph;
        private static List<ConstructionEdge> edges;
        private static bool[] visited;

        public static void Run()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());

            graph = new List<int>[nodesCount];
            edges = new List<ConstructionEdge>();

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);

                edges.Add(new ConstructionEdge()
                {
                    First = firstNode,
                    Second = secondNode
                });
            }

            Console.WriteLine();
            Console.WriteLine("Important streets:");

            foreach (var edge in edges)
            {
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                visited = new bool[graph.Length];

                DFS(0);

                if (visited.Contains(false))
                {
                    var newEdge = new ConstructionEdge()
                    {
                        First = Math.Min(edge.First, edge.Second),
                        Second = Math.Max(edge.First, edge.Second)
                    };

                    Console.WriteLine(newEdge);
                }

                graph[edge.First].Add(edge.Second);
                graph[edge.Second].Add(edge.First);
            }
        }

        private static void DFS(int node)
        {
            if (visited[node]) return;

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }
    }
}
