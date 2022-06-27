using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_farm.Abstract_Classes
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; set; }

        //това е абстрактен клас, поради което не съм задължен да имплементирам абстрактните неща от Animal

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
