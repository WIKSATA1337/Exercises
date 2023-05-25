public static class BubbleSort
{
    public static void Run(ref List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            throw new InvalidOperationException("Numbers count must be greater than 0.");
        }

        for (int i = 0; i < numbers.Count; i++)
        {
            for (int j = 0; j < numbers.Count - i - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    int temp = numbers[j + 1];
                    numbers[j + 1] = numbers[j];
                    numbers[j] = temp;
                }
            }
        }
    }
}