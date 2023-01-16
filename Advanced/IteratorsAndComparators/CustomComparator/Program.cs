using System;
using System.Linq;

namespace CustomComparator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> Sorter = (firstNumber, secondNumber) =>
            {
                if (firstNumber % 2 == 0 && secondNumber % 2 != 0)
                {
                    return -1;
                }
                
                if (firstNumber % 2 != 0 && secondNumber % 2 == 0)
                {
                    return 1;
                }

                return firstNumber.CompareTo(secondNumber);
            };

            int[] numbersArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbersArray, (first, second) => Sorter(first, second));

            Console.WriteLine(string.Join(" ", numbersArray));
        }
    }
}
