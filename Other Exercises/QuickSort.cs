public static class QuickSort
{
    // Example:
    // new int[] { 9, 3, 7, 4, 69, 420, 42 }
    public static int[] Run(int[] numbers)
    {
        Sort(numbers, 0, numbers.Length - 1);

        return numbers;
    }

    private static void Sort(int[] arr, int lo, int hi)
    {
        if (lo >= hi)
        {
            return;
        }

        int pivotIdx = Partition(arr, lo, hi);

        Sort(arr, lo, pivotIdx - 1);
        Sort(arr, pivotIdx + 1, hi);
    }

    private static int Partition(int[] arr, int lo, int hi)
    {
        int pivot = arr[hi];

        int idx = lo - 1;

        for (int i = lo; i < hi; ++i)
        {
            if (arr[i] <= pivot)
            {
                idx++;
                // Swapping with tuples
                (arr[idx], arr[i]) = (arr[i], arr[idx]);
            }
        }

        idx++;

        arr[hi] = arr[idx];
        arr[idx] = pivot;

        return idx;
    }
}