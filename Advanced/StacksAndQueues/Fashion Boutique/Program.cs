using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            bool isDone = false;
            int usedRacksCount = 0;
            int sum = 0;

            int[] clothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            for (int i = 0; i < clothes.Length; i++)
            {
                stack.Push(clothes[i]);
            }

            for (int i = 0; i < clothes.Length; i++)
            {
                int currentNum = stack.Pop();

                if (sum + currentNum == rackCapacity)
                {
                    usedRacksCount++;
                    sum = 0;
                }
                else if (sum + currentNum > rackCapacity)
                {
                    usedRacksCount++;
                    sum = currentNum;
                }
                else
                {
                    sum += currentNum;
                }

                if (i == clothes.Length - 1 && sum != 0)
                {
                    sum = 0;
                    usedRacksCount++;
                }
            }

            Console.WriteLine(usedRacksCount);
        }
    }
}
