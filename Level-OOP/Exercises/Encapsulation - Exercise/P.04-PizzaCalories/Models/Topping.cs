using System;
using System.Collections.Generic;

namespace _5.Models
{
    public class Topping
    {
        private Dictionary<string, double> toppings = new Dictionary<string, double>()
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
        };

        private const int DefaultCaloriesPerGram = 2;

        private double weight;
        private string type;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get => type;
            private set
            {
                if (!toppings.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }
        public double Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }

        public double Calories
            => DefaultCaloriesPerGram * Weight * toppings[Type.ToLower()];
    }
}
