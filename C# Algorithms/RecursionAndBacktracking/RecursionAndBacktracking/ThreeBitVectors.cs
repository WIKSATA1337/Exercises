namespace RecursionAndBacktracking
{
    public static class ThreeBitVectors
    {
        public static void Run(int vectorLength)
        {
            int[] arr = new int[vectorLength];

            Solve(arr, 0);
        }

        private static void Solve(int[] arr, int idx)
        {
            if (idx >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[idx] = i;

                Solve(arr, idx + 1);
            }
        }
    }
}
