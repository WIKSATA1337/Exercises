using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int finish = int.Parse(Console.ReadLine());
            int[] divideNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> list = new List<int>();

            Predicate<int> predicate = num =>
            {
                int counter = 0;

                for (int i = 0; i < divideNums.Length; i++)
                {
                    if (num % divideNums[i] == 0)
                    {
                        counter++;
                    }
                }

                return counter == divideNums.Length ? true : false;
            };

            for (int i = 1; i <= finish; i++)
            {
                list.Add(i);
            }

            list = list.Where(n => predicate(n)).ToList();

            Console.WriteLine(String.Join(' ', list));
        }
    }
}
