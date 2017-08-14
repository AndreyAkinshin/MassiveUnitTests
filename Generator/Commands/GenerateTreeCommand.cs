using System;
using System.IO;

namespace Generator.Commands
{
    public class GenerateTreeCommand : CommandBase
    {
        public static ICommand Instance = new GenerateTreeCommand();

        public override string Name => "tree";

        public override void Run(SmartArgs args)
        {
            var n = args.FirstAsInt() ?? 100;
            var body = args.GetUnitTestBody();
            Console.WriteLine("Args[N] = " + n);
            Console.WriteLine("Args[Body] = " + (body == "" ? "<empty>" : body));


            var finished = 0;
            for (int indexA = 0; finished < n; indexA++)
            for (int indexB = 0; indexB < 10 && finished < n; indexB++)
            for (int indexC = 0; indexC < 10 && finished < n; indexC++)
            {
                var path = Path.Combine("A" + indexA.ToString().PadLeft(3, '0'), "B" + indexB, "TestClass" + indexC);
                var codeName = indexA.ToString().PadLeft(3, '0') + indexB + indexC;
                var count = Math.Min(n - finished, 10);
                var content = UnitTestClassBuilder.Build(codeName, finished, count, body);
                finished += count;
                GenerateFile(path, content);
            }
        }
    }
}