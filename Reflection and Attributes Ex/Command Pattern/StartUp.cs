using CommandPattern.Core;
using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
             engine.Run();        
        }
    }
}
