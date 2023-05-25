using CommandPattern.Models.Contracts;
using System;

namespace CommandPattern.Models
{
    public class ExitCommand : ICommand
    {
        private const int DefaultErrorCode = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(DefaultErrorCode);
            return null;
        }
    }
}
