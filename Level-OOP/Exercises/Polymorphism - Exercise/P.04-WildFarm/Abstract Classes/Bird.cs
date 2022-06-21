using System;
using System.Collections.Generic;
using System.Text;

namespace Abstract_Classes
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()}{WingSize}, {this.Weight}, {FoodEaten}]";
        }
    }
}
