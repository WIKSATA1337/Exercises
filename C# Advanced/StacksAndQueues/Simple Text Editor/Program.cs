using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            int operationsCount = int.Parse(Console.ReadLine());
            string result = "";

            stack.Push(result);

            for (int i = 0; i < operationsCount; i++)
            {
                string[] command = Console.ReadLine()
                    .Split()
                    .ToArray();

                if (command[0] == "1")
                {
                    // appends string
                    result += command[1];
                    stack.Push(result);
                }
                else if (command[0] == "2")
                {
                    // erases the last count elements
                    result = result.Substring(0, result.Length - int.Parse(command[1]));
                    stack.Push(result);
                }
                else if (command[0] == "3")
                {
                    // returns the element at given position
                    Console.WriteLine(result[int.Parse(command[1]) - 1]);
                }
                else if (command[0] == "4")
                {
                    // UNDO
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    stack.Pop();
                    result = stack.Peek();
                }
            }
        }
    }
}