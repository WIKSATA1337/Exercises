using System;
using System.Collections.Generic;
using System.Linq;
using Telephony.Classes;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            List<string> phoneNumbers = Console.ReadLine()
                .Split()
                .ToList();

            List<string> links = Console.ReadLine()
                .Split()
                .ToList();

            foreach (var number in phoneNumbers)
            {
                if (number.Length == 10)
                {
                    smartphone.Call(number);
                }
                else
                {
                    stationaryPhone.Call(number);
                }
            }

            foreach (var link in links)
            {
                smartphone.Browse(link);
            }
        }
    }
}
