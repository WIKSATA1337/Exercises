using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string option = Console.ReadLine();
            int optionNumber = option == "odd" ? 1 : 0;

            List<int> list = new List<int>();

            for (int i = listSize[0]; i <= listSize[1]; i++)
            {
                list.Add(i);
            }

            Predicate<int> evenOrOdd = x => {
                if (x < 0) {
                    return x % 2 == -1;
                }
                else
                {
                    return x % 2 == optionNumber;
                }
            };

            list = list.FindAll(evenOrOdd);
            
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
