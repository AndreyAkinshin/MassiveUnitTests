using System;
using System.IO;

namespace Generator.Commands
{
    public abstract class CommandBase : ICommand
    {
        public abstract string Name { get; }

        protected DirectoryInfo Root { get; private set; }

        public void Init()
        {
            Root = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "..", "UnitTestProject", "Tests"));
            if (Root.Exists)
                Root.Delete(true);            
            Root.Create();
        }

        public abstract void Run(SmartArgs args);

        protected void GenerateFile(string path, string content)
        {
            Console.WriteLine("Generate: " + path);
            
            var fileInfo = new FileInfo(Path.Combine(Root.FullName, path + ".cs"));
            var dirInfo = fileInfo.Directory;
            if (!dirInfo.Exists)
                dirInfo.Create();
            File.WriteAllText(fileInfo.FullName, content);
        }
    }
}