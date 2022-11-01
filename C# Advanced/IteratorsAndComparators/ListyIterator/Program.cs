using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            var iterator = new ListyIterator<string>(elements);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(iterator.Move());
                }
                else if (command == "Print")
                {
                    try
                    {
                        iterator.Print();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
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
            internalList = list;
        }

        public bool Move()
        {
            if (currentIndex < internalList.Count - 1)
            {
                currentIndex++;
                return true;
            }
            return false;
        }
        public void Print()
        {
            if (internalList.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(internalList[currentIndex]);
        }
        public bool HasNext()
        {
            return currentIndex < internalList.Count - 1;
        }
    }
}
