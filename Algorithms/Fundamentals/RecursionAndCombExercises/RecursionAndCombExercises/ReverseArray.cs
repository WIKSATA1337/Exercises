namespace RecursionAndCombExercises
{
    public static class ReverseArray
    {
        public static void Run<T>(T[] array)
        {
            Reverse(array, 0);
        }

        private static void Reverse<T>(T[] arr, int idx)
        {
            if (idx >= arr.Length)
            {
                return;
            }

            Reverse<T>(arr, idx + 1);
            Console.Write($"{arr[idx]} ");
        }
    }
}
