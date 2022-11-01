using BirthdayCelebrations.Classes;
using BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> citizens = new List<IBirthable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var splittedCommand = command.Split();
                if (splittedCommand[0] == "Citizen")
                {
                    citizens.Add(new Citizen(splittedCommand[1], int.Parse(splittedCommand[2]), splittedCommand[3], splittedCommand[4]));
                }
                else if(splittedCommand[0] == "Pet")
                {
                    citizens.Add(new Pet(splittedCommand[1], splittedCommand[2]));
                }
            }

            string yearBorn = Console.ReadLine();

            foreach (var citizen in citizens)
            {
                if (citizen.Birthdate.EndsWith(yearBorn))
                {
                    Console.WriteLine(citizen.Birthdate);
                }
            }
        }
    }
}
