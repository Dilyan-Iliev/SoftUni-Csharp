namespace _8.Models.Animals.Mammals
{
    using _8.Models.Foods;
    using _8.Models.Interfaces;
    using System;
    using System.Collections.Generic;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<Type> AllowedFoods
            => new List<Type> { typeof(Fruit), typeof(Vegetable) }.AsReadOnly();

        protected override double WeightIncrease => 0.1;

        //public override void Eat(IFood food)
        //{
        //    if (food is Fruit || food is Vegetable)
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
           => "Squeak";

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
