namespace RecursionAndBacktracking
{
    public static class RecursiveFibonacci
    {
        public static int Run(int n)
        {
            return Fibonacci(n);
        }

        private static int Fibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
