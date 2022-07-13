namespace _8.Models.Animals.Birds
{
    using System;
    using _8.Models.Foods;
    using System.Collections.Generic;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override IReadOnlyCollection<Type> AllowedFoods
            => new List<Type> { typeof (Meat), typeof (Fruit)
            , typeof (Vegetable), typeof(Seeds) }.AsReadOnly();
        protected override double WeightIncrease => 0.35;

        //public override void Eat(IFood food)
        //{
        //    this.FoodEaten += food.Quantity;
        //    this.Weight += food.Quantity * WeightIncrease;
        //}

        public override string ProduceSound()
           => "Cluck";
    }
}
