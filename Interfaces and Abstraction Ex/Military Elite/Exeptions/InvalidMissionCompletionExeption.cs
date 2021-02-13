using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exeptions
{
   public class InvalidMissionCompletionExeption:Exception
    {
        private const string DEF_EXC_MSG = "Mission already completed!";

        public InvalidMissionCompletionExeption()
            :base(DEF_EXC_MSG)
        {
        }

        public InvalidMissionCompletionExeption(string message) 
            : base(message)
        {
        }
    }
}
