namespace SearchingSortingGreedy.Other
{
    // Greedy Algorithm
    public static class SumOfCoins
    {
        // Example:
        // int[] coins = Console.ReadLine().Split(' ')
        //    .Select(int.Parse).OrderByDescending(n => n).ToArray();
        // int targetSum = int.Parse(Console.ReadLine());
        // SumOfCoins.Run(coins, targetSum);

        private static Dictionary<int, int> coinsUsed;
        public static void Run(int[] coins, int targetSum)
        {
            coinsUsed = new Dictionary<int, int>();

            int idx = 0;
            int currSum = 0;

            while (currSum != targetSum)
            {
                if (currSum + coins[idx] <= targetSum)
                {
                    currSum += coins[idx];
                    if (!coinsUsed.ContainsKey(coins[idx]))
                    {
                        coinsUsed.Add(coins[idx], 1);
                    }
                    else
                    {
                        coinsUsed[coins[idx]]++;
                    }
                }
                else
                {
                    idx++;
                }
            }

            foreach (var coin in coinsUsed)
            {
                Console.WriteLine($"{coin.Key} used {coin.Value} times.");
            }
        }
    }
}
