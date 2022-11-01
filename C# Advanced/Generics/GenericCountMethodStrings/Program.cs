using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();

            for (int i = 0; i < count; i++)
            {
                list.Add(Console.ReadLine());
            }

            string searchingElement = Console.ReadLine();

            OccurrencesCount<string> occ = new OccurrencesCount<string>();
            Console.WriteLine(occ.Occurrences(list, searchingElement)); 
        }
    }

    public class OccurrencesCount<T> where T : IComparable<T>
    {
        public int Occurrences(List<T> list, T element)
        {
            int counter = 0;

            foreach (var item in list)
            {
                if (element.CompareTo(item) == -1)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
