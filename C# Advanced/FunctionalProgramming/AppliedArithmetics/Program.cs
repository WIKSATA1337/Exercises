using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AppliedArithmetics
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            Action<string> action = cmd =>
            {
                switch (cmd)
                {
                    case "add":
                        input = input.Select(num => ++num).ToList();
                        break;
                    case "multiply":
                        input = input.Select(num => num *= 2).ToList();
                        break;
                    case "subtract":
                        input = input.Select(num => --num).ToList();
                        break;
                    case "print":
                        Console.WriteLine(String.Join(' ', input));
                        break;
                }
            };

            while (command != "end")
            {
                action(command);

                command = Console.ReadLine();
            }
        }
    }
}
