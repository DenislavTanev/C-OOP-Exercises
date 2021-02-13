using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.IO.Contracts;

namespace Vehicles.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
             return Console.ReadLine();
        }
    }
}
