using System;
using System.Collections.Generic;

namespace P._04_PizzaCalories
{
    public class Dough
    {
        private const string DoughExceptionMessage = "Invalid type of dough.";
        private const string WeightExceptionMessage = "Dough weight should be in the range [1..200].";

        private Dictionary<string, double> flourTypeCalories = new Dictionary<string, double>
        {
            {"white", 1.5 },
            {"wholegrain", 1 }
        };

        private Dictionary<string, double> bakingTechniqueCalories = new Dictionary<string, double>
        {
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1 }
        };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (!flourTypeCalories.ContainsKey(value.ToLower())) //ако не е сред предифинираните стойности на речника
                {
                    throw new ArgumentException(DoughExceptionMessage);
                }

                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!bakingTechniqueCalories.ContainsKey(value.ToLower())) //ако не е сред предифинираните стойности на речника
                {
                    throw new ArgumentException(DoughExceptionMessage);
                }

                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(WeightExceptionMessage);
                }

                weight = value;
            }
        }

        public double Calories 
            => 2 * Weight * this.flourTypeCalories[this.FlourType.ToLower()] * this.bakingTechniqueCalories[this.BakingTechnique.ToLower()];
        // 2 * теглото * предефинираните калории на вида брашно от речника * предефинираните калории на вида техника

    }
}
