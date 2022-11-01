using System.Linq;
using System;
using Telephony.Interfaces;

namespace Telephony.Classes
{
    public class StationaryPhone : ICallable
    {
        public void Call(string number)
        {
            bool invalidNumber = number.Any(c => !char.IsDigit(c));
            if (invalidNumber)
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Dialing... {number}");
            }
        }
    }
}
