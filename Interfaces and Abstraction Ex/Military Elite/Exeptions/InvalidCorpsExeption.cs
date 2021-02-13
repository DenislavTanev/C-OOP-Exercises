using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exeptions
{
    public class InvalidCorpsExeption:Exception
    {
        private const string Def_EXC_MSG = "Invalid corps!";
        public InvalidCorpsExeption()
            :base(Def_EXC_MSG)
        {
            
        }

        public InvalidCorpsExeption(string message) :
            base(message)
        {
        }
    }
}
