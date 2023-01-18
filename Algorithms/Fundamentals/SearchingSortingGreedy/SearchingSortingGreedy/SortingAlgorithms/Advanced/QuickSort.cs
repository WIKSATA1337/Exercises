namespace SearchingSortingGreedy.SortingAlgorithms.Advanced
{
    public static class QuickSort
    {
        // Example:
        // int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        // QuickSort.Sort(arr);
        // Console.WriteLine(string.Join(" ", arr));
        public static void Sort(int[] numbers)
        {
            Solve(numbers, 0, numbers.Length - 1);
        }

        private static void Solve(int[] numbers, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = start;
            int left = start + 1;
            int right = end;

            while (left <= right)
            {
                if (numbers[left] > numbers[pivot] &&
                    numbers[right] < numbers[pivot])
                {
                    (numbers[left], numbers[right]) = (numbers[right], numbers[left]);
                }

                if (numbers[left] <= numbers[pivot])
                {
                    ++left;
                }

                if (numbers[right] >= numbers[pivot])
                {
                    --right;
                }
            }

            (numbers[pivot], numbers[right]) = (numbers[right], numbers[pivot]);

            if (right - 1 - start < end - (right + 1))
            {
                Solve(numbers, start, right - 1);
                Solve(numbers, right + 1, end);
            }
            else
            {
                Solve(numbers, right + 1, end);
                Solve(numbers, start, right - 1);
            }
        }
    }
}
