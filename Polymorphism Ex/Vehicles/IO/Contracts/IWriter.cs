using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.IO.Contracts
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(string text);
    }
}
