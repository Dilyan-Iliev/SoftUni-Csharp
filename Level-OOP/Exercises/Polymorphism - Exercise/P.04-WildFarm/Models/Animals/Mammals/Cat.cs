namespace _8.Models.Animals.Mammals
{
    using _8.Models.Foods;
    using _8.Models.Interfaces;
    using System;
    using System.Collections.Generic;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<Type> AllowedFoods
            => new List<Type> { typeof(Meat), typeof(Vegetable) }.AsReadOnly();
        protected override double WeightIncrease => 0.3;

        //public override void Eat(IFood food)
        //{
        //    if (food is Meat || food is Vegetable)
        //    {
        //        this.FoodEaten += food.Quantity;
        //        this.Weight += food.Quantity * WeightIncrease;
        //    }
        //    else
        //    {
        //        ThrowInvalidFoodException(this, food);
        //    }
        //}

        public override string ProduceSound()
           => "Meow";
    }
}
