using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var splitted = command.Split();
                people.Add(new Person(splitted[0], int.Parse(splitted[1]), splitted[2]));
            }

            int start = int.Parse(Console.ReadLine());

            var foundPerson = people[start - 1];

            int equalCount = 0;
            int notEqualCount = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (foundPerson.CompareTo(people[i]) == 0)
                {
                    equalCount++;
                }
                else
                {
                    notEqualCount++;
                }
            }

            if (equalCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {notEqualCount} {people.Count}");
            }
        }
    }
}
