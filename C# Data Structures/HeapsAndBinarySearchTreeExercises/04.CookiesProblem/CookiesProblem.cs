using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            var priorityQueue = new OrderedBag<int>();

            priorityQueue.AddMany(cookies);

            int currentMinSweetness = priorityQueue[0];
            int stepsCount = 0;

            while (currentMinSweetness < minSweetness && priorityQueue.Count > 1)
            {
                int leastSweetCookie = priorityQueue.RemoveFirst();
                int secondLeastSweetCookie = priorityQueue.RemoveFirst();

                int newCookie = leastSweetCookie + (2 * secondLeastSweetCookie);

                priorityQueue.Add(newCookie);
                currentMinSweetness = priorityQueue[0];
                stepsCount++;
            }

            return currentMinSweetness < minSweetness ? -1 : stepsCount;
        }
    }
}
