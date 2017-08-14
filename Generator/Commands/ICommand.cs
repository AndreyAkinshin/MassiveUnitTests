namespace Generator.Commands
{
    public interface ICommand
    {
        string Name { get; }

        void Init();
        void Run(SmartArgs args);
    }
}