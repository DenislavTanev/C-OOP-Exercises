using System;
using Vehicles.Core;
using Vehicles.IO;

namespace Vehicles
{
    class Program
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
