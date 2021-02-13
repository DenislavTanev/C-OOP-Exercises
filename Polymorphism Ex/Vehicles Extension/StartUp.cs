using MilitaryElite.IO;
using MilitaryElite.IO.Contracts;
using System;
using Vehicles.Core;
using Vehicles.Core.Contracts;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
