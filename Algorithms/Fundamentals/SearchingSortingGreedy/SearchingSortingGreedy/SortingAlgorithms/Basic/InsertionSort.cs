namespace SearchingSortingGreedy.SortingAlgorithms.Basic
{
    public static class InsertionSort
    {
        // Example:
        // int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        // Console.WriteLine(string.Join(" ", InsertionSort.Sort(arr)));
        public static int[] Sort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var j = i;

                while (j > 0 && numbers[j - 1] > numbers[j])
                {
                    (numbers[j - 1], numbers[j]) = (numbers[j], numbers[j - 1]);
                    j--;
                }
            }

            return numbers;
        }
    }
}
