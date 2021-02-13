using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ValidationAttributes.Atributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int MIN_AGE = 15;
        private const int MAX_AGE = 90; 
        public Person(string fullName,int age)
        {
            this.FullName = fullName;
            this.Age = age;

        }
        [MyRequiredAttribute]
        public string FullName { get; private set; }
        [MyRange(MIN_AGE,MAX_AGE)]
        public int Age { get; private set; }

    }
}
