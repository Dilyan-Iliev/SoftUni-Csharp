namespace _8.Models.Animals.Birds
{
    using _8.Models.Foods;
    using _8.Models.Interfaces;
    using System;
    using System.Collections.Generic;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override IReadOnlyCollection<Type> AllowedFoods
            => new List<Type> { typeof(Meat) }.AsReadOnly();
        protected override double WeightIncrease => 0.25;

        //public override void Eat(IFood food)
        //{
        //    if (!(food is Meat))
        //    {
        //        ThrowInvalidFoodException(this, food);
        //    }

        //    this.FoodEaten += food.Quantity;
        //    this.Weight += food.Quantity * WeightIncrease;
        //}

        public override string ProduceSound()
           => "Hoot Hoot";
    }
}
