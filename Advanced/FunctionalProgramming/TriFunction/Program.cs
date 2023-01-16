using System;
using System.Linq;

namespace TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int searchingNum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split();

            Func<string, bool> calc = name => name.ToCharArray()
                                                    .Select(letter => (int)letter)
                                                    .Sum() >= searchingNum;

            Console.WriteLine(String.Join(' ', names.Where(calc).ToList().FirstOrDefault()));
        }
    }
}
