namespace _8.Models.Animals
{
    using System;
    using System.Linq;
    using _8.Exceptions;
    using _8.Models.Interfaces;
    using System.Collections.Generic;

    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        protected virtual double WeightIncrease { get; }

        protected abstract IReadOnlyCollection<Type> AllowedFoods { get; }

        public void Eat(IFood food)
        {
            if (!AllowedFoods.Contains(food.GetType()))
            {
                ThrowInvalidFoodException(this, food);
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * WeightIncrease;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

        private void ThrowInvalidFoodException(IAnimal animal, IFood food)
        {
            throw new ArgumentException
                    (string.Format(ExceptionMessage.InvalidWantedFood, animal.GetType().Name, food.GetType().Name));
        }

    }
}
