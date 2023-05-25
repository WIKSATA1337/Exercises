namespace DynamicProgrammingExercises
{
    public static class BinomialCoefficients
    {
        private static Dictionary<string, long> cache;

        public static void Run()
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            cache = new Dictionary<string, long>();

            Console.WriteLine(BC(row, col));
        }

        private static long BC(int row, int col)
        {
            if (col == 0 || col == row)
            {
                return 1;
            }

            var key = $"{row}-{col}";

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            cache[key] = BC(row - 1, col - 1) + BC(row - 1, col);

            return cache[key];
        }
    }
}
