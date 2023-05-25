namespace Combinatorics
{
    public static class Variations
    {
        private static string[] elements;
        private static string[] variations;
        private static bool[] used;

        // Examples:
        // Variations.Run(new string[] { "A", "B", "C" }, 2, true);
        public static void Run(string[] items, int slots, bool withRepetition)
        {
            elements = items;
            variations = new string[slots];
            used = new bool[elements.Length];

            if (withRepetition)
            {
                WithRepetition(0);
            }
            else
            {
                WithoutRepetition(0);
            }
        }

        public static void WithoutRepetition(int idx)
        {
            if (idx >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[idx] = elements[i];

                    WithoutRepetition(idx + 1);

                    used[i] = false;
                }
            }
        }

        public static void WithRepetition(int idx)
        {
            if (idx >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variations[idx] = elements[i];

                WithRepetition(idx + 1);
            }
        }
    }
}
