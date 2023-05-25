using System;
using System.Collections.Generic;
using System.Net;

namespace GenericCountMethodIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<double> list = new List<double>();

            for (int i = 0; i < count; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            double searchingElement = double.Parse(Console.ReadLine());

            OccurrencesCount<double> occ = new OccurrencesCount<double>();
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
                if (Comparer<T>.Default.Compare(item, element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
