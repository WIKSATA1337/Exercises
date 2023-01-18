namespace SearchingSortingGreedy.SortingAlgorithms.Basic
{
    public static class BubbleSort
    {
        // Examples:
        // int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        // Console.WriteLine(string.Join(" ", BubbleSort.Sort(arr)));
        public static int[] Sort(int[] numbers)
        {
            return Result(numbers);
        }

        private static int[] Result(int[] numbers)
        {
            var sortedCount = 0;
            bool isSorted = false;

            while (!isSorted && sortedCount != numbers.Length)
            {
                isSorted = true;

                for (int j = 1; j < numbers.Length - sortedCount; j++)
                {
                    int i = j - 1;

                    if (numbers[i] > numbers[j])
                    {
                        (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
                        isSorted = false;
                    }
                }

                sortedCount++;
            }

            return numbers;
        }
    }
}
