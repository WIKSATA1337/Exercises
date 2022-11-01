using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split()
                .ToList();

            string command;

            List<string> filters = new List<string>();

            while ((command = Console.ReadLine()) != "Print")
            {
                string[] splittedCommand = command.Split(';');
                string addOrRemove = splittedCommand[0].Split().FirstOrDefault();
                string cmd = splittedCommand[1].Split().FirstOrDefault();
                string letter = splittedCommand[2];

                if (addOrRemove == "Add")
                {
                    filters.Add($"{cmd} {letter}");
                }
                else
                {
                    filters.Remove($"{cmd} {letter}");
                }
                
            }

            foreach (var filter in filters)
            {
                string[] arguments = filter.Split();

                if (arguments[0] == "Starts")
                {
                    people = people.Where(person => !person.StartsWith(arguments[1])).ToList();
                }
                else if (arguments[0] == "Ends")
                {
                    people = people.Where(person => !person.EndsWith(arguments[1])).ToList();
                }
                else if (arguments[0] == "Contains")
                {
                    people = people.Where(person => !person.Contains(arguments[1])).ToList();
                }
                else if (arguments[0] == "Length")
                {
                    people = people.Where(person => !(person.Length == int.Parse(arguments[1]))).ToList();
                }
            }

            Console.WriteLine(String.Join(' ', people));
        }
    }
}
