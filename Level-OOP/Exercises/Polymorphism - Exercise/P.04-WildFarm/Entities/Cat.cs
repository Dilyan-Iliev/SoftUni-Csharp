using System;
using System.Collections.Generic;
using System.Text;
using Wild_farm.Abstract_Classes;
using Wild_farm.Interfaces;

namespace Wild_farm.Entities
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Meat)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * 0.3;
            }
            else
            {
                ThrowInvalidOperationExceptionForFood(this, food);
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
        
    }
}
