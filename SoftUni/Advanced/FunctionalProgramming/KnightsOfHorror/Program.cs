using System;
using System.Linq;

namespace KnightsOfHorror
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            Action<string> action = item => Console.WriteLine("Sir " + item);

            input.ToList().ForEach(elem => action(elem));
        }
    }
}
