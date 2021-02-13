using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    public class Pet : IName, IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }

        public DateTime Birthdate { get; private set; }

        public string Name { get; private set; }
    }
}
