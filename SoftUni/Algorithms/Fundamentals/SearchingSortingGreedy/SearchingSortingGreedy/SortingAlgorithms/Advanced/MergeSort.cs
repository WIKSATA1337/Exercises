namespace SearchingSortingGreedy.SortingAlgorithms.Advanced
{
    public static class MergeSort
    {
        public static int[] Sort(int[] numbers)
        {
            return MS(numbers);
        }

        private static int[] MS(int[] numbers)
        {
            if (numbers.Length <= 1)
            {
                return numbers;
            }

            int[] left = numbers.Take(numbers.Length / 2).ToArray();
            int[] right = numbers.Skip(numbers.Length / 2).ToArray();

            return Merge(MS(left), MS(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] merged = new int[left.Length + right.Length];

            int mergedIdx = 0;
            int leftIdx = 0;
            int rightIdx = 0;

            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx])
                {
                    merged[mergedIdx++] = left[leftIdx++];
                }
                else
                {
                    merged[mergedIdx++] = right[rightIdx++];
                }
            }

            for (int i = leftIdx; i < left.Length; i++)
            {
                merged[mergedIdx++] = left[i];
            }

            for (int i = rightIdx; i < right.Length; i++)
            {
                merged[mergedIdx++] = right[i];
            }

            return merged;
        }
    }
}
