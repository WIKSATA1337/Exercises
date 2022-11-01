using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int row = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(row))
                {
                    dict[row] = 0;
                }

                dict[row]++;
            }

            foreach (var couple in dict)
            {
                if (couple.Value % 2 == 0)
                {
                    Console.WriteLine(couple.Key);
                }
            }
        }
    }
}
