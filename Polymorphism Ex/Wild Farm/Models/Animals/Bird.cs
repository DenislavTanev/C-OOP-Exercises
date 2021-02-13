using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten)
        {
            this.WingSize = wingSize;
        }
        public double WingSize { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
