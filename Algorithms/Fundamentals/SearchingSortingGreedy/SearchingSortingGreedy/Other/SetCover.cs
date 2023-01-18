namespace SearchingSortingGreedy.Other
{
    public static class SetCover
    {
        // Example:
        // SetCover.Run();
        public static void Run()
        {
            HashSet<int> universe = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToHashSet();

            int setsCount = int.Parse(Console.ReadLine());

            List<int[]> sets = new List<int[]>();

            for (int i = 0; i < setsCount; i++)
            {
                sets.Add(Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray());
            }

            var selectedSets = new List<int[]>();

            while (universe.Count > 0)
            {
                var set = sets
                    .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                    .FirstOrDefault();

                selectedSets.Add(set);

                sets.Remove(set);

                foreach (var element in set)
                {
                    universe.Remove(element);
                }
            }

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (var set in selectedSets)
            {
                Console.WriteLine(string.Join(", ", set));
            }
        }
    }
}
