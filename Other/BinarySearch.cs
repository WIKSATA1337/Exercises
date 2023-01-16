public static class BinarySearch
{
    public static bool Run(int[] numbers, int findNum)
    {
        if (numbers.Length == 0)
        {
            throw new InvalidOperationException("Numbers length must be greater than 0.");
        }

        // Extra:
        // If the number we are looking for is smaller or larger than the first or last element,
        // we return false;
        if (findNum < numbers[0] || findNum > numbers[numbers.Length - 1])
        {
            return false;
        }

        int lo = 0;
        int hi = numbers.Length;

        while (lo < hi)
        {
            int mid = lo + (hi - lo) / 2;
            int value = numbers[mid];

            if (value == findNum)
            {
                return true;
            }
            else if (value > findNum)
            {
                hi = mid;
            }
            else
            {
                lo = mid + 1;
            }
        }

        return false;
    }
}