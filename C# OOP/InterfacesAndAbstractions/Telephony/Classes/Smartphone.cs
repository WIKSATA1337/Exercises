using System.Linq;
using System;
using Telephony.Interfaces;

namespace Telephony.Classes
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string link)
        {
            bool invalidLink = link.Any(c => char.IsDigit(c));
            if (invalidLink)
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {link}!");
            }
        }

        public void Call(string number)
        {
            bool invalidNumber = number.Any(c => !char.IsDigit(c));
            if (invalidNumber)
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {number}");
            }
        }
    }
}
