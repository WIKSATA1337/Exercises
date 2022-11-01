using System;
using System.Linq;

namespace Action_Print
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            Action<string> action = item => Console.WriteLine(item);

            input.ToList().ForEach(elem => action(elem));
        }
    }
}
