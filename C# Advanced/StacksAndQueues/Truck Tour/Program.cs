using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<PetrolPump> queue = new Queue<PetrolPump>();
            int petrolsCount = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 0; i < petrolsCount; i++)
            {
                int[] command = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                PetrolPump pump = new PetrolPump(command[0], command[1]);
                queue.Enqueue(pump);
            }

            for (int i = 0; i < queue.Count; i++)
            {
                if (foundPump(queue))
                {
                    Console.WriteLine(counter);
                    break;
                }
                else
                {
                    counter++;
                    queue.Enqueue(queue.Dequeue());
                }                
            }
        }

        static bool foundPump(Queue<PetrolPump> queue)
        {
            Queue<PetrolPump> testQueue = new Queue<PetrolPump>(queue);
            int currentPetrol = 0;

            for (int i = 0; i < queue.Count; i++)
            {
                var currentPump = testQueue.Dequeue();
                currentPetrol += currentPump._petrolAmount - currentPump._nextPetrolDistance;
                if (currentPetrol >= 0)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        class PetrolPump
        {
            public int _petrolAmount { get; set; }
            public int _nextPetrolDistance { get; set; }

            public PetrolPump(int petrolAmount, int nextPetrolDistance)
            {
                _petrolAmount = petrolAmount;
                _nextPetrolDistance = nextPetrolDistance;
            }
        }
    }
}
