using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            string parentheses = Console.ReadLine();

            foreach (var symbol in parentheses)
            {
                if (stack.Any())
                {
                    char check = stack.Peek();

                    if (check == '{' && symbol == '}')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (check == '[' && symbol == ']')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (check == '(' && symbol == ')')
                    {
                        stack.Pop();
                        continue;
                    }
                }

                stack.Push(symbol);
            }

            Console.WriteLine(stack.Any() ? "NO" : "YES");
        }
    }
}
