public static class LinearSearch
{
    // Returns true or false, depending on if the number is in the array.
    public static bool Run(int[] numbers, int findNum)
    {
        if (numbers.Length == 0)
        {
            throw new InvalidOperationException("Numbers length must be greater than 0.");
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == findNum)
            {
                return true;
            }
        }

        return false;
    }
}