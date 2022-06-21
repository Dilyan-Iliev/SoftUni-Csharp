using System;
using System.Collections.Generic;
using WildFarm.Interfaces;

namespace Abstract_Classes
{
    public abstract class Animal : IAskForFood
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            AllowedFood = new List<string>();
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten => this.Count;
        protected int Count { get; private set; }
        public abstract string AskForFood();
        protected ICollection<string> AllowedFood { get; set; }
        public abstract void Eat(Food food);
        protected void TryEat(Food food, double multiplier)
        {
            if (!AllowedFood.Contains(food.GetType().Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * multiplier;
            Count += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
