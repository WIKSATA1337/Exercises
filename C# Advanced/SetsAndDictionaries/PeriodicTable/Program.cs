using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string[] row = Console.ReadLine().Split(' ');

                for (int j = 0; j < row.Length; j++)
                {
                    set.Add(row[j]);
                }
            }

            set = set.OrderBy(x => x).ToHashSet();

            Console.WriteLine(String.Join(' ', set));
        }
    }
}
