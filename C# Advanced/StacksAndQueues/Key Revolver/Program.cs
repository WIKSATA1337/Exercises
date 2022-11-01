using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunSize = int.Parse(Console.ReadLine());
            int[] bulletsArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] locksArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int intelligence = int.Parse(Console.ReadLine());
            int ammoShot = 0;
            int moneyForBullets = 0;

            Queue<int> locksQueue = new Queue<int>(locksArray);
            Stack<int> bulletsQueue = new Stack<int>(bulletsArray);

            while(bulletsQueue.Any() && locksQueue.Any())
            {
                int currentBullet = bulletsQueue.Pop();
                moneyForBullets += bulletPrice;
                ammoShot++;

                if (currentBullet <= locksQueue.Peek())
                {
                    locksQueue.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (ammoShot % gunSize == 0 && bulletsQueue.Any())
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if(locksQueue.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                Console.WriteLine($"{bulletsQueue.Count} bullets left. Earned ${intelligence - moneyForBullets}");
            }
        }
    }
}