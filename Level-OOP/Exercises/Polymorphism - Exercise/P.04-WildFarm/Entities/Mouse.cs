using Abstract_Classes;
using System;
using System.Collections.Generic;

namespace WildFarm.Entities
{
    public class Mouse : Mammal
    {
        private const double Multiplier = 0.1;
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.AllowedFood = new List<string>()
            {
                nameof(Vegetable),
                nameof(Fruit)
            };
        }

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override void Eat(Food food)
        {
            this.TryEat(food, Multiplier);
        }
        public override string ToString()
        {
            return $"{base.ToString()}{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
