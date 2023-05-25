namespace Combinatorics
{
    public static class Combinations
    {
        private static string[] elements;
        private static string[] combinations;

        // Example:
        // Combinations.Run(new string[] {"A", "B", "C"}, 2, false);
        // Combinations.Run(new string[] {"A", "B", "C"}, 2, true);
        public static void Run(string[] items, int slots, bool withRepetition)
        {
            elements = items;
            combinations = new string[slots];

            if (withRepetition)
            {
                WithRepetition(0, 0);
            }
            else
            {
                WithoutRepetition(0, 0);
            }
        }

        private static void WithoutRepetition(int idx, int elemStartIdx)
        {
            if (idx >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elemStartIdx; i < elements.Length; i++)
            {
                combinations[idx] = elements[i];
                WithoutRepetition(idx + 1, i + 1);
            }
        }

        private static void WithRepetition(int idx, int elemStartIdx)
        {
            if (idx >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elemStartIdx; i < elements.Length; i++)
            {
                combinations[idx] = elements[i];
                WithRepetition(idx + 1, i);
            }
        }
    }
}
