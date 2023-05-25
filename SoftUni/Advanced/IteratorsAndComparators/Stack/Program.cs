using System;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                .Split(", ")
                .ToArray();

            elements[0] = elements[0].Replace("Push ", "");

            Stack<string> stack = new Stack<string>(elements);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Pop")
                {
                    stack.Pop();
                }
                else
                {
                    var splitted = command.Split();

                    stack.Push(splitted[1]);
                }
            }

            stack.ForEach();
            stack.ForEach();
        }
    }
}
