namespace Combinatorics
{
    public static class Permutations
    {
        private static string[] elements;

        // Examples:
        // elements = new string[] { "A", "B", "C" };
        // elements = new string[] { "A", "B", "C", "E", "F" };
        // elements = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
        // "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        public static void Run(string[] items, bool withRepetition)
        {
            elements = items;

            if (withRepetition)
            {
                WithRepetition(0);
            }
            else
            {
                WithoutRepetition(0);
            }
        }

        private static void WithRepetition(int idx)
        {
            if (idx >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            WithRepetition(idx + 1);

            for (int i = idx + 1; i < elements.Length; i++)
            {
                Swap(idx, i);
                WithRepetition(idx + 1);
                Swap(idx, i);
            }
        }

        private static void WithoutRepetition(int idx)
        {
            if (idx >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            WithoutRepetition(idx + 1);

            HashSet<string> used = new HashSet<string> { elements[idx] };

            for (int i = idx + 1; i < elements.Length; i++)
            {
                if (!used.Contains(elements[i]))
                {
                    Swap(idx, i);
                    WithoutRepetition(idx + 1);
                    Swap(idx, i);

                    used.Add(elements[i]);
                }
            }
        }

        private static void Swap(int first, int second)
        {
            (elements[second], elements[first]) = (elements[first], elements[second]);
        }
    }
}
