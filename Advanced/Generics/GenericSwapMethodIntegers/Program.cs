using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<int> strings = new List<int>();

            for (int i = 0; i < count; i++)
            {
                strings.Add(int.Parse(Console.ReadLine()));
            }

            Swapper<int> swapper = new Swapper<int>();

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            swapper.Swap(strings, input[0], input[1]);
        }
    }
    public class Swapper<T>
    {
        public void Swap(List<T> list, int firstIndex, int secondIndex)
        {
            T tempElement = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = tempElement;

            PrintList(list);
        }

        private void PrintList(List<T> list)
        {
            foreach (var element in list)
            {
                Console.WriteLine($"{element.GetType()}: {element}");
            }
        }
    }
}
