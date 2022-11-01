using Generics;
using System;

namespace GenericBoxOfIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>();
                box.Value = input;

                Console.WriteLine(box.ToString());
            }
        }
    }
}
