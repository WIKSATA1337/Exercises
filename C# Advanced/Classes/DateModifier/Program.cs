using System;
using System.Linq;

namespace DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] inputOne = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            int[] inputTwo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            DateTime dateOne = new DateTime(inputOne[0], inputOne[1], inputOne[2]);
            DateTime dateTwo = new DateTime(inputTwo[0], inputTwo[1], inputTwo[2]);

            DateModifier dateModifier = new DateModifier();

            Console.WriteLine(dateModifier.Difference(dateOne, dateTwo));
        }
    }
}
