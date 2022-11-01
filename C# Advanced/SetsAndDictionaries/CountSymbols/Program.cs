using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> dict = new SortedDictionary<string, int>();
            string sentence = Console.ReadLine();

            for (int i = 0; i < sentence.Length; i++)
            {
                if (!dict.ContainsKey(sentence[i].ToString()))
                {
                    dict.Add(sentence[i].ToString(), 0);
                }

                dict[sentence[i].ToString()] += 1;
            }

            var keys = dict.Keys.ToList();
            var sortedKeys = new List<char>();

            for (int i = 0; i < keys.Count; i++)
            {
                sortedKeys.Add(char.Parse(keys[i]));
            }

            sortedKeys.Sort();

            foreach (var key in sortedKeys)
            {
                Console.WriteLine($"{key}: {dict[key.ToString()]} time/s");
            }
        }
    }
}
