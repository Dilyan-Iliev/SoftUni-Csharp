namespace _8.Models.Animals.Mammals
{
    using System;
    using _8.Models.Foods;
    using System.Collections.Generic;

    public class Dog : Mammal
    { 
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<Type> AllowedFoods
            => new List<Type> { typeof(Meat) }.AsReadOnly();
        protected override double WeightIncrease => 0.4;
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
           => "Woof!";

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
