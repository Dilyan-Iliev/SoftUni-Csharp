namespace _8.Models.Animals.Mammals
{
    using _8.Models.Foods;
    using _8.Models.Interfaces;
    using System;
    using System.Collections.Generic;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<Type> AllowedFoods
            => new List<Type> { typeof(Meat) }.AsReadOnly();

        protected override double WeightIncrease => 1;

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
           => "ROAR!!!";
    }
}
