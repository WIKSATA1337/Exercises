namespace RecursionAndBacktracking
{
    public static class RecursiveArraySum
    {
        public static int Run(int[] arr)
        {
            return RecursiveSum(arr);
        }

        private static int RecursiveSum(int[] arr)
        {
            if (arr.Length == 1)
            {
                return arr[0];
            }

            return arr[0] + RecursiveSum(arr.Skip(1).ToArray());
        }
    }
}
