using CommandPattern.Models.Contracts;

namespace CommandPattern.Models
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
