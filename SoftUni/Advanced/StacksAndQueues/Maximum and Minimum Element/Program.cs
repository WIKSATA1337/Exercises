using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int queriesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < queriesCount; i++)
            {
                int[] command = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (command[0] == 1)
                {
                    stack.Push(command[1]);
                }
                else if (command[0] == 2)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    stack.Pop();
                }
                else if (command[0] == 3)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine(stack.Max());
                }
                else if (command[0] == 4)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
