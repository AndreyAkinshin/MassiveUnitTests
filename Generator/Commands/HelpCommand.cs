using System;

namespace Generator.Commands
{
    public class HelpCommand : ICommand
    {
        public static ICommand Instance = new HelpCommand();
        
        public string Name => "help";
        
        public void Init()
        {            
        }

        public void Run(SmartArgs args)
        {
            Console.WriteLine("Usage examples:");
            Console.WriteLine("  list");
            Console.WriteLine("  list 100");
            Console.WriteLine("  list 100 body=ex");
            Console.WriteLine("  tree");
            Console.WriteLine("  tree 100");
            Console.WriteLine("  tree 100 body=ex");
            Console.WriteLine("  clean");
            Console.WriteLine("  help");
        }
    }
}