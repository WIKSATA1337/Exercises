using System;
using System.Collections.Generic;

namespace SetsAndDictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                set.Add(Console.ReadLine());
            }

            Console.WriteLine(String.Join("\n", set));
        }
    }
}
