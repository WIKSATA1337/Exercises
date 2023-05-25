namespace SearchingSortingGreedy.Other
{
    public static class BinarySearch
    {
        public static int Search(int[] elements, int number)
        {
            // Returns the index of the element or -1.
            return GetResult(elements, number);
        }

        private static int GetResult(int[] elements, int number)
        {
            int lo = 0;
            int hi = elements.Length - 1;

            int idx = -1;

            while (idx < 0 && lo <= hi)
            {
                int mid = (hi + lo) / 2;

                if (elements[mid] == number)
                {
                    idx = mid;
                }
                else if (number > elements[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }

            return idx;
        }
    }
}
