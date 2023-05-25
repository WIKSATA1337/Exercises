namespace DynamicProgramming
{
    // Fibonacci with memoization
    public static class Fibonacci
    {
        private static Dictionary<long, long> cache;

        public static long Run()
        {
            int n = int.Parse(Console.ReadLine());

            cache = new Dictionary<long, long>
            {
                { 0, 0 },
                { 1, 1 },
                { 2, 1 }
            };

            return Fib(n);
        }

        private static long Fib(int n)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            cache[n] = Fib(n - 1) + Fib(n - 2);

            return cache[n];
        }
    }
}