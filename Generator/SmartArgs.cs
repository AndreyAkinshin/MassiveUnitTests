using System;
using System.Linq;

namespace Generator
{
    public class SmartArgs
    {
        public string[] AllArgs { get; }

        public SmartArgs(string[] args)
        {
            AllArgs = args;
        }

        public SmartArgs SkipOne() => new SmartArgs(AllArgs.Length == 0 ? AllArgs : AllArgs.Skip(1).ToArray());

        public string FirstAsString() => AllArgs.Length == 0 ? null : AllArgs[0];

        public int? FirstAsInt()
        {
            if (AllArgs.Length == 0)
                return null;
            return int.TryParse(AllArgs[0], out int value) ? (int?) value : null;
        }

        public string GetUnitTestBody()
        {
            if (AllArgs.Any(arg => arg.StartsWith("body=ex", StringComparison.OrdinalIgnoreCase)))
                return "throw new Exception(\"=(\");";
            return "";
        }
    }
}