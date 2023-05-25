using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Ex. 1 => ListyIterator
            List<int> elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Skip(1)
                .ToList();

            var iterator = new ListyIterator<int>(elements);

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(iterator.Move());
                }
                else if (command == "Print")
                {
                    iterator.Print();
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(iterator.HasNext());
                }
            }
        }
    }
    public class ListyIterator<T>
    {
        private List<T> internalList;
        private int currentIndex = 0;
        public ListyIterator(List<T> list)
        {
            internalList = new List<T>(list);
        }

        public bool Move()
        {
            return ++currentIndex < internalList.Count;
        }
        public void Print()
        {
            try
            {
                Console.WriteLine(internalList[currentIndex]);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }
        public bool HasNext()
        {
            return currentIndex + 1 < internalList.Count;
        }
    }
}
