using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        public string Name { get; set; }
        public int Alcohol { get; set; }
        public int Quantity { get; set; }

        public Ingredient(string name, int alcohol, int quantity)
        {
            this.Name = name;
            this.Alcohol = alcohol;
            this.Quantity = quantity;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Ingredient: {Name}");
            sb.AppendLine($"Quantity: {Quantity}");
            sb.Append($"Alcohol: {Alcohol}");

            return sb.ToString();
        }
    }
}
