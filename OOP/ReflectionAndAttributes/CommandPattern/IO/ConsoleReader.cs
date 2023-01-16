using CommandPattern.IO.Contracts;
using System;

namespace CommandPattern.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        => Console.ReadLine();
    }
}
