using Abstract_Classes;
using System.Collections.Generic;

namespace WildFarm.Entities
{
    internal class Owl : Bird
    {
        private const double Multiplier = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.AllowedFood = new List<string>()
            {
                nameof(Meat)
            };
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override void Eat(Food food)
        {
            this.TryEat(food, Multiplier);
        }
    }
}
