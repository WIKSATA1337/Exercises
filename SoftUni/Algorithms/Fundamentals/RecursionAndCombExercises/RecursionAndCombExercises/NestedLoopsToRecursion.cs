namespace RecursionAndCombExercises
{
    public static class NestedLoopsToRecursion
    {
        private static int[] elements;
        public static void Run(int loops)
        {
            elements = new int[loops];

            Loop(0);
        }

        private static void Loop(int idx)
        {
            if (idx >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            for (int i = 1; i <= elements.Length; i++)
            {
                elements[idx] = i;
                Loop(idx + 1);
            }
        }
    }
}
