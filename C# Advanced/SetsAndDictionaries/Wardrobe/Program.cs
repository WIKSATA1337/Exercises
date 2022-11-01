using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < count; i++)
            {
                string[] rowInfo = Console.ReadLine().Split(" -> ");

                string color = rowInfo[0];
                List<string> clothes = rowInfo[1].Split(',').ToList();

                if (!dict.ContainsKey(color))
                {
                    Dictionary<string, int> clothesInfo = new Dictionary<string, int>();

                    for (int j = 0; j < clothes.Count; j++)
                    {
                        if (!clothesInfo.ContainsKey(clothes[j]))
                        {
                            clothesInfo.Add(clothes[j], 0);
                        }

                        clothesInfo[clothes[j]]++;
                    }

                    dict.Add(color, clothesInfo);
                }
                else
                {
                    Dictionary<string, int> currentDictClothesInfo = dict[color];

                    for (int j = 0; j < clothes.Count; j++)
                    {
                        if (!currentDictClothesInfo.ContainsKey(clothes[j]))
                        {
                            currentDictClothesInfo.Add(clothes[j], 0);
                            
                        }

                        currentDictClothesInfo[clothes[j]]++;
                    }
                }
            }

            string[] searching = Console.ReadLine().Split();

            foreach (var elem in dict)
            {
                Console.WriteLine($"{elem.Key} clothes:");
                foreach (var cloth in elem.Value)
                {
                    if (cloth.Key == searching[1] && searching[0] == elem.Key)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
