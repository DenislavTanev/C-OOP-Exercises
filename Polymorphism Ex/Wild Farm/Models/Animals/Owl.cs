using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override string ProducingSound()
        {
            return "Hoot Hoot";
        }
    }
}
