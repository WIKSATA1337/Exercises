using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();
            List<int> result = new List<int>();

            for (int i = 0; i < sizes[0]; i++)
            {
                setOne.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < sizes[1]; i++)
            {
                setTwo.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var number in setOne)
            {
                if (setTwo.Contains(number))
                {
                    result.Add(number);
                }
            }

            Console.WriteLine(String.Join(' ', result));
        }
    }
}
