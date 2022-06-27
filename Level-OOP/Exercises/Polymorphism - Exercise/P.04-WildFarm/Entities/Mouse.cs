using System;
using System.Collections.Generic;
using System.Text;
using Wild_farm.Abstract_Classes;
using Wild_farm.Interfaces;

namespace Wild_farm.Entities
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Fruit)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * 0.1;
            }
            else
            {
                ThrowInvalidOperationExceptionForFood(this, food);
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
