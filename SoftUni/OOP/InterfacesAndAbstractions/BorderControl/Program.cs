using BorderControl.Classes;
using BorderControl.Interfaces;
using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> soldiers = new List<IIdentifiable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var splittedCommand = command.Split();
                if (splittedCommand.Length == 2)
                {
                    soldiers.Add(new Robot(splittedCommand[0], splittedCommand[1]));
                }
                else
                {
                    soldiers.Add(new Citizen(splittedCommand[0], int.Parse(splittedCommand[1]), splittedCommand[2]));
                }
            }

            string containsNumber = Console.ReadLine();

            foreach (var soldier in soldiers)
            {
                if (soldier.Id.EndsWith(containsNumber))
                {
                    Console.WriteLine(soldier.Id);
                }
            }
        }
    }
}
