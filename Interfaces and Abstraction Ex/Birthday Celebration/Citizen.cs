using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    public class Citizen : IIdentifiable, IBirthable, IName,IAge
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }

        public string Id { get; private set; }

        public DateTime Birthdate { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }
    }
}
