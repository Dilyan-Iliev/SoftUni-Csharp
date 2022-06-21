using Abstract_Classes;
using System.Collections.Generic;

namespace WildFarm.Entities
{
    public class Cat : Feline
    {
        private const double Multiplier = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.AllowedFood = new List<string>()
            {
                nameof(Vegetable),
                nameof(Meat)
            };
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override void Eat(Food food)
        {
            this.TryEat(food, Multiplier);
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
