using System;
using System.Linq;
using Generator.Commands;

namespace Generator
{
    public class Program
    {
        private static readonly ICommand[] Commands =
        {
            HelpCommand.Instance,
            GenerateListCommand.Instance,
            GenerateTreeCommand.Instance,
            CleanCommand.Instance
        };

        public static void Main(string[] args)
        {
            var smartArgs = new SmartArgs(args);
            var commandName = smartArgs.FirstAsString();
            var targetCommand =
                Commands.FirstOrDefault(c => string.Equals(c.Name, commandName, StringComparison.OrdinalIgnoreCase))
                ?? Commands.First();
            Console.WriteLine("Args[TargetCommand] = " + targetCommand.Name);
            targetCommand.Init();
            targetCommand.Run(smartArgs.SkipOne());
            Console.WriteLine("DONE");
        }
    }
}