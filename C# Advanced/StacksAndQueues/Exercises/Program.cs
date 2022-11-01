using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;

namespace Exercises
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

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
                stack.Push(stackItems[i]);
            }

            for (int i = 0; i < nsx[1]; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(nsx[2]))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
