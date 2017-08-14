using System;

namespace Generator.Commands
{
    public class GenerateListCommand : CommandBase
    {
        public static ICommand Instance = new GenerateListCommand();

        public override string Name => "list";

        public override void Run(SmartArgs args)
        {
            var n = args.FirstAsInt() ?? 100;
            var body = args.GetUnitTestBody();
            Console.WriteLine("Args[N] = " + n);
            Console.WriteLine("Args[Body] = " + (body == "" ? "<empty>" : body));
            GenerateFile("AllUnitTests", UnitTestClassBuilder.Build("All", 0, n, body));
        }
    }
}