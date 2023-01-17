namespace RecursionAndCombExercises
{
    public static class SchoolTeams
    {
        public static void Run()
        {
            var girls = Console.ReadLine().Split(", ");
            var girlsComb = new string[3];
            var girlsCombs = new List<string[]>();

            var boys = Console.ReadLine().Split(", ");
            var boysComb = new string[2];
            var boysCombs = new List<string[]>();

            GenCombs(0, 0, girls, girlsComb, girlsCombs);
            GenCombs(0, 0, boys, boysComb, boysCombs);

            PrintResult(girlsCombs, boysCombs);
        }

        private static void PrintResult(List<string[]> girlsCombs, List<string[]> boysCombs)
        {
            foreach (var girlComb in girlsCombs)
            {
                foreach (var boyComb in boysCombs)
                {
                    Console.WriteLine($"{string.Join(", ",girlComb)}, " +
                        $"{string.Join(", ", boyComb)}");
                }
            }
        }

        private static void GenCombs(int idx, int start, string[] elements,
            string[] combs, List<string[]> results)
        {
            if (idx >= combs.Length)
            {
                results.Add(combs.ToArray());
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combs[idx] = elements[i];

                GenCombs(idx + 1, i + 1, elements, combs, results);
            }
        }
    }
}
