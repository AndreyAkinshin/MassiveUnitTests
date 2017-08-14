namespace Generator.Commands
{
    public class CleanCommand : CommandBase
    {
        public static ICommand Instance = new CleanCommand();
        
        public override string Name => "clean";

        public override void Run(SmartArgs args)
        {
        }
    }
}