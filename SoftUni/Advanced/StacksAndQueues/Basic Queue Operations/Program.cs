using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            List<int> nsx = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> stackItems = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < nsx[0]; i++)
            {
                queue.Enqueue(stackItems[i]);
            }

            for (int i = 0; i < nsx[1]; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(nsx[2]))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
