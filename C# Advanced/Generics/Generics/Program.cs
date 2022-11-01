using System;

namespace Generics
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                Box<string> box = new Box<string>();
                box.Value = input;

                Console.WriteLine(box.ToString());
            }
        }
    }
}
