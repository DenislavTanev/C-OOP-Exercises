using Raiding.Core;
using Raiding.IO;
using System;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ConsoleReader reader = new ConsoleReader();
            ConsoleWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
