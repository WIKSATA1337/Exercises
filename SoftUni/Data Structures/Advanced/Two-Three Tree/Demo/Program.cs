using _01.Two_Three;
using System;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            string[] arr = { "F", "C", "G", "A", "B", "D", "E", "K", "I", "G", "H", "J", "K" };
            var tree = new TwoThreeTree<string>();
            foreach (var item in arr)
            {
                tree.Insert(item);
            }

            Console.WriteLine(tree.ToString());
        }
    }
}
