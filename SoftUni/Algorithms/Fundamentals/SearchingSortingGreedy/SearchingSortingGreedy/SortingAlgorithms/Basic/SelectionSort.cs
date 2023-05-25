namespace SearchingSortingGreedy.SortingAlgorithms.Basic
{
    public static class SelectionSort
    {
        // Examples:
        // int[] arr = new int[]
        //     { 9, 24, 5, 10, 2, 6, 66, 3, 7, 1, 44, 9, 8, 22, 4 };
        // int[] arr2 = new int[]
        //     { 66, 3, 7, 1, 44, 9, 8, 22, 4, 9, 24, 5, 10, 2, 6 };

        // int[] result = SelectionSort.Sort(arr);
        // int[] result2 = SelectionSort.Sort(arr2, true);
        public static int[] Sort(int[] numbers, bool reverse = false)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int sortWay = reverse == true ? 0 : i;
                for (int j = sortWay; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
                    }
                }
            }

            return numbers;
        }
    }
}
