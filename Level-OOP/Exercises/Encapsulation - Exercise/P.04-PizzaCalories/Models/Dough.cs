using System;
using System.Collections.Generic;

namespace _5.Models
{
    public class Dough
    {
        //---------------Fields-----------------
        private Dictionary<string, double> flourTypes = new Dictionary<string, double>()
        {
            { "white", 1.5 },
            { "wholegrain", 1 }
        };

        private Dictionary<string, double> bakingTechniques = new Dictionary<string, double>()
        {
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1 }
        };

        private const int DefaultCaloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        //-----------Constructors-------------
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        //------------Properties-------------
        public string FlourType
        {
            get => flourType;
            private set
            {
                if (!flourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (!bakingTechniques.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }

        //----------Methods-------------
        public double Calories
        => DefaultCaloriesPerGram * Weight
            * flourTypes[FlourType.ToLower()] * bakingTechniques[BakingTechnique.ToLower()];
    }
}
