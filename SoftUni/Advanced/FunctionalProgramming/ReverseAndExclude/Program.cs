using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int divider = int.Parse(Console.ReadLine());

            list = list.Where(num => num % divider != 0).ToList();

            Console.WriteLine(String.Join(' ', list));
        }
    }
}
