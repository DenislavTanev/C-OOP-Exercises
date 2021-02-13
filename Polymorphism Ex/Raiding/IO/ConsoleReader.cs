using Raiding.IO.Contracts;
using System;

namespace Raiding.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
