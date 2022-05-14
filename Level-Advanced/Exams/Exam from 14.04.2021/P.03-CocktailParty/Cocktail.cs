using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Dictionary<string, Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; } //the maximum allowed number of ingredients in the cocktail
        public int MaxAlcoholLevel { get; set; } //the maximum allowed amount of alcohol in the cocktail

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;

            this.Ingredients = new Dictionary<string, Ingredient>();
        }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.ContainsKey(ingredient.Name)
                && Ingredients.Count < Capacity)
            {
                Ingredients[ingredient.Name] = ingredient;
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = Ingredients[name];

            if (ingredient.Name == name)
            {
                Ingredients.Remove(name);

                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = Ingredients.Where(x => x.Value.Name == name)
                .FirstOrDefault().Value;

            if (ingredient != null)
            {
                return ingredient;
            }

            return null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient ingredient = null;
            int maxAlcohol = int.MinValue;

            foreach (var item in Ingredients.Values)
            {
                if (item.Alcohol > maxAlcohol)
                {
                    maxAlcohol = item.Alcohol;
                    ingredient = item;
                }
            }

            return ingredient;
        }
        public int CurrentAlcoholLevel // or => Ingredients.Sum(x => x.Value.Alcohol);
        {
            get
            {
                int alcohol = 0;
                foreach (var item in Ingredients.Values)
                {
                    alcohol += item.Alcohol;
                }

                return alcohol;
            }
        }
        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var item in Ingredients.Values)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
