using System;

namespace OldestFamilyMember
{
    public class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                Person currPerson = new Person(input[0], int.Parse(input[1]));

                family.AddMember(currPerson);
            }

            var oldestMember = family.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
