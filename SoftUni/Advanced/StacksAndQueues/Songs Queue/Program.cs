using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            string[] firstSongs = Console.ReadLine()
                .Split(", ")
                .ToArray();

            for (int i = 0; i < firstSongs.Length; i++)
            {
                queue.Enqueue(firstSongs[i]);
            }

            while (queue.Any())
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    queue.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine(String.Join(", ", queue));
                }
                else
                {
                    command = command.Substring(4);
                    if (!queue.Contains(command))
                    {
                        queue.Enqueue(command);
                    }
                    else
                    {
                        Console.WriteLine($"{command} is already contained!");
                    }
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}