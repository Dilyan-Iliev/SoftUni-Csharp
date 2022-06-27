using System;
using System.Collections.Generic;
using System.Text;
using Wild_farm.Abstract_Classes;
using Wild_farm.Interfaces;

namespace Wild_farm.Entities
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (!(food is Meat))
            {
                ThrowInvalidOperationExceptionForFood(this, food);
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * 0.4;
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
