namespace DynamicProgrammingExercises
{
    public static class DividingPresents
    {
        public static void Run()
        {
            var presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var allSums = FindAllSums(presents);

            var totalSum = presents.Sum();
            var firstGuySum = totalSum / 2;

            while (true)
            {
                if (allSums.ContainsKey(firstGuySum))
                {
                    break;
                }

                firstGuySum--;
            }

            Console.WriteLine($"Difference: {Math.Max(firstGuySum, totalSum - firstGuySum) - Math.Min(totalSum - firstGuySum, firstGuySum)}");

            Console.WriteLine($"Alan: {firstGuySum} Bob: {totalSum - firstGuySum}");
        }

        private static Dictionary<int, int> FindAllSums(int[] elements)
        {
            var sums = new Dictionary<int, int>() { { 0, 0 } };

            foreach (var element in elements)
            {
                var currSums = sums.Keys.ToArray();

                foreach (var sum in currSums)
                {
                    var newSum = sum + element;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    sums.Add(newSum, element);
                }
            }

            return sums;
        }
    }
}
