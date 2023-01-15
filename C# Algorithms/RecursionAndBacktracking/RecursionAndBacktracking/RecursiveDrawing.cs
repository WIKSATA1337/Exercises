namespace RecursionAndBacktracking
{
    public static class RecursiveDrawing
    {
        public static void Run(int n)
        {
            Draw(n);
        }

        private static void Draw(int n)
        {
            if (n <= 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));

            Draw(n - 1);

            Console.WriteLine(new string('#', n));
        }
    }
}
