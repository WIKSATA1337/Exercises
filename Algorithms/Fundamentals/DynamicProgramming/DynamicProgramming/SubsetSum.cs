namespace DynamicProgramming
{
    public static class SubsetSum
    {
        public static void Run()
        {
            int[] nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int target = int.Parse(Console.ReadLine());

            var possibleSums = Get(nums);

            if (possibleSums.ContainsKey(target))
            {
                var subset = FindSubset(possibleSums, target);
                Console.WriteLine(string.Join(" ", subset));
                return;
            }

            Console.WriteLine("No matching sum was found.");
        }

        private static ICollection<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();

            while (target > 0)
            {
                var num = sums[target];

                target -= num;

                subset.Add(num);
            }

            return subset;
        }

        private static Dictionary<int, int> Get(int[] nums)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var num in nums)
            {
                var currSums = sums.Keys.ToArray();

                foreach (var sum in currSums)
                {
                    var newSum = sum + num;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    sums.Add(newSum, num);
                }
            }

            return sums;
        }
    }
}
