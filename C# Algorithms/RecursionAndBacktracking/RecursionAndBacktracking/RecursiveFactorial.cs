namespace RecursionAndBacktracking
{
    public static class RecursiveFactorial
    {
        public static int Run(int n)
        {
            return Factorial(n);
        }

        private static int Factorial(int n)
        {
            if (n <= 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
