using CommandPattern.Utilities.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Utilities
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args.Split(' ');

            string commandName = cmdArgs[0];
            string[] commandArgs = cmdArgs
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type intendedCmdType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (intendedCmdType == null)
            {
                throw new InvalidOperationException("Command doesn't exist.");
            }

            var cmdInstance = Activator.CreateInstance(intendedCmdType);
            MethodInfo executeMethodInfo = intendedCmdType
                .GetMethod("Execute");

            if (executeMethodInfo == null)
            {
                throw new InvalidOperationException("Command does not implement required pattern. Implement ICommand.");
            }

            string result = executeMethodInfo.Invoke(cmdInstance, new object[] { commandArgs }).ToString();

            return result;
        }
    }
}
