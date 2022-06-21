using Abstract_Classes;
using System.Collections.Generic;

namespace WildFarm.Entities
{
    public class Hem : Bird
    {
        private const double Multiplier = 0.35;
        public Hem(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.AllowedFood = new List<string>()
            {
                nameof(Vegetable),
                nameof(Fruit),
                nameof(Meat),
                nameof(Seeds)
            };
        }

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override void Eat(Food food)
        {
            this.TryEat(food, Multiplier);
        }
    }
}
