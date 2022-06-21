using Abstract_Classes;
using System.Collections.Generic;

namespace WildFarm.Entities
{
    public class Dog : Mammal
    {
        private const double Multiplier = 0.4;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.AllowedFood = new List<string>()
            {
                nameof(Meat)
            };
        }

        public override string AskForFood()
        {
            return "Woof!";
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
