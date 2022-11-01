using System;
using System.Linq;

namespace PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxLength = int.Parse(Console.ReadLine());

            Predicate<string> predicate = name => name.Length <= maxLength;

            Console.WriteLine(String.Join('\n', Console.ReadLine()
                .Split()
                .Where(name => predicate(name))));
        }
    }
}
