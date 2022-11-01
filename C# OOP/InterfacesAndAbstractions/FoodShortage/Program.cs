using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int totalFoodBought = 0;

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split();

                if (personInfo.Length == 3)
                {
                    buyers.Add(new Rebel(personInfo[0], int.Parse(personInfo[1]), personInfo[2]));
                }
                else
                {
                    buyers.Add(new Citizen(personInfo[0], int.Parse(personInfo[1]), personInfo[2], personInfo[3]));
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var foundBuyer = buyers.FirstOrDefault(b => b.Name == command);

                if (foundBuyer != null)
                {
                    foundBuyer.BuyFood();
                }
            }

            foreach (var buyer in buyers)
            {
                totalFoodBought += buyer.Food;
            }

            Console.WriteLine(totalFoodBought);
        }
    }
}
